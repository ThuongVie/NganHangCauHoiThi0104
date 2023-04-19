using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAL
{
    public class NguoiDungDAL
    {
        DatabaseAccess dba = new DatabaseAccess();

        public DataTable LoadNguoiDungTheoDieuKien_Store(int idKhoa,string maNhomNguoiSuDung,string userName,string hoTen, string email, string soDienThoai,string DiaChi)
        {
            try
            {
                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@IDKhoa", idKhoa),
                    new SqlParameter("@MaNhomNguoiSuDung", maNhomNguoiSuDung),
                    new SqlParameter("@UserName", userName),
                    new SqlParameter("@HoTen", hoTen),
                    new SqlParameter("@Email", email),
                    new SqlParameter("@SoDienThoai", soDienThoai),
                    new SqlParameter("@DiaChi", DiaChi),

                };
                DataTable dt = dba.ExcStoredProcedure("spLoadNguoiDungTheoDieuKien_Store", parameters);
                return dt;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public DataTable LoginUser(string username, string pass)
        {
            try
            {
                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@Username", username),
                    new SqlParameter("@Pass", pass),

                };
                DataTable dt = dba.ExcStoredProcedure("spLoginUser", parameters);
                return dt;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public DataTable LoadNhomNguoiSuDung()
        {
            string sql = "select * from TblNhomNguoiSuDung";
            return dba.get_DaTaTable(sql);
        }   

        public long ThaoTacNguoiDung_Store(long idNguoiDung,int idKhoa,string userName, string hoTen, string email,string soDienThoai, string diaChi,string maNhomNguoiSuDung, string nguoiTao, string nguoiCapNhat, EnumDto.eThaoTac eAction)
        {
            try
            {
                long result = 0;
                string spName = "[ThemNguoiSuDung_Store]";
                switch (eAction)
                {
                    case EnumDto.eThaoTac.sua:
                        spName = "[SuaNguoiSuDung_Store]";
                        break;
                    case EnumDto.eThaoTac.xoa:
                        spName = "[XoaNguoiSuDung_Store]";
                        break;
                }
                SqlConnection con = new SqlConnection(ServerShareDto.connect);
                SqlCommand cmd = new SqlCommand(spName, con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IDKhoa", idKhoa);
                cmd.Parameters.AddWithValue("@HoTen", hoTen);
                cmd.Parameters.AddWithValue("@Email", email);
                cmd.Parameters.AddWithValue("@SoDienThoai", soDienThoai);
                cmd.Parameters.AddWithValue("@DiaChi", diaChi);
                cmd.Parameters.AddWithValue("@MaNhomNguoiSuDung", maNhomNguoiSuDung);

                switch (eAction)
                {
                    case EnumDto.eThaoTac.them:
                        cmd.Parameters.Add("@ID", SqlDbType.BigInt);
                        cmd.Parameters["@ID"].Direction = ParameterDirection.Output;
                        cmd.Parameters.AddWithValue("@NguoiTao", nguoiTao);
                        break;
                    case EnumDto.eThaoTac.sua:
                        cmd.Parameters.AddWithValue("@ID", idNguoiDung);
                        cmd.Parameters.AddWithValue("@UserName", userName);
                        cmd.Parameters.AddWithValue("@NguoiCapNhat", nguoiCapNhat);
                        break;
                    case EnumDto.eThaoTac.xoa:
                        cmd.Parameters.AddWithValue("@ID", idNguoiDung);
                        cmd.Parameters.AddWithValue("@UserName", userName);
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

        public long DoiMatKhau_Store(long idNguoiDung,string userName, string pass)
        {
            try
            {
                long result = 0;
                string spName = "[DoiMatKhau_Store]";
                SqlConnection con = new SqlConnection(ServerShareDto.connect);
                SqlCommand cmd = new SqlCommand(spName, con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID", idNguoiDung);
                cmd.Parameters.AddWithValue("@UserName", userName);
                cmd.Parameters.AddWithValue("@Pass", pass);
  
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
