using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Daekhon.Common;
using Jhjo.Common;
using System.Threading;
using System.IO;
using System.Drawing;

namespace YKCJ_Diaper
{
    public class CSimulator : IImageExporter, IDisposable
    {
        #region VARIABLE
        private string m_StrDirectory = string.Empty;
        private string[] m_ArrStrFile = null;
        private int m_I32Index = 0;

        private bool m_BRun = false;
        private bool m_BRequireImage = false;

        private Thread m_OWorker = null;
        private bool m_BDoWork = false;
        #endregion


        #region EVENT
        public event ExportedHandler Exported = null;
        #endregion


        #region DELEGATE & EVENT
        public bool BRun
        {
            get { return this.m_BRun; }
        }
        #endregion


        #region CONSTRUCTOR & DESTRUCTOR
        public CSimulator(string StrDirectory)
        {
            try
            {
                this.m_StrDirectory = StrDirectory;
                this.m_ArrStrFile = Directory.GetFiles(this.m_StrDirectory, "*.bmp");

                this.BeginWork();
            }
            catch (Exception ex)
            {
                CError.Throw(ex);
            }
        }


        ~CSimulator()
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
                        if (this.m_BRun == true)
                        {
                            //if (this.m_BRequireImage == true)
                            //{
                                this.m_BRequireImage = false;

                                Bitmap OSource = new Bitmap(this.m_ArrStrFile[this.m_I32Index]);
                                CImageInfo OImageInfo = new CImageInfo(OSource);
                                this.OnExported(OImageInfo);
                                if (OSource != null)
                                {
                                    OSource.Dispose();
                                    OSource = null;
                                }

                                this.m_I32Index++;
                                if (this.m_I32Index >= this.m_ArrStrFile.Length)
                                {
                                    this.m_I32Index = 0;
                                }
                            //}
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
                CError.Ignore(ex);
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


        public void OneShot()
        {
            try
            {
                this.m_BRequireImage = true;
            }
            catch (Exception ex)
            {
                CError.Throw(ex);
            }
        }


        public void Start()
        {
            try
            {
                this.m_BRun = true;
            }
            catch (Exception ex)
            {
                CError.Throw(ex);
            }
        }


        public void Stop()
        {
            try
            {
                this.m_BRun = false;
            }
            catch (Exception ex)
            {
                CError.Throw(ex);
            }
        }


        public void OnExported(CImageInfo OImageInfo)
        {
            try
            {
                if (this.Exported != null)
                {
                    this.Exported(OImageInfo);
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
