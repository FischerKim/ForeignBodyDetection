using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Jhjo.Common;
using Cognex.VisionPro;

namespace YKCJ_Diaper
{
    public partial class frmROICircle : CROIWindow
    {
        #region VARIABLE
        private CRecipeDesignTool m_OTool = null;
        private CBlobRecipe m_ORecipe = null;
        private CogCircle m_OGraphic = null;
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
                    this.m_OGraphic = (CogCircle)value.OROI.OGraphic;

                    this.NudCenterX.Value = Math.Round((decimal)this.m_OGraphic.CenterX, 2);
                    this.NudCenterY.Value = Math.Round((decimal)this.m_OGraphic.CenterY, 2);
                    this.NudRadius.Value = Math.Round((decimal)this.m_OGraphic.Radius, 2);
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
        public frmROICircle()
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
                    case "CenterX":
                        this.m_OGraphic.CenterX = Convert.ToDouble(this.NudCenterX.Value);
                        break;

                    case "CenterY":
                        this.m_OGraphic.CenterY = Convert.ToDouble(this.NudCenterY.Value);
                        break;

                    case "Radius":
                        this.m_OGraphic.Radius = Convert.ToDouble(this.NudRadius.Value);
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
