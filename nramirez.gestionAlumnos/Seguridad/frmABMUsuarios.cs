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
                switch (Opcion)
                {
                    case 1: this.Text = this.Text + " - Alta de Usuario";
                        btnCancelar.Visible = true;
                        btnRegistrar.Text = "Registrar";
                        break;
                    case 2: this.Text = this.Text + " - Edicion de Usuario";
                        btnCancelar.Visible = true;
                        btnRegistrar.Text = "Modificar";
                        RecuperarDatos();
                        break;
                    case 4: this.Text = this.Text + " - Baja de Usuario";
                        btnCancelar.Visible = true;
                        btnRegistrar.Text = "Baja";
                        RecuperarDatos();
                        ucDatosUsuario1.ModoSoloLectura = true;
                        ucDatosUsuario1.Refresh();
                        break;
                }
                RegistrarControles();
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
                            oUser.UserID = IdUser;
                            if (oGU.Modificar(oUser))
                            {
                                MessageBox.Show("Se modifico al Usuario", "Modificar Usuarios", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                ucDatosUsuario1.limpiarControles();
                                this.Close();
                            }
                            else
                            {
                                MessageBox.Show("No se pudo dar modificar al Usuario", "Modificar Usuarios", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            break;
                        case (int)Utiles.OpcionesABM.BAJA:
                            oUser.UserID = IdUser;
                            oUser.FechaBaja = DateTime.Now;
                            if (oGU.Baja(oUser))
                            {
                                MessageBox.Show("Se dio de baja al Usuario", "Baja de Usuarios", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                ucDatosUsuario1.limpiarControles();
                                this.Close();
                            }
                            else
                            {
                                MessageBox.Show("No se pudo dar de baja al Usuario", "Baja de Usuarios", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            break;
                    }
                }
            }
            private void btnCancelar_Click(object sender, EventArgs e)
            {
                this.Close();
            }
        #endregion
        #region Metodos
            private void RecuperarDatos()
            {
                UsuarioModificar = new Users();
                UsuarioModificar = oGU.Buscar(IdUser);
                if (UsuarioModificar != null)
                {
                    UsuarioModificar.UserID = IdUser;
                    ucDatosUsuario1.llenarControles(UsuarioModificar.Name, UsuarioModificar.Password, UsuarioModificar.Email);
                }
            }
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
        #endregion
    }
}
