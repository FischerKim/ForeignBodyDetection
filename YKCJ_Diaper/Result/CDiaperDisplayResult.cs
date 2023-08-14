using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Daekhon.Common;
using Jhjo.Common;

namespace YKCJ_Diaper
{
    /*
    public class CDiaperDisplayResult
    {
        #region VARIABLE
        private CDiaperFaultResult m_OSymbolResult = null;
        private CDiaperFaultResult[] m_ArrOResult = null;

        private ulong m_U64Total = 0;
        private ulong m_U64OK = 0;
        private ulong m_U64NG = 0;
        #endregion


        #region PROPERTIES
        public CDiaperFaultResult OSymbolResult
        {
            get { return this.m_OSymbolResult; }
        }


        public CDiaperFaultResult[] ArrOResult
        {
            get { return this.m_ArrOResult; }
        }


        public ulong U64Total
        {
            get { return this.m_U64Total; }
            set { this.m_U64Total = value; }
        }


        public ulong U64OK
        {
            get { return this.m_U64OK; }
            set { this.m_U64OK = value; }
        }


        public ulong U64NG
        {
            get { return this.m_U64NG; }
            set { this.m_U64NG = value; }
        }
        #endregion


        #region CONSTRUCTOR & DESTRUCTOR
        public CDiaperDisplayResult(CDiaperFaultResult[] ArrOResult)
        {
            try
            {
                this.m_ArrOResult = ArrOResult;

                for (int _Index = this.m_ArrOResult.Length - 1; _Index >= 0; _Index--)
                {
                    if (this.m_OSymbolResult == null)
                    {
                        this.m_OSymbolResult = this.m_ArrOResult[_Index];
                        if (this.m_OSymbolResult.ORecipe != null) break;
                    }
                    else
                    {
                        if (this.m_ArrOResult[_Index].ORecipe != null)
                        {
                            this.m_OSymbolResult = this.m_ArrOResult[_Index];
                            break;
                        }
                        if ((this.m_OSymbolResult.BOK == true) && (this.m_ArrOResult[_Index].BOK == false))
                        {
                            this.m_OSymbolResult = this.m_ArrOResult[_Index];
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                CError.Throw(ex);
            }
        }
        #endregion
    }*/
}
