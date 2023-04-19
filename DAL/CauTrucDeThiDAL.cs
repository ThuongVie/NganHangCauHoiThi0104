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
    public class CauTrucDeThiDAL
    {
        DatabaseAccess dba = new DatabaseAccess();
        SqlCommand cmd;

        public DataTable LoadCauTrucDeThi(long _id=0, string _maDe = "")
        {
            string sql = $" Declare @MaDe nvarchar(500)='{_maDe}', @IDDe bigint={_id}; select * from TblCauTrucDeThis where (@IDDe=0 or @IDDe is null or ID=@IDDe) and (@MaDe='' or @MaDe is null or MaDe=@MaDe) ";
            return dba.get_DaTaTable(sql);
        }
        public void ThemCauTrucDeThi(CauTrucDeThiDTO ctrucDeDTO)
        {
            string sql = $" INSERT INTO [dbo].[TblCauTrucDeThis] ([MaDe] ,[TenDe],[IDMonHoc] ,[SLCauCuaNhom] ,[SoLuongNhomCau],[SoDiemMoiNhomCau] ,[SLCauMoiNhom] ,[TongThoiGianLam],[ThoiGianDuKienMoiNhom],[IDKhoa],NhomCauChons,IDCauChons,Huy ) VALUES ('{ctrucDeDTO.MaDe}','{ctrucDeDTO.TenDe}',{ctrucDeDTO.IDMonHoc},{ctrucDeDTO.SLCauCuaNhom},{ctrucDeDTO.SoLuongNhomCau}, '{ctrucDeDTO.SoDiemMoiNhomCau}','{ctrucDeDTO.SLCauMoiNhom}',{ctrucDeDTO.TongThoiGianLam},{ctrucDeDTO.ThoiGianDuKienMoiNhom},{ctrucDeDTO.IDKhoa}, '{ctrucDeDTO.NhomCauChons}','{ctrucDeDTO.IDCauChons}',{(ctrucDeDTO.Huy?1:0)} )  ";
            dba.ThucThiCL(sql);
        }
        public void SuaCauTrucDeThi(CauTrucDeThiDTO ctrucDeDTO)
        {
            string sql = $" Update TblCauTrucDeThis set  [MaDe]=N'{ctrucDeDTO.MaDe}',[TenDe]=N'{ctrucDeDTO.TenDe}',[IDMonHoc]={ctrucDeDTO.IDMonHoc} ,[SLCauCuaNhom]={ctrucDeDTO.SLCauCuaNhom} ,[SoLuongNhomCau]={ctrucDeDTO.SoLuongNhomCau},[SoDiemMoiNhomCau]='{ctrucDeDTO.SoDiemMoiNhomCau}' ,[SLCauMoiNhom]='{ctrucDeDTO.SLCauCuaNhom}' ,[TongThoiGianLam]={ctrucDeDTO.TongThoiGianLam},[ThoiGianDuKienMoiNhom]={ctrucDeDTO.ThoiGianDuKienMoiNhom},[IDKhoa]={ctrucDeDTO.IDKhoa}, NhomCauChons='{ctrucDeDTO.NhomCauChons}',IDCauChons='{ctrucDeDTO.IDCauChons}',Huy={(ctrucDeDTO.Huy ? 1 : 0)} where ID={ctrucDeDTO.ID} ";
            dba.ThucThiCL(sql);
        }
        //private string connec = $@"Data Source={ServerShareDto.serverName};Initial Catalog = {ServerShareDto.dataBase}; Integrated Security = True";
        public long ThaoTacCauTrucDeThi_Store(CauTrucDeThiDTO cauTrucDeDto, Boolean _isSua=false)
        {
            try
            {
                long result = 0;
                string spName = "spCauTrucDeThiAdd";
                if (_isSua)
                {
                    spName = "spCauTrucDeThiUpdate";
                }
                SqlConnection con = new SqlConnection(ServerShareDto.connect);
                SqlCommand cmd = new SqlCommand(spName, con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@MaDe", cauTrucDeDto.MaDe);
                cmd.Parameters.AddWithValue("@TenDe", cauTrucDeDto.TenDe);
                cmd.Parameters.AddWithValue("@IDMonHoc", cauTrucDeDto.IDMonHoc);
                cmd.Parameters.AddWithValue("@SLCauCuaNhom", cauTrucDeDto.SLCauCuaNhom);
                cmd.Parameters.AddWithValue("@SoLuongNhomCau", cauTrucDeDto.SoLuongNhomCau);
                cmd.Parameters.AddWithValue("@SoDiemMoiNhomCau", cauTrucDeDto.SoDiemMoiNhomCau);
                cmd.Parameters.AddWithValue("@SLCauMoiNhom", cauTrucDeDto.SLCauMoiNhom);
                cmd.Parameters.AddWithValue("@TongThoiGianLam", cauTrucDeDto.TongThoiGianLam);
                cmd.Parameters.AddWithValue("@ThoiGianDuKienMoiNhom", cauTrucDeDto.ThoiGianDuKienMoiNhom);
                cmd.Parameters.AddWithValue("@IDKhoa", cauTrucDeDto.IDKhoa);
                cmd.Parameters.AddWithValue("@NhomCauChons", cauTrucDeDto.NhomCauChons);
                cmd.Parameters.AddWithValue("@IDCauChons", cauTrucDeDto.IDCauChons);
                cmd.Parameters.AddWithValue("@MaKhoa", cauTrucDeDto.MaKhoa);
                cmd.Parameters.AddWithValue("@MaMon", cauTrucDeDto.MaMon);
                cmd.Parameters.AddWithValue("@Ngay", cauTrucDeDto.Ngay);
                cmd.Parameters.Add("@ID", SqlDbType.BigInt);
                cmd.Parameters["@ID"].Direction = ParameterDirection.Output;
                if (_isSua)
                {
                    cmd.Parameters.AddWithValue("@ID", cauTrucDeDto.ID);
                }
                con.Open();
                int i = cmd.ExecuteNonQuery();
                if (!_isSua)
                {
                    cmd.Parameters.AddWithValue("@ID", cauTrucDeDto.ID);
                }
                result = Convert.ToInt64( cmd.Parameters["@ID"].Value);
                con.Close();
                return result;
            }
            catch(Exception ex)
            {
                return 0;
            }
            
        }
        public DataTable LoadDSDeThi(DateTime _tuNgay,DateTime _denNgay,string _maKhoa, string _maMon, string _nhomCau, long _id,string _made)
        {
            DataTable dt = new DataTable();
            try
            {
                SqlConnection oConnection = new SqlConnection(ServerShareDto.connect);
                DataSet oDataset = new DataSet();
                DataTable oDatatable = new DataTable();
                SqlDataAdapter MyDataAdapter = new SqlDataAdapter();

                oConnection.Open();
                cmd = new SqlCommand("spCauTrucDeThiGet", oConnection);
                cmd.Parameters.Add(new SqlParameter("@tungay", _tuNgay));
                cmd.Parameters.Add(new SqlParameter("@denngay", _denNgay));
                cmd.Parameters.Add(new SqlParameter("@makhoa", _maKhoa));
                cmd.Parameters.Add(new SqlParameter("@mamon", _maMon));
                cmd.Parameters.Add(new SqlParameter("@nhomcau", _nhomCau));
                cmd.Parameters.Add(new SqlParameter("@id", _id));
                cmd.Parameters.Add(new SqlParameter("@made", _made));

                cmd.CommandType = CommandType.StoredProcedure;
                MyDataAdapter.SelectCommand = cmd;
                cmd.ExecuteNonQuery();
                MyDataAdapter.Fill(oDataset);
                oDatatable = oDataset.Tables[0];
                return oDatatable;
                return dt;
            }
            catch(Exception ex)
            {
                return dt;
            }
        }

    }
}
