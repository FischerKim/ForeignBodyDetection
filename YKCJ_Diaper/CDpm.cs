using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using Jhjo.Common;

namespace YKCJ_Diaper
{
    public class CDpm
    {
        #region VARIABLE
        private List<long> m_LstI64Tick = null;
        private object m_OInterrupt = null;
        #endregion


        #region CONSTRUCTOR & DESTRUCTOR
        public CDpm()
        {
            try
            {
                this.m_LstI64Tick = new List<long>();
                this.m_OInterrupt = new object();
            }
            catch (Exception ex)
            {
                CError.Throw(ex);
            }
        }
        #endregion


        #region FUNCTION
        public void Add()
        {
            try
            {
                Monitor.Enter(this.m_OInterrupt);

                this.m_LstI64Tick.Add(DateTime.Now.Ticks);
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


        public int GetDpm()
        {
            int I32Result = 0;

            try
            {
                Monitor.Enter(this.m_OInterrupt);


                long I64Tick = DateTime.Now.Ticks;

                while (this.m_LstI64Tick.Count > 0)
                {
                    if (this.m_LstI64Tick[0] + 600000000 < I64Tick)
                    {
                        this.m_LstI64Tick.RemoveAt(0);
                    }
                    else break;
                }


                I32Result = this.m_LstI64Tick.Count;
            }
            catch (Exception ex)
            {
                CError.Throw(ex);
            }
            finally
            {
                Monitor.Exit(this.m_OInterrupt);
            }

            return I32Result;
        }


        public int GetDps()
        {
            int I32Result = 0;

            try
            {
                Monitor.Enter(this.m_OInterrupt);


                long I64Value = DateTime.Now.Ticks;

                for (int _Index = this.m_LstI64Tick.Count - 1; _Index >= 0; _Index--)
                {
                    if (this.m_LstI64Tick[_Index] + 10000000 >= I64Value)
                    {
                        I32Result++;
                    }
                    else break;
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

            return I32Result;
        }
        #endregion
    }
}
