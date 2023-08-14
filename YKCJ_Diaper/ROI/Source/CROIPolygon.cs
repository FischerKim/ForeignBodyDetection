using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Jhjo.Common;
using Cognex.VisionPro;

namespace YKCJ_Diaper
{
    public class CROIPolygon : AROI
    {
        #region VARIABLE
        private int m_I32Count = 0;
        private double[] m_ArrF64X = null;
        private double[] m_ArrF64Y = null;
        #endregion


        #region PROPERTIES
        public override EROI EKind
        {
            get { return EROI.Polygon; }
        }


        public int I32Count
        {
            get { return this.m_I32Count; }
        }


        public double[] ArrF64X
        {
            get { return this.m_ArrF64X; }
        }


        public double[] ArrF64Y
        {
            get { return this.m_ArrF64Y; }
        }
        #endregion


        #region CONSTRUCTOR & DESTRUCTOR
        public CROIPolygon()
        {
            try
            {
                this.m_I32Count = 4;

                this.m_ArrF64X = new double[20];
                this.m_ArrF64X[0] = 0;
                this.m_ArrF64X[1] = 200;
                this.m_ArrF64X[2] = 200;
                this.m_ArrF64X[3] = 0;

                this.m_ArrF64Y = new double[20];
                this.m_ArrF64Y[0] = 0;
                this.m_ArrF64Y[1] = 0;
                this.m_ArrF64Y[2] = 200;
                this.m_ArrF64Y[3] = 200;
            }
            catch (Exception ex)
            {
                CError.Throw(ex);
            }
        }


        public CROIPolygon(AROI OROI)
        {
            try
            {
                CROIPolygon OSource = (CROIPolygon)OROI;

                this.m_I32Count = OSource.m_I32Count;

                this.m_ArrF64X = new double[20];
                this.m_ArrF64Y = new double[20];
                for (int _Index = 0; _Index < this.m_I32Count; _Index++)
                {
                    this.m_ArrF64X[_Index] = OSource.m_ArrF64X[_Index];
                    this.m_ArrF64Y[_Index] = OSource.m_ArrF64Y[_Index];
                }
            }
            catch (Exception ex)
            {
                CError.Throw(ex);
            }
        }


        public CROIPolygon(double[] ArrF64Value)
        {
            try
            {
                this.m_I32Count = ArrF64Value.Length / 2;

                this.m_ArrF64X = new double[20];
                this.m_ArrF64Y = new double[20];
                for (int _Index = 0; _Index < ArrF64Value.Length; _Index += 2)
                {
                    this.m_ArrF64X[_Index / 2] = ArrF64Value[_Index];
                    this.m_ArrF64Y[_Index / 2] = ArrF64Value[_Index + 1];
                }
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
                this.m_I32Count = 4;
                this.m_ArrF64X[0] = 0;
                this.m_ArrF64Y[0] = 0;
                this.m_ArrF64X[1] = 200;
                this.m_ArrF64Y[1] = 0;
                this.m_ArrF64X[2] = 200;
                this.m_ArrF64Y[2] = 200;
                this.m_ArrF64X[3] = 0;
                this.m_ArrF64Y[3] = 200;
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
                CogPolygon OGraphic = new CogPolygon();
                for (int _Index = 0; _Index < this.m_I32Count; _Index++)
                {
                    OGraphic.AddVertex(this.m_ArrF64X[_Index], this.m_ArrF64Y[_Index], _Index);
                }

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
                CogPolygon OGraphic = (CogPolygon)base.m_ORegion;

                if (this.m_I32Count > OGraphic.NumVertices)
                {
                    for (int _Index = 0; _Index < this.m_I32Count; _Index++)
                    {
                        if (OGraphic.NumVertices > _Index)
                        {
                            OGraphic.SetVertex(_Index, this.m_ArrF64X[_Index], this.m_ArrF64Y[_Index]);
                        }
                        else
                        {
                            OGraphic.AddVertex(this.m_ArrF64X[_Index], this.m_ArrF64Y[_Index], _Index);
                        }
                    }
                }
                else
                {
                    for (int _Index = 0; _Index < OGraphic.NumVertices; _Index++)
                    {
                        if (OGraphic.NumVertices > _Index)
                        {
                            OGraphic.SetVertex(_Index, this.m_ArrF64X[_Index], this.m_ArrF64Y[_Index]);
                        }
                        else
                        {
                            OGraphic.RemoveVertex(_Index);
                        }
                    }
                }
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
                CogPolygon OSource = (CogPolygon)base.m_ORegion;

                this.m_I32Count = OSource.NumVertices;

                for (int _Index = 0; _Index < this.m_I32Count; _Index++)
                {
                    this.m_ArrF64X[_Index] = OSource.GetVertexX(_Index);
                    this.m_ArrF64Y[_Index] = OSource.GetVertexY(_Index);
                }
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
                CROIPolygon OSource = (CROIPolygon)OROI;

                this.m_I32Count = OSource.m_I32Count;

                for (int _Index = 0; _Index < this.m_I32Count; _Index++)
                {
                    this.m_ArrF64X[_Index] = OSource.m_ArrF64X[_Index];
                    this.m_ArrF64Y[_Index] = OSource.m_ArrF64Y[_Index];
                }
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
                ArrF64Result = new double[this.m_I32Count * 2];
                for (int _Index = 0; _Index < this.m_I32Count; _Index++)
                {
                    ArrF64Result[_Index * 2] = this.m_ArrF64X[_Index];
                    ArrF64Result[(_Index * 2) + 1] = this.m_ArrF64Y[_Index];
                }
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
