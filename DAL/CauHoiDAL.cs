using DTO;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class CauHoiDAL
    {
        DatabaseAccess dba = new DatabaseAccess();
        public DataTable LoadCauHoi()
        {
            string sql = $" select ID,NhomCauHoi,IDMonHoc,FilePath from TblCauHoi order by NhomCauHoi,IDMonHoc,ID ";
            return dba.get_DaTaTable(sql);
        }
        public void ThemCauHoi(CauHoi cauHoi)
        {
            string sql = "INSERT INTO TblCauHoi(NhomCauHoi, IDMonHoc,FilePath, NoiDung) SELECT N'" + cauHoi.NhomCauHoi1 + "' AS NhomCauHoi,N'" + cauHoi.IDMonHoc1 + "' AS IDMonHoc,N'" + cauHoi.FilePath1 + "' as FilePath,* FROM OPENROWSET(BULK N'" + cauHoi.FilePath1 + "', SINGLE_BLOB) AS NoiDung  ";
            /*string sql = "insert into TblCauHoi values(N'" + cauHoi.NhomCauHoi1 + "',N'" + cauHoi.NoiDung1 + "','" + cauHoi.IDMonHoc1 + "',N'" + cauHoi.FilePath1 + "')";*/
            dba.ThucThiCL(sql);
        }
        public DataTable LoadCauHoiStore()
        {
            try
            {
                DataTable dt = new DataTable();
                dt = dba.ExcStore("[LoadCauHois]");
                return dt;
            }
            catch(Exception ex)
            {
                return null;
            }
        }

        public DataTable LoadCauHoiTaoDeThi(int _idKhoa, int _idMonHoc, string _nhomCau,int _soLuongCau, int _kieuLoad=0, string _maKhoa = "", string _maMon = "", string _listIDCau = "")
        {
            try
            {
                DataTable dt = new DataTable();
                dt = dba.DalLoadCauHoiTaoDeThi( _idKhoa,  _idMonHoc,  _nhomCau,  _soLuongCau, _kieuLoad,  _maKhoa ,  _maMon, _listIDCau);
                return dt;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        //NEw
        public DataTable LoadCauHoiTheoNhomCauHoi(int idMon, string nhomCauHoi)
        {
            try
            {
                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@IDMonHoc", idMon),
                    new SqlParameter("@NhomCauHoi", nhomCauHoi)
                };
                DataTable dt = dba.ExcStoredProcedure("LoadCauHoiTheoNhomCauHoi", parameters);
                return dt;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public DataTable ThemCauHoi1(string nhomCauHoi, int idMonHoc, string filePath)
        {
            try
            {
                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@NhomCauHoi", nhomCauHoi),
                    new SqlParameter("@IDMonHoc", idMonHoc),
                    new SqlParameter("@FilePath", filePath),

                };
                DataTable dt = dba.ExcStoredProcedure("ThemCauHoi2", parameters);
                return dt;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public DataTable LoadCauHoiTheoDieuKien(int idKhoa, int idMonHoc, string nhomCauHoi, string maCauHoi)
        {
            try
            {
                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@IDKhoa", idKhoa),
                    new SqlParameter("@IDMon", idMonHoc),
                    new SqlParameter("@NhomCauHoi", nhomCauHoi),
                    new SqlParameter("@MaCauHoi", maCauHoi)

                };
                DataTable dt = dba.ExcStoredProcedure("spLoadCauHoiTheoDieuKien", parameters);
                return dt;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public DataTable LoadCauHoiTheoKhoa(int idKhoa)
        {
            try
            {
                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@IDKhoa", idKhoa)
                };
                DataTable dt = dba.ExcStoredProcedure("LoadCauHoiTheoKhoa", parameters);
                return dt;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public byte[] GetNoiDungCauHoi(long idCauHoi)
        {
            byte[] noiDungBytes = null;
            try
            {
                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@ID", idCauHoi)
                };
                DataTable dt = dba.ExcStoredProcedure("GetNoiDungCauHoi", parameters);
                if (dt != null && dt.Rows.Count > 0)
                {
                    noiDungBytes = (byte[])dt.Rows[0]["NoiDung"];
                }
                return noiDungBytes;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public DataTable LoadCauHoiTheoMonHoc(int idMonHoc)
        {
            try
            {
                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@IDMonHoc", idMonHoc)
                };
                DataTable dt = dba.ExcStoredProcedure("LoadCauHoiTheoMonHoc", parameters);
                return dt;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public DataTable GetCauHoiById(long idCauHoi)
        {
            try
            {
                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@ID", idCauHoi)
                };
                DataTable dt = dba.ExcStoredProcedure("GetCauHoiById", parameters);
                return dt;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public DataTable GetMonHocById(int idCauHoi)
        {
            try
            {
                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@ID", idCauHoi)
                };
                DataTable dt = dba.ExcStoredProcedure("GetMonHocById", parameters);
                return dt;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public DataTable GetKhoaByIdMon(int idMonHoc)
        {
            try
            {
                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@IDMonHoc", idMonHoc)
                };
                DataTable dt = dba.ExcStoredProcedure("GetKhoaByIdMon", parameters);
                return dt;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public long ThaoTacCauHoi_Store(long _idCauHoi, string _maCau, string _nhomCau, int _idMon, string _fitlePath, string nguoiTao, EnumDto.eThaoTac eAction)
        {
            try
            {
                long result = 0;
                string spName = "[ThemCauHoi_Store]";
                switch (eAction)
                {
                    case EnumDto.eThaoTac.sua:
                        spName = "[SuaCauHoi_Store]";
                        break;
                    case EnumDto.eThaoTac.xoa:
                        spName = "[XoaCauHoi_Store]";
                        break;
                }
                SqlConnection con = new SqlConnection(ServerShareDto.connect);
                SqlCommand cmd = new SqlCommand(spName, con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@NhomCauHoi", _nhomCau);
                cmd.Parameters.AddWithValue("@IDMonHoc", _idMon);
                cmd.Parameters.AddWithValue("@FilePath", _fitlePath);

                switch (eAction)
                {
                    case EnumDto.eThaoTac.them:
                        cmd.Parameters.Add("@ID", SqlDbType.BigInt);
                        cmd.Parameters["@ID"].Direction = ParameterDirection.Output;
                        cmd.Parameters.AddWithValue("@NguoiTao", nguoiTao);
                        break;
                    case EnumDto.eThaoTac.sua:
                        cmd.Parameters.AddWithValue("@ID", _idCauHoi);
                        cmd.Parameters.AddWithValue("@MaCauHoi", _maCau);
                        break;
                    case EnumDto.eThaoTac.xoa:
                        cmd.Parameters.AddWithValue("@ID", _idCauHoi);
                        cmd.Parameters.AddWithValue("@MaCauHoi", _maCau);
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
        public DataTable LoadMonHocTheoDieuKien(int idKhoa, string maMon, string tenMon, string maHocPhan, int soTinChi, DateTime tungay, DateTime denngay)
        {
            try
            {
                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@IDKhoa", idKhoa),
                    new SqlParameter("@MaMon", maMon),
                    new SqlParameter("@TenMon", tenMon),
                    new SqlParameter("@MaHocPhan", maHocPhan),
                    new SqlParameter("@SoTinChi", soTinChi),
                    new SqlParameter("@tungay", tungay),
                    new SqlParameter("@denngay", denngay)

                };
                DataTable dt = dba.ExcStoredProcedure("spLoadMonHocTheoDieuKien", parameters);
                return dt;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public DataTable LoadCauHoiTheoDieuKien(int idKhoa, int idMonHoc, string nhomCauHoi, string maCauHoi, DateTime tungay, DateTime denngay)
        {
            try
            {
                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@IDKhoa", idKhoa),
                    new SqlParameter("@IDMon", idMonHoc),
                    new SqlParameter("@NhomCauHoi", nhomCauHoi),
                    new SqlParameter("@MaCauHoi", maCauHoi),
                    new SqlParameter("@tungay", tungay),
                    new SqlParameter("@denngay", denngay)

                };
                DataTable dt = dba.ExcStoredProcedure("spLoadCauHoiTheoDieuKien", parameters);
                return dt;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
