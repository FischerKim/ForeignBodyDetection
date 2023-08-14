using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Jhjo.Common;

namespace YKCJ_Diaper
{
    public class CSubStanceFilterList
    {
        #region VARIABLE
        private List<CSubStanceFilter> m_OList = null;
        #endregion


        #region INDEXER
        public CSubStanceFilter this[string StrName]
        {
            get
            {
                CSubStanceFilter OResult = null;

                try
                {
                    foreach (CSubStanceFilter _Item in this.m_OList)
                    {
                        if (_Item.StrName != StrName) continue;

                        OResult = _Item;
                        break;
                    }
                }
                catch (Exception ex)
                {
                    CError.Throw(ex);
                }

                return OResult;
            }
        }
        #endregion


        #region PROPERTIES
        public List<CSubStanceFilter> OList
        {
            get { return this.m_OList; }
        }
        #endregion


        #region CONSTRUCTOR & DESTRUCTOR
        public CSubStanceFilterList()
        {
            try
            {
                this.m_OList = new List<CSubStanceFilter>();
            }
            catch (Exception ex)
            {
                CError.Throw(ex);
            }
        }


        public CSubStanceFilterList(CSubStanceFilterList OSource)
        {
            try
            {
                this.m_OList = new List<CSubStanceFilter>();

                foreach (CSubStanceFilter _Item in OSource.m_OList)
                {
                    this.m_OList.Add(new CSubStanceFilter(_Item));
                }
            }
            catch (Exception ex)
            {
                CError.Throw(ex);
            }
        }
        #endregion


        #region FUNCTION
        public CSubStanceFilter GetMatchFilter(double F64XLength, double F64YLength, double F64Perimeter, double F64Area, double F64Elongation)
        {
            CSubStanceFilter OResult = null;

            try
            {
                foreach (CSubStanceFilter _Item in this.m_OList)
                {
                    if (_Item.IsMatch(F64XLength, F64YLength, F64Perimeter, F64Area, F64Elongation) == false) continue;

                    OResult = _Item;
                    break;
                }
            }
            catch (Exception ex)
            {
                CError.Throw(ex);
            }

            return OResult;
        }
        #endregion
    }
}
