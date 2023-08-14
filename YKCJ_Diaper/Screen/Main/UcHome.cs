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
using System.Diagnostics;

namespace YKCJ_Diaper
{
    public partial class UcHome : UcSubMain
    {
        #region VARIABLE
        private DateTime m_OStart = DateTime.MinValue;
        private DateTime m_OTraceResetTime = DateTime.MinValue;
        private int m_I32DownOccur = 0;

        private List<CDiaperFaultResult> m_LstONG = null;
        private CHomeNGHelperTool m_ONGHelperTool = null;
        private CHomeTraceHelperTool m_OTraceHelperTool = null;

        private frmExpandView m_OExpandViewer = null;
        private bool m_BCloseExpandViewerByOrder = false;

        private PerformanceCounter m_OPerformanceCounter = null;

        private ulong m_U64SummaryTotal = 0;
        private ulong m_U64SummaryOK = 0;
        private ulong m_U64SummaryNG = 0;

        private bool m_BPreventEvent = false;
        #endregion


        #region CONSTRUCTOR & DESTRUCTOR
        public UcHome()
        {
            InitializeComponent();

            try
            {
                this.m_BPreventEvent = true;

                this.CdpNG.AutoFit = true;
                this.CdpNG.BackColor = Color.Black;
                this.CdpNG.VerticalScrollBar = false;
                this.CdpNG.HorizontalScrollBar = false;

                this.CdpTrace.AutoFit = true;
                this.CdpTrace.BackColor = Color.Black;
                this.CdpTrace.VerticalScrollBar = false;
                this.CdpTrace.HorizontalScrollBar = false;

                this.CdpZoom.AutoFit = true;
                this.CdpZoom.BackColor = Color.Black;
                this.CdpZoom.VerticalScrollBar = false;
                this.CdpZoom.HorizontalScrollBar = false;





                this.m_OStart = DateTime.Now;
                this.m_OTraceResetTime = DateTime.Now;

                this.m_LstONG = new List<CDiaperFaultResult>();
                this.m_ONGHelperTool = new CHomeNGHelperTool(this.CdpNG, this.CdpZoom);
                this.m_OTraceHelperTool = new CHomeTraceHelperTool(this.CdpTrace);

                this.m_OPerformanceCounter = new PerformanceCounter("Processor", "% Processor Time", "_Total");

                //this.TrkGain.Minimum = CAcquisitionManager.It.OCameara.I32GainMin;
                //this.TrkGain.Maximum = CAcquisitionManager.It.OCameara.I32GainMax;
                this.NudGain.Minimum = this.TrkGain.Minimum;
                this.NudGain.Maximum = this.TrkGain.Maximum;

                CDiaperFaultTool.It.SaveOKImage = this.ODiaperFaultTool_SaveOKImage;
                CEnvironment.It.ChangedExpandView = this.OEnvironment_ChangedExpandView;

                this.LblTotalCount.Text = this.m_U64SummaryTotal.ToString();
                this.LblOKCount.Text = this.m_U64SummaryOK.ToString();
                this.LblNGCount.Text = this.m_U64SummaryNG.ToString();
                if (this.m_U64SummaryTotal == 0)
                {
                    this.LblOKRate.Text = "0";
                    this.LblNGRate.Text = "0";
                }
                else
                {
                    this.LblOKRate.Text = (Math.Round((decimal)this.m_U64SummaryOK / this.m_U64SummaryTotal, 4) * 100).ToString("00.00");
                    this.LblNGRate.Text = (Math.Round((decimal)this.m_U64SummaryNG / this.m_U64SummaryTotal, 4) * 100).ToString("00.00");
                }
            }
            catch (Exception ex)
            {
                CError.Throw(ex);
            }
            finally
            {
                this.m_BPreventEvent = false;
            }
        }
        #endregion


        #region EVENT
        #region BUTTON EVENT
        private void BtnResetCount_Click(object sender, EventArgs e)
        {
            try
            {
                CToolSummary.It.Reset();
                this.DisplayToolSummary();
            }
            catch (Exception ex)
            {
                CError.Show(ex);
            }
        }


        private void BtnResetTrace_Click(object sender, EventArgs e)
        {
            try
            {
                this.m_OTraceHelperTool.Clear();
            }
            catch (Exception ex)
            {
                CError.Show(ex);
            }
        }


        private void BtnSaveOK_Click(object sender, EventArgs e)
        {
            try
            {
                CDiaperFaultTool.It.BSaveOK = true;

                this.BtnSaveOK.Text = "(0/100)";
                this.BtnSaveOK.BackColor = Color.ForestGreen;
                this.BtnSaveOK.Enabled = false;
            }
            catch (Exception ex)
            {
                CError.Show(ex);
            }
        }


        private void BtnResetModel_Click(object sender, EventArgs e)
        {
            try
            {
                if (CDiaperFaultTool.It.ORecipe != null)
                {
                    string StrRecipe = CDiaperFaultTool.It.ORecipe.StrName;

                    foreach (CDiaperFaultRecipe _Item in CRecipeManager.It.LstORecipe)
                    {
                        if (_Item.StrName != StrRecipe) continue;

                        CDiaperFaultTool.It.ORecipe = new CDiaperFaultRecipe(_Item);
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                CError.Show(ex);
            }
        }
        

        private void BtnRun_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.BtnRun.Text == "시작")
                {
                    CAcquisitionManager.It.OCameara.Start();
                   
                    CControlBox.It.On(EIO.READY);
                    CControlBox.It.On(EIO.AIR);

                    this.BtnRun.Text = "정지";
                    this.BtnRun.BackColor = Color.ForestGreen;

                    base.OnScreenFixed(true);
                }
                else
                {
                    CAcquisitionManager.It.OCameara.Stop();

                    CControlBox.It.Off(EIO.READY);
                    CControlBox.It.Off(EIO.AIR);

                    this.BtnRun.Text = "시작";
                    this.BtnRun.BackColor = Color.DarkRed;

                    this.m_I32DownOccur++;
                    this.LblDownOccur.Text = this.m_I32DownOccur.ToString();

                    base.OnScreenFixed(false);
                }
            }
            catch (Exception ex)
            {
                CError.Show(ex);
            }
        }


        private void BtnExpansionView_Click(object sender, EventArgs e)
        {
            try
            {
                Monitor.Enter(frmMain.OScreenInterrupt);

                if (this.m_OExpandViewer == null)
                {
                    this.m_OExpandViewer = new frmExpandView();
                    this.m_OExpandViewer.F64X = CEnvironment.It.F64ExpandViewX;
                    this.m_OExpandViewer.F64Y = CEnvironment.It.F64ExpandViewY;
                    this.m_OExpandViewer.F64Width = CEnvironment.It.F64ExpandViewWidth;
                    this.m_OExpandViewer.F64Height = CEnvironment.It.F64ExpandViewHeight;
                    this.m_OExpandViewer.FormClosing += new FormClosingEventHandler(this.OExpandViewer_FormClosing);
                    this.m_OExpandViewer.Show();

                    this.BtnExpansionView.Text = "종료";
                    this.BtnExpansionView.BackColor = Color.ForestGreen;
                }
                else
                {
                    if (this.m_OExpandViewer != null)
                    {
                        this.m_BCloseExpandViewerByOrder = true;
                        this.m_OExpandViewer.Close();
                    }
                }
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


        #region ETC EVENT
        private void TrkGain_ValueChanged(object sender, EventArgs e)
        {
            if (this.m_BPreventEvent == true) return;

            try
            {
                this.m_BPreventEvent = true;

                int I32Value = this.TrkGain.Value;

                //CAcquisitionManager.It.OCameara.I32Gain = I32Value;
                this.NudGain.Value = I32Value;

                CEnvironment.It.I32CameraGain = I32Value;
                CEnvironment.It.Commit();
            }
            catch (Exception ex)
            {
                CError.Show(ex);
            }
            finally
            {
                this.m_BPreventEvent = false;
            }
        }


        private void NudGain_ValueChanged(object sender, EventArgs e)
        {
            if (this.m_BPreventEvent == true) return;

            try
            {
                this.m_BPreventEvent = true;

                int I32Value = Convert.ToInt32(this.NudGain.Value);

                //CAcquisitionManager.It.OCameara.I32Gain = I32Value;
                this.TrkGain.Value = I32Value;

                CEnvironment.It.I32CameraGain = I32Value;
                CEnvironment.It.Commit();
            }
            catch (Exception ex)
            {
                CError.Show(ex);
            }
            finally
            {
                this.m_BPreventEvent = false;
            }
        }
        

        private void LtbNG_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.LtbNG.SelectedItem == null) return;
            if (String.IsNullOrEmpty((string)this.LtbNG.SelectedItem) == true) return;

            try
            {
                Monitor.Enter(frmMain.OScreenInterrupt);

                this.DrawNGResult();
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


        private void ChkInspectionSpeed_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.ChkInspectionSpeed.Checked == true)
                {
                    CDiaperFaultTool.It.BInspectionSpeedEnabled = true;
                    CDiaperFaultTool.It.I32InspectionSpeed = Convert.ToInt32(this.NudInspectionSpeed.Value);
                }
                else
                {
                    CDiaperFaultTool.It.BInspectionSpeedEnabled = false;
                }

                this.NudInspectionSpeed.Enabled = !this.ChkInspectionSpeed.Checked;
            }
            catch (Exception ex)
            {
                CError.Show(ex);
            }
        }


        private void ChkTapeSize_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.ChkTapeSize.Checked == true)
                {
                    CDiaperFaultTool.It.BTapeSizeEnabled = true;
                    CDiaperFaultTool.It.I32TapeSize = Convert.ToInt32(this.NudTapeSize.Value);
                }
                else
                {
                    CDiaperFaultTool.It.BTapeSizeEnabled = false;
                }

                this.NudTapeSize.Enabled = !this.ChkTapeSize.Checked;
            }
            catch (Exception ex)
            {
                CError.Show(ex);
            }
        }


        private void ChkSignal_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                CDiaperFaultTool.It.BSendSignal = this.ChkSignal.Enabled;

                if (this.ChkSignal.Checked == true)
                {
                    this.ChkSignal.Text = "전송";
                    this.ChkSignal.BackColor = Color.ForestGreen;
                }
                else
                {
                    this.ChkSignal.Text = "전송않함";
                    this.ChkSignal.BackColor = Color.SteelBlue;
                }
            }
            catch (Exception ex)
            {
                CError.Show(ex);
            }
        }


        private void ChkSaveNG_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                CDiaperFaultTool.It.BSaveNG = this.ChkSaveNG.Checked;

                if (this.ChkSaveNG.Checked == true)
                {
                    this.ChkSaveNG.Text = "저장";
                    this.LblTitleSaveNG.Text = "NG 저장 [O]";
                    this.ChkSaveNG.BackColor = Color.ForestGreen;
                }
                else
                {
                    this.ChkSaveNG.Text = "저장않함";
                    this.LblTitleSaveNG.Text = "NG 저장 [X]";
                    this.ChkSaveNG.BackColor = Color.SteelBlue;
                }
            }
            catch (Exception ex)
            {
                CError.Show(ex);
            }
        }


        private void ODiaperFaultTool_SaveOKImage(int I32Count)
        {
            try
            {
                if (this.InvokeRequired == true)
                {
                    this.BeginInvoke(new CDiaperFaultTool.SaveOKImageHandler(this.ODiaperFaultTool_SaveOKImage), I32Count);
                    return;
                }

                if (I32Count < 100) this.BtnSaveOK.Text = "(" + I32Count + "/100)";
                else
                {
                    this.BtnSaveOK.Enabled = true;
                    this.BtnSaveOK.BackColor = Color.SteelBlue;
                    this.BtnSaveOK.Text = "저장";
                }
            }
            catch (Exception ex)
            {
                CError.Throw(ex);
            }
        }


        private void OEnvironment_ChangedExpandView()
        {
            try
            {
                Monitor.Enter(frmMain.OScreenInterrupt);

                if (this.m_OExpandViewer != null)
                {
                    this.m_OExpandViewer.F64X = CEnvironment.It.F64ExpandViewX;
                    this.m_OExpandViewer.F64Y = CEnvironment.It.F64ExpandViewY;
                    this.m_OExpandViewer.F64Width = CEnvironment.It.F64ExpandViewWidth;
                    this.m_OExpandViewer.F64Height = CEnvironment.It.F64ExpandViewHeight;
                }
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


        private void OExpandViewer_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (this.m_BCloseExpandViewerByOrder == false) Monitor.Enter(frmMain.OScreenInterrupt);

                this.m_OExpandViewer.Destory();
                this.m_OExpandViewer = null;

                this.BtnExpansionView.Text = "실행";
                this.BtnExpansionView.BackColor = Color.SteelBlue;
            }
            catch (Exception ex)
            {
                CError.Throw(ex);
            }
            finally
            {
                if (this.m_BCloseExpandViewerByOrder == false) Monitor.Exit(frmMain.OScreenInterrupt);
                this.m_BCloseExpandViewerByOrder = false;
            }
        }
        #endregion
        #endregion


        #region FUNCTION
        public override void Add()
        {
            try
            {
                this.m_BPreventEvent = true;

                this.DisplayToolSummary();


                //this.TrkGain.Value = CAcquisitionManager.It.OCameara.I32Gain;
                this.NudGain.Value = this.TrkGain.Value;


                this.UpdateNGList();
                if (this.LtbNG.Items.Count > 0)
                {
                    this.LtbNG.SelectedIndex = this.LtbNG.Items.Count - 1;
                    this.DrawNGResult();
                }
            }
            catch (Exception ex)
            {
                CError.Throw(ex);
            }
            finally
            {
                this.m_BPreventEvent = false;
            }
        }


        public override void SetResult(CDiaperFaultResult OResult)
        {
            try
            {
                if (this.InvokeRequired == true)
                {
                    //NG
                    if ((OResult.BInspected == true) && (OResult.BOK == false))
                    {
                        if (this.m_LstONG.Count == 100)
                        {
                            this.m_LstONG.RemoveAt(0);
                        }
                        this.m_LstONG.Add(OResult);
                    }

                    //Expand View
                    if (this.m_OExpandViewer != null) this.m_OExpandViewer.SetImage(OResult.OImageInfo.OImage);

                    //Trace
                    if ((OResult.BInspected == true) && (OResult.BOK == false))
                    {
                        this.m_OTraceHelperTool.SetResult(OResult);
                    }
                }
                else
                {
                    this.DisplayToolSummary();

                    //Measeure
                    this.LblInspectionTime.Text = Math.Round(OResult.F64Period, 2).ToString();
                    
                    //Product
                    if (OResult.BInspected == true)
                    {
                        if (OResult.BOK == true)
                        {
                            this.LblProduct.Text = "정상";
                            this.LblProduct.ForeColor = Color.White;
                            this.LblProduct.BackColor = Color.Lime;
                        }
                        else
                        {
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


                    if ((OResult.BInspected == true) && (OResult.BOK == false))
                    {
                        if (this.LtbNG.Items.Count == 100)
                        {
                            this.LtbNG.Items.RemoveAt(0);
                        }                        
                        this.LtbNG.Items.Add
                        (
                            OResult.OImageInfo.OTime.ToString("yyyy-MM-dd HH:mm:ss.fff") + " " +
                            OResult.OFaultResult.ETool.ToString().Substring(0, 1) +
                            OResult.OFaultResult.I32Index +
                            "(" + Math.Round(OResult.OFaultResult.F64Value) + "," + OResult.OFaultResult.StrReferance + ")"
                        );
                        if (this.LtbNG.Items.Count > 0)
                        {
                            this.LtbNG.SelectedIndex = this.LtbNG.Items.Count - 1;
                            this.DrawNGResult();
                        }
                    }
                }
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
                //검사속도
                this.LblDpm.Text = CDiaperFaultTool.It.ODpm.GetDpm().ToString();
                this.LblDps.Text = CDiaperFaultTool.It.ODpm.GetDps().ToString();


                //운영시간
                DateTime ONow = DateTime.Now;
                TimeSpan OTimeSpan = ONow - this.m_OStart;
                if (OTimeSpan.Days == 0)
                {
                    if (OTimeSpan.Hours == 0) this.LblRunTime.Text = OTimeSpan.Minutes + "M";
                    else this.LblRunTime.Text = OTimeSpan.Hours + "H " + OTimeSpan.Minutes + "M";
                }
                else
                {
                    if (OTimeSpan.Hours == 0) this.LblRunTime.Text = OTimeSpan.Days + "D " + OTimeSpan.Minutes + "M";
                    else this.LblRunTime.Text = OTimeSpan.Days + "D " + OTimeSpan.Hours + "H";
                }


                //CPU 사용률
                this.LblCPU.Text = Math.Round(this.m_OPerformanceCounter.NextValue()).ToString();


                //TRACE 초기화
                if (((this.m_OTraceResetTime.Hour == 6) && (ONow.Hour == 7)) ||
                    ((this.m_OTraceResetTime.Hour == 18) && (ONow.Hour == 19)))
                {
                    this.BtnResetTrace.PerformClick();
                }
                this.m_OTraceResetTime = ONow;
            }
            catch (Exception ex)
            {
                CError.Throw(ex);
            }
        }


        private void UpdateNGList()
        {
            try
            {
                this.LtbNG.BeginUpdate();

                this.LtbNG.Items.Clear();

                foreach (CDiaperFaultResult _Item in this.m_LstONG)
                {
                    this.LtbNG.Items.Add
                    (
                        _Item.OImageInfo.OTime.ToString("yyyy-MM-dd HH:mm:ss.fff") + " " +
                        _Item.OFaultResult.ETool.ToString().Substring(0, 1) + 
                        _Item.OFaultResult.I32Index +
                        "(" + Math.Round(_Item.OFaultResult.F64Value) + "," + _Item.OFaultResult.StrReferance + ")"
                    );
                }
            }
            catch (Exception ex)
            {
                CError.Throw(ex);
            }
            finally
            {
                this.LtbNG.EndUpdate();
            }
        }
        

        private void DrawNGResult()
        {
            try
            {
                string StrTime = ((string)this.LtbNG.SelectedItem).Substring(0, "yyyy-MM-dd HH:mm:ss.fff".Length);

                foreach (CDiaperFaultResult _Item in this.m_LstONG)
                {
                    if (_Item.OImageInfo.OTime.ToString("yyyy-MM-dd HH:mm:ss.fff") != StrTime) continue;

                    this.m_ONGHelperTool.OSubject = _Item;
                    break;
                }
            }
            catch (Exception ex)
            {
                CError.Throw(ex);
            }
        }


        private void DisplayToolSummary()
        {
            try
            {
                this.LblTotalCount.Text = CToolSummary.It.StrTotalCount;
                this.LblOKCount.Text = CToolSummary.It.StrOKCount;
                this.LblNGCount.Text = CToolSummary.It.StrNGCount;
                this.LblOKRate.Text = CToolSummary.It.StrOKRate;
                this.LblNGRate.Text = CToolSummary.It.StrNGRate;
            }
            catch (Exception ex)
            {
                CError.Throw(ex);
            }
        }
        #endregion
    }
}
