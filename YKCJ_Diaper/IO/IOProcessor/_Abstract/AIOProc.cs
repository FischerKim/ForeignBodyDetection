using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YKCJ_Diaper
{
    public abstract class AIOProc
    {
        #region FUNCTION
        /// <summary>
        /// 사용자의 신호 송신 명령을 처리합니다.
        /// </summary>
        /// <returns>신호 송신 여부</returns>
        public virtual EIO_STATUS ManualOn() { return EIO_STATUS.LET_OFF; }


        /// <summary>
        /// 사용자의 신호 송신 중단 명령을 처리합니다.
        /// </summary>
        /// <returns>신호 송신 여부</returns>
        public virtual EIO_STATUS ManualOff() { return EIO_STATUS.LET_OFF; }


        /// <summary>
        /// 시간의 흐름에 따른 신호 송신 명령을 처리합니다.
        /// </summary>
        /// <returns>신호 송신 여부</returns>
        public virtual EIO_STATUS AutoOn() { return EIO_STATUS.LET_OFF; }


        /// <summary>
        /// 시간의 흐름에 따른 신호 중단 명령을 처리합니다.
        /// </summary>
        /// <returns>신호 송신 여부</returns>
        public virtual EIO_STATUS AutoOff() { return EIO_STATUS.LET_OFF; }
        #endregion
    }
}
