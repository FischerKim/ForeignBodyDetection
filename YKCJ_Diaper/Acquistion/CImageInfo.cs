using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cognex.VisionPro;
using System.Drawing;
using Jhjo.Common;

namespace YKCJ_Diaper
{
    public class CImageInfo
    {
        #region VARIABLE
        private DateTime m_OTime = DateTime.MinValue;
        private CogImage8Grey m_OImage = null;
        #endregion


        #region PROPERTIES
        public DateTime OTime
        {
            get { return this.m_OTime; }
        }


        public CogImage8Grey OImage
        {
            get { return this.m_OImage; }
        }
        #endregion


        #region CONSTRUCTOR & DESTRUCTOR
        public CImageInfo(Bitmap OSource)
        {
            try
            {
                this.m_OTime = DateTime.Now;
                this.m_OImage = new CogImage8Grey(OSource);
            }
            catch (Exception ex)
            {
                CError.Throw(ex);
            }
        }
        #endregion
    }
}
