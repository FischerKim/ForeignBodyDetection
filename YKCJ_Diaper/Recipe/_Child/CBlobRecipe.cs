using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cognex.VisionPro.Blob;
using Jhjo.Common;
using Daekhon.Common;
using Cognex.VisionPro;

namespace YKCJ_Diaper
{
    public class CBlobRecipe : IRecipe
    {
        #region VARIABLE
        private string m_StrName = string.Empty;
        private int m_I32Index = 0;

        private bool m_BEnabled = false;
        private string m_StrDescription = string.Empty;
        private CogBlobSegmentationPolarityConstants m_EPolarity = CogBlobSegmentationPolarityConstants.DarkBlobs;
        private IThreshold m_OThreshold = null;
        private int m_I32Offset = 10;
        private int m_I32MinSize = 10;
        private EIO m_EIOSignal = EIO.NONE;
        private AROI m_OROI = null;
        private string m_StrMD = "없음";
        private string m_StrCD = "없음";
        private string m_StrAlignmentTarget = "없음";
        private string m_StrAlignmentIndex = "없음";
        private string m_StrAlignmentSource = "없음";
        #endregion


        #region PROPERTIES
        public string StrName
        {
            get { return this.m_StrName; }
            set { this.m_StrName = value; }
        }


        public int I32Index
        {
            get { return this.m_I32Index; }
        }


        public bool BEnabled
        {
            get { return this.m_BEnabled; }
            set { this.m_BEnabled = value; }
        }


        public string StrDescription
        {
            get { return this.m_StrDescription; }
            set { this.m_StrDescription = value; }
        }


        public CogBlobSegmentationPolarityConstants EPolarity
        {
            get { return this.m_EPolarity; }
            set { this.m_EPolarity = value; }
        }


        public IThreshold OThreshold
        {
            get { return this.m_OThreshold; }
            set { this.m_OThreshold = value; }
        }


        public int I32Offset
        {
            get { return this.m_I32Offset; }
            set { this.m_I32Offset = value; }
        }


        public int I32MinSize
        {
            get { return this.m_I32MinSize; }
            set { this.m_I32MinSize = value; }
        }


        public EIO EIOSignal
        {
            get { return this.m_EIOSignal; }
            set { this.m_EIOSignal = value; }
        }


        public AROI OROI
        {
            get { return this.m_OROI; }
            set { this.m_OROI = value; }
        }


        public string StrMD
        {
            get { return this.m_StrMD; }
            set { this.m_StrMD = value; }
        }


        public string StrCD
        {
            get { return this.m_StrCD; }
            set { this.m_StrCD = value; }
        }


        public string StrAlignmentTarget
        {
            get { return this.m_StrAlignmentTarget; }
            set { this.m_StrAlignmentTarget = value; }
        }


        public string StrAlignmentIndex
        {
            get { return this.m_StrAlignmentIndex; }
            set { this.m_StrAlignmentIndex = value; }
        }


        public string StrAlignmentSource
        {
            get { return this.m_StrAlignmentSource; }
            set { this.m_StrAlignmentSource = value; }
        }
        #endregion


        #region CONSTRUCTOR & DESTRUCTOR
        public CBlobRecipe(string StrName, int I32Index)
        {
            try
            {
                this.m_StrName = StrName;
                this.m_I32Index = I32Index;

                this.m_OThreshold = new CHistogramThreshold();
                this.m_OROI = new CROIRectangle();
            }
            catch (Exception ex)
            {
                CError.Throw(ex);
            }
        }


        public CBlobRecipe(CBlobRecipe OSource)
        {
            try
            {
                this.m_StrName = OSource.m_StrName;
                this.m_I32Index = OSource.m_I32Index;
                this.m_BEnabled = OSource.m_BEnabled;
                this.m_StrDescription = OSource.m_StrDescription;
                this.m_EPolarity = OSource.m_EPolarity;
                this.m_OThreshold = CThresholdFactory.GetThreshold(OSource.m_OThreshold);
                this.m_I32Offset = OSource.m_I32Offset;
                this.m_I32MinSize = OSource.m_I32MinSize;
                this.m_EIOSignal = OSource.m_EIOSignal;
                this.m_OROI = CROIFactory.GetROI(OSource.m_OROI);
                this.m_StrMD = OSource.m_StrMD;
                this.m_StrCD = OSource.m_StrCD;
                this.m_StrAlignmentTarget = OSource.m_StrAlignmentTarget;
                this.m_StrAlignmentIndex = OSource.m_StrAlignmentIndex;
                this.m_StrAlignmentSource = OSource.m_StrAlignmentSource;
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
                //if (this.m_BEnabled == true)
                //{
                    this.m_OThreshold.Load();

                    this.m_OROI.Create();
                    this.m_OROI.OGraphic.Color = CogColorConstants.Blue;
                    this.m_OROI.OGraphic.SelectedColor = CogColorConstants.Blue;
                //}
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


        public void Copy(CBlobRecipe OSource)
        {
            try
            {
                this.m_BEnabled = OSource.m_BEnabled;
                this.m_StrDescription = OSource.m_StrDescription;
                this.m_EPolarity = OSource.m_EPolarity;
                this.m_OThreshold = CThresholdFactory.GetThreshold(OSource.m_OThreshold);
                this.m_I32Offset = OSource.m_I32Offset;
                this.m_I32MinSize = OSource.m_I32MinSize;
                this.m_EIOSignal = OSource.m_EIOSignal;
                this.m_OROI = CROIFactory.GetROI(OSource.m_OROI);
                this.m_StrMD = OSource.m_StrMD;
                this.m_StrCD = OSource.m_StrCD;
                this.m_StrAlignmentTarget = OSource.m_StrAlignmentTarget;
                this.m_StrAlignmentIndex = OSource.m_StrAlignmentIndex;
                this.m_StrAlignmentSource = OSource.m_StrAlignmentSource;
            }
            catch (Exception ex)
            {
                CError.Throw(ex);
            }
        }
        #endregion
    }
}
