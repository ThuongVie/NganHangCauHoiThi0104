using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;

namespace DAL
{
    public class PhuongAnRaDeDal
    {
        DatabaseAccess dba = new DatabaseAccess();
        SqlCommand cmd;
        public Object LoadPhuongAnRaDe(string _maPA="", long _idPA =0, Boolean _isDTO =false)
        {
            try
            {
                Object result = null;
                using (SqlConnection conn = new SqlConnection(ServerShareDto.connect))
                {
                    conn.Open();
                    SqlDataAdapter dap = new SqlDataAdapter();
                    DataSet ds = new DataSet();
                    SqlCommand cmd = new SqlCommand("spPhuongAnRaDeGet", conn);
                    DataTable dt = new DataTable();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@ID", _idPA));
                    cmd.Parameters.Add(new SqlParameter("@MaPA", _maPA));
                    if (_isDTO)
                    {
                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                var ma = dr["MaPA"];
                                PhuongAnRaDeDto pa = new PhuongAnRaDeDto();
                                pa.ID = (long)(dr["ID"]);
                                pa.MaPA = (string)(dr["MaPA"] != DBNull.Value && dr["MaPA"] != null ? dr["MaPA"] : "");
                                pa.TenPA = (string)(dr["TenPA"] != DBNull.Value && dr["TenPA"] != null ? dr["TenPA"] : "");
                                pa.MaKhoa = (string)(dr["MaKhoa"] != DBNull.Value && dr["MaKhoa"] != null ? dr["MaKhoa"] : "");
                                pa.MaMon = (string)(dr["MaMon"] != DBNull.Value && dr["MaMon"] != null ? dr["MaMon"] : "");
                                pa.NhomCaus = (string)(dr["NhomCaus"] != DBNull.Value && dr["NhomCaus"] != null ? dr["NhomCaus"] : "");
                                pa.GhiChu = (string)(dr["GhiChu"] != DBNull.Value && dr["GhiChu"] != null ? dr["GhiChu"] : "");
                                pa.UrlHeader = (string)(dr["UrlHeader"] != DBNull.Value && dr["UrlHeader"] != null ? dr["UrlHeader"] : "");
                                pa.UrlFooter = (string)(dr["UrlFooter"] != DBNull.Value && dr["UrlFooter"] != null ? dr["UrlFooter"] : "");
                                result = pa;
                            }
                        }
                    }
                    else
                    {
                        dap.SelectCommand = cmd;
                        dap.Fill(ds);
                        dt = ds.Tables[0];
                        result = dt;
                    }    
                }
                return result;
            }
            catch(Exception ex)
            {
                return new PhuongAnRaDeDto();
            }
        }

        public DataTable LoadPhuongAnRaDeTheo(string maKhoa, string maMon, string maPA, string tenPA)
        {
            try
            {
                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@MaKhoa", maKhoa),
                    new SqlParameter("@MaMon", maMon),
                    new SqlParameter("@MaPA", maPA),
                    new SqlParameter("@TenPA", tenPA),
                };
                DataTable dt = dba.ExcStoredProcedure("spLoadPhuongAnRaDeTheo", parameters);
                return dt;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public long XuLyPARaDe(PhuongAnRaDeDto paRaDeDto, Boolean _isSua = false,string _urlHeader="",string _urlFooter="")
        {
            try
            {
                long result = 0;
                string spName = "spPhuongAnRaDeAdd";
                if (_isSua)
                {
                    spName = "spPhuongAnRaDeUpdate";
                }
                SqlConnection con = new SqlConnection(ServerShareDto.connect);
                SqlCommand cmd = new SqlCommand(spName, con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@MaPA", paRaDeDto.MaPA);
                cmd.Parameters.AddWithValue("@TenPA", paRaDeDto.TenPA);
                cmd.Parameters.AddWithValue("@MaKhoa", paRaDeDto.MaKhoa);
                cmd.Parameters.AddWithValue("@MaMon", paRaDeDto.MaMon);
                cmd.Parameters.AddWithValue("@NhomCaus", paRaDeDto.NhomCaus);
                cmd.Parameters.AddWithValue("@CreatedBy", paRaDeDto.CreatedBy);
                cmd.Parameters.AddWithValue("@CreatedDate", (paRaDeDto.CreatedDate == default(DateTime) ? DateTime.Now : paRaDeDto.CreatedDate));
                cmd.Parameters.AddWithValue("@UpdatedBy", paRaDeDto.UpdatedBy);
                cmd.Parameters.AddWithValue("@UpdatedDate", (paRaDeDto.UpdatedDate == default(DateTime) ? DateTime.Now : paRaDeDto.UpdatedDate));
                cmd.Parameters.AddWithValue("@Huy", paRaDeDto.Huy);

                try
                {
                    byte[] dataHeader=null;
                    byte[] dataFooter = null;
                    if (_urlHeader != null && _urlHeader != "")
                    {
                        dataHeader = System.IO.File.ReadAllBytes(_urlHeader);
                        if (dataHeader.Length > 0)
                        {
                            cmd.Parameters.Add(new SqlParameter("@NoiDungHeader", SqlDbType.VarBinary, dataHeader.Length, ParameterDirection.Input, false, 0, 0, "NoiDungHeader", DataRowVersion.Current, (SqlBinary)dataHeader));
                        }
                        else
                        {
                            cmd.Parameters.Add(new SqlParameter("@NoiDungHeader", SqlDbType.VarBinary, 0, ParameterDirection.Input, false, 0, 0, "NoiDungHeader", DataRowVersion.Current, DBNull.Value));
                        }
                    }
                    else
                    {
                        cmd.Parameters.Add(new SqlParameter("@NoiDungHeader", SqlDbType.VarBinary, 0, ParameterDirection.Input, false, 0, 0, "NoiDungHeader", DataRowVersion.Current, DBNull.Value));
                    }
                    if (_urlFooter != null && _urlFooter != "")
                    {
                        dataFooter = System.IO.File.ReadAllBytes(_urlFooter);
                        if (dataFooter.Length > 0)
                        {
                            cmd.Parameters.Add(new SqlParameter("@NoiDungFooter", SqlDbType.VarBinary, dataFooter.Length, ParameterDirection.Input, false, 0, 0, "NoiDungFooter", DataRowVersion.Current, (SqlBinary)dataFooter));
                        }
                        else
                        {
                            cmd.Parameters.Add(new SqlParameter("@NoiDungFooter", SqlDbType.VarBinary, 0, ParameterDirection.Input, false, 0, 0, "NoiDungFooter", DataRowVersion.Current, DBNull.Value));
                        }
                    }
                    else
                    {
                        cmd.Parameters.Add(new SqlParameter("@NoiDungFooter", SqlDbType.VarBinary, 0, ParameterDirection.Input, false, 0, 0, "NoiDungFooter", DataRowVersion.Current, DBNull.Value));
                    }
                }
                catch(Exception ex)
                {

                }

                cmd.Parameters.AddWithValue("@GhiChu", paRaDeDto.GhiChu);
                cmd.Parameters.AddWithValue("@UrlHeader", paRaDeDto.UrlHeader);
                cmd.Parameters.AddWithValue("@UrlFooter", paRaDeDto.UrlFooter);

                if (_isSua)
                {
                    cmd.Parameters.AddWithValue("@ID", paRaDeDto.ID);
                }
                else
                {
                    cmd.Parameters.Add("@ID", SqlDbType.BigInt);
                    cmd.Parameters["@ID"].Direction = ParameterDirection.Output;
                }    
                con.Open();
                int i = cmd.ExecuteNonQuery();
                if (!_isSua)
                {
                    cmd.Parameters.AddWithValue("@ID", paRaDeDto.ID);
                }
                result = Convert.ToInt64(cmd.Parameters["@ID"].Value);
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
