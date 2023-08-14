using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Jhjo.Common;

namespace YKCJ_Diaper
{
    public partial class frmRecipe : Form
    {
        #region PROPERTIES
        public string StrName
        {
            get { return this.TxtName.Text; }
        }
        #endregion


        #region CONSTRUCTOR & DESTRUCTOR
        public frmRecipe()
        {
            InitializeComponent();
        }
        #endregion


        #region EVENT
        #region BUTTON EVENT
        private void BtnOK_Click(object sender, EventArgs e)
        {
            try
            {
                if (String.IsNullOrEmpty(this.TxtName.Text) == true)
                {
                    CMsgBox.Warning("모델 이름을 입력하여 주세요.");
                    return;
                }


                foreach (CDiaperFaultRecipe _Item in CRecipeManager.It.LstORecipe)
                {
                    if (_Item.StrName != this.TxtName.Text.Trim()) continue;

                    CMsgBox.Warning("동일한 이름의 모델이 존재합니다.");
                    return;
                }

                this.DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                CError.Throw(ex);
            }
        }


        private void BtnCancel_Click(object sender, EventArgs e)
        {
            try
            {
                this.DialogResult = DialogResult.Cancel;
            }
            catch (Exception ex)
            {
                CError.Throw(ex);
            }
        }
        #endregion
        #endregion
    }
}
