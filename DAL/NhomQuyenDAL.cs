using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class NhomQuyenDAL
    {
        DatabaseAccess dba = new DatabaseAccess();

        public DataTable LoadPhanQuyenForm()
        {
            string sql = "select * from TblPhanQuyenForm";
            return dba.get_DaTaTable(sql);
        }

        public DataTable LoadNhomQuyenTheoDieuKien(string maNhomNguoiSuDung, string maForm)
        {
            try
            {
                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@MaNhomNguoiSuDung", maNhomNguoiSuDung),
                    new SqlParameter("@MaForm", maForm)
                };
                DataTable dt = dba.ExcStoredProcedure("spLoadNhomQuyenTheoDieuKien_Store", parameters);
                return dt;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public long ThaoTacNhomQuyen_Store(long idNhomQuyen, string maNhomNguoiSuDung, string maForm, string quyen, string chuThich, EnumDto.eThaoTac eAction)
        {
            try
            {
                long result = 0;
                string spName = "[ThemNhomQuyen_Store]";
                switch (eAction)
                {
                    case EnumDto.eThaoTac.sua:
                        spName = "[SuaNhomQuyen_Store]";
                        break;
                    case EnumDto.eThaoTac.xoa:
                        spName = "[XoaNhomQuyen_Store]";
                        break;
                }
                SqlConnection con = new SqlConnection(ServerShareDto.connect);
                SqlCommand cmd = new SqlCommand(spName, con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@MaNhomNguoiSuDung", maNhomNguoiSuDung);
                cmd.Parameters.AddWithValue("@MaForm", maForm);
                cmd.Parameters.AddWithValue("@Quyen", quyen);
                cmd.Parameters.AddWithValue("@ChuThich", chuThich);

                switch (eAction)
                {
                    /*case EnumDto.eThaoTac.them:
                        cmd.Parameters.Add("@ID", SqlDbType.BigInt);
                        cmd.Parameters["@ID"].Direction = ParameterDirection.Output;
                        break;*/
                    case EnumDto.eThaoTac.sua:
                        cmd.Parameters.AddWithValue("@ID", idNhomQuyen);
                        break;
                        /*case EnumDto.eThaoTac.xoa:
                            cmd.Parameters.AddWithValue("@ID", idNhomQuyen);
                            cmd.Parameters.AddWithValue("@Huy", 1);
                            break;*/
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
