using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using gestionalumnos.Entities;
using gestionalumnos.BL;
using gestionalumnos.Comun;
namespace nramirez.gestionAlumnos.Seguridad.ABM_Usuarios
{
    public partial class ucDatosUsuario : UserControl
    {
        #region Propiedades
        public Users Usuario { get; set; }
        public bool ModoSoloLectura { get; set; }
        #endregion
        #region Constructor
        public ucDatosUsuario()
        {
            InitializeComponent();
        }
        #endregion
        #region Eventos
        private void ucDatosUsuario_Load(object sender, EventArgs e)
        {
            HabilitarControles();
            RegistrarControles();
        }
        private void ucDatosUsuario_Paint(object sender, PaintEventArgs e)
        {
            HabilitarControles();
        }
        #endregion
        #region Metodos
        private void RegistrarControles()
        {
            List<Controls> lista = new List<Controls>();
            foreach (Control controlChotex in this.Controls)
            {
                Controls c = new Controls();
                c.ControlID = controlChotex.Name;
                c.Page = this.Name;
                lista.Add(c);
            }
            GestorControles oGC = new GestorControles();
            for (int i = 0; i < lista.Count; i++)
            {
                if (!oGC.Existe(lista[i]))
                {
                    oGC.Insertar(lista[i]);
                }
            }
        }
        public void HabilitarControles()
        {
            //CONSULTA DE DATOS--->TRUE
            if (ModoSoloLectura)
            {
                txtUsuario.Enabled = false;
                txtUsuario.BackColor = SystemColors.Info;
                txtPassword.Enabled = false;
                txtPassword.BackColor = SystemColors.Info;
                txtEmail.Enabled = false;
                txtEmail.BackColor = SystemColors.Info;
            }
            else
            {
                txtUsuario.Enabled = true;
                txtUsuario.BackColor = SystemColors.Window;
                txtPassword.Enabled = true;
                txtPassword.BackColor = SystemColors.Window;
                txtEmail.Enabled = true;
                txtEmail.BackColor = SystemColors.Window;
            }
        }
        public bool validarControles()
        {
            bool res = false;
            string msg = "";
            if (txtUsuario.Text == null || txtUsuario.Text.Equals(""))
            {
                MessageBox.Show("Debe ingresar el Usuario", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (txtPassword.Text == null || txtPassword.Text.Equals(""))
            {
                MessageBox.Show("Debe ingresar la Contraseña", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (txtEmail.Text == null || txtEmail.Text.Equals(""))
            {
                MessageBox.Show("Debe ingresar el Email", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            //if (!Utiles.validarEmail(txtEmail.Text.Trim()))
            if (!Utiles.ComprobarFormatoEmail(txtEmail.Text.Trim()))
            {
                MessageBox.Show("Debe ingresar un Email valido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            Usuario = new Users();
            Usuario.Name = txtUsuario.Text;
            Usuario.Password = txtPassword.Text;
            Usuario.Email = txtEmail.Text;
            return true;
        }
        public void limpiarControles()
        {
            txtEmail.Text = "";
            txtPassword.Text = "";
            txtUsuario.Text = "";
        }
        public void llenarControles(string pUser, string pPass, string pEmail)
        {
            txtUsuario.Text = pUser;
            txtPassword.Text = pPass;
            txtEmail.Text = pEmail;
        }
        #endregion
    }
}
