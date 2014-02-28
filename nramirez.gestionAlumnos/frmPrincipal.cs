using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using gestionalumnos.BL;
using gestionalumnos.Entities;
using nramirez.gestionAlumnos.Seguridad;
namespace nramirez.gestionAlumnos
{
    public partial class frmPrincipal : Form
    {
        #region Propiedades
        public int UsuarioID { get; set; }
        GestorUsers oGU = new GestorUsers();
        public Users UsuarioConectado { get; set; }
        #endregion
        #region Variables

        #endregion
        #region Eventos

        #endregion
        #region Metodos

        #endregion
        public frmPrincipal()
        {
            InitializeComponent();
        }
        public void LoadDatos()
        {
            //Users oGU.Buscar(UsuarioID);
            //Users oUser = oGU.Buscar(UsuarioID);
            this.Text = this.Text + " - " + UsuarioConectado.Name;
            tSSLUsuario.Text = UsuarioConectado.Name;
         
        }

        private void frmPrincipal_Load(object sender, EventArgs e)
        {
            LoadDatos();
            //ACA DEBERIA VER EL TEMA DE LOS ROLES
        }

        private void cerrarSesionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmLogin frm = new frmLogin();
            frm.txtPassword.Text = "";
            frm.txtUsuario.Text = "";
            this.Hide();
            frm.Show();
        }

        private void usuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmUsuario frm = new frmUsuario();
            //frm.MdiParent = this;
            frm.Show();
        }

        private void frmPrincipal_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            tSSLFecha.Text = DateTime.Now.ToString();
            timer1.Start();
        }
    }
}
