using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cognex.VisionPro.Display;
using System.Threading;
using Jhjo.Common;
using System.IO;
using System.Drawing;
using Cognex.VisionPro;

namespace YKCJ_Diaper
{
    public class CDefineSubStanceHelperTool : IDisposable
    {
        #region VARIABLE
        private CogDisplay m_OCdpImage = null;
        private string m_StrFile = string.Empty;
        private object m_OInterrupt = null;

        private Thread m_OWorker = null;
        private bool m_BDoWork = false;
        #endregion


        #region CONSTRUCTOR & DESTRUCTOR
        public CDefineSubStanceHelperTool(CogDisplay OCdpImage)
        {
            try
            {
                this.m_OCdpImage = OCdpImage;
                this.m_OInterrupt = new object();

                this.BeginWork();
            }
            catch (Exception ex)
            {
                CError.Throw(ex);
            }
        }
        #endregion


        #region FUNCTIOIN
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
                        Monitor.Enter(this.m_OInterrupt);

                        if (String.IsNullOrEmpty(this.m_StrFile) == false)
                        {
                            if (File.Exists(this.m_StrFile) == true)
                            {
                                Bitmap OSource = new Bitmap(this.m_StrFile);
                                this.m_OCdpImage.Image = new CogImage8Grey(OSource);
                                OSource.Dispose();
                                OSource = null;

                                this.m_StrFile = string.Empty;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        CError.Ignore(ex);
                    }
                    finally
                    {
                        Monitor.Exit(this.m_OInterrupt);
                    }

                    Thread.Sleep(1);
                }
            }
            catch (Exception ex)
            {
                CError.Throw(ex);
            }
        }


        public void RequestImage(string StrFile)
        {
            try
            {
                Monitor.Enter(this.m_OInterrupt);

                this.m_StrFile = StrFile;
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
