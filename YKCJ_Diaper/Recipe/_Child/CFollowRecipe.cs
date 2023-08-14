using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Cognex.VisionPro.Caliper;

using Daekhon.Common;
using Jhjo.Common;
using Cognex.VisionPro;

namespace YKCJ_Diaper
{
    public class CFollowRecipe : IRecipe
    {
        #region VARIABLE
        private string m_StrName = string.Empty;
        private EFOLLOW m_EKind = EFOLLOW.MD;
        private int m_I32Index = 0;

        private string m_StrDescription = string.Empty;
        private bool m_BEnabled = false;
        private CogCaliperPolarityConstants m_EPolarity = CogCaliperPolarityConstants.DontCare;
        private int m_I32ContrastThreshold = 2;
        private int m_I32HalfPixel = 2;
        private ECALIPER_PRIORITY m_EPriority = ECALIPER_PRIORITY.MostThreshold;
        private CROIRectangleAffine m_OROI = null;
        private double m_F64StandardPosition = 0;
        #endregion


        #region PROPERTIES
        public string StrName
        {
            get { return this.m_StrName; }
            set { this.m_StrName = value; }
        }


        public EFOLLOW EKind
        {
            get { return this.m_EKind; }
        }


        public int I32Index
        {
            get { return this.m_I32Index; }
        }


        public string StrDescription
        {
            get { return this.m_StrDescription; }
            set { this.m_StrDescription = value; }
        }


        public bool BEnabled
        {
            get { return this.m_BEnabled; }
            set { this.m_BEnabled = value; }
        }


        public CogCaliperPolarityConstants EPolarity
        {
            get { return this.m_EPolarity; }
            set { this.m_EPolarity = value; }
        }


        public int I32ContrastThreshold
        {
            get { return this.m_I32ContrastThreshold; }
            set { this.m_I32ContrastThreshold = value; }
        }


        public int I32HalfPixel
        {
            get { return this.m_I32HalfPixel; }
            set { this.m_I32HalfPixel = value; }
        }


        public ECALIPER_PRIORITY EPriority
        {
            get { return this.m_EPriority; }
            set { this.m_EPriority = value; }
        }


        public CROIRectangleAffine OROI
        {
            get { return this.m_OROI; }
            set { this.m_OROI = value; }
        }


        public double F64StandardPosition
        {
            get { return this.m_F64StandardPosition; }
            set { this.m_F64StandardPosition = value; }
        }
        #endregion


        #region CONSTRUCTOR & DESTRUCTOR
        public CFollowRecipe(string StrName, EFOLLOW EKind, int I32Index)
        {
            try
            {
                this.m_StrName = StrName;
                this.m_EKind = EKind;
                this.m_I32Index = I32Index;
                this.m_OROI = new CROIRectangleAffine();
                this.m_OROI.F64Rotation = (EKind == EFOLLOW.MD) ? 0F : 90F;
            }
            catch (Exception ex)
            {
                CError.Throw(ex);
            }
        }


        public CFollowRecipe(CFollowRecipe OSource)
        {
            try
            {
                this.m_StrName = OSource.m_StrName;
                this.m_EKind = OSource.m_EKind;
                this.m_I32Index = OSource.m_I32Index;

                this.m_BEnabled = OSource.m_BEnabled;
                this.m_EPolarity = OSource.m_EPolarity;
                this.m_I32ContrastThreshold = OSource.m_I32ContrastThreshold;
                this.m_I32HalfPixel = OSource.m_I32HalfPixel;
                this.m_EPriority = OSource.m_EPriority;
                this.m_OROI = new CROIRectangleAffine(OSource.m_OROI);
                this.m_F64StandardPosition = OSource.m_F64StandardPosition;
            }
            catch (Exception ex)
            {
                CError.Throw(ex);
            }
        }
        #endregion


        #region FUNCTION
        public void Load()
        {
            try
            {
                this.m_OROI.Create();
                this.m_OROI.OGraphic.Color = CogColorConstants.Yellow;
                this.m_OROI.OGraphic.SelectedColor = CogColorConstants.Yellow;
                ((CogRectangleAffine)this.m_OROI.OGraphic).XDirectionAdornment = CogRectangleAffineDirectionAdornmentConstants.SolidArrow;
                ((CogRectangleAffine)this.m_OROI.OGraphic).YDirectionAdornment = CogRectangleAffineDirectionAdornmentConstants.Arrow;
                this.m_OROI.OGraphic.GraphicDOFEnableBase = CogGraphicDOFConstants.Position;
            }
            catch (Exception ex)
            {
                CError.Throw(ex);
            }
        }


        public void Save()
        {
            try
            {
                if (this.m_BEnabled == true)
                {
                    this.m_OROI.Reflect();
                }
            }
            catch (Exception ex)
            {
                CError.Throw(ex);
            }
        }


        public void Copy(CFollowRecipe OSource)
        {
            try
            {
                this.m_BEnabled = OSource.m_BEnabled;
                this.m_EPolarity = OSource.m_EPolarity;
                this.m_I32ContrastThreshold = OSource.m_I32ContrastThreshold;
                this.m_I32HalfPixel = OSource.m_I32HalfPixel;
                this.m_EPriority = OSource.m_EPriority;
                this.m_OROI.Copy(OSource.m_OROI);
                this.m_F64StandardPosition = OSource.m_F64StandardPosition;
            }
            catch (Exception ex)
            {
                CError.Throw(ex);
            }
        }
        #endregion
    }


    public enum EFOLLOW
    {
        MD = 0x00,
        CD = 0x01
    }


    public enum ECALIPER_PRIORITY
    {
        MostThreshold = 0x00,
        MostPosition,
        None = 0xFF
    }
}
