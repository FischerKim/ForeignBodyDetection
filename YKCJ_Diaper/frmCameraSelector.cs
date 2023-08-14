using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Jhjo.Common;
using Daekhon.Common;
using PylonC.NET;

namespace YKCJ_Diaper
{
    public partial class frmCameraSelector : Form
    {
        #region VARIABLE
        private CCameraInfo m_OCamera = null;
        #endregion


        #region PROPERTIES
        public CCameraInfo OCamera
        {
            get { return this.m_OCamera; }
            set { this.m_OCamera = value; }
        }
        #endregion


        #region CONSTRUCTOR & DESTRUCTOR
        public frmCameraSelector()
        {
            InitializeComponent();
        }
        #endregion


        #region EVENT
        #region FORM EVENT
        private void frmCameraSelector_Load(object sender, EventArgs e)
        {
            try
            {
                DataTable ODataSource = new DataTable();
                ODataSource.Columns.Add("COMPANY", typeof(string));
                ODataSource.Columns.Add("MODEL", typeof(string));
                ODataSource.Columns.Add("IP", typeof(string));
                ODataSource.Columns.Add("SERIAL", typeof(string));
                ODataSource.Columns.Add("KEY", typeof(uint));

                uint U32Count = Pylon.EnumerateDevices();
                for (uint _Index = 0; _Index < U32Count; _Index++)
                {
                    PYLON_DEVICE_INFO_HANDLE OHandle = Pylon.GetDeviceInfoHandle(_Index);

                    DataRow ORow = ODataSource.NewRow();
                    ORow["COMPANY"] = Pylon.DeviceInfoGetPropertyValueByName(OHandle, "VendorName");
                    ORow["MODEL"] = Pylon.DeviceInfoGetPropertyValueByName(OHandle, "ModelName");
                    ORow["IP"] = Pylon.DeviceInfoGetPropertyValueByName(OHandle, "IpAddress");
                    ORow["SERIAL"] = Pylon.DeviceInfoGetPropertyValueByName(OHandle, "SerialNumber");
                    ORow["KEY"] = _Index;
                    ODataSource.Rows.Add(ORow);
                }

                this.DgvCamList.DataSource = ODataSource;


                if (this.m_OCamera != null) this.LblIP.Text = this.m_OCamera.StrIP;
            }
            catch (Exception ex)
            {
                CError.Show(ex);
            }
        }
        #endregion


        #region BUTTON EVENT
        private void BtnSelectFrontLeft_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.DgvCamList.CurrentRow == null)
                {
                    CMsgBox.Warning("카메라 정보를 선택하여 주세요!");
                    return;
                }

                this.LblIP.Text = (string)(((DataRowView)(this.DgvCamList.CurrentRow.DataBoundItem)).Row)["IP"];
            }
            catch (Exception ex)
            {
                CError.Show(ex);
            }
        }


        private void BtnApply_Click(object sender, EventArgs e)
        {
            try
            {
                if (String.IsNullOrEmpty(this.LblIP.Text) == true)
                {
                    CMsgBox.Warning("카메라 정보를 선택하여 주세요!");
                    return;
                }


                DataTable ODataSource = (DataTable)this.DgvCamList.DataSource;

                foreach (DataRow _Item in ODataSource.Rows)
                {
                    if ((string)_Item["IP"] != this.LblIP.Text) continue;
                                     
                    if (this.m_OCamera == null) this.m_OCamera = new CCameraInfo();
                    this.m_OCamera.StrVender = (string)_Item["COMPANY"];
                    this.m_OCamera.StrModel = (string)_Item["MODEL"];
                    this.m_OCamera.StrIP = (string)_Item["IP"];
                    this.m_OCamera.StrSerial = (string)_Item["SERIAL"];
                    this.m_OCamera.OKey = (uint)_Item["KEY"];

                    break;
                }

                this.DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                CError.Show(ex);
            }
        }


        private void BtnClose_Click(object sender, EventArgs e)
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
    }
}
