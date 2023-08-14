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
    public partial class frmROICircularAnnulusSection : CROIWindow
    {
        #region VARIABLE
        private CRecipeDesignTool m_OTool = null;
        private CBlobRecipe m_ORecipe = null;
        private CogCircularAnnulusSection m_OGraphic = null;
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
                    this.m_OGraphic = (CogCircularAnnulusSection)value.OROI.OGraphic;

                    this.NudCenterX.Value = Math.Round((decimal)this.m_OGraphic.CenterX, 2);
                    this.NudCenterY.Value = Math.Round((decimal)this.m_OGraphic.CenterY, 2);
                    this.NudRadius.Value = Math.Round((decimal)this.m_OGraphic.Radius, 2);
                    this.NudRadialScale.Value = Math.Round((decimal)this.m_OGraphic.RadialScale, 2);
                    this.NudAngleStart.Value = Math.Round((decimal)CogMisc.RadToDeg(this.m_OGraphic.AngleStart), 2);
                    this.NudAngleSpan.Value = Math.Round((decimal)CogMisc.RadToDeg(this.m_OGraphic.AngleSpan), 2);
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
        public frmROICircularAnnulusSection()
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

                    case "RadialScale":
                        this.m_OGraphic.RadialScale = Convert.ToDouble(this.NudRadialScale.Value);
                        break;

                    case "AngleStart":
                        this.m_OGraphic.AngleStart = CogMisc.DegToRad(Convert.ToDouble(this.NudAngleStart.Value));
                        break;

                    case "AngleSpan":
                        this.m_OGraphic.AngleSpan = CogMisc.DegToRad(Convert.ToDouble(this.NudAngleSpan.Value));
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
