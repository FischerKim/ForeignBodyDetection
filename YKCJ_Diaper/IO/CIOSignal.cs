using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Jhjo.Common;

namespace YKCJ_Diaper
{
    public class CIOSignal
    {
        #region VARIABLE
        private Enum m_ESignal = null;
        private ushort m_U16Card = 0;
        private ushort m_U16Line = 0;
        private EIO_STATUS m_ECurrent = EIO_STATUS.LET_OFF;

        private AIOProc m_OProc = null;
        #endregion


        #region PROPERTIES
        /// <summary>
        /// 신호 유형
        /// </summary>
        public Enum ESignal
        {
            get { return this.m_ESignal; }
            set { this.m_ESignal = value; }
        }


        /// <summary>
        /// 라인 번호
        /// </summary>
        public ushort U16Line
        {
            get { return this.m_U16Line; }
        }


        /// <summary>
        /// 신호 송신 여부
        /// (LET_ON = 신호 송신, LET_OF = 신호 비송신)
        /// </summary>
        public EIO_STATUS ECurrent
        {
            get { return this.m_ECurrent; }
        }


        /// <summary>
        /// 프로세스
        /// </summary>
        public AIOProc OProc
        {
            get { return this.m_OProc; }
            set { this.m_OProc = value; }
        }
        #endregion


        #region CONSTRUCTOR & DESTRUCTOR
        /// <summary>
        /// 생성자
        /// </summary>
        /// <param name="U16Card">콘트롤 박스 카드 번호</param>
        /// <param name="U16Line">라인 번호</param>
        public CIOSignal(ushort U16Card, ushort U16Line)
        {
            try
            {
                this.m_U16Card = U16Card;
                this.m_U16Line = U16Line;
            }
            catch (Exception ex)
            {
                CError.Throw(ex);
            }
        }
        #endregion


        #region FUNCTION
        /// <summary>
        /// 사용자의 명령에 따라 신호를 송신합니다.
        /// </summary>
        public void ManualOn()
        {
            try
            {
                if (this.m_OProc != null)
                {
                    if (this.m_ECurrent == EIO_STATUS.LET_OFF)
                    {
                        if (this.m_OProc.ManualOn() == EIO_STATUS.LET_ON) this.On();
                    }
                    else
                    {
                        if (this.m_OProc.ManualOn() == EIO_STATUS.LET_OFF) this.Off();
                    }
                }
            }
            catch (Exception ex)
            {
                CError.Throw(ex);
            }
        }


        /// <summary>
        /// 사용자의 명령에 따라 신호 송신을 중단합니다.
        /// </summary>
        public void ManualOff()
        {
            try
            {
                if (this.m_OProc != null)
                {
                    if (this.m_ECurrent == EIO_STATUS.LET_OFF)
                    {
                        if (this.m_OProc.ManualOff() == EIO_STATUS.LET_ON) this.On();
                    }
                    else
                    {
                        if (this.m_OProc.ManualOff() == EIO_STATUS.LET_OFF) this.Off();
                    }
                }
            }
            catch (Exception ex)
            {
                CError.Throw(ex);
            }
        }


        /// <summary>
        /// 시간의 흐름에 따른 신호 송신*중단을 처리합니다.
        /// </summary>
        public void Process()
        {
            try
            {
                if (this.m_OProc != null)
                {
                    if (this.m_ECurrent == EIO_STATUS.LET_OFF)
                    {
                        if (this.m_OProc.AutoOn() == EIO_STATUS.LET_ON) this.On();
                    }
                    else
                    {
                        if (this.m_OProc.AutoOff() == EIO_STATUS.LET_OFF) this.Off();
                    }
                }
            }
            catch (Exception ex)
            {
                CError.Throw(ex);
            }
        }


        /// <summary>
        /// 신호를 송신합니다.
        /// </summary>
        public void On()
        {
            try
            {
                CPCI7230.DO_WriteLine(this.m_U16Card, 0, this.m_U16Line, 1);
                this.m_ECurrent = EIO_STATUS.LET_ON;
            }
            catch (Exception ex)
            {
                CError.Throw(ex);
            }
        }


        /// <summary>
        /// 신호의 송신을 중단합니다.
        /// </summary>
        public void Off()
        {
            try
            {
                CPCI7230.DO_WriteLine(this.m_U16Card, 0, this.m_U16Line, 0);
                this.m_ECurrent = EIO_STATUS.LET_OFF;
            }
            catch (Exception ex)
            {
                CError.Throw(ex);
            }
        }
        #endregion
    }


    #region ENUM
    public enum EIO_STATUS
    {
        LET_ON,
        LET_OFF
    }
    #endregion
}
