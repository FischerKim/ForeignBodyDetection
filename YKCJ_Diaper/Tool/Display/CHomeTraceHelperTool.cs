using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Jhjo.Common;
using Cognex.VisionPro.Display;
using Cognex.VisionPro;
using System.Threading;

namespace YKCJ_Diaper
{
    public class CHomeTraceHelperTool : IDisposable
    {
        #region VARIABLE
        private CogDisplay m_ODisplayer = null;
        private object m_ODisplayInterrupt = null;

        private List<CogCircle> m_LstOGraphic = null;
        private bool m_BDrawGraphic = true;
        private object m_OGraphicInterrupt = null;
        

        private Thread m_OWorker = null;
        private bool m_BDoWork = false;
        #endregion


        #region CONSTRUCTOR & DESTRUCTOR
        public CHomeTraceHelperTool(CogDisplay ODisplayer)
        {
            try
            {
                this.m_ODisplayer = ODisplayer;
                this.m_ODisplayInterrupt = new object();

                this.m_LstOGraphic = new List<CogCircle>();
                this.m_OGraphicInterrupt = new object();

                this.BeginWork();
            }
            catch (Exception ex)
            {
                CError.Throw(ex);
            }
        }


        ~CHomeTraceHelperTool()
        {
            try
            {
                this.Dispose();
            }
            catch (Exception ex)
            {
                CError.Ignore(ex);
            }
        }
        #endregion


        #region FUNCTION
        private void BeginWork()
        {
            try
            {
                if (this.m_OWorker == null)
                {
                    this.m_BDoWork = true;

                    this.m_OWorker = new Thread(this.Work);
                    this.m_OWorker.IsBackground = true;
                    this.m_OWorker.Start();
                }
            }
            catch (Exception ex)
            {
                CError.Throw(ex);
            }
        }


        private void Work()
        {
            try
            {
                while (this.m_BDoWork == true)
                {
                    try
                    {
                        CogCircle OCircle = this.GetGrahpic();

                        if (OCircle != null)
                        {
                            this.DrawGrahic(OCircle);
                        }
                    }
                    catch (Exception ex)
                    {
                        CError.Ignore(ex);
                    }

                    Thread.Sleep(1);
                }
            }
            catch (Exception ex)
            {
                CError.Throw(ex);
            }
        }


        private void EndWork()
        {
            try
            {
                if (this.m_OWorker != null)
                {
                    this.m_BDoWork = false;

                    this.m_OWorker.Join();
                    this.m_OWorker = null;
                }
            }
            catch (Exception ex)
            {
                CError.Throw(ex);
            }
        }


        public void SetResult(CDiaperFaultResult OResult)
        {
            try
            {
                Monitor.Enter(this.m_OGraphicInterrupt);

                if (this.m_BDrawGraphic == true)
                {
                    if (this.m_ODisplayer.Image == null)
                    {
                        this.m_ODisplayer.Image = OResult.OImageInfo.OImage;
                    }

                    CogCircle OGraphic = new CogCircle();
                    OGraphic.CenterX = OResult.OFaultResult.F64X;
                    OGraphic.CenterY = OResult.OFaultResult.F64Y;
                    OGraphic.Radius = 2;
                    OGraphic.Color = OResult.EColor;

                    this.m_LstOGraphic.Add(OGraphic);
                }
            }
            catch (Exception ex)
            {
                CError.Throw(ex);
            }
            finally
            {
                Monitor.Exit(this.m_OGraphicInterrupt);
            }
        }


        private CogCircle GetGrahpic()
        {
            CogCircle OResult = null;

            try
            {
                Monitor.Enter(this.m_OGraphicInterrupt);

                if (this.m_LstOGraphic.Count > 0)
                {
                    OResult = this.m_LstOGraphic[0];
                    this.m_LstOGraphic.RemoveAt(0);
                }
            }
            catch (Exception ex)
            {
                CError.Throw(ex);
            }
            finally
            {
                Monitor.Exit(this.m_OGraphicInterrupt);
            }

            return OResult;
        }


        private void DrawGrahic(CogCircle OCircle)
        {
            try
            {
                Monitor.Enter(this.m_ODisplayInterrupt);

                this.m_ODisplayer.StaticGraphics.Add(OCircle, string.Empty);
            }
            catch (Exception ex)
            {
                CError.Throw(ex);
            }
            finally
            {
                Monitor.Exit(this.m_ODisplayInterrupt);
            }
        }


        public void Clear()
        {
            try
            {
                Monitor.Enter(this.m_ODisplayInterrupt);
                this.m_BDrawGraphic = false;

                this.m_ODisplayer.Image = null;
                this.m_ODisplayer.StaticGraphics.Clear();   
            }
            catch (Exception ex)
            {
                CError.Throw(ex);
            }
            finally
            {
                this.m_BDrawGraphic = true;
                Monitor.Exit(this.m_ODisplayInterrupt);
            }
        }


        public void Dispose()
        {
            try
            {
                this.EndWork();
            }
            catch (Exception ex)
            {
                CError.Throw(ex);
            }
        }
        #endregion
    }
}
