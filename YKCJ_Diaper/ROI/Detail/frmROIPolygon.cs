using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Cognex.VisionPro;
using Jhjo.Common;

namespace YKCJ_Diaper
{
    public partial class frmROIPolygon : CROIWindow
    {
        #region VARIABLE
        private CRecipeDesignTool m_OTool = null;
        private CBlobRecipe m_ORecipe = null;
        private CogPolygon m_OGraphic = null;
        private NumericUpDown[] m_ArrOX = null;
        private NumericUpDown[] m_ArrOY = null;

        private bool m_BPreventEvent = false;
        #endregion


        #region PROPERTIES
        public override CRecipeDesignTool OTool
        {
            set { this.m_OTool = value; }
        }


        public override CBlobRecipe ORecipe
        {
            set
            {
                try
                {
                    this.m_BPreventEvent = true;

                    this.m_ORecipe = value;
                    this.m_OGraphic = (CogPolygon)value.OROI.OGraphic;

                    if (this.m_OGraphic.NumVertices == 3) this.BtnRemove.Enabled = false;
                    else if (this.m_OGraphic.NumVertices == 20) this.BtnAdd.Enabled = false;

                    for (int _Index = 0; _Index < this.m_OGraphic.NumVertices; _Index++)
                    {
                        this.m_ArrOX[_Index].Value = Math.Round((decimal)this.m_OGraphic.GetVertexX(_Index), 2);
                        this.m_ArrOY[_Index].Value = Math.Round((decimal)this.m_OGraphic.GetVertexY(_Index), 2);
                        this.m_ArrOX[_Index].Controls[1].Text = this.m_ArrOX[_Index].Value.ToString();
                        this.m_ArrOY[_Index].Controls[1].Text = this.m_ArrOY[_Index].Value.ToString();
                        this.m_ArrOX[_Index].Enabled = true;
                        this.m_ArrOY[_Index].Enabled = true;
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
        }
        #endregion


        #region CONSTRUCTOR & DESTRUCTOR
        public frmROIPolygon()
        {
            InitializeComponent();

            try
            {
                this.m_ArrOX = new NumericUpDown[20];
                this.m_ArrOX[0] = this.NudX1;
                this.m_ArrOX[1] = this.NudX2;
                this.m_ArrOX[2] = this.NudX3;
                this.m_ArrOX[3] = this.NudX4;
                this.m_ArrOX[4] = this.NudX5;
                this.m_ArrOX[5] = this.NudX6;
                this.m_ArrOX[6] = this.NudX7;
                this.m_ArrOX[7] = this.NudX8;
                this.m_ArrOX[8] = this.NudX9;
                this.m_ArrOX[9] = this.NudX10;
                this.m_ArrOX[10] = this.NudX11;
                this.m_ArrOX[11] = this.NudX12;
                this.m_ArrOX[12] = this.NudX13;
                this.m_ArrOX[13] = this.NudX14;
                this.m_ArrOX[14] = this.NudX15;
                this.m_ArrOX[15] = this.NudX16;
                this.m_ArrOX[16] = this.NudX17;
                this.m_ArrOX[17] = this.NudX18;
                this.m_ArrOX[18] = this.NudX19;
                this.m_ArrOX[19] = this.NudX20;

                this.m_ArrOY = new NumericUpDown[20];
                this.m_ArrOY[0] = this.NudY1;
                this.m_ArrOY[1] = this.NudY2;
                this.m_ArrOY[2] = this.NudY3;
                this.m_ArrOY[3] = this.NudY4;
                this.m_ArrOY[4] = this.NudY5;
                this.m_ArrOY[5] = this.NudY6;
                this.m_ArrOY[6] = this.NudY7;
                this.m_ArrOY[7] = this.NudY8;
                this.m_ArrOY[8] = this.NudY9;
                this.m_ArrOY[9] = this.NudY10;
                this.m_ArrOY[10] = this.NudY11;
                this.m_ArrOY[11] = this.NudY12;
                this.m_ArrOY[12] = this.NudY13;
                this.m_ArrOY[13] = this.NudY14;
                this.m_ArrOY[14] = this.NudY15;
                this.m_ArrOY[15] = this.NudY16;
                this.m_ArrOY[16] = this.NudY17;
                this.m_ArrOY[17] = this.NudY18;
                this.m_ArrOY[18] = this.NudY19;
                this.m_ArrOY[19] = this.NudY20;


                foreach (NumericUpDown _Item in this.m_ArrOX)
                {
                    _Item.Controls[1].Text = string.Empty;
                    _Item.Enabled = false;
                }

                foreach (NumericUpDown _Item in this.m_ArrOY)
                {
                    _Item.Controls[1].Text = string.Empty;
                    _Item.Enabled = false;
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
        private void BtnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                this.m_BPreventEvent = true;
                this.m_OTool.OCdpImage.DrawingEnabled = false;

                this.m_OGraphic.AddVertex(0, 0, this.m_OGraphic.NumVertices);

                this.m_ArrOX[this.m_OGraphic.NumVertices - 1].Value = 0;
                this.m_ArrOX[this.m_OGraphic.NumVertices - 1].Controls[1].Text = this.m_ArrOX[this.m_OGraphic.NumVertices - 1].Value.ToString();
                this.m_ArrOX[this.m_OGraphic.NumVertices - 1].Enabled = true;
                this.m_ArrOY[this.m_OGraphic.NumVertices - 1].Value = 0;
                this.m_ArrOY[this.m_OGraphic.NumVertices - 1].Controls[1].Text = this.m_ArrOY[this.m_OGraphic.NumVertices - 1].Value.ToString();
                this.m_ArrOY[this.m_OGraphic.NumVertices - 1].Enabled = true;

                if (this.m_OGraphic.NumVertices == 20)
                {
                    this.BtnAdd.Enabled = false;
                }
                this.BtnRemove.Enabled = true;


                this.m_ORecipe.StrAlignmentTarget = CDiaperFaultRecipe.NONE;
                this.m_ORecipe.StrAlignmentIndex = CDiaperFaultRecipe.NONE;
                this.m_ORecipe.StrAlignmentSource = CDiaperFaultRecipe.NONE;
                this.m_ORecipe.OROI.ResetAttach();

                this.m_OTool.DoAlignment(this.m_ORecipe, this.m_ORecipe.OROI.OBound);
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


        private void BtnRemove_Click(object sender, EventArgs e)
        {
            try
            {
                this.m_BPreventEvent = true;
                this.m_OTool.OCdpImage.DrawingEnabled = false;

                this.m_OGraphic.RemoveVertex(this.m_OGraphic.NumVertices - 1);

                this.m_ArrOX[this.m_OGraphic.NumVertices].Controls[1].Text = string.Empty;
                this.m_ArrOX[this.m_OGraphic.NumVertices].Enabled = true;
                this.m_ArrOY[this.m_OGraphic.NumVertices].Controls[1].Text = string.Empty;
                this.m_ArrOY[this.m_OGraphic.NumVertices].Enabled = true;

                this.BtnAdd.Enabled = true;
                if (this.m_OGraphic.NumVertices == 3)
                {
                    this.BtnRemove.Enabled = false;
                }


                this.m_ORecipe.StrAlignmentTarget = CDiaperFaultRecipe.NONE;
                this.m_ORecipe.StrAlignmentIndex = CDiaperFaultRecipe.NONE;
                this.m_ORecipe.StrAlignmentSource = CDiaperFaultRecipe.NONE;
                this.m_ORecipe.OROI.ResetAttach();

                this.m_OTool.DoAlignment(this.m_ORecipe, this.m_ORecipe.OROI.OBound);
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


        private void BtnClose_Click(object sender, EventArgs e)
        {
            try
            {
                this.Close();
            }
            catch (Exception ex)
            {
                CError.Show(ex);
            }
        }
        #endregion


        #region ETC EVENT
        private void NudFeature_ValueChanged(object sender, EventArgs e)
        {
            if (this.m_BPreventEvent == true) return;

            try
            {
                this.m_OTool.OCdpImage.DrawingEnabled = false;

                NumericUpDown OControl = (NumericUpDown)sender;
                string StrTag = (string)OControl.Tag;

                if (StrTag.Substring(0, 1) == "X")
                {
                    this.m_OGraphic.SetVertexX
                    (
                        Convert.ToInt32(StrTag.Substring(1, 2)),
                        Convert.ToDouble(OControl.Value)
                    );
                }
                else
                {
                    this.m_OGraphic.SetVertexY
                    (
                        Convert.ToInt32(StrTag.Substring(1, 2)),
                        Convert.ToDouble(OControl.Value)
                    );
                }


                this.m_ORecipe.StrAlignmentTarget = CDiaperFaultRecipe.NONE;
                this.m_ORecipe.StrAlignmentIndex = CDiaperFaultRecipe.NONE;
                this.m_ORecipe.StrAlignmentSource = CDiaperFaultRecipe.NONE;
                this.m_ORecipe.OROI.ResetAttach();

                this.m_OTool.DoAlignment(this.m_ORecipe, this.m_ORecipe.OROI.OBound);
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
        #endregion
    }
}
