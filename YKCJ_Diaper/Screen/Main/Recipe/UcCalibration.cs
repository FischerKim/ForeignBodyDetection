using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Jhjo.Common;
using Cognex.VisionPro;
using Cognex.VisionPro.Display;

namespace YKCJ_Diaper
{
    public partial class UcCalibration : UcSubRecipe
    {
        #region CONST
        private const string MARKER1 = "MARKER1";
        private const string MARKER2 = "MARKER2";
        private const string EXPAND_VIEW = "EXPAND_VIEW";
        #endregion


        #region VARIABLE
        private CRecipeDesignTool m_OTool = null;
        private CogPointMarker m_OMarker1 = null;
        private CogPointMarker m_OMarker2 = null;
        private CogRectangle m_OBound = null;

        private bool m_BPreventEvent = false;
        #endregion


        #region CONSTRUCTOR & DESTRUCTOR
        public UcCalibration(CRecipeDesignTool OTool)
        {
            InitializeComponent();

            try
            {
                this.m_OTool = OTool;

                this.m_OMarker1 = new CogPointMarker();
                this.m_OMarker1.SizeInScreenPixels = 30;
                this.m_OMarker1.Color = CogColorConstants.Magenta;
                this.m_OMarker1.SelectedColor = CogColorConstants.Magenta;
                this.m_OMarker1.Interactive = true;
                this.m_OMarker1.GraphicDOFEnable = CogPointMarkerDOFConstants.All;

                this.m_OMarker2 = new CogPointMarker();
                this.m_OMarker2.SizeInScreenPixels = 30;
                this.m_OMarker2.Color = CogColorConstants.Magenta;
                this.m_OMarker2.SelectedColor = CogColorConstants.Magenta;
                this.m_OMarker2.Interactive = true;
                this.m_OMarker2.GraphicDOFEnable = CogPointMarkerDOFConstants.All;

                this.m_OBound = new CogRectangle();
                this.m_OBound.Color = CogColorConstants.Magenta;
                this.m_OBound.SelectedColor = CogColorConstants.Magenta;
                this.m_OBound.Interactive = true;
                this.m_OBound.GraphicDOFEnable = CogRectangleDOFConstants.All;
            }
            catch (Exception ex)
            {
                CError.Show(ex);
            }
        }
        #endregion


        #region EVENT
        #region BUTTON EVENT
        private void BtnCalibInspect_Click(object sender, EventArgs e)
        {
            try
            {
                double F64ImageWidth = Math.Abs(this.m_OMarker1.X - this.m_OMarker2.X);
                double F64ImageHeight = Math.Abs(this.m_OMarker1.Y - this.m_OMarker2.Y);
                double F64PixelWidth = Math.Round(Convert.ToInt32(this.NudCalibWidth.Value) / F64ImageWidth, 3);
                double F64PixelHeight = Math.Round(Convert.ToInt32(this.NudCalibHeight.Value) / F64ImageHeight, 3);

                this.TxtCalibPixelWidth.Text = F64PixelWidth.ToString();
                this.TxtCalibPixelHeight.Text = F64PixelHeight.ToString();
            }
            catch (Exception ex)
            {
                CError.Show(ex);
            }
        }


        private void BtnCalibApply_Click(object sender, EventArgs e)
        {
            try
            {
                CEnvironment.It.F64PixelWidth = Convert.ToDouble(this.TxtCalibPixelWidth.Text);
                CEnvironment.It.F64PixelHeight = Convert.ToDouble(this.TxtCalibPixelHeight.Text);
                CEnvironment.It.Commit();

                this.TxtScaleWidth.Text = CEnvironment.It.F64PixelWidth.ToString();
                this.TxtScaleHeight.Text = CEnvironment.It.F64PixelHeight.ToString();
            }
            catch (Exception ex)
            {
                CError.Show(ex);
            }
        }


        private void BtnScaleInspect_Click(object sender, EventArgs e)
        {
            try
            {
                double F64Width = Math.Round(Math.Abs(this.m_OMarker1.X - this.m_OMarker2.X) * CEnvironment.It.F64PixelWidth, 3);
                double F64Height = Math.Round(Math.Abs(this.m_OMarker1.Y - this.m_OMarker2.Y) * CEnvironment.It.F64PixelHeight, 3);

                this.TxtScaleRealWidth.Text = F64Width.ToString();
                this.TxtScaleRealHeight.Text = F64Height.ToString();
            }
            catch (Exception ex)
            {
                CError.Show(ex);
            }
        }
        #endregion


        #region ETC EVENT
        private void ChkCalibEnabled_CheckedChanged(object sender, EventArgs e)
        {
            if (this.m_BPreventEvent == true) return;

            try
            {
                this.m_BPreventEvent = true;
                this.m_OTool.OCdpImage.DrawingEnabled = false;

                if (this.ChkCalibEnabled.Checked == true)
                {
                    this.m_OMarker1.X = 100;
                    this.m_OMarker1.Y = 100;
                    this.m_OMarker2.X = 200;
                    this.m_OMarker2.Y = 100;
                    this.m_OTool.OCdpImage.InteractiveGraphics.Add(this.m_OMarker1, MARKER1, true);
                    this.m_OTool.OCdpImage.InteractiveGraphics.Add(this.m_OMarker2, MARKER2, true);


                    this.ChkCalibEnabled.Text = "사용";
                    this.ChkCalibEnabled.BackColor = Color.ForestGreen;
                    this.NudCalibWidth.Value = 100;
                    this.NudCalibWidth.Controls[1].Text = "100";
                    this.NudCalibHeight.Value = 100;
                    this.NudCalibHeight.Controls[1].Text = "100";
                    this.BtnCalibInspect.BackColor = Color.SteelBlue;
                    this.BtnCalibApply.BackColor = Color.SteelBlue;
                    this.NudCalibWidth.Enabled = true;
                    this.NudCalibHeight.Enabled = true;
                    this.BtnCalibInspect.Enabled = true;
                    this.BtnCalibApply.Enabled = true;

                    this.ChkScaleEnabled.BackColor = SystemColors.Control;
                    this.ChkScaleEnabled.Enabled = false;
                    this.BtnScaleInspect.BackColor = SystemColors.Control;
                    this.BtnScaleInspect.Enabled = false;

                    this.ChkExpandView.BackColor = SystemColors.Control;
                    this.ChkExpandView.Enabled = false;
                }
                else
                {
                    this.m_OTool.OCdpImage.InteractiveGraphics.Remove(MARKER1);
                    this.m_OTool.OCdpImage.InteractiveGraphics.Remove(MARKER2);


                    this.ChkCalibEnabled.Text = "사용않함";
                    this.ChkCalibEnabled.BackColor = Color.SteelBlue;
                    this.NudCalibWidth.Controls[1].Text = string.Empty;
                    this.NudCalibHeight.Controls[1].Text = string.Empty;
                    this.TxtCalibPixelWidth.Text = string.Empty;
                    this.TxtCalibPixelHeight.Text = string.Empty;
                    this.BtnCalibInspect.BackColor = SystemColors.Control;
                    this.BtnCalibApply.BackColor = SystemColors.Control;
                    this.NudCalibWidth.Enabled = false;
                    this.NudCalibHeight.Enabled = false;
                    this.BtnCalibInspect.Enabled = false;
                    this.BtnCalibApply.Enabled = false;

                    this.ChkScaleEnabled.BackColor = Color.SteelBlue;
                    this.ChkScaleEnabled.Enabled = true;

                    this.ChkExpandView.BackColor = Color.SteelBlue;
                    this.ChkExpandView.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                CError.Show(ex);
            }
            finally
            {
                this.m_OTool.OCdpImage.DrawingEnabled = true;
                this.m_BPreventEvent = false;
            }
        }


        private void ChkScaleEnabled_CheckedChanged(object sender, EventArgs e)
        {
            if (this.m_BPreventEvent == true) return;

            try
            {
                this.m_BPreventEvent = true;
                this.m_OTool.OCdpImage.DrawingEnabled = false;


                if (this.ChkScaleEnabled.Checked == true)
                {
                    this.m_OMarker1.X = 100;
                    this.m_OMarker1.Y = 100;
                    this.m_OMarker2.X = 200;
                    this.m_OMarker2.Y = 100;
                    this.m_OTool.OCdpImage.InteractiveGraphics.Add(this.m_OMarker1, MARKER1, true);
                    this.m_OTool.OCdpImage.InteractiveGraphics.Add(this.m_OMarker2, MARKER2, true);


                    this.ChkCalibEnabled.BackColor = SystemColors.Control;
                    this.ChkCalibEnabled.Enabled = false;

                    this.ChkScaleEnabled.Text = "사용";
                    this.ChkScaleEnabled.BackColor = Color.ForestGreen;
                    this.BtnScaleInspect.BackColor = Color.SteelBlue;
                    this.BtnScaleInspect.Enabled = true;

                    this.ChkExpandView.BackColor = SystemColors.Control;
                    this.ChkExpandView.Enabled = false;
                }
                else
                {
                    this.m_OTool.OCdpImage.InteractiveGraphics.Remove(MARKER1);
                    this.m_OTool.OCdpImage.InteractiveGraphics.Remove(MARKER2);


                    this.ChkCalibEnabled.BackColor = Color.SteelBlue;
                    this.ChkCalibEnabled.Enabled = true;

                    this.ChkScaleEnabled.Text = "사용않함";
                    this.ChkScaleEnabled.BackColor = Color.SteelBlue;
                    this.TxtScaleRealWidth.Text = string.Empty;
                    this.TxtScaleRealHeight.Text = string.Empty;
                    this.BtnScaleInspect.BackColor = SystemColors.Control;
                    this.BtnScaleInspect.Enabled = false;

                    this.ChkExpandView.BackColor = Color.SteelBlue;
                    this.ChkExpandView.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                CError.Show(ex);
            }
            finally
            {
                this.m_BPreventEvent = false;
                this.m_OTool.OCdpImage.DrawingEnabled = true;
            }
        }


        private void ChkExpandView_CheckedChanged(object sender, EventArgs e)
        {
            if (this.m_BPreventEvent == true) return;

            try
            {
                this.m_BPreventEvent = true;
                this.m_OTool.OCdpImage.DrawingEnabled = false;


                if (this.ChkExpandView.Checked == true)
                {
                    this.m_OBound.X = CEnvironment.It.F64ExpandViewX;
                    this.m_OBound.Y = CEnvironment.It.F64ExpandViewY;
                    this.m_OBound.Width = CEnvironment.It.F64ExpandViewWidth;
                    this.m_OBound.Height = CEnvironment.It.F64ExpandViewHeight;
                    this.m_OTool.OCdpImage.InteractiveGraphics.Add(this.m_OBound, EXPAND_VIEW, true);


                    this.ChkCalibEnabled.BackColor = SystemColors.Control;
                    this.ChkCalibEnabled.Enabled = false;

                    this.ChkScaleEnabled.BackColor = SystemColors.Control;
                    this.ChkScaleEnabled.Enabled = false;

                    this.ChkExpandView.Text = "적용";
                    this.ChkExpandView.BackColor = Color.ForestGreen;
                }
                else
                {
                    CEnvironment.It.F64ExpandViewX = this.m_OBound.X;
                    CEnvironment.It.F64ExpandViewY = this.m_OBound.Y;
                    CEnvironment.It.F64ExpandViewWidth = this.m_OBound.Width;
                    CEnvironment.It.F64ExpandViewHeight = this.m_OBound.Height;
                    CEnvironment.It.Commit();
                    CEnvironment.It.OnChangedExpandView();

                    this.m_OTool.OCdpImage.InteractiveGraphics.Remove(EXPAND_VIEW);
                    

                    this.ChkCalibEnabled.BackColor = Color.SteelBlue;
                    this.ChkCalibEnabled.Enabled = true;

                    this.ChkScaleEnabled.BackColor = Color.SteelBlue;
                    this.ChkScaleEnabled.Enabled = true;

                    this.ChkExpandView.Text = "표현";
                    this.ChkExpandView.BackColor = Color.SteelBlue;
                }
            }
            catch (Exception ex)
            {
                CError.Show(ex);
            }
            finally
            {
                this.m_OTool.OCdpImage.DrawingEnabled = true;
                this.m_BPreventEvent = false;
            }
        }
        #endregion
        #endregion


        #region FUNCTION
        public override void Remove()
        {
            try
            {
                this.m_BPreventEvent = true;

                if (this.ChkCalibEnabled.Checked == true)
                {
                    this.m_OTool.OCdpImage.InteractiveGraphics.Remove(MARKER1);
                    this.m_OTool.OCdpImage.InteractiveGraphics.Remove(MARKER2);
                }

                this.ChkCalibEnabled.Text = "사용않함";
                this.ChkCalibEnabled.Checked = false;
                this.ChkCalibEnabled.BackColor = Color.SteelBlue;
                this.NudCalibWidth.Controls[1].Text = string.Empty;
                this.NudCalibHeight.Controls[1].Text = string.Empty;
                this.TxtCalibPixelWidth.Text = string.Empty;
                this.TxtCalibPixelHeight.Text = string.Empty;
                this.BtnCalibInspect.BackColor = SystemColors.Control;
                this.BtnCalibApply.BackColor = SystemColors.Control;
                this.ChkCalibEnabled.Enabled = true;
                this.NudCalibWidth.Enabled = false;
                this.NudCalibHeight.Enabled = false;
                this.BtnCalibInspect.Enabled = false;
                this.BtnCalibApply.Enabled = false;


                if (this.ChkScaleEnabled.Checked == true)
                {
                    this.m_OTool.OCdpImage.InteractiveGraphics.Remove(MARKER1);
                    this.m_OTool.OCdpImage.InteractiveGraphics.Remove(MARKER2);
                }

                this.ChkScaleEnabled.Text = "사용않함";
                this.ChkScaleEnabled.Checked = false;
                this.ChkScaleEnabled.BackColor = Color.SteelBlue;
                this.TxtScaleWidth.Text = CEnvironment.It.F64PixelWidth.ToString();
                this.TxtScaleHeight.Text = CEnvironment.It.F64PixelHeight.ToString();
                this.TxtScaleRealWidth.Text = string.Empty;
                this.TxtScaleRealHeight.Text = string.Empty;
                this.BtnScaleInspect.BackColor = SystemColors.Control;
                this.ChkScaleEnabled.Enabled = true;
                this.BtnScaleInspect.Enabled = false;


                if (this.ChkExpandView.Checked == true)
                {
                    this.m_OTool.OCdpImage.InteractiveGraphics.Remove(EXPAND_VIEW);
                }

                this.ChkExpandView.Text = "표현";
                this.ChkExpandView.Checked = false;
                this.ChkExpandView.BackColor = Color.SteelBlue;
                this.ChkExpandView.Enabled = true;
            }
            catch (Exception ex)
            {
                CError.Throw(ex);
            }
            finally
            {
                this.m_BPreventEvent = false;
            }
        }
        #endregion
    }
}
