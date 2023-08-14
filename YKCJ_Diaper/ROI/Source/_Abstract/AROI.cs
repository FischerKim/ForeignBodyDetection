using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cognex.VisionPro;
using Jhjo.Common;

namespace YKCJ_Diaper
{
    public abstract class AROI
    {
        #region VARIABLE
        protected ICogRegion m_ORegion = null;
        protected List<IAttach> m_LstOAttach = null;
        private bool m_BDisplayed = false;

        protected double m_F64AdjustX = 0;
        protected double m_F64AdjustY = 0;
        #endregion


        #region PROPERTIES
        public abstract EROI EKind { get; }


        public ICogRegion ORegion
        {
            get { return this.m_ORegion; }
        }


        public List<IAttach> LstOAttach
        {
            get { return this.m_LstOAttach; }
        }


        public bool BDisplayed
        {
            get { return this.m_BDisplayed; }
            set { this.m_BDisplayed = value; }
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


        public ICogGraphicInteractive OGraphic
        {
            get { return (ICogGraphicInteractive)this.m_ORegion; }
        }


        public CogRectangle OBound
        {
            get { return this.m_ORegion.EnclosingRectangle(CogCopyShapeConstants.All); }
        }
        #endregion


        #region CONSTRUCTOR & DESTRUCTOR
        public AROI()
        {
            try
            {
                this.m_LstOAttach = new List<IAttach>();
            }
            catch (Exception ex)
            {
                CError.Throw(ex);
            }
        }
        #endregion

        
        #region FUNCTION
        public virtual void Move(string StrDirection, int I32Distance)
        {
            try
            {
                CogRectangle OBound = this.m_ORegion.EnclosingRectangle(CogCopyShapeConstants.All);

                if (StrDirection == "LEFT")
                {
                    OBound.X -= I32Distance;
                }
                else if (StrDirection == "RIGHT")
                {
                    OBound.X += I32Distance;
                }
                else if (StrDirection == "TOP")
                {
                    OBound.Y -= I32Distance;
                }
                else if (StrDirection == "BOTTOM")
                {
                    OBound.Y += I32Distance;
                }

                this.m_ORegion.FitToBoundingBox(OBound);


                foreach (IAttach _Item in this.m_LstOAttach)
                {
                    _Item.Alignment(OBound);
                }
            }
            catch (Exception ex)
            {
                CError.Throw(ex);
            }
        }


        public virtual void Alignment(string StrTarget, string StrSource, CogRectangle OSource)
        {
            try
            {
                CogRectangle OBound = this.m_ORegion.EnclosingRectangle(CogCopyShapeConstants.All);
                

                if (StrTarget == "왼쪽")
                {
                    if (StrSource == "왼쪽")
                    {
                        OBound.X = OSource.X;
                    }
                    else if (StrSource == "오른쪽")
                    {
                        OBound.X = OSource.X + OSource.Width;
                    }
                }
                else if (StrTarget == "오른쪽")
                {
                    if (StrSource == "왼쪽")
                    {
                        OBound.X = OSource.X - OBound.Width;
                    }
                    else if (StrSource == "오른쪽")
                    {
                        OBound.X = OSource.X + OSource.Width - OBound.Width;
                    }
                }
                else if (StrTarget == "상단")
                {
                    if (StrSource == "상단")
                    {
                        OBound.Y = OSource.Y;
                    }
                    else if (StrSource == "하단")
                    {
                        OBound.Y = OSource.Y + OSource.Height;
                    }
                }
                else if (StrTarget == "하단")
                {
                    if (StrSource == "상단")
                    {
                        OBound.Y = OSource.Y - OBound.Height;
                    }
                    else if (StrSource == "하단")
                    {
                        OBound.Y = OSource.Y + OSource.Height - OBound.Height;
                    }
                }


                this.m_ORegion.FitToBoundingBox(OBound);
                
                foreach (IAttach _Item in this.m_LstOAttach)
                {
                    _Item.Alignment(OBound);
                }
            }
            catch (Exception ex)
            {
                CError.Throw(ex);
            }
        }


        public void AddAttach(IAttach OItem)
        {
            try
            {
                CogRectangle OBound = this.m_ORegion.EnclosingRectangle(CogCopyShapeConstants.All);
                OItem.OGraphic.Color = ((ICogGraphicInteractive)this.m_ORegion).Color;
                OItem.Alignment(OBound);

                this.m_LstOAttach.Add(OItem);
            }
            catch (Exception ex)
            {
                CError.Throw(ex);
            }
        }


        public void ResetAttach()
        {
            try
            {
                CogRectangle OBound = this.m_ORegion.EnclosingRectangle(CogCopyShapeConstants.All);

                foreach (IAttach _Item in this.m_LstOAttach)
                {
                    _Item.Alignment(OBound);
                }
            }
            catch (Exception ex)
            {
                CError.Throw(ex);
            }
        }


        public void ResetAttach(CogRectangle OBound)
        {
            try
            {
                foreach (IAttach _Item in this.m_LstOAttach)
                {
                    _Item.Alignment(OBound);
                }
            }
            catch (Exception ex)
            {
                CError.Throw(ex);
            }
        }


        public virtual void Follow()
        {
            try
            {
                CogRectangle OBound = this.m_ORegion.EnclosingRectangle(CogCopyShapeConstants.All);
                OBound.X += this.m_F64AdjustX;
                OBound.Y += this.m_F64AdjustY;
                this.m_ORegion.FitToBoundingBox(OBound);

                this.ResetAttach();
            }
            catch (Exception ex)
            {
                CError.Throw(ex);
            }
        }
        #endregion


        #region ABSTRACT FUNCTION
        public abstract void Init();
        public abstract void Create();
        public abstract void Refresh();
        public abstract void Reflect();
        public abstract void Copy(AROI OROI);
        public abstract double[] GetValue();
        #endregion
    }


    public enum EROI
    {
        Circle = 0x00,
        Ellipse,
        Polygon,
        Rectangle,
        RectangleAffine,
        CircularAnnulusSection,
        EllipticalAnnulusSection
    }
}
