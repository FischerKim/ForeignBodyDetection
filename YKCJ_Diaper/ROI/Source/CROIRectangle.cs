using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Jhjo.Common;
using Cognex.VisionPro;

namespace YKCJ_Diaper
{
    public class CROIRectangle : AROI
    {
        #region VARIABLE
        private double m_F64X = 0;
        private double m_F64Y = 0;
        private double m_F64Width = 0;
        private double m_F64Height = 0;
        #endregion


        #region PROPERTIES
        public override EROI EKind
        {
            get { return EROI.Rectangle; }
        }


        public double F64X
        {
            get { return this.m_F64X; }
            set { this.m_F64X = value; }
        }


        public double F64Y
        {
            get { return this.m_F64Y; }
            set { this.m_F64Y = value; }
        }


        public double F64Width
        {
            get { return this.m_F64Width; }
            set { this.m_F64Width = value; }
        }


        public double F64Height
        {
            get { return this.m_F64Height; }
            set { this.m_F64Height = value; }
        }
        #endregion


        #region CONSTRUCTOR & DESTRUCTOR
        public CROIRectangle()
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


        public CROIRectangle(AROI OROI)
        {
            try
            {
                CROIRectangle OSource = (CROIRectangle)OROI;
                this.m_F64X = OSource.m_F64X;
                this.m_F64Y = OSource.m_F64Y;
                this.m_F64Width = OSource.m_F64Width;
                this.m_F64Height = OSource.m_F64Height;
            }
            catch (Exception ex)
            {
                CError.Throw(ex);
            }
        }


        public CROIRectangle(double[] ArrF64Value)
        {
            try
            {
                this.m_F64X = ArrF64Value[0];
                this.m_F64Y = ArrF64Value[1];
                this.m_F64Width = ArrF64Value[2];
                this.m_F64Height = ArrF64Value[3];
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
                this.m_F64X = 0;
                this.m_F64Y = 0;
                this.m_F64Width = 200;
                this.m_F64Height = 200;
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
                CogRectangle OGraphic = new CogRectangle();
                OGraphic.X = this.m_F64X;
                OGraphic.Y = this.m_F64Y;
                OGraphic.Width = this.m_F64Width;
                OGraphic.Height = this.m_F64Height;

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
                CogRectangle OGraphic = (CogRectangle)base.m_ORegion;
                OGraphic.X = this.m_F64X;
                OGraphic.Y = this.m_F64Y;
                OGraphic.Width = this.m_F64Width;
                OGraphic.Height = this.m_F64Height;
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
                CogRectangle OSource = (CogRectangle)base.m_ORegion;
                this.m_F64X = OSource.X;
                this.m_F64Y = OSource.Y;
                this.m_F64Width = OSource.Width;
                this.m_F64Height = OSource.Height;
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
                CROIRectangle OSource = (CROIRectangle)OROI;
                this.m_F64X = OSource.m_F64X;
                this.m_F64Y = OSource.m_F64Y;
                this.m_F64Width = OSource.m_F64Width;
                this.m_F64Height = OSource.m_F64Height;
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
                ArrF64Result = new double[4];
                ArrF64Result[0] = this.m_F64X;
                ArrF64Result[1] = this.m_F64Y;
                ArrF64Result[2] = this.m_F64Width;
                ArrF64Result[3] = this.m_F64Height;
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
