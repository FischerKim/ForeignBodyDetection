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
    public partial class frmROIRectangleAffine : CROIWindow
    {
        #region VARIABLE
        private CRecipeDesignTool m_OTool = null;
        private CBlobRecipe m_ORecipe = null;
        private CogRectangleAffine m_OGraphic = null;
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
                    this.m_OGraphic = (CogRectangleAffine)value.OROI.OGraphic;

                    this.NudCenterX.Value = Math.Round((decimal)this.m_OGraphic.CenterX, 2);
                    this.NudCenterY.Value = Math.Round((decimal)this.m_OGraphic.CenterY, 2);
                    this.NudLengthX.Value = Math.Round((decimal)this.m_OGraphic.SideXLength, 2);
                    this.NudLengthY.Value = Math.Round((decimal)this.m_OGraphic.SideYLength, 2);
                    this.NudRotation.Value = Math.Round((decimal)CogMisc.RadToDeg(this.m_OGraphic.Rotation), 2);
                    this.NudSkew.Value = Math.Round((decimal)CogMisc.RadToDeg(this.m_OGraphic.Skew), 2);
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
        public frmROIRectangleAffine()
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

                this.m_OGraphic.SetCenterLengthsRotationSkew
                (
                    Convert.ToDouble(this.NudCenterX.Value),
                    Convert.ToDouble(this.NudCenterY.Value),
                    Convert.ToDouble(this.NudLengthX.Value),
                    Convert.ToDouble(this.NudLengthY.Value),
                    CogMisc.DegToRad(Convert.ToDouble(this.NudRotation.Value)),
                    CogMisc.DegToRad(Convert.ToDouble(this.NudSkew.Value))
                );


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
