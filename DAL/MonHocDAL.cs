using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class MonHocDAL
    {
        DatabaseAccess dba = new DatabaseAccess();
        public DataTable LoadMonHoc()
        {
            string sql = "select * from TblMonHoc";
            return dba.get_DaTaTable(sql);
        }
        public string CheckMaHocPhan(string maHocPhan)
        {
            string sql = "SELECT COUNT(*) AS Count FROM TblMonHoc WHERE MaHocPhan = N'" + maHocPhan + "' and Huy = 0";
            return dba.ThucThiCLSelect(sql);
        }
        public DataTable LoadMonHocTheoKhoa(int IDKhoa)
        {
            string sql = "select * from TblMonHoc where IDKhoa = N'" + IDKhoa + "'";
            return dba.get_DaTaTable(sql);
        }
        public string LoadNhomCauHoiTheoMonHoc(int IDMon)
        {
            string sql = "select NhomCauHoi from TblMonHoc where ID = N'" + IDMon + "'";          
            return dba.ThucThiCLSelect(sql);
        }
        public string LoadChuThichTheoMonHoc(int IDMon)
        {
            string sql = "select ChuThich from TblMonHoc where ID = N'" + IDMon + "'";
            return dba.ThucThiCLSelect(sql);
        }
        public DataTable LoadMonTheoKhoa(int _idKhoa=0, string _maKhoa="",string _maMon="")
        {
            string sql = $" Declare @IDKhoa bigint={_idKhoa}, @MaKhoa nvarchar(500)='{_maKhoa}',@MaMon nvarchar(500)='{_maMon}' select * from TblMonHoc where Huy = 0 and (@IDKhoa=0 or @IDKhoa is null or IDKhoa=@IDKhoa) and (@MaKhoa='' or @MaKhoa is null or MaKhoa=@MaKhoa) and (@MaMon='' or @MaMon is null or MaMon=@MaMon) ";
            return dba.get_DaTaTable(sql);
        }
        public long ThaoTacMonHoc_Store(long idMonHoc, int idKhoa, string maMon, string tenMon, string maHocPhan, int soTinChi, string nguoiTao, EnumDto.eThaoTac eAction)
        {
            try
            {
                long result = 0;
                string spName = "[ThemMonHoc_Store]";
                switch (eAction)
                {
                    case EnumDto.eThaoTac.sua:
                        spName = "[SuaMonHoc_Store]";
                        break;
                    case EnumDto.eThaoTac.xoa:
                        spName = "[XoaMonHoc_Store]";
                        break;
                }
                SqlConnection con = new SqlConnection(ServerShareDto.connect);
                SqlCommand cmd = new SqlCommand(spName, con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@TenMon", tenMon);
                cmd.Parameters.AddWithValue("@MaHocPhan", maHocPhan);
                cmd.Parameters.AddWithValue("@SoTinChi", soTinChi);
                cmd.Parameters.AddWithValue("@IDKhoa", idKhoa);

                switch (eAction)
                {
                    case EnumDto.eThaoTac.them:
                        cmd.Parameters.Add("@ID", SqlDbType.BigInt);
                        cmd.Parameters["@ID"].Direction = ParameterDirection.Output;
                        cmd.Parameters.AddWithValue("@NguoiTao", nguoiTao);
                        break;
                    case EnumDto.eThaoTac.sua:
                        cmd.Parameters.AddWithValue("@ID", idMonHoc);
                        cmd.Parameters.AddWithValue("@MaMon", maMon);
                        break;
                    case EnumDto.eThaoTac.xoa:
                        cmd.Parameters.AddWithValue("@ID", idMonHoc);
                        cmd.Parameters.AddWithValue("@MaMon", maMon);
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
