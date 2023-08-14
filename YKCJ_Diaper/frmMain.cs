using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Jhjo.Common;
using System.Threading;
using Cognex.VisionPro;

namespace YKCJ_Diaper
{
    public partial class frmMain : Form
    {
        #region STATIC VARIABLE
        public static object OScreenInterrupt = null;
        #endregion


        #region VARIABLE
        private UcScreen m_OScreen = null;
        private UcMain m_OMain = null;
        private UcReport m_OReport = null;
        #endregion


        #region CONSTRUCTOR & DESTRUCTOR
        public frmMain()
        {
            InitializeComponent();

            try
            {
                frmMain.OScreenInterrupt = new object();
            }
            catch (Exception ex)
            {
                CError.Throw(ex);
            }
        }
        #endregion


        #region EVENT
        #region FORM EVENT
        private void frmMain_Load(object sender, EventArgs e)
        {
            try
            {
                this.m_OMain = new UcMain();
                this.m_OMain.Dock = DockStyle.Fill;
                this.m_OMain.ScreenFixed += new UcScreen.ScreenFixedHandler(this.OScreen_ScreenFixed);
                this.m_OReport = new UcReport();
                this.m_OReport.Dock = DockStyle.Fill;

                this.m_OMain.Add();
                this.m_OMain.OpenSubScreen(ESUBSCREEN.HOME);
                this.PnlBody.Controls.Add(this.m_OMain);
                this.m_OScreen = this.m_OMain;

                this.ReadyTool();
                this.ReadyToolSummary();
                this.ReadySubStance();
                this.ReadyIO();

                this.LblMachine.Text = CEnvironment.It.StrSystemMachine;
                this.LblInspObject.Text = CEnvironment.It.StrSystemObject;
                this.LblRecipe.Text = CEnvironment.It.StrSystemRecipe;
            }
            catch (Exception ex)
            {
                CError.Show(ex);
            }
        }


        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                CEnvironment.It.U64TotalCount = CToolSummary.It.U64TotalCount;
                CEnvironment.It.U64OKCount = CToolSummary.It.U64OKCount;
                CEnvironment.It.U64NGCount = CToolSummary.It.U64NGCount;
                CEnvironment.It.Commit();
            }
            catch (Exception ex)
            {
                CError.Show(ex);
            }
        }
        #endregion


        #region BUTTON EVENT
        private void BtnMinimize_Click(object sender, EventArgs e)
        {
            try
            {
                this.WindowState = FormWindowState.Minimized;
            }
            catch (Exception ex)
            {
                CError.Show(ex);
            }
        }


        private void BtnHome_Click(object sender, EventArgs e)
        {
            try
            {
                this.SetScreen(this.m_OMain, ESUBSCREEN.HOME);
            }
            catch (Exception ex)
            {
                CError.Show(ex);
            }
        }


        private void BtnRecipe_Click(object sender, EventArgs e)
        {
            try
            {
                this.SetScreen(this.m_OMain, ESUBSCREEN.RECIPE);
            }
            catch (Exception ex)
            {
                CError.Show(ex);
            }
        }


        private void BtnSetup_Click(object sender, EventArgs e)
        {
            try
            {
                this.SetScreen(this.m_OMain, ESUBSCREEN.SETUP);
            }
            catch (Exception ex)
            {
                CError.Show(ex);
            }
        }


        private void BtnSubStance_Click(object sender, EventArgs e)
        {
            try
            {
                this.SetScreen(this.m_OMain, ESUBSCREEN.SUBSTANCE);
            }
            catch (Exception ex)
            {
                CError.Show(ex);
            }
        }


        private void BtnIO_Click(object sender, EventArgs e)
        {
            try
            {
                this.SetScreen(this.m_OMain, ESUBSCREEN.IO);
            }
            catch (Exception ex)
            {
                CError.Show(ex);
            }
        }


        private void BtnReport_Click(object sender, EventArgs e)
        {
            try
            {
                this.SetScreen(this.m_OReport, ESUBSCREEN.NONE);
            }
            catch (Exception ex)
            {
                CError.Show(ex);
            }
        }


        private void BtnExit_Click(object sender, EventArgs e)
        {
            try
            {
                this.Close();
            }
            catch (Exception ex)
            {
                CError.Show(ex);
            }
        }
        #endregion


        #region ETC EVENT
        private void LblReject_Click(object sender, EventArgs e)
        {
            try
            {
                Monitor.Enter(frmMain.OScreenInterrupt);


                if (CDiaperFaultTool.It.BReject == true)
                {
                    CDiaperFaultTool.It.BReject = false;
                    this.LblReject.BackColor = Color.ForestGreen;
                }
                else
                {
                    CDiaperFaultTool.It.BReject = true;
                    this.LblReject.BackColor = Color.DarkRed;
                }
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


        private void Timer1000_Tick(object sender, EventArgs e)
        {
            try
            {
                CToolSummary.It.TimeReset();

                this.LblTime.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

                Monitor.Enter(frmMain.OScreenInterrupt);

                if (this.m_OScreen != null)
                {
                    this.m_OScreen.OnTimer1000();
                }
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
                if (BFixed == true)
                {
                    this.BtnReport.BackColor = SystemColors.Control;
                    this.BtnExit.BackColor = SystemColors.Control;
                    this.BtnReport.Enabled = false;
                    this.BtnExit.Enabled = false;
                }
                else
                {
                    this.BtnReport.BackColor = Color.SteelBlue;
                    this.BtnExit.BackColor = Color.SteelBlue;
                    this.BtnReport.Enabled = true;
                    this.BtnExit.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                CError.Throw(ex);
            }
        }


        private void OMain_ChangedReject(bool BReject)
        {
            try
            {
                this.LblReject.BackColor = (BReject == true) ? Color.DarkRed : Color.ForestGreen;
            }
            catch (Exception ex)
            {
                CError.Throw(ex);
            }
        }


        private void OEnvironment_ChangedSystemInfo()
        {
            try
            {
                this.LblMachine.Text = CEnvironment.It.StrSystemMachine;
                this.LblInspObject.Text = CEnvironment.It.StrSystemObject;
                this.LblRecipe.Text = CEnvironment.It.StrSystemRecipe;
            }
            catch (Exception ex)
            {
                CError.Throw(ex);
            }
        }


        private void ODiaperFaultTool_RecipeChanged(CDiaperFaultRecipe ORecipe)
        {
            try
            {
                Monitor.Enter(frmMain.OScreenInterrupt);

                this.m_OScreen.SetRecipe(ORecipe);
            }
            catch (Exception ex)
            {
                CError.Throw(ex);
            }
            finally
            {
                Monitor.Exit(frmMain.OScreenInterrupt);
            }
        }


        private void ODiaperFaultTool_Inspected(CDiaperFaultResult OResult)
        {
            try
            {
                
                if (this.InvokeRequired == true)
                {
                    this.SendSubScreen(OResult);
                    this.BeginInvoke(new CDiaperFaultTool.InspectedHandler(this.ODiaperFaultTool_Inspected), OResult);
                }
                else
                {
                    if (OResult.BInspected == true)
                    {
                        if (OResult.BOK == true)
                        {
                            CToolSummary.It.IncreaseOK();

                            this.LblProduct.Text = "정상";
                            this.LblProduct.ForeColor = Color.White;
                            this.LblProduct.BackColor = Color.Lime;
                        }
                        else
                        {
                            CToolSummary.It.IncreaseNG();

                            this.LblProduct.Text = "불량";
                            this.LblProduct.ForeColor = Color.White;
                            this.LblProduct.BackColor = Color.Red;
                        }
                    } 
                    else
                    {
                        this.LblProduct.Text = "-";
                        this.LblProduct.ForeColor = Color.Black;
                        this.LblProduct.BackColor = SystemColors.Control;
                    }

                    this.SendSubScreen(OResult);
                }
            }
            catch (Exception ex)
            {
                CError.Throw(ex);
            }
        }
        #endregion
        #endregion


        #region FUNCTION
        private void ReadyIO()
        {
            try
            {
                DataTable ODataSource = CDB.It[CDB.TABLE_IO_LIST].Select().Copy();

                foreach (DataRow _Item in ODataSource.Rows)
                {
                    EIO EIOSignal = (EIO)Enum.Parse(typeof(EIO), (string)_Item[CDB.IO_LIST_NAME]);

                    if (EIOSignal == EIO.NG)
                    {
                        CControlBox.It.SetIOEvent((ushort)_Item[CDB.IO_LIST_PORT], EIOSignal, (int)_Item[CDB.IO_LIST_ON_INTERVAL]);
                    }
                    else
                    {
                        if ((bool)_Item[CDB.IO_LIST_ENABLED] == false) continue;

                        if (EIOSignal == EIO.REJECT)
                        {
                            CControlBox.It.SetIOManual((ushort)_Item[CDB.IO_LIST_PORT], EIOSignal);
                        }
                        else if ((EIOSignal == EIO.READY) || (EIOSignal == EIO.AIR))
                        {
                            CControlBox.It.SetIOPulse((ushort)_Item[CDB.IO_LIST_PORT], EIOSignal, (int)_Item[CDB.IO_LIST_ON_INTERVAL], (int)_Item[CDB.IO_LIST_OFF_INTERVAL]);
                        }
                        else
                        {
                            CControlBox.It.SetIOEvent((ushort)_Item[CDB.IO_LIST_PORT], EIOSignal, (int)_Item[CDB.IO_LIST_ON_INTERVAL]);
                        }
                    }
                }

                if (ODataSource != null)
                {
                    ODataSource.Dispose();
                    ODataSource = null;
                }
            }
            catch (Exception ex)
            {
                CError.Throw(ex);
            }
        }


        private void ReadyTool()
        {
            try
            {
                CEnvironment.It.ChangedSystemInfo = this.OEnvironment_ChangedSystemInfo;
                CDiaperFaultTool.It.OExporter = CAcquisitionManager.It.OCameara;
                CDiaperFaultTool.It.Inspected = this.ODiaperFaultTool_Inspected;
                CDiaperFaultTool.It.RecipeChanged = this.ODiaperFaultTool_RecipeChanged;

                string StrRecipe = CEnvironment.It.StrSystemRecipe;
                if (String.IsNullOrEmpty(StrRecipe) == false)
                {
                    foreach (CDiaperFaultRecipe _Item in CRecipeManager.It.LstORecipe)
                    {
                        if (_Item.StrName != StrRecipe) continue;

                        CDiaperFaultTool.It.ORecipe = _Item;
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                CError.Throw(ex);
            }
        }


        private void ReadyToolSummary()
        {
            try
            {
                bool[] ArrBResetEnabled = new bool[3];
                TimeSpan[] ArrOResetTime = new TimeSpan[3];

                DataTable ODataSource = CDB.It[CDB.TABLE_SUMMARY_RESET].Select();
                foreach (DataRow _Item in ODataSource.Rows)
                {
                    int I32Index = (int)_Item[CDB.SUMMARY_RESET_INDEX];

                    if ((bool)_Item[CDB.SUMMARY_RESET_ENABLED] == true)
                    {
                        ArrBResetEnabled[I32Index] = true;
                        ArrOResetTime[I32Index] = new TimeSpan
                        (
                            (int)_Item[CDB.SUMMARY_RESET_HOUR],
                            (int)_Item[CDB.SUMMARY_RESET_MINUTE],
                            0
                        );
                    }
                    else
                    {
                        ArrBResetEnabled[I32Index] = false;
                        ArrOResetTime[I32Index] = TimeSpan.Zero;
                    }
                }
                if (ODataSource != null)
                {
                    ODataSource.Dispose();
                    ODataSource = null;
                }


                CToolSummary.It.U64TotalCount = CEnvironment.It.U64TotalCount;
                CToolSummary.It.U64OKCount = CEnvironment.It.U64OKCount;
                CToolSummary.It.U64NGCount = CEnvironment.It.U64NGCount;
                CToolSummary.It.ArrBResetEnabled = ArrBResetEnabled;
                CToolSummary.It.ArrOResetTime = ArrOResetTime;
            }
            catch (Exception ex)
            {
                CError.Throw(ex);
            }
        }


        private void ReadySubStance()
        {
            try
            {
                DataTable OSubStanceList = CDB.It[CDB.TABLE_SUBSTANCE_LIST].Select();
                DataTable OSubStanceInfo = CDB.It[CDB.TABLE_SUBSTANCE_INFO].Select();

                CSubStanceFilterList OSubStanceFilterList = new CSubStanceFilterList();
                foreach (DataRow _Item in OSubStanceList.Rows)
                {
                    CSubStanceFilter OFilter = new CSubStanceFilter();
                    OFilter.StrName = (string)_Item[CDB.SUBSTANCE_LIST_NAME];
                    OFilter.EColor = (CogColorConstants)Enum.Parse(typeof(CogColorConstants), (string)_Item[CDB.SUBSTANCE_LIST_COLOR]);
                    OSubStanceFilterList.OList.Add(OFilter);
                }

                foreach (DataRow _Item1 in OSubStanceInfo.Rows)
                {
                    foreach (CSubStanceFilter _Item2 in OSubStanceFilterList.OList)
                    {
                        if (_Item2.StrName != (string)_Item1[CDB.SUBSTANCE_INFO_NAME]) continue;
                        
                        if (_Item2.OXLength.EKind.ToString() == (string)_Item1[CDB.SUBSTANCE_INFO_FEATURE])
                        {
                            _Item2.OXLength.BEnabled = (bool)_Item1[CDB.SUBSTANCE_INFO_ENABLED];
                            _Item2.OXLength.BEnabledMin = (bool)_Item1[CDB.SUBSTANCE_INFO_MIN_ENABLED];
                            _Item2.OXLength.F64Min = (double)_Item1[CDB.SUBSTANCE_INFO_MIN];
                            _Item2.OXLength.BEnabledMax = (bool)_Item1[CDB.SUBSTANCE_INFO_MAX_ENABLED];
                            _Item2.OXLength.F64Max = (double)_Item1[CDB.SUBSTANCE_INFO_MAX];
                        }
                        else if (_Item2.OYLength.EKind.ToString() == (string)_Item1[CDB.SUBSTANCE_INFO_FEATURE])
                        {
                            _Item2.OYLength.BEnabled = (bool)_Item1[CDB.SUBSTANCE_INFO_ENABLED];
                            _Item2.OYLength.BEnabledMin = (bool)_Item1[CDB.SUBSTANCE_INFO_MIN_ENABLED];
                            _Item2.OYLength.F64Min = (double)_Item1[CDB.SUBSTANCE_INFO_MIN];
                            _Item2.OYLength.BEnabledMax = (bool)_Item1[CDB.SUBSTANCE_INFO_MAX_ENABLED];
                            _Item2.OYLength.F64Max = (double)_Item1[CDB.SUBSTANCE_INFO_MAX];
                        }
                        else if (_Item2.OPerimeter.EKind.ToString() == (string)_Item1[CDB.SUBSTANCE_INFO_FEATURE])
                        {
                            _Item2.OPerimeter.BEnabled = (bool)_Item1[CDB.SUBSTANCE_INFO_ENABLED];
                            _Item2.OPerimeter.BEnabledMin = (bool)_Item1[CDB.SUBSTANCE_INFO_MIN_ENABLED];
                            _Item2.OPerimeter.F64Min = (double)_Item1[CDB.SUBSTANCE_INFO_MIN];
                            _Item2.OPerimeter.BEnabledMax = (bool)_Item1[CDB.SUBSTANCE_INFO_MAX_ENABLED];
                            _Item2.OPerimeter.F64Max = (double)_Item1[CDB.SUBSTANCE_INFO_MAX];
                        }
                        else if (_Item2.OArea.EKind.ToString() == (string)_Item1[CDB.SUBSTANCE_INFO_FEATURE])
                        {
                            _Item2.OArea.BEnabled = (bool)_Item1[CDB.SUBSTANCE_INFO_ENABLED];
                            _Item2.OArea.BEnabledMin = (bool)_Item1[CDB.SUBSTANCE_INFO_MIN_ENABLED];
                            _Item2.OArea.F64Min = (double)_Item1[CDB.SUBSTANCE_INFO_MIN];
                            _Item2.OArea.BEnabledMax = (bool)_Item1[CDB.SUBSTANCE_INFO_MAX_ENABLED];
                            _Item2.OArea.F64Max = (double)_Item1[CDB.SUBSTANCE_INFO_MAX];
                        }
                        else if (_Item2.OElongation.EKind.ToString() == (string)_Item1[CDB.SUBSTANCE_INFO_FEATURE])
                        {
                            _Item2.OElongation.BEnabled = (bool)_Item1[CDB.SUBSTANCE_INFO_ENABLED];
                            _Item2.OElongation.BEnabledMin = (bool)_Item1[CDB.SUBSTANCE_INFO_MIN_ENABLED];
                            _Item2.OElongation.F64Min = (double)_Item1[CDB.SUBSTANCE_INFO_MIN];
                            _Item2.OElongation.BEnabledMax = (bool)_Item1[CDB.SUBSTANCE_INFO_MAX_ENABLED];
                            _Item2.OElongation.F64Max = (double)_Item1[CDB.SUBSTANCE_INFO_MAX];
                        }
                        break;
                    }
                }

                CDiaperFaultTool.It.OSubStance = OSubStanceFilterList;

                if (OSubStanceList != null)
                {
                    OSubStanceList.Dispose();
                    OSubStanceList = null;
                }
                if (OSubStanceInfo != null)
                {
                    OSubStanceInfo.Dispose();
                    OSubStanceInfo = null;
                }
            }
            catch (Exception ex)
            {
                CError.Throw(ex);
            }
        }


        private void SetScreen(UcScreen OScreen, ESUBSCREEN ESubScreen)
        {
            try
            {
                Monitor.Enter(frmMain.OScreenInterrupt);

                if (this.m_OScreen.GetType() != OScreen.GetType())
                {
                    this.m_OScreen.Remove();
                    OScreen.Add();
                    OScreen.OpenSubScreen(ESubScreen);

                    this.PnlBody.Controls.Add(OScreen);
                    OScreen.BringToFront();
                    this.PnlBody.Controls.Remove(this.m_OScreen);

                    this.m_OScreen = OScreen;
                }
                else this.m_OScreen.OpenSubScreen(ESubScreen);
            }
            catch (Exception ex)
            {
                CError.Throw(ex);
            }
            finally
            {
                Monitor.Exit(frmMain.OScreenInterrupt);
            }
        }


        private void SendSubScreen(CDiaperFaultResult OResult)
        {
            try
            {
                Monitor.Enter(frmMain.OScreenInterrupt);

                this.m_OScreen.SetResult(OResult);
            }
            catch (Exception ex)
            {
                CError.Throw(ex);
            }
            finally
            {
                Monitor.Exit(frmMain.OScreenInterrupt);
            }
        }
        #endregion
    }
}
