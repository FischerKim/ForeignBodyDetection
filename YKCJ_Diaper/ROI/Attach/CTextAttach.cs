using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

using Cognex.VisionPro;
using Jhjo.Common;

namespace YKCJ_Diaper
{
    public class CTextAttach : IAttach
    {
        #region VARIABLE
        private CogGraphicLabel m_OText = null;
        private string m_StrTag = string.Empty;

        private EATTACH_ALIGNMENT m_EAlignment = EATTACH_ALIGNMENT.CENTER;
        private EATTACH_LINEALIGNMENT m_ELineAlignment = EATTACH_LINEALIGNMENT.MIDDLE;
        private double m_F64AdjustX = 0;
        private double m_F64AdjustY = 0;
        #endregion


        #region PROPERTIES
        public ICogGraphicInteractive OGraphic
        {
            get { return this.m_OText; }
        }


        public string StrTag
        {
            get { return this.m_StrTag; }
            set { this.m_StrTag = value; }
        }


        public CogGraphicLabel OText
        {
            get { return this.m_OText; }
            set { this.m_OText = value; }
        }


        public EATTACH_ALIGNMENT EAlignment
        {
            get { return this.m_EAlignment; }
            set { this.m_EAlignment = value; }
        }


        public EATTACH_LINEALIGNMENT ELineAlignment
        {
            get { return this.m_ELineAlignment; }
            set { this.m_ELineAlignment = value; }
        }


        public double F64AdjustX
        {
            get { return this.m_F64AdjustX; }
            set { this.m_F64AdjustX = value; }
        }


        public double F64AdjustY
        {
            get { return this.m_F64AdjustY; }
            set { this.m_F64AdjustY = value; }
        }
        #endregion


        #region CONSTRUCTOR & DESTRUCTOR
        public CTextAttach()
        {
            try
            {
                this.m_OText = new CogGraphicLabel();
                this.m_OText.Font = new Font("굴림", 10);
                this.m_OText.Alignment = CogGraphicLabelAlignmentConstants.BaselineCenter;
                this.m_OText.Color = CogColorConstants.Green;
                this.m_OText.Interactive = false;
            }
            catch (Exception ex)
            {
                CError.Throw(ex);
            }
        }
        #endregion


        #region FUNCTION
        public void Alignment(CogRectangle OBound)
        {
            try
            {
                double F64X = 0;
                double F64Y = 0;

                switch (this.m_EAlignment)
                {
                    case EATTACH_ALIGNMENT.LEFT:
                        F64X = OBound.X;
                        break;

                    case EATTACH_ALIGNMENT.CENTER:
                        F64X = OBound.X + (OBound.Width / 2);
                        break;

                    case EATTACH_ALIGNMENT.RIGHT:
                        F64X = OBound.X + OBound.Width;
                        break;
                }
                switch (this.m_ELineAlignment)
                {
                    case EATTACH_LINEALIGNMENT.TOP:
                        F64Y = OBound.Y;
                        break;

                    case EATTACH_LINEALIGNMENT.MIDDLE:
                        F64Y = OBound.Y + (OBound.Height / 2);
                        break;

                    case EATTACH_LINEALIGNMENT.BOTTOM:
                        F64Y = OBound.Y + OBound.Height;
                        break;
                }

                this.m_OText.X = F64X + this.m_F64AdjustX;
                this.m_OText.Y = F64Y + this.m_F64AdjustY;
            }
            catch (Exception ex)
            {
                CError.Throw(ex);
            }
        }
        #endregion
    }


    #region ENUM
    public enum EGRAPHIC_ATTACH : byte
    {
        TOP_LEFT = 0x00,
        TOP_CENTER,
        TOP_RIGHT,
        MIDDLE_LEFT,
        MIDDLE_CENTER,
        MIDDLE_RIGHT,
        BOTTOM_LEFT,
        BOTTOM_CENTER,
        BOTTOM_RIGHT
    }
    #endregion
}
