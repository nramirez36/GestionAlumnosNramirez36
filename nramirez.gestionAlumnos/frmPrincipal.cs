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
using gestionalumnos.Entities;
using nramirez.gestionAlumnos.Seguridad;
namespace nramirez.gestionAlumnos
{
    public partial class frmPrincipal : Form
    {
        #region Propiedades
        public int UsuarioID { get; set; }
        GestorUsers oGU = new GestorUsers();
        public Users UsuarioConectado { get; set; }
        #endregion
        #region Variables

        #endregion
        #region Constructor
        public frmPrincipal()
        {
            InitializeComponent();
        }
        #endregion
        #region Eventos
        private void frmPrincipal_Load(object sender, EventArgs e)
        {
            LoadDatos();
            RegistrarControles();
            //ACA DEBERIA VER EL TEMA DE LOS ROLES
            CargarControles();

        }
        #region Archivo
        private void cerrarSesionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmLogin frm = new frmLogin();
            frm.txtPassword.Text = "";
            frm.txtUsuario.Text = "";
            this.Hide();
            frm.Show();
        }
        #endregion
        #region Alumnos
        private void nuevoToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        private void modificarToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        private void eliminarToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        private void buscarToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        #endregion
        #region Materias
        private void nuevoToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }
        private void modificarToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }
        private void eliminarToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }
        private void buscarToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }
        #endregion
        #region Curso
        private void nuevoToolStripMenuItem2_Click(object sender, EventArgs e)
        {

        }

        private void modificarToolStripMenuItem2_Click(object sender, EventArgs e)
        {

        }

        private void eliminarToolStripMenuItem2_Click(object sender, EventArgs e)
        {

        }

        private void buscarToolStripMenuItem2_Click(object sender, EventArgs e)
        {

        }
        #endregion
        #region Reportes

        #endregion
        #region Seguridad
        private void usuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmUsuario frm = new frmUsuario();
            //frm.MdiParent = this;
            frm.Show();
        }
        private void permisosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmGestionPermisos frm = new frmGestionPermisos();
            frm.Show();
        }
        private void rolesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmGestionRoles frm = new frmGestionRoles();
            frm.Show();
        }
        #endregion
        #region Ayuda
        private void acercaToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        #endregion

        private void frmPrincipal_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            tSSLFecha.Text = DateTime.Now.ToString();
            timer1.Start();
        }
        #endregion
        #region Metodos
        public void LoadDatos()
        {
            //Users oGU.Buscar(UsuarioID);
            //Users oUser = oGU.Buscar(UsuarioID);
            this.Text = this.Text + " - " + UsuarioConectado.Name;
            tSSLUsuario.Text = UsuarioConectado.Name;

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
        private void CargarControles()
        {
            UsuarioConectado = oGU.Buscar(UsuarioID);
            GestorRoles oGR = new GestorRoles();
            Roles oRol = null;
            UsersToRoles oUserRoles = null;
            Controls oControls = null;
            GestorUsersToRoles oGUR = new GestorUsersToRoles();
            GestorControles oGC = new GestorControles();
            List<gestionalumnos.Entities.Roles> listaRoles = null;
            if (UsuarioConectado != null)
            {
                oUserRoles = new UsersToRoles();
                oUserRoles.FKUserID = UsuarioID;
                listaRoles = oGUR.Buscar(oUserRoles).ToList();
                oControls = new gestionalumnos.Entities.Controls();
                oControls.Page = this.Name;
                List<Controls> listaControles = oGC.ListarPorPagina(oControls).ToList();
                if (listaControles.Count>0)
                {
                    for (int i = 0; i < listaControles.Count-1; i++)
                    {
                        HabilitarControles(listaRoles[i].RoleID, listaControles);      
                    }
                }
                //HabilitarControles(listaRoles[0].RoleID, listaControles);
                Console.Write("asdas");


            }

        }
        private void HabilitarControles(int idRol, List<Controls> lstCtrl)
        {

            GestorControlsToRole oGCR = new GestorControlsToRole();
            List<ControlsToRoles> list = new List<ControlsToRoles>();
            List<ControlsToRoles> listaux = new List<ControlsToRoles>();
            ControlsToRoles c = new ControlsToRoles();
            c.FKRole = idRol;
            ControlsToRoles aux = new ControlsToRoles();

            for (int i = 0; i < lstCtrl.Count; i++)
            {
                c.FKControlID = lstCtrl[i].ControlID;
                c.FKPage = this.Name;
                listaux = oGCR.Habilitar(c).ToList();
                foreach (ControlsToRoles item in listaux)
                {
                    list.Add(item);
                }
            }
            //list=oGCR.Habilitar(

            foreach (Control controlChotex in this.Controls)
            {
                foreach (ControlsToRoles item in list)
                {
                    if (item.FKControlID == controlChotex.Name)
                    {
                        if (item.Invisible == 1)
                        {
                            controlChotex.Visible = false;
                        }
                        else
                        {
                            controlChotex.Visible = true;
                        }
                        if (item.Disabled==1)
                        {
                            controlChotex.Enabled = false;
                        }
                        else
                        {
                            controlChotex.Enabled = true;
                        }
                    }
                }
            }
        }
        #endregion
    }
}
