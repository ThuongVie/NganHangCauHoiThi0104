using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BLL
{
    public class PluginBus
    {
        public static void OpenForm(UserControl userControl)
        {
            try
            {
                Panel label1 = Application.OpenForms["frm_TrangChu"].Controls["panelDesktop"] as Panel;
                userControl.Dock = DockStyle.Fill;
                label1.Controls.Clear();
                label1.Controls.Add(userControl);
                userControl.BringToFront();
            }
            catch(Exception ex)
            {

            }
        }
        public static string KiemTraGiaTri(Object _obj = null, int _kieu = 0)
        {
            try
            {
                if (_obj == DBNull.Value || _obj == null || _obj == "")
                {
                    return "";
                }
                return _obj.ToString();
            }
            catch (Exception ex)
            {
                return "";
            }
        }
        public enum ePhanQuyenForm
        {
            them=0,
            sua=1,
            xoa=2,
            huy=3,
            capNhat=4,
            khoiPhuc=5,
        }

        public static void PhanQuyenButtonForm(Control  _root,ePhanQuyenForm _ePhanQuyen)
        {
            string[] arrEnable=null;
            switch (_ePhanQuyen)
            {
                case ePhanQuyenForm.them:
                  case  ePhanQuyenForm.sua:
                    arrEnable = new string[] { "btnLuu", "btnReset", "btnBack", "btnNgauNhien", "btnChon", "btnExport", "btnXuatWord", "btnXuatDS" };
                    break;
                case ePhanQuyenForm.huy:
                case ePhanQuyenForm.capNhat:
                case ePhanQuyenForm.xoa:
                    arrEnable = new string[] { "btnThem", "btnSua", "btnXoa", "btnBack", "btnReset", "btnNgauNhien", "btnChon", "btnExport", "btnXuatWord", "btnXuatDS" };
                    break;
            }
            if (arrEnable == null || arrEnable.Count() == 0)
                return;
            foreach(Control ctr in _root.Controls)
            {
                ctr.Enabled=false;
                var s = arrEnable.Where(w => w == ctr.Name).ToArray();
                if (s!=null && s.Count() > 0)
                    ctr.Enabled = true;
            }    
        }
    }
}
