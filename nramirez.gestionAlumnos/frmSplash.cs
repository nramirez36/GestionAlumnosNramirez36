using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace nramirez.gestionAlumnos
{
    public partial class frmSplash : Form
    {
        #region Variables

        #endregion
        #region Propiedades

        #endregion
        #region Constructor

        #endregion
        #region Eventos

        #endregion
        #region Metodos

        #endregion
        public frmSplash()
        {
            InitializeComponent();
        }

        private void frmSplash_Load(object sender, EventArgs e)
        {
            progressBar1.Width = this.Width;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            frmLogin frm = new frmLogin();
            progressBar1.Visible = true;
            this.progressBar1.Value = this.progressBar1.Value + 2;
            if (this.progressBar1.Value == 10)
            {
                lblMensaje.Text = "Leyendo modulos...";
            }
            else if (this.progressBar1.Value == 20)
            {
                lblMensaje.Text = "Conectando modulos...";
            }
            else if (this.progressBar1.Value == 40)
            {
                lblMensaje.Text = "Iniciando modulos...";
            }
            else if (this.progressBar1.Value == 60)
            {
                lblMensaje.Text = "Cargando modulos...";
            }
            else if (this.progressBar1.Value == 80)
            {
                lblMensaje.Text = "Modulos cargados...";
            }
            else if (this.progressBar1.Value == 100)
            {
                frm.Show();
                timer1.Enabled = false;
                //this.Hide();
                this.Close();
            }
        }
    }
}
