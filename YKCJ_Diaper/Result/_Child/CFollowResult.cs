using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Daekhon.Common;
using Jhjo.Common;

namespace YKCJ_Diaper
{
    public class CFollowResult : IResult
    {
        #region VARIABLE
        private EFOLLOW m_EKind = EFOLLOW.MD;
        private int m_I32Index = 0;
        
        private bool m_BInspected = false;
        private bool m_BOK = false;
        
        private double m_F64X = 0;
        private double m_F64Y = 0;
        private double m_F64Differ = 0;
        #endregion


        #region PROPERTIES
        public EFOLLOW EKind
        {
            get { return this.m_EKind;}
        }


        public int I32Index
        {
            get { return this.m_I32Index; }
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


        public double F64Differ
        {
            get { return this.m_F64Differ; }
            set { this.m_F64Differ = value; }
        }
        #endregion


        #region CONSTRUCTOR & DESTRUCTOR
        public CFollowResult(EFOLLOW EKind, int I32Index)
        {
            try
            {
                this.m_EKind = EKind;
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
