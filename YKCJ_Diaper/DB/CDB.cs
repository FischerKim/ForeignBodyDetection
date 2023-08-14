using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Jhjo.DB;
using Jhjo.Common;

namespace YKCJ_Diaper
{
    public class CDB : ADB
    {
        #region SIGNLE TON
        protected static CDB Src_It = null;
        public static CDB It
        {
            get
            {
                CDB OResult = null;

                try
                {
                    if (CDB.Src_It == null)
                    {
                        CDB.Src_It = new CDB();
                    }

                    OResult = CDB.Src_It;
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
        public const string TABLE_ENVIRONMENT = "ENVIRONMENT";
        public const string ENVIRONMENT_NAME = "NAME";
        public const string ENVIRONMENT_VALUE = "VALUE";

        public const string TABLE_RECIPE_LIST = "RECIPE_LIST";
        public const string RECIPE_LIST_NAME = "NAME";
        public const string RECIPE_LIST_CENTER_LINE_ENABLED = "CENTER_LINE_ENABLED";
        public const string RECIPE_LIST_CENTER_LINE_X = "CENTER_LINE_X";
        public const string RECIPE_LIST_CENTER_LINE_Y = "CENTER_LINE_Y";
        public const string RECIPE_LIST_EXPAND_VIEW_ENABLED = "EXPAND_VIEW_ENABLED";
        public const string RECIPE_LIST_EXPAND_VIEW_X = "EXPAND_VIEW_X";
        public const string RECIPE_LIST_EXPAND_VIEW_Y = "EXPAND_VIEW_Y";
        public const string RECIPE_LIST_EXPAND_VIEW_WIDTH = "EXPAND_VIEW_WIDTH";
        public const string RECIPE_LIST_EXPAND_VIEW_HEIGHT = "EXPAND_VIEW_HEIGHT";

        public const string TABLE_BLOB_LIST = "BLOB_LIST";
        public const string BLOB_LIST_RECIPE = "RECIPE";
        public const string BLOB_LIST_INDEX = "INDEX";
        public const string BLOB_LIST_DESCRIPTION = "DESCRIPTION";
        public const string BLOB_LIST_ENABLED = "ENABLED";
        public const string BLOB_LIST_POLARITY = "POLARITY";
        public const string BLOB_LIST_THRESHOLD_TYPE = "THRESHOLD_TYPE";
        public const string BLOB_LIST_THRESHOLD_VALUE = "THRESHOLD_VALUE";
        public const string BLOB_LIST_OFFSET = "OFFSET";
        public const string BLOB_LIST_MIN_SIZE = "MIN_SIZE";
        public const string BLOB_LIST_IO = "IO";
        public const string BLOB_LIST_ALIGNMENT_TARGET = "ALIGNMENT_TARGET";
        public const string BLOB_LIST_ALIGNMENT_INDEX = "ALIGNMENT_INDEX";
        public const string BLOB_LIST_ALIGNMENT_SOURCE = "ALIGNMENT_SOURCE";
        public const string BLOB_LIST_FOLLOW_MD = "FOLLOW_MD";
        public const string BLOB_LIST_FOLLOW_CD = "FOLLOW_CD";
        public const string BLOB_LIST_ROI_KIND = "ROI_KIND";
        public const string BLOB_LIST_ROI_VALUE_COUNT = "ROI_VALUE_COUNT";
        public const string BLOB_LIST_ROI_VALUE = "ROI_VALUE";
        public const int BLOB_LIST_ROI_VALUE_LENGTH = 20;

        public const string TABLE_PATTERN_LIST = "PATTERN_LIST";
        public const string PATTERN_LIST_RECIPE = "RECIPE";
        public const string PATTERN_LIST_INDEX = "INDEX";
        public const string PATTERN_LIST_DESCRIPTION = "DESCRIPTION";
        public const string PATTERN_LIST_ENABLED = "ENABLED";
        public const string PATTERN_LIST_MIN_SCORE = "MIN_SCORE";
        public const string PATTERN_LIST_IO = "IO";
        public const string PATTERN_LIST_FOLLOW_MD = "FOLLOW_MD";
        public const string PATTERN_LIST_FOLLOW_CD = "FOLLOW_CD";
        public const string PATTERN_LIST_ROI_X = "ROI_X";
        public const string PATTERN_LIST_ROI_Y = "ROI_Y";
        public const string PATTERN_LIST_ROI_WIDTH = "ROI_WIDTH";
        public const string PATTERN_LIST_ROI_HEIGHT = "ROI_HEIGHT";

        public const string TABLE_FOLLOW_LIST = "FOLLOW_LIST";
        public const string FOLLOW_LIST_RECIPE = "RECIPE";
        public const string FOLLOW_LIST_KIND = "KIND";
        public const string FOLLOW_LIST_INDEX = "INDEX";
        public const string FOLLOW_LIST_DESCRIPTION = "DESCRIPTION";
        public const string FOLLOW_LIST_ENABLED = "ENABLED";
        public const string FOLLOW_LIST_POLARITY = "POLARITY";
        public const string FOLLOW_LIST_CONTRAST_THRESHOLD = "CONTRAST_THRESHOLD";
        public const string FOLLOW_LIST_HALF_PIXEL = "HALF_PIXEL";
        public const string FOLLOW_LIST_PRIORITY = "PRIORITY";
        public const string FOLLOW_LIST_ROI_CENTER_X = "ROI_CENTER_X";
        public const string FOLLOW_LIST_ROI_CENTER_Y = "ROI_CENTER_Y";
        public const string FOLLOW_LIST_ROI_LENGTH_X = "ROI_LENGTH_X";
        public const string FOLLOW_LIST_ROI_LENGTH_Y = "ROI_LENGTH_Y";
        public const string FOLLOW_LIST_ROI_ROTATION = "ROI_ROTATION";
        public const string FOLLOW_LIST_ROI_SKEW = "ROI_SKEW";
        public const string FOLLOW_LIST_STANDARD_POSITION = "STANDARD_POSITION";

        public const string TABLE_IO_LIST = "IO_LIST";
        public const string IO_LIST_NAME = "NAME";
        public const string IO_LIST_ENABLED = "ENABLED";
        public const string IO_LIST_PORT = "PORT";
        public const string IO_LIST_ON_INTERVAL = "ON_INTERVAL";
        public const string IO_LIST_OFF_INTERVAL = "OFF_INTERVAL";

        public const string TABLE_SUMMARY_RESET = "SUMMARY_RESET";
        public const string SUMMARY_RESET_INDEX = "INDEX";
        public const string SUMMARY_RESET_ENABLED = "ENABLED";
        public const string SUMMARY_RESET_HOUR = "HOUR";
        public const string SUMMARY_RESET_MINUTE = "MINUTE";

        public const string TABLE_SUBSTANCE_LIST = "SUBSTANCE_LIST";
        public const string SUBSTANCE_LIST_NAME = "NAME";
        public const string SUBSTANCE_LIST_COLOR = "COLOR";
        public const string SUBSTANCE_LIST_SEQ = "SEQ";

        public const string TABLE_SUBSTANCE_INFO = "SUBSTANCE_INFO";
        public const string SUBSTANCE_INFO_NAME = "NAME";
        public const string SUBSTANCE_INFO_FEATURE = "FEATURE";
        public const string SUBSTANCE_INFO_ENABLED = "ENABLED";
        public const string SUBSTANCE_INFO_MIN_ENABLED = "MIN_ENABLED";
        public const string SUBSTANCE_INFO_MIN = "MIN";
        public const string SUBSTANCE_INFO_MAX_ENABLED = "MAX_ENABLED";
        public const string SUBSTANCE_INFO_MAX = "MAX";
        
        public const string TABLE_REPORT = "REPORT";
        public const string REPORT_DATETIME = "DATETIME";
        public const string REPORT_RECIPE = "RECIPE";
        public const string REPORT_TOOL = "TOOL";
        public const string REPORT_INDEX = "INDEX";
        public const string REPORT_VALUE = "VALUE";
        public const string REPORT_X = "X";
        public const string REPORT_Y = "Y";
        public const string REPORT_REFERANCE = "REFERANCE";
        public const string REPORT_SUBSTANCE = "SUBSTANCE";
        public const string REPORT_SUBSTANCE_X_LENGTH = "SUBSTANCE_X_LENGTH";
        public const string REPORT_SUBSTANCE_Y_LENGTH = "SUBSTANCE_Y_LENGTH";
        public const string REPORT_SUBSTANCE_PERIMETER = "SUBSTANCE_PERIMETER";
        public const string REPORT_SUBSTANCE_AREA = "SUBSTANCE_AREA";
        public const string REPORT_SUBSTANCE_ELONGATION = "SUBSTANCE_ELONGATION";
        public const string REPORT_FILE = "FILE";
        #endregion


        #region FUNCTION
        protected override void InitDB() { }
        #endregion
    }
}
