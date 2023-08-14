using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Jhjo.Common;
using Cognex.VisionPro;

namespace YKCJ_Diaper
{
    public class CROICircle : AROI
    {
        #region VARIABLE
        private double m_F64CenterX = 0;
        private double m_F64CenterY = 0;
        private double m_F64Radius = 0;
        #endregion


        #region PROPERTIES
        public override EROI EKind
        {
            get { return EROI.Circle; }
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
        #endregion


        #region CONSTRUCTOR & DESTRUCTOR
        public CROICircle()
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


        public CROICircle(AROI OROI)
        {
            try
            {
                CROICircle OSource = (CROICircle)OROI;
                this.m_F64CenterX = OSource.m_F64CenterX;
                this.m_F64CenterY = OSource.m_F64CenterY;
                this.m_F64Radius = OSource.m_F64Radius;
            }
            catch (Exception ex)
            {
                CError.Throw(ex);
            }
        }


        public CROICircle(double[] ArrF64Value)
        {
            try
            {
                this.m_F64CenterX = ArrF64Value[0];
                this.m_F64CenterY = ArrF64Value[1];
                this.m_F64Radius = ArrF64Value[2];
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
                CogCircle OGraphic = new CogCircle();
                OGraphic.CenterX = this.m_F64CenterX;
                OGraphic.CenterY = this.m_F64CenterY;
                OGraphic.Radius = this.m_F64Radius;

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
                CogCircle OGraphic = (CogCircle)base.m_ORegion;
                OGraphic.CenterX = this.m_F64CenterX;
                OGraphic.CenterY = this.m_F64CenterY;
                OGraphic.Radius = this.m_F64Radius;
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
                CogCircle OSource = (CogCircle)base.m_ORegion;
                this.m_F64CenterX = OSource.CenterX;
                this.m_F64CenterY = OSource.CenterY;
                this.m_F64Radius = OSource.Radius;
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
                CROICircle OSource = (CROICircle)OROI;
                this.m_F64CenterX = OSource.m_F64CenterX;
                this.m_F64CenterY = OSource.m_F64CenterY;
                this.m_F64Radius = OSource.m_F64Radius;
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
                ArrF64Result = new double[3];
                ArrF64Result[0] = this.m_F64CenterX;
                ArrF64Result[1] = this.m_F64CenterY;
                ArrF64Result[2] = this.m_F64Radius;
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
