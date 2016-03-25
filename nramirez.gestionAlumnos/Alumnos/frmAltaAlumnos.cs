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
using gestionalumnos.Comun;
using nramirez36.Logger;
namespace nramirez.gestionAlumnos.Alumnos
{
    public partial class frmAltaAlumnos : Form
    {        
        #region Propiedades
        public bool ModoLectura { get; set; }
        public int Opcion { get; set; }
        public Alumno AlumnoModificar { get; set; }
        public Domicilio AlumnoDomicilio { get; set; }
        public int IdAlumno { get; set; }
        #endregion
        #region Variables
        private GestorAlumnos oGA = new GestorAlumnos();
        private GestorDomicilios oGD = new GestorDomicilios();
        private GestorTiposDocumentos oGTD = new GestorTiposDocumentos();
        private GestorBarrios oGB = new GestorBarrios();
        private GestorLocalidades oGL = new GestorLocalidades();
        private GestorProvincias oGP = new GestorProvincias();
        #endregion
        #region Constructor
        public frmAltaAlumnos()
        {
            InitializeComponent();
        }
        #endregion
        #region Metodos
        private void RecuperarDatos()
        {
            AlumnoModificar = new Alumno();
            AlumnoModificar = oGA.Buscar(IdAlumno);
            if (AlumnoModificar != null)
            {
                AlumnoModificar.alumnoID = IdAlumno;
                llenarControlesAlumnos(AlumnoModificar.apellidos, AlumnoModificar.email, AlumnoModificar.nacionalidad, AlumnoModificar.nombres, AlumnoModificar.nrodocumento, AlumnoModificar.fechanacimiento, AlumnoModificar.tipodocumentoID);
                if (AlumnoModificar.direccionID > 0)
                {
                    AlumnoDomicilio = oGD.Buscar(AlumnoModificar.direccionID);
                    llenarDomicilioAlumno();
                }
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
        public void habilitarControlesDomicilios()
        {
            if (ModoLectura)
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
        public void limpiarControlesDomicilios()
        {
            txtAltura.Text = "";
            txtCalle.Text = "";
            txtDepto.Text = "";
            txtPiso.Text = "";
            cmbBarrio.SelectedIndex = -1;
            cmbCiudad.SelectedIndex = -1;
            cmbProvincia.SelectedIndex = -1;

        }
        public void llenarControlesDomicilios(string pCalle, string pAltura, string pDepto, string pPiso, int pProvincia, int pCiudad, int pBarrio)
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
        public bool validarControlesDomicilios()
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
            AlumnoDomicilio = new Domicilio();
            AlumnoDomicilio.altura = txtAltura.Text;
            AlumnoDomicilio.barrio_id = int.Parse(cmbBarrio.SelectedValue.ToString());
            AlumnoDomicilio.calle = txtCalle.Text;
            AlumnoDomicilio.ciudad_id = int.Parse(cmbCiudad.SelectedValue.ToString());
            AlumnoDomicilio.depto = txtDepto.Text;
            AlumnoDomicilio.piso = txtPiso.Text;
            AlumnoDomicilio.provincia_id = int.Parse(cmbProvincia.SelectedValue.ToString());
            return true;
        }
        public void HabilitarControlesAlumnos()
        {
            //CONSULTA DE DATOS--->TRUE
            if (ModoLectura)
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
            }
        }
        public bool validarControlesAlumnos()
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


            if (!validarControlesDomicilios())
                return false;

            AlumnoModificar = new Alumno();
            AlumnoModificar.apellidos = txtApellido.Text;
            AlumnoModificar.edad = int.Parse(txtEdad.Text);
            AlumnoModificar.email = txtEmail.Text.Trim().ToString();
            AlumnoModificar.fechanacimiento = dtpFechaNacimiento.Value;
            AlumnoModificar.nacionalidad = txtNacionalidad.Text;
            AlumnoModificar.nombres = txtNombre.Text;
            AlumnoModificar.nrodocumento = int.Parse(txtNroDoc.Text);
            AlumnoModificar.telefonocelular = mskTelCel.Text;
            AlumnoModificar.telefonofijo = mskTelFijo.Text;
            AlumnoModificar.tipodocumentoID = int.Parse(cmbTipoDoc.SelectedValue.ToString());

            AlumnoDomicilio = new Domicilio();
            AlumnoDomicilio = AlumnoDomicilio;

            return true;
        }
        public void limpiarControlesAlumno()
        {
            txtApellido.Text = "";
            txtEdad.Text = "";
            txtEmail.Text = "";
            txtNacionalidad.Text = "";
            txtNombre.Text = "";
            txtNroDoc.Text = "";
            cmbTipoDoc.SelectedIndex = -1;
            limpiarControlesDomicilios();
        }
        public void llenarControlesAlumnos(string pApellido, string pEmail, string pNacionalidad, string pNombre, int pNroDoc, DateTime pFechaNac, int pCodTipoDoc)
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
        public void llenarDomicilioAlumno()
        {
            if (AlumnoDomicilio != null)
            {
                llenarControlesDomicilios(AlumnoDomicilio.calle, AlumnoDomicilio.altura, AlumnoDomicilio.depto, AlumnoDomicilio.piso, AlumnoDomicilio.provincia_id, AlumnoDomicilio.ciudad_id, AlumnoDomicilio.barrio_id);
            }
        }
        #endregion
        #region Eventos
        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            //if (ucDatosAlumnos1.validarControles())
            //{

            //}
            //if (validarControlesAlumnos())
            //{ }
        }
        private void frmAltaAlumnos_Load(object sender, EventArgs e)
        {
            cargarTipoDocumento();
            cargarProvincias();
            switch (Opcion)
            {
                case 1: this.Text = this.Text + " - Alta de Alumnos";
                    btnCancelar.Visible = true;
                    btnRegistrar.Text = "Registrar";
                    ModoLectura = false;
                    //ucDatosAlumnos1.ModoSoloLectura = false;
                    //ucDatosAlumnos1.Refresh();
                    break;
                case 2: this.Text = this.Text + " - Edicion de Alumnos";
                    btnCancelar.Visible = true;
                    btnRegistrar.Text = "Modificar";
                    ModoLectura = false;
                    //ucDatosAlumnos1.ModoSoloLectura = false;
                    //ucDatosAlumnos1.Refresh();
                    RecuperarDatos();
                    break;
                case 4: this.Text = this.Text + " - Baja de Alumnos";
                    btnCancelar.Visible = true;
                    btnRegistrar.Text = "Baja";
                    ModoLectura = true;
                    RecuperarDatos();
                    //ucDatosAlumnos1.ModoSoloLectura = true;
                    //ucDatosAlumnos1.Refresh();
                    break;
            }
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void cmbTipoDoc_DropDown(object sender, EventArgs e)
        {
            int pw = -1;
            Utiles.GetLargestTextExtent(this.cmbTipoDoc, ref pw);
            this.cmbTipoDoc.DropDownWidth = pw;
        }
        private void dtpFechaNacimiento_ValueChanged(object sender, EventArgs e)
        {
            int edad = Utiles.CalcularEdad(dtpFechaNacimiento.Value);
            txtEdad.Text = edad.ToString();
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
        private void cmbProvincia_MouseDown(object sender, MouseEventArgs e)
        {
            int pw = -1;
            Utiles.GetLargestTextExtent(this.cmbProvincia, ref pw);
            this.cmbProvincia.DropDownWidth = pw;
        }
        private void cmbCiudad_MouseDown(object sender, MouseEventArgs e)
        {
            int pw = -1;
            Utiles.GetLargestTextExtent(this.cmbCiudad, ref pw);
            this.cmbCiudad.DropDownWidth = pw;
        }
        private void cmbBarrio_MouseDown(object sender, MouseEventArgs e)
        {
            int pw = -1;
            Utiles.GetLargestTextExtent(this.cmbBarrio, ref pw);
            this.cmbBarrio.DropDownWidth = pw;
        }
        #endregion


        


        
    }
}
