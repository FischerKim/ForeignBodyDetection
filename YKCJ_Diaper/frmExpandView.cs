using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Cognex.VisionPro;
using Jhjo.Common;
using System.Threading;
using Cognex.VisionPro.ImageProcessing;

namespace YKCJ_Diaper
{
    public partial class frmExpandView : Form
    {
        #region VARIABLE
        private CogImage8Grey m_OSource = null;
        private CogCopyRegionTool m_OTool = null;
        private CogRectangle m_OBound = null;
        private object m_OInterrupt = null;

        private Thread m_OWorker = null;
        private bool m_BDoWork = false;
        #endregion


        #region PROPERTIES
        public double F64X
        {
            set { this.m_OBound.X = value; }
        }


        public double F64Y
        {
            set { this.m_OBound.Y = value; }
        }


        public double F64Width
        {
            set { this.m_OBound.Width = value; }
        }


        public double F64Height
        {
            set { this.m_OBound.Height = value; }
        }
        #endregion


        #region CONSTRUCTOR & DESTRUCTOR
        public frmExpandView()
        {
            InitializeComponent();

            try
            {
                this.m_OBound = new CogRectangle();
                this.m_OTool = new CogCopyRegionTool();
                this.m_OTool.Region = this.m_OBound;
                this.m_OInterrupt = new object();

                this.BeginWork();
            }
            catch (Exception ex)
            {
                CError.Throw(ex);
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
                        CogImage8Grey OSource = this.GetImage();

                        if (OSource != null)
                        {
                            this.m_OTool.InputImage = OSource;
                            this.m_OTool.Run();

                            this.CdpDisplayer.Image = this.m_OTool.OutputImage;
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


        public void SetImage(CogImage8Grey OSource)
        {
            try
            {
                Monitor.Enter(this.m_OInterrupt);

                this.m_OSource = OSource;
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


        private CogImage8Grey GetImage()
        {
            CogImage8Grey OResult = null;

            try
            {
                Monitor.Enter(this.m_OInterrupt);

                OResult = this.m_OSource;
                this.m_OSource = null;
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


        public void Destory()
        {
            try
            {
                this.EndWork();

                if (this.m_OTool != null)
                {
                    this.m_OTool.Dispose();
                    this.m_OTool = null;
                }
            }
            catch (Exception ex)
            {
                CError.Throw(ex);
            }
        }
        #endregion
    }
}
