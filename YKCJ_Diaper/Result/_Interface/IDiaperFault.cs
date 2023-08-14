using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YKCJ_Diaper
{
    public interface IDiaperFault
    {
        #region PROPERTIES
        ETOOL ETool { get; }
        int I32Index { get; }
        EIO EIOSignal { get; }
        double F64X { get;}
        double F64Y { get;}
        double F64Value { get; }
        string StrReferance { get; }
        #endregion
    }


    #region ENUM
    public enum ETOOL : byte
    {
        NONE = 0x00,
        BLOB,
        PATTERN
    }
    #endregion
}
