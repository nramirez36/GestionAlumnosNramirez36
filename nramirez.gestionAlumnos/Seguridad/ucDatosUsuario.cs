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
namespace nramirez.gestionAlumnos.Seguridad.ABM_Usuarios
{
    public partial class ucDatosUsuario : UserControl
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
        public Users Usuario { get; set; }
        public bool ModoSoloLectura { get; set; }


        public ucDatosUsuario()
        {
            InitializeComponent();
        }

        private void ucDatosUsuario_Load(object sender, EventArgs e)
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
            if (txtUsuario.Text==null || txtUsuario.Text.Equals(""))
            {
                MessageBox.Show("Debe ingresar el Usuario","Error", MessageBoxButtons.OK,MessageBoxIcon.Error);
                return false;
            }
            if (txtPassword.Text==null || txtPassword.Text.Equals(""))
            {
                MessageBox.Show("Debe ingresar la Contraseña", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (txtEmail.Text==null ||txtEmail.Text.Equals(""))
            {
                MessageBox.Show("Debe ingresar el Email","Error", MessageBoxButtons.OK,MessageBoxIcon.Error);
                return false;
            }
            //if (!Utiles.validarEmail(txtEmail.Text.Trim()))
            if(!Utiles.ComprobarFormatoEmail(txtEmail.Text.Trim()))
            {
                MessageBox.Show("Debe ingresar un Email valido","Error", MessageBoxButtons.OK,MessageBoxIcon.Error);
                return false;
            }
            Usuario = new Users();
            Usuario.Name = txtUsuario.Text;
            Usuario.Password = txtPassword.Text;
            Usuario.Email=txtEmail.Text;
            return true;
        }
        public void limpiarControles()
        {
            txtEmail.Text = "";
            txtPassword.Text = "";
            txtUsuario.Text="";
        }
        public void llenarControles(string pUser, string pPass, string pEmail)
        {
            txtUsuario.Text = pUser;
            txtPassword.Text = pPass;
            txtEmail.Text = pEmail;
        }
    }
}
