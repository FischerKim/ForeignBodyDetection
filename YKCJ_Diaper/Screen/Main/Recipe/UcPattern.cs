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

namespace YKCJ_Diaper
{
    public partial class UcPattern : UcSubRecipe
    {
        #region VARIABLE
        private CRecipeDesignTool m_OTool = null;
        private CPatternRecipe m_OTarget = null;

        private bool m_BPreventEvent = false;
        #endregion


        #region CONSTRUCTOR & DESTRUCTOR
        public UcPattern(CRecipeDesignTool OTool)
        {
            InitializeComponent();

            try
            {
                this.m_OTool = OTool;

                for (int _Index = 1; _Index <= CDiaperFaultRecipe.PATTERN_COUNT; _Index++)
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
                    CMsgBox.Warning("복사 대상 패턴 정보를 선택하여 주세요.!");
                    return;
                }


                foreach (CPatternRecipe _Item in this.m_OTool.ORecipe.ArrOPattern)
                {
                    if (_Item.I32Index != Convert.ToInt32(this.CmbCopyNo.Text)) continue;

                    this.m_OTarget.Copy(_Item, true);
                    this.m_OTarget.OROI.Refresh();
                    break;
                }


                if (this.m_OTarget.BEnabled == true)
                {
                    this.m_OTool.Activate(this.m_OTarget);

                    this.ChkEnabled.Text = "사용";
                    this.ChkEnabled.Checked = true;
                    this.ChkEnabled.BackColor = Color.ForestGreen;
                    this.TxtDescription.Text = this.m_OTarget.StrDescription;
                    this.CdpTrain.Image = this.m_OTarget.OTool.Pattern.GetTrainedPatternImage();
                    this.BtnShow.BackColor = Color.SteelBlue;
                    this.BtnTrain.BackColor = SystemColors.Control;
                    this.NudMinScore.Value = this.m_OTarget.I32MinScore;
                    this.NudMinScore.Controls[1].Text = this.NudMinScore.Value.ToString();
                    this.CmbIOSignal.Text = (this.m_OTarget.EIOSignal == EIO.NONE) ? CDiaperFaultRecipe.NONE : this.m_OTarget.EIOSignal.ToString();
                    this.CmbMD.Text = this.m_OTarget.StrMD;
                    this.CmbCD.Text = this.m_OTarget.StrCD;

                    this.ChkEnabled.Enabled = true;
                    this.TxtDescription.Enabled = true;
                    this.BtnShow.Enabled = true;
                    this.BtnTrain.Enabled = false;
                    this.NudMinScore.Enabled = true;
                    this.CmbIOSignal.Enabled = true;
                    this.CmbMD.Enabled = true;
                    this.CmbCD.Enabled = true;
                }
                else
                {
                    this.ChkEnabled.Text = "사용않함";
                    this.ChkEnabled.Checked = false;
                    this.ChkEnabled.BackColor = Color.DarkRed;
                    this.TxtDescription.Text = string.Empty;
                    this.CdpTrain.Image = null;
                    this.BtnShow.BackColor = SystemColors.Control;
                    this.BtnTrain.BackColor = SystemColors.Control;
                    this.NudMinScore.Controls[1].Text = string.Empty;
                    this.CmbIOSignal.SelectedIndex = -1;
                    this.CmbMD.SelectedIndex = -1;
                    this.CmbCD.SelectedIndex = -1;

                    this.TxtDescription.Enabled = false;
                    this.BtnShow.Enabled = false;
                    this.BtnTrain.Enabled = false;
                    this.NudMinScore.Enabled = false;
                    this.CmbIOSignal.Enabled = false;
                    this.CmbMD.Enabled = false;
                    this.CmbCD.Enabled = false;
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


        private void BtnShow_Click(object sender, EventArgs e)
        {
            try
            {
                this.m_OTool.OCdpImage.InteractiveGraphics.Add
                (
                   (ICogGraphicInteractive)this.m_OTarget.OTool.Pattern.TrainRegion,
                   "PatternTrain",
                   true
                );

                this.BtnShow.BackColor = SystemColors.Control;
                this.BtnTrain.BackColor = Color.SteelBlue;
                this.BtnShow.Enabled = false;
                this.BtnTrain.Enabled = true;
            }
            catch (Exception ex)
            {
                CError.Show(ex);
            }
        }


        private void BtnTrain_Click(object sender, EventArgs e)
        {
            try
            {
                this.m_OTool.OCdpImage.DrawingEnabled = false;

                this.m_OTarget.OTool.Pattern.TrainImage = (CogImage8Grey)this.m_OTool.OCdpImage.Image;
                this.m_OTarget.OTool.Pattern.Train();
                this.CdpTrain.Image = this.m_OTarget.OTool.Pattern.GetTrainedPatternImage();

                this.BtnShow.BackColor = Color.SteelBlue;
                this.BtnTrain.BackColor = SystemColors.Control;
                this.BtnShow.Enabled = true;
                this.BtnTrain.Enabled = false;
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
                    if (this.m_OTarget.OTool.Pattern.Trained == false)
                    {
                        CMsgBox.Warning("패턴을 설정하여 주세요!");
                        this.CmbNo.Text = this.m_OTarget.I32Index.ToString();
                        this.NudNo.Value = this.m_OTarget.I32Index;
                        return;
                    }

                    this.m_OTarget.OROI.Reflect();
                    this.m_OTool.DeActivate();

                    this.m_OTarget.BEnabled = true;
                    this.m_OTarget.StrDescription = this.TxtDescription.Text.Trim();
                    this.m_OTarget.I32MinScore = Convert.ToInt32(this.NudMinScore.Value);
                    this.m_OTarget.EIOSignal = (this.CmbIOSignal.Text == CDiaperFaultRecipe.NONE) ? EIO.NONE : (EIO)Enum.Parse(typeof(EIO), this.CmbIOSignal.Text);
                    this.m_OTarget.StrMD = this.CmbMD.Text;
                    this.m_OTarget.StrCD = this.CmbCD.Text;
                }
                else
                {
                    this.m_OTarget.BEnabled = false;
                    this.m_OTarget.StrDescription = string.Empty;
                    this.m_OTarget.I32MinScore = 80;
                    this.m_OTarget.EIOSignal = EIO.NONE;
                    this.m_OTarget.StrMD = CDiaperFaultRecipe.NONE;
                    this.m_OTarget.StrCD = CDiaperFaultRecipe.NONE;
                }


                int I32Index = Convert.ToInt32(this.CmbNo.Text);
                foreach (CPatternRecipe _Item in this.m_OTool.ORecipe.ArrOPattern)
                {
                    if (_Item.I32Index != I32Index) continue;

                    this.m_OTarget = _Item;
                    this.NudNo.Value = I32Index;
                    break;
                }

                this.CmbCopyNo.Items.Clear();
                foreach (CPatternRecipe _Item in this.m_OTool.ORecipe.ArrOPattern)
                {
                    if (_Item.I32Index == this.m_OTarget.I32Index) continue;

                    this.CmbCopyNo.Items.Add(_Item.I32Index.ToString());
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
                    this.CdpTrain.Image = this.m_OTarget.OTool.Pattern.GetTrainedPatternImage();
                    this.BtnShow.BackColor = Color.SteelBlue;
                    this.BtnTrain.BackColor = SystemColors.Control;
                    this.NudMinScore.Value = this.m_OTarget.I32MinScore;
                    this.NudMinScore.Controls[1].Text = this.NudMinScore.Value.ToString();
                    this.CmbIOSignal.Text = (this.m_OTarget.EIOSignal == EIO.NONE) ? CDiaperFaultRecipe.NONE : this.m_OTarget.EIOSignal.ToString();
                    this.CmbMD.Text = this.m_OTarget.StrMD;
                    this.CmbCD.Text = this.m_OTarget.StrCD;

                    this.ChkEnabled.Enabled = true;
                    this.TxtDescription.Enabled = true;
                    this.BtnShow.Enabled = true;
                    this.BtnTrain.Enabled = false;
                    this.NudMinScore.Enabled = true;
                    this.CmbIOSignal.Enabled = true;
                    this.CmbMD.Enabled = true;
                    this.CmbCD.Enabled = true;
                }
                else
                {
                    this.CmbCopyNo.SelectedIndex = -1;
                    this.BtnCopy.BackColor = Color.SteelBlue;
                    this.ChkEnabled.Checked = false;
                    this.ChkEnabled.Text = "사용않함";
                    this.ChkEnabled.BackColor = Color.DarkRed;
                    this.TxtDescription.Text = string.Empty;
                    this.CdpTrain.Image = null;
                    this.BtnShow.BackColor = SystemColors.Control;
                    this.BtnTrain.BackColor = SystemColors.Control;
                    this.NudMinScore.Controls[1].Text = string.Empty;
                    this.CmbIOSignal.SelectedIndex = -1;
                    this.CmbMD.SelectedIndex = -1;
                    this.CmbCD.SelectedIndex = -1;

                    this.ChkEnabled.Enabled = true;
                    this.TxtDescription.Enabled = false;
                    this.BtnShow.Enabled = false;
                    this.BtnTrain.Enabled = false;
                    this.NudMinScore.Enabled = false;
                    this.CmbIOSignal.Enabled = false;
                    this.CmbMD.Enabled = false;
                    this.CmbCD.Enabled = false;
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
                    this.BtnShow.BackColor = Color.SteelBlue;
                    this.BtnTrain.BackColor = SystemColors.Control;
                    this.NudMinScore.Value = this.m_OTarget.I32MinScore;
                    this.NudMinScore.Controls[1].Text = this.NudMinScore.Value.ToString();
                    this.CmbIOSignal.Text = CDiaperFaultRecipe.NONE;
                    this.CmbMD.Text = this.m_OTarget.StrMD;
                    this.CmbCD.Text = this.m_OTarget.StrCD;

                    this.TxtDescription.Enabled = true;
                    this.BtnShow.Enabled = true;
                    this.BtnTrain.Enabled = false;
                    this.NudMinScore.Enabled = true;
                    this.CmbIOSignal.Enabled = true;
                    this.CmbMD.Enabled = true;
                    this.CmbCD.Enabled = true;
                }
                else
                {
                    this.m_OTarget.BEnabled = false;
                    this.m_OTarget.StrDescription = string.Empty;
                    this.m_OTarget.OROI.Init();
                    this.m_OTarget.OROI.Refresh();
                    this.m_OTarget.OROI.ResetAttach();
                    this.m_OTarget.I32MinScore = 80;
                    this.m_OTarget.EIOSignal = EIO.NONE;
                    this.m_OTarget.StrMD = CDiaperFaultRecipe.NONE;
                    this.m_OTarget.StrCD = CDiaperFaultRecipe.NONE;
                    this.m_OTarget.OTool.Pattern.Untrain();


                    this.ChkEnabled.Text = "사용않함";
                    this.ChkEnabled.BackColor = Color.DarkRed;
                    this.TxtDescription.Text = string.Empty;
                    this.CdpTrain.Image = null;
                    this.BtnShow.BackColor = SystemColors.Control;
                    this.BtnTrain.BackColor = SystemColors.Control;
                    this.NudMinScore.Controls[1].Text = string.Empty;
                    this.CmbIOSignal.SelectedIndex = -1;
                    this.CmbMD.SelectedIndex = -1;
                    this.CmbCD.SelectedIndex = -1;

                    this.TxtDescription.Enabled = false;
                    this.BtnShow.Enabled = false;
                    this.BtnTrain.Enabled = false;
                    this.NudMinScore.Enabled = false;
                    this.CmbIOSignal.Enabled = false;
                    this.CmbMD.Enabled = false;
                    this.CmbCD.Enabled = false;
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
                this.m_OTool.OCdpImage.DrawingEnabled = false;

                this.CmbCopyNo.Items.Clear();
                this.CmbMD.Items.Clear();
                this.CmbCD.Items.Clear();

                if (this.m_OTool.ORecipe != null)
                {
                    this.m_OTarget = this.m_OTool.ORecipe.ArrOPattern[0];

                    foreach (CPatternRecipe _Item in this.m_OTool.ORecipe.ArrOPattern)
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
                        this.CdpTrain.Image = this.m_OTarget.OTool.Pattern.GetTrainedPatternImage();
                        this.BtnShow.BackColor = Color.SteelBlue;
                        this.BtnTrain.BackColor = SystemColors.Control;
                        this.NudMinScore.Value = this.m_OTarget.I32MinScore;
                        this.NudMinScore.Controls[1].Text = this.NudMinScore.Value.ToString();
                        this.CmbIOSignal.Text = (this.m_OTarget.EIOSignal == EIO.NONE) ? CDiaperFaultRecipe.NONE : this.m_OTarget.EIOSignal.ToString();
                        this.CmbMD.Text = this.m_OTarget.StrMD;
                        this.CmbCD.Text = this.m_OTarget.StrCD;

                        this.CmbNo.Enabled = true;
                        this.NudNo.Enabled = true;
                        this.CmbCopyNo.Enabled = true;
                        this.BtnCopy.Enabled = true;
                        this.ChkEnabled.Enabled = true;
                        this.TxtDescription.Enabled = true;
                        this.BtnShow.Enabled = true;
                        this.BtnTrain.Enabled = false;
                        this.NudMinScore.Enabled = true;
                        this.CmbIOSignal.Enabled = true;
                        this.CmbMD.Enabled = true;
                        this.CmbCD.Enabled = true;
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
                        this.CdpTrain.Image = null;
                        this.BtnShow.BackColor = SystemColors.Control;
                        this.BtnTrain.BackColor = SystemColors.Control;
                        this.NudMinScore.Controls[1].Text = string.Empty;
                        this.CmbIOSignal.SelectedIndex = -1;
                        this.CmbMD.SelectedIndex = -1;
                        this.CmbCD.SelectedIndex = -1;

                        this.CmbNo.Enabled = true;
                        this.NudNo.Enabled = true;
                        this.CmbCopyNo.Enabled = true;
                        this.BtnCopy.Enabled = true;
                        this.ChkEnabled.Enabled = true;
                        this.TxtDescription.Enabled = false;
                        this.BtnShow.Enabled = false;
                        this.BtnTrain.Enabled = false;
                        this.NudMinScore.Enabled = false;
                        this.CmbIOSignal.Enabled = false;
                        this.CmbMD.Enabled = false;
                        this.CmbCD.Enabled = false;
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
                    this.CdpTrain.Image = null;
                    this.BtnShow.BackColor = SystemColors.Control;
                    this.BtnTrain.BackColor = SystemColors.Control;
                    this.NudMinScore.Controls[1].Text = string.Empty;
                    this.CmbIOSignal.SelectedIndex = -1;
                    this.CmbMD.SelectedIndex = -1;
                    this.CmbCD.SelectedIndex = -1;

                    this.CmbNo.Enabled = false;
                    this.NudNo.Enabled = false;
                    this.CmbCopyNo.Enabled = false;
                    this.BtnCopy.Enabled = false;
                    this.ChkEnabled.Enabled = false;
                    this.TxtDescription.Enabled = false;
                    this.BtnShow.Enabled = false;
                    this.BtnTrain.Enabled = false;
                    this.NudMinScore.Enabled = false;
                    this.CmbIOSignal.Enabled = false;
                    this.CmbMD.Enabled = false;
                    this.CmbCD.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                CError.Throw(ex);
            }
            finally
            {
                this.m_OTool.OCdpImage.DrawingEnabled = true;
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
                    if (this.m_OTarget.OTool.Pattern.Trained == false)
                    {
                        CMsgBox.Warning("패턴을 설정하여 주세요!");
                        BResult = false;
                    }
                    else
                    {
                        this.m_OTarget.BEnabled = true;
                        this.m_OTarget.StrDescription = this.TxtDescription.Text.Trim();
                        this.m_OTarget.I32MinScore = Convert.ToInt32(this.NudMinScore.Value);
                        this.m_OTarget.EIOSignal = (this.CmbIOSignal.Text == CDiaperFaultRecipe.NONE) ? EIO.NONE : (EIO)Enum.Parse(typeof(EIO), this.CmbIOSignal.Text);
                        this.m_OTarget.StrMD = this.CmbMD.Text;
                        this.m_OTarget.StrCD = this.CmbCD.Text;
                    }
                }
                else
                {
                    this.m_OTarget.BEnabled = false;
                    this.m_OTarget.StrDescription = string.Empty;
                    this.m_OTarget.I32MinScore = 80;
                    this.m_OTarget.EIOSignal = EIO.NONE;
                    this.m_OTarget.StrMD = CDiaperFaultRecipe.NONE;
                    this.m_OTarget.StrCD = CDiaperFaultRecipe.NONE;
                }
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
