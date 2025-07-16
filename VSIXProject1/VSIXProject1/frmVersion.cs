using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;

namespace VSIXProject1
{
    public partial class frmVersion : Form
    {
        public string version = string.Empty;
        public frmVersion()
        {
            InitializeComponent();
        }
        public frmVersion(string versionAnteriorUsada):this()
        {
            txtVersion.Text=versionAnteriorUsada;
        }

        private void btAceptar_Click(object sender, EventArgs e)
        {
            ValidarNumeroVersion();
        }


        private void btCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void txtVersion_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar== Convert.ToChar(Keys.Enter))
            {
                ValidarNumeroVersion();
            }
        }
       
        private void ValidarNumeroVersion()
        {
            lblError.Visible = false;
            bool valido = RegexValidarNumeroVersion(txtVersion.Text);
            if (valido)
            {
                version = txtVersion.Text;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                lblError.Visible = true;
            }
        }

        private bool RegexValidarNumeroVersion(string version)
        {
            if (!string.IsNullOrEmpty(version))
            {
                return System.Text.RegularExpressions.Regex.IsMatch(version, @"^\d+\.\d+\.\d+(\.\d+)?$");
            }
            return false;
        }

        
    }
}
