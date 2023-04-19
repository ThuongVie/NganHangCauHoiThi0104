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
    public class NhomCauHoiDAL
    {
        DatabaseAccess dba = new DatabaseAccess();

        public DataTable LoadNhomCauHoi()
        {
            string sql = "select * from TblNhomCauHoi";
            return dba.get_DaTaTable(sql);
        }
        public DataTable LoadNhomCauHoiTheoMon(int IDMon)
        {
            string sql = "select * from TblNhomCauHoi where Huy = 0 and IDMonHoc = N'" + IDMon + "'";
            return dba.get_DaTaTable(sql);
        }

        public DataTable LoadNhomCauHoiTheoID(int id)
        {
            string sql = "select * from TblNhomCauHoi where ID = N'" + id + "'";
            return dba.get_DaTaTable(sql);
        }
        public DataTable LoadNhomCauTheoMon(string _maMon)
        {
            string sql = $" select * from TblNhomCauHoi where MaMon='{_maMon}' ";
            return dba.get_DaTaTable(sql);
        }
        public DataTable LoadNhomCauHoiTheoDieuKien(int idKhoa, int idMon, string maNhom, int diem, int thoigiandukien, DateTime tungay, DateTime denngay)
        {
            try
            {
                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@IDKhoa", idKhoa),
                    new SqlParameter("@IDMonHoc", idMon),
                    new SqlParameter("@MaNhom", maNhom),
                    new SqlParameter("@Diem", diem),
                    new SqlParameter("@ThoiGianDuKien", thoigiandukien),
                    new SqlParameter("@tungay", tungay),
                    new SqlParameter("@denngay", denngay)

                };
                DataTable dt = dba.ExcStoredProcedure("spLoadNhomCauHoiTheoDieuKien", parameters);
                return dt;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public long ThaoTacNhomCau_Store(long idNhomCau, int idMonHoc,string maNhom, float diem, int thoiGianDuKien, string chuThich, EnumDto.eThaoTac eAction)
        {
            try
            {
                long result = 0;
                string spName = "[ThemNhomCau_Store]";
                switch (eAction)
                {
                    case EnumDto.eThaoTac.sua:
                        spName = "[SuaNhomCau_Store]";
                        break;
                    case EnumDto.eThaoTac.xoa:
                        spName = "[XoaNhomCau_Store]";
                        break;
                }
                SqlConnection con = new SqlConnection(ServerShareDto.connect);
                SqlCommand cmd = new SqlCommand(spName, con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IDMonHoc", idMonHoc);
                cmd.Parameters.AddWithValue("@Diem", diem);
                cmd.Parameters.AddWithValue("@ThoiGianDuKien", thoiGianDuKien);
                cmd.Parameters.AddWithValue("@ChuThich", chuThich);
                switch (eAction)
                {
                    case EnumDto.eThaoTac.them:                        
                        cmd.Parameters.Add("@ID", SqlDbType.BigInt);
                        cmd.Parameters["@ID"].Direction = ParameterDirection.Output;
                        break;
                    case EnumDto.eThaoTac.sua:
                        cmd.Parameters.AddWithValue("@ID", idNhomCau);
                        cmd.Parameters.AddWithValue("@MaNhom", maNhom);
                        break;
                    case EnumDto.eThaoTac.xoa:
                        cmd.Parameters.AddWithValue("@ID", idNhomCau);
                        cmd.Parameters.AddWithValue("@MaNhom", maNhom);
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
