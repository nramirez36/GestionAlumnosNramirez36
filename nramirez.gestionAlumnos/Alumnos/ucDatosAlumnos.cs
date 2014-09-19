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
namespace nramirez.gestionAlumnos.Alumnos
{
    public partial class ucDatosAlumnos : UserControl
    {
        #region Propiedades
        public Alumno AlumnoDatos { get; set; }
        public Domicilio AlumnoDomicilio { get; set; }
        public bool ModoSoloLectura { get; set; }
        #endregion
        #region Variables
        private GestorTiposDocumentos oGTD = new GestorTiposDocumentos();
        #endregion
        #region Constructor
        public ucDatosAlumnos()
        {
            InitializeComponent();
        }
        #endregion
        #region Eventos
        private void ucDatosAlumnos_Load(object sender, EventArgs e)
        {
            HabilitarControles();
            cargarTipoDocumento();
        }
        private void ucDatosAlumnos_Paint(object sender, PaintEventArgs e)
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
                txtApellido.Enabled = false;
                txtApellido.BackColor = SystemColors.Info;
                txtEdad.Enabled = false;
                txtEdad.BackColor = SystemColors.Info;
                txtEmail.Enabled = false;
                txtEmail.BackColor = SystemColors.Info;
                txtNacionalidad.Enabled = false;
                txtNacionalidad.BackColor = SystemColors.Info;
                txtNombre.Enabled = false;
                txtNombre.BackColor = SystemColors.Info;
                txtNroDoc.Enabled = false;
                txtNroDoc.BackColor = SystemColors.Info;
                cmbTipoDoc.Enabled = false;
                cmbTipoDoc.BackColor = SystemColors.Info;
                dtpFechaNacimiento.Enabled = false;
                ucDatosDom = new ucDatosDomicilio();
                ucDatosDom.ModoSoloLectura = true;
                ucDatosDom.Refresh();
            }
            else
            {
                txtApellido.Enabled = true;
                txtApellido.BackColor = SystemColors.Window;
                txtEdad.Enabled = false;
                txtEdad.BackColor = SystemColors.Info;
                txtEmail.Enabled = true;
                txtEmail.BackColor = SystemColors.Window;
                txtNacionalidad.Enabled = true;
                txtNacionalidad.BackColor = SystemColors.Window;
                txtNombre.Enabled = true;
                txtNombre.BackColor = SystemColors.Window;
                txtNroDoc.Enabled = true;
                txtNroDoc.BackColor = SystemColors.Window;
                cmbTipoDoc.Enabled = true;
                cmbTipoDoc.BackColor = SystemColors.Window;
                dtpFechaNacimiento.Enabled = true;
                ucDatosDom = new ucDatosDomicilio();
                ucDatosDom.ModoSoloLectura = false;
                ucDatosDom.Refresh();
            }
        }
        public bool validarControles()
        {
            bool res = false;
            string msg = "";
            if (txtApellido.Text == null || txtApellido.Text.Equals(""))
            {
                MessageBox.Show("Debe ingresar el Apellido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (txtNombre.Text == null || txtNombre.Text.Equals(""))
            {
                MessageBox.Show("Debe ingresar el Nombre", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (txtEmail.Text == null || txtEmail.Text.Equals(""))
            {
                MessageBox.Show("Debe ingresar un Email", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (txtNacionalidad.Text == null || txtNacionalidad.Text.Equals(""))
            {
                MessageBox.Show("Debe ingresar la Nacionalidad", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (cmbTipoDoc.SelectedValue == null || int.Parse(cmbTipoDoc.SelectedValue.ToString()) < 1)
            {
                MessageBox.Show("Debe seleccionar el Tipo de Documento", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (dtpFechaNacimiento.Value == null || dtpFechaNacimiento.Value > DateTime.MinValue)
            {
                MessageBox.Show("Debe seleccionar la Fecha de Nacimiento", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (txtNroDoc.Text == null || txtNroDoc.Text.Equals(""))
            {
                MessageBox.Show("Debe ingresar el Nro. de Documento", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (!mskTelCel.MaskFull)
            {
                MessageBox.Show("Debe ingresar el Nro. de Telefono Celular", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (!mskTelFijo.MaskFull)
            {
                MessageBox.Show("Debe ingresar el Nro. de Telefono Fijo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }


            if (!ucDatosDom.validarControles())
                return false;

            AlumnoDatos = new Alumno();
            AlumnoDatos.apellidos = txtApellido.Text;
            AlumnoDatos.edad = int.Parse(txtEdad.Text);
            AlumnoDatos.email = txtEmail.Text.Trim().ToString();
            AlumnoDatos.fechanacimiento = dtpFechaNacimiento.Value;
            AlumnoDatos.nacionalidad = txtNacionalidad.Text;
            AlumnoDatos.nombres = txtNombre.Text;
            AlumnoDatos.nrodocumento = int.Parse(txtNroDoc.Text);
            AlumnoDatos.telefonocelular = mskTelCel.Text;
            AlumnoDatos.telefonofijo = mskTelFijo.Text;
            AlumnoDatos.tipodocumentoID = int.Parse(cmbTipoDoc.SelectedValue.ToString());

            AlumnoDomicilio = new Domicilio();
            AlumnoDomicilio = ucDatosDom.DomicilioAlumno;

            return true;
        }
        public void limpiarControles()
        {
            txtApellido.Text = "";
            txtEdad.Text = "";
            txtEmail.Text = "";
            txtNacionalidad.Text = "";
            txtNombre.Text = "";
            txtNroDoc.Text = "";
            cmbTipoDoc.SelectedIndex = -1;
            ucDatosDom.limpiarControles();
        }
        public void llenarControles(string pApellido, string pEmail, string pNacionalidad, string pNombre, int pNroDoc, DateTime pFechaNac, int pCodTipoDoc)
        {
            if (!string.IsNullOrEmpty(pApellido))
                txtApellido.Text = pApellido;
            if (!string.IsNullOrEmpty(pEmail))
                txtEmail.Text = pEmail;
            if (!string.IsNullOrEmpty(pNacionalidad))
                txtNacionalidad.Text = pNacionalidad;
            if (!string.IsNullOrEmpty(pNombre))
                txtNombre.Text = pNombre;
            if (pNroDoc > 0)
                txtNroDoc.Text = pNroDoc.ToString();
            if (pFechaNac != null && (pFechaNac > DateTime.MinValue && pFechaNac < DateTime.MaxValue))
                dtpFechaNacimiento.Value = pFechaNac;
            if (pCodTipoDoc > 0)
                cmbTipoDoc.SelectedValue = pCodTipoDoc;

            int edad = Utiles.CalcularEdad(pFechaNac);
            txtEdad.Text = edad.ToString();
        }
        public void llenarDomicilio()
        {
            if (AlumnoDomicilio != null)
            {
                ucDatosDom.llenarControles(AlumnoDomicilio.calle, AlumnoDomicilio.altura, AlumnoDomicilio.depto, AlumnoDomicilio.piso, AlumnoDomicilio.provincia_id, AlumnoDomicilio.ciudad_id, AlumnoDomicilio.barrio_id);
            }
        }
        public void cargarTipoDocumento()
        {
            try
            {
                cmbTipoDoc.DataSource = oGTD.Listar().ToList();
                cmbTipoDoc.DisplayMember = "Descripcion";
                cmbTipoDoc.ValueMember = "TipoDocumentoID";
            }
            catch (Exception ex)
            {
                
                throw;
            }
        }
        #endregion

        private void dtpFechaNacimiento_ValueChanged(object sender, EventArgs e)
        {
            int edad = Utiles.CalcularEdad(dtpFechaNacimiento.Value);
            txtEdad.Text = edad.ToString();
        }

        private void cmbTipoDoc_DropDown(object sender, EventArgs e)
        {
            int pw = -1;
            Utiles.GetLargestTextExtent(this.cmbTipoDoc, ref pw);
            this.cmbTipoDoc.DropDownWidth = pw;
        }
    }
}
