using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Daekhon.Common;
using Jhjo.Common;

namespace YKCJ_Diaper
{
    public class CPatternResult : IResult, IDiaperFault
    {
        #region VARIABLE
        private int m_I32Index = 0;

        private bool m_BInspected = false;
        private bool m_BOK = true;
        private EIO m_EIOSignal = EIO.NONE;

        private double m_F64Score = 0;
        private double m_F64X = 0;
        private double m_F64Y = 0;
        #endregion


        #region PROPERTIES
        public int I32Index
        {
            get { return this.m_I32Index; }
        }


        public ETOOL ETool
        {
            get { return ETOOL.PATTERN; }
        }


        public bool BInspected
        {
            get { return this.m_BInspected; }
            set { this.m_BInspected = value; }
        }


        public bool BOK
        {
            get { return this.m_BOK; }
            set { this.m_BOK = value; }
        }


        public EIO EIOSignal
        {
            get { return this.m_EIOSignal; }
            set { this.m_EIOSignal = value; }
        }


        public double F64Score
        {
            get { return this.m_F64Score; }
            set { this.m_F64Score = value; }
        }


        public double F64X
        {
            get { return this.m_F64X; }
            set { this.m_F64X = value; }
        }


        public double F64Y
        {
            get { return this.m_F64Y; }
            set { this.m_F64Y = value; }
        }


        public double F64Value
        {
            get { return this.m_F64Score; }
        }


        public string StrReferance
        {
            get { return string.Empty; }
        }
        #endregion


        #region CONSTRUCTOR & DESTRUCTOR
        public CPatternResult(int I32Index)
        {
            try
            {
                this.m_I32Index = I32Index;
            }
            catch (Exception ex)
            {
                CError.Throw(ex);
            }
        }
        #endregion
    }
}
