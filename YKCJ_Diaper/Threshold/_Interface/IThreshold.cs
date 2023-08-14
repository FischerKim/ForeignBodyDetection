using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YKCJ_Diaper
{
    public interface IThreshold
    {
        #region PROPERTIES
        EBLOB_THRESHOLD EKind { get; }
        string StrValueName { get; }
        int I32Value { get; set; }
        #endregion


        #region FUNCTION
        void Load();
        #endregion
    }


    #region ENUM
    public enum EBLOB_THRESHOLD
    {
        Histogram = 0x00,
        Fixed
    }
    #endregion
}
