using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAL
{
    public class DatabaseAccess
    {
        static string connec = $@"Data Source={ServerShareDto.serverName};Initial Catalog = {ServerShareDto.dataBase}; Integrated Security = True";
        SqlConnection connection = new SqlConnection(connec);
        SqlDataAdapter adap;
        SqlCommand cmd;

        public void KetNoi()
        {
            if (connection.State == ConnectionState.Closed)
                connection.Open();
        }

        /// Ngắt kết nối
        public void NgatKetNoi()
        {
            if (connection.State == ConnectionState.Open)
                connection.Close();
        }

        public DataTable get_DaTaTable(string clSelect)
        {
            try
            {
                adap = new SqlDataAdapter(clSelect, connection);
                DataTable dt = new DataTable();
                adap.Fill(dt);
                return dt;
            }
            catch(Exception ex)
            {
                return null;
            }
        }

        public string ThucThiCLSelect(string input1)
        {
            string a = "";
            KetNoi();
            cmd = new SqlCommand(input1, connection);
            SqlDataReader DR1 = cmd.ExecuteReader();
            while (DR1.Read())
            {
                a = DR1[0].ToString();
            }
            NgatKetNoi();
            return a;
        }

        /// Thực thi câu lệnh select
        public void ThucThiCL(string caulenh)
        {
            KetNoi();
            cmd = new SqlCommand(caulenh, connection);
            cmd.ExecuteNonQuery();// thực thi câu lệnh Insert, Update, delete
            NgatKetNoi();
        }

        //kiem tra ma
        public int TongBanGhi(string strSelect)
        {
            DataTable dtTong = new DataTable();
            adap = new SqlDataAdapter(strSelect, connec);
            adap.Fill(dtTong);
            // 
            int sbg = dtTong.Rows.Count;
            return sbg;

        }




        // STORE
        public DataTable ExcStore(string _storeName="")
        {
            try
            {
                SqlConnection oConnection = new SqlConnection(connec);
                DataSet oDataset = new DataSet();
                DataTable oDatatable = new DataTable();
                SqlDataAdapter MyDataAdapter = new SqlDataAdapter();

                oConnection.Open();
                cmd = new SqlCommand(_storeName, oConnection);
                //cmd.Parameters.Add(new SqlParameter("@INSTALL_ID", install_id));
                //cmd.Parameters.Add(new SqlParameter("@INSTALL_MAP_ID", install_map_id));
                //cmd.Parameters.Add(new SqlParameter("@SETTING_VALUE", Setting_value));

                cmd.CommandType = CommandType.StoredProcedure;
                MyDataAdapter.SelectCommand = cmd;
                cmd.ExecuteNonQuery();
                MyDataAdapter.Fill(oDataset);
                oDatatable = oDataset.Tables[0];
                return oDatatable;
            }
            catch(Exception ex)
            {
                return null;
            }
        }

        public DataTable DalLoadCauHoiTaoDeThi(int _idKhoa, int _idMonHoc, string _nhomCau, int _soLuongCau, int _kieuLoad=0,string _maKhoa="",string _maMon="", string _listIDCau="")
        {
            try
            {
                SqlConnection oConnection = new SqlConnection(connec);
                DataSet oDataset = new DataSet();
                DataTable oDatatable = new DataTable();
                SqlDataAdapter MyDataAdapter = new SqlDataAdapter();

                oConnection.Open();
                cmd = new SqlCommand("spLoadNoiDungDeThi", oConnection);
                cmd.Parameters.Add(new SqlParameter("@IDKhoa", _idKhoa));
                cmd.Parameters.Add(new SqlParameter("@IDMonHoc", _idMonHoc));
                cmd.Parameters.Add(new SqlParameter("@NhomCau", _nhomCau));
                cmd.Parameters.Add(new SqlParameter("@SoLuongCau", _soLuongCau));
                cmd.Parameters.Add(new SqlParameter("@KieuLoad", _kieuLoad));
                cmd.Parameters.Add(new SqlParameter("@MaKhoa", _maKhoa));
                cmd.Parameters.Add(new SqlParameter("@MaMon", _maMon));
                cmd.Parameters.Add(new SqlParameter("@ListIDCau", _listIDCau));

                cmd.CommandType = CommandType.StoredProcedure;
                MyDataAdapter.SelectCommand = cmd;
                cmd.ExecuteNonQuery();
                MyDataAdapter.Fill(oDataset);
                oDatatable = oDataset.Tables[0];
                return oDatatable;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public void ExecuteStoredProcedure(string procedureName)
        {
            SqlConnection sqlConnObj = new SqlConnection(connec);

            SqlCommand sqlCmd = new SqlCommand(procedureName, sqlConnObj);
            sqlCmd.CommandType = CommandType.StoredProcedure;

            sqlConnObj.Open();
            sqlCmd.ExecuteNonQuery();
            sqlConnObj.Close();
        }
        public void ExecuteStoredProcedure(string procedureName, object model)
        {
            var parameters = GenerateSQLParameters(model);
            SqlConnection sqlConnObj = new SqlConnection(connec);

            SqlCommand sqlCmd = new SqlCommand(procedureName, sqlConnObj);
            sqlCmd.CommandType = CommandType.StoredProcedure;

            foreach (var param in parameters)
            {
                sqlCmd.Parameters.Add(param);
            }

            sqlConnObj.Open();
            sqlCmd.ExecuteNonQuery();
            sqlConnObj.Close();
        }
        private List<SqlParameter> GenerateSQLParameters(object model)
        {
            var paramList = new List<SqlParameter>();
            Type modelType = model.GetType();
            var properties = modelType.GetProperties();
            foreach (var property in properties)
            {
                if (property.GetValue(model) == null)
                {
                    paramList.Add(new SqlParameter(property.Name, DBNull.Value));
                }
                else
                {
                    paramList.Add(new SqlParameter(property.Name, property.GetValue(model)));
                }
            }
            return paramList;

        }

        //NEw
        public DataTable ExcStoredProcedure(string storeName, SqlParameter[] parameters = null)
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection conn = new SqlConnection(connec))
                {
                    using (SqlCommand cmd = new SqlCommand(storeName, conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        if (parameters != null)
                        {
                            foreach (SqlParameter param in parameters)
                            {
                                cmd.Parameters.Add(param);
                            }
                        }
                        conn.Open();
                        dt.Load(cmd.ExecuteReader());
                    }
                }
            }
            catch (Exception ex)
            {
                return null;
            }
            return dt;
        }

    }
}
