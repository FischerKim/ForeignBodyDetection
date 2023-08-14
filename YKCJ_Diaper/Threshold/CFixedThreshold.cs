using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Jhjo.Common;

namespace YKCJ_Diaper
{
    public class CFixedThreshold : IThreshold
    {
        #region VARIABLE
        private int m_I32Value = 100;
        #endregion


        #region PROPERTIES
        public EBLOB_THRESHOLD EKind
        {
            get { return EBLOB_THRESHOLD.Fixed; }
        }


        public string StrValueName
        {
            get { return "명암"; }
        }


        public int I32Value
        {
            get { return this.m_I32Value; }
            set { this.m_I32Value = value; }
        }
        #endregion


        #region CONSTRUCTOR & DESTRUCTOR
        public CFixedThreshold() { }


        public CFixedThreshold(IThreshold OSource)
        {
            try
            {
                CFixedThreshold OThreshold = (CFixedThreshold)OSource;
                this.m_I32Value = OThreshold.m_I32Value;
            }
            catch (Exception ex)
            {
                CError.Throw(ex);
            }
        }
        #endregion


        #region FUNCTION
        public void Load() { }
        #endregion
    }
}
