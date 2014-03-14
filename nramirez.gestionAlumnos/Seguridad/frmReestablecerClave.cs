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

namespace nramirez.gestionAlumnos.Usuarios
{
    public partial class frmReestablecerClave : Form
    {
        #region Variables

        #endregion
        #region Propiedades

        #endregion
        #region Constructor
        public frmReestablecerClave()
        {
            InitializeComponent();
        }
        #endregion
        #region Eventos
        private void frmReestablecerClave_Load(object sender, EventArgs e)
        {
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
