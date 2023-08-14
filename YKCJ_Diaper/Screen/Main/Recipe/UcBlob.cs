using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Cognex.VisionPro.Display;
using Jhjo.Common;
using Cognex.VisionPro;
using Cognex.VisionPro.Blob;

namespace YKCJ_Diaper
{
    public partial class UcBlob : UcSubRecipe
    {
        #region VARIABLE
        private CRecipeDesignTool m_OTool = null;
        private CBlobRecipe m_OTarget = null;

        private bool m_BPreventEvent = false;
        #endregion


        #region CONSTRUCTOR & DESTRUCTOR
        public UcBlob(CRecipeDesignTool OTool)
        {
            InitializeComponent();

            try
            {
                this.m_OTool = OTool;

                for (int _Index = 1; _Index <= CDiaperFaultRecipe.BLOB_COUNT; _Index++)
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

                if (String.IsNullOrEmpty(this.CmbCopyNo.Text) == true)
                {
                    CMsgBox.Warning("복사 대상 블랍 정보를 선택하여 주세요.");
                    return;
                }


                foreach (CBlobRecipe _Item in this.m_OTool.ORecipe.ArrOBlob)
                {
                    if (_Item.I32Index != Convert.ToInt32(this.CmbCopyNo.Text)) continue;

                    if (_Item.StrAlignmentIndex == this.m_OTarget.I32Index.ToString())
                    {
                        _Item.StrAlignmentTarget = "없음";
                        _Item.StrAlignmentSource = "없음";
                        _Item.StrAlignmentIndex = "없음";
                    }

                    this.m_OTarget.Copy(_Item);
                    break;
                }


                if (this.m_OTarget.BEnabled == true)
                {
                    this.m_OTarget.OROI.Create();
                    this.m_OTool.Activate(this.m_OTarget);

                    this.ChkEnabled.Text = "사용";
                    this.ChkEnabled.Checked = true;
                    this.ChkEnabled.BackColor = Color.ForestGreen;
                    this.TxtDescription.Text = this.m_OTarget.StrDescription;
                    this.CmbPolarity.Text = CLanguage.GetBlobPolarity(this.m_OTarget.EPolarity);
                    this.ChkThresholdKind.Text = CLanguage.GetBlobThreshold(this.m_OTarget.OThreshold.EKind);
                    this.ChkThresholdKind.BackColor = Color.SteelBlue;
                    this.LblTitleThresholdValue.Text = this.m_OTarget.OThreshold.StrValueName;
                    this.NudThresholdValue.Value = this.m_OTarget.OThreshold.I32Value;
                    this.NudThresholdValue.Controls[1].Text = this.NudThresholdValue.Value.ToString();
                    this.NudMinSize.Value = this.m_OTarget.I32MinSize;
                    this.NudMinSize.Controls[1].Text = this.NudMinSize.Value.ToString();
                    this.NudOffset.Value = this.m_OTarget.I32Offset;
                    this.NudOffset.Controls[1].Text = this.NudOffset.Value.ToString();
                    this.CmbIOSignal.Text = (this.m_OTarget.EIOSignal == EIO.NONE) ? CDiaperFaultRecipe.NONE : this.m_OTarget.EIOSignal.ToString();
                    this.CmbROI.Text = this.m_OTarget.OROI.EKind.ToString();
                    this.BtnROIDetail.BackColor = Color.SteelBlue;
                    this.CmbMD.Text = this.m_OTarget.StrMD;
                    this.CmbCD.Text = this.m_OTarget.StrCD;
                    this.CmbAlignmentTarget.Text = this.m_OTarget.StrAlignmentTarget;
                    this.CmbAlignmentIndex.Text = this.m_OTarget.StrAlignmentIndex;
                    this.CmbAlignmentSource.Text = this.m_OTarget.StrAlignmentSource;
                    this.BtnApplyAlignment.BackColor = Color.SteelBlue;
                    this.BtnClearAlignment.BackColor = Color.SteelBlue;

                    this.ChkEnabled.Enabled = true;
                    this.TxtDescription.Enabled = true;
                    this.CmbPolarity.Enabled = true;
                    this.ChkThresholdKind.Enabled = true;
                    this.NudThresholdValue.Enabled = true;
                    this.NudMinSize.Enabled = true;
                    this.NudOffset.Enabled = true;
                    this.CmbIOSignal.Enabled = true;
                    this.CmbROI.Enabled = true;
                    this.BtnROIDetail.Enabled = true;
                    this.CmbMD.Enabled = true;
                    this.CmbCD.Enabled = true;
                    this.CmbAlignmentTarget.Enabled = true;
                    this.CmbAlignmentIndex.Enabled = true;
                    this.CmbAlignmentSource.Enabled = true;
                    this.BtnApplyAlignment.Enabled = true;
                    this.BtnClearAlignment.Enabled = true;
                }
                else
                {
                    this.ChkEnabled.Text = "사용않함";
                    this.ChkEnabled.Checked = false;
                    this.ChkEnabled.BackColor = Color.DarkRed;
                    this.TxtDescription.Text = string.Empty;
                    this.CmbPolarity.SelectedIndex = -1;
                    this.ChkThresholdKind.Text = "이미지 명암";
                    this.ChkThresholdKind.BackColor = SystemColors.Control;
                    this.LblTitleThresholdValue.Text = "이미지 수";
                    this.NudThresholdValue.Controls[1].Text = string.Empty;
                    this.NudMinSize.Controls[1].Text = string.Empty;
                    this.NudOffset.Controls[1].Text = string.Empty;
                    this.CmbIOSignal.SelectedIndex = -1;
                    this.CmbROI.SelectedIndex = -1;
                    this.BtnROIDetail.BackColor = SystemColors.Control;
                    this.CmbMD.SelectedIndex = -1;
                    this.CmbCD.SelectedIndex = -1;
                    this.CmbAlignmentTarget.SelectedIndex = -1;
                    this.CmbAlignmentIndex.SelectedIndex = -1;
                    this.CmbAlignmentSource.SelectedIndex = -1;
                    this.BtnApplyAlignment.BackColor = SystemColors.Control;
                    this.BtnClearAlignment.BackColor = SystemColors.Control;

                    this.ChkEnabled.Enabled = true;
                    this.TxtDescription.Enabled = false;
                    this.CmbPolarity.Enabled = false;
                    this.ChkThresholdKind.Enabled = false;
                    this.NudThresholdValue.Enabled = false;
                    this.NudMinSize.Enabled = false;
                    this.NudOffset.Enabled = false;
                    this.CmbIOSignal.Enabled = false;
                    this.CmbROI.Enabled = false;
                    this.BtnROIDetail.Enabled = false;
                    this.CmbMD.Enabled = false;
                    this.CmbCD.Enabled = false;
                    this.CmbAlignmentTarget.Enabled = false;
                    this.CmbAlignmentIndex.Enabled = false;
                    this.CmbAlignmentSource.Enabled = false;
                    this.BtnApplyAlignment.Enabled = false;
                    this.BtnClearAlignment.Enabled = false;
                }

                this.m_OTool.Refresh();
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


        private void BtnROIDetail_Click(object sender, EventArgs e)
        {
            try
            {
                CROIWindow OWindow = CROIFactory.GetROIWindow(this.m_OTarget.OROI.EKind);
                OWindow.OTool = this.m_OTool;
                OWindow.ORecipe = this.m_OTarget;
                OWindow.ShowDialog();

                this.CmbAlignmentTarget.Text = this.m_OTarget.StrAlignmentTarget;
                this.CmbAlignmentIndex.Text = this.m_OTarget.StrAlignmentIndex;
                this.CmbAlignmentSource.Text = this.m_OTarget.StrAlignmentSource;
            }
            catch (Exception ex)
            {
                CError.Show(ex);
            }
        }


        private void BtnApplyAlignment_Click(object sender, EventArgs e)
        {
            try
            {
                this.m_OTool.OCdpImage.DrawingEnabled = false;

                if ((this.CmbAlignmentTarget.Text == CDiaperFaultRecipe.NONE) ||
                    (this.CmbAlignmentIndex.Text == CDiaperFaultRecipe.NONE) ||
                    (this.CmbAlignmentSource.Text == CDiaperFaultRecipe.NONE))
                {
                    CMsgBox.Warning("정렬 정보를 정확하게 입력하여 주세요.!");
                    return;
                }
                else
                {
                    if ((this.CmbAlignmentTarget.Text == "왼쪽") || (this.CmbAlignmentTarget.Text == "오른쪽"))
                    {
                        if ((this.CmbAlignmentSource.Text == "왼쪽") || (this.CmbAlignmentSource.Text == "오른쪽"))
                        {
                            this.m_OTarget.StrAlignmentTarget = this.CmbAlignmentTarget.Text;
                            this.m_OTarget.StrAlignmentIndex = this.CmbAlignmentIndex.Text;
                            this.m_OTarget.StrAlignmentSource = this.CmbAlignmentSource.Text;


                            foreach (CBlobRecipe _Item in this.m_OTool.ORecipe.ArrOBlob)
                            {
                                if (_Item.I32Index != Convert.ToInt32(this.m_OTarget.StrAlignmentIndex)) continue;

                                if (_Item.StrAlignmentIndex == this.m_OTarget.I32Index.ToString())
                                {
                                    _Item.StrAlignmentTarget = CDiaperFaultRecipe.NONE;
                                    _Item.StrAlignmentIndex = CDiaperFaultRecipe.NONE;
                                    _Item.StrAlignmentSource = CDiaperFaultRecipe.NONE;
                                }

                                this.m_OTool.DoAlignment(_Item, _Item.OROI.OBound);
                                break;
                            }
                        }
                        else CMsgBox.Warning("정렬 정보를 정확하게 입력하여 주세요.");
                    }
                    else if ((this.CmbAlignmentTarget.Text == "상단") || (this.CmbAlignmentTarget.Text == "하단"))
                    {
                        if ((this.CmbAlignmentSource.Text == "상단") || (this.CmbAlignmentSource.Text == "하단"))
                        {
                            this.m_OTarget.StrAlignmentTarget = this.CmbAlignmentTarget.Text;
                            this.m_OTarget.StrAlignmentIndex = this.CmbAlignmentIndex.Text;
                            this.m_OTarget.StrAlignmentSource = this.CmbAlignmentSource.Text;

                            foreach (CBlobRecipe _Item in this.m_OTool.ORecipe.ArrOBlob)
                            {
                                if (_Item.I32Index != Convert.ToInt32(this.m_OTarget.StrAlignmentIndex)) continue;

                                if (_Item.StrAlignmentIndex == this.m_OTarget.I32Index.ToString())
                                {
                                    _Item.StrAlignmentTarget = CDiaperFaultRecipe.NONE;
                                    _Item.StrAlignmentIndex = CDiaperFaultRecipe.NONE;
                                    _Item.StrAlignmentSource = CDiaperFaultRecipe.NONE;
                                }

                                this.m_OTool.DoAlignment(_Item, _Item.OROI.OBound);
                                break;
                            }
                        }
                        else CMsgBox.Warning("정렬 정보를 정확하게 입력하여 주세요.");
                    }
                }
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


        private void BtnClearAlignment_Click(object sender, EventArgs e)
        {
            try
            {
                this.CmbAlignmentTarget.Text = CDiaperFaultRecipe.NONE;
                this.CmbAlignmentIndex.Text = CDiaperFaultRecipe.NONE;
                this.CmbAlignmentSource.Text = CDiaperFaultRecipe.NONE;

                this.m_OTarget.StrAlignmentTarget = CDiaperFaultRecipe.NONE;
                this.m_OTarget.StrAlignmentIndex = CDiaperFaultRecipe.NONE;
                this.m_OTarget.StrAlignmentSource = CDiaperFaultRecipe.NONE;
            }
            catch (Exception ex)
            {
                CError.Show(ex);
            }
        }
        #endregion


        #region ETC EVENT
        private void CmbNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.m_BPreventEvent == true) return;

            try
            {
                this.m_BPreventEvent = true;
                this.m_OTool.OCdpImage.DrawingEnabled = false;

                if (this.ChkEnabled.Checked == true)
                {
                    this.m_OTarget.OROI.Reflect();
                    this.m_OTool.DeActivate();

                    this.m_OTarget.BEnabled = true;
                    this.m_OTarget.StrDescription = this.TxtDescription.Text.Trim();
                    this.m_OTarget.EPolarity = CLanguage.GetBlobPolarity(this.CmbPolarity.Text);
                    this.m_OTarget.OThreshold = CThresholdFactory.GetThreshold(CLanguage.GetBlobThreshold(this.ChkThresholdKind.Text));
                    this.m_OTarget.OThreshold.I32Value = Convert.ToInt32(this.NudThresholdValue.Value);
                    this.m_OTarget.I32MinSize = Convert.ToInt32(this.NudMinSize.Value);
                    this.m_OTarget.I32Offset = Convert.ToInt32(this.NudOffset.Value);
                    this.m_OTarget.EIOSignal = (this.CmbIOSignal.Text == CDiaperFaultRecipe.NONE) ? EIO.NONE : (EIO)Enum.Parse(typeof(EIO), this.CmbIOSignal.Text);
                    this.m_OTarget.StrMD = this.CmbMD.Text;
                    this.m_OTarget.StrCD = this.CmbCD.Text;
                }
                else
                {
                    this.m_OTarget.BEnabled = false;
                }


                int I32Index = Convert.ToInt32(this.CmbNo.Text);
                foreach (CBlobRecipe _Item in this.m_OTool.ORecipe.ArrOBlob)
                {
                    if (_Item.I32Index != I32Index) continue;

                    this.m_OTarget = _Item;
                    this.NudNo.Value = I32Index;
                    break;
                }

                this.CmbCopyNo.Items.Clear();
                foreach (CBlobRecipe _Item in this.m_OTool.ORecipe.ArrOBlob)
                {
                    if (_Item.I32Index == this.m_OTarget.I32Index) continue;

                    this.CmbCopyNo.Items.Add(_Item.I32Index.ToString());
                }

                this.CmbAlignmentIndex.Items.Clear();
                this.CmbAlignmentIndex.Items.Add("없음");
                foreach (CBlobRecipe _Item in this.m_OTool.ORecipe.ArrOBlob)
                {
                    if (_Item.BEnabled == false) continue;
                    if (_Item.I32Index == this.m_OTarget.I32Index) continue;

                    this.CmbAlignmentIndex.Items.Add(_Item.I32Index);
                }


                if (this.m_OTarget.BEnabled == true)
                {
                    this.m_OTool.Activate(this.m_OTarget);

                    this.CmbCopyNo.SelectedIndex = -1;
                    this.BtnCopy.BackColor = Color.SteelBlue;
                    this.ChkEnabled.Checked = true;
                    this.ChkEnabled.Text = "사용";
                    this.ChkEnabled.BackColor = Color.ForestGreen;
                    this.TxtDescription.Text = this.m_OTarget.StrDescription;
                    this.CmbPolarity.Text = CLanguage.GetBlobPolarity(this.m_OTarget.EPolarity);
                    this.ChkThresholdKind.Text = CLanguage.GetBlobThreshold(this.m_OTarget.OThreshold.EKind);
                    this.ChkThresholdKind.BackColor = Color.SteelBlue;
                    this.LblTitleThresholdValue.Text = this.m_OTarget.OThreshold.StrValueName;
                    this.NudThresholdValue.Value = this.m_OTarget.OThreshold.I32Value;
                    this.NudThresholdValue.Controls[1].Text = this.NudThresholdValue.Value.ToString();
                    this.NudMinSize.Value = this.m_OTarget.I32MinSize;
                    this.NudMinSize.Controls[1].Text = this.NudMinSize.Value.ToString();
                    this.NudOffset.Value = this.m_OTarget.I32Offset;
                    this.NudOffset.Controls[1].Text = this.NudOffset.Value.ToString();
                    this.CmbIOSignal.Text = (this.m_OTarget.EIOSignal == EIO.NONE) ? CDiaperFaultRecipe.NONE : this.m_OTarget.EIOSignal.ToString();
                    this.CmbROI.Text = this.m_OTarget.OROI.EKind.ToString();
                    this.BtnROIDetail.BackColor = Color.SteelBlue;
                    this.CmbMD.Text = this.m_OTarget.StrMD;
                    this.CmbCD.Text = this.m_OTarget.StrCD;
                    this.CmbAlignmentTarget.Text = this.m_OTarget.StrAlignmentTarget;
                    this.CmbAlignmentIndex.Text = this.m_OTarget.StrAlignmentIndex;
                    this.CmbAlignmentSource.Text = this.m_OTarget.StrAlignmentSource;
                    this.BtnApplyAlignment.BackColor = Color.SteelBlue;
                    this.BtnClearAlignment.BackColor = Color.SteelBlue;

                    this.ChkEnabled.Enabled = true;
                    this.TxtDescription.Enabled = true;
                    this.CmbPolarity.Enabled = true;
                    this.ChkThresholdKind.Enabled = true;
                    this.NudThresholdValue.Enabled = true;
                    this.NudMinSize.Enabled = true;
                    this.NudOffset.Enabled = true;
                    this.CmbIOSignal.Enabled = true;
                    this.CmbROI.Enabled = true;
                    this.BtnROIDetail.Enabled = true;
                    this.CmbMD.Enabled = true;
                    this.CmbCD.Enabled = true;
                    this.CmbAlignmentTarget.Enabled = true;
                    this.CmbAlignmentIndex.Enabled = true;
                    this.CmbAlignmentSource.Enabled = true;
                    this.BtnApplyAlignment.Enabled = true;
                    this.BtnClearAlignment.Enabled = true;
                }
                else
                {
                    this.CmbCopyNo.SelectedIndex = -1;
                    this.BtnCopy.BackColor = Color.SteelBlue;
                    this.ChkEnabled.Checked = false;
                    this.ChkEnabled.Text = "사용않함";
                    this.ChkEnabled.BackColor = Color.DarkRed;
                    this.TxtDescription.Text = string.Empty;
                    this.CmbPolarity.SelectedIndex = -1;
                    this.ChkThresholdKind.Text = "이미지 명암";
                    this.ChkThresholdKind.BackColor = SystemColors.Control;
                    this.LblTitleThresholdValue.Text = "이미지 수";
                    this.NudThresholdValue.Controls[1].Text = string.Empty;
                    this.NudMinSize.Controls[1].Text = string.Empty;
                    this.NudOffset.Controls[1].Text = string.Empty;
                    this.CmbIOSignal.SelectedIndex = -1;
                    this.CmbROI.SelectedIndex = -1;
                    this.BtnROIDetail.BackColor = SystemColors.Control;
                    this.CmbMD.SelectedIndex = -1;
                    this.CmbCD.SelectedIndex = -1;
                    this.CmbAlignmentTarget.SelectedIndex = -1;
                    this.CmbAlignmentIndex.SelectedIndex = -1;
                    this.CmbAlignmentSource.SelectedIndex = -1;
                    this.BtnApplyAlignment.BackColor = SystemColors.Control;
                    this.BtnClearAlignment.BackColor = SystemColors.Control;

                    this.ChkEnabled.Enabled = true;
                    this.TxtDescription.Enabled = false;
                    this.CmbPolarity.Enabled = false;
                    this.ChkThresholdKind.Enabled = false;
                    this.NudThresholdValue.Enabled = false;
                    this.NudMinSize.Enabled = false;
                    this.NudOffset.Enabled = false;
                    this.CmbIOSignal.Enabled = false;
                    this.CmbROI.Enabled = false;
                    this.BtnROIDetail.Enabled = false;
                    this.CmbMD.Enabled = false;
                    this.CmbCD.Enabled = false;
                    this.CmbAlignmentTarget.Enabled = false;
                    this.CmbAlignmentIndex.Enabled = false;
                    this.CmbAlignmentSource.Enabled = false;
                    this.BtnApplyAlignment.Enabled = false;
                    this.BtnClearAlignment.Enabled = false;
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
                    //this.m_OTarget.OROI.Create();
                    this.m_OTool.Activate(this.m_OTarget);


                    this.ChkEnabled.Text = "사용";
                    this.ChkEnabled.BackColor = Color.ForestGreen;
                    this.TxtDescription.Text = this.m_OTarget.StrDescription;
                    this.CmbPolarity.Text = CLanguage.GetBlobPolarity(this.m_OTarget.EPolarity);
                    this.ChkThresholdKind.Text = CLanguage.GetBlobThreshold(this.m_OTarget.OThreshold.EKind);
                    this.ChkThresholdKind.BackColor = Color.SteelBlue;
                    this.LblTitleThresholdValue.Text = this.m_OTarget.OThreshold.StrValueName;
                    this.NudThresholdValue.Value = this.m_OTarget.OThreshold.I32Value;
                    this.NudThresholdValue.Controls[1].Text = this.NudThresholdValue.Value.ToString();
                    this.NudMinSize.Value = this.m_OTarget.I32MinSize;
                    this.NudMinSize.Controls[1].Text = this.NudMinSize.Value.ToString();
                    this.NudOffset.Value = this.m_OTarget.I32Offset;
                    this.NudOffset.Controls[1].Text = this.NudOffset.Value.ToString();
                    this.CmbIOSignal.Text = CDiaperFaultRecipe.NONE;
                    this.CmbROI.Text = this.m_OTarget.OROI.EKind.ToString();
                    this.BtnROIDetail.BackColor = Color.SteelBlue;
                    this.CmbMD.Text = this.m_OTarget.StrMD;
                    this.CmbCD.Text = this.m_OTarget.StrCD;
                    this.CmbAlignmentTarget.Text = this.m_OTarget.StrAlignmentTarget;
                    this.CmbAlignmentIndex.Text = this.m_OTarget.StrAlignmentIndex;
                    this.CmbAlignmentSource.Text = this.m_OTarget.StrAlignmentSource;
                    this.BtnApplyAlignment.BackColor = Color.SteelBlue;
                    this.BtnClearAlignment.BackColor = Color.SteelBlue;

                    this.TxtDescription.Enabled = true;
                    this.CmbPolarity.Enabled = true;
                    this.ChkThresholdKind.Enabled = true;
                    this.NudThresholdValue.Enabled = true;
                    this.NudMinSize.Enabled = true;
                    this.NudOffset.Enabled = true;
                    this.CmbIOSignal.Enabled = true;
                    this.CmbROI.Enabled = true;
                    this.BtnROIDetail.Enabled = true;
                    this.CmbMD.Enabled = true;
                    this.CmbCD.Enabled = true;
                    this.CmbAlignmentTarget.Enabled = true;
                    this.CmbAlignmentIndex.Enabled = true;
                    this.CmbAlignmentSource.Enabled = true;
                    this.BtnApplyAlignment.Enabled = true;
                    this.BtnClearAlignment.Enabled = true;
                }
                else
                {
                    this.m_OTarget.OROI.Reflect();
                    this.m_OTarget.BEnabled = false;
                    this.m_OTarget.StrDescription = this.TxtDescription.Text.Trim();
                    this.m_OTarget.EPolarity = CLanguage.GetBlobPolarity(this.CmbPolarity.Text);
                    this.m_OTarget.OThreshold = CThresholdFactory.GetThreshold(CLanguage.GetBlobThreshold(this.ChkThresholdKind.Text));
                    this.m_OTarget.OThreshold.I32Value = Convert.ToInt32(this.NudThresholdValue.Value);
                    this.m_OTarget.I32MinSize = Convert.ToInt32(this.NudMinSize.Value);
                    this.m_OTarget.I32Offset = Convert.ToInt32(this.NudOffset.Value);
                    this.m_OTarget.EIOSignal = (this.CmbIOSignal.Text == CDiaperFaultRecipe.NONE) ? EIO.NONE : (EIO)Enum.Parse(typeof(EIO), this.CmbIOSignal.Text);
                    this.m_OTarget.StrMD = CDiaperFaultRecipe.NONE;
                    this.m_OTarget.StrCD = CDiaperFaultRecipe.NONE;
                    this.m_OTarget.StrAlignmentTarget = CDiaperFaultRecipe.NONE;
                    this.m_OTarget.StrAlignmentIndex = CDiaperFaultRecipe.NONE;
                    this.m_OTarget.StrAlignmentSource = CDiaperFaultRecipe.NONE;

                    foreach (CBlobRecipe _Item in this.m_OTool.ORecipe.ArrOBlob)
                    {
                        if (_Item.StrAlignmentIndex != this.m_OTarget.I32Index.ToString()) continue;

                        _Item.StrAlignmentTarget = CDiaperFaultRecipe.NONE;
                        _Item.StrAlignmentIndex = CDiaperFaultRecipe.NONE;
                        _Item.StrAlignmentSource = CDiaperFaultRecipe.NONE;
                    }


                    this.ChkEnabled.Text = "사용않함";
                    this.ChkEnabled.BackColor = Color.DarkRed;
                    this.TxtDescription.Text = string.Empty;
                    this.CmbPolarity.SelectedIndex = -1;
                    this.ChkThresholdKind.Text = "이미지 명암";
                    this.ChkThresholdKind.BackColor = SystemColors.Control;
                    this.LblTitleThresholdValue.Text = "이미지 수";
                    this.NudThresholdValue.Controls[1].Text = string.Empty;
                    this.NudMinSize.Controls[1].Text = string.Empty;
                    this.NudOffset.Controls[1].Text = string.Empty;
                    this.CmbIOSignal.SelectedIndex = -1;
                    this.CmbROI.SelectedIndex = -1;
                    this.BtnROIDetail.BackColor = SystemColors.Control;
                    this.CmbMD.SelectedIndex = -1;
                    this.CmbCD.SelectedIndex = -1;
                    this.CmbAlignmentTarget.SelectedIndex = -1;
                    this.CmbAlignmentIndex.SelectedIndex = -1;
                    this.CmbAlignmentSource.SelectedIndex = -1;
                    this.BtnApplyAlignment.BackColor = SystemColors.Control;
                    this.BtnClearAlignment.BackColor = SystemColors.Control;

                    this.TxtDescription.Enabled = false;
                    this.CmbPolarity.Enabled = false;
                    this.ChkThresholdKind.Enabled = false;
                    this.NudThresholdValue.Enabled = false;
                    this.NudMinSize.Enabled = false;
                    this.NudOffset.Enabled = false;
                    this.CmbIOSignal.Enabled = false;
                    this.CmbROI.Enabled = false;
                    this.BtnROIDetail.Enabled = false;
                    this.CmbMD.Enabled = false;
                    this.CmbCD.Enabled = false;
                    this.CmbAlignmentTarget.Enabled = false;
                    this.CmbAlignmentIndex.Enabled = false;
                    this.CmbAlignmentSource.Enabled = false;
                    this.BtnApplyAlignment.Enabled = false;
                    this.BtnClearAlignment.Enabled = false;
                }

                this.m_OTool.Refresh();
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


        private void ChkThresholdKind_CheckedChanged(object sender, EventArgs e)
        {
            if (this.m_BPreventEvent == true) return;

            try
            {
                if (CLanguage.GetBlobThreshold(this.ChkThresholdKind.Text) == EBLOB_THRESHOLD.Fixed)
                {
                    this.ChkThresholdKind.Text = "이미지 명암";
                    this.LblTitleThresholdValue.Text = "이미지 수";
                    this.NudThresholdValue.Value = 30;
                }
                else
                {
                    this.ChkThresholdKind.Text = "고정";
                    this.LblTitleThresholdValue.Text = "명암";
                    this.NudThresholdValue.Value = 100;
                }
            }
            catch (Exception ex)
            {
                CError.Show(ex);
            }
        }


        private void CmbROI_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.m_BPreventEvent == true) return;

            try
            {
                this.m_BPreventEvent = true;
                this.m_OTool.OCdpImage.DrawingEnabled = false;

                this.m_OTarget.OROI = CROIFactory.GetROI(this.CmbROI.Text);
                this.m_OTarget.OROI.Create();
                this.m_OTool.Activate(this.m_OTarget);

                this.m_OTarget.StrAlignmentTarget = CDiaperFaultRecipe.NONE;
                this.m_OTarget.StrAlignmentIndex = CDiaperFaultRecipe.NONE;
                this.m_OTarget.StrAlignmentSource = CDiaperFaultRecipe.NONE;

                this.CmbAlignmentTarget.Text = this.m_OTarget.StrAlignmentTarget;
                this.CmbAlignmentIndex.Text = this.m_OTarget.StrAlignmentIndex;
                this.CmbAlignmentSource.Text = this.m_OTarget.StrAlignmentSource;

                this.m_OTool.Refresh();
                this.m_OTool.DoAlignment(this.m_OTarget, this.m_OTarget.OROI.OBound);
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
                this.CmbMD.Items.Clear();
                this.CmbCD.Items.Clear();
                this.CmbAlignmentIndex.Items.Clear();


                if (this.m_OTool.ORecipe != null)
                {
                    this.m_OTarget = this.m_OTool.ORecipe.ArrOBlob[0];

                    foreach (CBlobRecipe _Item in this.m_OTool.ORecipe.ArrOBlob)
                    {
                        if (_Item.I32Index == this.m_OTarget.I32Index) continue;

                        this.CmbCopyNo.Items.Add(_Item.I32Index.ToString());
                    }

                    this.CmbMD.Items.Add("없음");
                    foreach (CFollowRecipe _Item in this.m_OTool.ORecipe.ArrOMD)
                    {
                        if (_Item.BEnabled == false) continue;

                        this.CmbMD.Items.Add(_Item.I32Index);
                    }

                    this.CmbCD.Items.Add("없음");
                    foreach (CFollowRecipe _Item in this.m_OTool.ORecipe.ArrOCD)
                    {
                        if (_Item.BEnabled == false) continue;

                        this.CmbCD.Items.Add(_Item.I32Index);
                    }

                    this.CmbAlignmentIndex.Items.Add("없음");
                    foreach (CBlobRecipe _Item in this.m_OTool.ORecipe.ArrOBlob)
                    {
                        if (_Item.BEnabled == false) continue;
                        if (_Item.I32Index == this.m_OTarget.I32Index) continue;

                        this.CmbAlignmentIndex.Items.Add(_Item.I32Index);
                    }


                    if (this.m_OTarget.BEnabled == true)
                    {
                        this.m_OTool.Activate(this.m_OTarget);

                        this.CmbNo.Text = this.m_OTarget.I32Index.ToString();
                        this.NudNo.Value = this.m_OTarget.I32Index;
                        this.CmbCopyNo.SelectedIndex = -1;
                        this.BtnCopy.BackColor = Color.SteelBlue;
                        this.ChkEnabled.Checked = true;
                        this.ChkEnabled.Text = "사용";
                        this.ChkEnabled.BackColor = Color.ForestGreen;
                        this.TxtDescription.Text = this.m_OTarget.StrDescription;
                        this.CmbPolarity.Text = CLanguage.GetBlobPolarity(this.m_OTarget.EPolarity);
                        this.ChkThresholdKind.Text = CLanguage.GetBlobThreshold(this.m_OTarget.OThreshold.EKind);
                        this.ChkThresholdKind.BackColor = Color.SteelBlue;
                        this.LblTitleThresholdValue.Text = this.m_OTarget.OThreshold.StrValueName;
                        this.NudThresholdValue.Value = this.m_OTarget.OThreshold.I32Value;
                        this.NudThresholdValue.Controls[1].Text = this.NudThresholdValue.Value.ToString();
                        this.NudMinSize.Value = this.m_OTarget.I32MinSize;
                        this.NudMinSize.Controls[1].Text = this.NudMinSize.Value.ToString();
                        this.NudOffset.Value = this.m_OTarget.I32Offset;
                        this.NudOffset.Controls[1].Text = this.NudOffset.Value.ToString();
                        this.CmbIOSignal.Text = (this.m_OTarget.EIOSignal == EIO.NONE) ? CDiaperFaultRecipe.NONE : this.m_OTarget.EIOSignal.ToString();
                        this.CmbROI.Text = this.m_OTarget.OROI.EKind.ToString();
                        this.BtnROIDetail.BackColor = Color.SteelBlue;
                        this.CmbMD.Text = this.m_OTarget.StrMD;
                        this.CmbCD.Text = this.m_OTarget.StrCD;
                        this.CmbAlignmentTarget.Text = this.m_OTarget.StrAlignmentTarget;
                        this.CmbAlignmentIndex.Text = this.m_OTarget.StrAlignmentIndex;
                        this.CmbAlignmentSource.Text = this.m_OTarget.StrAlignmentSource;
                        this.BtnApplyAlignment.BackColor = Color.SteelBlue;
                        this.BtnClearAlignment.BackColor = Color.SteelBlue;

                        this.CmbNo.Enabled = true;
                        this.NudNo.Enabled = true;
                        this.CmbCopyNo.Enabled = true;
                        this.BtnCopy.Enabled = true;
                        this.ChkEnabled.Enabled = true;
                        this.TxtDescription.Enabled = true;
                        this.CmbPolarity.Enabled = true;
                        this.ChkThresholdKind.Enabled = true;
                        this.NudThresholdValue.Enabled = true;
                        this.NudMinSize.Enabled = true;
                        this.NudOffset.Enabled = true;
                        this.CmbIOSignal.Enabled = true;
                        this.CmbROI.Enabled = true;
                        this.BtnROIDetail.Enabled = true;
                        this.CmbMD.Enabled = true;
                        this.CmbCD.Enabled = true;
                        this.CmbAlignmentTarget.Enabled = true;
                        this.CmbAlignmentIndex.Enabled = true;
                        this.CmbAlignmentSource.Enabled = true;
                        this.BtnApplyAlignment.Enabled = true;
                        this.BtnClearAlignment.Enabled = true;
                    }
                    else
                    {
                        this.CmbNo.Text = this.m_OTarget.I32Index.ToString();
                        this.NudNo.Value = this.m_OTarget.I32Index;
                        this.CmbCopyNo.SelectedIndex = -1;
                        this.BtnCopy.BackColor = Color.SteelBlue;
                        this.ChkEnabled.Checked = false;
                        this.ChkEnabled.Text = "사용않함";
                        this.ChkEnabled.BackColor = Color.DarkRed;
                        this.TxtDescription.Text = string.Empty;
                        this.CmbPolarity.SelectedIndex = -1;
                        this.ChkThresholdKind.Text = "이미지 명암";
                        this.ChkThresholdKind.BackColor = SystemColors.Control;
                        this.LblTitleThresholdValue.Text = "이미지 수";
                        this.NudThresholdValue.Controls[1].Text = string.Empty;
                        this.NudMinSize.Controls[1].Text = string.Empty;
                        this.NudOffset.Controls[1].Text = string.Empty;
                        this.CmbIOSignal.SelectedIndex = -1;
                        this.CmbROI.SelectedIndex = -1;
                        this.BtnROIDetail.BackColor = SystemColors.Control;
                        this.CmbMD.SelectedIndex = -1;
                        this.CmbCD.SelectedIndex = -1;
                        this.CmbAlignmentTarget.SelectedIndex = -1;
                        this.CmbAlignmentIndex.SelectedIndex = -1;
                        this.CmbAlignmentSource.SelectedIndex = -1;
                        this.BtnApplyAlignment.BackColor = SystemColors.Control;
                        this.BtnClearAlignment.BackColor = SystemColors.Control;

                        this.CmbNo.Enabled = true;
                        this.NudNo.Enabled = true;
                        this.CmbCopyNo.Enabled = true;
                        this.BtnCopy.Enabled = true;
                        this.ChkEnabled.Enabled = true;
                        this.TxtDescription.Enabled = false;
                        this.CmbPolarity.Enabled = false;
                        this.ChkThresholdKind.Enabled = false;
                        this.NudThresholdValue.Enabled = false;
                        this.NudMinSize.Enabled = false;
                        this.NudOffset.Enabled = false;
                        this.CmbIOSignal.Enabled = false;
                        this.CmbROI.Enabled = false;
                        this.BtnROIDetail.Enabled = false;
                        this.CmbMD.Enabled = false;
                        this.CmbCD.Enabled = false;
                        this.CmbAlignmentTarget.Enabled = false;
                        this.CmbAlignmentIndex.Enabled = false;
                        this.CmbAlignmentSource.Enabled = false;
                        this.BtnApplyAlignment.Enabled = false;
                        this.BtnClearAlignment.Enabled = false;
                    }
                }
                else
                {
                    this.CmbNo.SelectedIndex = -1;
                    this.CmbCopyNo.SelectedIndex = -1;
                    this.BtnCopy.BackColor = SystemColors.Control;
                    this.ChkEnabled.Checked = false;
                    this.ChkEnabled.Text = "사용않함";
                    this.ChkEnabled.BackColor = SystemColors.Control;
                    this.TxtDescription.Text = string.Empty;
                    this.CmbPolarity.SelectedIndex = -1;
                    this.ChkThresholdKind.Text = "이미지 명암";
                    this.ChkThresholdKind.BackColor = SystemColors.Control;
                    this.LblTitleThresholdValue.Text = "이미지 수";
                    this.NudThresholdValue.Controls[1].Text = string.Empty;
                    this.NudMinSize.Controls[1].Text = string.Empty;
                    this.NudOffset.Controls[1].Text = string.Empty;
                    this.CmbIOSignal.SelectedIndex = -1;
                    this.CmbROI.SelectedIndex = -1;
                    this.BtnROIDetail.BackColor = SystemColors.Control;
                    this.CmbMD.SelectedIndex = -1;
                    this.CmbCD.SelectedIndex = -1;
                    this.CmbAlignmentTarget.SelectedIndex = -1;
                    this.CmbAlignmentIndex.SelectedIndex = -1;
                    this.CmbAlignmentSource.SelectedIndex = -1;
                    this.BtnApplyAlignment.BackColor = SystemColors.Control;
                    this.BtnClearAlignment.BackColor = SystemColors.Control;

                    this.CmbNo.Enabled = false;
                    this.NudNo.Enabled = false;
                    this.CmbCopyNo.Enabled = false;
                    this.BtnCopy.Enabled = false;
                    this.ChkEnabled.Enabled = false;
                    this.TxtDescription.Enabled = false;
                    this.CmbPolarity.Enabled = false;
                    this.ChkThresholdKind.Enabled = false;
                    this.NudThresholdValue.Enabled = false;
                    this.NudMinSize.Enabled = false;
                    this.NudOffset.Enabled = false;
                    this.CmbIOSignal.Enabled = false;
                    this.CmbROI.Enabled = false;
                    this.BtnROIDetail.Enabled = false;
                    this.CmbMD.Enabled = false;
                    this.CmbCD.Enabled = false;
                    this.CmbAlignmentTarget.Enabled = false;
                    this.CmbAlignmentIndex.Enabled = false;
                    this.CmbAlignmentSource.Enabled = false;
                    this.BtnApplyAlignment.Enabled = false;
                    this.BtnClearAlignment.Enabled = false;
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
            bool BResult = false;

            try
            {
                if (this.ChkEnabled.Checked == true)
                {
                    this.m_OTarget.BEnabled = true;
                    this.m_OTarget.StrDescription = this.TxtDescription.Text.Trim();
                    this.m_OTarget.EPolarity = CLanguage.GetBlobPolarity(this.CmbPolarity.Text);
                    this.m_OTarget.OThreshold = CThresholdFactory.GetThreshold(CLanguage.GetBlobThreshold(this.ChkThresholdKind.Text));
                    this.m_OTarget.OThreshold.I32Value = Convert.ToInt32(this.NudThresholdValue.Value);
                    this.m_OTarget.I32MinSize = Convert.ToInt32(this.NudMinSize.Value);
                    this.m_OTarget.I32Offset = Convert.ToInt32(this.NudOffset.Value);
                    this.m_OTarget.EIOSignal = (this.CmbIOSignal.Text == CDiaperFaultRecipe.NONE) ? EIO.NONE : (EIO)Enum.Parse(typeof(EIO), this.CmbIOSignal.Text);
                    this.m_OTarget.StrMD = this.CmbMD.Text;
                    this.m_OTarget.StrCD = this.CmbCD.Text;
                }
                else
                {
                    this.m_OTarget.BEnabled = false;
                }

                BResult = true;
            }
            catch (Exception ex)
            {
                CError.Throw(ex);
            }

            return BResult;
        }


        public override void MoveGraphic(string StrDirection, int I32Distance)
        {
            try
            {
                if (this.m_OTarget.BEnabled == true)
                {
                    this.m_OTarget.OROI.Move(StrDirection, I32Distance);
                }
            }
            catch (Exception ex)
            {
                CError.Throw(ex);
            }
        }
        #endregion
    }
}
