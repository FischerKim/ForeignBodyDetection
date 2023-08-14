using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Daekhon.Common;
using Jhjo.Common;
using System.Runtime.InteropServices;
using System.IO;
using PylonC.NET;

namespace YKCJ_Diaper
{
    public partial class frmLoad : Form
    {
        #region CONST
        private const string SYSTEM_INI = ".\\System.ini";
        #endregion


        #region VARIABLE
        private CCameraInfo m_OCameraInfo = null;
        #endregion


        #region CONSTRUCTOR & DESTRUCTOR
        public frmLoad()
        {
            InitializeComponent();
        }
        #endregion


        #region EVENT
        #region FORM EVENT
        private void frmLoad_Load(object sender, EventArgs e)
        {
            try
            {
                StringBuilder OText = new StringBuilder();

                if (File.Exists(frmLoad.SYSTEM_INI) == false)
                {
                    File.WriteAllText(frmLoad.SYSTEM_INI, YKCJ_Diaper.Properties.Resources.System);
                }
                frmLoad.GetPrivateProfileString("CAMERA", "Serial", string.Empty, OText, 255, frmLoad.SYSTEM_INI);


                uint U32Count = Pylon.EnumerateDevices();
                for (uint _Index = 0; _Index < U32Count; _Index++)
                {
                    PYLON_DEVICE_INFO_HANDLE OHandle = Pylon.GetDeviceInfoHandle(_Index);
                    string StrSerial = Pylon.DeviceInfoGetPropertyValueByName(OHandle, "SerialNumber");

                    if (StrSerial == OText.ToString())
                    {
                        this.m_OCameraInfo = new CCameraInfo();
                        this.m_OCameraInfo.StrVender = Pylon.DeviceInfoGetPropertyValueByName(OHandle, "VendorName");
                        this.m_OCameraInfo.StrModel = Pylon.DeviceInfoGetPropertyValueByName(OHandle, "ModelName");
                        this.m_OCameraInfo.StrSerial = Pylon.DeviceInfoGetPropertyValueByName(OHandle, "SerialNumber");
                        this.m_OCameraInfo.StrIP = Pylon.DeviceInfoGetPropertyValueByName(OHandle, "IpAddress");
                        this.m_OCameraInfo.OKey = _Index;
                    }
                }

                if (this.m_OCameraInfo != null) this.LblIP.Text = this.m_OCameraInfo.StrIP;
            }
            catch (Exception ex)
            {
                CError.Show(ex);
            }
        }
        #endregion


        #region BUTTON EVENT
        private void BtnSelect_Click(object sender, EventArgs e)
        {
            try
            {
                frmCameraSelector OWindow = new frmCameraSelector();
                OWindow.OCamera = this.m_OCameraInfo;

                if (OWindow.ShowDialog() == DialogResult.OK)
                {
                    this.m_OCameraInfo = OWindow.OCamera;
                    this.LblIP.Text = this.m_OCameraInfo.StrIP;
                }
            }
            catch (Exception ex)
            {
                CError.Show(ex);
            }
        }


        private void BtnEnter_Click(object sender, EventArgs e)
        {
            try
            {
                //if (this.m_OCameraInfo == null)
                //{
                //    CMsgBox.Warning("카메라 정보를 선택하여 주세요!");
                //    return;
                //}


                if (this.m_OCameraInfo != null)
                {
                    frmLoad.WritePrivateProfileString("CAMERA", "Company", this.m_OCameraInfo.StrVender, SYSTEM_INI);
                    frmLoad.WritePrivateProfileString("CAMERA", "Product", this.m_OCameraInfo.StrModel, SYSTEM_INI);
                    frmLoad.WritePrivateProfileString("CAMERA", "Serial", this.m_OCameraInfo.StrSerial, SYSTEM_INI);
                    frmLoad.WritePrivateProfileString("CAMERA", "IP", this.m_OCameraInfo.StrIP, SYSTEM_INI);
                }


                CDB.It.Load();
                CRecipeManager.It.Load();
                CAcquisitionManager.It.Load(this.m_OCameraInfo);

                this.DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                CError.Show(ex);
            }
        }


        private void BtnExit_Click(object sender, EventArgs e)
        {
            try
            {
                this.DialogResult = DialogResult.Cancel;
            }
            catch (Exception ex)
            {
                CError.Show(ex);
            }
        }
        #endregion
        #endregion


        #region EXTERNAL FUNCTION
        [DllImport("kernel32")]
        public static extern bool GetPrivateProfileString(string StrAppName, string StrKey, string StrDefault, StringBuilder StrValue, int I32Size, string StrFile);


        [DllImport("kernel32")]
        public static extern bool WritePrivateProfileString(string StrAppName, string StrKey, string StrValue, string StrFile);
        #endregion
    }
}
