using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Jhjo.Common;
using Cognex.VisionPro.Display;
using Cognex.VisionPro;
using Cognex.VisionPro.Caliper;

namespace YKCJ_Diaper
{
    public partial class UcMDCD : UcSubRecipe
    {
        #region VARIABLE
        private CRecipeDesignTool m_OTool = null;
        private CFollowRecipe m_OTarget = null;
        private CogPointMarker m_OPointMarker = null;
        private bool m_BPreventEvent = false;
        #endregion


        #region CONSTRUCTOR & DESTRUCTOR
        public UcMDCD(CRecipeDesignTool OTool)
        {
            InitializeComponent();

            try
            {
                this.m_OTool = OTool;

                this.m_OPointMarker = new CogPointMarker();
                this.m_OPointMarker.Color = CogColorConstants.Magenta;
                this.m_OPointMarker.SizeInScreenPixels = 30;
                this.m_OPointMarker.Interactive = false;

                for (int _Index = 1; _Index <= CDiaperFaultRecipe.MD_COUNT; _Index++)
                {
                    this.CmbNo.Items.Add(_Index.ToString());
                }
            }
            catch (Exception ex)
            {
                CError.Throw(ex);
            }
        }
        #endregion


        #region EVENT
        #region BUTTON EVENT
        private void BtnCopy_Click(object sender, EventArgs e)
        {
            try
            {
                this.m_BPreventEvent = true;
                this.m_OTool.OCdpImage.DrawingEnabled = false;


                if (String.IsNullOrEmpty(this.CmbCopyNo.Text) == true)
                {
                    if (this.m_OTarget.EKind == EFOLLOW.MD) CMsgBox.Warning("복사 대상 가로 맞춤 정보를 선택하여 주세요!");
                    else CMsgBox.Warning("복사 대상 세로 맞춤 정보를 선택하여 주세요!");
                    return;
                }


                if (this.CmbKind.Text == "가로 맞춤")
                {
                    foreach (CFollowRecipe _Item in this.m_OTool.ORecipe.ArrOMD)
                    {
                        if (_Item.I32Index != Convert.ToInt32(this.CmbCopyNo.Text)) continue;

                        this.m_OTarget.Copy(_Item);
                        this.m_OTarget.OROI.Refresh();
                        break;
                    }
                }
                else
                {
                    foreach (CFollowRecipe _Item in this.m_OTool.ORecipe.ArrOCD)
                    {
                        if (_Item.I32Index != Convert.ToInt32(this.CmbCopyNo.Text)) continue;

                        this.m_OTarget.Copy(_Item);
                        this.m_OTarget.OROI.Refresh();
                        break;
                    }
                }


                if (this.m_OTarget.BEnabled == true)
                {
                    this.m_OTool.Activate(this.m_OTarget);

                    this.ChkEnabled.Text = "사용";
                    this.ChkEnabled.Checked = true;
                    this.ChkEnabled.BackColor = Color.ForestGreen;
                    this.TxtDescription.Text = this.m_OTarget.StrDescription;
                    this.CmbPolarity.Text = CLanguage.GetCaliperPolarity(this.m_OTarget.EPolarity);
                    this.NudConstThreshold.Value = this.m_OTarget.I32ContrastThreshold;
                    this.NudConstThreshold.Controls[1].Text = this.NudConstThreshold.Value.ToString();
                    this.NudHalfPixel.Value = this.m_OTarget.I32HalfPixel;
                    this.NudHalfPixel.Controls[1].Text = this.NudHalfPixel.Value.ToString();
                    this.ChkPriority.Text = CLanguage.GetCaliperPriority(this.m_OTarget.EPriority);
                    this.ChkPriority.Checked = (this.m_OTarget.EPriority == ECALIPER_PRIORITY.MostPosition);
                    this.ChkPriority.BackColor = Color.SteelBlue;
                    this.BtnInspect.BackColor = Color.SteelBlue;
                    this.TxtDescription.Enabled = true;
                    this.CmbPolarity.Enabled = true;
                    this.NudConstThreshold.Enabled = true;
                    this.NudHalfPixel.Enabled = true;
                    this.ChkPriority.Enabled = true;
                    this.BtnInspect.Enabled = true;

                    if (this.m_OTarget.EKind == EFOLLOW.MD)
                    {
                        if (this.m_OTarget.OROI.F64Rotation == -180F)
                        {
                            this.BtnLeft.BackColor = Color.ForestGreen;
                            this.BtnRight.BackColor = Color.SteelBlue;
                            this.BtnTop.BackColor = SystemColors.Control;
                            this.BtnBottom.BackColor = SystemColors.Control;

                            this.BtnLeft.Enabled = false;
                            this.BtnRight.Enabled = true;
                            this.BtnTop.Enabled = false;
                            this.BtnBottom.Enabled = false;
                        }
                        else
                        {
                            this.BtnLeft.BackColor = Color.SteelBlue;
                            this.BtnRight.BackColor = Color.ForestGreen;
                            this.BtnTop.BackColor = SystemColors.Control;
                            this.BtnBottom.BackColor = SystemColors.Control;

                            this.BtnLeft.Enabled = true;
                            this.BtnRight.Enabled = false;
                            this.BtnTop.Enabled = false;
                            this.BtnBottom.Enabled = false;
                        }
                    }
                    else
                    {
                        if (this.m_OTarget.OROI.F64Rotation == -90F)
                        {
                            this.BtnLeft.BackColor = SystemColors.Control;
                            this.BtnRight.BackColor = SystemColors.Control;
                            this.BtnTop.BackColor = Color.ForestGreen;
                            this.BtnBottom.BackColor = Color.SteelBlue;

                            this.BtnLeft.Enabled = false;
                            this.BtnRight.Enabled = false;
                            this.BtnTop.Enabled = false;
                            this.BtnBottom.Enabled = true;
                        }
                        else
                        {
                            this.BtnLeft.BackColor = SystemColors.Control;
                            this.BtnRight.BackColor = SystemColors.Control;
                            this.BtnTop.BackColor = Color.SteelBlue;
                            this.BtnBottom.BackColor = Color.ForestGreen;

                            this.BtnLeft.Enabled = false;
                            this.BtnRight.Enabled = false;
                            this.BtnTop.Enabled = true;
                            this.BtnBottom.Enabled = false;
                        }
                    }
                }
                else
                {
                    this.ChkEnabled.Checked = false;
                    this.ChkEnabled.Text = "사용않함";
                    this.ChkEnabled.BackColor = Color.DarkRed;
                    this.TxtDescription.Text = string.Empty;
                    this.CmbPolarity.SelectedIndex = -1;
                    this.NudConstThreshold.Controls[1].Text = string.Empty;
                    this.NudHalfPixel.Controls[1].Text = string.Empty;
                    this.ChkPriority.Text = "명암";
                    this.ChkPriority.Checked = false;
                    this.ChkPriority.BackColor = SystemColors.Control;
                    this.BtnLeft.BackColor = SystemColors.Control;
                    this.BtnRight.BackColor = SystemColors.Control;
                    this.BtnTop.BackColor = SystemColors.Control;
                    this.BtnBottom.BackColor = SystemColors.Control;
                    this.BtnInspect.BackColor = SystemColors.Control;
                    this.TxtDescription.Enabled = false;
                    this.CmbPolarity.Enabled = false;
                    this.NudConstThreshold.Enabled = false;
                    this.NudHalfPixel.Enabled = false;
                    this.ChkPriority.Enabled = false;
                    this.BtnLeft.Enabled = false;
                    this.BtnRight.Enabled = false;
                    this.BtnTop.Enabled = false;
                    this.BtnBottom.Enabled = false;
                    this.BtnInspect.Enabled = false;
                }

                this.m_OTool.Refresh();
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


        private void BtnDirection_Click(object sender, EventArgs e)
        {
            try
            {
                this.m_OTool.OCdpImage.DrawingEnabled = false;

                string StrTag = (string)((Control)sender).Tag;

                this.m_OTarget.OROI.Reflect();

                if (StrTag == "LEFT")
                {
                    this.m_OTarget.OROI.F64Rotation = -180;

                    this.BtnLeft.BackColor = Color.ForestGreen;
                    this.BtnRight.BackColor = Color.SteelBlue;
                    this.BtnLeft.Enabled = false;
                    this.BtnRight.Enabled = true;
                }
                else if (StrTag == "RIGHT")
                {
                    this.m_OTarget.OROI.F64Rotation = 0;

                    this.BtnLeft.BackColor = Color.SteelBlue;
                    this.BtnRight.BackColor = Color.ForestGreen;
                    this.BtnLeft.Enabled = true;
                    this.BtnRight.Enabled = false;
                }
                else if (StrTag == "TOP")
                {
                    this.m_OTarget.OROI.F64Rotation = -90;

                    this.BtnTop.BackColor = Color.ForestGreen;
                    this.BtnBottom.BackColor = Color.SteelBlue;
                    this.BtnTop.Enabled = false;
                    this.BtnBottom.Enabled = true;
                }
                else if (StrTag == "BOTTOM")
                {
                    this.m_OTarget.OROI.F64Rotation = 90;

                    this.BtnTop.BackColor = Color.SteelBlue;
                    this.BtnBottom.BackColor = Color.ForestGreen;
                    this.BtnTop.Enabled = true;
                    this.BtnBottom.Enabled = false;
                }

                this.m_OTarget.OROI.Refresh();
            }
            catch (Exception ex)
            {
                CError.Show(ex);
            }
            finally
            {
                this.m_OTool.OCdpImage.DrawingEnabled = true;
            }
        }
        

        private void BtnInspect_Click(object sender, EventArgs e)
        {
            try
            {
                this.DoInspect();

                if (this.m_OTool.OMDCDTool.Results.Count == 1)
                {
                    this.m_OPointMarker.X = this.m_OTool.OMDCDTool.Results[0].Edge0.PositionX;
                    this.m_OPointMarker.Y = this.m_OTool.OMDCDTool.Results[0].Edge0.PositionY;

                    this.m_OTool.OCdpImage.StaticGraphics.Clear();
                    this.m_OTool.OCdpImage.StaticGraphics.Add(this.m_OPointMarker, "Result");
                }
                else CMsgBox.Warning("표준 위치를 찾을 수 없습니다!");
            }
            catch (Exception ex)
            {
                CError.Show(ex);
            }
        }
        #endregion


        #region ETC EVENT
        private void CmbKind_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.m_BPreventEvent == true) return;

            try
            {
                this.m_BPreventEvent = true;
                this.m_OTool.OCdpImage.DrawingEnabled = false;
                this.m_OTool.OCdpImage.StaticGraphics.Clear();

                if (this.ChkEnabled.Checked == true)
                {
                    this.DoInspect();

                    if (this.m_OTool.OMDCDTool.Results.Count != 1)
                    {
                        CMsgBox.Warning("표준 위치를 찾을 수 없습니다.!");
                        this.CmbKind.Text = (this.m_OTarget.EKind == EFOLLOW.MD) ? "가로 맞춤" : "세로 맞춤";
                        return;
                    }

                    this.m_OTarget.OROI.Reflect();
                    this.m_OTool.DeActivate();

                    this.m_OTarget.BEnabled = true;
                    this.m_OTarget.StrDescription = this.TxtDescription.Text.Trim();
                    this.m_OTarget.EPolarity = CLanguage.GetCaliperPolarity(this.CmbPolarity.Text);
                    this.m_OTarget.I32ContrastThreshold = Convert.ToInt32(this.NudConstThreshold.Value);
                    this.m_OTarget.I32HalfPixel = Convert.ToInt32(this.NudHalfPixel.Value);
                    this.m_OTarget.EPriority = CLanguage.GetCaliperPriority(this.ChkPriority.Text);
                    this.m_OTarget.F64StandardPosition = (this.m_OTarget.EKind == EFOLLOW.MD) ?
                        this.m_OTool.OMDCDTool.Results[0].Edge0.PositionX : this.m_OTool.OMDCDTool.Results[0].Edge0.PositionY;
                }
                else
                {
                    this.m_OTarget.BEnabled = false;
                    this.m_OTarget.F64StandardPosition = 0;
                }


                if (this.CmbKind.Text == "가로 맞춤")
                {
                    this.m_OTarget = this.m_OTool.ORecipe.ArrOMD[0];

                    this.CmbCopyNo.Items.Clear();
                    foreach (CFollowRecipe _Item in this.m_OTool.ORecipe.ArrOMD)
                    {
                        if (_Item.I32Index == this.m_OTarget.I32Index) continue;

                        this.CmbCopyNo.Items.Add(_Item.I32Index.ToString());
                    }
                }
                else
                {
                    this.m_OTarget = this.m_OTool.ORecipe.ArrOCD[0];

                    this.CmbCopyNo.Items.Clear();
                    foreach (CFollowRecipe _Item in this.m_OTool.ORecipe.ArrOCD)
                    {
                        if (_Item.I32Index == this.m_OTarget.I32Index) continue;

                        this.CmbCopyNo.Items.Add(_Item.I32Index.ToString());
                    }
                }


                if (this.m_OTarget.BEnabled == true)
                {
                    this.m_OTool.Activate(this.m_OTarget);

                    this.CmbNo.Text = this.m_OTarget.I32Index.ToString();
                    this.NudNo.Value = this.m_OTarget.I32Index;
                    this.CmbCopyNo.SelectedIndex = -1;
                    this.ChkEnabled.Checked = true;
                    this.ChkEnabled.Text = "사용";
                    this.ChkEnabled.BackColor = Color.ForestGreen;
                    this.TxtDescription.Text = this.m_OTarget.StrDescription;
                    this.CmbPolarity.Text = CLanguage.GetCaliperPolarity(this.m_OTarget.EPolarity);
                    this.NudConstThreshold.Value = this.m_OTarget.I32ContrastThreshold;
                    this.NudConstThreshold.Controls[1].Text = this.NudConstThreshold.Value.ToString();
                    this.NudHalfPixel.Value = this.m_OTarget.I32HalfPixel;
                    this.NudHalfPixel.Controls[1].Text = this.NudHalfPixel.Value.ToString();
                    this.ChkPriority.Text = CLanguage.GetCaliperPriority(this.m_OTarget.EPriority);
                    this.ChkPriority.Checked = (this.m_OTarget.EPriority == ECALIPER_PRIORITY.MostPosition);
                    this.ChkPriority.BackColor = Color.SteelBlue;
                    this.BtnInspect.BackColor = Color.SteelBlue;
                    this.TxtDescription.Enabled = true;
                    this.CmbPolarity.Enabled = true;
                    this.NudConstThreshold.Enabled = true;
                    this.NudHalfPixel.Enabled = true;
                    this.ChkPriority.Enabled = true;
                    this.BtnInspect.Enabled = true;

                    if (this.m_OTarget.EKind == EFOLLOW.MD)
                    {
                        if (this.m_OTarget.OROI.F64Rotation == -180F)
                        {
                            this.BtnLeft.BackColor = Color.ForestGreen;
                            this.BtnRight.BackColor = Color.SteelBlue;
                            this.BtnTop.BackColor = SystemColors.Control;
                            this.BtnBottom.BackColor = SystemColors.Control;

                            this.BtnLeft.Enabled = false;
                            this.BtnRight.Enabled = true;
                            this.BtnTop.Enabled = false;
                            this.BtnBottom.Enabled = false;
                        }
                        else
                        {
                            this.BtnLeft.BackColor = Color.SteelBlue;
                            this.BtnRight.BackColor = Color.ForestGreen;
                            this.BtnTop.BackColor = SystemColors.Control;
                            this.BtnBottom.BackColor = SystemColors.Control;

                            this.BtnLeft.Enabled = true;
                            this.BtnRight.Enabled = false;
                            this.BtnTop.Enabled = false;
                            this.BtnBottom.Enabled = false;
                        }
                    }
                    else
                    {
                        if (this.m_OTarget.OROI.F64Rotation == -90F)
                        {
                            this.BtnLeft.BackColor = SystemColors.Control;
                            this.BtnRight.BackColor = SystemColors.Control;
                            this.BtnTop.BackColor = Color.ForestGreen;
                            this.BtnBottom.BackColor = Color.SteelBlue;

                            this.BtnLeft.Enabled = false;
                            this.BtnRight.Enabled = false;
                            this.BtnTop.Enabled = false;
                            this.BtnBottom.Enabled = true;
                        }
                        else
                        {
                            this.BtnLeft.BackColor = SystemColors.Control;
                            this.BtnRight.BackColor = SystemColors.Control;
                            this.BtnTop.BackColor = Color.SteelBlue;
                            this.BtnBottom.BackColor = Color.ForestGreen;

                            this.BtnLeft.Enabled = false;
                            this.BtnRight.Enabled = false;
                            this.BtnTop.Enabled = true;
                            this.BtnBottom.Enabled = false;
                        }
                    }
                }
                else
                {
                    this.CmbNo.Text = this.m_OTarget.I32Index.ToString();
                    this.NudNo.Value = this.m_OTarget.I32Index;
                    this.CmbCopyNo.SelectedIndex = -1;
                    this.ChkEnabled.Checked = false;
                    this.ChkEnabled.Text = "사용않함";
                    this.ChkEnabled.BackColor = Color.DarkRed;
                    this.TxtDescription.Text = string.Empty;
                    this.CmbPolarity.SelectedIndex = -1;
                    this.NudConstThreshold.Controls[1].Text = string.Empty;
                    this.NudHalfPixel.Controls[1].Text = string.Empty;
                    this.ChkPriority.Text = "명암";
                    this.ChkPriority.Checked = false;
                    this.ChkPriority.BackColor = SystemColors.Control;
                    this.BtnLeft.BackColor = SystemColors.Control;
                    this.BtnRight.BackColor = SystemColors.Control;
                    this.BtnTop.BackColor = SystemColors.Control;
                    this.BtnBottom.BackColor = SystemColors.Control;
                    this.BtnInspect.BackColor = SystemColors.Control;

                    this.TxtDescription.Enabled = false;
                    this.CmbPolarity.Enabled = false;
                    this.NudConstThreshold.Enabled = false;
                    this.NudHalfPixel.Enabled = false;
                    this.ChkPriority.Enabled = false;
                    this.BtnLeft.Enabled = false;
                    this.BtnRight.Enabled = false;
                    this.BtnTop.Enabled = false;
                    this.BtnBottom.Enabled = false;
                    this.BtnInspect.Enabled = false;
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


        private void CmbNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.m_BPreventEvent == true) return;

            try
            {
                this.m_BPreventEvent = true;
                this.m_OTool.OCdpImage.DrawingEnabled = false;
                this.m_OTool.OCdpImage.StaticGraphics.Clear();


                if (this.ChkEnabled.Checked == true)
                {
                    this.DoInspect();

                    if (this.m_OTool.OMDCDTool.Results.Count != 1)
                    {
                        CMsgBox.Warning("표준 위치를 찾을 수 없습니다!");
                        this.CmbNo.Text = this.m_OTarget.I32Index.ToString();
                        this.NudNo.Value = this.m_OTarget.I32Index;
                        return;
                    }

                    this.m_OTarget.OROI.Reflect();
                    this.m_OTool.DeActivate();

                    this.m_OTarget.BEnabled = true;
                    this.m_OTarget.StrDescription = this.TxtDescription.Text.Trim();
                    this.m_OTarget.EPolarity = CLanguage.GetCaliperPolarity(this.CmbPolarity.Text);
                    this.m_OTarget.I32ContrastThreshold = Convert.ToInt32(this.NudConstThreshold.Value);
                    this.m_OTarget.I32HalfPixel = Convert.ToInt32(this.NudHalfPixel.Value);
                    this.m_OTarget.EPriority = CLanguage.GetCaliperPriority(this.ChkPriority.Text);
                    this.m_OTarget.F64StandardPosition = (this.m_OTarget.EKind == EFOLLOW.MD) ?
                        this.m_OTool.OMDCDTool.Results[0].Edge0.PositionX : this.m_OTool.OMDCDTool.Results[0].Edge0.PositionY;
                }
                else
                {
                    this.m_OTarget.BEnabled = false;
                    this.m_OTarget.EPriority = ECALIPER_PRIORITY.MostThreshold;
                }


                if (this.CmbKind.Text == "가로 맞춤")
                {
                    int I32Index = Convert.ToInt32(this.CmbNo.Text);
                    foreach (CFollowRecipe _Item in this.m_OTool.ORecipe.ArrOMD)
                    {
                        if (_Item.I32Index != I32Index) continue;

                        this.m_OTarget = _Item;
                        this.NudNo.Value = I32Index;
                        break;
                    }

                    this.CmbCopyNo.Items.Clear();
                    foreach (CFollowRecipe _Item in this.m_OTool.ORecipe.ArrOMD)
                    {
                        if (_Item.I32Index == this.m_OTarget.I32Index) continue;

                        this.CmbCopyNo.Items.Add(_Item.I32Index.ToString());
                    }
                }
                else
                {
                    int I32Index = Convert.ToInt32(this.CmbNo.Text);
                    foreach (CFollowRecipe _Item in this.m_OTool.ORecipe.ArrOCD)
                    {
                        if (_Item.I32Index != I32Index) continue;

                        this.m_OTarget = _Item;
                        break;
                    }

                    this.CmbCopyNo.Items.Clear();
                    foreach (CFollowRecipe _Item in this.m_OTool.ORecipe.ArrOCD)
                    {
                        if (_Item.I32Index == this.m_OTarget.I32Index) continue;

                        this.CmbCopyNo.Items.Add(_Item.I32Index.ToString());
                    }
                }


                if (this.m_OTarget.BEnabled == true)
                {
                    this.m_OTool.Activate(this.m_OTarget);

                    this.CmbCopyNo.SelectedIndex = -1;
                    this.ChkEnabled.Checked = true;
                    this.ChkEnabled.Text = "사용";
                    this.ChkEnabled.BackColor = Color.ForestGreen;
                    this.TxtDescription.Text = this.m_OTarget.StrDescription;
                    this.CmbPolarity.Text = CLanguage.GetCaliperPolarity(this.m_OTarget.EPolarity);
                    this.NudConstThreshold.Value = this.m_OTarget.I32ContrastThreshold;
                    this.NudConstThreshold.Controls[1].Text = this.NudConstThreshold.Value.ToString();
                    this.NudHalfPixel.Value = this.m_OTarget.I32HalfPixel;
                    this.NudHalfPixel.Controls[1].Text = this.NudHalfPixel.Value.ToString();
                    this.ChkPriority.Text = CLanguage.GetCaliperPriority(this.m_OTarget.EPriority);
                    this.ChkPriority.Checked = (this.m_OTarget.EPriority == ECALIPER_PRIORITY.MostPosition);
                    this.ChkPriority.BackColor = Color.SteelBlue;
                    this.BtnInspect.BackColor = Color.SteelBlue;

                    this.TxtDescription.Enabled = true;
                    this.CmbPolarity.Enabled = true;
                    this.NudConstThreshold.Enabled = true;
                    this.NudHalfPixel.Enabled = true;
                    this.ChkPriority.Enabled = true;
                    this.BtnInspect.Enabled = true;

                    if (this.m_OTarget.EKind == EFOLLOW.MD)
                    {
                        if (this.m_OTarget.OROI.F64Rotation == -180F)
                        {
                            this.BtnLeft.BackColor = Color.ForestGreen;
                            this.BtnRight.BackColor = Color.SteelBlue;
                            this.BtnTop.BackColor = SystemColors.Control;
                            this.BtnBottom.BackColor = SystemColors.Control;

                            this.BtnLeft.Enabled = false;
                            this.BtnRight.Enabled = true;
                            this.BtnTop.Enabled = false;
                            this.BtnBottom.Enabled = false;
                        }
                        else
                        {
                            this.BtnLeft.BackColor = Color.SteelBlue;
                            this.BtnRight.BackColor = Color.ForestGreen;
                            this.BtnTop.BackColor = SystemColors.Control;
                            this.BtnBottom.BackColor = SystemColors.Control;

                            this.BtnLeft.Enabled = true;
                            this.BtnRight.Enabled = false;
                            this.BtnTop.Enabled = false;
                            this.BtnBottom.Enabled = false;
                        }
                    }
                    else
                    {
                        if (this.m_OTarget.OROI.F64Rotation == -90F)
                        {
                            this.BtnLeft.BackColor = SystemColors.Control;
                            this.BtnRight.BackColor = SystemColors.Control;
                            this.BtnTop.BackColor = Color.ForestGreen;
                            this.BtnBottom.BackColor = Color.SteelBlue;

                            this.BtnLeft.Enabled = false;
                            this.BtnRight.Enabled = false;
                            this.BtnTop.Enabled = false;
                            this.BtnBottom.Enabled = true;
                        }
                        else
                        {
                            this.BtnLeft.BackColor = SystemColors.Control;
                            this.BtnRight.BackColor = SystemColors.Control;
                            this.BtnTop.BackColor = Color.SteelBlue;
                            this.BtnBottom.BackColor = Color.ForestGreen;

                            this.BtnLeft.Enabled = false;
                            this.BtnRight.Enabled = false;
                            this.BtnTop.Enabled = true;
                            this.BtnBottom.Enabled = false;
                        }
                    }
                }
                else
                {
                    this.CmbCopyNo.SelectedIndex = -1;
                    this.ChkEnabled.Checked = false;
                    this.ChkEnabled.Text = "사용않함";
                    this.ChkEnabled.BackColor = Color.DarkRed;
                    this.TxtDescription.Text = string.Empty;
                    this.CmbPolarity.SelectedIndex = -1;
                    this.NudConstThreshold.Controls[1].Text = string.Empty;
                    this.NudHalfPixel.Controls[1].Text = string.Empty;
                    this.ChkPriority.Text = "명암";
                    this.ChkPriority.Checked = false;
                    this.ChkPriority.BackColor = SystemColors.Control;
                    this.BtnLeft.BackColor = SystemColors.Control;
                    this.BtnRight.BackColor = SystemColors.Control;
                    this.BtnTop.BackColor = SystemColors.Control;
                    this.BtnBottom.BackColor = SystemColors.Control;
                    this.BtnInspect.BackColor = SystemColors.Control;

                    this.TxtDescription.Enabled = false;
                    this.CmbPolarity.Enabled = false;
                    this.NudConstThreshold.Enabled = false;
                    this.NudHalfPixel.Enabled = false;
                    this.ChkPriority.Enabled = false;
                    this.BtnLeft.Enabled = false;
                    this.BtnRight.Enabled = false;
                    this.BtnTop.Enabled = false;
                    this.BtnBottom.Enabled = false;
                    this.BtnInspect.Enabled = false;
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


        private void NudNo_ValueChanged(object sender, EventArgs e)
        {
            if (this.m_BPreventEvent == true) return;

            try
            {
                this.CmbNo.Text = this.NudNo.Value.ToString();
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
                this.m_OTool.OCdpImage.DrawingEnabled = false;


                if (this.ChkEnabled.Checked == true)
                {
                    this.m_OTarget.BEnabled = true;
                    this.m_OTool.Activate(this.m_OTarget);

                    this.ChkEnabled.Text = "사용";
                    this.ChkEnabled.BackColor = Color.ForestGreen;
                    this.TxtDescription.Text = this.m_OTarget.StrDescription;
                    this.CmbPolarity.Text = CLanguage.GetCaliperPolarity(this.m_OTarget.EPolarity);
                    this.NudConstThreshold.Value = this.m_OTarget.I32ContrastThreshold;
                    this.NudConstThreshold.Controls[1].Text = this.NudConstThreshold.Value.ToString();
                    this.NudHalfPixel.Value = this.m_OTarget.I32HalfPixel;
                    this.NudHalfPixel.Controls[1].Text = this.NudHalfPixel.Value.ToString();
                    this.ChkPriority.Text = CLanguage.GetCaliperPriority(this.m_OTarget.EPriority);
                    this.ChkPriority.Checked = (this.m_OTarget.EPriority == ECALIPER_PRIORITY.MostPosition);
                    this.ChkPriority.BackColor = Color.SteelBlue;
                    this.BtnInspect.BackColor = Color.SteelBlue;
                    this.TxtDescription.Enabled = true;
                    this.CmbPolarity.Enabled = true;
                    this.NudConstThreshold.Enabled = true;
                    this.NudHalfPixel.Enabled = true;
                    this.ChkPriority.Enabled = true;
                    this.BtnInspect.Enabled = true;

                    if (this.m_OTarget.EKind == EFOLLOW.MD)
                    {
                        if (this.m_OTarget.OROI.F64Rotation == -180F)
                        {
                            this.BtnLeft.BackColor = Color.ForestGreen;
                            this.BtnRight.BackColor = Color.SteelBlue;
                            this.BtnTop.BackColor = SystemColors.Control;
                            this.BtnBottom.BackColor = SystemColors.Control;

                            this.BtnLeft.Enabled = false;
                            this.BtnRight.Enabled = true;
                            this.BtnTop.Enabled = false;
                            this.BtnBottom.Enabled = false;
                        }
                        else
                        {
                            this.BtnLeft.BackColor = Color.SteelBlue;
                            this.BtnRight.BackColor = Color.ForestGreen;
                            this.BtnTop.BackColor = SystemColors.Control;
                            this.BtnBottom.BackColor = SystemColors.Control;

                            this.BtnLeft.Enabled = true;
                            this.BtnRight.Enabled = false;
                            this.BtnTop.Enabled = false;
                            this.BtnBottom.Enabled = false;
                        }
                    }
                    else
                    {
                        if (this.m_OTarget.OROI.F64Rotation == -90F)
                        {
                            this.BtnLeft.BackColor = SystemColors.Control;
                            this.BtnRight.BackColor = SystemColors.Control;
                            this.BtnTop.BackColor = Color.ForestGreen;
                            this.BtnBottom.BackColor = Color.SteelBlue;

                            this.BtnLeft.Enabled = false;
                            this.BtnRight.Enabled = false;
                            this.BtnTop.Enabled = false;
                            this.BtnBottom.Enabled = true;
                        }
                        else
                        {
                            this.BtnLeft.BackColor = SystemColors.Control;
                            this.BtnRight.BackColor = SystemColors.Control;
                            this.BtnTop.BackColor = Color.SteelBlue;
                            this.BtnBottom.BackColor = Color.ForestGreen;

                            this.BtnLeft.Enabled = false;
                            this.BtnRight.Enabled = false;
                            this.BtnTop.Enabled = true;
                            this.BtnBottom.Enabled = false;
                        }
                    }
                }
                else
                {
                    this.m_OTarget.BEnabled = false;
                    this.m_OTarget.OROI.Reflect();
                    this.m_OTarget.F64StandardPosition = 0;


                    this.ChkEnabled.Text = "사용않함";
                    this.ChkEnabled.BackColor = Color.DarkRed;
                    this.TxtDescription.Text = string.Empty;
                    this.CmbPolarity.SelectedIndex = -1;
                    this.NudConstThreshold.Controls[1].Text = string.Empty;
                    this.NudHalfPixel.Controls[1].Text = string.Empty;
                    this.ChkPriority.Text = "명암";
                    this.ChkPriority.Checked = false;
                    this.ChkPriority.BackColor = SystemColors.Control;
                    this.BtnLeft.BackColor = SystemColors.Control;
                    this.BtnRight.BackColor = SystemColors.Control;
                    this.BtnTop.BackColor = SystemColors.Control;
                    this.BtnBottom.BackColor = SystemColors.Control;
                    this.BtnInspect.BackColor = SystemColors.Control;

                    this.TxtDescription.Enabled = false;
                    this.CmbPolarity.Enabled = false;
                    this.NudConstThreshold.Enabled = false;
                    this.NudHalfPixel.Enabled = false;
                    this.ChkPriority.Enabled = false;
                    this.BtnLeft.Enabled = false;
                    this.BtnRight.Enabled = false;
                    this.BtnTop.Enabled = false;
                    this.BtnBottom.Enabled = false;
                    this.BtnInspect.Enabled = false;
                }

                this.m_OTool.Refresh();
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



        private void ChkPriority_CheckedChanged(object sender, EventArgs e)
        {
            if (this.m_BPreventEvent == true) return;

            try
            {
                if (this.ChkPriority.Checked == true)
                {
                    this.ChkPriority.Text = "위치";
                }
                else
                {
                    this.ChkPriority.Text = "명암";
                }
            }
            catch (Exception ex)
            {
                CError.Show(ex);
            }
        }
        #endregion
        #endregion


        #region FUNCTION
        public override void Add()
        {
            try
            {
                this.Display();
            }
            catch (Exception ex)
            {
                CError.Throw(ex);
            }
        }


        public override void Remove()
        {
            try
            {
                if (this.m_OTarget.BEnabled == true)
                {
                    this.m_OTool.DeActivate();
                }

                this.m_OTool.OCdpImage.StaticGraphics.Clear();
            }
            catch (Exception ex)
            {
                CError.Throw(ex);
            }
        }


        public override void Display()
        {
            try
            {
                this.m_BPreventEvent = true;

                this.CmbCopyNo.Items.Clear();

                if (this.m_OTool.ORecipe != null)
                {
                    this.m_OTarget = this.m_OTool.ORecipe.ArrOMD[0];

                    this.CmbCopyNo.Items.Clear();
                    foreach (CFollowRecipe _Item in this.m_OTool.ORecipe.ArrOMD)
                    {
                        if (_Item.I32Index == this.m_OTarget.I32Index) continue;

                        this.CmbCopyNo.Items.Add(_Item.I32Index.ToString());
                    }


                    if (this.m_OTarget.BEnabled == true)
                    {
                        this.m_OTool.Activate(this.m_OTarget);

                        this.CmbKind.Text = (this.m_OTarget.EKind == EFOLLOW.MD) ? "가로 맞춤" : "세로 맞춤";
                        this.CmbNo.Text = this.m_OTarget.I32Index.ToString();
                        this.NudNo.Value = this.m_OTarget.I32Index;
                        this.CmbCopyNo.SelectedIndex = -1;
                        this.BtnCopy.BackColor = Color.SteelBlue;
                        this.ChkEnabled.Checked = true;
                        this.ChkEnabled.Text = "사용";
                        this.ChkEnabled.BackColor = Color.ForestGreen;
                        this.TxtDescription.Text = this.m_OTarget.StrDescription;
                        this.CmbPolarity.Text = CLanguage.GetCaliperPolarity(this.m_OTarget.EPolarity);
                        this.NudConstThreshold.Value = this.m_OTarget.I32ContrastThreshold;
                        this.NudConstThreshold.Controls[1].Text = this.NudConstThreshold.Value.ToString();
                        this.NudHalfPixel.Value = this.m_OTarget.I32HalfPixel;
                        this.NudHalfPixel.Controls[1].Text = this.NudHalfPixel.Value.ToString();
                        this.ChkPriority.Text = CLanguage.GetCaliperPriority(this.m_OTarget.EPriority);
                        this.ChkPriority.Checked = (this.m_OTarget.EPriority == ECALIPER_PRIORITY.MostPosition);
                        this.ChkPriority.BackColor = Color.SteelBlue;
                        this.BtnInspect.BackColor = Color.SteelBlue;

                        this.CmbKind.Enabled = true;
                        this.CmbNo.Enabled = true;
                        this.NudNo.Enabled = true;
                        this.CmbCopyNo.Enabled = true;
                        this.BtnCopy.Enabled = true;
                        this.ChkEnabled.Enabled = true;
                        this.TxtDescription.Enabled = true;
                        this.CmbPolarity.Enabled = true;
                        this.NudConstThreshold.Enabled = true;
                        this.NudHalfPixel.Enabled = true;
                        this.ChkPriority.Enabled = true;
                        this.BtnInspect.Enabled = true;

                        if (this.m_OTarget.EKind == EFOLLOW.MD)
                        {
                            if (this.m_OTarget.OROI.F64Rotation == -180F)
                            {
                                this.BtnLeft.BackColor = Color.ForestGreen;
                                this.BtnRight.BackColor = Color.SteelBlue;
                                this.BtnTop.BackColor = SystemColors.Control;
                                this.BtnBottom.BackColor = SystemColors.Control;

                                this.BtnLeft.Enabled = false;
                                this.BtnRight.Enabled = true;
                                this.BtnTop.Enabled = false;
                                this.BtnBottom.Enabled = false;
                            }
                            else
                            {
                                this.BtnLeft.BackColor = Color.SteelBlue;
                                this.BtnRight.BackColor = Color.ForestGreen;
                                this.BtnTop.BackColor = SystemColors.Control;
                                this.BtnBottom.BackColor = SystemColors.Control;

                                this.BtnLeft.Enabled = true;
                                this.BtnRight.Enabled = false;
                                this.BtnTop.Enabled = false;
                                this.BtnBottom.Enabled = false;
                            }
                        }
                        else
                        {
                            if (this.m_OTarget.OROI.F64Rotation == -90F)
                            {
                                this.BtnLeft.BackColor = SystemColors.Control;
                                this.BtnRight.BackColor = SystemColors.Control;
                                this.BtnTop.BackColor = Color.ForestGreen;
                                this.BtnBottom.BackColor = Color.SteelBlue;

                                this.BtnLeft.Enabled = false;
                                this.BtnRight.Enabled = false;
                                this.BtnTop.Enabled = false;
                                this.BtnBottom.Enabled = true;
                            }
                            else
                            {
                                this.BtnLeft.BackColor = SystemColors.Control;
                                this.BtnRight.BackColor = SystemColors.Control;
                                this.BtnTop.BackColor = Color.SteelBlue;
                                this.BtnBottom.BackColor = Color.ForestGreen;

                                this.BtnLeft.Enabled = false;
                                this.BtnRight.Enabled = false;
                                this.BtnTop.Enabled = true;
                                this.BtnBottom.Enabled = false;
                            }
                        }
                    }
                    else
                    {
                        this.CmbKind.Text = (this.m_OTarget.EKind == EFOLLOW.MD) ? "가로 맞춤" : "세로 맞춤";
                        this.CmbNo.Text = this.m_OTarget.I32Index.ToString();
                        this.NudNo.Value = this.m_OTarget.I32Index;
                        this.CmbCopyNo.SelectedIndex = -1;
                        this.BtnCopy.BackColor = Color.SteelBlue;
                        this.ChkEnabled.Checked = false;
                        this.ChkEnabled.Text = "사용않함";
                        this.ChkEnabled.BackColor = Color.DarkRed;
                        this.TxtDescription.Text = string.Empty;
                        this.CmbPolarity.SelectedIndex = -1;
                        this.NudConstThreshold.Controls[1].Text = string.Empty;
                        this.NudHalfPixel.Controls[1].Text = string.Empty;
                        this.ChkPriority.Text = "명암";
                        this.ChkPriority.Checked = false;
                        this.ChkPriority.BackColor = SystemColors.Control;
                        this.BtnLeft.BackColor = SystemColors.Control;
                        this.BtnRight.BackColor = SystemColors.Control;
                        this.BtnTop.BackColor = SystemColors.Control;
                        this.BtnBottom.BackColor = SystemColors.Control;
                        this.BtnInspect.BackColor = SystemColors.Control;

                        this.CmbKind.Enabled = true;
                        this.CmbNo.Enabled = true;
                        this.NudNo.Enabled = true;
                        this.CmbCopyNo.Enabled = true;
                        this.BtnCopy.Enabled = true;
                        this.ChkEnabled.Enabled = true;
                        this.TxtDescription.Enabled = false;
                        this.CmbPolarity.Enabled = false;
                        this.NudConstThreshold.Enabled = false;
                        this.NudHalfPixel.Enabled = false;
                        this.ChkPriority.Enabled = false;
                        this.BtnLeft.Enabled = false;
                        this.BtnRight.Enabled = false;
                        this.BtnTop.Enabled = false;
                        this.BtnBottom.Enabled = false;
                        this.BtnInspect.Enabled = false;
                    }
                }
                else
                {
                    this.CmbKind.SelectedIndex = -1;
                    this.CmbNo.SelectedIndex = -1;
                    this.CmbCopyNo.SelectedIndex = -1;
                    this.BtnCopy.BackColor = SystemColors.Control;
                    this.ChkEnabled.Checked = false;
                    this.ChkEnabled.Text = "사용않함";
                    this.ChkEnabled.BackColor = SystemColors.Control;
                    this.TxtDescription.Text = string.Empty;
                    this.CmbPolarity.SelectedIndex = -1;
                    this.NudConstThreshold.Controls[1].Text = string.Empty;
                    this.NudHalfPixel.Controls[1].Text = string.Empty;
                    this.ChkPriority.Text = "명암";
                    this.ChkPriority.Checked = false;
                    this.ChkPriority.BackColor = SystemColors.Control;
                    this.BtnLeft.BackColor = SystemColors.Control;
                    this.BtnRight.BackColor = SystemColors.Control;
                    this.BtnTop.BackColor = SystemColors.Control;
                    this.BtnBottom.BackColor = SystemColors.Control;
                    this.BtnInspect.BackColor = SystemColors.Control;

                    this.CmbKind.Enabled = false;
                    this.CmbNo.Enabled = false;
                    this.NudNo.Enabled = false;
                    this.CmbCopyNo.Enabled = false;
                    this.BtnCopy.Enabled = false;
                    this.ChkEnabled.Enabled = false;
                    this.TxtDescription.Enabled = false;
                    this.CmbPolarity.Enabled = false;
                    this.NudConstThreshold.Enabled = false;
                    this.NudHalfPixel.Enabled = false;
                    this.ChkPriority.Enabled = false;
                    this.BtnLeft.Enabled = false;
                    this.BtnRight.Enabled = false;
                    this.BtnTop.Enabled = false;
                    this.BtnBottom.Enabled = false;
                    this.BtnInspect.Enabled = false;
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


        public override bool Apply()
        {
            bool BResult = true;

            try
            {
                if (this.ChkEnabled.Checked == true)
                {
                    this.DoInspect();

                    if (this.m_OTool.OMDCDTool.Results.Count != 1)
                    {
                        CMsgBox.Warning("표준 위치를 찾을 수 없습니다.!");
                        BResult = false;
                    }
                    else
                    {
                        this.m_OTarget.BEnabled = true;
                        this.m_OTarget.StrDescription = this.TxtDescription.Text.Trim();
                        this.m_OTarget.EPolarity = CLanguage.GetCaliperPolarity(this.CmbPolarity.Text);
                        this.m_OTarget.I32ContrastThreshold = Convert.ToInt32(this.NudConstThreshold.Value);
                        this.m_OTarget.I32HalfPixel = Convert.ToInt32(this.NudHalfPixel.Value);
                        this.m_OTarget.EPriority = CLanguage.GetCaliperPriority(this.ChkPriority.Text);
                        this.m_OTarget.F64StandardPosition = (this.m_OTarget.EKind == EFOLLOW.MD) ?
                            this.m_OTool.OMDCDTool.Results[0].Edge0.PositionX : this.m_OTool.OMDCDTool.Results[0].Edge0.PositionY;
                    }
                }
                else
                {
                    this.m_OTarget.BEnabled = false;
                    this.m_OTarget.I32HalfPixel = 2;
                }
            }
            catch (Exception ex)
            {
                CError.Throw(ex);
            }

            return BResult;
        }


        private void DoInspect()
        {
            try
            {
                this.m_OTool.OMDCDTool.InputImage = (CogImage8Grey)this.m_OTool.OCdpImage.Image;
                this.m_OTool.OMDCDTool.Region = (CogRectangleAffine)this.m_OTarget.OROI.OGraphic;
                this.m_OTool.OMDCDTool.RunParams.EdgeMode = CogCaliperEdgeModeConstants.SingleEdge;
                this.m_OTool.OMDCDTool.RunParams.Edge0Polarity = CLanguage.GetCaliperPolarity(this.CmbPolarity.Text);
                this.m_OTool.OMDCDTool.RunParams.ContrastThreshold = Convert.ToInt32(this.NudConstThreshold.Value);
                this.m_OTool.OMDCDTool.RunParams.FilterHalfSizeInPixels = Convert.ToInt32(this.NudHalfPixel.Value);
                if (CLanguage.GetCaliperPriority(this.ChkPriority.Text) == ECALIPER_PRIORITY.MostThreshold)
                {
                    this.m_OTool.OMDCDTool.RunParams.SingleEdgeScorers.Clear();
                    this.m_OTool.OMDCDTool.RunParams.SingleEdgeScorers.Add(new CogCaliperScorerContrast());
                }
                else
                {
                    this.m_OTool.OMDCDTool.RunParams.SingleEdgeScorers.Clear();

                    CogCaliperScorerPositionNeg OScorer = new CogCaliperScorerPositionNeg();
                    OScorer.SetXYParameters(-50000, 50000, 100000, 1, 0);
                    this.m_OTool.OMDCDTool.RunParams.SingleEdgeScorers.Add(OScorer);
                }
                this.m_OTool.OMDCDTool.Run();
            }
            catch (Exception ex)
            {
                CError.Throw(ex);
            }
        }
        #endregion
    }
}
