using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Jhjo.Common;
using Cognex.VisionPro;

namespace YKCJ_Diaper
{
    public class CROIEllipticalAnnulusSection : AROI
    {
        #region VARIABLE
        private double m_F64CenterX = 0;
        private double m_F64CenterY = 0;
        private double m_F64RadiusX = 0;
        private double m_F64RadiusY = 0;
        private double m_F64RadialScale = 0;
        private double m_F64Rotation = 0;
        private double m_F64AngleStart = 0;
        private double m_F64AngleSpan = 0;
        #endregion


        #region PROPERTIES
        public override EROI EKind
        {
            get { return EROI.EllipticalAnnulusSection; }
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


        public double F64RadiusX
        {
            get { return this.m_F64RadiusX; }
            set { this.m_F64RadiusX = value; }
        }


        public double F64RadiusY
        {
            get { return this.m_F64RadiusY; }
            set { this.m_F64RadiusY = value; }
        }


        public double F64RadialScale
        {
            get { return this.m_F64RadialScale; }
            set { this.m_F64RadialScale = value; }
        }


        public double F64Rotation
        {
            get { return this.m_F64Rotation; }
            set { this.m_F64Rotation = value; }
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
        public CROIEllipticalAnnulusSection()
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


        public CROIEllipticalAnnulusSection(AROI OROI)
        {
            try
            {
                CROIEllipticalAnnulusSection OSource = (CROIEllipticalAnnulusSection)OROI;
                this.m_F64CenterX = OSource.m_F64CenterX;
                this.m_F64CenterY = OSource.m_F64CenterY;
                this.m_F64RadiusX = OSource.m_F64RadiusX;
                this.m_F64RadiusY = OSource.m_F64RadiusY;
                this.m_F64RadialScale = OSource.m_F64RadialScale;
                this.m_F64Rotation = OSource.m_F64Rotation;
                this.m_F64AngleStart = OSource.m_F64AngleStart;
                this.m_F64AngleSpan = OSource.m_F64AngleSpan;
            }
            catch (Exception ex)
            {
                CError.Throw(ex);
            }
        }


        public CROIEllipticalAnnulusSection(double[] ArrF64Value)
        {
            try
            {
                this.m_F64CenterX = ArrF64Value[0];
                this.m_F64CenterY = ArrF64Value[1];
                this.m_F64RadiusX = ArrF64Value[2];
                this.m_F64RadiusY = ArrF64Value[3];
                this.m_F64RadialScale = ArrF64Value[4];
                this.m_F64Rotation = ArrF64Value[5];
                this.m_F64AngleStart = ArrF64Value[6];
                this.m_F64AngleSpan = ArrF64Value[7];
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
                this.m_F64RadiusX = 100;
                this.m_F64RadiusY = 100;
                this.m_F64RadialScale = 0.5;
                this.m_F64Rotation = 0;
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
                CogEllipticalAnnulusSection OGraphic = new CogEllipticalAnnulusSection();
                OGraphic.CenterX = this.m_F64CenterX;
                OGraphic.CenterY = this.m_F64CenterY;
                OGraphic.RadiusX = this.m_F64RadiusX;
                OGraphic.RadiusY = this.m_F64RadiusY;
                OGraphic.RadialScale = this.m_F64RadialScale;
                OGraphic.Rotation = CogMisc.DegToRad(this.m_F64Rotation);
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
                CogEllipticalAnnulusSection OGraphic = (CogEllipticalAnnulusSection)base.m_ORegion;
                OGraphic.CenterX = this.m_F64CenterX;
                OGraphic.CenterY = this.m_F64CenterY;
                OGraphic.RadiusX = this.m_F64RadiusX;
                OGraphic.RadiusY = this.m_F64RadiusY;
                OGraphic.RadialScale = this.m_F64RadialScale;
                OGraphic.Rotation = CogMisc.DegToRad(this.m_F64Rotation);
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
                CogEllipticalAnnulusSection OGraphic = (CogEllipticalAnnulusSection)base.m_ORegion;

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
                CogEllipticalAnnulusSection OGraphic = (CogEllipticalAnnulusSection)base.m_ORegion;

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
                CogEllipticalAnnulusSection OGraphic = (CogEllipticalAnnulusSection)base.m_ORegion;
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
                CogEllipticalAnnulusSection OSource = (CogEllipticalAnnulusSection)base.m_ORegion;
                this.m_F64CenterX = OSource.CenterX;
                this.m_F64CenterY = OSource.CenterY;
                this.m_F64RadiusX = OSource.RadiusX;
                this.m_F64RadiusY = OSource.RadiusY;
                this.m_F64RadialScale = OSource.RadialScale;
                this.m_F64Rotation = CogMisc.RadToDeg(OSource.Rotation);
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
                CROIEllipticalAnnulusSection OSource = (CROIEllipticalAnnulusSection)OROI;
                this.m_F64CenterX = OSource.m_F64CenterX;
                this.m_F64CenterY = OSource.m_F64CenterY;
                this.m_F64RadiusX = OSource.m_F64RadiusX;
                this.m_F64RadiusY = OSource.m_F64RadiusY;
                this.m_F64RadialScale = OSource.m_F64RadialScale;
                this.m_F64Rotation = OSource.m_F64Rotation;
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
                ArrF64Result = new double[8];
                ArrF64Result[0] = this.m_F64CenterX;
                ArrF64Result[1] = this.m_F64CenterY;
                ArrF64Result[2] = this.m_F64RadiusX;
                ArrF64Result[3] = this.m_F64RadiusY;
                ArrF64Result[4] = this.m_F64RadialScale;
                ArrF64Result[5] = this.m_F64Rotation;
                ArrF64Result[6] = this.m_F64AngleStart;
                ArrF64Result[7] = this.m_F64AngleSpan;
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
