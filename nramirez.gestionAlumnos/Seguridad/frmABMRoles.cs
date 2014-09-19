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
namespace nramirez.gestionAlumnos.Seguridad
{
    public partial class frmABMRoles : Form
    {
        #region Variables
        private GestorRoles oGR = new GestorRoles();
        #endregion
        #region Propiedades
        public bool ModoLectura { get; set; }
        public int Opcion { get; set; }
        public Roles RolModificar { get; set; }
        public int IdRol { get; set; }
        #endregion
        #region Constructor
        public frmABMRoles()
        {
            InitializeComponent();
        }
        #endregion
        #region Eventos
        private void frmABMRoles_Load(object sender, EventArgs e)
        {
            switch (Opcion)
            {
                case 1: this.Text = this.Text + " - Alta de Roles";
                    btnCancelar.Visible = true;
                    btnRegistrar.Text = "Registrar";
                    break;
                case 2: this.Text = this.Text + " - Edicion de Rol";
                    btnCancelar.Visible = true;
                    btnRegistrar.Text = "Modificar";
                    RecuperarDatos();
                    break;
                case 4: this.Text = this.Text + " - Baja de Rol";
                    btnCancelar.Visible = true;
                    btnRegistrar.Text = "Baja";
                    RecuperarDatos();
                    ucDatosRoles1.ModoSoloLectura = true;
                    ucDatosRoles1.Refresh();
                    break;
            }
            RegistrarControles();
            
        }
        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            if (ucDatosRoles1.validarControles())
            {
                Roles oRol = ucDatosRoles1.Rol;
                switch (Opcion)
                {
                    case (int)Utiles.OpcionesABM.ALTA:
                        if (!oGR.VerificarExistencia(oRol.RoleName))
                        {
                            int i = oGR.Insertar(oRol);
                            if (i > 1)
                            {
                                MessageBox.Show("Se dio de alta al Rol", "Alta de Roles", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                ucDatosRoles1.limpiarControles();
                                this.Close();
                            }
                            else
                            {
                                MessageBox.Show("No se pudo dar de alta al Rol", "Alta de Roles", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        else
                        {
                            MessageBox.Show("El Rol ingresado ya existe", "Alta de Roles", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        break;
                    case (int)Utiles.OpcionesABM.MODIFICACION:
                        oRol.RoleID = IdRol;
                        if (oGR.Modificar(oRol))
                        {
                            MessageBox.Show("Se modifico al Rol", "Modificar Roles", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            ucDatosRoles1.limpiarControles();
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("No se pudo dar modificar al Rol", "Modificar Roles", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        break;
                    case (int)Utiles.OpcionesABM.BAJA:
                        oRol.RoleID = IdRol;
                        oRol.FechaBaja = DateTime.Now;
                        if (oGR.Eliminar(oRol))
                        {
                            MessageBox.Show("Se dio de baja al Rol", "Baja de Roles", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            ucDatosRoles1.limpiarControles();
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("No se pudo dar de baja al Rol", "Baja de Roles", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        break;
                }
            }
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion
        #region Metodos
        private void RecuperarDatos()
        {
            RolModificar = new Roles();
            RolModificar = oGR.Buscar(IdRol);
            if (RolModificar != null)
            {
                RolModificar.RoleID = IdRol;
                ucDatosRoles1.llenarControles(RolModificar.RoleName);
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
