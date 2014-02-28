using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using gestionalumnos.Entities;
using gestionalumnos.BL;
namespace nramirez.gestionAlumnos.Seguridad
{
    public partial class frmABMUsuarios : Form
    {
        #region Propiedades
        public bool ModoLectura { get; set; }
        public int Opcion { get; set; }
        public Users UsuarioModificar { get; set; }
        public int IdUser { get; set; }
        #endregion
        #region Variables
        private GestorUsers oGU = new GestorUsers();
        #endregion
        #region Constructor
        public frmABMUsuarios()
        {
            InitializeComponent();
        }
        #endregion
        #region Eventos
        private void frmABMUsuarios_Load(object sender, EventArgs e)
        {
            if (ModoLectura)
            {
                this.Text = this.Text + " - Consulta de Usuarios";
                btnCancelar.Visible = false;
                btnRegistrar.Text = "Aceptar";
            }
            else
            {
                switch (Opcion)
                {
                    case 1: this.Text = this.Text + " - Alta de Usuario";
                        btnCancelar.Visible = true;
                        btnRegistrar.Text = "Registrar";
                        break;
                    case 2: this.Text = this.Text + " - Edicion de Usuario";
                        btnCancelar.Visible = true;
                        btnRegistrar.Text = "Modificar";
                        break;
                }
            }
        }
        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            if (ucDatosUsuario1.validarControles())
            {
                Users oUser = ucDatosUsuario1.Usuario;
                switch (Opcion)
                {
                    case (int)Utiles.OpcionesABM.ALTA:
                        if (!oGU.VerficarExistencia(oUser.Name))
                        {
                            int i = oGU.Insertar(oUser);
                            if (i > 1)
                            {
                                MessageBox.Show("Se dio de alta al Usuario", "Alta de Usuarios", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                ucDatosUsuario1.limpiarControles();
                                this.Close();
                            }
                            else
                            {
                                MessageBox.Show("No se pudo dar de alta al Usuario", "Alta de Usuarios", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        else
                        {
                            MessageBox.Show("El Usuario ingresado ya existe", "Alta de Usuarios", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        break;
                    case (int)Utiles.OpcionesABM.MODIFICACION:
                        if (oGU.Modificar(oUser))
                        {
                            MessageBox.Show("Se modifico al Usuario", "Alta de Usuarios", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            ucDatosUsuario1.limpiarControles();
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("No se pudo dar modificar al Usuario", "Alta de Usuarios", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        break;
                }
            }
        }
        #endregion
        #region Metodos
        private void RecuperarDatos()
        {
            UsuarioModificar = new Users();
            UsuarioModificar = oGU.Buscar(UsuarioModificar.UserID);
            if (UsuarioModificar != null)
            {
                ucDatosUsuario1.llenarControles(UsuarioModificar.Name, UsuarioModificar.Password, UsuarioModificar.Email);
            }
        }
        #endregion
    }
}
