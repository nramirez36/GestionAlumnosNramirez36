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

namespace nramirez.gestionAlumnos.Seguridad
{
    public partial class ucDatosRoles : UserControl
    {
        #region Variables

        #endregion
        #region Propieadades
        public Roles Rol { get; set; }
        public bool ModoSoloLectura { get; set; }
        #endregion
        #region Constructor
        public ucDatosRoles()
        {
            InitializeComponent();
        }
        #endregion
        #region Eventos
        private void ucDatosRoles_Load(object sender, EventArgs e)
        {
            HabilitarControles();
            RegistrarControles();
        }
        private void ucDatosRoles_Paint(object sender, PaintEventArgs e)
        {
            HabilitarControles();
        }
        #endregion
        #region Metodos
        public void HabilitarControles()
        {
            //CONSULTA DE DATOS--->TRUE
            if (ModoSoloLectura)
            {
                txtRol.Enabled = false;
                txtRol.BackColor = SystemColors.Info;
            }
            else
            {
                txtRol.Enabled = true;
                txtRol.BackColor = SystemColors.Window;
            }
        }
        public bool validarControles()
        {
            bool res = false;
            string msg = "";
            if (txtRol.Text == null || txtRol.Text.Equals(""))
            {
                MessageBox.Show("Debe ingresar el Rol", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            Rol = new Roles();
            Rol.RoleName = txtRol.Text;
            return true;
        }
        public void limpiarControles()
        {
            txtRol.Text = "";
        }
        public void llenarControles(string pRol)
        {
            txtRol.Text = pRol;
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
