using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YKCJ_Diaper
{
    /// <summary>
    /// 사용자의 조작으로 신호를 송신하거나, 신호의 송신을 중단하는 클래스
    /// </summary>
    public class CIOManual : AIOProc
    {
        #region FUNCTION
        /// <summary>
        /// 사용자의 신호 송신 명령을 처리합니다.
        /// </summary>
        /// <returns>LET_ON</returns>
        public override EIO_STATUS ManualOn()
        {
            return EIO_STATUS.LET_ON;
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
        /// <returns>LET_ON</returns>
        public override EIO_STATUS AutoOff()
        {
            return EIO_STATUS.LET_ON;
        }
        #endregion
    }
}
