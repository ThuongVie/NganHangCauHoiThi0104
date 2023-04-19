using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace DTO
{
    public static class ExcelHelper
    {
        public static void ExportDataGridViewToExcel(DataGridView dgv)
        {
            // Sao chép nội dung trong DataGridView vào Clipboard
            dgv.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText;
            dgv.MultiSelect = true;
            dgv.SelectAll();
            DataObject dataObj = dgv.GetClipboardContent();
            if (dataObj != null)
            {
                Clipboard.SetDataObject(dataObj);
            }

            // Khởi tạo đối tượng Excel
            Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();
            excel.Visible = true;

            // Tạo workbook và worksheet mới
            Workbook workbook = excel.Workbooks.Add(XlSheetType.xlWorksheet);
            Worksheet worksheet = (Worksheet)excel.ActiveSheet;

            // Lấy dữ liệu từ Clipboard và dán vào worksheet
            Microsoft.Office.Interop.Excel.Range range = (Microsoft.Office.Interop.Excel.Range)worksheet.Cells[1, 1];
            range.Select();
            worksheet.PasteSpecial(range, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, true);

            // Định dạng các cột trong worksheet
            Microsoft.Office.Interop.Excel.Range headerRange = worksheet.Rows[1];
            headerRange.Font.Bold = true;
            headerRange.Interior.Color = Color.LightGray;
            headerRange.Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;

            Microsoft.Office.Interop.Excel.Range usedRange = worksheet.UsedRange;
            usedRange.Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;

            foreach (Microsoft.Office.Interop.Excel.Range column in usedRange.Columns)
            {
                column.AutoFit();
            }
        }
    }
}
