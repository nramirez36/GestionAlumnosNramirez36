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
        #endregion
        #region Constructor
        public frmAltaAlumnos()
        {
            InitializeComponent();
        }
        #endregion
        #region Eventos
        private void RecuperarDatos()
        {
            AlumnoModificar = new Alumno();
            AlumnoModificar = oGA.Buscar(IdAlumno);
            if (AlumnoModificar != null)
            {
                AlumnoModificar.alumnoID = IdAlumno;
                //ucDatosAlumnos1.llenarControles(AlumnoModificar.apellidos, AlumnoModificar.email, AlumnoModificar.nacionalidad, AlumnoModificar.nombres, AlumnoModificar.nrodocumento, AlumnoModificar.fechanacimiento, AlumnoModificar.tipodocumentoID);
                if (AlumnoModificar.direccionID > 0)
                {
                    AlumnoDomicilio = oGD.Buscar(AlumnoModificar.direccionID);
                  //  ucDatosAlumnos1.AlumnoDomicilio = AlumnoDomicilio;
                    //ucDatosAlumnos1.llenarDomicilio();
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
        #endregion
        #region Metodos
        
        #endregion
        

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            //if (ucDatosAlumnos1.validarControles())
            //{
                
            //}
        }

        private void frmAltaAlumnos_Load(object sender, EventArgs e)
        {
            switch (Opcion)
            {
                case 1: this.Text = this.Text + " - Alta de Alumnos";
                    btnCancelar.Visible = true;
                    btnRegistrar.Text = "Registrar";
                    //ucDatosAlumnos1.ModoSoloLectura = false;
                    //ucDatosAlumnos1.Refresh();
                    break;
                case 2: this.Text = this.Text + " - Edicion de Alumnos";
                    btnCancelar.Visible = true;
                    btnRegistrar.Text = "Modificar";
                    //ucDatosAlumnos1.ModoSoloLectura = false;
                    //ucDatosAlumnos1.Refresh();
                    RecuperarDatos();
                    break;
                case 4: this.Text = this.Text + " - Baja de Alumnos";
                    btnCancelar.Visible = true;
                    btnRegistrar.Text = "Baja";
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
    }
}
