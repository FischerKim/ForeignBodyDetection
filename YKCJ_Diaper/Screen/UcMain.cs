using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Jhjo.Common;
using System.Threading;
using Cognex.VisionPro;
using Cognex.VisionPro.Blob;
using Cognex.VisionPro.Display;

namespace YKCJ_Diaper
{
    public partial class UcMain : UcScreen
    {
        #region VARIABLE
        private UcSubMain m_OScreen = null;
        private UcHome m_OHomeScreen = null;
        private UcRecipe m_ORecipeScreen = null;
        private UcSetup m_OSetupScreen = null;
        private UcDefineSubStance m_OSubStanceScreen = null;
        private UcIO m_OIOScreen = null;

        private CMainImageHelperTool m_OImageHelperTool = null;
        #endregion


        #region CONSTRUCTOR & DESTRUCTOR
        public UcMain()
        {
            InitializeComponent();

            try
            {
                this.CdpDisplayer.AutoFit = true;
                this.CdpDisplayer.BackColor = Color.Black;
                this.CdpDisplayer.HorizontalScrollBar = false;
                this.CdpDisplayer.VerticalScrollBar = false;


                this.LblLeft.Text = CEnvironment.It.StrSystemLeft;
                this.LblRight.Text = CEnvironment.It.StrSystemRight;

                this.m_OHomeScreen = new UcHome();
                this.m_OHomeScreen.Dock = DockStyle.Fill;
                this.m_OHomeScreen.ScreenFixed += new UcSubMain.ScreenFixedHandler(this.OScreen_ScreenFixed);
                this.m_ORecipeScreen = new UcRecipe();
                this.m_ORecipeScreen.Dock = DockStyle.Fill;
                this.m_OSetupScreen = new UcSetup();
                this.m_OSetupScreen.Dock = DockStyle.Fill;
                this.m_OSubStanceScreen = new UcDefineSubStance();
                this.m_OSubStanceScreen.Dock = DockStyle.Fill;
                this.m_OIOScreen = new UcIO();
                this.m_OIOScreen.Dock = DockStyle.Fill;

                this.m_OImageHelperTool = new CMainImageHelperTool(this.CdpDisplayer);
                this.m_OImageHelperTool.DrawCenterLine
                (
                    CEnvironment.It.BCenterLineEnabled,
                    CEnvironment.It.F64CenterLineX,
                    CEnvironment.It.F64CenterLineY
                );

                CEnvironment.It.DirectionInfoChanged = OEnvironment_DirectionInfoChanged;
                CEnvironment.It.ChangedCenterLine = this.OEnvironment_ChangedCenterLine;
            }
            catch (Exception ex)
            {
                CError.Throw(ex);
            }
        }
        #endregion
               

        #region EVENT
        #region ETC EVENT
        private void Splitter_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                if (this.m_OScreen.GetType() == typeof(UcHome))
                {
                    if (this.PnlLeft.Width == 750)
                    {
                        this.PnlLeft.Size = new Size(540, this.PnlLeft.Height);
                    }
                    else
                    {
                        this.PnlLeft.Size = new Size(750, this.PnlLeft.Height);
                    }
                }
                else
                {
                    this.PnlLeft.Size = new Size(540, this.PnlLeft.Height);
                }
            }
            catch (Exception ex)
            {
                CError.Show(ex);
            }
        }


        private void Splitter_LocationChanged(object sender, EventArgs e)
        {
            try
            {
                Monitor.Enter(frmMain.OScreenInterrupt);

                this.m_OScreen.Refresh();
            }
            catch (Exception ex)
            {
                CError.Show(ex);
            }
            finally
            {
                Monitor.Exit(frmMain.OScreenInterrupt);
            }
        }


        private void OScreen_ScreenFixed(bool BFixed)
        {
            try
            {
                base.OnScreenFixed(BFixed);
            }
            catch (Exception ex)
            {
                CError.Throw(ex);
            }
        }


        private void OEnvironment_DirectionInfoChanged()
        {
            try
            {
                this.LblLeft.Text = CEnvironment.It.StrSystemLeft;
                this.LblRight.Text = CEnvironment.It.StrSystemRight;
            }
            catch (Exception ex)
            {
                CError.Throw(ex);
            }
        }


        private void OEnvironment_ChangedCenterLine()
        {
            try
            {
                this.m_OImageHelperTool.DrawCenterLine
                (
                    CEnvironment.It.BCenterLineEnabled,
                    CEnvironment.It.F64CenterLineX,
                    CEnvironment.It.F64CenterLineY
                );
            }
            catch (Exception ex)
            {
                CError.Throw(ex);
            }
        }
        #endregion
        #endregion


        #region FUNCTION
        public override void OpenSubScreen(ESUBSCREEN ESubScreen)
        {
            try
            {
                if (ESubScreen == ESUBSCREEN.HOME)
                {
                    this.SetScreen(this.m_OHomeScreen);

                    this.PnlLeft.Size = new Size(750, this.PnlLeft.Height);
                    this.Splitter.Enabled = true;
                }
                else if (ESubScreen == ESUBSCREEN.RECIPE)
                {
                    this.SetScreen(this.m_ORecipeScreen);

                    this.PnlLeft.Size = new Size(440, this.PnlLeft.Height);
                    this.Splitter.Enabled = false;
                }
                else if (ESubScreen == ESUBSCREEN.SETUP)
                {
                    this.SetScreen(this.m_OSetupScreen);

                    this.PnlLeft.Size = new Size(540, this.PnlLeft.Height);
                    this.Splitter.Enabled = true;
                }
                else if (ESubScreen == ESUBSCREEN.SUBSTANCE)
                {
                    this.SetScreen(this.m_OSubStanceScreen);

                    this.PnlLeft.Size = new Size(540, this.PnlLeft.Height);
                    this.Splitter.Enabled = true;
                }
                else if (ESubScreen == ESUBSCREEN.IO)
                {
                    this.SetScreen(this.m_OIOScreen);

                    this.PnlLeft.Size = new Size(540, this.PnlLeft.Height);
                    this.Splitter.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                CError.Throw(ex);
            }
        }


        private void SetScreen(UcSubMain OScreen)
        {
            try
            {
                if (this.m_OScreen == null)
                {
                    OScreen.Add();
                    
                    this.PnlSubScreen.Controls.Add(OScreen);
                    OScreen.BringToFront();

                    this.m_OScreen = OScreen;
                }
                else
                {
                    if (this.m_OScreen.GetType() != OScreen.GetType())
                    {
                        this.m_OScreen.Remove();
                        OScreen.Add();

                        this.PnlSubScreen.Controls.Add(OScreen);
                        OScreen.BringToFront();
                        this.PnlSubScreen.Controls.Remove(this.m_OScreen);

                        this.m_OScreen = OScreen;
                    }
                }
            }
            catch (Exception ex)
            {
                CError.Throw(ex);
            }
        }


        public override void SetRecipe(CDiaperFaultRecipe ORecipe)
        {
            try
            {
                this.m_OImageHelperTool.SetRecipe(ORecipe);
            }
            catch (Exception ex)
            {
                CError.Throw(ex);
            }
        }


        public override void SetResult(CDiaperFaultResult OResult)
        {
            try
            {
                if (this.InvokeRequired == true)
                {
                    this.m_OImageHelperTool.SetResult(OResult);
                }

                this.SendSubScreen(OResult);
            }
            catch (Exception ex)
            {
                CError.Throw(ex);
            }
        }


        public override void OnTimer1000()
        {
            try
            {
                this.m_OScreen.OnTimer1000();
            }
            catch (Exception ex)
            {
                CError.Throw(ex);
            }
        }


        private void SendSubScreen(CDiaperFaultResult OResult)
        {
            try
            {
                if (this.InvokeRequired == true)
                {
                    this.m_OHomeScreen.SetResult(OResult);
                }
                else
                {
                    if (this.m_OScreen.GetType() == this.m_OHomeScreen.GetType())
                    {
                        this.m_OHomeScreen.SetResult(OResult);
                    }
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
