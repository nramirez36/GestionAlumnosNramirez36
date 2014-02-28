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
using nramirez36.Logger;
using gestionalumnos.Entities;
namespace nramirez.gestionAlumnos.Seguridad
{
    public partial class frmConsultaUsuarios : Form
    {
        #region Variables
        GestorUsers oGU = new GestorUsers();
        List<Users> lista = new List<Users>();
        frmABMUsuarios frmABM;
        #endregion
        #region Propiedades
        public bool ModoLectura { get; set; }
        public int Opcion { get; set; }
        #endregion
        #region Constructor
        public frmConsultaUsuarios()
        {
            InitializeComponent();
        }
        #endregion
        #region Eventos

        #endregion
        #region Metodos
        private void CargarOpcion()
        {
            if (ModoLectura)
            {
                this.Text = this.Text + " - Consulta de Usuarios";
                btnCancelar.Visible = false;
                btnConsultar.Text = "Aceptar";
            }
            else
            {
                switch (Opcion)
                {
                    case 1: this.Text = this.Text + " - Alta de Usuario";
                        btnCancelar.Visible = true;
                        btnConsultar.Text = "Registrar";
                        break;
                    case 2: this.Text = this.Text + " - Edicion de Usuario";
                        btnCancelar.Visible = true;
                        btnConsultar.Text = "Modificar";
                        break;
                    case 4: this.Text = this.Text + " - Baja de Usuario";
                        btnCancelar.Visible = true;
                        btnConsultar.Text = "Eliminar";
                        btnAgregarUsuario.Visible = false;
                        break;
                }

            }
        }
        private void LoadGrilla()
        {
            try
            {
                List<Users> lst = oGU.Listar().ToList();
                dgvUsuarios.DataSource = lst;
                dgvUsuarios.Columns["FechaBaja"].Visible = false;
                dgvUsuarios.Columns["Password"].Visible = false;
                lista = lst;
            }
            catch (Exception ex)
            {
                Logger.WriteXMLError("frmConsultaUsuarios", "frmConsultaUsuarios", "LoadGrilla", ex.Message);
                throw;
            }
        }
        #endregion



        private void frmConsultaUsuarios_Load(object sender, EventArgs e)
        {
            CargarOpcion();
            LoadGrilla();
        }

        private void btnAgregarUsuario_Click(object sender, EventArgs e)
        {
            frmABM = new frmABMUsuarios();
            frmABM.Opcion = (int)Utiles.OpcionesABM.ALTA;
            frmABM.ModoLectura = false;
            frmABM.Show();
            LoadGrilla();
        }



        private void txtUserName_TextChanged(object sender, EventArgs e)
        {
            string username = txtUserName.Text.Trim();
            var usuarios = lista.Where(a => a.Name.Contains(username));
            //Equals(username));
            dgvUsuarios.DataSource = usuarios.ToList();
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            if (Opcion == (int)Utiles.OpcionesABM.MODIFICACION)
            {
                ModificarDatos();
                //frmABM = new frmABMUsuarios();
                //frmABM.Opcion = (int)Utiles.OpcionesABM.MODIFICACION;
                //frmABM.ModoLectura = false;
                //frmABM.UsuarioModificar = new Users();

                //frmABM.UsuarioModificar.UserID = filaSeleccionada;
                //frmABM.Show();
                //LoadGrilla();
            }
        }

        private void ModificarDatos()
        {
            if (filaSeleccionada != -1)
            {
                frmABM = new frmABMUsuarios();
                frmABM.Opcion = (int)Utiles.OpcionesABM.MODIFICACION;
                frmABM.ModoLectura = false;
                frmABM.IdUser = filaSeleccionada;
                frmABM.Show();
                LoadGrilla();
            }
            else
            {
                MessageBox.Show("No selecciono usuario", "Modificar Datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private int filaSeleccionada = -1;
        private void dgvUsuarios_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            dgvUsuarios.Rows[e.RowIndex].Selected = true;
            filaSeleccionada = (int)dgvUsuarios.Rows[e.RowIndex].Cells[0].Value;
        }

        private void dgvUsuarios_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (Opcion == (int)Utiles.OpcionesABM.MODIFICACION)
            {
                ModificarDatos();
                //frmABM = new frmABMUsuarios();
                //frmABM.Opcion = (int)Utiles.OpcionesABM.MODIFICACION;
                //frmABM.ModoLectura = false;
                //frmABM.UsuarioModificar = new Users();

                //frmABM.UsuarioModificar.UserID = filaSeleccionada;
                //frmABM.Show();
                //LoadGrilla();
            }
        }
    }
}
