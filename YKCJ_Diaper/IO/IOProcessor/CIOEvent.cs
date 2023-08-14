using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Jhjo.Common;

namespace YKCJ_Diaper
{
    /// <summary>
    /// 사용자의 조작으로 신호를 송신하며, 시간의 흐름에 따라 신호 송신을 중단하는 클래스
    /// </summary>
    public class CIOEvent : AIOProc
    {
        #region VARIABLE
        private long m_BOnTick = long.MaxValue;
        private int m_I32OnInterval = 1000;
        #endregion


        #region PROPERTIES
        /// <summary>
        /// 신호 송신 유지 시간을 설정하거나 반환한다.
        /// </summary>
        public int I32OnInterval
        {
            get { return this.m_I32OnInterval; }
            set { this.m_I32OnInterval = value; }
        }
        #endregion


        #region CONSTRUCTOR & DESTRUCTOR
        /// <summary>
        /// 생성자
        /// </summary>
        public CIOEvent() { }


        /// <summary>
        /// 생성자
        /// </summary>
        /// <param name="I32OnInterval">신호 송신 유지 시간</param>
        public CIOEvent(int I32OnInterval)
        {
            try
            {
                this.m_I32OnInterval = I32OnInterval;
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
                this.m_BOnTick = DateTime.Now.Ticks;
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
            return EIO_STATUS.LET_OFF;
        }


        /// <summary>
        /// 시간의 흐름에 따른 신호 송신 명령을 처리합니다.
        /// </summary>
        /// <returns>LET_OFF</returns>
        public override EIO_STATUS AutoOn()
        {
            return EIO_STATUS.LET_OFF;
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
                if (this.m_BOnTick + (this.m_I32OnInterval * 10000) < DateTime.Now.Ticks)
                {
                    this.m_BOnTick = long.MaxValue;
                    EResult = EIO_STATUS.LET_OFF;
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
