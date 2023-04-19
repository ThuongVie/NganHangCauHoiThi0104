using BLL;
using DevComponents.DotNetBar.Controls;
using Microsoft.Office.Interop.Word;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.WebRequestMethods;
using DTO;

namespace NganHangCauHoiThi.UserControls
{
    public partial class FrmLoadTaoDeThi : Form 
    {
        CauHoiBLL cHoiBll = new CauHoiBLL();
        static string connec = $@"Data Source={ServerShareDto.serverName};Initial Catalog = {ServerShareDto.dataBase}; Integrated Security = True";
        SqlConnection connection = new SqlConnection(connec);
        SqlDataAdapter adap;
        SqlCommand cmd;

        string urlRtf = "";
        List<string> lstUrlRtf = new List<string>();
        List<string> lstNhomCau = new List<string>();
        List<string> lstNhomCauDaChon = new List<string>();
        List<string> lstNhomCauSelect = new List<string>();
        List<int> lstIDCauHoi = new List<int>();
        List<int> lstIDCauHoiUsed = new List<int>();
        List<int> lstDiemDaChon = new List<int>();


        public int idKhoa=0,idMonHoc=0,soLuongCau=0,kieuLoad=0, tongDiemChon=0;
        public string nhomCau = "";

        System.Data.DataTable dtListCauHoi = new System.Data.DataTable();
        private string local = "";
        
        private void btnIn_Click(object sender, EventArgs e)
        {
            switch(kieuLoad)
            {
                case 0:
                    break;
                case 1:
                    //ChonCauHoi();
                    if (tongDiemChon != 10)
                    {
                        MessageBox.Show("Tổng điểm = 10 .!!!");
                        return;
                    }  
                    if(lstNhomCauSelect.Count != lstNhomCau.Count)
                    {
                        MessageBox.Show($"Chọn câu hỏi đảm bảo mỗi nhóm 1 câu. Nhóm câu hỏi: {nhomCau} ");
                        return;
                    }    
                    break;
            }    

            clearFolder(local + @"\Trash\");
            KhoiTaoUrlRtf();
            string[] allRTFDocument = Directory.GetFiles(local + (@"\Trash"), "*.rtf");
            MergeRTF(allRTFDocument, local + @"\Trash\Final.rtf", true);
            object readOnly = false;
            object visiable = true;
            object save = false;
            object fileName = local + @"\Trash\Final.rtf";
            object newTemplate = false;
            object docType = 0;
            object missing = Type.Missing;
            Microsoft.Office.Interop.Word._Document document;
            Microsoft.Office.Interop.Word._Application application = new Microsoft.Office.Interop.Word.Application() { Visible = false };
            document = application.Documents.Open(ref fileName,
            ref missing, ref readOnly, ref missing, ref missing, ref missing,
            ref missing, ref missing, ref missing, ref missing, ref missing,
            ref visiable, ref missing, ref missing, ref missing, ref missing);
            document.ActiveWindow.Selection.WholeStory();
            document.ActiveWindow.Selection.Copy();
            IDataObject dataObject = Clipboard.GetDataObject();
            richTextBox1.Rtf = dataObject.GetData(DataFormats.Rtf).ToString();
            application.Quit(ref missing, ref missing, ref missing);
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public FrmLoadTaoDeThi()
        {
            InitializeComponent();
        }

        private void FrmLoadTaoDeThi_Load(object sender, EventArgs e)
        {
            local = System.Windows.Forms.Application.StartupPath;
            dtListCauHoi = cHoiBll.LoadCauHoiTaoDeThi(idKhoa, idMonHoc, nhomCau, soLuongCau, _kieuLoad: kieuLoad);
            foreach (DataRow dr in dtListCauHoi.Rows)
            {
                int idThem = 0;
                idThem = Convert.ToInt16(dr["ID"]);
                lstIDCauHoi.Add(idThem);
            }
            lblDS.Text = "SỐ LƯỢNG CÂU " + lstIDCauHoi.Count().ToString();
            switch (kieuLoad)
            {
                case 0:
                    this.Text = "LOAD CÂU HỎI RANDOM";
                    btnIn_Click(null,null);
                    break;
                case 1:
                    this.Text = "LOAD CÂU HỎI LỰA CHỌN";
                    soLuongCau = 0;
                    lstIDCauHoi.Clear();
                    lstIDCauHoiUsed.Clear();
                    lstDiemDaChon.Clear();
                    lstNhomCau.Clear();
                    if (nhomCau != null && nhomCau != "")
                    {
                        string[] nhoms = nhomCau.Split(' ');
                        foreach(string s  in nhoms)
                        {
                            if (s !=null && s!="")
                                lstNhomCau.Add(s);

                        }    
                    }    
                    
                   
                    break;
            }
            if (kieuLoad==1)
            {
                dtListCauHoi = cHoiBll.LoadCauHoiTaoDeThi(idKhoa, idMonHoc, nhomCau, soLuongCau, _kieuLoad: kieuLoad);
            }    
            dgvCauHoi.DataSource = dtListCauHoi;
        }

        //private void saveRtf()
        //{
        //    using (SqlConnection myDatabaseConnection = new SqlConnection(connection.ConnectionString))
        //    {
        //        myDatabaseConnection.Open();
        //        using (SqlCommand myCmd = new SqlCommand("Insert into TblCauHoi(NhomCauHoi,IDMonHoc,ContentRTF) Values(@NhomCauHoi, @IDMonHoc, @ContentRTF)", myDatabaseConnection))
        //        {
        //            myCmd.Parameters.AddWithValue("@NhomCauHoi", "C1");
        //            myCmd.Parameters.AddWithValue("@IDMonHoc", "1");
        //            myCmd.Parameters.AddWithValue("@ContentRTF", richTextBox1.Text);
        //            myCmd.ExecuteNonQuery();
        //        }
        //    }
        //}
        private void KhoiTaoUrlRtf()
        {
            using (SqlConnection conn = new SqlConnection(connec))
            {
                conn.Open();
                
                for (int i=0;i < lstIDCauHoi.Count ;i ++)
                {
                    string selQuery = " select NoiDung from TblCauHoi where ID=" + lstIDCauHoi[i].ToString() + " ";
                    using (SqlCommand cmd = new SqlCommand(selQuery, conn))
                    {
                        string nameRtf = "";
                        object oBuffer = cmd.ExecuteScalar();
                        if (oBuffer != DBNull.Value)
                        {
                            byte[] buffer = (byte[])oBuffer;
                            string fName = local + @"\Trash\rtf" + lstIDCauHoi[i].ToString() + ".rtf";
                            System.IO.File.WriteAllBytes(fName, buffer);
                        }
                    }
                    urlRtf = local + @"\Trash\rtf" + lstIDCauHoi[i].ToString() +".rtf";
                    lstUrlRtf.Add(urlRtf);
                }
            }
        }

        private void dgvCauHoi_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                switch (kieuLoad)
                {
                    case 0:
                        break;
                    case 1:
                        ChonCauHoi();
                        break;
                }
            }    
            catch(Exception ex)
            {

            }
        }

        private void dgvCauHoi_Click(object sender, EventArgs e)
        {
            //ChonCauHoi();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            lstIDCauHoi.Clear();
            lstIDCauHoiUsed.Clear();
            lstDiemDaChon.Clear();
            lstNhomCau.Clear();
            lstNhomCauDaChon.Clear();
        }

        private void btnExportWord_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            //saveFileDialog1.Filter = "JPeg Image|*.jpg|Bitmap Image|*.bmp|Gif Image|*.gif";
            saveFileDialog1.Title = "LƯU ĐỀ THI";
            saveFileDialog1.ShowDialog();
            if (saveFileDialog1.FileName != "")
            {
                string pathFile = local + @"\Trash\Final.rtf";
                var wordApp = new Microsoft.Office.Interop.Word.Application();
                var currentDoc = wordApp.Documents.Open(pathFile);
                string pathSave = saveFileDialog1.FileName + @".doc";
                currentDoc.SaveAs(pathSave , Microsoft.Office.Interop.Word.WdSaveFormat.wdFormatDocument97);
                MessageBox.Show("Đã lưu");
            }
        }

        private void dgvCauHoi_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                dgvCauHoi.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = (dgvCauHoi.Rows[e.RowIndex].Cells[e.ColumnIndex].Value == null ? true : (!(bool)dgvCauHoi.Rows[e.RowIndex].Cells[e.ColumnIndex].Value));
                var nhomBoChon = dgvCauHoi.Rows[e.RowIndex].Cells[2].Value;
                
                if((Boolean)dgvCauHoi.Rows[e.RowIndex].Cells[e.ColumnIndex].Value==false)
                {
                    lstNhomCauSelect.Remove(nhomBoChon.ToString());
                }

                var nhomCauDaChon = "";
                foreach (string s in lstNhomCauSelect)
                {
                    nhomCauDaChon = $"{nhomCauDaChon} {s}";
                }
                lblNhomDaChon.Text = $"- Nhóm đã chọn: {nhomCauDaChon}";
            }
        }

        private void clearFolder(string FolderName)
        {
            try
            {
                DirectoryInfo dir = new DirectoryInfo(FolderName);
                foreach (FileInfo fi in dir.GetFiles())
                {
                    fi.Delete();
                }
                foreach (DirectoryInfo di in dir.GetDirectories())
                {
                    clearFolder(di.FullName);
                    di.Delete();
                }
            }
            catch(Exception ex)
            {

            }
        }

        public static void MergeRTF(string[] filesToMerge, string outputFilename, bool insertPageBreaks)
        {
            object missing = System.Type.Missing;
            object pageBreak = Microsoft.Office.Interop.Word.WdBreakType.wdSectionBreakNextPage;
            object outputFile = outputFilename;
            Microsoft.Office.Interop.Word._Application wordApplication = new Microsoft.Office.Interop.Word.Application();
            try
            {
                Microsoft.Office.Interop.Word.Document wordDocument = wordApplication.Documents.Add(
                                                ref missing
                                            , ref missing
                                            , ref missing
                                            , ref missing);
                Microsoft.Office.Interop.Word.Selection selection = wordApplication.Selection;
                int documentCount = filesToMerge.Length;
                int breakStop = 0;
                foreach (string file in filesToMerge)
                {
                    breakStop++;
                    selection.InsertFile(file, ref missing, ref missing, ref missing, ref missing);
                    if (insertPageBreaks && breakStop != documentCount)
                    {
                        selection.InsertBreak(ref pageBreak);
                    }
                }
                wordDocument.SaveAs(
                            ref outputFile
                            , ref missing
                            , ref missing
                            , ref missing
                            , ref missing
                            , ref missing
                            , ref missing
                            , ref missing
                            , ref missing
                            , ref missing
                            , ref missing
                            , ref missing
                            , ref missing
                            , ref missing
                            , ref missing
                            , ref missing);
                wordDocument = null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                wordApplication.Quit(ref missing, ref missing, ref missing);
            }
        }
        private void ChonCauHoi()
        {
            tongDiemChon = 0;
            for (int i = 0; i <= dgvCauHoi.Rows.Count - 1; i++)
            {
                bool rowAlreadyExist = false, checkedCell=false;
                var check = dgvCauHoi.Rows[i].Cells[0].Value;
                if (check != null)
                {
                    checkedCell = (bool)dgvCauHoi.Rows[i].Cells[0].Value;
                }
                
                if (checkedCell)
                {
                    DataGridViewRow row = dgvCauHoi.Rows[i];
                    var nhomCau = row.Cells[2].Value.ToString();
                    int id = Convert.ToInt32( row.Cells["ID"].Value.ToString() );
                    int diem = Convert.ToInt32(row.Cells["Diem"].Value.ToString());
                    //var nhomCau = row.Cells["NhomCauHoi"].Value.ToString();
                    var findID = lstIDCauHoiUsed.Find(s => s==id);
                    lstDiemDaChon.Add(diem);
                    if (findID==0)
                        lstIDCauHoi.Add((id));
                    tongDiemChon = tongDiemChon + diem;
                    if (nhomCau != null && nhomCau != "")
                        lstNhomCauDaChon.Remove(nhomCau);

                    var fNhom = lstNhomCauSelect.Find(s => s == nhomCau);
                    if (fNhom == null)
                        lstNhomCauSelect.Add(nhomCau);

                }
                else
                {
                    
                }    
            }
            if (lstIDCauHoi.Count > 0)
            {
                lstIDCauHoiUsed.AddRange(lstIDCauHoi);
            }
            lblTongDiemChon.Text = $"- Tổng điểm: {tongDiemChon}";
            
            var nhomCauDaChon = "";
            foreach (string s in lstNhomCauSelect)
            {
                nhomCauDaChon = $"{nhomCauDaChon} {s}";
            }
            lblNhomDaChon.Text = $"- Nhóm đã chọn: {nhomCauDaChon}";
        }
        
    }


    
}
