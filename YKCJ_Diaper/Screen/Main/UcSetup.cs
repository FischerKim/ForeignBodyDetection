using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Jhjo.Common;

namespace YKCJ_Diaper
{
    public partial class UcSetup : UcSubMain
    {
        #region VARIABLE
        private CheckBox[] m_ArrOSummaryResetEnabled = null;
        private NumericUpDown[] m_ArrOSummaryResetHour = null;
        private NumericUpDown[] m_ArrOSummaryResetMinute = null;

        private bool m_BPreventEvent = false;
        #endregion


        #region CONSTRUCTOR & DESTRUCTOR
        public UcSetup()
        {
            InitializeComponent();

            try
            {
                this.m_BPreventEvent = true;


                this.TxtSystemMachine.Text = CEnvironment.It.StrSystemMachine;
                this.TxtSystemObject.Text = CEnvironment.It.StrSystemObject;
                this.TxtSystemLeft.Text = CEnvironment.It.StrSystemLeft;
                this.TxtSystemRight.Text = CEnvironment.It.StrSystemRight;


                //this.TrkCameraWidth.Minimum = CAcquisitionManager.It.OCameara.I32WidthMin;
                //this.TrkCameraWidth.Maximum = CAcquisitionManager.It.OCameara.I32WidthMax;
                //this.TrkCameraWidth.Value = CAcquisitionManager.It.OCameara.I32Width;
                this.NudCameraWidth.Minimum = this.TrkCameraWidth.Minimum;
                this.NudCameraWidth.Maximum = this.TrkCameraWidth.Maximum;
                this.NudCameraWidth.Value = this.TrkCameraWidth.Value;

                //this.TrkCameraHeight.Minimum = CAcquisitionManager.It.OCameara.I32HeightMin;
                //this.TrkCameraHeight.Maximum = CAcquisitionManager.It.OCameara.I32HeightMax;
                //this.TrkCameraHeight.Value = CAcquisitionManager.It.OCameara.I32Height;
                this.NudCameraHeight.Minimum = this.TrkCameraHeight.Minimum;
                this.NudCameraHeight.Maximum = this.TrkCameraHeight.Maximum;
                this.NudCameraHeight.Value = this.TrkCameraHeight.Value;

                //this.TrkCameraGain.Minimum = CAcquisitionManager.It.OCameara.I32GainMin;
                //this.TrkCameraGain.Maximum = CAcquisitionManager.It.OCameara.I32GainMax;
                //this.TrkCameraGain.Value = CAcquisitionManager.It.OCameara.I32Gain;
                this.NudCameraGain.Minimum = this.TrkCameraGain.Minimum;
                this.NudCameraGain.Maximum = this.TrkCameraGain.Maximum;
                this.NudCameraGain.Value = this.TrkCameraGain.Value;

                //this.TrkCameraExposureTime.Minimum = CAcquisitionManager.It.OCameara.I32ExposureTimeMin;
                //this.TrkCameraExposureTime.Maximum = CAcquisitionManager.It.OCameara.I32ExposureTimeMax;
                //this.TrkCameraExposureTime.Value = CAcquisitionManager.It.OCameara.I32ExposureTime;
                this.NudCameraExposureTime.Minimum = this.TrkCameraExposureTime.Minimum;
                this.NudCameraExposureTime.Maximum = this.TrkCameraExposureTime.Maximum;
                this.NudCameraExposureTime.Value = this.TrkCameraExposureTime.Value;

                this.CmbCameraAcquisitionMode.Text = this.GetTriggerMode(CEnvironment.It.StrCameraAcquisitionMode);
                this.CmbCameraAcquisitionSource.Text = this.GetTriggerSource(CEnvironment.It.StrCameraAcquisitionSource);
                this.CmbCameraFrameMode.Text = this.GetTriggerMode(CEnvironment.It.StrCameraFrameMode);
                this.CmbCameraFrameSource.Text = this.GetTriggerSource(CEnvironment.It.StrCameraFrameSource);
                this.CmbCameraLineMode.Text = this.GetTriggerMode(CEnvironment.It.StrCameraLineMode);
                this.CmbCameraLineSource.Text = this.GetTriggerSource(CEnvironment.It.StrCameraLineSource);


                //Summary Reset
                this.m_ArrOSummaryResetEnabled = new CheckBox[3];
                this.m_ArrOSummaryResetEnabled[0] = this.ChkSummaryReset1Enabled;
                this.m_ArrOSummaryResetEnabled[1] = this.ChkSummaryReset2Enabled;
                this.m_ArrOSummaryResetEnabled[2] = this.ChkSummaryReset3Enabled;

                this.m_ArrOSummaryResetHour = new NumericUpDown[3];
                this.m_ArrOSummaryResetHour[0] = this.NudSummaryReset1Hour;
                this.m_ArrOSummaryResetHour[1] = this.NudSummaryReset2Hour;
                this.m_ArrOSummaryResetHour[2] = this.NudSummaryReset3Hour;

                this.m_ArrOSummaryResetMinute = new NumericUpDown[3];
                this.m_ArrOSummaryResetMinute[0] = this.NudSummaryReset1Minute;
                this.m_ArrOSummaryResetMinute[1] = this.NudSummaryReset2Minute;
                this.m_ArrOSummaryResetMinute[2] = this.NudSummaryReset3Minute;

                DataTable ODataSource = CDB.It[CDB.TABLE_SUMMARY_RESET].Select();
                foreach (DataRow OItem in ODataSource.Rows)
                {
                    int I32Index = (int)OItem[CDB.SUMMARY_RESET_INDEX];

                    if ((bool)OItem[CDB.SUMMARY_RESET_ENABLED] == true)
                    {
                        this.m_ArrOSummaryResetEnabled[I32Index].Text = "사용";
                        this.m_ArrOSummaryResetEnabled[I32Index].Checked = true;
                        this.m_ArrOSummaryResetEnabled[I32Index].BackColor = Color.ForestGreen;

                        this.m_ArrOSummaryResetHour[I32Index].Value = (int)OItem[CDB.SUMMARY_RESET_HOUR];
                        this.m_ArrOSummaryResetHour[I32Index].Controls[1].Text = this.m_ArrOSummaryResetHour[I32Index].Value.ToString();
                        this.m_ArrOSummaryResetHour[I32Index].Enabled = true;

                        this.m_ArrOSummaryResetMinute[I32Index].Value = (int)OItem[CDB.SUMMARY_RESET_MINUTE];
                        this.m_ArrOSummaryResetMinute[I32Index].Controls[1].Text = this.m_ArrOSummaryResetMinute[I32Index].Value.ToString();
                        this.m_ArrOSummaryResetMinute[I32Index].Enabled = true;
                    }
                    else
                    {
                        this.m_ArrOSummaryResetEnabled[I32Index].Text = "사용안함";
                        this.m_ArrOSummaryResetEnabled[I32Index].Checked = false;
                        this.m_ArrOSummaryResetEnabled[I32Index].BackColor = Color.SteelBlue;

                        this.m_ArrOSummaryResetHour[I32Index].Controls[1].Text = string.Empty;
                        this.m_ArrOSummaryResetHour[I32Index].Enabled = false;

                        this.m_ArrOSummaryResetMinute[I32Index].Controls[1].Text = string.Empty;
                        this.m_ArrOSummaryResetMinute[I32Index].Enabled = false;
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
            finally
            {
                this.m_BPreventEvent = false;
            }
        }
        #endregion


        #region EVENT
        #region BUTTON EVENT
        private void BtnApplySystem_Click(object sender, EventArgs e)
        {
            try
            {
                CEnvironment.It.StrSystemMachine = this.TxtSystemMachine.Text.Trim();
                CEnvironment.It.StrSystemObject = this.TxtSystemObject.Text.Trim();
                CEnvironment.It.StrSystemLeft = this.TxtSystemLeft.Text.Trim();
                CEnvironment.It.StrSystemRight = this.TxtSystemRight.Text.Trim();
                CEnvironment.It.Commit();

                CEnvironment.It.OnChangedSystemInfo();
                CEnvironment.It.OnChangedDirectionInfo();
            }
            catch (Exception ex)
            {
                CError.Show(ex);
            }
        }


        private void BtnApplyCameraOption_Click(object sender, EventArgs e)
        {
            try
            {
                this.m_BPreventEvent = true;


                string StrTag = (string)((Control)sender).Tag;
                int I32Value = 0;

                if (StrTag == "WIDTH")
                {
                    I32Value = Convert.ToInt32(this.NudCameraWidth.Value);

                    //CAcquisitionManager.It.OCameara.I32Width = I32Value;
                    this.TrkCameraWidth.Value = I32Value;

                    CEnvironment.It.I32CameraWidth = I32Value;
                    CEnvironment.It.Commit();
                }
                else if (StrTag == "HEIGHT")
                {
                    I32Value = Convert.ToInt32(this.NudCameraHeight.Value);

                    //CAcquisitionManager.It.OCameara.I32Height = I32Value;
                    this.TrkCameraHeight.Value = I32Value;

                    CEnvironment.It.I32CameraHeight = I32Value;
                    CEnvironment.It.Commit();
                }
                else if (StrTag == "GAIN")
                {
                    I32Value = Convert.ToInt32(this.NudCameraGain.Value);

                    //CAcquisitionManager.It.OCameara.I32Gain = I32Value;
                    this.TrkCameraGain.Value = I32Value;

                    CEnvironment.It.I32CameraGain = I32Value;
                    CEnvironment.It.Commit();
                }
                else if (StrTag == "EXPOSURE TIME")
                {
                    I32Value = Convert.ToInt32(this.NudCameraExposureTime.Value);

                    //CAcquisitionManager.It.OCameara.I32ExposureTime = I32Value;
                    this.TrkCameraExposureTime.Value = I32Value;

                    CEnvironment.It.I32CameraExposureTime = I32Value;
                    CEnvironment.It.Commit();
                }
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


        private void BtnApplySummaryReset_Click(object sender, EventArgs e)
        {
            try
            {
                //Validate
                for (int _Index1 = 0; _Index1 < this.m_ArrOSummaryResetEnabled.Length; _Index1++)
                {
                    if (this.m_ArrOSummaryResetEnabled[_Index1].Checked == false) continue;

                    for (int _Index2 = _Index1 + 1; _Index2 < this.m_ArrOSummaryResetEnabled.Length; _Index2++)
                    {
                        if (this.m_ArrOSummaryResetEnabled[_Index2].Checked == false) continue;

                        if ((this.m_ArrOSummaryResetHour[_Index1].Value == this.m_ArrOSummaryResetHour[_Index2].Value) &&
                            (this.m_ArrOSummaryResetMinute[_Index1].Value == this.m_ArrOSummaryResetMinute[_Index2].Value))
                        {
                            CMsgBox.Warning((_Index1 + 1) + "의 초기화 시간이 " + (_Index2 + 1) + "의 초기화 시간과 동일합니다.");
                            return;
                        }
                    }
                }


                //Save To DB
                for (int _Index = 0; _Index < this.m_ArrOSummaryResetEnabled.Length; _Index++)
                {
                    int I32RowIndex = CDB.It[CDB.TABLE_SUMMARY_RESET].SelectRowIndex(CDB.SUMMARY_RESET_INDEX, _Index);

                    if (this.m_ArrOSummaryResetEnabled[_Index].Checked == true)
                    {
                        CDB.It[CDB.TABLE_SUMMARY_RESET].Update(I32RowIndex, CDB.SUMMARY_RESET_ENABLED, true);
                        CDB.It[CDB.TABLE_SUMMARY_RESET].Update(I32RowIndex, CDB.SUMMARY_RESET_HOUR, Convert.ToInt32(this.m_ArrOSummaryResetHour[_Index].Value));
                        CDB.It[CDB.TABLE_SUMMARY_RESET].Update(I32RowIndex, CDB.SUMMARY_RESET_MINUTE, Convert.ToInt32(this.m_ArrOSummaryResetMinute[_Index].Value));
                    }
                    else
                    {
                        CDB.It[CDB.TABLE_SUMMARY_RESET].Update(I32RowIndex, CDB.SUMMARY_RESET_ENABLED, false);
                        CDB.It[CDB.TABLE_SUMMARY_RESET].Update(I32RowIndex, CDB.SUMMARY_RESET_HOUR, 0);
                        CDB.It[CDB.TABLE_SUMMARY_RESET].Update(I32RowIndex, CDB.SUMMARY_RESET_MINUTE, 0);
                    }
                }
                CDB.It[CDB.TABLE_SUMMARY_RESET].Commit();


                //Set To Tool
                bool[] ArrBEnabled = new bool[5];
                TimeSpan[] ArrOTime = new TimeSpan[5];

                for (int _Index = 0; _Index < this.m_ArrOSummaryResetEnabled.Length; _Index++)
                {
                    if (this.m_ArrOSummaryResetEnabled[_Index].Checked == true)
                    {
                        ArrBEnabled[_Index] = true;
                        ArrOTime[_Index] = new TimeSpan
                        (
                            Convert.ToInt32(this.m_ArrOSummaryResetHour[_Index].Value),
                            Convert.ToInt32(this.m_ArrOSummaryResetMinute[_Index].Value),
                            0
                        );
                    }
                    else
                    {
                        ArrBEnabled[_Index] = false;
                        ArrOTime[_Index] = TimeSpan.Zero;
                    }
                }

                CToolSummary.It.ArrBResetEnabled = ArrBEnabled;
                CToolSummary.It.ArrOResetTime = ArrOTime;
            }
            catch (Exception ex)
            {
                CError.Show(ex);
            }
        }
        #endregion


        #region ETC EVENT
        private void TrkCameraOption_ValueChanged(object sender, EventArgs e)
        {
            if (this.m_BPreventEvent == true) return;

            try
            {
                string StrTag = (string)((Control)sender).Tag;
                int I32Value = Convert.ToInt32(((TrackBar)sender).Value);

                if (StrTag == "WIDTH")
                {
                    //CAcquisitionManager.It.OCameara.I32Width = I32Value;
                    this.NudCameraWidth.Value = I32Value;

                    CEnvironment.It.I32CameraWidth = I32Value;
                    CEnvironment.It.Commit();
                }
                else if (StrTag == "HEIGHT")
                {
                    //CAcquisitionManager.It.OCameara.I32Height = I32Value;
                    this.NudCameraHeight.Value = I32Value;

                    CEnvironment.It.I32CameraHeight = I32Value;
                    CEnvironment.It.Commit();
                }
                else if (StrTag == "GAIN")
                {
                    //CAcquisitionManager.It.OCameara.I32Gain = I32Value;
                    this.NudCameraGain.Value = I32Value;

                    CEnvironment.It.I32CameraGain = I32Value;
                    CEnvironment.It.Commit();
                }
                else if (StrTag == "EXPOSURE TIME")
                {
                    //CAcquisitionManager.It.OCameara.I32ExposureTime = I32Value;
                    this.NudCameraExposureTime.Value = I32Value;

                    CEnvironment.It.I32CameraExposureTime = I32Value;
                    CEnvironment.It.Commit();
                }
            }
            catch (Exception ex)
            {
                CError.Show(ex);
            }
        }


        private void CmbCameraTriggerMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.m_BPreventEvent == true) return;

            try
            {
                string StrTag = (string)((Control)sender).Tag;

                if (StrTag == "ACQUISITION")
                {
                    if (this.CmbCameraAcquisitionMode.Text == "켬")
                    {
                        //CAcquisitionManager.It.OCameara.StrTriggerSelector = "AcquisitionStart";
                        //CAcquisitionManager.It.OCameara.StrTriggerMode = ETriggerMode.On.ToString();

                        CEnvironment.It.StrCameraAcquisitionMode = ETriggerMode.On.ToString();
                        CEnvironment.It.Commit();
                    }
                    else
                    {
                        //CAcquisitionManager.It.OCameara.StrTriggerSelector = "AcquisitionStart";
                        //CAcquisitionManager.It.OCameara.StrTriggerMode = ETriggerMode.Off.ToString();

                        CEnvironment.It.StrCameraAcquisitionMode = ETriggerMode.Off.ToString();
                        CEnvironment.It.Commit();
                    }
                }
                else if (StrTag == "FRAME")
                {
                    if (this.CmbCameraFrameMode.Text == "켬")
                    {
                        //CAcquisitionManager.It.OCameara.StrTriggerSelector = "FrameStart";
                        //CAcquisitionManager.It.OCameara.StrTriggerMode = ETriggerMode.On.ToString();

                        CEnvironment.It.StrCameraFrameMode = ETriggerMode.On.ToString();
                        CEnvironment.It.Commit();
                    }
                    else
                    {
                        //CAcquisitionManager.It.OCameara.StrTriggerSelector = "FrameStart";
                        //CAcquisitionManager.It.OCameara.StrTriggerMode = ETriggerMode.Off.ToString();

                        CEnvironment.It.StrCameraFrameMode = ETriggerMode.Off.ToString();
                        CEnvironment.It.Commit();
                    }
                }
                else if (StrTag == "LINE")
                {
                    if (this.CmbCameraLineMode.Text == "켬")
                    {
                        //CAcquisitionManager.It.OCameara.StrTriggerSelector = "LineStart";
                        //CAcquisitionManager.It.OCameara.StrTriggerMode = ETriggerMode.On.ToString();

                        CEnvironment.It.StrCameraLineMode = ETriggerMode.On.ToString();
                        CEnvironment.It.Commit();
                    }
                    else
                    {
                        //CAcquisitionManager.It.OCameara.StrTriggerSelector = "LineStart";
                        //CAcquisitionManager.It.OCameara.StrTriggerMode = ETriggerMode.Off.ToString();

                        CEnvironment.It.StrCameraLineMode = ETriggerMode.Off.ToString();
                        CEnvironment.It.Commit();
                    }
                }
            }
            catch (Exception ex)
            {
                CError.Show(ex);
            }
        }


        private void CmbCameraTriggerSource_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.m_BPreventEvent == true) return;

            try
            {
                ETriggerSource ESource = ETriggerSource.Software;

                switch ((string)((Control)sender).Text)
                {
                    case "소프트웨어":
                        ESource = ETriggerSource.Software;
                        break;

                    case "입력 라인1":
                        ESource = ETriggerSource.Line1;
                        break;

                    case "입력 라인2":
                        ESource = ETriggerSource.Line2;
                        break;

                    case "입력 라인3":
                        ESource = ETriggerSource.Line3;
                        break;

                    case "Shaft Encoder Module Out":
                        ESource = ETriggerSource.ShaftEncoderModuleOut;
                        break;

                    case "Frequency Converter":
                        ESource = ETriggerSource.FrequencyConverter;
                        break;
                }


                string StrTag = (string)((Control)sender).Tag;

                if (StrTag == "ACQUISITION")
                {
                    //CAcquisitionManager.It.OCameara.StrTriggerSelector = "AcquisitionStart";
                    //CAcquisitionManager.It.OCameara.StrTriggerSource = ESource.ToString();

                    CEnvironment.It.StrCameraAcquisitionSource = ESource.ToString();
                    CEnvironment.It.Commit();
                }
                else if (StrTag == "FRAME")
                {
                    //CAcquisitionManager.It.OCameara.StrTriggerSelector = "FrameStart";
                    //CAcquisitionManager.It.OCameara.StrTriggerSource = ESource.ToString();

                    CEnvironment.It.StrCameraFrameSource = ESource.ToString();
                    CEnvironment.It.Commit();
                }
                else if (StrTag == "LINE")
                {
                    //CAcquisitionManager.It.OCameara.StrTriggerSelector = "LineStart";
                    //CAcquisitionManager.It.OCameara.StrTriggerSource = ESource.ToString();

                    CEnvironment.It.StrCameraLineSource = ESource.ToString();
                    CEnvironment.It.Commit();
                }
            }
            catch (Exception ex)
            {
                CError.Show(ex);
            }
        }


        private void ChkSummaryResetEnabled_CheckedChanged(object sender, EventArgs e)
        {
            if (this.m_BPreventEvent == true) return;

            try
            {
                int I32Index = Convert.ToInt32(((Control)sender).Tag);

                if (this.m_ArrOSummaryResetEnabled[I32Index].Checked == true)
                {
                    this.m_ArrOSummaryResetEnabled[I32Index].Text = "사용";
                    this.m_ArrOSummaryResetEnabled[I32Index].BackColor = Color.ForestGreen;

                    this.m_ArrOSummaryResetHour[I32Index].Value = 0;
                    this.m_ArrOSummaryResetHour[I32Index].Controls[1].Text = this.m_ArrOSummaryResetHour[I32Index].Value.ToString();
                    this.m_ArrOSummaryResetHour[I32Index].Enabled = true;

                    this.m_ArrOSummaryResetMinute[I32Index].Value = 0;
                    this.m_ArrOSummaryResetMinute[I32Index].Controls[1].Text = this.m_ArrOSummaryResetMinute[I32Index].Value.ToString();
                    this.m_ArrOSummaryResetMinute[I32Index].Enabled = true;
                }
                else
                {
                    this.m_ArrOSummaryResetEnabled[I32Index].Text = "사용안함";
                    this.m_ArrOSummaryResetEnabled[I32Index].BackColor = Color.SteelBlue;

                    this.m_ArrOSummaryResetHour[I32Index].Controls[1].Text = string.Empty;
                    this.m_ArrOSummaryResetHour[I32Index].Enabled = false;

                    this.m_ArrOSummaryResetMinute[I32Index].Controls[1].Text = string.Empty;
                    this.m_ArrOSummaryResetMinute[I32Index].Enabled = false;
                }
            }
            catch (Exception ex)
            {
                CError.Show(ex);
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


                if (CAcquisitionManager.It.OCameara.BRun == true)
                {
                    this.TrkCameraWidth.Enabled = false;
                    this.NudCameraWidth.Enabled = false;
                    this.BtnApplyCameraWidth.BackColor = SystemColors.Control;
                    this.BtnApplyCameraWidth.Enabled = false;

                    this.TrkCameraHeight.Enabled = false;
                    this.NudCameraHeight.Enabled = false;
                    this.BtnApplyCameraHeight.BackColor = SystemColors.Control;
                    this.BtnApplyCameraHeight.Enabled = false;
                }
                else
                {
                    this.TrkCameraWidth.Enabled = true;
                    this.NudCameraWidth.Enabled = true;
                    this.BtnApplyCameraWidth.BackColor = Color.SteelBlue;
                    this.BtnApplyCameraWidth.Enabled = true;

                    this.TrkCameraHeight.Enabled = true;
                    this.NudCameraHeight.Enabled = true;
                    this.BtnApplyCameraHeight.BackColor = Color.SteelBlue;
                    this.BtnApplyCameraHeight.Enabled = true;
                }

                this.TrkCameraGain.Value = CEnvironment.It.I32CameraGain;
                this.NudCameraGain.Value = this.TrkCameraGain.Value;
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


        private string GetTriggerMode(string StrTriggerMode)
        {
            string StrResult = string.Empty;

            try
            {
                if (StrTriggerMode == ETriggerMode.On.ToString()) StrResult = "켬";
                else StrResult = "끔";
            }
            catch (Exception ex)
            {
                CError.Throw(ex);
            }

            return StrResult;
        }


        private string GetTriggerSource(string StrTriggerSource)
        {
            string StrResult = string.Empty;

            try
            {
                if (StrTriggerSource == ETriggerSource.Software.ToString()) StrResult = "소프트웨어";
                else if (StrTriggerSource == ETriggerSource.Line1.ToString()) StrResult = "입력 라인1";
                else if (StrTriggerSource == ETriggerSource.Line2.ToString()) StrResult = "입력 라인2";
                else if (StrTriggerSource == ETriggerSource.Line3.ToString()) StrResult = "입력 라인3";
                else if (StrTriggerSource == ETriggerSource.ShaftEncoderModuleOut.ToString()) StrResult = "Shaft Encoder Module Out";
                else StrResult = "Frequency Converter";
            }
            catch (Exception ex)
            {
                CError.Throw(ex);
            }

            return StrResult;
        }
        #endregion
    }


    public enum ETriggerMode : byte
    {
        On = 0x00,
        Off
    }


    public enum ETriggerSource : byte
    {
        Software = 0x00,
        Line1,
        Line2,
        Line3,
        ShaftEncoderModuleOut,
        FrequencyConverter
    }
}
