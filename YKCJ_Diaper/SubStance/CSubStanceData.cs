using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Jhjo.Common;

namespace YKCJ_Diaper
{
    public class CSubStanceData
    {
        #region VARIABLE
        private ESUBSTANCE m_EKind = ESUBSTANCE.NONE;

        private bool m_BEnabled = true;
        private bool m_BEnabledMin = true;
        private double m_F64Min = 0;
        private bool m_BEnabledMax = true;
        private double m_F64Max = 100;
        #endregion


        #region PROPERTIES
        public ESUBSTANCE EKind
        {
            get { return this.m_EKind; }
            set { this.m_EKind = value; }
        }


        public bool BEnabled
        {
            get { return this.m_BEnabled; }
            set { this.m_BEnabled = value; }
        }


        public bool BEnabledMin
        {
            get { return this.m_BEnabledMin; }
            set { this.m_BEnabledMin = value; }
        }


        public double F64Min
        {
            get { return this.m_F64Min; }
            set { this.m_F64Min = value; }
        }


        public bool BEnabledMax
        {
            get { return this.m_BEnabledMax; }
            set { this.m_BEnabledMax = value; }
        }


        public double F64Max
        {
            get { return this.m_F64Max; }
            set { this.m_F64Max = value; }
        }
        #endregion


        #region CONSTRUCTOR & DESTRUCTOR
        public CSubStanceData(ESUBSTANCE EKind)
        {
            try
            {
                this.m_EKind = EKind;
            }
            catch (Exception ex)
            {
                CError.Throw(ex);
            }
        }


        public CSubStanceData(CSubStanceData OSource)
        {
            try
            {
                this.m_EKind = OSource.m_EKind;

                this.m_BEnabled = OSource.m_BEnabled;
                this.m_BEnabledMin = OSource.m_BEnabledMin;
                this.m_F64Min = OSource.m_F64Min;
                this.m_BEnabledMax = OSource.m_BEnabledMax;
                this.m_F64Max = OSource.m_F64Max;
            }
            catch (Exception ex)
            {
                CError.Throw(ex);
            }
        }
        #endregion


        #region FUNCTION
        public bool IsMatch(double F64Value)
        {
            bool BResult = true;

            try
            {
                if (this.m_BEnabled == true)
                {
                    if ((this.m_BEnabledMin == true) && (this.m_BEnabledMax == true))
                    {
                        if ((F64Value < this.m_F64Min) || (F64Value > this.m_F64Max))
                        {
                            BResult = false;
                        }
                    }
                    else
                    {
                        if (this.m_BEnabledMin == true)
                        {
                            if (F64Value < this.m_F64Min)
                            {
                                BResult = false;
                            }
                        }
                        else if (this.m_BEnabledMax == true)
                        {
                            if (F64Value > this.m_F64Max)
                            {
                                BResult = false;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                CError.Throw(ex);
            }

            return BResult;
        }


        public void Copy(CSubStanceData OSource)
        {
            try
            {
                this.m_BEnabled = OSource.m_BEnabled;
                this.m_BEnabledMin = OSource.m_BEnabledMin;
                this.m_F64Min = OSource.m_F64Min;
                this.m_BEnabledMax = OSource.m_BEnabledMax;
                this.m_F64Max = OSource.m_F64Max;
            }
            catch (Exception ex)
            {
                CError.Throw(ex);
            }
        }
        #endregion
    }
}
