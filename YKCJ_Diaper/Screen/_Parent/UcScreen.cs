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
    public partial class UcScreen : UserControl
    {
        #region DELEGATE & EVENT
        public delegate void ScreenFixedHandler(bool BFixed);
        public event ScreenFixedHandler ScreenFixed = null;
        #endregion


        #region CONSTRUCTOR & DESTRUCTOR
        public UcScreen()
        {
            InitializeComponent();
            base.DoubleBuffered = true;
        }
        #endregion


        #region FUNCTION
        public virtual void Add() { }


        public virtual void Remove() { }


        public virtual void OpenSubScreen(ESUBSCREEN ESubScreen) { }


        public virtual void SetRecipe(CDiaperFaultRecipe ORecipe) { }


        public virtual void SetResult(CDiaperFaultResult OResult) { }


        public virtual void OnTimer1000() { }


        protected void OnScreenFixed(bool BFixed)
        {
            try
            {
                if (this.ScreenFixed != null)
                {
                    this.ScreenFixed(BFixed);
                }
            }
            catch (Exception ex)
            {
                CError.Throw(ex);
            }
        }
        #endregion
    }

    #region ENUM
    public enum ESUBSCREEN : byte
    {
        NONE = 0x00,
        HOME,
        RECIPE,
        SETUP,
        SUBSTANCE,
        IO
    }
    #endregion
}
