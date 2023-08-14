using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Daekhon.Common;
using Cognex.VisionPro;

namespace YKCJ_Diaper
{
    public class CDiaperFaultResult : IResult
    {
        #region VARIABLE
        private CImageInfo m_OImageInfo = null;
        private bool m_BInspected = false;
        private bool m_BOK = false;

        private CFollowResult[] m_ArrOMD = null;
        private CFollowResult[] m_ArrOCD = null;
        private CBlobResult[] m_ArrOBlob = null;
        private CPatternResult[] m_ArrOPattern = null;
        private IDiaperFault m_OFaultResult = null;

        private CogImage8Grey m_OZoomImage = null;
        private double m_F64Period = 0;

        private bool m_BIsBlobNG = false;
        private string m_StrBlobName = "알수없음";
        private CogColorConstants m_EColor = CogColorConstants.Red;
        private double m_F64BlobXLength = 0;
        private double m_F64BlobYLength = 0;
        private double m_F64BlobPerimeter = 0;
        private double m_F64BlobArea = 0;
        private double m_F64Elongation = 0;
        #endregion


        #region PROPERTIES
        public CImageInfo OImageInfo
        {
            get { return this.m_OImageInfo; }
            set { this.m_OImageInfo = value; }
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


        public CBlobResult[] ArrOBlob
        {
            get { return this.m_ArrOBlob; }
            set { this.m_ArrOBlob = value; }
        }


        public CPatternResult[] ArrOPattern
        {
            get { return this.m_ArrOPattern; }
            set { this.m_ArrOPattern = value; }
        }


        public CFollowResult[] ArrOMD
        {
            get { return this.m_ArrOMD; }
            set { this.m_ArrOMD = value; }
        }


        public CFollowResult[] ArrOCD
        {
            get { return this.m_ArrOCD; }
            set { this.m_ArrOCD = value; }
        }


        public IDiaperFault OFaultResult
        {
            get { return this.m_OFaultResult; }
            set { this.m_OFaultResult = value; }
        }


        public double F64Period
        {
            get { return this.m_F64Period; }
            set { this.m_F64Period = value; }
        }


        public bool BIsBlobNG
        {
            get { return this.m_BIsBlobNG; }
            set { this.m_BIsBlobNG = value; }
        }


        public string StrBlobName
        {
            get { return this.m_StrBlobName; }
            set { this.m_StrBlobName = value; }
        }


        public CogColorConstants EColor
        {
            get { return this.m_EColor; }
            set { this.m_EColor = value; }
        }


        public double F64BlobXLength
        {
            get { return this.m_F64BlobXLength; }
            set { this.m_F64BlobXLength = value; }
        }


        public double F64BlobYLength
        {
            get { return this.m_F64BlobYLength; }
            set { this.m_F64BlobYLength = value; }
        }


        public double F64BlobPerimeter
        {
            get { return this.m_F64BlobPerimeter; }
            set { this.m_F64BlobPerimeter = value; }
        }


        public double F64BlobArea
        {
            get { return this.m_F64BlobArea; }
            set { this.m_F64BlobArea = value; }
        }


        public double F64Elongation
        {
            get { return this.m_F64Elongation; }
            set { this.m_F64Elongation = value; }
        }


        public CogImage8Grey OZoomImage
        {
            get { return this.m_OZoomImage; }
            set { this.m_OZoomImage = value; }
        }
        #endregion
    }
}
