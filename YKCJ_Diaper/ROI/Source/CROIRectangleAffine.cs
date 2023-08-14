using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Jhjo.Common;
using Cognex.VisionPro;

namespace YKCJ_Diaper
{
    public class CROIRectangleAffine : AROI
    {
        #region VARIABLE
        private double m_F64CenterX = 0;
        private double m_F64CenterY = 0;
        private double m_F64LengthX = 0;
        private double m_F64LengthY = 0;
        private double m_F64Rotation = 0;
        private double m_F64Skew = 0;
        #endregion


        #region PROPERTIES
        public override EROI EKind
        {
            get { return EROI.RectangleAffine; }
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


        public double F64LengthX
        {
            get { return this.m_F64LengthX; }
            set { this.m_F64LengthX = value; }
        }


        public double F64LengthY
        {
            get { return this.m_F64LengthY; }
            set { this.m_F64LengthY = value; }
        }


        public double F64Rotation
        {
            get { return this.m_F64Rotation; }
            set { this.m_F64Rotation = value; }
        }


        public double F64Skew
        {
            get { return this.m_F64Skew; }
            set { this.m_F64Skew = value; }
        }
        #endregion


        #region CONSTRUCTOR & DESTRUCTOR
        public CROIRectangleAffine()
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


        public CROIRectangleAffine(AROI OROI)
        {
            try
            {
                CROIRectangleAffine OSource = (CROIRectangleAffine)OROI;
                this.m_F64CenterX = OSource.m_F64CenterX;
                this.m_F64CenterY = OSource.m_F64CenterY;
                this.m_F64LengthX = OSource.m_F64LengthX;
                this.m_F64LengthY = OSource.m_F64LengthY;
                this.m_F64Rotation = OSource.m_F64Rotation;
                this.m_F64Skew = OSource.m_F64Skew;
            }
            catch (Exception ex)
            {
                CError.Throw(ex);
            }
        }


        public CROIRectangleAffine(double[] ArrF64Value)
        {
            try
            {
                this.m_F64CenterX = ArrF64Value[0];
                this.m_F64CenterY = ArrF64Value[1];
                this.m_F64LengthX = ArrF64Value[2];
                this.m_F64LengthY = ArrF64Value[3];
                this.m_F64Rotation = ArrF64Value[4];
                this.m_F64Skew = ArrF64Value[5];
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
                this.m_F64LengthX = 200;
                this.m_F64LengthY = 200;
                this.m_F64Rotation = 0;
                this.m_F64Skew = 0;
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
                CogRectangleAffine OGraphic = new CogRectangleAffine();
                OGraphic.SetCenterLengthsRotationSkew
                (
                    this.m_F64CenterX,
                    this.m_F64CenterY,
                    this.m_F64LengthX,
                    this.m_F64LengthY,
                    CogMisc.DegToRad(this.m_F64Rotation),
                    CogMisc.DegToRad(this.m_F64Skew)
                );

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
                CogRectangleAffine OGraphic = (CogRectangleAffine)base.m_ORegion;
                OGraphic.SetCenterLengthsRotationSkew
                (
                    this.m_F64CenterX,
                    this.m_F64CenterY,
                    this.m_F64LengthX,
                    this.m_F64LengthY,
                    CogMisc.DegToRad(this.m_F64Rotation),
                    CogMisc.DegToRad(this.m_F64Skew)
                );
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
                CogRectangleAffine OGraphic = (CogRectangleAffine)base.m_ORegion;

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
                CogRectangleAffine OGraphic = (CogRectangleAffine)base.m_ORegion;

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
                CogRectangleAffine OGraphic = (CogRectangleAffine)base.m_ORegion;
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
                CogRectangleAffine OSource = (CogRectangleAffine)base.m_ORegion;
                this.m_F64CenterX = OSource.CenterX;
                this.m_F64CenterY = OSource.CenterY;
                this.m_F64LengthX = OSource.SideXLength;
                this.m_F64LengthY = OSource.SideYLength;
                this.m_F64Rotation = CogMisc.RadToDeg(OSource.Rotation);
                this.m_F64Skew = CogMisc.RadToDeg(OSource.Skew);
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
                CROIRectangleAffine OSource = (CROIRectangleAffine)OROI;
                this.m_F64CenterX = OSource.m_F64CenterX;
                this.m_F64CenterY = OSource.m_F64CenterY;
                this.m_F64LengthX = OSource.m_F64LengthX;
                this.m_F64LengthY = OSource.m_F64LengthY;
                this.m_F64Rotation = OSource.m_F64Rotation;
                this.m_F64Skew = OSource.m_F64Skew;
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
                ArrF64Result[2] = this.m_F64LengthX;
                ArrF64Result[3] = this.m_F64LengthY;
                ArrF64Result[4] = this.m_F64Rotation;
                ArrF64Result[5] = this.m_F64Skew;
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
