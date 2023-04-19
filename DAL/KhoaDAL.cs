using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAL
{
    public class KhoaDAL
    {
        DatabaseAccess dba = new DatabaseAccess();
        public DataTable LoadKhoa()
        {
            string sql = "select * from TblKhoa where Huy = 0";
            return dba.get_DaTaTable(sql);
        }
        public string CheckMaKhoa(string maKhoa)
        {
            string sql = "SELECT COUNT(*) AS Count FROM TblKhoa WHERE MaKhoa = N'" + maKhoa + "'";
            return dba.ThucThiCLSelect(sql);
        }
        public DataTable LoadKhoaTheo(string _maKhoa="",int _idKhoa=0)
        {
            string sql = $" Declare @MaKhoa nvarchar(500)='{_maKhoa}',@IDKhoa bigint={_idKhoa}; select * from TblKhoa  where (@MaKhoa='' or @MaKhoa is null or MaKhoa=@MaKhoa) and (@IDKhoa='' or @IDKhoa is null or ID=@IDKhoa) ";
            return dba.get_DaTaTable(sql);
        }
        public DataTable LoadKhoaTheoDieuKien(string maKhoa, string tenKhoa)
        {
            try
            {
                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@MaKhoa", maKhoa),
                    new SqlParameter("@TenKhoa", tenKhoa)
                };
                DataTable dt = dba.ExcStoredProcedure("spLoadKhoaTheoDieuKien", parameters);
                return dt;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public long ThaoTacKhoa_Store(long idKhoa, string maKhoa, string tenKhoa,string chuThich,string nguoiTao, string nguoiCapNhat, EnumDto.eThaoTac eAction)
        {
            try
            {
                long result = 0;
                string spName = "[ThemKhoa_Store]";
                switch (eAction)
                {
                    case EnumDto.eThaoTac.sua:
                        spName = "[SuaKhoa_Store]";
                        break;
                    case EnumDto.eThaoTac.xoa:
                        spName = "[XoaKhoa_Store]";
                        break;
                }
                SqlConnection con = new SqlConnection(ServerShareDto.connect);
                SqlCommand cmd = new SqlCommand(spName, con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@MaKhoa", maKhoa);
                cmd.Parameters.AddWithValue("@TenKhoa", tenKhoa);
                cmd.Parameters.AddWithValue("@ChuThich", chuThich);

                switch (eAction)
                {
                    case EnumDto.eThaoTac.them:
                        cmd.Parameters.Add("@ID", SqlDbType.BigInt);
                        cmd.Parameters["@ID"].Direction = ParameterDirection.Output;
                        cmd.Parameters.AddWithValue("@NguoiTao", nguoiTao);
                        break;
                    case EnumDto.eThaoTac.sua:
                        cmd.Parameters.AddWithValue("@ID", idKhoa);
                        cmd.Parameters.AddWithValue("@NguoiCapNhat", nguoiCapNhat);
                        break;
                    case EnumDto.eThaoTac.xoa:
                        cmd.Parameters.AddWithValue("@ID", idKhoa);
                        cmd.Parameters.AddWithValue("@NguoiCapNhat", nguoiCapNhat);
                        cmd.Parameters.AddWithValue("@Huy", 1);
                        break;
                }

                con.Open();
                int i = cmd.ExecuteNonQuery();

                if (cmd.Parameters["@ID"].Value != null && cmd.Parameters["@ID"].Value != DBNull.Value)
                {
                    result = Convert.ToInt64(cmd.Parameters["@ID"].Value);

                }

                con.Close();
                return result;
            }
            catch (Exception ex)
            {
                return 0;
            }

        }
        
    }
}
