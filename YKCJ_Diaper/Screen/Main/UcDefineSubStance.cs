using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Cognex.VisionPro;
using Jhjo.Common;
using Cognex.VisionPro.Blob;

namespace YKCJ_Diaper
{
    public partial class UcDefineSubStance : UcSubMain
    {
        #region VARIABLE
        private CSubStanceFilterList m_OSubStanceFilterList = null;
        private CSubStanceFilter m_OSubStanceFilter = null;
        private EEDIT m_EEdit = EEDIT.NONE;

        private CogRectangle m_OROI = null;
        private CogBlobTool m_OInspectTool = null;
        private CDefineSubStanceHelperTool m_OHelperTool = null;

        private bool m_BPreventEvent = false;
        #endregion


        #region CONSTRUCTOR & DESTRUCTOR
        public UcDefineSubStance()
        {
            InitializeComponent();

            try
            {
                this.m_OROI = new CogRectangle();
                this.m_OROI.X = 0;
                this.m_OROI.Y = 0;
                this.m_OROI.Width = 100;
                this.m_OROI.Height = 100;
                this.m_OROI.Color = CogColorConstants.Red;
                this.m_OROI.Interactive = true;
                this.m_OROI.GraphicDOFEnable = CogRectangleDOFConstants.All;
                this.CdpImage.InteractiveGraphics.Add(this.m_OROI, "ROI", true);

                this.m_OInspectTool = new CogBlobTool();
                this.m_OInspectTool.RunParams.SegmentationParams.Mode = CogBlobSegmentationModeConstants.HardFixedThreshold;
                this.m_OInspectTool.Region = this.m_OROI;

                this.m_OHelperTool = new CDefineSubStanceHelperTool(this.CdpImage);
            }
            catch (Exception ex)
            {
                CError.Throw(ex);
            }
        }
        #endregion


        #region EVENT
        #region BUTTON EVENT
        private void BtnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                this.m_BPreventEvent = true;


                this.m_EEdit = EEDIT.ADD;
                this.m_OSubStanceFilter = new CSubStanceFilter();
                

                this.TxtName.Text = string.Empty;
                this.CmbColor.Text = this.m_OSubStanceFilter.EColor.ToString();
                this.LblColor.BackColor = this.GetColor(this.m_OSubStanceFilter.EColor.ToString());
                this.TxtName.ReadOnly = false;
                this.CmbColor.Enabled = true;
                                
                //XLength
                if (this.m_OSubStanceFilter.OXLength.BEnabled == true)
                {
                    this.ChkEnabledXLength.Text = "사용";
                    this.ChkEnabledXLength.Checked = true;
                    this.ChkEnabledXLength.BackColor = Color.SteelBlue;
                    this.ChkEnabledXLength.Enabled = true;

                    if (this.m_OSubStanceFilter.OXLength.BEnabledMin == true)
                    {
                        this.ChkEnabledMinOfXLength.Checked = true;
                        this.ChkEnabledMinOfXLength.Enabled = true;

                        this.NudMinOfXLength.Value = Convert.ToDecimal(this.m_OSubStanceFilter.OXLength.F64Min);
                        this.NudMinOfXLength.Controls[1].Text = this.m_OSubStanceFilter.OXLength.F64Min.ToString("0.0");
                        this.NudMinOfXLength.Enabled = true;
                    }
                    else
                    {
                        this.ChkEnabledMinOfXLength.Checked = false;
                        this.ChkEnabledMinOfXLength.Enabled = true;

                        this.NudMinOfXLength.Controls[1].Text = string.Empty;
                        this.NudMinOfXLength.Enabled = false;
                    }
                    if (this.m_OSubStanceFilter.OXLength.BEnabledMax == true)
                    {
                        this.ChkEnabledMaxOfXLength.Checked = true;
                        this.ChkEnabledMaxOfXLength.Enabled = true;

                        this.NudMaxOfXLength.Value = Convert.ToDecimal(this.m_OSubStanceFilter.OXLength.F64Max);
                        this.NudMaxOfXLength.Controls[1].Text = this.m_OSubStanceFilter.OXLength.F64Max.ToString("0.0");
                        this.NudMaxOfXLength.Enabled = true;
                    }
                    else
                    {
                        this.ChkEnabledMaxOfXLength.Checked = false;
                        this.ChkEnabledMaxOfXLength.Enabled = true;

                        this.NudMaxOfXLength.Controls[1].Text = string.Empty;
                        this.NudMaxOfXLength.Enabled = false;
                    }
                }
                else
                {
                    this.ChkEnabledXLength.Text = "사용안함";
                    this.ChkEnabledXLength.Checked = false;
                    this.ChkEnabledXLength.BackColor = Color.SteelBlue;
                    this.ChkEnabledXLength.Enabled = true;

                    this.ChkEnabledMinOfXLength.Checked = false;
                    this.ChkEnabledMinOfXLength.Enabled = false;
                    this.NudMinOfXLength.Controls[1].Text = string.Empty;
                    this.NudMinOfXLength.Enabled = false;

                    this.ChkEnabledMaxOfXLength.Checked = false;
                    this.ChkEnabledMaxOfXLength.Enabled = false;
                    this.NudMaxOfXLength.Controls[1].Text = string.Empty;
                    this.NudMaxOfXLength.Enabled = false;
                }

                //YLength
                if (this.m_OSubStanceFilter.OYLength.BEnabled == true)
                {
                    this.ChkEnabledYLength.Text = "사용";
                    this.ChkEnabledYLength.Checked = true;
                    this.ChkEnabledYLength.BackColor = Color.SteelBlue;
                    this.ChkEnabledYLength.Enabled = true;

                    if (this.m_OSubStanceFilter.OYLength.BEnabledMin == true)
                    {
                        this.ChkEnabledMinOfYLength.Checked = true;
                        this.ChkEnabledMinOfYLength.Enabled = true;

                        this.NudMinOfYLength.Value = Convert.ToDecimal(this.m_OSubStanceFilter.OYLength.F64Min);
                        this.NudMinOfYLength.Controls[1].Text = this.m_OSubStanceFilter.OYLength.F64Min.ToString("0.0");
                        this.NudMinOfYLength.Enabled = true;
                    }
                    else
                    {
                        this.ChkEnabledMinOfYLength.Checked = false;
                        this.ChkEnabledMinOfYLength.Enabled = true;

                        this.NudMinOfYLength.Controls[1].Text = string.Empty;
                        this.NudMinOfYLength.Enabled = false;
                    }
                    if (this.m_OSubStanceFilter.OYLength.BEnabledMax == true)
                    {
                        this.ChkEnabledMaxOfYLength.Checked = true;
                        this.ChkEnabledMaxOfYLength.Enabled = true;

                        this.NudMaxOfYLength.Value = Convert.ToDecimal(this.m_OSubStanceFilter.OYLength.F64Max);
                        this.NudMaxOfYLength.Controls[1].Text = this.m_OSubStanceFilter.OYLength.F64Max.ToString("0.0");
                        this.NudMaxOfYLength.Enabled = true;
                    }
                    else
                    {
                        this.ChkEnabledMaxOfYLength.Checked = false;
                        this.ChkEnabledMaxOfYLength.Enabled = true;

                        this.NudMaxOfYLength.Controls[1].Text = string.Empty;
                        this.NudMaxOfYLength.Enabled = false;
                    }
                }
                else
                {
                    this.ChkEnabledYLength.Text = "사용안함";
                    this.ChkEnabledYLength.Checked = false;
                    this.ChkEnabledYLength.BackColor = Color.SteelBlue;
                    this.ChkEnabledYLength.Enabled = true;

                    this.ChkEnabledMinOfYLength.Checked = false;
                    this.ChkEnabledMinOfYLength.Enabled = false;
                    this.NudMinOfYLength.Controls[1].Text = string.Empty;
                    this.NudMinOfYLength.Enabled = false;

                    this.ChkEnabledMaxOfYLength.Checked = false;
                    this.ChkEnabledMaxOfYLength.Enabled = false;
                    this.NudMaxOfYLength.Controls[1].Text = string.Empty;
                    this.NudMaxOfYLength.Enabled = false;
                }

                //Perimeter
                if (this.m_OSubStanceFilter.OPerimeter.BEnabled == true)
                {
                    this.ChkEnabledPerimeter.Text = "사용";
                    this.ChkEnabledPerimeter.Checked = true;
                    this.ChkEnabledPerimeter.BackColor = Color.SteelBlue;
                    this.ChkEnabledPerimeter.Enabled = true;

                    if (this.m_OSubStanceFilter.OPerimeter.BEnabledMin == true)
                    {
                        this.ChkEnabledMinOfPerimeter.Checked = true;
                        this.ChkEnabledMinOfPerimeter.Enabled = true;

                        this.NudMinOfPerimeter.Value = Convert.ToDecimal(this.m_OSubStanceFilter.OPerimeter.F64Min);
                        this.NudMinOfPerimeter.Controls[1].Text = this.m_OSubStanceFilter.OPerimeter.F64Min.ToString("0.0");
                        this.NudMinOfPerimeter.Enabled = true;
                    }
                    else
                    {
                        this.ChkEnabledMinOfPerimeter.Checked = false;
                        this.ChkEnabledMinOfPerimeter.Enabled = true;

                        this.NudMinOfPerimeter.Controls[1].Text = string.Empty;
                        this.NudMinOfPerimeter.Enabled = false;
                    }
                    if (this.m_OSubStanceFilter.OPerimeter.BEnabledMax == true)
                    {
                        this.ChkEnabledMaxOfPerimeter.Checked = true;
                        this.ChkEnabledMaxOfPerimeter.Enabled = true;

                        this.NudMaxOfPerimeter.Value = Convert.ToDecimal(this.m_OSubStanceFilter.OPerimeter.F64Max);
                        this.NudMaxOfPerimeter.Controls[1].Text = this.m_OSubStanceFilter.OPerimeter.F64Max.ToString("0.0");
                        this.NudMaxOfPerimeter.Enabled = true;
                    }
                    else
                    {
                        this.ChkEnabledMaxOfPerimeter.Checked = false;
                        this.ChkEnabledMaxOfPerimeter.Enabled = true;

                        this.NudMaxOfPerimeter.Controls[1].Text = string.Empty;
                        this.NudMaxOfPerimeter.Enabled = false;
                    }
                }
                else
                {
                    this.ChkEnabledPerimeter.Text = "사용안함";
                    this.ChkEnabledPerimeter.Checked = false;
                    this.ChkEnabledPerimeter.BackColor = Color.SteelBlue;
                    this.ChkEnabledPerimeter.Enabled = true;

                    this.ChkEnabledMinOfPerimeter.Checked = false;
                    this.ChkEnabledMinOfPerimeter.Enabled = false;
                    this.NudMinOfPerimeter.Controls[1].Text = string.Empty;
                    this.NudMinOfPerimeter.Enabled = false;

                    this.ChkEnabledMaxOfPerimeter.Checked = false;
                    this.ChkEnabledMaxOfPerimeter.Enabled = false;
                    this.NudMaxOfPerimeter.Controls[1].Text = string.Empty;
                    this.NudMaxOfPerimeter.Enabled = false;
                }

                //Area
                if (this.m_OSubStanceFilter.OArea.BEnabled == true)
                {
                    this.ChkEnabledArea.Text = "사용";
                    this.ChkEnabledArea.Checked = true;
                    this.ChkEnabledArea.BackColor = Color.SteelBlue;
                    this.ChkEnabledArea.Enabled = true;

                    if (this.m_OSubStanceFilter.OArea.BEnabledMin == true)
                    {
                        this.ChkEnabledMinOfArea.Checked = true;
                        this.ChkEnabledMinOfArea.Enabled = true;

                        this.NudMinOfArea.Value = Convert.ToDecimal(this.m_OSubStanceFilter.OArea.F64Min);
                        this.NudMinOfArea.Controls[1].Text = this.m_OSubStanceFilter.OArea.F64Min.ToString("0.0");
                        this.NudMinOfArea.Enabled = true;
                    }
                    else
                    {
                        this.ChkEnabledMinOfArea.Checked = false;
                        this.ChkEnabledMinOfArea.Enabled = true;

                        this.NudMinOfArea.Controls[1].Text = string.Empty;
                        this.NudMinOfArea.Enabled = false;
                    }
                    if (this.m_OSubStanceFilter.OArea.BEnabledMax == true)
                    {
                        this.ChkEnabledMaxOfArea.Checked = true;
                        this.ChkEnabledMaxOfArea.Enabled = true;

                        this.NudMaxOfArea.Value = Convert.ToDecimal(this.m_OSubStanceFilter.OArea.F64Max);
                        this.NudMaxOfArea.Controls[1].Text = this.m_OSubStanceFilter.OArea.F64Max.ToString("0.0");
                        this.NudMaxOfArea.Enabled = true;
                    }
                    else
                    {
                        this.ChkEnabledMaxOfArea.Checked = false;
                        this.ChkEnabledMaxOfArea.Enabled = true;

                        this.NudMaxOfArea.Controls[1].Text = string.Empty;
                        this.NudMaxOfArea.Enabled = false;
                    }
                }
                else
                {
                    this.ChkEnabledArea.Text = "사용안함";
                    this.ChkEnabledArea.Checked = false;
                    this.ChkEnabledArea.BackColor = Color.SteelBlue;
                    this.ChkEnabledArea.Enabled = true;

                    this.ChkEnabledMinOfArea.Checked = false;
                    this.ChkEnabledMinOfArea.Enabled = false;
                    this.NudMinOfArea.Controls[1].Text = string.Empty;
                    this.NudMinOfArea.Enabled = false;

                    this.ChkEnabledMaxOfArea.Checked = false;
                    this.ChkEnabledMaxOfArea.Enabled = false;
                    this.NudMaxOfArea.Controls[1].Text = string.Empty;
                    this.NudMaxOfArea.Enabled = false;
                }

                //Elongation
                if (this.m_OSubStanceFilter.OElongation.BEnabled == true)
                {
                    this.ChkEnabledElongation.Text = "사용";
                    this.ChkEnabledElongation.Checked = true;
                    this.ChkEnabledElongation.BackColor = Color.SteelBlue;
                    this.ChkEnabledElongation.Enabled = true;

                    if (this.m_OSubStanceFilter.OElongation.BEnabledMin == true)
                    {
                        this.ChkEnabledMinOfElongation.Checked = true;
                        this.ChkEnabledMinOfElongation.Enabled = true;

                        this.NudMinOfElongation.Value = Convert.ToDecimal(this.m_OSubStanceFilter.OElongation.F64Min);
                        this.NudMinOfElongation.Controls[1].Text = this.m_OSubStanceFilter.OElongation.F64Min.ToString("0.0");
                        this.NudMinOfElongation.Enabled = true;
                    }
                    else
                    {
                        this.ChkEnabledMinOfElongation.Checked = false;
                        this.ChkEnabledMinOfElongation.Enabled = true;

                        this.NudMinOfElongation.Controls[1].Text = string.Empty;
                        this.NudMinOfElongation.Enabled = false;
                    }
                    if (this.m_OSubStanceFilter.OElongation.BEnabledMax == true)
                    {
                        this.ChkEnabledMaxOfElongation.Checked = true;
                        this.ChkEnabledMaxOfElongation.Enabled = true;

                        this.NudMaxOfElongation.Value = Convert.ToDecimal(this.m_OSubStanceFilter.OElongation.F64Max);
                        this.NudMaxOfElongation.Controls[1].Text = this.m_OSubStanceFilter.OElongation.F64Max.ToString("0.0");
                        this.NudMaxOfElongation.Enabled = true;
                    }
                    else
                    {
                        this.ChkEnabledMaxOfElongation.Checked = false;
                        this.ChkEnabledMaxOfElongation.Enabled = true;

                        this.NudMaxOfElongation.Controls[1].Text = string.Empty;
                        this.NudMaxOfElongation.Enabled = false;
                    }
                }
                else
                {
                    this.ChkEnabledElongation.Text = "사용안함";
                    this.ChkEnabledElongation.Checked = false;
                    this.ChkEnabledElongation.BackColor = Color.SteelBlue;
                    this.ChkEnabledElongation.Enabled = true;

                    this.ChkEnabledMinOfElongation.Checked = false;
                    this.ChkEnabledMinOfElongation.Enabled = false;
                    this.NudMinOfElongation.Controls[1].Text = string.Empty;
                    this.NudMinOfElongation.Enabled = false;

                    this.ChkEnabledMaxOfElongation.Checked = false;
                    this.ChkEnabledMaxOfElongation.Enabled = false;
                    this.NudMaxOfElongation.Controls[1].Text = string.Empty;
                    this.NudMaxOfElongation.Enabled = false;
                }

                this.BtnAdd.BackColor = SystemColors.Control;
                this.BtnModify.BackColor = SystemColors.Control;
                this.BtnDelete.BackColor = SystemColors.Control;
                this.BtnSave.BackColor = Color.SteelBlue;
                this.BtnCancel.BackColor = Color.SteelBlue;
            }
            catch (Exception ex)
            {
                CError.Show(ex);
            }
            finally
            {
                this.m_BPreventEvent = false;
            }
        }


        private void BtnModify_Click(object sender, EventArgs e)
        {
            try
            {
                this.m_BPreventEvent = true;


                string StrName = this.LtbList.SelectedItem.ToString();
                if (String.IsNullOrEmpty(StrName) == true)
                {
                    CMsgBox.Warning("수정을 원하는 이물 유형 항목을 선택하여 주세요!");
                    return;
                }


                this.m_EEdit = EEDIT.MODIFY;
                StrName = StrName.Substring(3);
                this.m_OSubStanceFilter = this.m_OSubStanceFilterList[StrName];
                

                this.CmbColor.Text = this.m_OSubStanceFilter.EColor.ToString();
                this.LblColor.BackColor = this.GetColor(this.m_OSubStanceFilter.EColor.ToString());
                this.TxtName.ReadOnly = true;
                this.CmbColor.Enabled = true;

                //XLength
                if (this.m_OSubStanceFilter.OXLength.BEnabled == true)
                {
                    this.ChkEnabledXLength.BackColor = Color.SteelBlue;
                    this.ChkEnabledXLength.Enabled = true;

                    if (this.m_OSubStanceFilter.OXLength.BEnabledMin == true)
                    {
                        this.ChkEnabledMinOfXLength.Enabled = true;
                        this.NudMinOfXLength.Enabled = true;
                    }
                    else
                    {
                        this.ChkEnabledMinOfXLength.Enabled = true;
                        this.NudMinOfXLength.Enabled = false;
                    }
                    if (this.m_OSubStanceFilter.OXLength.BEnabledMax == true)
                    {
                        this.ChkEnabledMaxOfXLength.Enabled = true;
                        this.NudMaxOfXLength.Enabled = true;
                    }
                    else
                    {
                        this.ChkEnabledMaxOfXLength.Enabled = true;
                        this.NudMaxOfXLength.Enabled = false;
                    }
                }
                else
                {
                    this.ChkEnabledXLength.BackColor = Color.SteelBlue;
                    this.ChkEnabledXLength.Enabled = true;

                    this.ChkEnabledMinOfXLength.Enabled = false;
                    this.NudMinOfXLength.Enabled = false;

                    this.ChkEnabledMaxOfXLength.Enabled = false;
                    this.NudMaxOfXLength.Enabled = false;
                }

                //YLength
                if (this.m_OSubStanceFilter.OYLength.BEnabled == true)
                {
                    this.ChkEnabledYLength.BackColor = Color.SteelBlue;
                    this.ChkEnabledYLength.Enabled = true;

                    if (this.m_OSubStanceFilter.OYLength.BEnabledMin == true)
                    {
                        this.ChkEnabledMinOfYLength.Enabled = true;
                        this.NudMinOfYLength.Enabled = true;
                    }
                    else
                    {
                        this.ChkEnabledMinOfYLength.Enabled = true;
                        this.NudMinOfYLength.Enabled = false;
                    }
                    if (this.m_OSubStanceFilter.OYLength.BEnabledMax == true)
                    {
                        this.ChkEnabledMaxOfYLength.Enabled = true;
                        this.NudMaxOfYLength.Enabled = true;
                    }
                    else
                    {
                        this.ChkEnabledMaxOfYLength.Enabled = true;
                        this.NudMaxOfYLength.Enabled = false;
                    }
                }
                else
                {
                    this.ChkEnabledYLength.BackColor = Color.SteelBlue;
                    this.ChkEnabledYLength.Enabled = true;

                    this.ChkEnabledMinOfYLength.Enabled = false;
                    this.NudMinOfYLength.Enabled = false;

                    this.ChkEnabledMaxOfYLength.Enabled = false;
                    this.NudMaxOfYLength.Enabled = false;
                }

                //Perimeter
                if (this.m_OSubStanceFilter.OPerimeter.BEnabled == true)
                {
                    this.ChkEnabledPerimeter.BackColor = Color.SteelBlue;
                    this.ChkEnabledPerimeter.Enabled = true;

                    if (this.m_OSubStanceFilter.OPerimeter.BEnabledMin == true)
                    {
                        this.ChkEnabledMinOfPerimeter.Enabled = true;
                        this.NudMinOfPerimeter.Enabled = true;
                    }
                    else
                    {
                        this.ChkEnabledMinOfPerimeter.Enabled = true;
                        this.NudMinOfPerimeter.Enabled = false;
                    }
                    if (this.m_OSubStanceFilter.OPerimeter.BEnabledMax == true)
                    {
                        this.ChkEnabledMaxOfPerimeter.Enabled = true;
                        this.NudMaxOfPerimeter.Enabled = true;
                    }
                    else
                    {
                        this.ChkEnabledMaxOfPerimeter.Enabled = true;
                        this.NudMaxOfPerimeter.Enabled = false;
                    }
                }
                else
                {
                    this.ChkEnabledPerimeter.BackColor = Color.SteelBlue;
                    this.ChkEnabledPerimeter.Enabled = true;

                    this.ChkEnabledMinOfPerimeter.Enabled = false;
                    this.NudMinOfPerimeter.Enabled = false;

                    this.ChkEnabledMaxOfPerimeter.Enabled = false;
                    this.NudMaxOfPerimeter.Enabled = false;
                }

                //Area
                if (this.m_OSubStanceFilter.OArea.BEnabled == true)
                {
                    this.ChkEnabledArea.BackColor = Color.SteelBlue;
                    this.ChkEnabledArea.Enabled = true;

                    if (this.m_OSubStanceFilter.OArea.BEnabledMin == true)
                    {
                        this.ChkEnabledMinOfArea.Enabled = true;
                        this.NudMinOfArea.Enabled = true;
                    }
                    else
                    {
                        this.ChkEnabledMinOfArea.Enabled = true;
                        this.NudMinOfArea.Enabled = false;
                    }
                    if (this.m_OSubStanceFilter.OArea.BEnabledMax == true)
                    {
                        this.ChkEnabledMaxOfArea.Enabled = true;
                        this.NudMaxOfArea.Enabled = true;
                    }
                    else
                    {
                        this.ChkEnabledMaxOfArea.Enabled = true;
                        this.NudMaxOfArea.Enabled = false;
                    }
                }
                else
                {
                    this.ChkEnabledArea.BackColor = Color.SteelBlue;
                    this.ChkEnabledArea.Enabled = true;

                    this.ChkEnabledMinOfArea.Enabled = false;
                    this.NudMinOfArea.Enabled = false;

                    this.ChkEnabledMaxOfArea.Enabled = false;
                    this.NudMaxOfArea.Enabled = false;
                }

                //Elongation
                if (this.m_OSubStanceFilter.OElongation.BEnabled == true)
                {
                    this.ChkEnabledElongation.BackColor = Color.SteelBlue;
                    this.ChkEnabledElongation.Enabled = true;

                    if (this.m_OSubStanceFilter.OElongation.BEnabledMin == true)
                    {
                        this.ChkEnabledMinOfElongation.Enabled = true;
                        this.NudMinOfElongation.Enabled = true;
                    }
                    else
                    {
                        this.ChkEnabledMinOfElongation.Enabled = true;
                        this.NudMinOfElongation.Enabled = false;
                    }
                    if (this.m_OSubStanceFilter.OElongation.BEnabledMax == true)
                    {
                        this.ChkEnabledMaxOfElongation.Enabled = true;
                        this.NudMaxOfElongation.Enabled = true;
                    }
                    else
                    {
                        this.ChkEnabledMaxOfElongation.Enabled = true;
                        this.NudMaxOfElongation.Enabled = false;
                    }
                }
                else
                {
                    this.ChkEnabledElongation.BackColor = Color.SteelBlue;
                    this.ChkEnabledElongation.Enabled = true;

                    this.ChkEnabledMinOfElongation.Enabled = false;
                    this.NudMinOfElongation.Enabled = false;

                    this.ChkEnabledMaxOfElongation.Enabled = false;
                    this.NudMaxOfElongation.Enabled = false;
                }

                this.BtnAdd.BackColor = SystemColors.Control;
                this.BtnModify.BackColor = SystemColors.Control;
                this.BtnDelete.BackColor = SystemColors.Control;
                this.BtnSave.BackColor = Color.SteelBlue;
                this.BtnCancel.BackColor = Color.SteelBlue;
            }
            catch (Exception ex)
            {
                CError.Show(ex);
            }
            finally
            {
                this.m_BPreventEvent = false;
            }
        }


        private void BtnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                string StrName = this.LtbList.SelectedItem.ToString();
                if (String.IsNullOrEmpty(StrName) == true)
                {
                    CMsgBox.Warning("삭제를 원하는 이물 유형 항목을 선택하여 주세요!");
                    return;
                }

                StrName = StrName.Substring(3);
                if (CMsgBox.OKCancel("'" + StrName + "' 이물질 유형을 삭제하시겠습니까?") == DialogResult.OK)
                {
                    this.m_OSubStanceFilterList.OList.Remove(this.m_OSubStanceFilterList[StrName]);

                    this.DisplaySubStanceList();
                    this.DisplayControlsAccordingToList();
                }
            }
            catch (Exception ex)
            {
                CError.Show(ex);
            }
        }


        private void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.m_EEdit == EEDIT.ADD)
                {
                    if (String.IsNullOrEmpty(this.TxtName.Text.Trim()) == true)
                    {
                        CMsgBox.Warning("이름을 입력하여 주세요.");
                        return;
                    }

                    foreach (CSubStanceFilter _Item in this.m_OSubStanceFilterList.OList)
                    {
                        if (_Item.StrName != this.TxtName.Text.Trim()) continue;

                        CMsgBox.Warning("동일 이름의 이물 유형이 존재합니다.!");
                        return;
                    }



                    this.m_OSubStanceFilter.StrName = this.TxtName.Text.Trim();
                    this.m_OSubStanceFilter.EColor = (CogColorConstants)Enum.Parse(typeof(CogColorConstants), this.CmbColor.Text);

                    //XLength
                    this.m_OSubStanceFilter.OXLength.BEnabled = this.ChkEnabledXLength.Checked;
                    this.m_OSubStanceFilter.OXLength.BEnabledMin = this.ChkEnabledMinOfXLength.Checked;
                    this.m_OSubStanceFilter.OXLength.BEnabledMax = this.ChkEnabledMaxOfXLength.Checked;
                    if (this.ChkEnabledMinOfXLength.Checked == true) this.m_OSubStanceFilter.OXLength.F64Min = Convert.ToDouble(this.NudMinOfXLength.Value);
                    if (this.ChkEnabledMaxOfXLength.Checked == true) this.m_OSubStanceFilter.OXLength.F64Max = Convert.ToDouble(this.NudMaxOfXLength.Value);

                    //YLength
                    this.m_OSubStanceFilter.OYLength.BEnabled = this.ChkEnabledYLength.Checked;
                    this.m_OSubStanceFilter.OYLength.BEnabledMin = this.ChkEnabledMinOfYLength.Checked;
                    this.m_OSubStanceFilter.OYLength.BEnabledMax = this.ChkEnabledMaxOfYLength.Checked;
                    if (this.ChkEnabledMinOfYLength.Checked == true) this.m_OSubStanceFilter.OYLength.F64Min = Convert.ToDouble(this.NudMinOfYLength.Value);
                    if (this.ChkEnabledMaxOfYLength.Checked == true) this.m_OSubStanceFilter.OYLength.F64Max = Convert.ToDouble(this.NudMaxOfYLength.Value);

                    //Perimeter
                    this.m_OSubStanceFilter.OPerimeter.BEnabled = this.ChkEnabledPerimeter.Checked;
                    this.m_OSubStanceFilter.OPerimeter.BEnabledMin = this.ChkEnabledMinOfPerimeter.Checked;
                    this.m_OSubStanceFilter.OPerimeter.BEnabledMax = this.ChkEnabledMaxOfPerimeter.Checked;
                    if (this.ChkEnabledMinOfPerimeter.Checked == true) this.m_OSubStanceFilter.OPerimeter.F64Min = Convert.ToDouble(this.NudMinOfPerimeter.Value);
                    if (this.ChkEnabledMaxOfPerimeter.Checked == true) this.m_OSubStanceFilter.OPerimeter.F64Max = Convert.ToDouble(this.NudMaxOfPerimeter.Value);

                    //Area
                    this.m_OSubStanceFilter.OArea.BEnabled = this.ChkEnabledArea.Checked;
                    this.m_OSubStanceFilter.OArea.BEnabledMin = this.ChkEnabledMinOfArea.Checked;
                    this.m_OSubStanceFilter.OArea.BEnabledMax = this.ChkEnabledMaxOfArea.Checked;
                    if (this.ChkEnabledMinOfArea.Checked == true) this.m_OSubStanceFilter.OArea.F64Min = Convert.ToDouble(this.NudMinOfArea.Value);
                    if (this.ChkEnabledMaxOfArea.Checked == true) this.m_OSubStanceFilter.OArea.F64Max = Convert.ToDouble(this.NudMaxOfArea.Value);

                    //Elongation
                    this.m_OSubStanceFilter.OElongation.BEnabled = this.ChkEnabledElongation.Checked;
                    this.m_OSubStanceFilter.OElongation.BEnabledMin = this.ChkEnabledMinOfElongation.Checked;
                    this.m_OSubStanceFilter.OElongation.BEnabledMax = this.ChkEnabledMaxOfElongation.Checked;
                    if (this.ChkEnabledMinOfElongation.Checked == true) this.m_OSubStanceFilter.OElongation.F64Min = Convert.ToDouble(this.NudMinOfElongation.Value);
                    if (this.ChkEnabledMaxOfElongation.Checked == true) this.m_OSubStanceFilter.OElongation.F64Max = Convert.ToDouble(this.NudMaxOfElongation.Value);


                    this.m_OSubStanceFilterList.OList.Add(this.m_OSubStanceFilter);
                    this.DisplaySubStanceList();
                }
                else
                {
                    this.m_OSubStanceFilter.EColor = (CogColorConstants)Enum.Parse(typeof(CogColorConstants), this.CmbColor.Text);

                    //XLength
                    this.m_OSubStanceFilter.OXLength.BEnabled = this.ChkEnabledXLength.Checked;
                    this.m_OSubStanceFilter.OXLength.BEnabledMin = this.ChkEnabledMinOfXLength.Checked;
                    this.m_OSubStanceFilter.OXLength.BEnabledMax = this.ChkEnabledMaxOfXLength.Checked;
                    if (this.ChkEnabledMinOfXLength.Checked == true) this.m_OSubStanceFilter.OXLength.F64Min = Convert.ToDouble(this.NudMinOfXLength.Value);
                    if (this.ChkEnabledMaxOfXLength.Checked == true) this.m_OSubStanceFilter.OXLength.F64Max = Convert.ToDouble(this.NudMaxOfXLength.Value);

                    //YLength
                    this.m_OSubStanceFilter.OYLength.BEnabled = this.ChkEnabledYLength.Checked;
                    this.m_OSubStanceFilter.OYLength.BEnabledMin = this.ChkEnabledMinOfYLength.Checked;
                    this.m_OSubStanceFilter.OYLength.BEnabledMax = this.ChkEnabledMaxOfYLength.Checked;
                    if (this.ChkEnabledMinOfYLength.Checked == true) this.m_OSubStanceFilter.OYLength.F64Min = Convert.ToDouble(this.NudMinOfYLength.Value);
                    if (this.ChkEnabledMaxOfYLength.Checked == true) this.m_OSubStanceFilter.OYLength.F64Max = Convert.ToDouble(this.NudMaxOfYLength.Value);

                    //Perimeter
                    this.m_OSubStanceFilter.OPerimeter.BEnabled = this.ChkEnabledPerimeter.Checked;
                    this.m_OSubStanceFilter.OPerimeter.BEnabledMin = this.ChkEnabledMinOfPerimeter.Checked;
                    this.m_OSubStanceFilter.OPerimeter.BEnabledMax = this.ChkEnabledMaxOfPerimeter.Checked;
                    if (this.ChkEnabledMinOfPerimeter.Checked == true) this.m_OSubStanceFilter.OPerimeter.F64Min = Convert.ToDouble(this.NudMinOfPerimeter.Value);
                    if (this.ChkEnabledMaxOfPerimeter.Checked == true) this.m_OSubStanceFilter.OPerimeter.F64Max = Convert.ToDouble(this.NudMaxOfPerimeter.Value);

                    //Area
                    this.m_OSubStanceFilter.OArea.BEnabled = this.ChkEnabledArea.Checked;
                    this.m_OSubStanceFilter.OArea.BEnabledMin = this.ChkEnabledMinOfArea.Checked;
                    this.m_OSubStanceFilter.OArea.BEnabledMax = this.ChkEnabledMaxOfArea.Checked;
                    if (this.ChkEnabledMinOfArea.Checked == true) this.m_OSubStanceFilter.OArea.F64Min = Convert.ToDouble(this.NudMinOfArea.Value);
                    if (this.ChkEnabledMaxOfArea.Checked == true) this.m_OSubStanceFilter.OArea.F64Max = Convert.ToDouble(this.NudMaxOfArea.Value);

                    //Elongation
                    this.m_OSubStanceFilter.OElongation.BEnabled = this.ChkEnabledElongation.Checked;
                    this.m_OSubStanceFilter.OElongation.BEnabledMin = this.ChkEnabledMinOfElongation.Checked;
                    this.m_OSubStanceFilter.OElongation.BEnabledMax = this.ChkEnabledMaxOfElongation.Checked;
                    if (this.ChkEnabledMinOfElongation.Checked == true) this.m_OSubStanceFilter.OElongation.F64Min = Convert.ToDouble(this.NudMinOfElongation.Value);
                    if (this.ChkEnabledMaxOfElongation.Checked == true) this.m_OSubStanceFilter.OElongation.F64Max = Convert.ToDouble(this.NudMaxOfElongation.Value);
                }

                this.BtnCancel.PerformClick();
            }
            catch (Exception ex)
            {
                CError.Show(ex);
            }
        }


        private void BtnCancel_Click(object sender, EventArgs e)
        {
            try
            {
                this.m_EEdit = EEDIT.NONE;
                if (this.m_OSubStanceFilter != null)
                {
                    this.m_OSubStanceFilter = null;
                }

                this.DisplaySubStanceList();
                this.DisplayControlsAccordingToList();
            }
            catch (Exception ex)
            {
                CError.Show(ex);
            }
        }


        private void BtnUp_Click(object sender, EventArgs e)
        {
            try
            {
                string StrName = this.LtbList.SelectedItem.ToString();
                if (String.IsNullOrEmpty(StrName) == true)
                {
                    CMsgBox.Warning("우선순위 변경을 원하는 이물 유형 항목을 선택하여 주세요!");
                    return;
                }


                StrName = StrName.Substring(3);
                for (int _Index = 1; _Index < this.m_OSubStanceFilterList.OList.Count; _Index++)
                {
                    if (this.m_OSubStanceFilterList.OList[_Index].StrName != StrName) continue;

                    CSubStanceFilter OTemp = this.m_OSubStanceFilterList.OList[_Index];
                    this.m_OSubStanceFilterList.OList[_Index] = this.m_OSubStanceFilterList.OList[_Index - 1];
                    this.m_OSubStanceFilterList.OList[_Index - 1] = OTemp;
                    break;
                }

                this.DisplaySubStanceList();
                for (int _Index = 0; _Index < this.LtbList.Items.Count; _Index++)
                {
                    if (this.LtbList.Items[_Index].ToString().Substring(3) != StrName) continue;

                    this.LtbList.SelectedIndex = _Index;
                    break;
                }
            }
            catch (Exception ex)
            {
                CError.Show(ex);
            }
        }


        private void BtnDown_Click(object sender, EventArgs e)
        {
            try
            {
                string StrName = this.LtbList.SelectedItem.ToString();
                if (String.IsNullOrEmpty(StrName) == true)
                {
                    CMsgBox.Warning("우선순위 변경을 원하는 이물 유형 항목을 선택하여 주세요!");
                    return;
                }


                StrName = StrName.Substring(3);
                for (int _Index = 0; _Index < this.m_OSubStanceFilterList.OList.Count - 1; _Index++)
                {
                    if (this.m_OSubStanceFilterList.OList[_Index].StrName != StrName) continue;

                    CSubStanceFilter OTemp = this.m_OSubStanceFilterList.OList[_Index];
                    this.m_OSubStanceFilterList.OList[_Index] = this.m_OSubStanceFilterList.OList[_Index + 1];
                    this.m_OSubStanceFilterList.OList[_Index + 1] = OTemp;
                    break;
                }

                this.DisplaySubStanceList();
                for (int _Index = 0; _Index < this.LtbList.Items.Count; _Index++)
                {
                    if (this.LtbList.Items[_Index].ToString().Substring(3) != StrName) continue;

                    this.LtbList.SelectedIndex = _Index;
                    break;
                }
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
                //DB
                CDB.It[CDB.TABLE_SUBSTANCE_LIST].Drop();
                CDB.It[CDB.TABLE_SUBSTANCE_INFO].Drop();

                for (int _Index = 0; _Index < this.m_OSubStanceFilterList.OList.Count; _Index++)
                {
                    int I32RowIndex = CDB.It[CDB.TABLE_SUBSTANCE_LIST].InsertRow();
                    CDB.It[CDB.TABLE_SUBSTANCE_LIST].Update(I32RowIndex, CDB.SUBSTANCE_LIST_NAME, this.m_OSubStanceFilterList.OList[_Index].StrName);
                    CDB.It[CDB.TABLE_SUBSTANCE_LIST].Update(I32RowIndex, CDB.SUBSTANCE_LIST_COLOR, this.m_OSubStanceFilterList.OList[_Index].EColor.ToString());
                    CDB.It[CDB.TABLE_SUBSTANCE_LIST].Update(I32RowIndex, CDB.SUBSTANCE_LIST_SEQ, _Index);

                    I32RowIndex = CDB.It[CDB.TABLE_SUBSTANCE_INFO].InsertRow();
                    CDB.It[CDB.TABLE_SUBSTANCE_INFO].Update(I32RowIndex, CDB.SUBSTANCE_LIST_NAME, this.m_OSubStanceFilterList.OList[_Index].StrName);
                    CDB.It[CDB.TABLE_SUBSTANCE_INFO].Update(I32RowIndex, CDB.SUBSTANCE_INFO_FEATURE, this.m_OSubStanceFilterList.OList[_Index].OXLength.EKind.ToString());
                    CDB.It[CDB.TABLE_SUBSTANCE_INFO].Update(I32RowIndex, CDB.SUBSTANCE_INFO_ENABLED, this.m_OSubStanceFilterList.OList[_Index].OXLength.BEnabled);
                    CDB.It[CDB.TABLE_SUBSTANCE_INFO].Update(I32RowIndex, CDB.SUBSTANCE_INFO_MIN_ENABLED, this.m_OSubStanceFilterList.OList[_Index].OXLength.BEnabledMin);
                    CDB.It[CDB.TABLE_SUBSTANCE_INFO].Update(I32RowIndex, CDB.SUBSTANCE_INFO_MIN, this.m_OSubStanceFilterList.OList[_Index].OXLength.F64Min);
                    CDB.It[CDB.TABLE_SUBSTANCE_INFO].Update(I32RowIndex, CDB.SUBSTANCE_INFO_MAX_ENABLED, this.m_OSubStanceFilterList.OList[_Index].OXLength.BEnabledMax);
                    CDB.It[CDB.TABLE_SUBSTANCE_INFO].Update(I32RowIndex, CDB.SUBSTANCE_INFO_MAX, this.m_OSubStanceFilterList.OList[_Index].OXLength.F64Max);

                    I32RowIndex = CDB.It[CDB.TABLE_SUBSTANCE_INFO].InsertRow();
                    CDB.It[CDB.TABLE_SUBSTANCE_INFO].Update(I32RowIndex, CDB.SUBSTANCE_LIST_NAME, this.m_OSubStanceFilterList.OList[_Index].StrName);
                    CDB.It[CDB.TABLE_SUBSTANCE_INFO].Update(I32RowIndex, CDB.SUBSTANCE_INFO_FEATURE, this.m_OSubStanceFilterList.OList[_Index].OYLength.EKind.ToString());
                    CDB.It[CDB.TABLE_SUBSTANCE_INFO].Update(I32RowIndex, CDB.SUBSTANCE_INFO_ENABLED, this.m_OSubStanceFilterList.OList[_Index].OYLength.BEnabled);
                    CDB.It[CDB.TABLE_SUBSTANCE_INFO].Update(I32RowIndex, CDB.SUBSTANCE_INFO_MIN_ENABLED, this.m_OSubStanceFilterList.OList[_Index].OYLength.BEnabledMin);
                    CDB.It[CDB.TABLE_SUBSTANCE_INFO].Update(I32RowIndex, CDB.SUBSTANCE_INFO_MIN, this.m_OSubStanceFilterList.OList[_Index].OYLength.F64Min);
                    CDB.It[CDB.TABLE_SUBSTANCE_INFO].Update(I32RowIndex, CDB.SUBSTANCE_INFO_MAX_ENABLED, this.m_OSubStanceFilterList.OList[_Index].OYLength.BEnabledMax);
                    CDB.It[CDB.TABLE_SUBSTANCE_INFO].Update(I32RowIndex, CDB.SUBSTANCE_INFO_MAX, this.m_OSubStanceFilterList.OList[_Index].OYLength.F64Max);

                    I32RowIndex = CDB.It[CDB.TABLE_SUBSTANCE_INFO].InsertRow();
                    CDB.It[CDB.TABLE_SUBSTANCE_INFO].Update(I32RowIndex, CDB.SUBSTANCE_LIST_NAME, this.m_OSubStanceFilterList.OList[_Index].StrName);
                    CDB.It[CDB.TABLE_SUBSTANCE_INFO].Update(I32RowIndex, CDB.SUBSTANCE_INFO_FEATURE, this.m_OSubStanceFilterList.OList[_Index].OPerimeter.EKind.ToString());
                    CDB.It[CDB.TABLE_SUBSTANCE_INFO].Update(I32RowIndex, CDB.SUBSTANCE_INFO_ENABLED, this.m_OSubStanceFilterList.OList[_Index].OPerimeter.BEnabled);
                    CDB.It[CDB.TABLE_SUBSTANCE_INFO].Update(I32RowIndex, CDB.SUBSTANCE_INFO_MIN_ENABLED, this.m_OSubStanceFilterList.OList[_Index].OPerimeter.BEnabledMin);
                    CDB.It[CDB.TABLE_SUBSTANCE_INFO].Update(I32RowIndex, CDB.SUBSTANCE_INFO_MIN, this.m_OSubStanceFilterList.OList[_Index].OPerimeter.F64Min);
                    CDB.It[CDB.TABLE_SUBSTANCE_INFO].Update(I32RowIndex, CDB.SUBSTANCE_INFO_MAX_ENABLED, this.m_OSubStanceFilterList.OList[_Index].OPerimeter.BEnabledMax);
                    CDB.It[CDB.TABLE_SUBSTANCE_INFO].Update(I32RowIndex, CDB.SUBSTANCE_INFO_MAX, this.m_OSubStanceFilterList.OList[_Index].OPerimeter.F64Max);

                    I32RowIndex = CDB.It[CDB.TABLE_SUBSTANCE_INFO].InsertRow();
                    CDB.It[CDB.TABLE_SUBSTANCE_INFO].Update(I32RowIndex, CDB.SUBSTANCE_LIST_NAME, this.m_OSubStanceFilterList.OList[_Index].StrName);
                    CDB.It[CDB.TABLE_SUBSTANCE_INFO].Update(I32RowIndex, CDB.SUBSTANCE_INFO_FEATURE, this.m_OSubStanceFilterList.OList[_Index].OArea.EKind.ToString());
                    CDB.It[CDB.TABLE_SUBSTANCE_INFO].Update(I32RowIndex, CDB.SUBSTANCE_INFO_ENABLED, this.m_OSubStanceFilterList.OList[_Index].OArea.BEnabled);
                    CDB.It[CDB.TABLE_SUBSTANCE_INFO].Update(I32RowIndex, CDB.SUBSTANCE_INFO_MIN_ENABLED, this.m_OSubStanceFilterList.OList[_Index].OArea.BEnabledMin);
                    CDB.It[CDB.TABLE_SUBSTANCE_INFO].Update(I32RowIndex, CDB.SUBSTANCE_INFO_MIN, this.m_OSubStanceFilterList.OList[_Index].OArea.F64Min);
                    CDB.It[CDB.TABLE_SUBSTANCE_INFO].Update(I32RowIndex, CDB.SUBSTANCE_INFO_MAX_ENABLED, this.m_OSubStanceFilterList.OList[_Index].OArea.BEnabledMax);
                    CDB.It[CDB.TABLE_SUBSTANCE_INFO].Update(I32RowIndex, CDB.SUBSTANCE_INFO_MAX, this.m_OSubStanceFilterList.OList[_Index].OArea.F64Max);

                    I32RowIndex = CDB.It[CDB.TABLE_SUBSTANCE_INFO].InsertRow();
                    CDB.It[CDB.TABLE_SUBSTANCE_INFO].Update(I32RowIndex, CDB.SUBSTANCE_LIST_NAME, this.m_OSubStanceFilterList.OList[_Index].StrName);
                    CDB.It[CDB.TABLE_SUBSTANCE_INFO].Update(I32RowIndex, CDB.SUBSTANCE_INFO_FEATURE, this.m_OSubStanceFilterList.OList[_Index].OElongation.EKind.ToString());
                    CDB.It[CDB.TABLE_SUBSTANCE_INFO].Update(I32RowIndex, CDB.SUBSTANCE_INFO_ENABLED, this.m_OSubStanceFilterList.OList[_Index].OElongation.BEnabled);
                    CDB.It[CDB.TABLE_SUBSTANCE_INFO].Update(I32RowIndex, CDB.SUBSTANCE_INFO_MIN_ENABLED, this.m_OSubStanceFilterList.OList[_Index].OElongation.BEnabledMin);
                    CDB.It[CDB.TABLE_SUBSTANCE_INFO].Update(I32RowIndex, CDB.SUBSTANCE_INFO_MIN, this.m_OSubStanceFilterList.OList[_Index].OElongation.F64Min);
                    CDB.It[CDB.TABLE_SUBSTANCE_INFO].Update(I32RowIndex, CDB.SUBSTANCE_INFO_MAX_ENABLED, this.m_OSubStanceFilterList.OList[_Index].OElongation.BEnabledMax);
                    CDB.It[CDB.TABLE_SUBSTANCE_INFO].Update(I32RowIndex, CDB.SUBSTANCE_INFO_MAX, this.m_OSubStanceFilterList.OList[_Index].OElongation.F64Max);
                }

                CDB.It[CDB.TABLE_SUBSTANCE_LIST].Commit();
                CDB.It[CDB.TABLE_SUBSTANCE_INFO].Commit();

                //Tool
                CDiaperFaultTool.It.OSubStance = this.m_OSubStanceFilterList;
            }
            catch (Exception ex)
            {
                CError.Show(ex);
            }
        }


        private void BtnImage_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog OWindow = new OpenFileDialog();
                OWindow.InitialDirectory = ".\\Image";
                OWindow.Filter = "(*.bmp, *.jpg) | *.bmp; *.jpg";
                if (OWindow.ShowDialog() == DialogResult.OK)
                {
                    this.CdpImage.StaticGraphics.Clear();
                    this.m_OHelperTool.RequestImage(OWindow.FileName);
                }
            }
            catch (Exception ex)
            {
                CError.Show(ex);
            }
        }


        private void BtnInspect_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.CdpImage.Image == null)
                {
                    CMsgBox.Warning("검사를 위해서는 이미지가 필요합니다.");
                    return;
                }

                this.m_OInspectTool.InputImage = (CogImage8Grey)this.CdpImage.Image;
                this.m_OInspectTool.RunParams.ConnectivityMinPixels = Convert.ToInt32(this.NudMinSize.Value);
                this.m_OInspectTool.RunParams.SegmentationParams.Polarity = CLanguage.GetBlobPolarity(this.CmbPolarity.Text);
                this.m_OInspectTool.RunParams.SegmentationParams.HardFixedThreshold = Convert.ToInt32(this.NudThreshold.Value);
                this.m_OInspectTool.Run();

                if (this.m_OInspectTool.Results != null)
                {
                    CogBlobResultCollection OToolResult = this.m_OInspectTool.Results.GetBlobs(true);
                    CogPolygon OBoundary = OToolResult[0].GetBoundary();
                    CogRectangle OBound = OBoundary.EnclosingRectangle(CogCopyShapeConstants.All);                    
                    CSubStanceFilter OFilter = this.m_OSubStanceFilterList.GetMatchFilter(OBound.Width, OBound.Height, OToolResult[0].Perimeter, OToolResult[0].Area, OToolResult[0].Elongation);

                    if (OFilter != null) this.LblResultName.Text = OFilter.StrName;
                    else this.LblResultName.Text = "알수없음";
                    this.LblResultXLength.Text = Math.Round(OBound.Width, 1).ToString();
                    this.LblResultYLength.Text = Math.Round(OBound.Height, 1).ToString();
                    this.LblResultPerimeter.Text = Math.Round(OToolResult[0].Perimeter, 1).ToString();
                    this.LblResultArea.Text = Math.Round(OToolResult[0].Area, 1).ToString();
                    this.LblResultElongation.Text = Math.Round(OToolResult[0].Elongation, 2).ToString();

                    this.CdpImage.StaticGraphics.Clear();
                    this.CdpImage.StaticGraphics.Add(OToolResult[0].GetBoundary(), "RESULT");
                }
            }
            catch (Exception ex)
            {
                CError.Show(ex);
            }
        }
        #endregion


        #region ETC EVENT
        private void CmbColor_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.m_BPreventEvent == true) return;

            try
            {
                this.LblColor.BackColor = this.GetColor(this.CmbColor.Text);
            }
            catch (Exception ex)
            {
                CError.Show(ex);
            }
        }


        private void ChkEnabled_CheckedChanged(object sender, EventArgs e)
        {
            if (this.m_BPreventEvent == true) return;

            try
            {
                this.m_BPreventEvent = true;

                ESUBSTANCE ESubStance = (ESUBSTANCE)Enum.Parse(typeof(ESUBSTANCE), (string)((Control)sender).Tag);

                switch (ESubStance)
                {
                    case ESUBSTANCE.X_LENGTH:
                        if (this.ChkEnabledXLength.Checked == true)
                        {
                            this.ChkEnabledXLength.Text = "사용";

                            this.ChkEnabledMinOfXLength.Checked = true;
                            this.NudMinOfXLength.Value = 0;
                            this.NudMinOfXLength.Controls[1].Text = "0.0";
                            this.ChkEnabledMaxOfXLength.Checked = true;
                            this.NudMaxOfXLength.Value = 100;
                            this.NudMaxOfXLength.Controls[1].Text = "100.0";

                            this.ChkEnabledMinOfXLength.Enabled = true;
                            this.NudMinOfXLength.Enabled = true;
                            this.ChkEnabledMaxOfXLength.Enabled = true;
                            this.NudMaxOfXLength.Enabled = true;
                        }
                        else
                        {
                            this.ChkEnabledXLength.Text = "사용안함";

                            this.ChkEnabledMinOfXLength.Checked = false;
                            this.NudMinOfXLength.Controls[1].Text = string.Empty;
                            this.ChkEnabledMaxOfXLength.Checked = false;
                            this.NudMaxOfXLength.Controls[1].Text = string.Empty;

                            this.ChkEnabledMinOfXLength.Enabled = false;
                            this.NudMinOfXLength.Enabled = false;
                            this.ChkEnabledMaxOfXLength.Enabled = false;
                            this.NudMaxOfXLength.Enabled = false;
                        }
                        break;

                    case ESUBSTANCE.Y_LENGTH:
                        if (this.ChkEnabledYLength.Checked == true)
                        {
                            this.ChkEnabledYLength.Text = "사용";

                            this.ChkEnabledMinOfYLength.Checked = true;
                            this.NudMinOfYLength.Value = 0;
                            this.NudMinOfYLength.Controls[1].Text = "0.0";
                            this.ChkEnabledMaxOfYLength.Checked = true;
                            this.NudMaxOfYLength.Value = 100;
                            this.NudMaxOfYLength.Controls[1].Text = "100.0";

                            this.ChkEnabledMinOfYLength.Enabled = true;
                            this.NudMinOfYLength.Enabled = true;
                            this.ChkEnabledMaxOfYLength.Enabled = true;
                            this.NudMaxOfYLength.Enabled = true;
                        }
                        else
                        {
                            this.ChkEnabledYLength.Text = "사용안함";

                            this.ChkEnabledMinOfYLength.Checked = false;
                            this.NudMinOfYLength.Controls[1].Text = string.Empty;
                            this.ChkEnabledMaxOfYLength.Checked = false;
                            this.NudMaxOfYLength.Controls[1].Text = string.Empty;

                            this.ChkEnabledMinOfYLength.Enabled = false;
                            this.NudMinOfYLength.Enabled = false;
                            this.ChkEnabledMaxOfYLength.Enabled = false;
                            this.NudMaxOfYLength.Enabled = false;
                        }
                        break;

                    case ESUBSTANCE.PERIMETER:
                        if (this.ChkEnabledPerimeter.Checked == true)
                        {
                            this.ChkEnabledPerimeter.Text = "사용";

                            this.ChkEnabledMinOfPerimeter.Checked = true;
                            this.NudMinOfPerimeter.Value = 0;
                            this.NudMinOfPerimeter.Controls[1].Text = "0.0";
                            this.ChkEnabledMaxOfPerimeter.Checked = true;
                            this.NudMaxOfPerimeter.Value = 100;
                            this.NudMaxOfPerimeter.Controls[1].Text = "100.0";

                            this.ChkEnabledMinOfPerimeter.Enabled = true;
                            this.NudMinOfPerimeter.Enabled = true;
                            this.ChkEnabledMaxOfPerimeter.Enabled = true;
                            this.NudMaxOfPerimeter.Enabled = true;
                        }
                        else
                        {
                            this.ChkEnabledPerimeter.Text = "사용안함";

                            this.ChkEnabledMinOfPerimeter.Checked = false;
                            this.NudMinOfPerimeter.Controls[1].Text = string.Empty;
                            this.ChkEnabledMaxOfPerimeter.Checked = false;
                            this.NudMaxOfPerimeter.Controls[1].Text = string.Empty;

                            this.ChkEnabledMinOfPerimeter.Enabled = false;
                            this.NudMinOfPerimeter.Enabled = false;
                            this.ChkEnabledMaxOfPerimeter.Enabled = false;
                            this.NudMaxOfPerimeter.Enabled = false;
                        }
                        break;

                    case ESUBSTANCE.AREA:
                        if (this.ChkEnabledArea.Checked == true)
                        {
                            this.ChkEnabledArea.Text = "사용";

                            this.ChkEnabledMinOfArea.Checked = true;
                            this.NudMinOfArea.Value = 0;
                            this.NudMinOfArea.Controls[1].Text = "0.0";
                            this.ChkEnabledMaxOfArea.Checked = true;
                            this.NudMaxOfArea.Value = 100;
                            this.NudMaxOfArea.Controls[1].Text = "100.0";

                            this.ChkEnabledMinOfArea.Enabled = true;
                            this.NudMinOfArea.Enabled = true;
                            this.ChkEnabledMaxOfArea.Enabled = true;
                            this.NudMaxOfArea.Enabled = true;
                        }
                        else
                        {
                            this.ChkEnabledArea.Text = "사용안함";

                            this.ChkEnabledMinOfArea.Checked = false;
                            this.NudMinOfArea.Controls[1].Text = string.Empty;
                            this.ChkEnabledMaxOfArea.Checked = false;
                            this.NudMaxOfArea.Controls[1].Text = string.Empty;

                            this.ChkEnabledMinOfArea.Enabled = false;
                            this.NudMinOfArea.Enabled = false;
                            this.ChkEnabledMaxOfArea.Enabled = false;
                            this.NudMaxOfArea.Enabled = false;
                        }
                        break;

                    case ESUBSTANCE.ELONGATION:
                        if (this.ChkEnabledElongation.Checked == true)
                        {
                            this.ChkEnabledElongation.Text = "사용";

                            this.ChkEnabledMinOfElongation.Checked = true;
                            this.NudMinOfElongation.Value = 0;
                            this.NudMinOfElongation.Controls[1].Text = "0.00";
                            this.ChkEnabledMaxOfElongation.Checked = true;
                            this.NudMaxOfElongation.Value = 100;
                            this.NudMaxOfElongation.Controls[1].Text = "100.00";

                            this.ChkEnabledMinOfElongation.Enabled = true;
                            this.NudMinOfElongation.Enabled = true;
                            this.ChkEnabledMaxOfElongation.Enabled = true;
                            this.NudMaxOfElongation.Enabled = true;
                        }
                        else
                        {
                            this.ChkEnabledElongation.Text = "사용안함";

                            this.ChkEnabledMinOfElongation.Checked = false;
                            this.NudMinOfElongation.Controls[1].Text = string.Empty;
                            this.ChkEnabledMaxOfElongation.Checked = false;
                            this.NudMaxOfElongation.Controls[1].Text = string.Empty;

                            this.ChkEnabledMinOfElongation.Enabled = false;
                            this.NudMinOfElongation.Enabled = false;
                            this.ChkEnabledMaxOfElongation.Enabled = false;
                            this.NudMaxOfElongation.Enabled = false;
                        }
                        break;
                }
            }
            catch (Exception ex)
            {
                CError.Show(ex);
            }
            finally
            {
                this.m_BPreventEvent = false;
            }
        }


        private void ChkEnabledMin_CheckedChanged(object sender, EventArgs e)
        {
            if (this.m_BPreventEvent == true) return;

            try
            {
                this.m_BPreventEvent = true;

                ESUBSTANCE ESubStance = (ESUBSTANCE)Enum.Parse(typeof(ESUBSTANCE), (string)((Control)sender).Tag);

                switch (ESubStance)
                {
                    case ESUBSTANCE.X_LENGTH:
                        if (this.ChkEnabledMinOfXLength.Checked == true)
                        {
                            this.NudMinOfXLength.Value = 0;
                            this.NudMinOfXLength.Controls[1].Text = "0.0";
                            this.NudMinOfXLength.Enabled = true;
                        }
                        else
                        {
                            this.NudMinOfXLength.Controls[1].Text = string.Empty;
                            this.NudMinOfXLength.Enabled = false;
                        }
                        break;

                    case ESUBSTANCE.Y_LENGTH:
                        if (this.ChkEnabledMinOfYLength.Checked == true)
                        {
                            this.NudMinOfYLength.Value = 0;
                            this.NudMinOfYLength.Controls[1].Text = "0.0";
                            this.NudMinOfYLength.Enabled = true;
                        }
                        else
                        {
                            this.NudMinOfYLength.Controls[1].Text = string.Empty;
                            this.NudMinOfYLength.Enabled = false;
                        }
                        break;

                    case ESUBSTANCE.PERIMETER:
                        if (this.ChkEnabledMinOfPerimeter.Checked == true)
                        {
                            this.NudMinOfPerimeter.Value = 0;
                            this.NudMinOfPerimeter.Controls[1].Text = "0.0";
                            this.NudMinOfPerimeter.Enabled = true;
                        }
                        else
                        {
                            this.NudMinOfPerimeter.Controls[1].Text = string.Empty;
                            this.NudMinOfPerimeter.Enabled = false;
                        }
                        break;

                    case ESUBSTANCE.AREA:
                        if (this.ChkEnabledMinOfArea.Checked == true)
                        {
                            this.NudMinOfArea.Value = 0;
                            this.NudMinOfArea.Controls[1].Text = "0.0";
                            this.NudMinOfArea.Enabled = true;
                        }
                        else
                        {
                            this.NudMinOfArea.Controls[1].Text = string.Empty;
                            this.NudMinOfArea.Enabled = false;
                        }
                        break;

                    case ESUBSTANCE.ELONGATION:
                        if (this.ChkEnabledMinOfElongation.Checked == true)
                        {
                            this.NudMinOfElongation.Value = 0;
                            this.NudMinOfElongation.Controls[1].Text = "0.00";
                            this.NudMinOfElongation.Enabled = true;
                        }
                        else
                        {
                            this.NudMinOfElongation.Controls[1].Text = string.Empty;
                            this.NudMinOfElongation.Enabled = false;
                        }
                        break;
                }
            }
            catch (Exception ex)
            {
                CError.Show(ex);
            }
            finally
            {
                this.m_BPreventEvent = false;
            }
        }


        private void ChkEnabledMax_CheckedChanged(object sender, EventArgs e)
        {
            if (this.m_BPreventEvent == true) return;

            try
            {
                this.m_BPreventEvent = true;

                ESUBSTANCE ESubStance = (ESUBSTANCE)Enum.Parse(typeof(ESUBSTANCE), (string)((Control)sender).Tag);

                switch (ESubStance)
                {
                    case ESUBSTANCE.X_LENGTH:
                        if (this.ChkEnabledMaxOfXLength.Checked == true)
                        {
                            this.NudMaxOfXLength.Value = 100;
                            this.NudMaxOfXLength.Controls[1].Text = "100.0";
                            this.NudMaxOfXLength.Enabled = true;
                        }
                        else
                        {
                            this.NudMaxOfXLength.Controls[1].Text = string.Empty;
                            this.NudMaxOfXLength.Enabled = false;
                        }
                        break;

                    case ESUBSTANCE.Y_LENGTH:
                        if (this.ChkEnabledMaxOfYLength.Checked == true)
                        {
                            this.NudMaxOfYLength.Value = 100;
                            this.NudMaxOfYLength.Controls[1].Text = "100.0";
                            this.NudMaxOfYLength.Enabled = true;
                        }
                        else
                        {
                            this.NudMaxOfYLength.Controls[1].Text = string.Empty;
                            this.NudMaxOfYLength.Enabled = false;
                        }
                        break;

                    case ESUBSTANCE.PERIMETER:
                        if (this.ChkEnabledMaxOfPerimeter.Checked == true)
                        {
                            this.NudMaxOfPerimeter.Value = 100;
                            this.NudMaxOfPerimeter.Controls[1].Text = "100.0";
                            this.NudMaxOfPerimeter.Enabled = true;
                        }
                        else
                        {
                            this.NudMaxOfPerimeter.Controls[1].Text = string.Empty;
                            this.NudMaxOfPerimeter.Enabled = false;
                        }
                        break;

                    case ESUBSTANCE.AREA:
                        if (this.ChkEnabledMaxOfArea.Checked == true)
                        {
                            this.NudMaxOfArea.Value = 100;
                            this.NudMaxOfArea.Controls[1].Text = "100.0";
                            this.NudMaxOfArea.Enabled = true;
                        }
                        else
                        {
                            this.NudMaxOfArea.Controls[1].Text = string.Empty;
                            this.NudMaxOfArea.Enabled = false;
                        }
                        break;

                    case ESUBSTANCE.ELONGATION:
                        if (this.ChkEnabledMaxOfElongation.Checked == true)
                        {
                            this.NudMaxOfElongation.Value = 100;
                            this.NudMaxOfElongation.Controls[1].Text = "100.00";
                            this.NudMaxOfElongation.Enabled = true;
                        }
                        else
                        {
                            this.NudMaxOfElongation.Controls[1].Text = string.Empty;
                            this.NudMaxOfElongation.Enabled = false;
                        }
                        break;
                }
            }
            catch (Exception ex)
            {
                CError.Show(ex);
            }
            finally
            {
                this.m_BPreventEvent = false;
            }
        }


        private void LtbList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.m_BPreventEvent == true) return;
            if (this.m_EEdit != EEDIT.NONE) return;
            if (this.LtbList.SelectedItem == null) return;

            try
            {
                this.m_BPreventEvent = true;

                string StrName = this.LtbList.SelectedItem.ToString().Substring(3);
                this.m_OSubStanceFilter = this.m_OSubStanceFilterList[StrName];

                this.TxtName.Text = this.m_OSubStanceFilter.StrName;
                this.CmbColor.Text = this.m_OSubStanceFilter.EColor.ToString();
                this.LblColor.BackColor = this.GetColor(this.m_OSubStanceFilter.EColor.ToString());

                //XLength
                if (this.m_OSubStanceFilter.OXLength.BEnabled == true)
                {
                    this.ChkEnabledXLength.Text = "사용";
                    this.ChkEnabledXLength.Checked = true;
                    this.ChkEnabledXLength.BackColor = SystemColors.Control;

                    if (this.m_OSubStanceFilter.OXLength.BEnabledMin == true)
                    {
                        this.ChkEnabledMinOfXLength.Checked = true;
                        this.NudMinOfXLength.Value = Convert.ToDecimal(this.m_OSubStanceFilter.OXLength.F64Min);
                        this.NudMinOfXLength.Controls[1].Text = this.m_OSubStanceFilter.OXLength.F64Min.ToString("0.0");
                    }
                    else
                    {
                        this.ChkEnabledMinOfXLength.Checked = false;
                        this.NudMinOfXLength.Controls[1].Text = string.Empty;
                    }
                    if (this.m_OSubStanceFilter.OXLength.BEnabledMax == true)
                    {
                        this.ChkEnabledMaxOfXLength.Checked = true;
                        this.NudMaxOfXLength.Value = Convert.ToDecimal(this.m_OSubStanceFilter.OXLength.F64Max);
                        this.NudMaxOfXLength.Controls[1].Text = this.m_OSubStanceFilter.OXLength.F64Max.ToString("0.0");
                    }
                    else
                    {
                        this.ChkEnabledMaxOfXLength.Checked = false;
                        this.NudMaxOfXLength.Controls[1].Text = string.Empty;
                    }
                }
                else
                {
                    this.ChkEnabledXLength.Text = "사용안함";
                    this.ChkEnabledXLength.Checked = false;
                    this.ChkEnabledXLength.BackColor = SystemColors.Control;

                    this.ChkEnabledMinOfXLength.Checked = false;
                    this.NudMinOfXLength.Controls[1].Text = string.Empty;

                    this.ChkEnabledMaxOfXLength.Checked = false;
                    this.NudMaxOfXLength.Controls[1].Text = string.Empty;
                }

                //YLength
                if (this.m_OSubStanceFilter.OYLength.BEnabled == true)
                {
                    this.ChkEnabledYLength.Text = "사용";
                    this.ChkEnabledYLength.Checked = true;
                    this.ChkEnabledYLength.BackColor = SystemColors.Control;

                    if (this.m_OSubStanceFilter.OYLength.BEnabledMin == true)
                    {
                        this.ChkEnabledMinOfYLength.Checked = true;
                        this.NudMinOfYLength.Value = Convert.ToDecimal(this.m_OSubStanceFilter.OYLength.F64Min);
                        this.NudMinOfYLength.Controls[1].Text = this.m_OSubStanceFilter.OYLength.F64Min.ToString("0.0");
                    }
                    else
                    {
                        this.ChkEnabledMinOfYLength.Checked = false;
                        this.NudMinOfYLength.Controls[1].Text = string.Empty;
                    }
                    if (this.m_OSubStanceFilter.OYLength.BEnabledMax == true)
                    {
                        this.ChkEnabledMaxOfYLength.Checked = true;
                        this.NudMaxOfYLength.Value = Convert.ToDecimal(this.m_OSubStanceFilter.OYLength.F64Max);
                        this.NudMaxOfYLength.Controls[1].Text = this.m_OSubStanceFilter.OYLength.F64Max.ToString("0.0");
                    }
                    else
                    {
                        this.ChkEnabledMaxOfYLength.Checked = false;
                        this.NudMaxOfYLength.Controls[1].Text = string.Empty;
                    }
                }
                else
                {
                    this.ChkEnabledYLength.Text = "사용안함";
                    this.ChkEnabledYLength.Checked = false;
                    this.ChkEnabledYLength.BackColor = SystemColors.Control;

                    this.ChkEnabledMinOfYLength.Checked = false;
                    this.NudMinOfYLength.Controls[1].Text = string.Empty;

                    this.ChkEnabledMaxOfYLength.Checked = false;
                    this.NudMaxOfYLength.Controls[1].Text = string.Empty;
                }

                //Perimeter
                if (this.m_OSubStanceFilter.OPerimeter.BEnabled == true)
                {
                    this.ChkEnabledPerimeter.Text = "사용";
                    this.ChkEnabledPerimeter.Checked = true;
                    this.ChkEnabledPerimeter.BackColor = SystemColors.Control;

                    if (this.m_OSubStanceFilter.OPerimeter.BEnabledMin == true)
                    {
                        this.ChkEnabledMinOfPerimeter.Checked = true;
                        this.NudMinOfPerimeter.Value = Convert.ToDecimal(this.m_OSubStanceFilter.OPerimeter.F64Min);
                        this.NudMinOfPerimeter.Controls[1].Text = this.m_OSubStanceFilter.OPerimeter.F64Min.ToString("0.0");
                    }
                    else
                    {
                        this.ChkEnabledMinOfPerimeter.Checked = false;
                        this.NudMinOfPerimeter.Controls[1].Text = string.Empty;
                    }
                    if (this.m_OSubStanceFilter.OPerimeter.BEnabledMax == true)
                    {
                        this.ChkEnabledMaxOfPerimeter.Checked = true;
                        this.NudMaxOfPerimeter.Value = Convert.ToDecimal(this.m_OSubStanceFilter.OPerimeter.F64Max);
                        this.NudMaxOfPerimeter.Controls[1].Text = this.m_OSubStanceFilter.OPerimeter.F64Max.ToString("0.0");
                    }
                    else
                    {
                        this.ChkEnabledMaxOfPerimeter.Checked = false;
                        this.NudMaxOfPerimeter.Controls[1].Text = string.Empty;
                    }
                }
                else
                {
                    this.ChkEnabledPerimeter.Text = "사용안함";
                    this.ChkEnabledPerimeter.Checked = false;
                    this.ChkEnabledPerimeter.BackColor = SystemColors.Control;

                    this.ChkEnabledMinOfPerimeter.Checked = false;
                    this.NudMinOfPerimeter.Controls[1].Text = string.Empty;

                    this.ChkEnabledMaxOfPerimeter.Checked = false;
                    this.NudMaxOfPerimeter.Controls[1].Text = string.Empty;
                }

                //Area
                if (this.m_OSubStanceFilter.OArea.BEnabled == true)
                {
                    this.ChkEnabledArea.Text = "사용";
                    this.ChkEnabledArea.Checked = true;
                    this.ChkEnabledArea.BackColor = SystemColors.Control;

                    if (this.m_OSubStanceFilter.OArea.BEnabledMin == true)
                    {
                        this.ChkEnabledMinOfArea.Checked = true;
                        this.NudMinOfArea.Value = Convert.ToDecimal(this.m_OSubStanceFilter.OArea.F64Min);
                        this.NudMinOfArea.Controls[1].Text = this.m_OSubStanceFilter.OArea.F64Min.ToString("0.0");
                    }
                    else
                    {
                        this.ChkEnabledMinOfArea.Checked = false;
                        this.NudMinOfArea.Controls[1].Text = string.Empty;
                    }
                    if (this.m_OSubStanceFilter.OArea.BEnabledMax == true)
                    {
                        this.ChkEnabledMaxOfArea.Checked = true;
                        this.NudMaxOfArea.Value = Convert.ToDecimal(this.m_OSubStanceFilter.OArea.F64Max);
                        this.NudMaxOfArea.Controls[1].Text = this.m_OSubStanceFilter.OArea.F64Max.ToString("0.0");
                    }
                    else
                    {
                        this.ChkEnabledMaxOfArea.Checked = false;
                        this.NudMaxOfArea.Controls[1].Text = string.Empty;
                    }
                }
                else
                {
                    this.ChkEnabledArea.Text = "사용안함";
                    this.ChkEnabledArea.Checked = false;
                    this.ChkEnabledArea.BackColor = SystemColors.Control;

                    this.ChkEnabledMinOfArea.Checked = false;
                    this.NudMinOfArea.Controls[1].Text = string.Empty;

                    this.ChkEnabledMaxOfArea.Checked = false;
                    this.NudMaxOfArea.Controls[1].Text = string.Empty;
                }

                //Elongation
                if (this.m_OSubStanceFilter.OElongation.BEnabled == true)
                {
                    this.ChkEnabledElongation.Text = "사용";
                    this.ChkEnabledElongation.Checked = true;
                    this.ChkEnabledElongation.BackColor = SystemColors.Control;

                    if (this.m_OSubStanceFilter.OElongation.BEnabledMin == true)
                    {
                        this.ChkEnabledMinOfElongation.Checked = true;
                        this.NudMinOfElongation.Value = Convert.ToDecimal(this.m_OSubStanceFilter.OElongation.F64Min);
                        this.NudMinOfElongation.Controls[1].Text = this.m_OSubStanceFilter.OElongation.F64Min.ToString("0.00");
                    }
                    else
                    {
                        this.ChkEnabledMinOfElongation.Checked = false;
                        this.NudMinOfElongation.Controls[1].Text = string.Empty;
                    }
                    if (this.m_OSubStanceFilter.OElongation.BEnabledMax == true)
                    {
                        this.ChkEnabledMaxOfElongation.Checked = true;
                        this.NudMaxOfElongation.Value = Convert.ToDecimal(this.m_OSubStanceFilter.OElongation.F64Max);
                        this.NudMaxOfElongation.Controls[1].Text = this.m_OSubStanceFilter.OElongation.F64Max.ToString("0.00");
                    }
                    else
                    {
                        this.ChkEnabledMaxOfElongation.Checked = false;
                        this.NudMaxOfElongation.Controls[1].Text = string.Empty;
                    }
                }
                else
                {
                    this.ChkEnabledElongation.Text = "사용안함";
                    this.ChkEnabledElongation.Checked = false;
                    this.ChkEnabledElongation.BackColor = SystemColors.Control;

                    this.ChkEnabledMinOfElongation.Checked = false;
                    this.NudMinOfElongation.Controls[1].Text = string.Empty;

                    this.ChkEnabledMaxOfElongation.Checked = false;
                    this.NudMaxOfElongation.Controls[1].Text = string.Empty;
                }

                this.TxtName.ReadOnly = true;
                this.CmbColor.Enabled = false;
                this.ChkEnabledXLength.Enabled = false;
                this.ChkEnabledMinOfXLength.Enabled = false;
                this.NudMinOfXLength.Enabled = false;
                this.ChkEnabledMaxOfXLength.Enabled = false;
                this.NudMaxOfXLength.Enabled = false;
                this.ChkEnabledYLength.Enabled = false;
                this.ChkEnabledMinOfYLength.Enabled = false;
                this.NudMinOfYLength.Enabled = false;
                this.ChkEnabledMaxOfYLength.Enabled = false;
                this.NudMaxOfYLength.Enabled = false;
                this.ChkEnabledPerimeter.Enabled = false;
                this.ChkEnabledMinOfPerimeter.Enabled = false;
                this.NudMinOfPerimeter.Enabled = false;
                this.ChkEnabledMaxOfPerimeter.Enabled = false;
                this.NudMaxOfPerimeter.Enabled = false;
                this.ChkEnabledArea.Enabled = false;
                this.ChkEnabledMinOfArea.Enabled = false;
                this.NudMinOfArea.Enabled = false;
                this.ChkEnabledMaxOfArea.Enabled = false;
                this.NudMaxOfArea.Enabled = false;
                this.ChkEnabledElongation.Enabled = false;
                this.ChkEnabledMinOfElongation.Enabled = false;
                this.NudMinOfElongation.Enabled = false;
                this.ChkEnabledMaxOfElongation.Enabled = false;
                this.NudMaxOfElongation.Enabled = false;
            }
            catch (Exception ex)
            {
                CError.Show(ex);
            }
            finally
            {
                this.m_BPreventEvent = false;
            }
        }
        #endregion
        #endregion


        #region FUNCTION
        public override void Add()
        {
            try
            {
                this.m_OSubStanceFilterList = CDiaperFaultTool.It.OSubStance;
                this.DisplaySubStanceList();
                this.DisplayControlsAccordingToList();
            }
            catch (Exception ex)
            {
                CError.Throw(ex);
            }
        }


        private void DisplaySubStanceList()
        {
            try
            {
                this.m_BPreventEvent = true;

                this.LtbList.Items.Clear();

                for (int _Index = 0; _Index < this.m_OSubStanceFilterList.OList.Count; _Index++)
                {
                    this.LtbList.Items.Add((_Index + 1).ToString("00") + "." + this.m_OSubStanceFilterList.OList[_Index].StrName);
                }
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


        private void DisplayControlsAccordingToList()
        {
            try
            {
                this.m_BPreventEvent = true;

                if (this.LtbList.Items.Count == 0)
                {
                    this.TxtName.Text = string.Empty;
                    this.CmbColor.SelectedIndex = -1;
                    this.LblColor.BackColor = SystemColors.Control;

                    this.ChkEnabledXLength.Text = "사용안함";
                    this.ChkEnabledXLength.Checked = false;
                    this.ChkEnabledXLength.BackColor = SystemColors.Control;
                    this.ChkEnabledMinOfXLength.Checked = false;
                    this.NudMinOfXLength.Controls[1].Text = string.Empty;
                    this.ChkEnabledMaxOfXLength.Checked = false;
                    this.NudMaxOfXLength.Controls[1].Text = string.Empty;

                    this.ChkEnabledYLength.Text = "사용안함";
                    this.ChkEnabledYLength.Checked = false;
                    this.ChkEnabledYLength.BackColor = SystemColors.Control;
                    this.ChkEnabledMinOfYLength.Checked = false;
                    this.NudMinOfYLength.Controls[1].Text = string.Empty;
                    this.ChkEnabledMaxOfYLength.Checked = false;
                    this.NudMaxOfYLength.Controls[1].Text = string.Empty;

                    this.ChkEnabledPerimeter.Text = "사용안함";
                    this.ChkEnabledPerimeter.Checked = false;
                    this.ChkEnabledPerimeter.BackColor = SystemColors.Control;
                    this.ChkEnabledMinOfPerimeter.Checked = false;
                    this.NudMinOfPerimeter.Controls[1].Text = string.Empty;
                    this.ChkEnabledMaxOfPerimeter.Checked = false;
                    this.NudMaxOfPerimeter.Controls[1].Text = string.Empty;

                    this.ChkEnabledArea.Text = "사용안함";
                    this.ChkEnabledArea.Checked = false;
                    this.ChkEnabledArea.BackColor = SystemColors.Control;
                    this.ChkEnabledMinOfArea.Checked = false;
                    this.NudMinOfArea.Controls[1].Text = string.Empty;
                    this.ChkEnabledMaxOfArea.Checked = false;
                    this.NudMaxOfArea.Controls[1].Text = string.Empty;

                    this.ChkEnabledElongation.Text = "사용안함";
                    this.ChkEnabledElongation.Checked = false;
                    this.ChkEnabledElongation.BackColor = SystemColors.Control;
                    this.ChkEnabledMinOfElongation.Checked = false;
                    this.NudMinOfElongation.Controls[1].Text = string.Empty;
                    this.ChkEnabledMaxOfElongation.Checked = false;
                    this.NudMaxOfElongation.Controls[1].Text = string.Empty;

                    this.TxtName.ReadOnly = false;
                    this.CmbColor.Enabled = false;
                    this.ChkEnabledXLength.Enabled = false;
                    this.ChkEnabledMinOfXLength.Enabled = false;
                    this.NudMinOfXLength.Enabled = false;
                    this.ChkEnabledMaxOfXLength.Enabled = false;
                    this.NudMaxOfXLength.Enabled = false;
                    this.ChkEnabledYLength.Enabled = false;
                    this.ChkEnabledMinOfYLength.Enabled = false;
                    this.NudMinOfYLength.Enabled = false;
                    this.ChkEnabledMaxOfYLength.Enabled = false;
                    this.NudMaxOfYLength.Enabled = false;
                    this.ChkEnabledPerimeter.Enabled = false;
                    this.ChkEnabledMinOfPerimeter.Enabled = false;
                    this.NudMinOfPerimeter.Enabled = false;
                    this.ChkEnabledMaxOfPerimeter.Enabled = false;
                    this.NudMaxOfPerimeter.Enabled = false;
                    this.ChkEnabledArea.Enabled = false;
                    this.ChkEnabledMinOfArea.Enabled = false;
                    this.NudMinOfArea.Enabled = false;
                    this.ChkEnabledMaxOfArea.Enabled = false;
                    this.NudMaxOfArea.Enabled = false;
                    this.ChkEnabledElongation.Enabled = false;
                    this.ChkEnabledMinOfElongation.Enabled = false;
                    this.NudMinOfElongation.Enabled = false;
                    this.ChkEnabledMaxOfElongation.Enabled = false;
                    this.NudMaxOfElongation.Enabled = false;

                    this.BtnAdd.BackColor = Color.SteelBlue;
                    this.BtnModify.BackColor = SystemColors.Control;
                    this.BtnDelete.BackColor = SystemColors.Control;
                    this.BtnSave.BackColor = SystemColors.Control;
                    this.BtnCancel.BackColor = SystemColors.Control;
                    this.BtnUp.BackColor = SystemColors.Control;
                    this.BtnDown.BackColor = SystemColors.Control;
                }
                else
                {
                    this.LtbList.SelectedIndex = 0;
                    string StrName = this.LtbList.SelectedItem.ToString().Substring(3);
                    this.m_OSubStanceFilter = this.m_OSubStanceFilterList[StrName];

                    this.TxtName.Text = this.m_OSubStanceFilter.StrName;
                    this.CmbColor.Text = this.m_OSubStanceFilter.EColor.ToString();
                    this.LblColor.BackColor = this.GetColor(this.m_OSubStanceFilter.EColor.ToString());

                    //XLength
                    if (this.m_OSubStanceFilter.OXLength.BEnabled == true)
                    {
                        this.ChkEnabledXLength.Text = "사용";
                        this.ChkEnabledXLength.Checked = true;
                        this.ChkEnabledXLength.BackColor = SystemColors.Control;

                        if (this.m_OSubStanceFilter.OXLength.BEnabledMin == true)
                        {
                            this.ChkEnabledMinOfXLength.Checked = true;
                            this.NudMinOfXLength.Value = Convert.ToDecimal(this.m_OSubStanceFilter.OXLength.F64Min);
                            this.NudMinOfXLength.Controls[1].Text = this.m_OSubStanceFilter.OXLength.F64Min.ToString("0.0");
                        }
                        else
                        {
                            this.ChkEnabledMinOfXLength.Checked = false;
                            this.NudMinOfXLength.Controls[1].Text = string.Empty;
                        }
                        if (this.m_OSubStanceFilter.OXLength.BEnabledMax == true)
                        {
                            this.ChkEnabledMaxOfXLength.Checked = true;
                            this.NudMaxOfXLength.Value = Convert.ToDecimal(this.m_OSubStanceFilter.OXLength.F64Max);
                            this.NudMaxOfXLength.Controls[1].Text = this.m_OSubStanceFilter.OXLength.F64Max.ToString("0.0");
                        }
                        else
                        {
                            this.ChkEnabledMaxOfXLength.Checked = false;
                            this.NudMaxOfXLength.Controls[1].Text = string.Empty;
                        }
                    }
                    else
                    {
                        this.ChkEnabledXLength.Text = "사용안함";
                        this.ChkEnabledXLength.Checked = false;
                        this.ChkEnabledXLength.BackColor = SystemColors.Control;

                        this.ChkEnabledMinOfXLength.Checked = false;
                        this.NudMinOfXLength.Controls[1].Text = string.Empty;

                        this.ChkEnabledMaxOfXLength.Checked = false;
                        this.NudMaxOfXLength.Controls[1].Text = string.Empty;
                    }
                    
                    //YLength
                    if (this.m_OSubStanceFilter.OYLength.BEnabled == true)
                    {
                        this.ChkEnabledYLength.Text = "사용";
                        this.ChkEnabledYLength.Checked = true;
                        this.ChkEnabledYLength.BackColor = SystemColors.Control;

                        if (this.m_OSubStanceFilter.OYLength.BEnabledMin == true)
                        {
                            this.ChkEnabledMinOfYLength.Checked = true;
                            this.NudMinOfYLength.Value = Convert.ToDecimal(this.m_OSubStanceFilter.OYLength.F64Min);
                            this.NudMinOfYLength.Controls[1].Text = this.m_OSubStanceFilter.OYLength.F64Min.ToString("0.0");
                        }
                        else
                        {
                            this.ChkEnabledMinOfYLength.Checked = false;
                            this.NudMinOfYLength.Controls[1].Text = string.Empty;
                        }
                        if (this.m_OSubStanceFilter.OYLength.BEnabledMax == true)
                        {
                            this.ChkEnabledMaxOfYLength.Checked = true;
                            this.NudMaxOfYLength.Value = Convert.ToDecimal(this.m_OSubStanceFilter.OYLength.F64Max);
                            this.NudMaxOfYLength.Controls[1].Text = this.m_OSubStanceFilter.OYLength.F64Max.ToString("0.0");
                        }
                        else
                        {
                            this.ChkEnabledMaxOfYLength.Checked = false;
                            this.NudMaxOfYLength.Controls[1].Text = string.Empty;
                        }
                    }
                    else
                    {
                        this.ChkEnabledYLength.Text = "사용안함";
                        this.ChkEnabledYLength.Checked = false;
                        this.ChkEnabledYLength.BackColor = SystemColors.Control;

                        this.ChkEnabledMinOfYLength.Checked = false;
                        this.NudMinOfYLength.Controls[1].Text = string.Empty;

                        this.ChkEnabledMaxOfYLength.Checked = false;
                        this.NudMaxOfYLength.Controls[1].Text = string.Empty;
                    }
                    
                    //Perimeter
                    if (this.m_OSubStanceFilter.OPerimeter.BEnabled == true)
                    {
                        this.ChkEnabledPerimeter.Text = "사용";
                        this.ChkEnabledPerimeter.Checked = true;
                        this.ChkEnabledPerimeter.BackColor = SystemColors.Control;

                        if (this.m_OSubStanceFilter.OPerimeter.BEnabledMin == true)
                        {
                            this.ChkEnabledMinOfPerimeter.Checked = true;
                            this.NudMinOfPerimeter.Value = Convert.ToDecimal(this.m_OSubStanceFilter.OPerimeter.F64Min);
                            this.NudMinOfPerimeter.Controls[1].Text = this.m_OSubStanceFilter.OPerimeter.F64Min.ToString("0.0");
                        }
                        else
                        {
                            this.ChkEnabledMinOfPerimeter.Checked = false;
                            this.NudMinOfPerimeter.Controls[1].Text = string.Empty;
                        }
                        if (this.m_OSubStanceFilter.OPerimeter.BEnabledMax == true)
                        {
                            this.ChkEnabledMaxOfPerimeter.Checked = true;
                            this.NudMaxOfPerimeter.Value = Convert.ToDecimal(this.m_OSubStanceFilter.OPerimeter.F64Max);
                            this.NudMaxOfPerimeter.Controls[1].Text = this.m_OSubStanceFilter.OPerimeter.F64Max.ToString("0.0");
                        }
                        else
                        {
                            this.ChkEnabledMaxOfPerimeter.Checked = false;
                            this.NudMaxOfPerimeter.Controls[1].Text = string.Empty;
                        }
                    }
                    else
                    {
                        this.ChkEnabledPerimeter.Text = "사용안함";
                        this.ChkEnabledPerimeter.Checked = false;
                        this.ChkEnabledPerimeter.BackColor = SystemColors.Control;

                        this.ChkEnabledMinOfPerimeter.Checked = false;
                        this.NudMinOfPerimeter.Controls[1].Text = string.Empty;

                        this.ChkEnabledMaxOfPerimeter.Checked = false;
                        this.NudMaxOfPerimeter.Controls[1].Text = string.Empty;
                    }
                    
                    //Area
                    if (this.m_OSubStanceFilter.OArea.BEnabled == true)
                    {
                        this.ChkEnabledArea.Text = "사용";
                        this.ChkEnabledArea.Checked = true;
                        this.ChkEnabledArea.BackColor = SystemColors.Control;

                        if (this.m_OSubStanceFilter.OArea.BEnabledMin == true)
                        {
                            this.ChkEnabledMinOfArea.Checked = true;
                            this.NudMinOfArea.Value = Convert.ToDecimal(this.m_OSubStanceFilter.OArea.F64Min);
                            this.NudMinOfArea.Controls[1].Text = this.m_OSubStanceFilter.OArea.F64Min.ToString("0.0");
                        }
                        else
                        {
                            this.ChkEnabledMinOfArea.Checked = false;
                            this.NudMinOfArea.Controls[1].Text = string.Empty;
                        }
                        if (this.m_OSubStanceFilter.OArea.BEnabledMax == true)
                        {
                            this.ChkEnabledMaxOfArea.Checked = true;
                            this.NudMaxOfArea.Value = Convert.ToDecimal(this.m_OSubStanceFilter.OArea.F64Max);
                            this.NudMaxOfArea.Controls[1].Text = this.m_OSubStanceFilter.OArea.F64Max.ToString("0.0");
                        }
                        else
                        {
                            this.ChkEnabledMaxOfArea.Checked = false;
                            this.NudMaxOfArea.Controls[1].Text = string.Empty;
                        }
                    }
                    else
                    {
                        this.ChkEnabledArea.Text = "사용안함";
                        this.ChkEnabledArea.Checked = false;
                        this.ChkEnabledArea.BackColor = SystemColors.Control;

                        this.ChkEnabledMinOfArea.Checked = false;
                        this.NudMinOfArea.Controls[1].Text = string.Empty;

                        this.ChkEnabledMaxOfArea.Checked = false;
                        this.NudMaxOfArea.Controls[1].Text = string.Empty;
                    }

                    //Elongation
                    if (this.m_OSubStanceFilter.OElongation.BEnabled == true)
                    {
                        this.ChkEnabledElongation.Text = "사용";
                        this.ChkEnabledElongation.Checked = true;
                        this.ChkEnabledElongation.BackColor = SystemColors.Control;

                        if (this.m_OSubStanceFilter.OElongation.BEnabledMin == true)
                        {
                            this.ChkEnabledMinOfElongation.Checked = true;
                            this.NudMinOfElongation.Value = Convert.ToDecimal(this.m_OSubStanceFilter.OElongation.F64Min);
                            this.NudMinOfElongation.Controls[1].Text = this.m_OSubStanceFilter.OElongation.F64Min.ToString("0.00");
                        }
                        else
                        {
                            this.ChkEnabledMinOfElongation.Checked = false;
                            this.NudMinOfElongation.Controls[1].Text = string.Empty;
                        }
                        if (this.m_OSubStanceFilter.OElongation.BEnabledMax == true)
                        {
                            this.ChkEnabledMaxOfElongation.Checked = true;
                            this.NudMaxOfElongation.Value = Convert.ToDecimal(this.m_OSubStanceFilter.OElongation.F64Max);
                            this.NudMaxOfElongation.Controls[1].Text = this.m_OSubStanceFilter.OElongation.F64Max.ToString("0.00");
                        }
                        else
                        {
                            this.ChkEnabledMaxOfElongation.Checked = false;
                            this.NudMaxOfElongation.Controls[1].Text = string.Empty;
                        }
                    }
                    else
                    {
                        this.ChkEnabledElongation.Text = "사용안함";
                        this.ChkEnabledElongation.Checked = false;
                        this.ChkEnabledElongation.BackColor = SystemColors.Control;

                        this.ChkEnabledMinOfElongation.Checked = false;
                        this.NudMinOfElongation.Controls[1].Text = string.Empty;

                        this.ChkEnabledMaxOfElongation.Checked = false;
                        this.NudMaxOfElongation.Controls[1].Text = string.Empty;
                    }

                    this.TxtName.ReadOnly = true;
                    this.CmbColor.Enabled = false;
                    this.ChkEnabledXLength.Enabled = false;
                    this.ChkEnabledMinOfXLength.Enabled = false;
                    this.NudMinOfXLength.Enabled = false;
                    this.ChkEnabledMaxOfXLength.Enabled = false;
                    this.NudMaxOfXLength.Enabled = false;
                    this.ChkEnabledYLength.Enabled = false;
                    this.ChkEnabledMinOfYLength.Enabled = false;
                    this.NudMinOfYLength.Enabled = false;
                    this.ChkEnabledMaxOfYLength.Enabled = false;
                    this.NudMaxOfYLength.Enabled = false;
                    this.ChkEnabledPerimeter.Enabled = false;
                    this.ChkEnabledMinOfPerimeter.Enabled = false;
                    this.NudMinOfPerimeter.Enabled = false;
                    this.ChkEnabledMaxOfPerimeter.Enabled = false;
                    this.NudMaxOfPerimeter.Enabled = false;
                    this.ChkEnabledArea.Enabled = false;
                    this.ChkEnabledMinOfArea.Enabled = false;
                    this.NudMinOfArea.Enabled = false;
                    this.ChkEnabledMaxOfArea.Enabled = false;
                    this.NudMaxOfArea.Enabled = false;
                    this.ChkEnabledElongation.Enabled = false;
                    this.ChkEnabledMinOfElongation.Enabled = false;
                    this.NudMinOfElongation.Enabled = false;
                    this.ChkEnabledMaxOfElongation.Enabled = false;
                    this.NudMaxOfElongation.Enabled = false;

                    this.BtnAdd.BackColor = Color.SteelBlue;
                    this.BtnModify.BackColor = Color.SteelBlue;
                    this.BtnDelete.BackColor = Color.SteelBlue;
                    this.BtnSave.BackColor = SystemColors.Control;
                    this.BtnCancel.BackColor = SystemColors.Control;
                    if (this.LtbList.Items.Count > 1)
                    {
                        this.BtnUp.BackColor = Color.SteelBlue;
                        this.BtnDown.BackColor = Color.SteelBlue;
                    }
                    else
                    {
                        this.BtnUp.BackColor = SystemColors.Control;
                        this.BtnDown.BackColor = SystemColors.Control;
                    }
                }
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


        private Color GetColor(string StrColor)
        {
            Color OResult = Color.Red;

            try
            {
                switch (StrColor)
                {
                    case "Grey":
                        OResult = Color.FromName("Gray");
                        break;

                    case "LightGrey":
                        OResult = Color.FromName("LightGray");
                        break;

                    case "DarkGrey":
                        OResult = Color.FromName("DarkGray");
                        break;

                    default:
                        OResult = Color.FromName(StrColor);
                        break;
                }
            }
            catch (Exception ex)
            {
                CError.Throw(ex);
            }

            return OResult;
        }
        #endregion


        #region ENUM
        private enum EEDIT : byte
        {
            ADD = 0x00,
            MODIFY,
            DELETE,
            NONE
        }
        #endregion        
    }
}
