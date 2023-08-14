using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cognex.VisionPro;
using Jhjo.Common;

namespace YKCJ_Diaper
{
    public class CSubStanceFilter
    {
        #region VARIABLE
        private string m_StrName = string.Empty;
        private CogColorConstants m_EColor = CogColorConstants.Red;
        private CSubStanceData m_OXLength = null;
        private CSubStanceData m_OYLength = null;
        private CSubStanceData m_OPerimeter = null;
        private CSubStanceData m_OArea = null;
        private CSubStanceData m_OElongation = null;
        #endregion


        #region PROPERTIES
        public string StrName
        {
            get { return this.m_StrName; }
            set { this.m_StrName = value; }
        }


        public CogColorConstants EColor
        {
            get { return this.m_EColor; }
            set { this.m_EColor = value; }
        }


        public CSubStanceData OXLength
        {
            get { return this.m_OXLength; }
        }


        public CSubStanceData OYLength
        {
            get { return this.m_OYLength; }
        }


        public CSubStanceData OPerimeter
        {
            get { return this.m_OPerimeter; }
        }


        public CSubStanceData OArea
        {
            get { return this.m_OArea; }
        }


        public CSubStanceData OElongation
        {
            get { return this.m_OElongation; }
        }
        #endregion


        #region CONSTRUCTOR & DESTRUCTOR
        public CSubStanceFilter()
        {
            try
            {
                this.m_OXLength = new CSubStanceData(ESUBSTANCE.X_LENGTH);
                this.m_OYLength = new CSubStanceData(ESUBSTANCE.Y_LENGTH);
                this.m_OPerimeter = new CSubStanceData(ESUBSTANCE.PERIMETER);
                this.m_OArea = new CSubStanceData(ESUBSTANCE.AREA);
                this.m_OElongation = new CSubStanceData(ESUBSTANCE.ELONGATION);
            }
            catch (Exception ex)
            {
                CError.Throw(ex);
            }
        }


        public CSubStanceFilter(CSubStanceFilter OSource)
        {
            try
            {
                this.m_StrName = OSource.m_StrName;
                this.m_EColor = OSource.m_EColor;

                this.m_OXLength = new CSubStanceData(OSource.m_OXLength);
                this.m_OYLength = new CSubStanceData(OSource.m_OYLength);
                this.m_OPerimeter = new CSubStanceData(OSource.m_OPerimeter);
                this.m_OArea = new CSubStanceData(OSource.m_OArea);
                this.m_OElongation = new CSubStanceData(OSource.m_OElongation);
            }
            catch (Exception ex)
            {
                CError.Throw(ex);
            }
        }
        #endregion


        #region FUNCTION
        public bool IsMatch(double F64XLength, double F64YLength, double F64Perimeter, double F64Area, double F64Elongation)
        {
            bool BResult = false;

            try
            {
                if (this.m_OXLength.IsMatch(F64XLength) == false) return BResult;
                if (this.m_OYLength.IsMatch(F64YLength) == false) return BResult;
                if (this.m_OPerimeter.IsMatch(F64Perimeter) == false) return BResult;
                if (this.m_OArea.IsMatch(F64Area) == false) return BResult;
                if (this.m_OElongation.IsMatch(F64Elongation) == false) return BResult;

                BResult = true;
            }
            catch (Exception ex)
            {
                CError.Throw(ex);
            }

            return BResult;
        }


        public void Copy(CSubStanceFilter OSource)
        {
            try
            {
                this.m_EColor = OSource.m_EColor;

                this.m_OXLength.Copy(OSource.m_OXLength);
                this.m_OYLength.Copy(OSource.m_OYLength);
                this.m_OPerimeter.Copy(OSource.m_OPerimeter);
                this.m_OArea.Copy(OSource.m_OArea);
                this.m_OElongation.Copy(OSource.m_OElongation);
            }
            catch (Exception ex)
            {
                CError.Throw(ex);
            }
        }
        #endregion
    }


    public enum ESUBSTANCE : byte
    {
        X_LENGTH = 0x00,
        Y_LENGTH,
        PERIMETER,
        AREA,
        ELONGATION,
        NONE = 0xFF
    }
}
