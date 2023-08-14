using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Jhjo.Common;

namespace YKCJ_Diaper
{
    public partial class UcSubRecipe : UserControl
    {
        #region CONSTRUCTOR & DESTRUCTOR
        public UcSubRecipe()
        {
            InitializeComponent();
        }
        #endregion


        #region FUNCTION
        public virtual void Add() { }


        public virtual void Remove() { }


        public virtual void Display() { }


        public virtual void SetRecipe(CDiaperFaultRecipe ORecipe) { }


        public virtual bool Apply() { return true; }


        public virtual void AddGraphic() { }


        public virtual void MoveGraphic(string StrDirection, int I32Distance) { }
        #endregion
    }
}
