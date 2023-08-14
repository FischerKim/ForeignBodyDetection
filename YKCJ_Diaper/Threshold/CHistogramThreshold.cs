using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Jhjo.Common;

namespace YKCJ_Diaper
{
    public class CHistogramThreshold : IThreshold
    {
        #region VARIABLE
        private List<int> m_LstI32Value = null;
        private int m_I32Value = 30;
        #endregion


        #region PROPERTIES
        public EBLOB_THRESHOLD EKind
        {
            get { return EBLOB_THRESHOLD.Histogram; }
        }


        public string StrValueName
        {
            get { return "이미지 수"; }
        }


        public int I32Value
        {
            get { return this.m_I32Value; }
            set { this.m_I32Value = value; }
        }
        #endregion


        #region CONSTRUCTOR & DESTRUCTOR
        public CHistogramThreshold() { }


        public CHistogramThreshold(IThreshold OSource)
        {
            try
            {
                CHistogramThreshold OThreshold = (CHistogramThreshold)OSource;
                this.m_I32Value = OThreshold.m_I32Value;
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
                this.m_LstI32Value = new List<int>();
            }
            catch (Exception ex)
            {
                CError.Throw(ex);
            }
        }


        public int GetThreshold(int I32Threshold)
        {
            int I32Result = 0;

            try
            {
                int I32Total = I32Threshold;
                foreach (int _Item in this.m_LstI32Value)
                {
                    I32Total += _Item;
                };

                I32Result = Convert.ToInt32((float)I32Total / (this.m_LstI32Value.Count + 1));
            }
            catch (Exception ex)
            {
                CError.Throw(ex);
            }

            return I32Result;
        }


        public void Apply(int I32Threshold)
        {
            try
            {
                if (this.m_LstI32Value.Count == this.m_I32Value)
                {
                    this.m_LstI32Value.RemoveAt(0);
                }
                this.m_LstI32Value.Add(I32Threshold);
            }
            catch (Exception ex)
            {
                CError.Throw(ex);
            }
        }
        #endregion
    }
}
