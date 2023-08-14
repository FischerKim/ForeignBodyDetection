using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Jhjo.Common;

namespace YKCJ_Diaper
{
    public class CToolSummary
    {
        #region SINGLE TON
        private static CToolSummary Src_It = null;


        public static CToolSummary It
        {
            get
            {
                CToolSummary OResult = null;

                try
                {
                    if (CToolSummary.Src_It == null)
                    {
                        CToolSummary.Src_It = new CToolSummary();
                    }

                    OResult = CToolSummary.Src_It;
                }
                catch (Exception ex)
                {
                    CError.Throw(ex);
                }

                return OResult;
            }
        }
        #endregion


        #region VARIABLE
        private ulong m_U64TotalCount = 0;
        private ulong m_U64OKCount = 0;
        private ulong m_U64NGCount = 0;
        
        private bool[] m_ArrBResetEnabled = new bool[3];
        private TimeSpan[] m_ArrOResetTime = new TimeSpan[3];
        private DateTime m_OBeforeResetCheckTime = DateTime.MinValue;
        #endregion


        #region PROPERTIES
        public ulong U64TotalCount
        {
            get { return this.m_U64TotalCount; }
            set { this.m_U64TotalCount = value; }
        }


        public ulong U64OKCount
        {
            get { return this.m_U64OKCount; }
            set { this.m_U64OKCount = value; }
        }


        public ulong U64NGCount
        {
            get { return this.m_U64NGCount; }
            set { this.m_U64NGCount = value; }
        }


        public string StrTotalCount
        {
            get { return this.m_U64TotalCount.ToString(); }
        }


        public string StrOKCount
        {
            get { return this.m_U64OKCount.ToString(); }
        }


        public string StrNGCount
        {
            get { return this.m_U64NGCount.ToString(); }
        }


        public string StrOKRate
        {
            get
            {
                string StrResult = "0.00";

                try
                {
                    if (this.m_U64TotalCount != 0)
                    {
                        decimal F128Rate = (decimal)this.m_U64OKCount / this.m_U64TotalCount;
                        F128Rate = Math.Round(F128Rate, 4);
                        F128Rate *= 100;

                        StrResult = F128Rate.ToString("0.00");
                    }
                }
                catch (Exception ex)
                {
                    CError.Throw(ex);
                }

                return StrResult;
            }
        }


        public string StrNGRate
        {
            get
            {
                string StrResult = "0.00";

                try
                {
                    if (this.m_U64TotalCount != 0)
                    {
                        decimal F128Rate = (decimal)this.m_U64NGCount / this.m_U64TotalCount;
                        F128Rate = Math.Round(F128Rate, 4);
                        F128Rate *= 100;

                        StrResult = F128Rate.ToString("0.00");
                    }
                }
                catch (Exception ex)
                {
                    CError.Throw(ex);
                }

                return StrResult;
            }
        }


        public bool[] ArrBResetEnabled
        {
            get { return this.m_ArrBResetEnabled; }
            set { this.m_ArrBResetEnabled = value; }
        }


        public TimeSpan[] ArrOResetTime
        {
            get { return this.m_ArrOResetTime; }
            set { this.m_ArrOResetTime = value; }
        }
        #endregion


        #region FUNCTION
        public void IncreaseOK()
        {
            try
            {
                this.m_U64TotalCount++;
                this.m_U64OKCount++;
            }
            catch (Exception ex)
            {
                CError.Throw(ex);
            }
        }


        public void IncreaseNG()
        {
            try
            {
                this.m_U64TotalCount++;
                this.m_U64NGCount++;
            }
            catch (Exception ex)
            {
                CError.Throw(ex);
            }
        }


        public void Reset()
        {
            try
            {
                this.m_U64TotalCount = 0;
                this.m_U64OKCount = 0;
                this.m_U64NGCount = 0;
            }
            catch (Exception ex)
            {
                CError.Throw(ex);
            }
        }


        public void TimeReset()
        {
            try
            {
                DateTime ONow = DateTime.Now;
                for (int _Index = 0; _Index < this.m_ArrBResetEnabled.Length; _Index++)
                {
                    if (this.m_ArrBResetEnabled[_Index] == false) continue;

                    if (this.m_OBeforeResetCheckTime.Date == ONow.Date)
                    {
                        if ((this.m_OBeforeResetCheckTime.TimeOfDay < this.m_ArrOResetTime[_Index]) &&
                            (ONow.TimeOfDay > this.m_ArrOResetTime[_Index]))
                        {
                            this.m_U64TotalCount = 0;
                            this.m_U64OKCount = 0;
                            this.m_U64NGCount = 0;
                        }
                    }
                    else
                    {
                        if (ONow.TimeOfDay > this.m_ArrOResetTime[_Index])
                        {
                            this.m_U64TotalCount = 0;
                            this.m_U64OKCount = 0;
                            this.m_U64NGCount = 0;
                        }
                    }
                }

                this.m_OBeforeResetCheckTime = ONow;
            }
            catch (Exception ex)
            {
                CError.Throw(ex);
            }
        }
        #endregion
    }
}
