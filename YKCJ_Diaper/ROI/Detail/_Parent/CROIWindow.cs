using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Jhjo.Common;
using Cognex.VisionPro;

namespace YKCJ_Diaper
{
    public class CROIWindow : Form
    {
        #region PROPERTIES
        public virtual CRecipeDesignTool OTool
        {
            set { }
        }


        public virtual CBlobRecipe ORecipe
        {
            set { }
        }
        #endregion
    }
}
