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
namespace nramirez.gestionAlumnos
{
    public partial class frmLogin : Form
    {
        #region Variables
        GestorUsers oGU = new GestorUsers();
        #endregion        
        #region Propiedades

        #endregion
        #region Constructor

        #endregion
        #region Eventos

        #endregion
        #region Metodos

        #endregion
        public frmLogin()
        {
            InitializeComponent();
        }
        private void IniciarSesion()
        {
            Users oUsers = new Users();
            if (validarControles())
            {
                oUsers.Name = txtUsuario.Text.Trim();
                oUsers.Password = txtPassword.Text.Trim();
                Users oAux = oGU.IniciarSesion(oUsers);
                if (oAux != null)
                {
                    frmPrincipal frm = new frmPrincipal();
                    frm.UsuarioID = oAux.UserID;
                    frm.UsuarioConectado = oAux;
                    //this.Hide();
                    this.Close();
                    frm.Show();

                }
                else
                {
                    MessageBox.Show("El Usuario o la Contraseña Ingresados no son correctos", "Inicio de Sesión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtUsuario.Focus();
                    txtPassword.Text = "";
                }
            }
        }
        private void btnIniciarSesion_Click(object sender, EventArgs e)
        {
            IniciarSesion();
        }
        private bool validarControles()
        {
            if ((txtUsuario.Text!=null && !txtUsuario.Text.Equals(string.Empty)) && txtUsuario.Text.Length<=50)
            {
                if ((txtPassword.Text!=null && !txtPassword.Text.Equals(string.Empty)) && txtPassword.Text.Length<=50)
                {
                    return true;
                }
                else
                {
                    MessageBox.Show("Por favor ingrese la contraseña", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtPassword.Focus();
                    return false;
                }
            }
            else
            {
                MessageBox.Show("Por favor ingrese el usuario", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtUsuario.Focus();
                return false;
            }
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == (int)Keys.Enter)
            {
                IniciarSesion();
            }
        }
    }
}
