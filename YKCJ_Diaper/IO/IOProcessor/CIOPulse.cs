using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Jhjo.Common;

namespace YKCJ_Diaper
{
    /// <summary>
    /// 시간의 흐름에 따라 신호를 송신하거나, 신호의 송신을 중단하는 클래스
    /// (사용자의 조작으로는 Pulse 신호에 대한 신호를 송신하거나, 송신을 중단할 수 있음.)
    /// </summary>
    public class CIOPulse : AIOProc
    {
        #region VARIABLE
        private bool m_BEnabled = false;

        private long m_I64OnTick = 0;
        private int m_I32OnInterval = 1000;

        private long m_I64OffTick = 0;
        private int m_I32OffInterval = 1000;
        #endregion


        #region PROPERTIES
        /// <summary>
        /// 시간의 흐름에 따라 신호를 송신*중단 할 것인지 여부를 반환한다.
        /// </summary>
        public bool BEnabled
        {
            get { return this.m_BEnabled; }
        }


        /// <summary>
        /// 신호 송신 유지 시간을 설정하거나 반환한다.
        /// </summary>
        public int I32OnInterval
        {
            get { return this.m_I32OnInterval; }
            set { this.m_I32OnInterval = value; }
        }


        /// <summary>
        /// 신호 송신 중단 유지 시간을 설정하거나 반환한다.
        /// </summary>
        public int I32OffInterval
        {
            get { return this.m_I32OffInterval; }
            set { this.m_I32OffInterval = value; }
        }
        #endregion


        #region CONSTRUCTOR & DESTRUCTOR
        /// <summary>
        /// 생성자
        /// </summary>
        /// <param name="I32OnInterval">신호 송신 유지 시간</param>
        /// <param name="I32OffInterval">신호 송신 중단 유지 시간</param>
        public CIOPulse(int I32OnInterval, int I32OffInterval)
        {
            try
            {
                this.m_I32OnInterval = I32OnInterval;
                this.m_I32OffInterval = I32OffInterval;
            }
            catch (Exception ex)
            {
                CError.Throw(ex);
            }
        }
        #endregion


        #region FUNCTION
        /// <summary>
        /// 사용자의 신호 송신 명령을 처리합니다.
        /// </summary>
        /// <returns>LET_ON</returns>
        public override EIO_STATUS ManualOn()
        {
            EIO_STATUS EResult = EIO_STATUS.LET_ON;

            try
            {
                this.m_BEnabled = true;
            }
            catch (Exception ex)
            {
                CError.Throw(ex);
            }

            return EResult;
        }


        /// <summary>
        /// 사용자의 신호 송신 중단 명령을 처리합니다.
        /// </summary>
        /// <returns>LET_OFF</returns>
        public override EIO_STATUS ManualOff()
        {
            EIO_STATUS EResult = EIO_STATUS.LET_OFF;

            try
            {
                this.m_BEnabled = false;
            }
            catch (Exception ex)
            {
                CError.Throw(ex);
            }

            return EResult;
        }


        /// <summary>
        /// 시간의 흐름에 따른 신호 송신 명령을 처리합니다.
        /// </summary>
        /// <returns>신호 송신 여부</returns>
        public override EIO_STATUS AutoOn()
        {
            EIO_STATUS EResult = EIO_STATUS.LET_OFF;

            try
            {
                if (this.m_BEnabled == true)
                {
                    if (this.m_I64OffTick + (this.m_I32OffInterval * 10000) < DateTime.Now.Ticks)
                    {
                        EResult = EIO_STATUS.LET_ON;

                        this.m_I64OnTick = DateTime.Now.Ticks;
                        this.m_I64OffTick = 0;
                    }
                }
            }
            catch (Exception ex)
            {
                CError.Throw(ex);
            }

            return EResult;
        }


        /// <summary>
        /// 시간의 흐름에 따른 신호 중단 명령을 처리합니다.
        /// </summary>
        /// <returns>신호 송신 여부</returns>
        public override EIO_STATUS AutoOff()
        {
            EIO_STATUS EResult = EIO_STATUS.LET_ON;

            try
            {
                if (this.m_BEnabled == true)
                {
                    if (this.m_I64OnTick + (this.m_I32OnInterval * 10000) < DateTime.Now.Ticks)
                    {
                        EResult = EIO_STATUS.LET_OFF;

                        this.m_I64OnTick = 0;
                        this.m_I64OffTick = DateTime.Now.Ticks;
                    }
                }
            }
            catch (Exception ex)
            {
                CError.Throw(ex);
            }

            return EResult;
        }
        #endregion
    }
}
