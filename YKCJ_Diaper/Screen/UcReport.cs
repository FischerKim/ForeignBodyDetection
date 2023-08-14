using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Jhjo.Common;
using Jhjo.DB;
using Cognex.VisionPro;
using System.IO;

namespace YKCJ_Diaper
{
    public partial class UcReport : UcScreen
    {
        #region VARIABLE
        private DataTable m_ODataSource = null;
        private CogCircle m_OCircle = null;
        #endregion


        #region CONSTRUCTOR & DESTRUCTOR
        public UcReport()
        {
            InitializeComponent();

            try
            {
                this.DgvReport.AutoGenerateColumns = false;

                this.m_OCircle = new CogCircle();
                this.m_OCircle.Radius = 100;
                this.m_OCircle.Color = CogColorConstants.Red;
                this.m_OCircle.LineWidthInScreenPixels = 2;
                this.m_OCircle.Interactive = false;
                this.CdpDisplayer.InteractiveGraphics.Add(this.m_OCircle, "Position", true);
            }
            catch (Exception ex)
            {
                CError.Throw(ex);
            }
        }
        #endregion


        #region EVENT
        #region BUTTON EVENT
        private void BtnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                IDynamicTable OTable = CDB.It.GetDynamicTable(CDB.TABLE_REPORT);
                this.DgvReport.DataSource = OTable.Select(this.DtpDate.Value, true).Copy();

                if (this.m_ODataSource != null)
                {
                    this.m_ODataSource.Dispose();
                    this.m_ODataSource = null;
                }
                this.m_ODataSource = (DataTable)this.DgvReport.DataSource;
            }
            catch (Exception ex)
            {
                CError.Show(ex);
            }
        }
        #endregion


        #region ETC EVENT
        private void Splitter_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                this.PnlLeft.Size = new Size(440, this.PnlLeft.Height);
            }
            catch (Exception ex)
            {
                CError.Show(ex);
            }
        }


        private void DgvReport_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.DgvReport.CurrentRow == null) return;
                
                DataRow ORow = ((DataRowView)(this.DgvReport.CurrentRow.DataBoundItem)).Row;

                this.CdpDisplayer.Image = this.GetImage(ORow[CDB.REPORT_FILE].ToString());
                this.m_OCircle.CenterX = (double)ORow[CDB.REPORT_X];
                this.m_OCircle.CenterY = (double)ORow[CDB.REPORT_Y];


                this.LblTime.Text = ORow[CDB.REPORT_DATETIME].ToString();
                this.LblModel.Text = ORow[CDB.REPORT_RECIPE].ToString();
                this.LblTool.Text = ORow[CDB.REPORT_TOOL].ToString();
                this.LblToolNo.Text = ORow[CDB.REPORT_INDEX].ToString();
                this.LblValue.Text = ORow[CDB.REPORT_VALUE].ToString();
                this.LblRefer.Text = ORow[CDB.REPORT_REFERANCE].ToString();
                this.LblSubStance.Text = ORow[CDB.REPORT_SUBSTANCE].ToString();
                this.LblXLength.Text = ORow[CDB.REPORT_SUBSTANCE_X_LENGTH].ToString();
                this.LblYLength.Text = ORow[CDB.REPORT_SUBSTANCE_Y_LENGTH].ToString();
                this.LblPerimeter.Text = ORow[CDB.REPORT_SUBSTANCE_PERIMETER].ToString();
                this.LblArea.Text = ORow[CDB.REPORT_SUBSTANCE_AREA].ToString();
                this.LblElongation.Text = ORow[CDB.REPORT_SUBSTANCE_ELONGATION].ToString();
            }
            catch (Exception ex)
            {
                CError.Show(ex);
            }
        }
        #endregion
        #endregion


        #region FUNCTION
        public override void Remove()
        {
            try
            {
                this.DgvReport.DataSource = null;
                if (this.m_ODataSource != null)
                {
                    this.m_ODataSource.Dispose();
                    this.m_ODataSource = null;
                }

                this.CdpDisplayer.Image = null;
            }
            catch (Exception ex)
            {
                CError.Throw(ex);
            }
        }


        private CogImage8Grey GetImage(string StrPath)
        {
            CogImage8Grey OResult = null;

            try
            {
                if (String.IsNullOrEmpty(StrPath) == false)
                {
                    if (File.Exists(StrPath) == true)
                    {
                        Bitmap OSource = (Bitmap)Bitmap.FromFile(StrPath);
                        OResult = new CogImage8Grey(OSource);
                        OSource.Dispose();
                        OSource = null;

                        GC.Collect();
                    }
                }
            }
            catch (Exception ex)
            {
                CError.Throw(ex);
            }

            return OResult;
        }
        #endregion

        private void UcReport_Load(object sender, EventArgs e)
        {


        }
    }
}
