using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Daekhon.Common;
using Jhjo.Common;
using Cognex.VisionPro.Blob;

namespace YKCJ_Diaper
{
    public class CBlobResult : IResult, IDiaperFault
    {
        #region VARIABLE
        private int m_I32Index = 0;

        private bool m_BInspected = false;
        private bool m_BOK = true;
        private EIO m_EIOSignal = EIO.NONE;

        private CogBlobSegmentationPolarityConstants m_EPolarity = CogBlobSegmentationPolarityConstants.DarkBlobs;
        private bool m_BHasThreshold = false;
        private int m_I32CurrentThreshold = 0;
        private int m_I32AverageThreshold = 0;
        
        private double m_F64X = 0;
        private double m_F64Y = 0;
        private double m_F64Size = 0;
        #endregion


        #region PROPERTIES
        public int I32Index
        {
            get { return this.m_I32Index; }
        }


        public ETOOL ETool
        {
            get { return ETOOL.BLOB; }
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


        public CogBlobSegmentationPolarityConstants EPolarity
        {
            get { return this.m_EPolarity; }
            set { this.m_EPolarity = value; }
        }


        public bool BHasThreshold
        {
            get { return this.m_BHasThreshold; }
            set { this.m_BHasThreshold = value; }
        }


        public int I32CurrentThreshold
        {
            get { return this.m_I32CurrentThreshold; }
            set { this.m_I32CurrentThreshold = value; }
        }


        public int I32AverageThreshold
        {
            get { return this.m_I32AverageThreshold; }
            set { this.m_I32AverageThreshold = value; }
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


        public double F64Size
        {
            get { return this.m_F64Size; }
            set { this.m_F64Size = value; }
        }


        public double F64Value
        {
            get { return this.m_F64Size; }
        }


        public string StrReferance
        {
            get
            {
                string StrResult = string.Empty;

                try
                {
                    if (this.m_EPolarity == CogBlobSegmentationPolarityConstants.DarkBlobs)
                    {
                        StrResult = "D(" + (this.m_I32CurrentThreshold - this.m_I32AverageThreshold) + ")"; 
                    }
                    else
                    {
                        StrResult = "W(" + (this.m_I32CurrentThreshold - this.m_I32AverageThreshold) + ")"; 
                    }
                }
                catch (Exception ex)
                {
                    CError.Throw(ex);
                }

                return StrResult;
            }
        }
        #endregion


        #region CONSTRUCTOR & DESTRUCTOR
        public CBlobResult(int I32Index)
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
