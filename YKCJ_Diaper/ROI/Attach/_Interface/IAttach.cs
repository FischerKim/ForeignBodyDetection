using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cognex.VisionPro;

namespace YKCJ_Diaper
{
    public interface IAttach
    {
        #region PROPERTIES
        ICogGraphicInteractive OGraphic { get; }
        string StrTag { get; set; }

        EATTACH_ALIGNMENT EAlignment { get; set; }
        EATTACH_LINEALIGNMENT ELineAlignment { get; set; }
        double F64AdjustX { get; set; }
        double F64AdjustY { get; set; }
        #endregion


        #region FUNCTION
        void Alignment(CogRectangle OBound);
        #endregion
    }


    #region ENUM
    public enum EATTACH_ALIGNMENT
    {
        LEFT = 0x00,
        CENTER,
        RIGHT
    }


    public enum EATTACH_LINEALIGNMENT
    {
        TOP = 0x00,
        MIDDLE,
        BOTTOM
    }
    #endregion
}
