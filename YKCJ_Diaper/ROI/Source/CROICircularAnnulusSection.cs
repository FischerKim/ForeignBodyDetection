using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Jhjo.Common;
using Cognex.VisionPro;

namespace YKCJ_Diaper
{
    public class CROICircularAnnulusSection : AROI
    {
        #region VARIABLE
        private double m_F64CenterX = 0;
        private double m_F64CenterY = 0;
        private double m_F64Radius = 0;
        private double m_F64RadialScale = 0;
        private double m_F64AngleStart = 0;
        private double m_F64AngleSpan = 0;
        #endregion


        #region PROPERTIES
        public override EROI EKind
        {
            get { return EROI.CircularAnnulusSection; }
        }


        public double F64CenterX
        {
            get { return this.m_F64CenterX; }
            set { this.m_F64CenterX = value; }
        }


        public double F64CenterY
        {
            get { return this.m_F64CenterY; }
            set { this.m_F64CenterY = value; }
        }


        public double F64Radius
        {
            get { return this.m_F64Radius; }
            set { this.m_F64Radius = value; }
        }


        public double F64RadialScale
        {
            get { return this.m_F64RadialScale; }
            set { this.m_F64RadialScale = value; }
        }


        public double F64AngleStart
        {
            get { return this.m_F64AngleStart; }
            set { this.m_F64AngleStart = value; }
        }


        public double F64AngleSpan
        {
            get { return this.m_F64AngleSpan; }
            set { this.m_F64AngleSpan = value; }
        }
        #endregion


        #region CONSTRUCTOR & DESTRUCTOR
        public CROICircularAnnulusSection()
        {
            try
            {
                this.Init();
            }
            catch (Exception ex)
            {
                CError.Throw(ex);
            }
        }


        public CROICircularAnnulusSection(AROI OROI)
        {
            try
            {
                CROICircularAnnulusSection OSource = (CROICircularAnnulusSection)OROI;
                this.m_F64CenterX = OSource.m_F64CenterX;
                this.m_F64CenterY = OSource.m_F64CenterY;
                this.m_F64Radius = OSource.m_F64Radius;
                this.m_F64RadialScale = OSource.m_F64RadialScale;
                this.m_F64AngleStart = OSource.m_F64AngleStart;
                this.m_F64AngleSpan = OSource.m_F64AngleSpan;
            }
            catch (Exception ex)
            {
                CError.Throw(ex);
            }
        }


        public CROICircularAnnulusSection(double[] ArrF64Value)
        {
            try
            {
                this.m_F64CenterX = ArrF64Value[0];
                this.m_F64CenterY = ArrF64Value[1];
                this.m_F64Radius = ArrF64Value[2];
                this.m_F64RadialScale = ArrF64Value[3];
                this.m_F64AngleStart = ArrF64Value[4];
                this.m_F64AngleSpan = ArrF64Value[5];
            }
            catch (Exception ex)
            {
                CError.Throw(ex);
            }
        }
        #endregion


        #region FUNCTION
        public override void Init()
        {
            try
            {
                this.m_F64CenterX = 100;
                this.m_F64CenterY = 100;
                this.m_F64Radius = 100;
                this.m_F64RadialScale = 0.5;
                this.m_F64AngleStart = 0;
                this.m_F64AngleSpan = 360;
            }
            catch (Exception ex)
            {
                CError.Throw(ex);
            }
        }


        public override void Create()
        {
            try
            {
                CogCircularAnnulusSection OGraphic = new CogCircularAnnulusSection();
                OGraphic.CenterX = this.m_F64CenterX;
                OGraphic.CenterY = this.m_F64CenterY;
                OGraphic.Radius = this.m_F64Radius;
                OGraphic.RadialScale = this.m_F64RadialScale;
                OGraphic.AngleStart = CogMisc.DegToRad(this.m_F64AngleStart);
                OGraphic.AngleSpan = CogMisc.DegToRad(this.m_F64AngleSpan);

                base.m_ORegion = OGraphic;
            }
            catch (Exception ex)
            {
                CError.Throw(ex);
            }
        }


        public override void Refresh()
        {
            try
            {
                CogCircularAnnulusSection OGraphic = (CogCircularAnnulusSection)base.m_ORegion;
                OGraphic.CenterX = this.m_F64CenterX;
                OGraphic.CenterY = this.m_F64CenterY;
                OGraphic.Radius = this.m_F64Radius;
                OGraphic.RadialScale = this.m_F64RadialScale;
                OGraphic.AngleStart = CogMisc.DegToRad(this.m_F64AngleStart);
                OGraphic.AngleSpan = CogMisc.DegToRad(this.m_F64AngleSpan);
            }
            catch (Exception ex)
            {
                CError.Throw(ex);
            }
        }


        public override void Move(string StrDirection, int I32Distance)
        {
            try
            {
                CogCircularAnnulusSection OGraphic = (CogCircularAnnulusSection)base.m_ORegion;

                if (StrDirection == "LEFT")
                {
                    OGraphic.CenterX -= I32Distance;
                }
                else if (StrDirection == "RIGHT")
                {
                    OGraphic.CenterX += I32Distance;
                }
                else if (StrDirection == "TOP")
                {
                    OGraphic.CenterY -= I32Distance;
                }
                else if (StrDirection == "BOTTOM")
                {
                    OGraphic.CenterY += I32Distance;
                }

                foreach (IAttach _Item in base.m_LstOAttach)
                {
                    _Item.Alignment(OBound);
                }
            }
            catch (Exception ex)
            {
                CError.Throw(ex);
            }
        }


        public override void Alignment(string StrTarget, string StrSource, CogRectangle OSource)
        {
            try
            {
                CogRectangle OBound = base.m_ORegion.EnclosingRectangle(CogCopyShapeConstants.All);
                CogCircularAnnulusSection OGraphic = (CogCircularAnnulusSection)base.m_ORegion;

                if (StrTarget == "왼쪽")
                {
                    if (StrSource == "왼쪽")
                    {
                        OGraphic.CenterX += OSource.X - OBound.X;
                        OBound.X = OSource.X;
                    }
                    else if (StrSource == "오른쪽")
                    {
                        OGraphic.CenterX += OSource.X + OSource.Width - OBound.X;
                        OBound.X = OSource.X + OSource.Width;
                    }
                }
                else if (StrTarget == "오른쪽")
                {
                    if (StrSource == "왼쪽")
                    {
                        OGraphic.CenterX += OSource.X - (OBound.X + OBound.Width);
                        OBound.X = OSource.X - OBound.Width;
                    }
                    else if (StrSource == "오른쪽")
                    {
                        OGraphic.CenterX += OSource.X + OSource.Width - (OBound.X + OBound.Width);
                        OBound.X = OSource.X + OSource.Width - OBound.Width;
                    }
                }
                else if (StrTarget == "상단")
                {
                    if (StrSource == "상단")
                    {
                        OGraphic.CenterY += OSource.Y - OBound.Y;
                        OBound.Y = OSource.Y;
                    }
                    else if (StrSource == "하단")
                    {
                        OGraphic.CenterY += OSource.Y + OSource.Height - OBound.Y;
                        OBound.Y = OSource.Y + OSource.Height;
                    }
                }
                else if (StrTarget == "하단")
                {
                    if (StrSource == "상단")
                    {
                        OGraphic.CenterY += OSource.Y - (OBound.Y + OBound.Height);
                        OBound.Y = OSource.Y - OBound.Height;
                    }
                    else if (StrSource == "하단")
                    {
                        OGraphic.CenterY += OSource.Y + OSource.Height - (OBound.Y + OBound.Height);
                        OBound.Y = OSource.Y + OSource.Height - OBound.Height;
                    }
                }

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


        public override void Follow()
        {
            try
            {
                CogCircularAnnulusSection OGraphic = (CogCircularAnnulusSection)base.m_ORegion;
                OGraphic.CenterX += this.m_F64AdjustX;
                OGraphic.CenterY += this.m_F64AdjustY;

                base.ResetAttach();
            }
            catch (Exception ex)
            {
                CError.Throw(ex);
            }
        }


        public override void Reflect()
        {
            try
            {
                CogCircularAnnulusSection OSource = (CogCircularAnnulusSection)base.m_ORegion;
                this.m_F64CenterX = OSource.CenterX;
                this.m_F64CenterY = OSource.CenterY;
                this.m_F64Radius = OSource.Radius;
                this.m_F64RadialScale = OSource.RadialScale;
                this.m_F64AngleStart = CogMisc.RadToDeg(OSource.AngleStart);
                this.m_F64AngleSpan = CogMisc.RadToDeg(OSource.AngleSpan);
            }
            catch (Exception ex)
            {
                CError.Throw(ex);
            }
        }


        public override void Copy(AROI OROI)
        {
            try
            {
                CROICircularAnnulusSection OSource = (CROICircularAnnulusSection)OROI;
                this.m_F64CenterX = OSource.m_F64CenterX;
                this.m_F64CenterY = OSource.m_F64CenterY;
                this.m_F64Radius = OSource.m_F64Radius;
                this.m_F64RadialScale = OSource.m_F64RadialScale;
                this.m_F64AngleStart = OSource.m_F64AngleStart;
                this.m_F64AngleSpan = OSource.m_F64AngleSpan;
            }
            catch (Exception ex)
            {
                CError.Throw(ex);
            }
        }


        public override double[] GetValue()
        {
            double[] ArrF64Result = null;

            try
            {
                ArrF64Result = new double[6];
                ArrF64Result[0] = this.m_F64CenterX;
                ArrF64Result[1] = this.m_F64CenterY;
                ArrF64Result[2] = this.m_F64Radius;
                ArrF64Result[3] = this.m_F64RadialScale;
                ArrF64Result[4] = this.m_F64AngleStart;
                ArrF64Result[5] = this.m_F64AngleSpan;
            }
            catch (Exception ex)
            {
                CError.Throw(ex);
            }

            return ArrF64Result;
        }
        #endregion
    }
}
