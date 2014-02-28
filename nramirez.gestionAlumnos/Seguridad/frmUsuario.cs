using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace nramirez.gestionAlumnos.Seguridad
{
    public partial class frmUsuario : Form
    {
        #region Variables
        frmABMUsuarios frmABM;
        frmConsultaUsuarios frmCons;
        #endregion
        #region Propiedades

        #endregion
        #region Constructor

        #endregion
        #region Eventos

        #endregion
        #region Metodos

        #endregion
        public frmUsuario()
        {
            InitializeComponent();
        }

        private void consultarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCons = new frmConsultaUsuarios();
            frmCons.MdiParent = this;
            frmCons.ModoLectura = true;
            frmCons.Opcion = (int)Utiles.OpcionesABM.CONSULTA;
            frmCons.Show();
        }

        private void nuevoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmABM = new frmABMUsuarios();
            frmABM.MdiParent = this;
            frmABM.ModoLectura = false;
            frmABM.Opcion = (int)Utiles.OpcionesABM.ALTA;
            frmABM.Show();
        }

        private void modificarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCons = new frmConsultaUsuarios();
            frmCons.MdiParent = this;
            frmCons.ModoLectura = true;
            frmCons.Opcion = (int)Utiles.OpcionesABM.MODIFICACION;
            frmCons.Show();
        }

        private void darDeBajaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCons = new frmConsultaUsuarios();
            frmCons.MdiParent = this;
            frmCons.ModoLectura = false;
            frmCons.Opcion = (int)Utiles.OpcionesABM.BAJA;
            frmCons.Show();
        }
    }
}
