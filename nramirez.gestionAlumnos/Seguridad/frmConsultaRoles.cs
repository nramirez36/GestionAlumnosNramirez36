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
using gestionalumnos.Comun;
namespace nramirez.gestionAlumnos.Seguridad
{
    public partial class frmConsultaRoles : Form
    {
        #region Variables
        GestorRoles oGR = new GestorRoles();
        List<Roles> lista = new List<Roles>();
        frmABMRoles frmABM;
        private int filaSeleccionada = -1;
        #endregion
        #region Propiedades
        public bool ModoLectura { get; set; }
        public int Opcion { get; set; }
        #endregion
        #region Constructor
        public frmConsultaRoles()
        {
            InitializeComponent();
        }
        #endregion
        #region Eventos
        private void frmConsultaRoles_Load(object sender, EventArgs e)
        {
            CargarOpcion();
            LoadGrilla();
            RegistrarControles();
        }
        private void btnAgregarRol_Click(object sender, EventArgs e)
        {
            frmABM = new frmABMRoles();
            frmABM.Opcion = (int)Utiles.OpcionesABM.ALTA;
            frmABM.ModoLectura = false;
            frmABM.Show();
            LoadGrilla();
        }
        private void txtRol_TextChanged(object sender, EventArgs e)
        {
            string rolname = txtRol.Text.Trim();
            var usuarios = lista.Where(a => a.RoleName.Contains(rolname));
            //Equals(username));
            dgvRoles.DataSource = usuarios.ToList();
        }
        private void btnConsultar_Click(object sender, EventArgs e)
        {
            if (Opcion == (int)Utiles.OpcionesABM.MODIFICACION)
            {
                ModificarDatos();
            }
            if (Opcion == (int)Utiles.OpcionesABM.BAJA)
            {
                BajaDatos();
            }
        }
        private void dgvRoles_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            dgvRoles.Rows[e.RowIndex].Selected = true;
            filaSeleccionada = (int)dgvRoles.Rows[e.RowIndex].Cells[0].Value;
        }
        private void dgvRoles_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (Opcion == (int)Utiles.OpcionesABM.MODIFICACION)
            {
                ModificarDatos();
            }
            if (Opcion == (int)Utiles.OpcionesABM.BAJA)
            {
                BajaDatos();
            }
        }
        #endregion
        #region Metodos
        private void CargarOpcion()
        {
            if (ModoLectura)
            {
                this.Text = this.Text + " - Consulta de Roles";
                btnCancelar.Visible = false;
                btnConsultar.Text = "Aceptar";
            }
            else
            {
                switch (Opcion)
                {
                    case 1: this.Text = this.Text + " - Alta de Roles";
                        btnCancelar.Visible = true;
                        btnConsultar.Text = "Registrar";
                        break;
                    case 2: this.Text = this.Text + " - Edicion de Roles";
                        btnCancelar.Visible = true;
                        btnConsultar.Text = "Modificar";
                        break;
                    case 4: this.Text = this.Text + " - Baja de Roles";
                        btnCancelar.Visible = true;
                        btnConsultar.Text = "Eliminar";
                        btnAgregarRol.Visible = false;
                        break;
                }

            }
        }
        private void LoadGrilla()
        {
            try
            {
                List<Roles> lst = oGR.Listar().ToList();
                dgvRoles.DataSource = lst;
                dgvRoles.Columns["FechaBaja"].Visible = false;
                lista = lst;
            }
            catch (Exception ex)
            {
                Logger.WriteXMLError("frmConsultaRoles", "frmConsultaRoles", "LoadGrilla", ex.Message);
                throw;
            }
        }
        private void ModificarDatos()
        {
            if (filaSeleccionada != -1)
            {
                frmABM = new frmABMRoles();
                frmABM.Opcion = (int)Utiles.OpcionesABM.MODIFICACION;
                frmABM.ModoLectura = false;
                frmABM.IdRol = filaSeleccionada;
                frmABM.ShowDialog();
                LoadGrilla();
            }
            else
            {
                MessageBox.Show("No selecciono Rol", "Modificar Datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void BajaDatos()
        {
            if (filaSeleccionada != -1)
            {
                frmABM = new frmABMRoles();
                frmABM.Opcion = (int)Utiles.OpcionesABM.BAJA;
                frmABM.ModoLectura = true;
                frmABM.IdRol = filaSeleccionada;
                frmABM.ShowDialog();
                LoadGrilla();
            }
            else
            {
                MessageBox.Show("No selecciono Rol", "Baja de Roles", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
