using gestionalumnos.BL;
using gestionalumnos.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using gestionalumnos.Comun;
namespace nramirez.gestionAlumnos.Seguridad
{
    public partial class frmGestionRoles : Form
    {
        #region Variables
        frmABMRoles frmABM;
        frmConsultaRoles frmCons;
        #endregion
        #region Propiedades

        #endregion
        #region Constructor
        public frmGestionRoles()
        {
            InitializeComponent();
        }
        #endregion
        #region Eventos
        private void nuevoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmABM = new frmABMRoles();
            frmABM.MdiParent = this;
            frmABM.ModoLectura = false;
            frmABM.Opcion = (int)Utiles.OpcionesABM.ALTA;
            frmABM.Show();
        }
        private void modificarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCons = new frmConsultaRoles();
            frmCons.MdiParent = this;
            frmCons.ModoLectura = true;
            frmCons.Opcion = (int)Utiles.OpcionesABM.MODIFICACION;
            frmCons.Show();
        }
        private void consultarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCons = new frmConsultaRoles();
            frmCons.MdiParent = this;
            frmCons.ModoLectura = true;
            frmCons.Opcion = (int)Utiles.OpcionesABM.CONSULTA;
            frmCons.Show();
        }
        private void darDeBajaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCons = new frmConsultaRoles();
            frmCons.MdiParent = this;
            frmCons.ModoLectura = true;
            frmCons.Opcion = (int)Utiles.OpcionesABM.BAJA;
            frmCons.Show();
        }
        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void frmGestionRoles_Load(object sender, EventArgs e)
        {

            this.BackgroundImage = new Bitmap("C:\\Users\\Nicolas\\Documents\\Visual Studio 2012\\Projects\\nramirez36 - Proyectos\\nramirez.gestionAlumnos\\nramirez.gestionAlumnos\\Retro.png");
            RegistrarControles();
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

        #endregion


    }
}
