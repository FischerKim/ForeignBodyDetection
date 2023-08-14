using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Jhjo.Common;
using Daekhon.Common;

namespace YKCJ_Diaper
{
    public class CAcquisitionManager
    {
        #region SIGNLETON
        private static CAcquisitionManager Src_It = null;

        public static CAcquisitionManager It
        {
            get
            {
                CAcquisitionManager OResult = null;

                try
                {
                    if (CAcquisitionManager.Src_It == null)
                    {
                        CAcquisitionManager.Src_It = new CAcquisitionManager();
                    }

                    OResult = CAcquisitionManager.Src_It;
                }
                catch (Exception ex)
                {
                    CError.Throw(ex);
                }

                return OResult;
            }
        }
        #endregion


        #region VARIABLE
        private CSimulator m_OCamera = null;
        #endregion


        #region PROPERTIES
        public CSimulator OCameara
        {
            get { return this.m_OCamera; }
        }
        #endregion


        #region CONSTRUCTOR & DESTRUCTOR
        protected CAcquisitionManager() { }


        ~CAcquisitionManager()
        {
            try
            {
                this.Dispose();
            }
            catch (Exception ex)
            {
                CError.Ignore(ex);
            }
        }
        #endregion


        #region FUNCTION
        public void Load(CCameraInfo OCameraInfo)
        {
            try
            {
                this.m_OCamera = new CSimulator(".\\Simulator");

                ////Width
                //if ((this.m_OCamera.I32WidthMin <= CEnvironment.It.I32CameraWidth) &&
                //    (this.m_OCamera.I32WidthMax >= CEnvironment.It.I32CameraWidth))
                //{
                //    this.m_OCamera.I32Width = CEnvironment.It.I32CameraWidth;
                //}
                ////Height
                //if ((this.m_OCamera.I32HeightMin <= CEnvironment.It.I32CameraHeight) &&
                //    (this.m_OCamera.I32HeightMax >= CEnvironment.It.I32CameraHeight))
                //{
                //    this.m_OCamera.I32Height = CEnvironment.It.I32CameraHeight;
                //}
                //this.m_OCamera.BCenterX = true;
                ////Gain
                //if ((this.m_OCamera.I32GainMin <= CEnvironment.It.I32CameraGain) &&
                //    (this.m_OCamera.I32GainMax >= CEnvironment.It.I32CameraGain))
                //{
                //    this.m_OCamera.I32Gain = CEnvironment.It.I32CameraGain;
                //}
                ////ExposureTime
                //if ((this.m_OCamera.I32ExposureTimeMin <= CEnvironment.It.I32CameraExposureTime) &&
                //    (this.m_OCamera.I32ExposureTimeMax >= CEnvironment.It.I32CameraExposureTime))
                //{
                //    this.m_OCamera.I32ExposureTime = CEnvironment.It.I32CameraExposureTime;
                //}
                ////AcquisitionStart
                //this.m_OCamera.StrTriggerSelector = "AcquisitionStart";
                //this.m_OCamera.StrTriggerMode = CEnvironment.It.StrCameraAcquisitionMode;
                //this.m_OCamera.StrTriggerSource = CEnvironment.It.StrCameraAcquisitionSource;
                ////FrameStart
                //this.m_OCamera.StrTriggerSelector = "FrameStart";
                //this.m_OCamera.StrTriggerMode = CEnvironment.It.StrCameraFrameMode;
                //this.m_OCamera.StrTriggerSource = CEnvironment.It.StrCameraFrameSource;
                ////LineStart
                //this.m_OCamera.StrTriggerSelector = "LineStart";
                //this.m_OCamera.StrTriggerMode = CEnvironment.It.StrCameraLineMode;
                //this.m_OCamera.StrTriggerSource = CEnvironment.It.StrCameraLineSource;
            }
            catch (Exception ex)
            {
                CError.Throw(ex);
            }
        }


        public void Dispose()
        {
            try
            {
                if (this.m_OCamera != null)
                {
                    this.m_OCamera.Dispose();
                    this.m_OCamera = null;
                }
            }
            catch (Exception ex)
            {
                CError.Ignore(ex);
            }
        }
        #endregion
    }
}
