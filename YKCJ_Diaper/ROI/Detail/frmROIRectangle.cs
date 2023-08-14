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
    public partial class frmROIRectangle : CROIWindow
    {
        #region VARIABLE
        private CRecipeDesignTool m_OTool = null;
        private CBlobRecipe m_ORecipe = null;
        private CogRectangle m_OGraphic = null;
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
                    this.m_OGraphic = (CogRectangle)value.OROI.OGraphic;

                    this.NudX.Value = Math.Round((decimal)this.m_OGraphic.X, 2);
                    this.NudY.Value = Math.Round((decimal)this.m_OGraphic.Y, 2);
                    this.NudWidth.Value = Math.Round((decimal)this.m_OGraphic.Width, 2);
                    this.NudHeight.Value = Math.Round((decimal)this.m_OGraphic.Height, 2);
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
        public frmROIRectangle()
        {
            InitializeComponent();
        }
        #endregion


        #region EVENT
        #region BUTTON EVENT
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

                string StrTag = (string)((Control)sender).Tag;

                switch (StrTag)
                {
                    case "X":
                        this.m_OGraphic.X = Convert.ToDouble(this.NudX.Value);
                        break;

                    case "Y":
                        this.m_OGraphic.Y = Convert.ToDouble(this.NudY.Value);
                        break;

                    case "Width":
                        this.m_OGraphic.Width = Convert.ToDouble(this.NudWidth.Value);
                        break;

                    case "Height":
                        this.m_OGraphic.Height = Convert.ToDouble(this.NudHeight.Value);
                        break;
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
