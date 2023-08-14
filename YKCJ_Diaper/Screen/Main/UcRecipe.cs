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

namespace YKCJ_Diaper
{
    public partial class UcRecipe : UcSubMain
    {
        #region VARIABLE
        private CRecipeDesignTool m_OTool = null;

        private UcSubRecipe m_OScreen = null;
        private UcBlob m_OBlob = null;
        private UcPattern m_OPattern = null;
        private UcMDCD m_OMDCD = null;
        private UcCalibration m_OETC = null;
        #endregion


        #region CONSTRUCTOR & DESTRUCTOR
        public UcRecipe()
        {
            InitializeComponent();

            try
            {
                this.CdpDisplayer.AutoFit = true;
                this.CdpDisplayer.BackColor = Color.Black;
                this.CdpDisplayer.HorizontalScrollBar = false;
                this.CdpDisplayer.VerticalScrollBar = false;


                this.m_OTool = new CRecipeDesignTool(this.CdpDisplayer);
                
                this.m_OBlob = new UcBlob(this.m_OTool);
                this.m_OBlob.Dock = DockStyle.Fill;
                this.m_OPattern = new UcPattern(this.m_OTool);
                this.m_OPattern.Dock = DockStyle.Fill;
                this.m_OMDCD = new UcMDCD(this.m_OTool);
                this.m_OMDCD.Dock = DockStyle.Fill;
                this.m_OETC = new UcCalibration(this.m_OTool);
                this.m_OETC.Dock = DockStyle.Fill;

                this.m_OBlob.Add();
                this.PnlScreen.Controls.Add(this.m_OBlob);
                this.m_OScreen = this.m_OBlob;

                this.BtnBlob.BackColor = Color.ForestGreen;
                

                this.LtbRecipe.Items.Clear();
                foreach (CDiaperFaultRecipe _Item in CRecipeManager.It.LstORecipe)
                {
                    this.LtbRecipe.Items.Add(_Item.StrName);
                }
                if (this.LtbRecipe.Items.Count > 0)
                {
                    this.LtbRecipe.SelectedIndex = 0;
                    this.LtbRecipe_SelectedIndexChanged(null, null);
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
        private void BtnBlob_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.SetScreen(this.m_OBlob) == true)
                {
                    this.BtnBlob.BackColor = Color.ForestGreen;
                    //this.BtnPattern.BackColor = Color.SteelBlue;
                    this.BtnMDCD.BackColor = Color.SteelBlue;
                    this.BtnETC.BackColor = Color.SteelBlue;

                    this.BtnLeft1.BackColor = Color.SteelBlue;
                    this.BtnLeft10.BackColor = Color.SteelBlue;
                    this.BtnRight1.BackColor = Color.SteelBlue;
                    this.BtnRight10.BackColor = Color.SteelBlue;
                    this.BtnTop1.BackColor = Color.SteelBlue;
                    this.BtnTop10.BackColor = Color.SteelBlue;
                    this.BtnBottom1.BackColor = Color.SteelBlue;
                    this.BtnBottom10.BackColor = Color.SteelBlue;
                    this.BtnLeft1.Enabled = true;
                    this.BtnLeft10.Enabled = true;
                    this.BtnRight1.Enabled = true;
                    this.BtnRight10.Enabled = true;
                    this.BtnTop1.Enabled = true;
                    this.BtnTop10.Enabled = true;
                    this.BtnBottom1.Enabled = true;
                    this.BtnBottom10.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                CError.Show(ex);
            }
        }


        private void BtnPattern_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.SetScreen(this.m_OPattern) == true)
                {
                    this.BtnBlob.BackColor = Color.SteelBlue;
                    //this.BtnPattern.BackColor = Color.ForestGreen;
                    this.BtnMDCD.BackColor = Color.SteelBlue;
                    this.BtnETC.BackColor = Color.SteelBlue;

                    this.BtnLeft1.BackColor = Color.SteelBlue;
                    this.BtnLeft10.BackColor = Color.SteelBlue;
                    this.BtnRight1.BackColor = Color.SteelBlue;
                    this.BtnRight10.BackColor = Color.SteelBlue;
                    this.BtnTop1.BackColor = Color.SteelBlue;
                    this.BtnTop10.BackColor = Color.SteelBlue;
                    this.BtnBottom1.BackColor = Color.SteelBlue;
                    this.BtnBottom10.BackColor = Color.SteelBlue;
                    this.BtnLeft1.Enabled = true;
                    this.BtnLeft10.Enabled = true;
                    this.BtnRight1.Enabled = true;
                    this.BtnRight10.Enabled = true;
                    this.BtnTop1.Enabled = true;
                    this.BtnTop10.Enabled = true;
                    this.BtnBottom1.Enabled = true;
                    this.BtnBottom10.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                CError.Show(ex);
            }
        }


        private void BtnMDCD_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.SetScreen(this.m_OMDCD) == true)
                {
                    this.BtnBlob.BackColor = Color.SteelBlue;
                    //this.BtnPattern.BackColor = Color.SteelBlue;
                    this.BtnMDCD.BackColor = Color.ForestGreen;
                    this.BtnETC.BackColor = Color.SteelBlue;

                    if (this.ChkMoveAll.Checked == true)
                    {
                        this.BtnLeft1.BackColor = Color.SteelBlue;
                        this.BtnLeft10.BackColor = Color.SteelBlue;
                        this.BtnRight1.BackColor = Color.SteelBlue;
                        this.BtnRight10.BackColor = Color.SteelBlue;
                        this.BtnTop1.BackColor = Color.SteelBlue;
                        this.BtnTop10.BackColor = Color.SteelBlue;
                        this.BtnBottom1.BackColor = Color.SteelBlue;
                        this.BtnBottom10.BackColor = Color.SteelBlue;
                        this.BtnLeft1.Enabled = true;
                        this.BtnLeft10.Enabled = true;
                        this.BtnRight1.Enabled = true;
                        this.BtnRight10.Enabled = true;
                        this.BtnTop1.Enabled = true;
                        this.BtnTop10.Enabled = true;
                        this.BtnBottom1.Enabled = true;
                        this.BtnBottom10.Enabled = true;
                    }
                    else
                    {
                        this.BtnLeft1.BackColor = SystemColors.Control;
                        this.BtnLeft10.BackColor = SystemColors.Control;
                        this.BtnRight1.BackColor = SystemColors.Control;
                        this.BtnRight10.BackColor = SystemColors.Control;
                        this.BtnTop1.BackColor = SystemColors.Control;
                        this.BtnTop10.BackColor = SystemColors.Control;
                        this.BtnBottom1.BackColor = SystemColors.Control;
                        this.BtnBottom10.BackColor = SystemColors.Control;
                        this.BtnLeft1.Enabled = false;
                        this.BtnLeft10.Enabled = false;
                        this.BtnRight1.Enabled = false;
                        this.BtnRight10.Enabled = false;
                        this.BtnTop1.Enabled = false;
                        this.BtnTop10.Enabled = false;
                        this.BtnBottom1.Enabled = false;
                        this.BtnBottom10.Enabled = false;
                    }
                }
            }
            catch (Exception ex)
            {
                CError.Show(ex);
            }
        }


        private void BtnETC_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.SetScreen(this.m_OETC) == true)
                {
                    this.BtnBlob.BackColor = Color.SteelBlue;
                    //this.BtnPattern.BackColor = Color.SteelBlue;
                    this.BtnMDCD.BackColor = Color.SteelBlue;
                    this.BtnETC.BackColor = Color.ForestGreen;

                    if (this.ChkMoveAll.Checked == true)
                    {
                        this.BtnLeft1.BackColor = Color.SteelBlue;
                        this.BtnLeft10.BackColor = Color.SteelBlue;
                        this.BtnRight1.BackColor = Color.SteelBlue;
                        this.BtnRight10.BackColor = Color.SteelBlue;
                        this.BtnTop1.BackColor = Color.SteelBlue;
                        this.BtnTop10.BackColor = Color.SteelBlue;
                        this.BtnBottom1.BackColor = Color.SteelBlue;
                        this.BtnBottom10.BackColor = Color.SteelBlue;
                        this.BtnLeft1.Enabled = true;
                        this.BtnLeft10.Enabled = true;
                        this.BtnRight1.Enabled = true;
                        this.BtnRight10.Enabled = true;
                        this.BtnTop1.Enabled = true;
                        this.BtnTop10.Enabled = true;
                        this.BtnBottom1.Enabled = true;
                        this.BtnBottom10.Enabled = true;
                    }
                    else
                    {
                        this.BtnLeft1.BackColor = SystemColors.Control;
                        this.BtnLeft10.BackColor = SystemColors.Control;
                        this.BtnRight1.BackColor = SystemColors.Control;
                        this.BtnRight10.BackColor = SystemColors.Control;
                        this.BtnTop1.BackColor = SystemColors.Control;
                        this.BtnTop10.BackColor = SystemColors.Control;
                        this.BtnBottom1.BackColor = SystemColors.Control;
                        this.BtnBottom10.BackColor = SystemColors.Control;
                        this.BtnLeft1.Enabled = false;
                        this.BtnLeft10.Enabled = false;
                        this.BtnRight1.Enabled = false;
                        this.BtnRight10.Enabled = false;
                        this.BtnTop1.Enabled = false;
                        this.BtnTop10.Enabled = false;
                        this.BtnBottom1.Enabled = false;
                        this.BtnBottom10.Enabled = false;
                    }
                }
            }
            catch (Exception ex)
            {
                CError.Show(ex);
            }
        }


        private void BtnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                frmRecipe OWindow = new frmRecipe();
                if (OWindow.ShowDialog() == DialogResult.OK)
                {
                    CDiaperFaultRecipe ORecipe = new CDiaperFaultRecipe(OWindow.StrName);
                    ORecipe.Create();
                    ORecipe.OImage = (CogImage8Grey)this.CdpDisplayer.Image;
                    ORecipe.Save();
                    ORecipe.Dispose();

                    int I32RowIndex = CDB.It[CDB.TABLE_RECIPE_LIST].InsertRow();
                    CDB.It[CDB.TABLE_RECIPE_LIST].Update(I32RowIndex, CDB.RECIPE_LIST_NAME, ORecipe.StrName);

                    foreach (CBlobRecipe _Item1 in ORecipe.ArrOBlob)
                    {
                        double[] ArrF64Value = _Item1.OROI.GetValue();

                        I32RowIndex = CDB.It[CDB.TABLE_BLOB_LIST].InsertRow();
                        CDB.It[CDB.TABLE_BLOB_LIST].Update(I32RowIndex, CDB.BLOB_LIST_RECIPE, ORecipe.StrName);
                        CDB.It[CDB.TABLE_BLOB_LIST].Update(I32RowIndex, CDB.BLOB_LIST_INDEX, _Item1.I32Index);
                        CDB.It[CDB.TABLE_BLOB_LIST].Update(I32RowIndex, CDB.BLOB_LIST_DESCRIPTION, _Item1.StrDescription);
                        CDB.It[CDB.TABLE_BLOB_LIST].Update(I32RowIndex, CDB.BLOB_LIST_ENABLED, _Item1.BEnabled);
                        CDB.It[CDB.TABLE_BLOB_LIST].Update(I32RowIndex, CDB.BLOB_LIST_POLARITY, _Item1.EPolarity.ToString());
                        CDB.It[CDB.TABLE_BLOB_LIST].Update(I32RowIndex, CDB.BLOB_LIST_THRESHOLD_TYPE, _Item1.OThreshold.EKind.ToString());
                        CDB.It[CDB.TABLE_BLOB_LIST].Update(I32RowIndex, CDB.BLOB_LIST_THRESHOLD_VALUE, _Item1.OThreshold.I32Value);
                        CDB.It[CDB.TABLE_BLOB_LIST].Update(I32RowIndex, CDB.BLOB_LIST_MIN_SIZE, _Item1.I32MinSize);
                        CDB.It[CDB.TABLE_BLOB_LIST].Update(I32RowIndex, CDB.BLOB_LIST_OFFSET, _Item1.I32Offset);
                        CDB.It[CDB.TABLE_BLOB_LIST].Update(I32RowIndex, CDB.BLOB_LIST_IO, (_Item1.EIOSignal == EIO.NONE) ? CDiaperFaultRecipe.NONE : _Item1.EIOSignal.ToString());
                        CDB.It[CDB.TABLE_BLOB_LIST].Update(I32RowIndex, CDB.BLOB_LIST_ALIGNMENT_TARGET, _Item1.StrAlignmentTarget);
                        CDB.It[CDB.TABLE_BLOB_LIST].Update(I32RowIndex, CDB.BLOB_LIST_ALIGNMENT_INDEX, _Item1.StrAlignmentIndex);
                        CDB.It[CDB.TABLE_BLOB_LIST].Update(I32RowIndex, CDB.BLOB_LIST_ALIGNMENT_SOURCE, _Item1.StrAlignmentSource);
                        CDB.It[CDB.TABLE_BLOB_LIST].Update(I32RowIndex, CDB.BLOB_LIST_FOLLOW_MD, _Item1.StrMD);
                        CDB.It[CDB.TABLE_BLOB_LIST].Update(I32RowIndex, CDB.BLOB_LIST_FOLLOW_CD, _Item1.StrCD);
                        CDB.It[CDB.TABLE_BLOB_LIST].Update(I32RowIndex, CDB.BLOB_LIST_ROI_KIND, _Item1.OROI.EKind.ToString());
                        CDB.It[CDB.TABLE_BLOB_LIST].Update(I32RowIndex, CDB.BLOB_LIST_ROI_VALUE_COUNT, ArrF64Value.Length);

                        for (int _Index2 = 0; _Index2 < ArrF64Value.Length; _Index2++)
                        {
                            CDB.It[CDB.TABLE_BLOB_LIST].Update(I32RowIndex, CDB.BLOB_LIST_ROI_VALUE + _Index2, ArrF64Value[_Index2]);
                        }
                    }

                    foreach (CPatternRecipe _Item in ORecipe.ArrOPattern)
                    {
                        I32RowIndex = CDB.It[CDB.TABLE_PATTERN_LIST].InsertRow();
                        CDB.It[CDB.TABLE_PATTERN_LIST].Update(I32RowIndex, CDB.PATTERN_LIST_RECIPE, ORecipe.StrName);
                        CDB.It[CDB.TABLE_PATTERN_LIST].Update(I32RowIndex, CDB.PATTERN_LIST_INDEX, _Item.I32Index);
                        CDB.It[CDB.TABLE_PATTERN_LIST].Update(I32RowIndex, CDB.PATTERN_LIST_ENABLED, _Item.BEnabled);
                        CDB.It[CDB.TABLE_PATTERN_LIST].Update(I32RowIndex, CDB.PATTERN_LIST_DESCRIPTION, _Item.StrDescription);
                        CDB.It[CDB.TABLE_PATTERN_LIST].Update(I32RowIndex, CDB.PATTERN_LIST_MIN_SCORE, _Item.I32MinScore);
                        CDB.It[CDB.TABLE_PATTERN_LIST].Update(I32RowIndex, CDB.PATTERN_LIST_IO, (_Item.EIOSignal == EIO.NONE) ? CDiaperFaultRecipe.NONE : _Item.EIOSignal.ToString());
                        CDB.It[CDB.TABLE_PATTERN_LIST].Update(I32RowIndex, CDB.PATTERN_LIST_FOLLOW_MD, _Item.StrMD);
                        CDB.It[CDB.TABLE_PATTERN_LIST].Update(I32RowIndex, CDB.PATTERN_LIST_FOLLOW_CD, _Item.StrCD);
                        CDB.It[CDB.TABLE_PATTERN_LIST].Update(I32RowIndex, CDB.PATTERN_LIST_ROI_X, _Item.OROI.F64X);
                        CDB.It[CDB.TABLE_PATTERN_LIST].Update(I32RowIndex, CDB.PATTERN_LIST_ROI_Y, _Item.OROI.F64Y);
                        CDB.It[CDB.TABLE_PATTERN_LIST].Update(I32RowIndex, CDB.PATTERN_LIST_ROI_WIDTH, _Item.OROI.F64Width);
                        CDB.It[CDB.TABLE_PATTERN_LIST].Update(I32RowIndex, CDB.PATTERN_LIST_ROI_HEIGHT, _Item.OROI.F64Height);
                    }

                    foreach (CFollowRecipe _Item in ORecipe.ArrOMD)
                    {
                        I32RowIndex = CDB.It[CDB.TABLE_FOLLOW_LIST].InsertRow();
                        CDB.It[CDB.TABLE_FOLLOW_LIST].Update(I32RowIndex, CDB.FOLLOW_LIST_RECIPE, ORecipe.StrName);
                        CDB.It[CDB.TABLE_FOLLOW_LIST].Update(I32RowIndex, CDB.FOLLOW_LIST_KIND, _Item.EKind.ToString());
                        CDB.It[CDB.TABLE_FOLLOW_LIST].Update(I32RowIndex, CDB.FOLLOW_LIST_INDEX, _Item.I32Index);
                        CDB.It[CDB.TABLE_FOLLOW_LIST].Update(I32RowIndex, CDB.FOLLOW_LIST_ENABLED, _Item.BEnabled);
                        CDB.It[CDB.TABLE_FOLLOW_LIST].Update(I32RowIndex, CDB.FOLLOW_LIST_DESCRIPTION, _Item.StrDescription);
                        CDB.It[CDB.TABLE_FOLLOW_LIST].Update(I32RowIndex, CDB.FOLLOW_LIST_POLARITY, _Item.EPolarity.ToString());
                        CDB.It[CDB.TABLE_FOLLOW_LIST].Update(I32RowIndex, CDB.FOLLOW_LIST_CONTRAST_THRESHOLD, _Item.I32ContrastThreshold);
                        CDB.It[CDB.TABLE_FOLLOW_LIST].Update(I32RowIndex, CDB.FOLLOW_LIST_HALF_PIXEL, _Item.I32HalfPixel);
                        CDB.It[CDB.TABLE_FOLLOW_LIST].Update(I32RowIndex, CDB.FOLLOW_LIST_PRIORITY, _Item.EPriority.ToString());
                        CDB.It[CDB.TABLE_FOLLOW_LIST].Update(I32RowIndex, CDB.FOLLOW_LIST_ROI_CENTER_X, _Item.OROI.F64CenterX);
                        CDB.It[CDB.TABLE_FOLLOW_LIST].Update(I32RowIndex, CDB.FOLLOW_LIST_ROI_CENTER_Y, _Item.OROI.F64CenterY);
                        CDB.It[CDB.TABLE_FOLLOW_LIST].Update(I32RowIndex, CDB.FOLLOW_LIST_ROI_LENGTH_X, _Item.OROI.F64LengthX);
                        CDB.It[CDB.TABLE_FOLLOW_LIST].Update(I32RowIndex, CDB.FOLLOW_LIST_ROI_LENGTH_Y, _Item.OROI.F64LengthY);
                        CDB.It[CDB.TABLE_FOLLOW_LIST].Update(I32RowIndex, CDB.FOLLOW_LIST_ROI_ROTATION, _Item.OROI.F64Rotation);
                        CDB.It[CDB.TABLE_FOLLOW_LIST].Update(I32RowIndex, CDB.FOLLOW_LIST_ROI_SKEW, _Item.OROI.F64Skew);
                        CDB.It[CDB.TABLE_FOLLOW_LIST].Update(I32RowIndex, CDB.FOLLOW_LIST_STANDARD_POSITION, _Item.F64StandardPosition);
                    }

                    foreach (CFollowRecipe _Item in ORecipe.ArrOCD)
                    {
                        I32RowIndex = CDB.It[CDB.TABLE_FOLLOW_LIST].InsertRow();
                        CDB.It[CDB.TABLE_FOLLOW_LIST].Update(I32RowIndex, CDB.FOLLOW_LIST_RECIPE, ORecipe.StrName);
                        CDB.It[CDB.TABLE_FOLLOW_LIST].Update(I32RowIndex, CDB.FOLLOW_LIST_KIND, _Item.EKind.ToString());
                        CDB.It[CDB.TABLE_FOLLOW_LIST].Update(I32RowIndex, CDB.FOLLOW_LIST_INDEX, _Item.I32Index);
                        CDB.It[CDB.TABLE_FOLLOW_LIST].Update(I32RowIndex, CDB.FOLLOW_LIST_ENABLED, _Item.BEnabled);
                        CDB.It[CDB.TABLE_FOLLOW_LIST].Update(I32RowIndex, CDB.FOLLOW_LIST_DESCRIPTION, _Item.StrDescription);
                        CDB.It[CDB.TABLE_FOLLOW_LIST].Update(I32RowIndex, CDB.FOLLOW_LIST_POLARITY, _Item.EPolarity.ToString());
                        CDB.It[CDB.TABLE_FOLLOW_LIST].Update(I32RowIndex, CDB.FOLLOW_LIST_CONTRAST_THRESHOLD, _Item.I32ContrastThreshold);
                        CDB.It[CDB.TABLE_FOLLOW_LIST].Update(I32RowIndex, CDB.FOLLOW_LIST_HALF_PIXEL, _Item.I32HalfPixel);
                        CDB.It[CDB.TABLE_FOLLOW_LIST].Update(I32RowIndex, CDB.FOLLOW_LIST_PRIORITY, _Item.EPriority.ToString());
                        CDB.It[CDB.TABLE_FOLLOW_LIST].Update(I32RowIndex, CDB.FOLLOW_LIST_ROI_CENTER_X, _Item.OROI.F64CenterX);
                        CDB.It[CDB.TABLE_FOLLOW_LIST].Update(I32RowIndex, CDB.FOLLOW_LIST_ROI_CENTER_Y, _Item.OROI.F64CenterY);
                        CDB.It[CDB.TABLE_FOLLOW_LIST].Update(I32RowIndex, CDB.FOLLOW_LIST_ROI_LENGTH_X, _Item.OROI.F64LengthX);
                        CDB.It[CDB.TABLE_FOLLOW_LIST].Update(I32RowIndex, CDB.FOLLOW_LIST_ROI_LENGTH_Y, _Item.OROI.F64LengthY);
                        CDB.It[CDB.TABLE_FOLLOW_LIST].Update(I32RowIndex, CDB.FOLLOW_LIST_ROI_ROTATION, _Item.OROI.F64Rotation);
                        CDB.It[CDB.TABLE_FOLLOW_LIST].Update(I32RowIndex, CDB.FOLLOW_LIST_ROI_SKEW, _Item.OROI.F64Skew);
                        CDB.It[CDB.TABLE_FOLLOW_LIST].Update(I32RowIndex, CDB.FOLLOW_LIST_STANDARD_POSITION, _Item.F64StandardPosition);
                    }

                    CDB.It[CDB.TABLE_RECIPE_LIST].Commit();
                    CDB.It[CDB.TABLE_BLOB_LIST].Commit();
                    CDB.It[CDB.TABLE_PATTERN_LIST].Commit();
                    CDB.It[CDB.TABLE_FOLLOW_LIST].Commit();


                    CRecipeManager.It.LstORecipe.Add(new CDiaperFaultRecipe(ORecipe));


                    this.LtbRecipe.Items.Clear();
                    foreach (CDiaperFaultRecipe _Item in CRecipeManager.It.LstORecipe)
                    {
                        this.LtbRecipe.Items.Add(_Item.StrName);
                    }
                    if (this.LtbRecipe.Items.Count > 0)
                    {
                        this.LtbRecipe.SelectedIndex = 0;
                        this.LtbRecipe_SelectedIndexChanged(null, null);
                    }
                }
            }
            catch (Exception ex)
            {
                CError.Show(ex);
            }
        }


        private void BtnCopy_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.m_OTool.ORecipe == null)
                {
                    CMsgBox.Warning("복사 대상 모델 정보를 선택하여 주세요.");
                    return;
                }


                frmRecipe OWindow = new frmRecipe();
                if (OWindow.ShowDialog() == DialogResult.OK)
                {
                    CDiaperFaultRecipe ORecipe = new CDiaperFaultRecipe(OWindow.StrName);
                    ORecipe.Copy(this.m_OTool.ORecipe);

                    int I32RowIndex = CDB.It[CDB.TABLE_RECIPE_LIST].InsertRow();
                    CDB.It[CDB.TABLE_RECIPE_LIST].Update(I32RowIndex, CDB.RECIPE_LIST_NAME, ORecipe.StrName);

                    foreach (CBlobRecipe _Item1 in ORecipe.ArrOBlob)
                    {
                        double[] ArrF64Value = _Item1.OROI.GetValue();

                        I32RowIndex = CDB.It[CDB.TABLE_BLOB_LIST].InsertRow();
                        CDB.It[CDB.TABLE_BLOB_LIST].Update(I32RowIndex, CDB.BLOB_LIST_RECIPE, ORecipe.StrName);
                        CDB.It[CDB.TABLE_BLOB_LIST].Update(I32RowIndex, CDB.BLOB_LIST_INDEX, _Item1.I32Index);
                        CDB.It[CDB.TABLE_BLOB_LIST].Update(I32RowIndex, CDB.BLOB_LIST_DESCRIPTION, _Item1.StrDescription);
                        CDB.It[CDB.TABLE_BLOB_LIST].Update(I32RowIndex, CDB.BLOB_LIST_ENABLED, _Item1.BEnabled);
                        CDB.It[CDB.TABLE_BLOB_LIST].Update(I32RowIndex, CDB.BLOB_LIST_POLARITY, _Item1.EPolarity.ToString());
                        CDB.It[CDB.TABLE_BLOB_LIST].Update(I32RowIndex, CDB.BLOB_LIST_THRESHOLD_TYPE, _Item1.OThreshold.EKind.ToString());
                        CDB.It[CDB.TABLE_BLOB_LIST].Update(I32RowIndex, CDB.BLOB_LIST_THRESHOLD_VALUE, _Item1.OThreshold.I32Value);
                        CDB.It[CDB.TABLE_BLOB_LIST].Update(I32RowIndex, CDB.BLOB_LIST_MIN_SIZE, _Item1.I32MinSize);
                        CDB.It[CDB.TABLE_BLOB_LIST].Update(I32RowIndex, CDB.BLOB_LIST_OFFSET, _Item1.I32Offset);
                        CDB.It[CDB.TABLE_BLOB_LIST].Update(I32RowIndex, CDB.BLOB_LIST_IO, (_Item1.EIOSignal == EIO.NONE) ? CDiaperFaultRecipe.NONE : _Item1.EIOSignal.ToString());
                        CDB.It[CDB.TABLE_BLOB_LIST].Update(I32RowIndex, CDB.BLOB_LIST_ALIGNMENT_TARGET, _Item1.StrAlignmentTarget);
                        CDB.It[CDB.TABLE_BLOB_LIST].Update(I32RowIndex, CDB.BLOB_LIST_ALIGNMENT_INDEX, _Item1.StrAlignmentIndex);
                        CDB.It[CDB.TABLE_BLOB_LIST].Update(I32RowIndex, CDB.BLOB_LIST_ALIGNMENT_SOURCE, _Item1.StrAlignmentSource);
                        CDB.It[CDB.TABLE_BLOB_LIST].Update(I32RowIndex, CDB.BLOB_LIST_FOLLOW_MD, _Item1.StrMD);
                        CDB.It[CDB.TABLE_BLOB_LIST].Update(I32RowIndex, CDB.BLOB_LIST_FOLLOW_CD, _Item1.StrCD);
                        CDB.It[CDB.TABLE_BLOB_LIST].Update(I32RowIndex, CDB.BLOB_LIST_ROI_KIND, _Item1.OROI.EKind.ToString());
                        CDB.It[CDB.TABLE_BLOB_LIST].Update(I32RowIndex, CDB.BLOB_LIST_ROI_VALUE_COUNT, ArrF64Value.Length);

                        for (int _Index2 = 0; _Index2 < ArrF64Value.Length; _Index2++)
                        {
                            CDB.It[CDB.TABLE_BLOB_LIST].Update(I32RowIndex, CDB.BLOB_LIST_ROI_VALUE + _Index2, ArrF64Value[_Index2]);
                        }
                    }

                    foreach (CPatternRecipe _Item in ORecipe.ArrOPattern)
                    {
                        I32RowIndex = CDB.It[CDB.TABLE_PATTERN_LIST].InsertRow();
                        CDB.It[CDB.TABLE_PATTERN_LIST].Update(I32RowIndex, CDB.PATTERN_LIST_RECIPE, ORecipe.StrName);
                        CDB.It[CDB.TABLE_PATTERN_LIST].Update(I32RowIndex, CDB.PATTERN_LIST_INDEX, _Item.I32Index);
                        CDB.It[CDB.TABLE_PATTERN_LIST].Update(I32RowIndex, CDB.PATTERN_LIST_ENABLED, _Item.BEnabled);
                        CDB.It[CDB.TABLE_PATTERN_LIST].Update(I32RowIndex, CDB.PATTERN_LIST_DESCRIPTION, _Item.StrDescription);
                        CDB.It[CDB.TABLE_PATTERN_LIST].Update(I32RowIndex, CDB.PATTERN_LIST_MIN_SCORE, _Item.I32MinScore);
                        CDB.It[CDB.TABLE_PATTERN_LIST].Update(I32RowIndex, CDB.PATTERN_LIST_IO, (_Item.EIOSignal == EIO.NONE) ? CDiaperFaultRecipe.NONE : _Item.EIOSignal.ToString());
                        CDB.It[CDB.TABLE_PATTERN_LIST].Update(I32RowIndex, CDB.PATTERN_LIST_FOLLOW_MD, _Item.StrMD);
                        CDB.It[CDB.TABLE_PATTERN_LIST].Update(I32RowIndex, CDB.PATTERN_LIST_FOLLOW_CD, _Item.StrCD);
                        CDB.It[CDB.TABLE_PATTERN_LIST].Update(I32RowIndex, CDB.PATTERN_LIST_ROI_X, _Item.OROI.F64X);
                        CDB.It[CDB.TABLE_PATTERN_LIST].Update(I32RowIndex, CDB.PATTERN_LIST_ROI_Y, _Item.OROI.F64Y);
                        CDB.It[CDB.TABLE_PATTERN_LIST].Update(I32RowIndex, CDB.PATTERN_LIST_ROI_WIDTH, _Item.OROI.F64Width);
                        CDB.It[CDB.TABLE_PATTERN_LIST].Update(I32RowIndex, CDB.PATTERN_LIST_ROI_HEIGHT, _Item.OROI.F64Height);
                    }

                    foreach (CFollowRecipe _Item in ORecipe.ArrOMD)
                    {
                        I32RowIndex = CDB.It[CDB.TABLE_FOLLOW_LIST].InsertRow();
                        CDB.It[CDB.TABLE_FOLLOW_LIST].Update(I32RowIndex, CDB.FOLLOW_LIST_RECIPE, ORecipe.StrName);
                        CDB.It[CDB.TABLE_FOLLOW_LIST].Update(I32RowIndex, CDB.FOLLOW_LIST_KIND, _Item.EKind.ToString());
                        CDB.It[CDB.TABLE_FOLLOW_LIST].Update(I32RowIndex, CDB.FOLLOW_LIST_INDEX, _Item.I32Index);
                        CDB.It[CDB.TABLE_FOLLOW_LIST].Update(I32RowIndex, CDB.FOLLOW_LIST_ENABLED, _Item.BEnabled);
                        CDB.It[CDB.TABLE_FOLLOW_LIST].Update(I32RowIndex, CDB.FOLLOW_LIST_DESCRIPTION, _Item.StrDescription);
                        CDB.It[CDB.TABLE_FOLLOW_LIST].Update(I32RowIndex, CDB.FOLLOW_LIST_POLARITY, _Item.EPolarity.ToString());
                        CDB.It[CDB.TABLE_FOLLOW_LIST].Update(I32RowIndex, CDB.FOLLOW_LIST_CONTRAST_THRESHOLD, _Item.I32ContrastThreshold);
                        CDB.It[CDB.TABLE_FOLLOW_LIST].Update(I32RowIndex, CDB.FOLLOW_LIST_HALF_PIXEL, _Item.I32HalfPixel);
                        CDB.It[CDB.TABLE_FOLLOW_LIST].Update(I32RowIndex, CDB.FOLLOW_LIST_PRIORITY, _Item.EPriority.ToString());
                        CDB.It[CDB.TABLE_FOLLOW_LIST].Update(I32RowIndex, CDB.FOLLOW_LIST_ROI_CENTER_X, _Item.OROI.F64CenterX);
                        CDB.It[CDB.TABLE_FOLLOW_LIST].Update(I32RowIndex, CDB.FOLLOW_LIST_ROI_CENTER_Y, _Item.OROI.F64CenterY);
                        CDB.It[CDB.TABLE_FOLLOW_LIST].Update(I32RowIndex, CDB.FOLLOW_LIST_ROI_LENGTH_X, _Item.OROI.F64LengthX);
                        CDB.It[CDB.TABLE_FOLLOW_LIST].Update(I32RowIndex, CDB.FOLLOW_LIST_ROI_LENGTH_Y, _Item.OROI.F64LengthY);
                        CDB.It[CDB.TABLE_FOLLOW_LIST].Update(I32RowIndex, CDB.FOLLOW_LIST_ROI_ROTATION, _Item.OROI.F64Rotation);
                        CDB.It[CDB.TABLE_FOLLOW_LIST].Update(I32RowIndex, CDB.FOLLOW_LIST_ROI_SKEW, _Item.OROI.F64Skew);
                        CDB.It[CDB.TABLE_FOLLOW_LIST].Update(I32RowIndex, CDB.FOLLOW_LIST_STANDARD_POSITION, _Item.F64StandardPosition);
                    }

                    foreach (CFollowRecipe _Item in ORecipe.ArrOCD)
                    {
                        I32RowIndex = CDB.It[CDB.TABLE_FOLLOW_LIST].InsertRow();
                        CDB.It[CDB.TABLE_FOLLOW_LIST].Update(I32RowIndex, CDB.FOLLOW_LIST_RECIPE, ORecipe.StrName);
                        CDB.It[CDB.TABLE_FOLLOW_LIST].Update(I32RowIndex, CDB.FOLLOW_LIST_KIND, _Item.EKind.ToString());
                        CDB.It[CDB.TABLE_FOLLOW_LIST].Update(I32RowIndex, CDB.FOLLOW_LIST_INDEX, _Item.I32Index);
                        CDB.It[CDB.TABLE_FOLLOW_LIST].Update(I32RowIndex, CDB.FOLLOW_LIST_ENABLED, _Item.BEnabled);
                        CDB.It[CDB.TABLE_FOLLOW_LIST].Update(I32RowIndex, CDB.FOLLOW_LIST_DESCRIPTION, _Item.StrDescription);
                        CDB.It[CDB.TABLE_FOLLOW_LIST].Update(I32RowIndex, CDB.FOLLOW_LIST_POLARITY, _Item.EPolarity.ToString());
                        CDB.It[CDB.TABLE_FOLLOW_LIST].Update(I32RowIndex, CDB.FOLLOW_LIST_CONTRAST_THRESHOLD, _Item.I32ContrastThreshold);
                        CDB.It[CDB.TABLE_FOLLOW_LIST].Update(I32RowIndex, CDB.FOLLOW_LIST_HALF_PIXEL, _Item.I32HalfPixel);
                        CDB.It[CDB.TABLE_FOLLOW_LIST].Update(I32RowIndex, CDB.FOLLOW_LIST_PRIORITY, _Item.EPriority.ToString());
                        CDB.It[CDB.TABLE_FOLLOW_LIST].Update(I32RowIndex, CDB.FOLLOW_LIST_ROI_CENTER_X, _Item.OROI.F64CenterX);
                        CDB.It[CDB.TABLE_FOLLOW_LIST].Update(I32RowIndex, CDB.FOLLOW_LIST_ROI_CENTER_Y, _Item.OROI.F64CenterY);
                        CDB.It[CDB.TABLE_FOLLOW_LIST].Update(I32RowIndex, CDB.FOLLOW_LIST_ROI_LENGTH_X, _Item.OROI.F64LengthX);
                        CDB.It[CDB.TABLE_FOLLOW_LIST].Update(I32RowIndex, CDB.FOLLOW_LIST_ROI_LENGTH_Y, _Item.OROI.F64LengthY);
                        CDB.It[CDB.TABLE_FOLLOW_LIST].Update(I32RowIndex, CDB.FOLLOW_LIST_ROI_ROTATION, _Item.OROI.F64Rotation);
                        CDB.It[CDB.TABLE_FOLLOW_LIST].Update(I32RowIndex, CDB.FOLLOW_LIST_ROI_SKEW, _Item.OROI.F64Skew);
                        CDB.It[CDB.TABLE_FOLLOW_LIST].Update(I32RowIndex, CDB.FOLLOW_LIST_STANDARD_POSITION, _Item.F64StandardPosition);
                    }

                    CDB.It[CDB.TABLE_RECIPE_LIST].Commit();
                    CDB.It[CDB.TABLE_BLOB_LIST].Commit();
                    CDB.It[CDB.TABLE_PATTERN_LIST].Commit();
                    CDB.It[CDB.TABLE_FOLLOW_LIST].Commit();


                    CRecipeManager.It.LstORecipe.Add(ORecipe);


                    this.LtbRecipe.Items.Clear();
                    foreach (CDiaperFaultRecipe _Item in CRecipeManager.It.LstORecipe)
                    {
                        this.LtbRecipe.Items.Add(_Item.StrName);
                    }
                    if (this.LtbRecipe.Items.Count > 0)
                    {
                        this.LtbRecipe.SelectedIndex = 0;
                        this.LtbRecipe_SelectedIndexChanged(null, null);
                    }
                }
            }
            catch (Exception ex)
            {
                CError.Show(ex);
            }
        }


        private void BtnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.m_OTool.ORecipe == null)
                {
                    CMsgBox.Warning("삭제 대상 모델 정보를 선택하여 주세요.");
                    return;
                }

                if (this.m_OTool.ORecipe.StrName == CEnvironment.It.StrSystemRecipe)
                {
                    CMsgBox.Warning("현재 사용중인 모델은 삭제할 수 없습니다.");
                    return;
                }


                if (CMsgBox.OKCancel("'" + this.m_OTool.ORecipe.StrName + "' 모델 정보를 정말 삭제하시겠습니까?") == DialogResult.OK)
                {
                    CDB.It[CDB.TABLE_RECIPE_LIST].DeleteRow(CDB.RECIPE_LIST_NAME, this.m_OTool.ORecipe.StrName);
                    CDB.It[CDB.TABLE_BLOB_LIST].DeleteRow(CDB.BLOB_LIST_RECIPE, this.m_OTool.ORecipe.StrName);
                    CDB.It[CDB.TABLE_PATTERN_LIST].DeleteRow(CDB.PATTERN_LIST_RECIPE, this.m_OTool.ORecipe.StrName);
                    CDB.It[CDB.TABLE_FOLLOW_LIST].DeleteRow(CDB.FOLLOW_LIST_RECIPE, this.m_OTool.ORecipe.StrName);

                    CDB.It[CDB.TABLE_RECIPE_LIST].Commit();
                    CDB.It[CDB.TABLE_BLOB_LIST].Commit();
                    CDB.It[CDB.TABLE_PATTERN_LIST].Commit();
                    CDB.It[CDB.TABLE_FOLLOW_LIST].Commit();


                    for (int _Index = 0; _Index < CRecipeManager.It.LstORecipe.Count; _Index++)
                    {
                        if (CRecipeManager.It.LstORecipe[_Index].StrName != this.m_OTool.ORecipe.StrName) continue;

                        CRecipeManager.It.LstORecipe[_Index].Delete();
                        CRecipeManager.It.LstORecipe.RemoveAt(_Index);
                        break;
                    }


                    this.LtbRecipe.Items.Clear();
                    foreach (CDiaperFaultRecipe _Item in CRecipeManager.It.LstORecipe)
                    {
                        this.LtbRecipe.Items.Add(_Item.StrName);
                    }
                    if (this.LtbRecipe.Items.Count > 0)
                    {
                        this.LtbRecipe.SelectedIndex = 0;
                        this.LtbRecipe_SelectedIndexChanged(null, null);
                    }
                }
            }
            catch (Exception ex)
            {
                CError.Show(ex);
            }
        }


        private void BtnToolModify_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.m_OTool.ORecipe == null) return;
                if (this.m_OScreen.Apply() == false) return;
                if (this.m_OTool.Validate() == false) return;
                

                this.m_OTool.ORecipe.OImage = (CogImage8Grey)this.CdpDisplayer.Image;
                this.m_OTool.ORecipe.Save();

                int I32RowIndex = 0;
                foreach (CBlobRecipe _Item1 in this.m_OTool.ORecipe.ArrOBlob)
                {
                    double[] ArrF64Value = _Item1.OROI.GetValue();

                    I32RowIndex = CDB.It[CDB.TABLE_BLOB_LIST].SelectRowIndex
                    (
                        new string[] { CDB.BLOB_LIST_RECIPE, CDB.BLOB_LIST_INDEX },
                        new object[] { this.m_OTool.ORecipe.StrName, _Item1.I32Index }
                    );

                    CDB.It[CDB.TABLE_BLOB_LIST].Update(I32RowIndex, CDB.BLOB_LIST_ENABLED, _Item1.BEnabled);
                    CDB.It[CDB.TABLE_BLOB_LIST].Update(I32RowIndex, CDB.BLOB_LIST_DESCRIPTION, _Item1.StrDescription);
                    CDB.It[CDB.TABLE_BLOB_LIST].Update(I32RowIndex, CDB.BLOB_LIST_POLARITY, _Item1.EPolarity.ToString());
                    CDB.It[CDB.TABLE_BLOB_LIST].Update(I32RowIndex, CDB.BLOB_LIST_THRESHOLD_TYPE, _Item1.OThreshold.EKind.ToString());
                    CDB.It[CDB.TABLE_BLOB_LIST].Update(I32RowIndex, CDB.BLOB_LIST_THRESHOLD_VALUE, _Item1.OThreshold.I32Value);
                    CDB.It[CDB.TABLE_BLOB_LIST].Update(I32RowIndex, CDB.BLOB_LIST_MIN_SIZE, _Item1.I32MinSize);
                    CDB.It[CDB.TABLE_BLOB_LIST].Update(I32RowIndex, CDB.BLOB_LIST_OFFSET, _Item1.I32Offset);
                    CDB.It[CDB.TABLE_BLOB_LIST].Update(I32RowIndex, CDB.BLOB_LIST_IO, (_Item1.EIOSignal == EIO.NONE) ? CDiaperFaultRecipe.NONE : _Item1.EIOSignal.ToString());
                    CDB.It[CDB.TABLE_BLOB_LIST].Update(I32RowIndex, CDB.BLOB_LIST_ALIGNMENT_TARGET, _Item1.StrAlignmentTarget);
                    CDB.It[CDB.TABLE_BLOB_LIST].Update(I32RowIndex, CDB.BLOB_LIST_ALIGNMENT_INDEX, _Item1.StrAlignmentIndex);
                    CDB.It[CDB.TABLE_BLOB_LIST].Update(I32RowIndex, CDB.BLOB_LIST_ALIGNMENT_SOURCE, _Item1.StrAlignmentSource);
                    CDB.It[CDB.TABLE_BLOB_LIST].Update(I32RowIndex, CDB.BLOB_LIST_FOLLOW_MD, _Item1.StrMD);
                    CDB.It[CDB.TABLE_BLOB_LIST].Update(I32RowIndex, CDB.BLOB_LIST_FOLLOW_CD, _Item1.StrCD);
                    CDB.It[CDB.TABLE_BLOB_LIST].Update(I32RowIndex, CDB.BLOB_LIST_ROI_KIND, _Item1.OROI.EKind.ToString());
                    CDB.It[CDB.TABLE_BLOB_LIST].Update(I32RowIndex, CDB.BLOB_LIST_ROI_VALUE_COUNT, ArrF64Value.Length);
                    for (int _Index2 = 0; _Index2 < ArrF64Value.Length; _Index2++)
                    {
                        CDB.It[CDB.TABLE_BLOB_LIST].Update(I32RowIndex, CDB.BLOB_LIST_ROI_VALUE + _Index2, ArrF64Value[_Index2]);
                    }
                }

                foreach (CPatternRecipe _Item in this.m_OTool.ORecipe.ArrOPattern)
                {
                    I32RowIndex = CDB.It[CDB.TABLE_PATTERN_LIST].SelectRowIndex
                    (
                        new string[] { CDB.PATTERN_LIST_RECIPE, CDB.PATTERN_LIST_INDEX },
                        new object[] { this.m_OTool.ORecipe.StrName, _Item.I32Index }
                    );

                    CDB.It[CDB.TABLE_PATTERN_LIST].Update(I32RowIndex, CDB.PATTERN_LIST_ENABLED, _Item.BEnabled);
                    CDB.It[CDB.TABLE_PATTERN_LIST].Update(I32RowIndex, CDB.PATTERN_LIST_DESCRIPTION, _Item.StrDescription);
                    CDB.It[CDB.TABLE_PATTERN_LIST].Update(I32RowIndex, CDB.PATTERN_LIST_MIN_SCORE, _Item.I32MinScore);
                    CDB.It[CDB.TABLE_PATTERN_LIST].Update(I32RowIndex, CDB.PATTERN_LIST_IO, (_Item.EIOSignal == EIO.NONE) ? CDiaperFaultRecipe.NONE : _Item.EIOSignal.ToString());
                    CDB.It[CDB.TABLE_PATTERN_LIST].Update(I32RowIndex, CDB.PATTERN_LIST_FOLLOW_MD, _Item.StrMD);
                    CDB.It[CDB.TABLE_PATTERN_LIST].Update(I32RowIndex, CDB.PATTERN_LIST_FOLLOW_CD, _Item.StrCD);
                    CDB.It[CDB.TABLE_PATTERN_LIST].Update(I32RowIndex, CDB.PATTERN_LIST_ROI_X, _Item.OROI.F64X);
                    CDB.It[CDB.TABLE_PATTERN_LIST].Update(I32RowIndex, CDB.PATTERN_LIST_ROI_Y, _Item.OROI.F64Y);
                    CDB.It[CDB.TABLE_PATTERN_LIST].Update(I32RowIndex, CDB.PATTERN_LIST_ROI_WIDTH, _Item.OROI.F64Width);
                    CDB.It[CDB.TABLE_PATTERN_LIST].Update(I32RowIndex, CDB.PATTERN_LIST_ROI_HEIGHT, _Item.OROI.F64Height);
                }

                foreach (CFollowRecipe _Item in this.m_OTool.ORecipe.ArrOMD)
                {
                    I32RowIndex = CDB.It[CDB.TABLE_FOLLOW_LIST].SelectRowIndex
                    (
                        new string[] { CDB.FOLLOW_LIST_KIND, CDB.FOLLOW_LIST_RECIPE, CDB.FOLLOW_LIST_INDEX },
                        new object[] { _Item.EKind.ToString(), this.m_OTool.ORecipe.StrName, _Item.I32Index }
                    );

                    CDB.It[CDB.TABLE_FOLLOW_LIST].Update(I32RowIndex, CDB.FOLLOW_LIST_INDEX, _Item.I32Index);
                    CDB.It[CDB.TABLE_FOLLOW_LIST].Update(I32RowIndex, CDB.FOLLOW_LIST_ENABLED, _Item.BEnabled);
                    CDB.It[CDB.TABLE_FOLLOW_LIST].Update(I32RowIndex, CDB.FOLLOW_LIST_DESCRIPTION, _Item.StrDescription);
                    CDB.It[CDB.TABLE_FOLLOW_LIST].Update(I32RowIndex, CDB.FOLLOW_LIST_POLARITY, _Item.EPolarity.ToString());
                    CDB.It[CDB.TABLE_FOLLOW_LIST].Update(I32RowIndex, CDB.FOLLOW_LIST_CONTRAST_THRESHOLD, _Item.I32ContrastThreshold);
                    CDB.It[CDB.TABLE_FOLLOW_LIST].Update(I32RowIndex, CDB.FOLLOW_LIST_HALF_PIXEL, _Item.I32HalfPixel);
                    CDB.It[CDB.TABLE_FOLLOW_LIST].Update(I32RowIndex, CDB.FOLLOW_LIST_PRIORITY, _Item.EPriority.ToString());
                    CDB.It[CDB.TABLE_FOLLOW_LIST].Update(I32RowIndex, CDB.FOLLOW_LIST_ROI_CENTER_X, _Item.OROI.F64CenterX);
                    CDB.It[CDB.TABLE_FOLLOW_LIST].Update(I32RowIndex, CDB.FOLLOW_LIST_ROI_CENTER_Y, _Item.OROI.F64CenterY);
                    CDB.It[CDB.TABLE_FOLLOW_LIST].Update(I32RowIndex, CDB.FOLLOW_LIST_ROI_LENGTH_X, _Item.OROI.F64LengthX);
                    CDB.It[CDB.TABLE_FOLLOW_LIST].Update(I32RowIndex, CDB.FOLLOW_LIST_ROI_LENGTH_Y, _Item.OROI.F64LengthY);
                    CDB.It[CDB.TABLE_FOLLOW_LIST].Update(I32RowIndex, CDB.FOLLOW_LIST_ROI_ROTATION, _Item.OROI.F64Rotation);
                    CDB.It[CDB.TABLE_FOLLOW_LIST].Update(I32RowIndex, CDB.FOLLOW_LIST_ROI_SKEW, _Item.OROI.F64Skew);
                    CDB.It[CDB.TABLE_FOLLOW_LIST].Update(I32RowIndex, CDB.FOLLOW_LIST_STANDARD_POSITION, _Item.F64StandardPosition);
                }

                foreach (CFollowRecipe _Item in this.m_OTool.ORecipe.ArrOCD)
                {
                    I32RowIndex = CDB.It[CDB.TABLE_FOLLOW_LIST].SelectRowIndex
                    (
                        new string[] { CDB.FOLLOW_LIST_KIND, CDB.FOLLOW_LIST_RECIPE, CDB.FOLLOW_LIST_INDEX },
                        new object[] { _Item.EKind.ToString(), this.m_OTool.ORecipe.StrName, _Item.I32Index }
                    );

                    CDB.It[CDB.TABLE_FOLLOW_LIST].Update(I32RowIndex, CDB.FOLLOW_LIST_INDEX, _Item.I32Index);
                    CDB.It[CDB.TABLE_FOLLOW_LIST].Update(I32RowIndex, CDB.FOLLOW_LIST_ENABLED, _Item.BEnabled);
                    CDB.It[CDB.TABLE_FOLLOW_LIST].Update(I32RowIndex, CDB.FOLLOW_LIST_DESCRIPTION, _Item.StrDescription);
                    CDB.It[CDB.TABLE_FOLLOW_LIST].Update(I32RowIndex, CDB.FOLLOW_LIST_POLARITY, _Item.EPolarity.ToString());
                    CDB.It[CDB.TABLE_FOLLOW_LIST].Update(I32RowIndex, CDB.FOLLOW_LIST_CONTRAST_THRESHOLD, _Item.I32ContrastThreshold);
                    CDB.It[CDB.TABLE_FOLLOW_LIST].Update(I32RowIndex, CDB.FOLLOW_LIST_HALF_PIXEL, _Item.I32HalfPixel);
                    CDB.It[CDB.TABLE_FOLLOW_LIST].Update(I32RowIndex, CDB.FOLLOW_LIST_PRIORITY, _Item.EPriority.ToString());
                    CDB.It[CDB.TABLE_FOLLOW_LIST].Update(I32RowIndex, CDB.FOLLOW_LIST_ROI_CENTER_X, _Item.OROI.F64CenterX);
                    CDB.It[CDB.TABLE_FOLLOW_LIST].Update(I32RowIndex, CDB.FOLLOW_LIST_ROI_CENTER_Y, _Item.OROI.F64CenterY);
                    CDB.It[CDB.TABLE_FOLLOW_LIST].Update(I32RowIndex, CDB.FOLLOW_LIST_ROI_LENGTH_X, _Item.OROI.F64LengthX);
                    CDB.It[CDB.TABLE_FOLLOW_LIST].Update(I32RowIndex, CDB.FOLLOW_LIST_ROI_LENGTH_Y, _Item.OROI.F64LengthY);
                    CDB.It[CDB.TABLE_FOLLOW_LIST].Update(I32RowIndex, CDB.FOLLOW_LIST_ROI_ROTATION, _Item.OROI.F64Rotation);
                    CDB.It[CDB.TABLE_FOLLOW_LIST].Update(I32RowIndex, CDB.FOLLOW_LIST_ROI_SKEW, _Item.OROI.F64Skew);
                    CDB.It[CDB.TABLE_FOLLOW_LIST].Update(I32RowIndex, CDB.FOLLOW_LIST_STANDARD_POSITION, _Item.F64StandardPosition);
                }

                CDB.It[CDB.TABLE_BLOB_LIST].Commit();
                CDB.It[CDB.TABLE_PATTERN_LIST].Commit();
                CDB.It[CDB.TABLE_FOLLOW_LIST].Commit();


                for (int _Index = 0; _Index < CRecipeManager.It.LstORecipe.Count; _Index++)
                {
                    if (CRecipeManager.It.LstORecipe[_Index].StrName != this.m_OTool.ORecipe.StrName) continue;

                    CRecipeManager.It.LstORecipe[_Index] = new CDiaperFaultRecipe(this.m_OTool.ORecipe);
                    break;
                }
            }
            catch (Exception ex)
            {
                CError.Show(ex);
            }
        }


        private void BtnToolUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.m_OTool.ORecipe == null) return;
                if (this.m_OScreen.Apply() == false) return;
                if (this.m_OTool.Validate() == false) return;


                if (this.m_OTool.ORecipe != null)
                {
                    CEnvironment.It.BCenterLineEnabled = this.m_OTool.OCenterLine.Visible;
                    CEnvironment.It.F64CenterLineX = this.m_OTool.OCenterLine.X;
                    CEnvironment.It.F64CenterLineY = this.m_OTool.OCenterLine.Y;
                    CEnvironment.It.StrSystemRecipe = this.m_OTool.ORecipe.StrName;
                    CEnvironment.It.Commit();

                    CEnvironment.It.OnChangedCenterLine();
                    CEnvironment.It.OnChangedSystemInfo();

                    foreach (CDiaperFaultRecipe _Item in CRecipeManager.It.LstORecipe)
                    {
                        if (_Item.StrName != this.m_OTool.ORecipe.StrName) continue;

                        CDiaperFaultTool.It.ORecipe = new CDiaperFaultRecipe(_Item);
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                CError.Show(ex);
            }
        }


        private void BtnCenterLine_Click(object sender, EventArgs e)
        {
            try
            {
                this.m_OTool.OCenterLine.Visible = !this.m_OTool.OCenterLine.Visible;

                if (this.m_OTool.OCenterLine.Visible == true)
                {
                    this.BtnCenterLine.BackColor = Color.ForestGreen;
                }
                else
                {
                    this.BtnCenterLine.BackColor = Color.SteelBlue;
                }
            }
            catch (Exception ex)
            {
                CError.Show(ex);
            }
        }


        private void BtnLoadImage_Click(object sender, EventArgs e)
        {
            try
            {
                this.CdpDisplayer.Image = CDiaperFaultTool.It.OCurrentImage;
            }
            catch (Exception ex)
            {
                CError.Show(ex);
            }
        }


        private void BtnMove_Click(object sender, EventArgs e)
        {
            try
            {
                this.CdpDisplayer.DrawingEnabled = false;

                string StrTag = (string)((Control)sender).Tag;

                if (this.ChkMoveAll.Checked == true) this.m_OTool.MoveGraphic(StrTag, 1);
                else this.m_OScreen.MoveGraphic(StrTag, 1);
            }
            catch (Exception ex)
            {
                CError.Show(ex);
            }
            finally
            {
                this.CdpDisplayer.DrawingEnabled = true;
            }
        }


        private void BtnMove10_Click(object sender, EventArgs e)
        {
            try
            {
                this.CdpDisplayer.DrawingEnabled = false;

                string StrTag = (string)((Control)sender).Tag;

                if (this.ChkMoveAll.Checked == true) this.m_OTool.MoveGraphic(StrTag, 10);
                else this.m_OScreen.MoveGraphic(StrTag, 10);
            }
            catch (Exception ex)
            {
                CError.Show(ex);
            }
            finally
            {
                this.CdpDisplayer.DrawingEnabled = true;
            }
        }


        private void BtnClick_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                ((Control)sender).BackColor = Color.ForestGreen;
            }
            catch (Exception ex)
            {
                CError.Show(ex);
            }
        }


        private void BtnClick_MouseUp(object sender, MouseEventArgs e)
        {
            try
            {
                ((Control)sender).BackColor = Color.SteelBlue;
            }
            catch (Exception ex)
            {
                CError.Show(ex);
            }
        }
        #endregion


        #region ETC EVENT
        private void LtbRecipe_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                this.m_OTool.OCdpImage.DrawingEnabled = false;

                if (String.IsNullOrEmpty((string)this.LtbRecipe.SelectedItem) == true) return;
                if ((this.m_OTool.ORecipe != null) && (this.m_OTool.ORecipe.StrName == (string)this.LtbRecipe.SelectedItem)) return;

                if (this.m_OTool.ORecipe != null)
                {
                    this.m_OTool.ORecipe.Dispose();
                    this.m_OTool.ORecipe = null;
                }

                foreach (CDiaperFaultRecipe _Item in CRecipeManager.It.LstORecipe)
                {
                    if (_Item.StrName != (string)this.LtbRecipe.SelectedItem) continue;

                    this.m_OTool.ORecipe = new CDiaperFaultRecipe(_Item);
                    this.m_OTool.ORecipe.Load();
                    this.m_OTool.OCdpImage.Image = this.m_OTool.ORecipe.OImage;
                    this.m_OTool.Refresh();
                    this.m_OScreen.Display();
                    break;
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


        private void ChkDisplayAll_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                this.m_OTool.OCdpImage.DrawingEnabled = false;

                if (this.ChkDisplayAll.Checked == true) this.ChkDisplayAll.BackColor = Color.ForestGreen;
                else this.ChkDisplayAll.BackColor = Color.SteelBlue;

                this.m_OTool.BDisplayAll = this.ChkDisplayAll.Checked;
                this.m_OTool.Refresh();
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


        private void ChkAll_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.ChkMoveAll.Checked == true)
                {
                    this.ChkMoveAll.BackColor = Color.ForestGreen;

                    this.BtnLeft1.BackColor = Color.SteelBlue;
                    this.BtnLeft10.BackColor = Color.SteelBlue;
                    this.BtnRight1.BackColor = Color.SteelBlue;
                    this.BtnRight10.BackColor = Color.SteelBlue;
                    this.BtnTop1.BackColor = Color.SteelBlue;
                    this.BtnTop10.BackColor = Color.SteelBlue;
                    this.BtnBottom1.BackColor = Color.SteelBlue;
                    this.BtnBottom10.BackColor = Color.SteelBlue;
                    this.BtnLeft1.Enabled = true;
                    this.BtnLeft10.Enabled = true;
                    this.BtnRight1.Enabled = true;
                    this.BtnRight10.Enabled = true;
                    this.BtnTop1.Enabled = true;
                    this.BtnTop10.Enabled = true;
                    this.BtnBottom1.Enabled = true;
                    this.BtnBottom10.Enabled = true;
                }
                else
                {
                    this.ChkMoveAll.BackColor = Color.SteelBlue;

                    if ((this.m_OScreen.GetType() == typeof(UcMDCD)) ||
                        (this.m_OScreen.GetType() == typeof(UcCalibration)))
                    {
                        this.BtnLeft1.BackColor = SystemColors.Control;
                        this.BtnLeft10.BackColor = SystemColors.Control;
                        this.BtnRight1.BackColor = SystemColors.Control;
                        this.BtnRight10.BackColor = SystemColors.Control;
                        this.BtnTop1.BackColor = SystemColors.Control;
                        this.BtnTop10.BackColor = SystemColors.Control;
                        this.BtnBottom1.BackColor = SystemColors.Control;
                        this.BtnBottom10.BackColor = SystemColors.Control;
                        this.BtnLeft1.Enabled = false;
                        this.BtnLeft10.Enabled = false;
                        this.BtnRight1.Enabled = false;
                        this.BtnRight10.Enabled = false;
                        this.BtnTop1.Enabled = false;
                        this.BtnTop10.Enabled = false;
                        this.BtnBottom1.Enabled = false;
                        this.BtnBottom10.Enabled = false;
                    }
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
                this.BtnBlob.PerformClick();
            }
            catch (Exception ex)
            {
                CError.Show(ex);
            }
        }


        private bool SetScreen(UcSubRecipe OScreen)
        {
            bool BResult = false;

            try
            {
                this.m_OTool.OCdpImage.DrawingEnabled = false;

                if (this.m_OScreen.GetType() != OScreen.GetType())
                {
                    if (this.m_OScreen.Apply() == true)
                    {
                        this.m_OScreen.Remove();
                        OScreen.Add();

                        this.PnlScreen.Controls.Add(OScreen);
                        OScreen.BringToFront();
                        this.PnlScreen.Controls.Remove(this.m_OScreen);

                        this.m_OScreen = OScreen;
                        BResult = true;
                    }
                }
            }
            catch (Exception ex)
            {
                CError.Throw(ex);
            }
            finally
            {
                this.m_OTool.OCdpImage.DrawingEnabled = true;
            }

            return BResult;
        }
        #endregion
    }
}
