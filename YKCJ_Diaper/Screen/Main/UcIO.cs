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
    public partial class UcIO : UcSubMain
    {
        #region CONST
        private const string TXT_ENABLE = "사용";
        private const string TXT_DISABLE = "사용안함";
        #endregion


        #region VARIABLE
        private CheckBox[] m_ArrOEnabled = null;
        private NumericUpDown[] m_ArrOPort = null;
        private NumericUpDown[] m_ArrOOnInterval = null;
        private NumericUpDown[] m_ArrOOffInterval = null;

        private bool m_BPreventEvent = false;
        #endregion


        #region CONSTRUCTOR & DESTRUCTOR
        public UcIO()
        {
            InitializeComponent();

            try
            {
                this.m_ArrOEnabled = new CheckBox[16];
                this.m_ArrOEnabled[0] = null; //NG
                this.m_ArrOEnabled[1] = this.ChkEnabledReject;
                this.m_ArrOEnabled[2] = this.ChkEnabledReady;
                this.m_ArrOEnabled[3] = this.ChkEnabledAir;
                this.m_ArrOEnabled[4] = this.ChkEnabledTool1;
                this.m_ArrOEnabled[5] = this.ChkEnabledTool2;
                this.m_ArrOEnabled[6] = this.ChkEnabledTool3;
                this.m_ArrOEnabled[7] = this.ChkEnabledTool4;
                this.m_ArrOEnabled[8] = this.ChkEnabledTool5;
                this.m_ArrOEnabled[9] = this.ChkEnabledTool6;
                this.m_ArrOEnabled[10] = this.ChkEnabledTool7;
                this.m_ArrOEnabled[11] = this.ChkEnabledTool8;
                this.m_ArrOEnabled[12] = this.ChkEnabledTool9;
                this.m_ArrOEnabled[13] = this.ChkEnabledTool10;
                this.m_ArrOEnabled[14] = this.ChkEnabledTool11;
                this.m_ArrOEnabled[15] = this.ChkEnabledTool12;

                this.m_ArrOPort = new NumericUpDown[16];
                this.m_ArrOPort[0] = this.NudPortNG;
                this.m_ArrOPort[1] = this.NudPortReject;
                this.m_ArrOPort[2] = this.NudPortReady;
                this.m_ArrOPort[3] = this.NudPortAir;
                this.m_ArrOPort[4] = this.NudPortTool1;
                this.m_ArrOPort[5] = this.NudPortTool2;
                this.m_ArrOPort[6] = this.NudPortTool3;
                this.m_ArrOPort[7] = this.NudPortTool4;
                this.m_ArrOPort[8] = this.NudPortTool5;
                this.m_ArrOPort[9] = this.NudPortTool6;
                this.m_ArrOPort[10] = this.NudPortTool7;
                this.m_ArrOPort[11] = this.NudPortTool8;
                this.m_ArrOPort[12] = this.NudPortTool9;
                this.m_ArrOPort[13] = this.NudPortTool10;
                this.m_ArrOPort[14] = this.NudPortTool11;
                this.m_ArrOPort[15] = this.NudPortTool12;

                this.m_ArrOOnInterval = new NumericUpDown[16];
                this.m_ArrOOnInterval[0] = this.NudOnIntervalNG;
                this.m_ArrOOnInterval[1] = null;
                this.m_ArrOOnInterval[2] = this.NudOnIntervalReady;
                this.m_ArrOOnInterval[3] = this.NudOnIntervalAir;
                this.m_ArrOOnInterval[4] = this.NudOnIntervalTool1;
                this.m_ArrOOnInterval[5] = this.NudOnIntervalTool2;
                this.m_ArrOOnInterval[6] = this.NudOnIntervalTool3;
                this.m_ArrOOnInterval[7] = this.NudOnIntervalTool4;
                this.m_ArrOOnInterval[8] = this.NudOnIntervalTool5;
                this.m_ArrOOnInterval[9] = this.NudOnIntervalTool6;
                this.m_ArrOOnInterval[10] = this.NudOnIntervalTool7;
                this.m_ArrOOnInterval[11] = this.NudOnIntervalTool8;
                this.m_ArrOOnInterval[12] = this.NudOnIntervalTool9;
                this.m_ArrOOnInterval[13] = this.NudOnIntervalTool10;
                this.m_ArrOOnInterval[14] = this.NudOnIntervalTool11;
                this.m_ArrOOnInterval[15] = this.NudOnIntervalTool12;

                this.m_ArrOOffInterval = new NumericUpDown[16];
                this.m_ArrOOffInterval[0] = null;
                this.m_ArrOOffInterval[1] = null;
                this.m_ArrOOffInterval[2] = this.NudOffIntervalReady;
                this.m_ArrOOffInterval[3] = this.NudOffIntervalAir;
                this.m_ArrOOffInterval[4] = null;
                this.m_ArrOOffInterval[5] = null;
                this.m_ArrOOffInterval[6] = null;
                this.m_ArrOOffInterval[7] = null;
                this.m_ArrOOffInterval[8] = null;
                this.m_ArrOOffInterval[9] = null;
                this.m_ArrOOffInterval[10] = null;
                this.m_ArrOOffInterval[11] = null;
                this.m_ArrOOffInterval[12] = null;
                this.m_ArrOOffInterval[13] = null;
                this.m_ArrOOffInterval[14] = null;
                this.m_ArrOOffInterval[15] = null;
            }
            catch (Exception ex)
            {
                CError.Throw(ex);
            }
        }
        #endregion


        #region EVENT
        #region BUTTON EVENT
        private void BtnReset_Click(object sender, EventArgs e)
        {
            try
            {
                this.DisplayIO();
            }
            catch (Exception ex)
            {
                CError.Show(ex);
            }
        }


        private void BtnApply_Click(object sender, EventArgs e)
        {
            try
            {
                for (int _Index1 = 0; _Index1 < this.m_ArrOPort.Length; _Index1++)
                {
                    if ((this.m_ArrOEnabled[_Index1] == null) || (this.m_ArrOEnabled[_Index1].Checked == false)) continue;

                    for (int _Index2 = _Index1 + 1; _Index2 < this.m_ArrOPort.Length; _Index2++)
                    {
                        if ((this.m_ArrOEnabled[_Index2] == null) || (this.m_ArrOEnabled[_Index2].Checked == false)) continue;
                        if (Convert.ToUInt16(this.m_ArrOPort[_Index1].Value) != Convert.ToUInt16(this.m_ArrOPort[_Index2].Value)) continue;

                        string StrMsg = "'" + ((EIO)Enum.ToObject(typeof(EIO), _Index1)).ToString() + "' 신호와 "
                                      + "'" + ((EIO)Enum.ToObject(typeof(EIO), _Index2)).ToString() + "' 신호의 "
                                      + "포트가 동일합니다.";
                        CMsgBox.Warning(StrMsg);
                        return;
                    }
                }


                for (int _Index1 = 0; _Index1 < this.m_ArrOEnabled.Length; _Index1++)
                {
                    EIO EIOSignal = (EIO)Enum.ToObject(typeof(EIO), _Index1);
                    int I32RowIndex = CDB.It[CDB.TABLE_IO_LIST].SelectRowIndex(CDB.IO_LIST_NAME, EIOSignal.ToString());

                    if (EIOSignal == EIO.NG)
                    {
                        CDB.It[CDB.TABLE_IO_LIST].Update(I32RowIndex, CDB.IO_LIST_PORT, Convert.ToUInt16(this.m_ArrOPort[_Index1].Value));
                        CDB.It[CDB.TABLE_IO_LIST].Update(I32RowIndex, CDB.IO_LIST_ON_INTERVAL, Convert.ToInt32(this.m_ArrOOnInterval[_Index1].Value));
                    }
                    else if (EIOSignal == EIO.REJECT)
                    {
                        CDB.It[CDB.TABLE_IO_LIST].Update(I32RowIndex, CDB.IO_LIST_ENABLED, this.m_ArrOEnabled[_Index1].Checked);
                        if (this.m_ArrOEnabled[_Index1].Checked == true)
                        {
                            CDB.It[CDB.TABLE_IO_LIST].Update(I32RowIndex, CDB.IO_LIST_PORT, Convert.ToUInt16(this.m_ArrOPort[_Index1].Value));
                        }
                    }
                    else if ((EIOSignal == EIO.READY) || (EIOSignal == EIO.AIR))
                    {
                        CDB.It[CDB.TABLE_IO_LIST].Update(I32RowIndex, CDB.IO_LIST_ENABLED, this.m_ArrOEnabled[_Index1].Checked);
                        if (this.m_ArrOEnabled[_Index1].Checked == true)
                        {
                            CDB.It[CDB.TABLE_IO_LIST].Update(I32RowIndex, CDB.IO_LIST_PORT, Convert.ToUInt16(this.m_ArrOPort[_Index1].Value));
                            CDB.It[CDB.TABLE_IO_LIST].Update(I32RowIndex, CDB.IO_LIST_ON_INTERVAL, Convert.ToInt32(this.m_ArrOOnInterval[_Index1].Value));
                            CDB.It[CDB.TABLE_IO_LIST].Update(I32RowIndex, CDB.IO_LIST_OFF_INTERVAL, Convert.ToInt32(this.m_ArrOOffInterval[_Index1].Value));
                        }
                    }
                    else
                    {
                        CDB.It[CDB.TABLE_IO_LIST].Update(I32RowIndex, CDB.IO_LIST_ENABLED, this.m_ArrOEnabled[_Index1].Checked);
                        if (this.m_ArrOEnabled[_Index1].Checked == true)
                        {
                            CDB.It[CDB.TABLE_IO_LIST].Update(I32RowIndex, CDB.IO_LIST_PORT, Convert.ToUInt16(this.m_ArrOPort[_Index1].Value));
                            CDB.It[CDB.TABLE_IO_LIST].Update(I32RowIndex, CDB.IO_LIST_ON_INTERVAL, Convert.ToInt32(this.m_ArrOOnInterval[_Index1].Value));
                        }
                    }
                }
                CDB.It[CDB.TABLE_IO_LIST].Commit();


                CControlBox.It.ClearProc();
                for (int _Index1 = 0; _Index1 < this.m_ArrOEnabled.Length; _Index1++)
                {
                    EIO EIOSignal = (EIO)Enum.ToObject(typeof(EIO), _Index1);

                    if (EIOSignal == EIO.NG)
                    {
                        CControlBox.It.SetIOEvent(Convert.ToUInt16(this.m_ArrOPort[_Index1].Value), EIOSignal, Convert.ToInt32(this.m_ArrOOnInterval[_Index1].Value));
                    }
                    else
                    {
                        if (this.m_ArrOEnabled[_Index1].Checked == false) continue;

                        if (EIOSignal == EIO.REJECT)
                        {
                            CControlBox.It.SetIOManual(Convert.ToUInt16(this.m_ArrOPort[_Index1].Value), EIOSignal);
                        }
                        else if ((EIOSignal == EIO.READY) || (EIOSignal == EIO.AIR))
                        {
                            CControlBox.It.SetIOPulse(Convert.ToUInt16(this.m_ArrOPort[_Index1].Value), EIOSignal, Convert.ToInt32(this.m_ArrOOnInterval[_Index1].Value), Convert.ToInt32(this.m_ArrOOffInterval[_Index1].Value));
                        }
                        else
                        {
                            CControlBox.It.SetIOEvent(Convert.ToUInt16(this.m_ArrOPort[_Index1].Value), EIOSignal, Convert.ToInt32(this.m_ArrOOnInterval[_Index1].Value));
                        }
                    }
                }

                //On이면 켠다.
                CDiaperFaultTool.It.BReject = CDiaperFaultTool.It.BReject;

                if (CAcquisitionManager.It.OCameara.BRun == true)
                {
                    CControlBox.It.On(EIO.READY);
                    CControlBox.It.On(EIO.AIR);
                }
            }
            catch (Exception ex)
            {
                CError.Show(ex);
            }
        }
        #endregion


        #region ETC EVENT
        private void ChkEnabled_CheckedChanged(object sender, EventArgs e)
        {
            if (this.m_BPreventEvent == true) return;

            try
            {
                EIO EIOSignal = (EIO)Enum.Parse(typeof(EIO), (string)((Control)sender).Tag);
                int I32Index = (int)EIOSignal;
                int I32RowIndex = CDB.It[CDB.TABLE_IO_LIST].SelectRowIndex(CDB.IO_LIST_NAME, EIOSignal.ToString());

                if (this.m_ArrOEnabled[I32Index].Checked == true)
                {
                    this.m_ArrOEnabled[I32Index].Text = TXT_ENABLE;

                    if (EIOSignal == EIO.REJECT)
                    {
                        this.m_ArrOPort[I32Index].Value = (ushort)CDB.It[CDB.TABLE_IO_LIST].Select(I32RowIndex, CDB.IO_LIST_PORT);
                        this.m_ArrOPort[I32Index].Controls[1].Text = this.m_ArrOPort[I32Index].Value.ToString();
                        this.m_ArrOPort[I32Index].Enabled = true;
                    }
                    else if ((EIOSignal == EIO.READY) || (EIOSignal == EIO.AIR))
                    {
                        this.m_ArrOPort[I32Index].Value = (ushort)CDB.It[CDB.TABLE_IO_LIST].Select(I32RowIndex, CDB.IO_LIST_PORT);
                        this.m_ArrOPort[I32Index].Controls[1].Text = this.m_ArrOPort[I32Index].Value.ToString();
                        this.m_ArrOPort[I32Index].Enabled = true;

                        this.m_ArrOOnInterval[I32Index].Value = (int)CDB.It[CDB.TABLE_IO_LIST].Select(I32RowIndex, CDB.IO_LIST_ON_INTERVAL);
                        this.m_ArrOOnInterval[I32Index].Controls[1].Text = this.m_ArrOOnInterval[I32Index].Value.ToString();
                        this.m_ArrOOnInterval[I32Index].Enabled = true;

                        this.m_ArrOOffInterval[I32Index].Value = (int)CDB.It[CDB.TABLE_IO_LIST].Select(I32RowIndex, CDB.IO_LIST_OFF_INTERVAL);
                        this.m_ArrOOffInterval[I32Index].Controls[1].Text = this.m_ArrOOffInterval[I32Index].Value.ToString();
                        this.m_ArrOOffInterval[I32Index].Enabled = true;
                    }
                    else
                    {
                        this.m_ArrOPort[I32Index].Value = (ushort)CDB.It[CDB.TABLE_IO_LIST].Select(I32RowIndex, CDB.IO_LIST_PORT);
                        this.m_ArrOPort[I32Index].Controls[1].Text = this.m_ArrOPort[I32Index].Value.ToString();
                        this.m_ArrOPort[I32Index].Enabled = true;

                        this.m_ArrOOnInterval[I32Index].Value = (int)CDB.It[CDB.TABLE_IO_LIST].Select(I32RowIndex, CDB.IO_LIST_ON_INTERVAL);
                        this.m_ArrOOnInterval[I32Index].Controls[1].Text = this.m_ArrOOnInterval[I32Index].Value.ToString();
                        this.m_ArrOOnInterval[I32Index].Enabled = true;
                    }
                }
                else
                {
                    this.m_ArrOEnabled[I32Index].Text = TXT_DISABLE;

                    if (EIOSignal == EIO.REJECT)
                    {
                        this.m_ArrOPort[I32Index].Controls[1].Text = string.Empty;
                        this.m_ArrOPort[I32Index].Enabled = false;
                    }
                    else if ((EIOSignal == EIO.READY) || (EIOSignal == EIO.AIR))
                    {
                        this.m_ArrOPort[I32Index].Controls[1].Text = string.Empty;
                        this.m_ArrOPort[I32Index].Enabled = false;

                        this.m_ArrOOnInterval[I32Index].Controls[1].Text = string.Empty;
                        this.m_ArrOOnInterval[I32Index].Enabled = false;

                        this.m_ArrOOffInterval[I32Index].Controls[1].Text = string.Empty;
                        this.m_ArrOOffInterval[I32Index].Enabled = false;
                    }
                    else
                    {
                        this.m_ArrOPort[I32Index].Controls[1].Text = string.Empty;
                        this.m_ArrOPort[I32Index].Enabled = false;

                        this.m_ArrOOnInterval[I32Index].Controls[1].Text = string.Empty;
                        this.m_ArrOOnInterval[I32Index].Enabled = false;
                    }
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
                this.DisplayIO();
            }
            catch (Exception ex)
            {
                CError.Show(ex);
            }
        }


        private void DisplayIO()
        {
            try
            {
                this.m_BPreventEvent = true;

                DataTable ODataSource = CDB.It[CDB.TABLE_IO_LIST].Select();

                foreach (DataRow _Item1 in ODataSource.Rows)
                {
                    for (int _Index2 = 0; _Index2 < this.m_ArrOEnabled.Length; _Index2++)
                    {
                        EIO EIOSignal = (EIO)Enum.Parse(typeof(EIO), (string)_Item1[CDB.IO_LIST_NAME]);

                        if (EIOSignal == EIO.NG)
                        {
                            this.m_ArrOPort[_Index2].Value = (ushort)_Item1[CDB.IO_LIST_PORT];
                            this.m_ArrOPort[_Index2].Controls[1].Text = this.m_ArrOPort[_Index2].Value.ToString();
                            this.m_ArrOPort[_Index2].Enabled = true;

                            this.m_ArrOOnInterval[_Index2].Value = (int)_Item1[CDB.IO_LIST_ON_INTERVAL];
                            this.m_ArrOOnInterval[_Index2].Controls[1].Text = this.m_ArrOOnInterval[_Index2].Value.ToString();
                            this.m_ArrOOnInterval[_Index2].Enabled = true;
                        }
                        else
                        {
                            if (this.m_ArrOEnabled[_Index2] == null) continue;
                            if ((string)_Item1[CDB.IO_LIST_NAME] != (string)this.m_ArrOEnabled[_Index2].Tag) continue;

                            if ((bool)_Item1[CDB.IO_LIST_ENABLED] == true)
                            {
                                this.m_ArrOEnabled[_Index2].Checked = true;
                                this.m_ArrOEnabled[_Index2].Text = TXT_ENABLE;

                                if (EIOSignal == EIO.REJECT)
                                {
                                    this.m_ArrOPort[_Index2].Value = (ushort)_Item1[CDB.IO_LIST_PORT];
                                    this.m_ArrOPort[_Index2].Controls[1].Text = this.m_ArrOPort[_Index2].Value.ToString();
                                    this.m_ArrOPort[_Index2].Enabled = true;
                                }
                                else if ((EIOSignal == EIO.READY) || (EIOSignal == EIO.AIR))
                                {
                                    this.m_ArrOPort[_Index2].Value = (ushort)_Item1[CDB.IO_LIST_PORT];
                                    this.m_ArrOPort[_Index2].Controls[1].Text = this.m_ArrOPort[_Index2].Value.ToString();
                                    this.m_ArrOPort[_Index2].Enabled = true;

                                    this.m_ArrOOnInterval[_Index2].Value = (int)_Item1[CDB.IO_LIST_ON_INTERVAL];
                                    this.m_ArrOOnInterval[_Index2].Controls[1].Text = this.m_ArrOOnInterval[_Index2].Value.ToString();
                                    this.m_ArrOOnInterval[_Index2].Enabled = true;

                                    this.m_ArrOOffInterval[_Index2].Value = (int)_Item1[CDB.IO_LIST_OFF_INTERVAL];
                                    this.m_ArrOOffInterval[_Index2].Controls[1].Text = this.m_ArrOOffInterval[_Index2].Value.ToString();
                                    this.m_ArrOOffInterval[_Index2].Enabled = true;
                                }
                                else
                                {
                                    this.m_ArrOPort[_Index2].Value = (ushort)_Item1[CDB.IO_LIST_PORT];
                                    this.m_ArrOPort[_Index2].Controls[1].Text = this.m_ArrOPort[_Index2].Value.ToString();
                                    this.m_ArrOPort[_Index2].Enabled = true;

                                    this.m_ArrOOnInterval[_Index2].Value = (int)_Item1[CDB.IO_LIST_ON_INTERVAL];
                                    this.m_ArrOOnInterval[_Index2].Controls[1].Text = this.m_ArrOOnInterval[_Index2].Value.ToString();
                                    this.m_ArrOOnInterval[_Index2].Enabled = true;
                                }
                            }
                            else
                            {
                                this.m_ArrOEnabled[_Index2].Checked = false;
                                this.m_ArrOEnabled[_Index2].Text = TXT_DISABLE;

                                if (EIOSignal == EIO.REJECT)
                                {
                                    this.m_ArrOPort[_Index2].Controls[1].Text = string.Empty;
                                    this.m_ArrOPort[_Index2].Enabled = false;
                                }
                                else if ((EIOSignal == EIO.READY) || (EIOSignal == EIO.AIR))
                                {
                                    this.m_ArrOPort[_Index2].Controls[1].Text = string.Empty;
                                    this.m_ArrOPort[_Index2].Enabled = false;

                                    this.m_ArrOOnInterval[_Index2].Controls[1].Text = string.Empty;
                                    this.m_ArrOOnInterval[_Index2].Enabled = false;

                                    this.m_ArrOOffInterval[_Index2].Controls[1].Text = string.Empty;
                                    this.m_ArrOOffInterval[_Index2].Enabled = false;
                                }
                                else
                                {
                                    this.m_ArrOPort[_Index2].Controls[1].Text = string.Empty;
                                    this.m_ArrOPort[_Index2].Enabled = false;

                                    this.m_ArrOOnInterval[_Index2].Controls[1].Text = string.Empty;
                                    this.m_ArrOOnInterval[_Index2].Enabled = false;
                                }
                            }
                        }
                        break;
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
                CError.Show(ex);
            }
            finally
            {
                this.m_BPreventEvent = false;
            }
        }
        #endregion
    }

    #region ENUM
    public enum EIO : byte
    {
        NG = 0,
        REJECT,
        READY,
        AIR,
        TOOL1,
        TOOL2,
        TOOL3,
        TOOL4,
        TOOL5,
        TOOL6,
        TOOL7,
        TOOL8,
        TOOL9,
        TOOL10,
        TOOL11,
        TOOL12,
        NONE = 0xFF
    }
    #endregion
}
