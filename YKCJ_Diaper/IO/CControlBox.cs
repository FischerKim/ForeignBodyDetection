using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Jhjo.Common;
using System.Threading;

namespace YKCJ_Diaper
{
    public class CControlBox : IDisposable
    {
        #region SINGLE TON
        private static CControlBox Src_It = null;

        public static CControlBox It
        {
            get
            {
                CControlBox OResult = null;

                try
                {
                    if (CControlBox.Src_It == null)
                    {
                        CControlBox.Src_It = new CControlBox();
                    }

                    OResult = CControlBox.Src_It;
                }
                catch (Exception ex)
                {
                    CError.Throw(ex);
                }

                return OResult;
            }
        }
        #endregion


        #region STATIC VARIABLE
        public static int MAX_LINE_COUNT = 16;
        #endregion


        #region VARIABLE
        private ushort m_U16Card = 0;
        private bool m_BRegisted = false;

        private List<CIOSignal> m_LstOSignal = null;
        private bool m_BRunAuto = true;
        private object m_OInterrupt = null;

        private Thread m_OWorker = null;
        private bool m_BDoWork = false;
        #endregion


        #region PROPERTIES
        /// <summary>
        /// 컨트롤 박스 연결 여부
        /// </summary>
        public bool BRegisted
        {
            get { return this.m_BRegisted; }
        }


        /// <summary>
        /// Auto 모드 동작 여부
        /// </summary>
        public bool BRunAuto
        {
            get { return this.m_BRunAuto; }
        }
        #endregion


        #region CONSTRUCTOR & DESTRUCTOR
        protected CControlBox()
        {
            try
            {
                this.m_BRegisted = this.Regist();
                this.m_OInterrupt = new object();

                if (this.m_BRegisted == true)
                {
                    this.m_LstOSignal = new List<CIOSignal>();
                    for (ushort _Index = 0; _Index < MAX_LINE_COUNT; _Index++)
                    {
                        this.m_LstOSignal.Add(new CIOSignal(this.m_U16Card, _Index));
                    }

                    this.BeginWork();
                }
            }
            catch (Exception ex)
            {
                CError.Throw(ex);
            }
        }


        ~CControlBox()
        {
            try
            {
                this.Dispose();
            }
            catch (Exception ex)
            {
                CError.Ignore(ex);
            }
        }
        #endregion


        #region FUNCTION
        /// <summary>
        /// PCI7230 컨트롤박스에 연결합니다.
        /// </summary>
        /// <returns>정상 연결 여부</returns>
        private bool Regist()
        {
            bool BResult = false;

            try
            {
                this.m_U16Card = (ushort)CPCI7230.Register_Card(CPCI7230.PCI_7230, 0);
                CPCI7230.DO_WritePort(this.m_U16Card, 0, 0);

                BResult = true;
            }
            catch (Exception ex)
            {
                CError.Throw(ex);
            }

            return BResult;
        }


        /// <summary>
        /// PCI7230 컨트롤박스와의 연결을 해제합니다.
        /// </summary>
        private void Release()
        {
            try
            {
                if (this.m_BRegisted == true)
                {
                    CPCI7230.DO_WritePort(this.m_U16Card, 0, 0);
                    CPCI7230.Release_Card(this.m_U16Card);
                }
            }
            catch (Exception ex)
            {
                CError.Throw(ex);
            }
        }


        /// <summary>
        /// Thread를 시작합니다.
        /// </summary>
        private void BeginWork()
        {
            try
            {
                if (this.m_OWorker == null)
                {
                    this.m_BDoWork = true;

                    this.m_OWorker = new Thread(this.Work);
                    this.m_OWorker.IsBackground = true;
                    this.m_OWorker.Start();
                }
            }
            catch (Exception ex)
            {
                CError.Throw(ex);
            }
        }


        /// <summary>
        /// Thread가 동작되는 함수(Auto On/Off에 대한 처리를 수행합니다.)
        /// </summary>
        private void Work()
        {
            try
            {
                while (this.m_BDoWork == true)
                {
                    try
                    {
                        Monitor.Enter(this.m_OInterrupt);

                        if (this.m_BRunAuto == true)
                        {
                            foreach (CIOSignal _Item in this.m_LstOSignal)
                            {
                                _Item.Process();
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                    finally
                    {
                        Monitor.Exit(this.m_OInterrupt);
                    }

                    Thread.Sleep(1);
                }
            }
            catch (Exception ex)
            {
                CError.Throw(ex);
            }
        }


        /// <summary>
        /// Thread 종료 함수
        /// </summary>
        private void EndWork()
        {
            try
            {
                if (this.m_OWorker != null)
                {
                    this.m_BDoWork = false;

                    this.m_OWorker.Join();
                    this.m_OWorker = null;
                }
            }
            catch (Exception ex)
            {
                CError.Throw(ex);
            }
        }


        /// <summary>
        /// 주어진 라인 번호에 신호를 송신합니다.
        /// (Auto 모드(O) : 주어진 Proc에 따라 신호 송신*중단 결정,
        ///  Auto 모드(X) : 반드시 신호를 송신)
        /// </summary>
        /// <param name="U16Line">라인 번호</param>
        public void On(ushort U16Line)
        {
            try
            {
                Monitor.Enter(this.m_OInterrupt);

                foreach (CIOSignal _Item in this.m_LstOSignal)
                {
                    if (_Item.U16Line != U16Line) continue;

                    if (this.m_BRunAuto == true) _Item.ManualOn();
                    else _Item.On();
                    break;
                }
            }
            catch (Exception ex)
            {
                CError.Throw(ex);
            }
            finally
            {
                Monitor.Exit(this.m_OInterrupt);
            }
        }


        /// <summary>
        /// 주어진 라인 번호에 송신하던 신호를 중단합니다.
        /// (Auto 모드(O) : 주어진 Proc에 따라 신호 송신*중단 결정,
        ///  Auto 모드(X) : 반드시 신호 송신을 중단)
        /// </summary>
        /// <param name="U16Line">라인 번호</param>
        public void Off(ushort U16Line)
        {
            try
            {
                Monitor.Enter(this.m_OInterrupt);

                foreach (CIOSignal _Item in this.m_LstOSignal)
                {
                    if (_Item.U16Line != U16Line) continue;

                    if (this.m_BRunAuto == true) _Item.ManualOff();
                    else _Item.Off();
                    break;
                }
            }
            catch (Exception ex)
            {
                CError.Throw(ex);
            }
            finally
            {
                Monitor.Exit(this.m_OInterrupt);
            }
        }


        /// <summary>
        /// 주어진 신호 유형에 신호를 송신합니다.
        /// (Auto 모드(O) : 주어진 Proc에 따라 신호 송신*중단 결정,
        ///  Auto 모드(X) : 반드시 신호를 송신)
        /// </summary>
        /// <param name="ESignal">신호 유형</param>
        public void On(Enum ESignal)
        {
            try
            {
                Monitor.Enter(this.m_OInterrupt);

                foreach (CIOSignal _Item in this.m_LstOSignal)
                {
                    if (_Item.ESignal == null) continue;
                    if (_Item.ESignal.Equals(ESignal) == false) continue;

                    if (this.m_BRunAuto == true) _Item.ManualOn();
                    else _Item.On();
                    break;
                }
            }
            catch (Exception ex)
            {
                CError.Throw(ex);
            }
            finally
            {
                Monitor.Exit(this.m_OInterrupt);
            }
        }


        /// <summary>
        /// 주어진 신호 유형에 송신하던 신호를 중단합니다.
        /// (Auto 모드(O) : 주어진 Proc에 따라 신호 송신*중단 결정,
        ///  Auto 모드(X) : 반드시 신호 송신을 중단)
        /// </summary>
        /// <param name="U16Line">신호 유형</param>
        public void Off(Enum ESignal)
        {
            try
            {
                Monitor.Enter(this.m_OInterrupt);

                foreach (CIOSignal _Item in this.m_LstOSignal)
                {
                    if (_Item.ESignal == null) continue;
                    if (_Item.ESignal.Equals(ESignal) == false) continue;

                    if (this.m_BRunAuto == true) _Item.ManualOff();
                    else _Item.Off();
                    break;
                }
            }
            catch (Exception ex)
            {
                CError.Throw(ex);
            }
            finally
            {
                Monitor.Exit(this.m_OInterrupt);
            }
        }


        /// <summary>
        /// 모든 라인에 신호를 송신합니다.(Auto 모드에서는 동작하지 않습니다.)
        /// </summary>
        public void OnAll()
        {
            try
            {
                Monitor.Enter(this.m_OInterrupt);

                if (this.m_BRunAuto == true)
                {
                    throw new Exception("Cannot control controlbox during running auto mode!");
                }
                else
                {
                    foreach (CIOSignal _Item in this.m_LstOSignal)
                    {
                        _Item.On();
                    }
                }
            }
            catch (Exception ex)
            {
                CError.Throw(ex);
            }
            finally
            {
                Monitor.Exit(this.m_OInterrupt);
            }
        }


        /// <summary>
        /// 모든 라인에 송신하던 신호를 중단합니다.(Auto 모드에서는 동작하지 않습니다.)
        /// </summary>
        public void OffAll()
        {
            try
            {
                Monitor.Enter(this.m_OInterrupt);

                if (this.m_BRunAuto == true)
                {
                    throw new Exception("Cannot control controlbox during running auto mode!");
                }
                else
                {
                    foreach (CIOSignal _Item in this.m_LstOSignal)
                    {
                        _Item.Off();
                    }
                }
            }
            catch (Exception ex)
            {
                CError.Throw(ex);
            }
            finally
            {
                Monitor.Exit(this.m_OInterrupt);
            }
        }


        /// <summary>
        /// 주어진 라인 번호에 신호 유형 및 IOManual 프로세스를 설정합니다.
        /// (신호 유형에 대해 기존에 설정된 프로세스는 제거됩니다.)
        /// </summary>
        /// <param name="U16Line">라인 번호</param>
        /// <param name="ESignal">신호 유형</param>
        public void SetIOManual(ushort U16Line, Enum ESignal)
        {
            try
            {
                this.SetIOProc(U16Line, ESignal, new CIOManual());
            }
            catch (Exception ex)
            {
                CError.Throw(ex);
            }
        }


        /// <summary>
        /// 주어진 라인 번호에 신호 유형 및 IOEvent 프로세스를 설정합니다.
        /// (신호 유형에 대해 기존에 설정된 프로세스는 제거됩니다.)
        /// </summary>
        /// <param name="U16Line">라인 번호</param>
        /// <param name="ESignal">신호 유형</param>
        /// <param name="I32OnInterval">신호 송신 유지 시간</param>
        public void SetIOEvent(ushort U16Line, Enum ESignal, int I32OnInterval)
        {
            try
            {
                this.SetIOProc(U16Line, ESignal, new CIOEvent(I32OnInterval));
            }
            catch (Exception ex)
            {
                CError.Throw(ex);
            }
        }


        /// <summary>
        /// 주어진 라인 번호에 신호 유형 및 IOPulse 프로세스를 설정합니다.
        /// (신호 유형에 대해 기존에 설정된 프로세스는 제거됩니다.)
        /// </summary>
        /// <param name="U16Line">라인 번호</param>
        /// <param name="ESignal"></param>
        /// <param name="I32OnInterval">신호 송신 유지 시간</param>
        /// <param name="I32OffInterval">신호 송신 중단 유지 시간</param>
        public void SetIOPulse(ushort U16Line, Enum ESignal, int I32OnInterval, int I32OffInterval)
        {
            try
            {
                this.SetIOProc(U16Line, ESignal, new CIOPulse(I32OnInterval, I32OffInterval));
            }
            catch (Exception ex)
            {
                CError.Throw(ex);
            }
        }


        /// <summary>
        /// 주어진 라인 번호에 신호 유형 및 프로세스를 설정합니다.
        /// (신호 유형에 대해 기존에 설정된 프로세스는 제거됩니다.)
        /// </summary>
        /// <param name="U16Line">라인 번호</param>
        /// <param name="ESignal">신호 유형</param>
        /// <param name="OProc">프로세스</param>
        public void SetIOProc(ushort U16Line, Enum ESignal, AIOProc OProc)
        {
            try
            {
                Monitor.Enter(this.m_OInterrupt);

                foreach (CIOSignal _Item in this.m_LstOSignal)
                {
                    if (_Item.ESignal == null) continue;
                    if (_Item.ESignal.Equals(ESignal) == false) continue;

                    _Item.ESignal = null;
                    _Item.OProc = null;
                    _Item.Off();
                    break;
                }

                foreach (CIOSignal _Item in this.m_LstOSignal)
                {
                    if (_Item.U16Line != U16Line) continue;

                    _Item.ESignal = ESignal;
                    _Item.OProc = OProc;
                    break;
                }
            }
            catch (Exception ex)
            {
                CError.Throw(ex);
            }
            finally
            {
                Monitor.Exit(this.m_OInterrupt);
            }
        }


        /// <summary>
        /// 주어진 신호 유형에 설정된 신호 유형 및 프로세를 제거합니다.
        /// </summary>
        /// <param name="ESignal">신호 유형</param>
        public void DeleteProc(Enum ESignal)
        {
            try
            {
                Monitor.Enter(this.m_OInterrupt);

                foreach (CIOSignal _Item in this.m_LstOSignal)
                {
                    if (_Item.ESignal == null) continue;
                    if (_Item.ESignal.Equals(ESignal) == false) continue;

                    _Item.ESignal = null;
                    _Item.OProc = null;
                    _Item.Off();
                    break;
                }
            }
            catch (Exception ex)
            {
                CError.Throw(ex);
            }
            finally
            {
                Monitor.Exit(this.m_OInterrupt);
            }
        }


        /// <summary>
        /// 모든 신호에 대한 신호 유형 및 프로세스를 제거합니다.
        /// </summary>
        public void ClearProc()
        {
            try
            {
                Monitor.Enter(this.m_OInterrupt);

                foreach (CIOSignal _Item in this.m_LstOSignal)
                {
                    _Item.ESignal = null;
                    _Item.OProc = null;
                    _Item.Off();
                }
            }
            catch (Exception ex)
            {
                CError.Throw(ex);
            }
            finally
            {
                Monitor.Exit(this.m_OInterrupt);
            }
        }


        /// <summary>
        /// 해당 클래스에 할당한 메모리를 소거한다.
        /// </summary>
        public void Dispose()
        {
            try
            {
                this.EndWork();
                this.Release();
            }
            catch (Exception ex)
            {
                CError.Throw(ex);
            }
        }
        #endregion
    }
}

    
