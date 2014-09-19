using gestionalumnos.BL;
using gestionalumnos.Entities;
using nramirez36.Logger;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Windows.Forms;

namespace nramirez.gestionAlumnos.Seguridad
{
    public partial class frmGestionPermisos : Form
    {
        #region Variables
        private GestorControles oGC = new GestorControles();
        private GestorRoles oGR = new GestorRoles();
        private GestorControlsToRole oGCR = new GestorControlsToRole();
        private Form workingForm;
        #endregion
        #region Propiedades

        #endregion
        #region Constructor
        public frmGestionPermisos()
        {
            InitializeComponent();
        }
        #endregion
        #region Eventos
        private void frmGestionPermisos_Load(object sender, EventArgs e)
        {
            RegistrarControles();
            LoadGrilla();
            LoadPaginas();
            LoadRoles();            
            //LoadArbolPermisos();
            string value = ddlPage.SelectedValue.ToString();
            LoadArbolPermisos(value);
        }
        private void ddlPage_SelectedValueChanged(object sender, EventArgs e)
        {
            string value = ddlPage.SelectedValue.ToString();
            LoadGrilla(value);
            LoadArbolPermisos(value);
        }
        private void ByControlRB_CheckedChanged(object sender, EventArgs e)
        {
            LoadArbolPermisos();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void frmGestionPermisos_FormClosing(object sender, FormClosingEventArgs e)
        {

        }
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            ControlsToRoles c = null;
            foreach (gestionalumnos.Entities.Controls controlID in lstControles.SelectedItems)
            {
                foreach (Roles item in lstRoles.SelectedItems)
                {
                    c = new ControlsToRoles();
                    c.FKRole = item.RoleID;
                    c.FKPage = controlID.Page;
                    c.FKControlID = controlID.ControlID;
                    c.Invisible = chkInvisible.Checked ? 1 : 0;
                    c.Disabled = chkDisabled.Checked ? 1 : 0;
                    int res = oGCR.Insertar(c);
                    if (res < 1 || res > 2)
                    {
                        DisplayError(controlID.ControlID, item.RoleID, "Permisos insertados = " + res.ToString());
                    }
                }
            }
            LoadArbolPermisos();
        }

        private void ByRoleRB_Click(object sender, EventArgs e)
        {
            LoadArbolPermisos();
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
        private void LoadGrilla(string pPagina)
        {
            try
            {
                Controls c = new Controls();
                c.Page = pPagina;
                List<Controls> lst = oGC.ListarPorPagina(c).ToList();
                lstControles.DataSource = lst;
                lstControles.DisplayMember = "ControlID";
                lstRoles.ValueMember = "RoleID";
            }
            catch (Exception ex)
            {
                Logger.WriteXMLError("frmGestionPermisos", "frmGestionPermisos", "LoadGrilla", ex.Message);
                throw;
            }
        }
        private void LoadGrilla()
        {
            try
            {
                List<Controls> lst = oGC.Listar().ToList();
                lstControles.DataSource = lst;
                lstControles.DisplayMember = "ControlID";
                lstRoles.ValueMember = "RoleID";

            }
            catch (Exception ex)
            {
                Logger.WriteXMLError("frmGestionPermisos", "frmGestionPermisos", "LoadGrilla", ex.Message);
                throw;
            }
        }
        private void LoadPaginas()
        {
            try
            {
                ddlPage.DataSource = oGC.ListarPaginas().ToList();
                ddlPage.DisplayMember = "Page";
                ddlPage.ValueMember = "Page";
            }
            catch (Exception ex)
            {
                Logger.WriteXMLError("frmGestionPermisos", "frmGestionPermisos", "LoadPaginas", ex.Message);
                throw;
            }
        }
        private void LoadRoles()
        {
            try
            {
                lstRoles.DataSource = oGR.Listar().ToList();
                lstRoles.DisplayMember = "RoleName";
                lstRoles.ValueMember = "RoleID";
            }
            catch (Exception ex)
            {
                Logger.WriteXMLError("frmGestionPermisos", "frmGestionPermisos", "LoadRoles", ex.Message);
                throw;
            }
        }
        private void DisplayError(string controlID, int roleID, string message)
        {
            MessageBox.Show("No se puede agregar el control (" + controlID + ") al rol (" + roleID + ")" + message,
                "Error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }

        private void LoadArbolPermisos(string pPage)
        {
            List<ControlsToRoles> lst = new List<ControlsToRoles>();
            lst = oGCR.ListarPorPagina(pPage).ToList();
            tvEstado.BeginUpdate();
            tvEstado.Nodes.Clear();
            TreeNode parentNode = null;
            TreeNode subNode = null;
            string currentName = string.Empty;

            foreach (var i in lst)
            {
                //string subNodeText = ByControlRB.Checked ? i.FKRole.ToString() : i.FKControlID.ToString();
                string subNodeText = i.FKPage.ToString() + " - ";
                subNodeText += ByControlRB.Checked ? oGR.Buscar(i.FKRole).RoleName.ToString() : i.FKControlID.ToString();
                subNodeText += ":";
                subNodeText += Convert.ToInt32(i.Invisible) == 0 ? " visible " : " no visible ";
                subNodeText += " y ";
                subNodeText += Convert.ToInt32(i.Disabled) == 0 ? " habilitado " : " deshabilitado ";

                subNode = new TreeNode(subNodeText);
                //string dataName = ByControlRB.Checked ? i.FKControlID.ToString() : i.FKRole.ToString();
                string dataName = ByControlRB.Checked ? i.FKControlID.ToString() : oGR.Buscar(i.FKRole).RoleName.ToString();
                if (currentName != dataName)
                {
                    parentNode = new TreeNode(dataName);
                    currentName = dataName;
                    tvEstado.Nodes.Add(parentNode);
                }

                if (parentNode != null)
                {
                    parentNode.Nodes.Add(subNode);
                }

            }
            tvEstado.EndUpdate();
        }
        private void LoadArbolPermisos()
        {
            List<ControlsToRoles> lst = new List<ControlsToRoles>();
            if (ByControlRB.Checked)
            {
                lst = oGCR.ListarPorControl().ToList();
            }
            else
            {
                lst = oGCR.ListarPorRoles().ToList();
            }
            tvEstado.BeginUpdate();
            tvEstado.Nodes.Clear();
            TreeNode parentNode = null;
            TreeNode subNode = null;
            string currentName = string.Empty;

            foreach (var i in lst)
            {
                //string subNodeText = ByControlRB.Checked ? i.FKRole.ToString() : i.FKControlID.ToString();
                string subNodeText = i.FKPage.ToString() + " - ";
                subNodeText += ByControlRB.Checked ? oGR.Buscar(i.FKRole).RoleName.ToString() : i.FKControlID.ToString();
                subNodeText += ":";
                subNodeText += Convert.ToInt32(i.Invisible) == 0 ? " visible " : " no visible ";
                subNodeText += " and ";
                subNodeText += Convert.ToInt32(i.Disabled) == 0 ? " habilitado " : " deshabilitado ";

                subNode = new TreeNode(subNodeText);
                //string dataName = ByControlRB.Checked ? i.FKControlID.ToString() : i.FKRole.ToString();
                string dataName = ByControlRB.Checked ? i.FKControlID.ToString() : oGR.Buscar(i.FKRole).RoleName.ToString();
                if (currentName != dataName)
                {
                    parentNode = new TreeNode(dataName);
                    currentName = dataName;
                    tvEstado.Nodes.Add(parentNode);
                }

                if (parentNode != null)
                {
                    parentNode.Nodes.Add(subNode);
                }

            }
            tvEstado.EndUpdate();
        }


        #endregion





    }
}
