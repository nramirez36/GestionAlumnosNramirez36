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
using nramirez36.Logger;
using gestionalumnos.Comun;
namespace nramirez.gestionAlumnos.Alumnos
{
    public partial class ucDatosDomicilio : UserControl
    {
        #region Propiedades
        public bool ModoSoloLectura { get; set; }
        public Domicilio DomicilioAlumno { get; set; }
        #endregion
        #region Variables
        private GestorBarrios oGB = new GestorBarrios();
        private GestorLocalidades oGL = new GestorLocalidades();
        private GestorProvincias oGP = new GestorProvincias();
        #endregion
        #region Constructor
        public ucDatosDomicilio()
        {
            InitializeComponent();
            cargarProvincias();
        }
        #endregion
        #region Eventos
        private void ucDatosDomicilio_Load(object sender, EventArgs e)
        {
            habilitarControles();
        }
        private void ucDatosDomicilio_Paint(object sender, PaintEventArgs e)
        {
            habilitarControles();
        }
        #endregion
        #region Metodos
        public void habilitarControles()
        {
            if (ModoSoloLectura)
            {
                txtAltura.Enabled = false;
                txtCalle.Enabled = false;
                txtDepto.Enabled = false;
                txtPiso.Enabled = false;
                cmbBarrio.Enabled = false;
                cmbCiudad.Enabled = false;
                cmbProvincia.Enabled = false;
                txtAltura.BackColor = SystemColors.Info;
                txtCalle.BackColor = SystemColors.Info;
                txtDepto.BackColor = SystemColors.Info;
                txtPiso.BackColor = SystemColors.Info;
                cmbBarrio.BackColor = SystemColors.Info;
                cmbCiudad.BackColor = SystemColors.Info;
                cmbProvincia.BackColor = SystemColors.Info;
            }
            else
            {
                txtAltura.Enabled = true;
                txtCalle.Enabled = true;
                txtDepto.Enabled = true;
                txtPiso.Enabled = true;
                cmbBarrio.Enabled = true;
                cmbCiudad.Enabled = true;
                cmbProvincia.Enabled = true;
                txtAltura.BackColor = SystemColors.Window;
                txtCalle.BackColor = SystemColors.Window;
                txtDepto.BackColor = SystemColors.Window;
                txtPiso.BackColor = SystemColors.Window;
                cmbBarrio.BackColor = SystemColors.Window;
                cmbCiudad.BackColor = SystemColors.Window;
                cmbProvincia.BackColor = SystemColors.Window;
            }

        }
        public void limpiarControles()
        {
            txtAltura.Text = "";
            txtCalle.Text = "";
            txtDepto.Text = "";
            txtPiso.Text = "";
            cmbBarrio.SelectedIndex = -1;
            cmbCiudad.SelectedIndex = -1;
            cmbProvincia.SelectedIndex = -1;

        }
        public void llenarControles(string pCalle, string pAltura, string pDepto, string pPiso, int pProvincia, int pCiudad, int pBarrio)
        {
            if (!string.IsNullOrEmpty(pAltura))
                txtAltura.Text = pAltura.ToString();
            if (!string.IsNullOrEmpty(pCalle))
                txtCalle.Text = pCalle;
            if (!string.IsNullOrEmpty(pDepto))
                txtDepto.Text = pDepto;
            if (!string.IsNullOrEmpty(pDepto))
                txtPiso.Text = pPiso;
            cmbBarrio.SelectedValue = pBarrio;
            cmbCiudad.SelectedValue = pCiudad;
            cmbProvincia.SelectedValue = pProvincia;
        }
        public bool validarControles()
        {
            bool res = false;
            string msg = "";
            if (txtAltura.Text == null || txtAltura.Text.Equals(""))
            {
                MessageBox.Show("Debe ingresar la Altura", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (txtCalle.Text == null || txtCalle.Text.Equals(""))
            {
                MessageBox.Show("Debe ingresar la Calle", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (cmbProvincia.SelectedValue == null || int.Parse(cmbProvincia.SelectedValue.ToString()) < 1)
            {
                MessageBox.Show("Debe seleccionar la Provincia", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (cmbCiudad.SelectedValue == null || int.Parse(cmbCiudad.SelectedValue.ToString()) < 1)
            {
                MessageBox.Show("Debe seleccionar la Ciudad", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (cmbBarrio.SelectedValue == null || int.Parse(cmbBarrio.SelectedValue.ToString()) < 1)
            {
                MessageBox.Show("Debe seleccionar el Barrio", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            DomicilioAlumno = new Domicilio();
            DomicilioAlumno.altura = txtAltura.Text;
            DomicilioAlumno.barrio_id = int.Parse(cmbBarrio.SelectedValue.ToString());
            DomicilioAlumno.calle = txtCalle.Text;
            DomicilioAlumno.ciudad_id = int.Parse(cmbCiudad.SelectedValue.ToString());
            DomicilioAlumno.depto = txtDepto.Text;
            DomicilioAlumno.piso = txtPiso.Text;
            DomicilioAlumno.provincia_id = int.Parse(cmbProvincia.SelectedValue.ToString());
            return true;
        }
        #endregion
        public void cargarProvincias()
        {
            try
            {
                cmbProvincia.DataSource = oGP.Listar().ToList();
                cmbProvincia.DisplayMember = "nombre";
                cmbProvincia.ValueMember = "id";
                if (cmbProvincia.Items.Count != 0)
                {
                    int pCodProvincia = Convert.ToInt32(cmbProvincia.SelectedValue);
                    cargarLocalidades(pCodProvincia);
                }
                else
                {
                    cmbProvincia.DataSource = null;
                }
            }
            catch (Exception ex)
            {
                Logger.WriteXMLError("ucDatosDomicilio", "ucDatosDomicilio", "cargarProvincias", ex.Message);
            }
        }
        public void cargarLocalidades(int pCodProvincia)
        {
            try
            {
                cmbCiudad.DataSource = oGL.Listar(pCodProvincia).ToList();
                cmbCiudad.DisplayMember = "nombre";
                cmbCiudad.ValueMember = "localidad_id";
                if (cmbCiudad.Items.Count != 0)
                {
                    int pCodCiudad = Convert.ToInt32(cmbCiudad.SelectedValue);
                    cargarBarrios(pCodCiudad);
                }
                else
                {
                    cmbCiudad.DataSource = null;
                }

            }
            catch (Exception ex)
            {
                Logger.WriteXMLError("ucDatosDomicilio", "ucDatosDomicilio", "cargarLocalidades", ex.Message);
            }
        }
        public void cargarBarrios(int pCodCiudad)
        {
            try
            {
                cmbBarrio.DataSource = oGB.Listar(pCodCiudad).ToList();
                cmbBarrio.DisplayMember = "nombre";
                cmbBarrio.ValueMember = "id";
                if (cmbBarrio.Items.Count == 0)
                    cmbBarrio.DataSource = null;

            }
            catch (Exception ex)
            {
                Logger.WriteXMLError("ucDatosDomicilio", "ucDatosDomicilio", "cargarBarrios", ex.Message);
            }
        }

        private void cmbProvincia_SelectionChangeCommitted(object sender, EventArgs e)
        {
            int pCodProvincia = Convert.ToInt32(cmbProvincia.SelectedValue);
            cargarLocalidades(pCodProvincia);
        }

        private void cmbCiudad_SelectionChangeCommitted(object sender, EventArgs e)
        {
            int pCodLocalidad = Convert.ToInt32(cmbCiudad.SelectedValue);
            cargarBarrios(pCodLocalidad);
        }

        private void cmbProvincia_DropDown(object sender, EventArgs e)
        {
            int pw = -1;
            Utiles.GetLargestTextExtent(this.cmbProvincia, ref pw);
            this.cmbProvincia.DropDownWidth = pw;
        }

        private void cmbCiudad_DropDown(object sender, EventArgs e)
        {
            int pw = -1;
            Utiles.GetLargestTextExtent(this.cmbCiudad, ref pw);
            this.cmbCiudad.DropDownWidth = pw;
        }

        private void cmbBarrio_DropDown(object sender, EventArgs e)
        {
            int pw = -1;
            Utiles.GetLargestTextExtent(this.cmbBarrio, ref pw);
            this.cmbBarrio.DropDownWidth = pw;
        }

    }
}
