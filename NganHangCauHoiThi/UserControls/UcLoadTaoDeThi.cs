using BLL;
using DTO;
using Guna.UI.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DTO;
using Microsoft.Office.Interop.Word;
using DevComponents.DotNetBar.Controls;
using System.Diagnostics;

namespace NganHangCauHoiThi.UserControls
{
    public partial class UcLoadTaoDeThi : UserControl
    {
        #region Var
        CauHoiBLL cHoiBll = new CauHoiBLL();
        CauTrucDeThiBus cauTrucDeBus = new CauTrucDeThiBus();

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

        public CauTrucDeThiDTO cauTrucDeDto = new CauTrucDeThiDTO();
        public int idKhoa = 0, idMonHoc = 0, soLuongCau = 0, kieuLoad = 0, tongDiemChon = 0;
        public string nhomCau = "", arrIDCauHoi="",maKhoa="",maMon="", maPA="";


        System.Data.DataTable dtListCauHoi = new System.Data.DataTable();
        private System.Data.DataTable dtCauTrucDe;
        private Boolean isTaoDe = false;
        private long idCauTruDeThi = 0;

        private void btnExport_Click(object sender, EventArgs e)
        {
            ExportFile();
        }

        private string local = "";

        #endregion
        private void btnTaoDe_Click(object sender, EventArgs e)
        {
            if (!CheckTrungNhom())
                return;
            TaoDe();
        }

        public UcLoadTaoDeThi()
        {
            InitializeComponent();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            ResetData();
            ResetData();
        }

        private void ResetData()
        {
            richTextBox1.Text = string.Empty;
            lstIDCauHoi.Clear();
            lstIDCauHoiUsed.Clear();
            lstDiemDaChon.Clear();
            //lstNhomCau.Clear();
            foreach (DataGridViewRow row in dgvCauHoi.Rows)
            {
                DataGridViewCheckBoxCell chkCell = row.Cells["Chon"] as DataGridViewCheckBoxCell;
                if (chkCell != null)
                {
                    chkCell.Value = false;
                    row.Cells["Chon"].Value = false;
                }
            }
            lstNhomCauDaChon.Clear();
        }

        private void grpTimKiem_Click(object sender, EventArgs e)
        {

        }

        private void UcLoadTaoDeThi_Load(object sender, EventArgs e)
        {
            local = System.Windows.Forms.Application.StartupPath;
            dtListCauHoi = cHoiBll.LoadCauHoiTaoDeThi(idKhoa, idMonHoc, nhomCau, soLuongCau, _kieuLoad: kieuLoad, _maKhoa:maKhoa, _maMon: maMon);
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
                    TaoDe();
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
                        foreach (string s in nhoms)
                        {
                            if (s != null && s != "")
                                lstNhomCau.Add(s);

                        }
                    }


                    break;
            }
            if (kieuLoad == 1)
            {
                dtListCauHoi = cHoiBll.LoadCauHoiTaoDeThi(idKhoa, idMonHoc, nhomCau, soLuongCau, _kieuLoad: kieuLoad, _maKhoa: maKhoa, _maMon: maMon);
            }
            dgvCauHoi.DataSource = dtListCauHoi;
            dtCauTrucDe = cauTrucDeBus.LoadCauTrucDeThi(_id:0, _maDe: cauTrucDeDto.MaDe);
        }
        private void TaoDe()
        {
            try
            {
                switch (kieuLoad)
                {
                    case 0:
                        break;
                    case 1:
                        if (tongDiemChon != 10)
                        {
                            MessageBox.Show("Tổng điểm = 10 .!!!");
                            return;
                        }
                        if (lstNhomCauDaChon.Count != lstNhomCau.Count)
                        {
                            MessageBox.Show($"Chọn câu hỏi đảm bảo mỗi nhóm 1 câu. Nhóm câu hỏi: {nhomCau} ");
                            return;
                        }
                        break;
                }
                //if (_lstIDCau != null && _lstIDCau.Count > 0)
                //{
                //    lstIDCauHoi = _lstIDCau;
                //}
                local = System.Windows.Forms.Application.StartupPath;
                clearFolder(local + @"\Trash\");
                KhoiTaoUrlRtf();
                string[] allRTFDocument = Directory.GetFiles(local + (@"\Trash"), "*.rtf");

                //allRTFDocument = allRTFDocument.Where(w => w != allRTFDocument[1]).ToArray();
                //allRTFDocument = allRTFDocument.Where(w => w != allRTFDocument[2]).ToArray();
                //allRTFDocument = allRTFDocument.Where(w => w != allRTFDocument[3]).ToArray();
                //allRTFDocument = allRTFDocument.Where(w => w != allRTFDocument[5]).ToArray();

                List<string> lstNEW = new List<string>();
                foreach (string s in allRTFDocument)
                {
                    int index = lstUrlRtf.IndexOf(s);
                    if (index >= 0)
                    {
                        lstNEW.Add(s);
                    }
                }
                allRTFDocument = lstNEW.ToArray();

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
                isTaoDe = true;
            }
            catch(Exception ex)
            {

            }
        }
        private void ExportFile()
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
                currentDoc.SaveAs(pathSave, Microsoft.Office.Interop.Word.WdSaveFormat.wdFormatDocument97);
                MessageBox.Show("Đã lưu");
            }
        }

        private void dgvCauHoi_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvCauHoi_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvCauHoi_CellValueChanged_1(object sender, DataGridViewCellEventArgs e)
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
            catch (Exception ex)
            {

            }
        }

        private void dgvCauHoi_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                dgvCauHoi.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = (dgvCauHoi.Rows[e.RowIndex].Cells[e.ColumnIndex].Value == null ? true : (!(bool)dgvCauHoi.Rows[e.RowIndex].Cells[e.ColumnIndex].Value));
                var nhomBoChon = dgvCauHoi.Rows[e.RowIndex].Cells[2].Value;

                if ((Boolean)dgvCauHoi.Rows[e.RowIndex].Cells[e.ColumnIndex].Value == false)
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

        private void dgvCauHoi_CellClick_2(object sender, DataGridViewCellEventArgs e)
        {
            /*if (e.ColumnIndex == 0)
            {
                dgvCauHoi.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = (dgvCauHoi.Rows[e.RowIndex].Cells[e.ColumnIndex].Value == null ? true : (!(bool)dgvCauHoi.Rows[e.RowIndex].Cells[e.ColumnIndex].Value));
                var nhomBoChon = dgvCauHoi.Rows[e.RowIndex].Cells[2].Value;

                if ((Boolean)dgvCauHoi.Rows[e.RowIndex].Cells[e.ColumnIndex].Value == false)
                {
                    lstNhomCauSelect.Remove(nhomBoChon.ToString());
                }

                var nhomCauDaChon = "";
                foreach (string s in lstNhomCauSelect)
                {
                    nhomCauDaChon = $"{nhomCauDaChon} {s}";
                }
                lblNhomDaChon.Text = $"- Nhóm đã chọn: {nhomCauDaChon}";
            }*/
        }

        private void dgvCauHoi_CellValueChanged_2(object sender, DataGridViewCellEventArgs e)
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
            catch (Exception ex)
            {

            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {

        }

        private void btnXuatWord_Click(object sender, EventArgs e)
        {
            ExportToWord(richTextBox1);
        }

        private void ExportToWord(RichTextBox richTextBox)
        {
            // Khởi tạo đối tượng Word
            Microsoft.Office.Interop.Word.Application word = new Microsoft.Office.Interop.Word.Application();

            // Tạo một tài liệu mới trong Word
            Document document = word.Documents.Add();

            // Chuyển dữ liệu từ RichTextBox sang Clipboard
            Clipboard.SetText(richTextBox.Rtf, TextDataFormat.Rtf);

            // Chèn nội dung từ Clipboard vào file Word
            document.Range().Paste();

            // Hiển thị tài liệu Word
            word.Visible = true;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            Boolean isSua = false;
            if (cauTrucDeDto == null)
                return;

            if (lstIDCauHoi.Count > 0)
            {
                foreach (int idCau in lstIDCauHoi)
                {
                    if (idCau != null && idCau > 0)
                        arrIDCauHoi = $"{arrIDCauHoi};{idCau.ToString()}";
                }
            }
            cauTrucDeDto.IDCauChons = arrIDCauHoi;

            dtCauTrucDe = cauTrucDeBus.LoadCauTrucDeThi(_id: idCauTruDeThi, _maDe: cauTrucDeDto.MaDe);
            if (dtCauTrucDe != null && dtCauTrucDe.Rows.Count > 0)
            {
                isSua = true;
                cauTrucDeDto.ID = idCauTruDeThi;
            }
            idCauTruDeThi = cauTrucDeBus.ThaoTacCauTrucDeThi_Store(cauTrucDeDto,_isSua: isSua);
            MessageBox.Show("Đã lưu");
        }

        private void lblTongDiemChon_Click(object sender, EventArgs e)
        {

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
            catch (Exception ex)
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
                bool rowAlreadyExist = false, checkedCell = false;
                var check = dgvCauHoi.Rows[i].Cells["Chon"].Value;
                if (check != null)
                {
                    checkedCell = (bool)dgvCauHoi.Rows[i].Cells["Chon"].Value;
                }
                DataGridViewRow row = dgvCauHoi.Rows[i];
                if (checkedCell)
                {
                    //DataGridViewRow row = dgvCauHoi.Rows[i];
                    
                    //var nhomCau = row.Cells["NhomCauHoi"].Value.ToString();
                    int id = Convert.ToInt32(row.Cells["ID"].Value.ToString());
                   // int id = Convert.ToInt32(row.Cells[1].Value.ToString());
                    int diem = Convert.ToInt32(row.Cells["Diem"].Value.ToString());
                    //var nhomCau = row.Cells["NhomCauHoi"].Value.ToString();
                    var findID = lstIDCauHoiUsed.Find(s => s == id);
                    lstDiemDaChon.Add(diem);
                    if (findID == 0)
                        lstIDCauHoi.Add((id));
                    tongDiemChon = tongDiemChon + diem;
                    //if (nhomCau != null && nhomCau != "")
                    //    lstNhomCauDaChon.Remove(nhomCau);

                    //var fNhom = lstNhomCauDaChon.Find(s => s == nhomCau);
                    //if (fNhom == null)
                    //    lstNhomCauDaChon.Add(nhomCau);

                }
                else
                {
                    //var nhomCau = row.Cells["NhomCauHoi"].Value.ToString();
                    //if (nhomCau != null && nhomCau != "")
                    //    lstNhomCauDaChon.Remove(nhomCau);
                }
            }

            Boolean checkedCell2=false;
            int index = dgvCauHoi.CurrentCell.RowIndex;
            var check2 = dgvCauHoi.Rows[index].Cells[0].Value;
            
            if (check2 != null)
            {
                checkedCell2 = (bool)dgvCauHoi.Rows[index].Cells[0].Value;
            }
            DataGridViewRow row2 = dgvCauHoi.Rows[index];
            var nhomCau = row2.Cells["NhomCauHoi"].Value.ToString();
            if (checkedCell2)
            {
                var fNhom = lstNhomCauDaChon.Find(s => s == nhomCau);
                lstNhomCauDaChon.Add(nhomCau);
            }
            else
            {
                /*if (nhomCau != null && nhomCau != "")
                    lstNhomCauDaChon.RemoveAt(index);*/
                if (nhomCau != null && nhomCau != "")
                {
                    index = lstNhomCauDaChon.IndexOf(nhomCau);
                    if (index >= 0)
                    {
                        lstNhomCauDaChon.RemoveAt(index);
                    }
                }
            }


            if (lstIDCauHoi.Count > 0)
            {
                lstIDCauHoiUsed.AddRange(lstIDCauHoi);
            }
            lblTongDiemChon.Text = $"- Tổng điểm: {tongDiemChon}";

            var nhomCauDaChon = "";
            /*foreach (string s in lstNhomCauSelect)
            {
                nhomCauDaChon = $"{nhomCauDaChon} {s}";
            }
            lblNhomDaChon.Text = $"- Nhóm đã chọn: {nhomCauDaChon}";*/
            foreach (string s in lstNhomCauDaChon)
            {
                nhomCauDaChon = $"{nhomCauDaChon} {s}";
            }
            lblNhomDaChon.Text = $"- Nhóm đã chọn: {nhomCauDaChon}";
        }
        //private void KhoiTaoUrlRtf()
        //{
        //    using (SqlConnection conn = new SqlConnection(connec))
        //    {
        //        conn.Open();

        //        for (int i = 0; i < lstIDCauHoi.Count; i++)
        //        {
        //            string selQuery = " select NoiDung from TblCauHoi where ID=" + lstIDCauHoi[i].ToString() + " ";
        //            using (SqlCommand cmd = new SqlCommand(selQuery, conn))
        //            {
        //                string nameRtf = "";
        //                object oBuffer = cmd.ExecuteScalar();
        //                if (oBuffer != DBNull.Value)
        //                {
        //                    byte[] buffer = (byte[])oBuffer;
        //                    string fName = local + @"\Trash\rtf" + lstIDCauHoi[i].ToString() + ".rtf";
        //                    System.IO.File.WriteAllBytes(fName, buffer);
        //                }
        //            }
        //            urlRtf = local + @"\Trash\rtf" + lstIDCauHoi[i].ToString() + ".rtf";
        //            lstUrlRtf.Add(urlRtf);
        //        }
        //    }
        //}

        private void KhoiTaoUrlRtf()
        {
            try
            {
                KhoiTaoUrlHeader();
                using (SqlConnection conn = new SqlConnection(ServerShareDto.connect))
                {
                    conn.Open();

                    for (int i = 0; i < lstIDCauHoi.Count; i++)
                    {
                        string selQuery = $" select NoiDung from TblCauHoi where ID={lstIDCauHoi[i]} ";
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

                        urlRtf = local + @"\Trash\rtf" + lstIDCauHoi[i].ToString() + ".rtf";

                        int _diem = 0;
                        _diem = 0;
                        System.Data.DataTable dtCauHoi = (System.Data.DataTable)cHoiBll.GetCauHoiById(idCauhoi: Convert.ToInt64(lstIDCauHoi[i]));
                        if (dtCauHoi != null && dtCauHoi.Rows.Count == 1)
                            _diem = Convert.ToInt32(dtCauHoi.Rows[0]["Diem"]);
                        urlRtf = AppendFormattedText(_pathFile: urlRtf, text: "Câu", _stt: i, _diem: _diem, Color.Red, isBold: true, alignment: HorizontalAlignment.Left);
                        if (urlRtf != "")
                            lstUrlRtf.Add(urlRtf);
                        else
                            MessageBox.Show("Chưa lưu được file.!!!");

                    }
                }
                KhoiTaoUrlFooter();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private void KhoiTaoUrlHeader()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(ServerShareDto.connect))
                {
                    conn.Open();

                    string selQuery = $" select NoiDungHeader from TblPhuongAnRaDe where ISNULL(Huy,0)=0 and MaPA='{maPA}' ";
                    using (SqlCommand cmd = new SqlCommand(selQuery, conn))
                    {
                        string nameRtf = "";
                        object oBuffer = cmd.ExecuteScalar();
                        if (oBuffer != DBNull.Value)
                        {
                            byte[] buffer = (byte[])oBuffer;
                            string fName = local + @"\Trash\001rtf_header.rtf";
                            System.IO.File.WriteAllBytes(fName, buffer);
                        }
                    }
                    urlRtf = local + @"\Trash\001rtf_header.rtf";
                    urlRtf = AppendFormattedText(_pathFile: urlRtf, text: cauTrucDeDto.MaDe, _stt: 0, _diem: 0, Color.Black, isBold: true, alignment: HorizontalAlignment.Center, _tenMaDe: cauTrucDeDto.MaDe, _tenDeThi: cauTrucDeDto.TenDe);
                    lstUrlRtf.Add(urlRtf);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private void KhoiTaoUrlFooter()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(ServerShareDto.connect))
                {
                    conn.Open();

                    string selQuery = $" select NoiDungFooter from TblPhuongAnRaDe where ISNULL(Huy,0)=0 and MaPA='{maPA}' ";
                    using (SqlCommand cmd = new SqlCommand(selQuery, conn))
                    {
                        string nameRtf = "";
                        object oBuffer = cmd.ExecuteScalar();
                        if (oBuffer != DBNull.Value)
                        {
                            byte[] buffer = (byte[])oBuffer;
                            string fName = local + @"\Trash\zzzrtf_NoiDungFooter.rtf";
                            System.IO.File.WriteAllBytes(fName, buffer);
                        }
                    }
                    urlRtf = local + @"\Trash\zzzrtf_NoiDungFooter.rtf";
                    lstUrlRtf.Add(urlRtf);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        //private string AppendFormattedText(string _pathFile = "", string text = "", int _stt = 1, int _diem = 0, Color textColour = default(Color), Boolean isBold = false, HorizontalAlignment alignment = HorizontalAlignment.Left)
        //{
        //    try
        //    {
        //        RichTextBox rtb = new RichTextBox();

        //        object readOnly = false;
        //        object visiable = true;
        //        object save = false;
        //        object fileName = _pathFile;
        //        object newTemplate = false;
        //        object docType = 0;
        //        object missing = Type.Missing;
        //        Microsoft.Office.Interop.Word._Document document;
        //        Microsoft.Office.Interop.Word._Application application = new Microsoft.Office.Interop.Word.Application() { Visible = false };
        //        document = application.Documents.Open(ref fileName,
        //        ref missing, ref readOnly, ref missing, ref missing, ref missing,
        //        ref missing, ref missing, ref missing, ref missing, ref missing,
        //        ref visiable, ref missing, ref missing, ref missing, ref missing);
        //        document.ActiveWindow.Selection.WholeStory();
        //        document.ActiveWindow.Selection.Copy();
        //        IDataObject dataObject = Clipboard.GetDataObject();
        //        rtb.Rtf = dataObject.GetData(DataFormats.Rtf).ToString();
        //        application.Quit(ref missing, ref missing, ref missing);

        //        //rtb.LoadFile(_pathFile);

        //        int start = rtb.TextLength;
        //        rtb.AppendText("\r\n");
        //        int end = rtb.TextLength; // now longer by length of appended text

        //        // Select text that was appended
        //        rtb.Select(start, end - start);

        //        #region Apply Formatting
        //        rtb.SelectionColor = textColour;
        //        rtb.SelectionAlignment = alignment;
        //        rtb.SelectionFont = new System.Drawing.Font(
        //             rtb.SelectionFont.FontFamily,
        //             rtb.SelectionFont.Size,
        //             (isBold ? FontStyle.Bold : FontStyle.Regular));
        //        #endregion

        //        // Unselect text
        //        rtb.SelectionLength = 0;

        //        rtb.SelectionStart = 0;
        //        rtb.SelectionLength = 0;
        //        rtb.SelectedText = $"{text} {_stt + 1} ({_diem} điểm) \r\n ";

        //        string result = "";
        //        string newPath = _pathFile.Replace(".rtf", "") + "_2.rtf";
        //        rtb.SaveFile(newPath, RichTextBoxStreamType.RichText);
        //        if (File.Exists(newPath))
        //            result = _pathFile;
        //        else
        //            result = "";

        //        return result;
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("AppendFormattedText() " + ex.ToString());
        //        return "";
        //    }
        //}
        private string AppendFormattedText(string _pathFile = "", string text = "", int _stt = 1, int _diem = 0, Color textColour = default(Color), Boolean isBold = false, HorizontalAlignment alignment = HorizontalAlignment.Left, string _tenMaDe = "", string _tenDeThi="")
        {
            try
            {
                RichTextBox rtb = new RichTextBox();

                object readOnly = false;
                object visiable = true;
                object save = false;
                object fileName = _pathFile;
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
                rtb.Rtf = dataObject.GetData(DataFormats.Rtf).ToString();
                application.Quit(ref missing, ref missing, ref missing);

                //rtb.LoadFile(_pathFile);
                if (_tenMaDe != "")
                {
                    int start = rtb.TextLength;
                    rtb.AppendText($"\n{_tenDeThi} - Mã đề {_tenMaDe}\r");
                    int end = rtb.TextLength; // now longer by length of appended text

                    // Select text that was appended
                    rtb.Select(start, end - start);

                    #region Apply Formatting
                    rtb.SelectionColor = textColour;
                    rtb.SelectionAlignment = alignment;
                    rtb.SelectionFont = new System.Drawing.Font(
                         rtb.SelectionFont.FontFamily,
                         rtb.SelectionFont.Size,
                         (isBold ? FontStyle.Bold : FontStyle.Regular));
                    #endregion
                }

                // Unselect text

                if (_tenMaDe == "")
                {
                    rtb.SelectionLength = 0;

                    rtb.SelectionStart = 0;
                    rtb.SelectionLength = 0;
                    rtb.SelectedText = $"{text} {_stt + 1} ({_diem} điểm) \r\n ";
                }


                string result = "";
                string newPath = _pathFile.Replace(".rtf", "") + "_2.rtf";
                rtb.SaveFile(newPath, RichTextBoxStreamType.RichText);
                if (File.Exists(newPath))
                    result = newPath;
                else
                    result = _pathFile;

                return result;
            }
            catch (Exception ex)
            {
                MessageBox.Show("AppendFormattedText() " + ex.ToString());
                return "";
            }
        }

        private Boolean CheckTrungNhom()
        {
            if (lstNhomCauDaChon.Count == 0)
                return false;
            List<string> lstCheck = new List<string>();
            foreach (string s in lstNhomCauDaChon)
            {
                int dem = lstNhomCauDaChon.Count(x => x==s);
                if (dem > 1)
                {
                    MessageBox.Show("Mỗi nhóm câu chỉ chọn 1 câu.Vui lòng chọn lại!!!");
                    ResetData();
                    ResetData();
                    return false;
                }
                else
                {
                    lstCheck.Add(s);
                }
            }
            if(lstCheck.Count < 3)
            {
                MessageBox.Show("Chọn đủ số nhóm câu.Vui lòng chọn lại!!!");
                ResetData();
                return false;
            }
            return true;
        }

    }
}
