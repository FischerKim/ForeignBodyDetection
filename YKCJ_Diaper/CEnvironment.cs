using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Jhjo.Common;

namespace YKCJ_Diaper
{
    public class CEnvironment
    {
        #region SINGLE TON
        private static CEnvironment Src_It = null;


        public static CEnvironment It
        {
            get
            {
                CEnvironment OResult = null;

                try
                {
                    if (CEnvironment.Src_It == null)
                    {
                        CEnvironment.Src_It = new CEnvironment();
                    }

                    OResult = CEnvironment.Src_It;
                }
                catch (Exception ex)
                {
                    CError.Throw(ex);
                }

                return OResult;
            }
        }
        #endregion


        #region CONST
        private const string SYSTEM_MACHINE = "SYSTEM_MACHINE";
        private const string SYSTEM_OBJECT = "SYSTEM_OBJECT";
        private const string SYSTEM_RECIPE = "SYSTEM_RECIPE";
        private const string SYSTEM_LEFT = "SYSTEM_LEFT";
        private const string SYSTEM_RIGHT = "SYSTEM_RIGHT";
        private const string SYSTEM_T0TAL_COUNT = "SYSTEM_TOTAL_COUNT";
        private const string SYSTEM_OK_COUNT = "SYSTEM_OK_COUNT";
        private const string SYSTEM_NG_COUNT = "SYSTEM_NG_COUNT";

        private const string CAMERA_WIDTH = "CAMERA_WIDTH";
        private const string CAMERA_HEIGHT = "CAMERA_HEIGHT";
        private const string CAMERA_GAIN = "CAMERA_GAIN";
        private const string CAMERA_EXPOSURE_TIME = "CAMERA_EXPOSURE_TIME";
        private const string CAMERA_ACQUISITION_MODE = "CAMERA_ACQUISITION_MODE";
        private const string CAMERA_ACQUISITION_SOURCE = "CAMERA_ACQUISITION_SOURCE";
        private const string CAMERA_FRAME_MODE = "CAMERA_FRAME_MODE";
        private const string CAMERA_FRAME_SOURCE = "CAMERA_FRAME_SOURCE";
        private const string CAMERA_LINE_MODE = "CAMERA_LINE_MODE";
        private const string CAMERA_LINE_SOURCE = "CAMERA_LINE_SOURCE";

        private const string CENTER_LINE_ENABLED = "CENTER_LINE_ENABLED";
        private const string CENTER_LINE_X = "CENTER_LINE_X";
        private const string CENTER_LINE_Y = "CENTER_LINE_Y";
        private const string EXPAND_VIEW_X = "EXPAND_VIEW_X";
        private const string EXPAND_VIEW_Y = "EXPAND_VIEW_Y";
        private const string EXPAND_VIEW_WIDTH = "EXPAND_VIEW_WIDTH";
        private const string EXPAND_VIEW_HEIGHT = "EXPAND_VIEW_HEIGHT";
        private const string PIXEL_WIDTH = "PIXEL_WIDTH";
        private const string PIXEL_HEIGHT = "PIXEL_HEIGHT";
        #endregion


        #region DELEGATE & EVENT
        public delegate void ChangedSystemInfoHandler();
        public ChangedSystemInfoHandler ChangedSystemInfo = null;
        
        public delegate void DirectionInfoChangedHandler();
        public DirectionInfoChangedHandler DirectionInfoChanged = null;

        public delegate void ChangedCenterLineHandler();
        public ChangedCenterLineHandler ChangedCenterLine = null;

        public delegate void ChangedExpandViewHandler();
        public ChangedExpandViewHandler ChangedExpandView = null;
        #endregion


        #region PROPERTIES
        public string StrSystemMachine
        {
            get { return this.GetData(CEnvironment.SYSTEM_MACHINE); }
            set { this.SetData(CEnvironment.SYSTEM_MACHINE, value); }
        }


        public string StrSystemObject
        {
            get { return this.GetData(CEnvironment.SYSTEM_OBJECT); }
            set { this.SetData(CEnvironment.SYSTEM_OBJECT, value); }
        }


        public string StrSystemLeft
        {
            get { return this.GetData(CEnvironment.SYSTEM_LEFT); }
            set { this.SetData(CEnvironment.SYSTEM_LEFT, value); }
        }


        public string StrSystemRight
        {
            get { return this.GetData(CEnvironment.SYSTEM_RIGHT); }
            set { this.SetData(CEnvironment.SYSTEM_RIGHT, value); }
        }


        public string StrSystemRecipe
        {
            get { return this.GetData(CEnvironment.SYSTEM_RECIPE); }
            set { this.SetData(CEnvironment.SYSTEM_RECIPE, value); }
        }


        public ulong U64TotalCount
        {
            get { return Convert.ToUInt64(this.GetData(CEnvironment.SYSTEM_T0TAL_COUNT)); }
            set { this.SetData(CEnvironment.SYSTEM_T0TAL_COUNT, value); }
        }


        public ulong U64OKCount
        {
            get { return Convert.ToUInt64(this.GetData(CEnvironment.SYSTEM_OK_COUNT)); }
            set { this.SetData(CEnvironment.SYSTEM_OK_COUNT, value); }
        }


        public ulong U64NGCount
        {
            get { return Convert.ToUInt64(this.GetData(CEnvironment.SYSTEM_NG_COUNT)); }
            set { this.SetData(CEnvironment.SYSTEM_NG_COUNT, value); }
        }


        public int I32CameraWidth
        {
            get { return Convert.ToInt32(this.GetData(CEnvironment.CAMERA_WIDTH)); }
            set { this.SetData(CEnvironment.CAMERA_WIDTH, value); }
        }


        public int I32CameraHeight
        {
            get { return Convert.ToInt32(this.GetData(CEnvironment.CAMERA_HEIGHT)); }
            set { this.SetData(CEnvironment.CAMERA_HEIGHT, value); }
        }

        public int I32CameraGain
        {
            get { return Convert.ToInt32(this.GetData(CEnvironment.CAMERA_GAIN)); }
            set { this.SetData(CEnvironment.CAMERA_GAIN, value); }
        }


        public int I32CameraExposureTime
        {
            get { return Convert.ToInt32(this.GetData(CEnvironment.CAMERA_EXPOSURE_TIME)); }
            set { this.SetData(CEnvironment.CAMERA_EXPOSURE_TIME, value); }
        }


        public string StrCameraAcquisitionMode
        {
            get { return this.GetData(CEnvironment.CAMERA_ACQUISITION_MODE); }
            set { this.SetData(CEnvironment.CAMERA_ACQUISITION_MODE, value); }
        }


        public string StrCameraAcquisitionSource
        {
            get { return this.GetData(CEnvironment.CAMERA_ACQUISITION_SOURCE); }
            set { this.SetData(CEnvironment.CAMERA_ACQUISITION_SOURCE, value); }
        }


        public string StrCameraFrameMode
        {
            get { return this.GetData(CEnvironment.CAMERA_FRAME_MODE); }
            set { this.SetData(CEnvironment.CAMERA_FRAME_MODE, value); }
        }


        public string StrCameraFrameSource
        {
            get { return this.GetData(CEnvironment.CAMERA_FRAME_SOURCE); }
            set { this.SetData(CEnvironment.CAMERA_FRAME_SOURCE, value); }
        }


        public string StrCameraLineMode
        {
            get { return this.GetData(CEnvironment.CAMERA_LINE_MODE); }
            set { this.SetData(CEnvironment.CAMERA_LINE_MODE, value); }
        }


        public string StrCameraLineSource
        {
            get { return this.GetData(CEnvironment.CAMERA_LINE_SOURCE); }
            set { this.SetData(CEnvironment.CAMERA_LINE_SOURCE, value); }
        }


        public bool BCenterLineEnabled
        {
            get { return Convert.ToBoolean(this.GetData(CEnvironment.CENTER_LINE_ENABLED)); }
            set { this.SetData(CEnvironment.CENTER_LINE_ENABLED, value); }
        }


        public double F64CenterLineX
        {
            get { return Convert.ToDouble(this.GetData(CEnvironment.CENTER_LINE_X)); }
            set { this.SetData(CEnvironment.CENTER_LINE_X, value); }
        }


        public double F64CenterLineY
        {
            get { return Convert.ToDouble(this.GetData(CEnvironment.CENTER_LINE_Y)); }
            set { this.SetData(CEnvironment.CENTER_LINE_Y, value); }
        }


        public double F64ExpandViewX
        {
            get { return Convert.ToDouble(this.GetData(CEnvironment.EXPAND_VIEW_X)); }
            set { this.SetData(CEnvironment.EXPAND_VIEW_X, value); }
        }


        public double F64ExpandViewY
        {
            get { return Convert.ToDouble(this.GetData(CEnvironment.EXPAND_VIEW_Y)); }
            set { this.SetData(CEnvironment.EXPAND_VIEW_Y, value); }
        }


        public double F64ExpandViewWidth
        {
            get { return Convert.ToDouble(this.GetData(CEnvironment.EXPAND_VIEW_WIDTH)); }
            set { this.SetData(CEnvironment.EXPAND_VIEW_WIDTH, value); }
        }


        public double F64ExpandViewHeight
        {
            get { return Convert.ToDouble(this.GetData(CEnvironment.EXPAND_VIEW_HEIGHT)); }
            set { this.SetData(CEnvironment.EXPAND_VIEW_HEIGHT, value); }
        }


        public double F64PixelWidth
        {
            get { return Convert.ToDouble(this.GetData(CEnvironment.PIXEL_WIDTH)); }
            set { this.SetData(CEnvironment.PIXEL_WIDTH, value); }
        }


        public double F64PixelHeight
        {
            get { return Convert.ToDouble(this.GetData(CEnvironment.PIXEL_HEIGHT)); }
            set { this.SetData(CEnvironment.PIXEL_HEIGHT, value); }
        }
        #endregion


        #region CONSTRUCTOR & DESTRUCTOR
        protected CEnvironment() { }
        #endregion


        #region FUNCTION
        private string GetData(string StrName)
        {
            string StrResult = string.Empty;

            try
            {
                int I32RowIndex = CDB.It[CDB.TABLE_ENVIRONMENT].SelectRowIndex(CDB.ENVIRONMENT_NAME, StrName);
                object OValue = CDB.It[CDB.TABLE_ENVIRONMENT].Select(I32RowIndex, CDB.ENVIRONMENT_VALUE);

                if (OValue != null) StrResult = OValue.ToString();
            }
            catch (Exception ex)
            {
                CError.Throw(ex);
            }

            return StrResult;
        }


        private void SetData(string StrName, object OValue)
        {
            try
            {
                int I32RowIndex = CDB.It[CDB.TABLE_ENVIRONMENT].SelectRowIndex(CDB.ENVIRONMENT_NAME, StrName);
                CDB.It[CDB.TABLE_ENVIRONMENT].Update(I32RowIndex, CDB.ENVIRONMENT_VALUE, OValue.ToString());
            }
            catch (Exception ex)
            {
                CError.Throw(ex);
            }
        }


        public void Commit()
        {
            try
            {
                CDB.It[CDB.TABLE_ENVIRONMENT].Commit();
            }
            catch (Exception ex)
            {
                CError.Throw(ex);
            }
        }


        public void OnChangedSystemInfo()
        {
            try
            {
                if (this.ChangedSystemInfo != null)
                {
                    this.ChangedSystemInfo();
                }
            }
            catch (Exception ex)
            {
                CError.Throw(ex);
            }
        }


        public void OnChangedDirectionInfo()
        {
            try
            {
                if (this.DirectionInfoChanged != null)
                {
                    this.DirectionInfoChanged();
                }
            }
            catch (Exception ex)
            {
                CError.Throw(ex);
            }
        }


        public void OnChangedCenterLine()
        {
            try
            {
                if (this.ChangedCenterLine != null)
                {
                    this.ChangedCenterLine();
                }
            }
            catch (Exception ex)
            {
                CError.Throw(ex);
            }
        }


        public void OnChangedExpandView()
        {
            try
            {
                if (this.ChangedExpandView != null)
                {
                    this.ChangedExpandView();
                }
            }
            catch (Exception ex)
            {
                CError.Throw(ex);
            }
        }
        #endregion
    }
}
