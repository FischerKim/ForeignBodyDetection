using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cognex.VisionPro.Display;
using System.Threading;
using Jhjo.Common;
using Cognex.VisionPro;

namespace YKCJ_Diaper
{
    public class CHomeNGHelperTool : IDisposable
    {
        #region VARIABLE
        private CogDisplay m_OCdpPosition = null;
        private CogCircle m_OPosition = null;

        private CogDisplay m_OCdpZoom = null;

        private CDiaperFaultResult m_OSubject = null;
        private object m_OInterrupt = null;

        private Thread m_OWorker = null;
        private bool m_BDoWork = false;
        #endregion


        #region PROPERTIES
        public CDiaperFaultResult OSubject
        {
            set
            {
                try
                {
                    Monitor.Enter(this.m_OInterrupt);

                    this.m_OSubject = value;
                }
                catch (Exception ex)
                {
                    CError.Throw(ex);
                }
                finally
                {
                    Monitor.Exit(this.m_OInterrupt);
                }
            }
        }
        #endregion


        #region CONSTRUCTOR & DESTRUCTOR
        public CHomeNGHelperTool(CogDisplay OCdpPosition, CogDisplay OCdpZoom)
        {
            try
            {
                this.m_OCdpPosition = OCdpPosition;
                this.m_OPosition = new CogCircle();
                this.m_OPosition.Radius = 100;
                this.m_OPosition.Color = CogColorConstants.Red;
                this.m_OPosition.LineWidthInScreenPixels = 2;
                this.m_OPosition.Interactive = false;
                this.m_OCdpPosition.InteractiveGraphics.Add(this.m_OPosition, "Position", true);
                
                this.m_OCdpZoom = OCdpZoom;

                this.m_OInterrupt = new object();
                this.BeginWork();
            }
            catch (Exception ex)
            {
                CError.Throw(ex);
            }
        }


        ~CHomeNGHelperTool()
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
                        CDiaperFaultResult OSubject = this.GetSubject();

                        if (OSubject != null)
                        {
                            this.DoProcess(OSubject);
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


        private void DoProcess(CDiaperFaultResult OSubject)
        {
            try
            {
                this.m_OCdpPosition.DrawingEnabled = false;
                this.m_OCdpZoom.DrawingEnabled = false;

                this.m_OCdpPosition.Image = OSubject.OImageInfo.OImage;
                this.m_OPosition.CenterX = OSubject.OFaultResult.F64X;
                this.m_OPosition.CenterY = OSubject.OFaultResult.F64Y;

                this.m_OCdpZoom.Image = OSubject.OZoomImage;
            }
            catch (Exception ex)
            {
                CError.Throw(ex);
            }
            finally
            {
                this.m_OCdpZoom.DrawingEnabled = true;
                this.m_OCdpPosition.DrawingEnabled = true;
            }
        }


        private CDiaperFaultResult GetSubject()
        {
            CDiaperFaultResult OResult = null;

            try
            {
                Monitor.Enter(this.m_OInterrupt);

                OResult = this.m_OSubject;
                this.m_OSubject = null;
            }
            catch (Exception ex)
            {
                CError.Throw(ex);
            }
            finally
            {
                Monitor.Exit(this.m_OInterrupt);
            }

            return OResult;
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
