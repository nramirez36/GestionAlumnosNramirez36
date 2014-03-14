using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Common;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using gestionalumnos.Entities;
using nramirez36.Logger;
namespace gestionalumnos.DL
{
    public class Controls
    {
        public static IEnumerable<gestionalumnos.Entities.Controls> Listar()
        {
            Database odb = DatabaseFactory.CreateDatabase("gestionAlumnos");
            try
            {
                return odb.ExecuteSprocAccessor("Controls_Listar", MapBuilder<gestionalumnos.Entities.Controls>.MapAllProperties().DoNotMap(p=>p.ControlPK).Build());
            }
            catch (Exception ex)
            {
                Logger.WriteXMLError("Controls.cs", "Controls.cs", "Listar", ex.Message);
                //Console.WriteLine("Problemas Al Listar Los Clientes: " + ex.Message);
                throw;
            }
        }
        public static IEnumerable<gestionalumnos.Entities.Controls> ListarPaginas()
        {
            Database odb = DatabaseFactory.CreateDatabase("gestionAlumnos");
            try
            {
                return odb.ExecuteSprocAccessor("Controls_ListarPaginas", MapBuilder<gestionalumnos.Entities.Controls>.MapAllProperties().DoNotMap(p => p.ControlPK).DoNotMap(p => p.ControlID).Build());
            }
            catch (Exception ex)
            {
                Logger.WriteXMLError("Controls.cs", "Controls.cs", "ListarPaginas", ex.Message);
                //Console.WriteLine("Problemas Al Listar Los Clientes: " + ex.Message);
                throw;
            }
        }
        public static IEnumerable<gestionalumnos.Entities.Controls> ListarPorPagina(gestionalumnos.Entities.Controls pControls)
        {
            Database odb = DatabaseFactory.CreateDatabase("gestionAlumnos");
            try
            {
                return odb.ExecuteSprocAccessor("Controls_ListarPorPagina", MapBuilder<gestionalumnos.Entities.Controls>.MapAllProperties().DoNotMap(p=>p.ControlPK).Build(),pControls.Page);
            }
            catch (Exception ex)
            {
                Logger.WriteXMLError("Controls.cs", "Controls.cs", "ListarPorPagina", ex.Message);
                //Console.WriteLine("Problemas Al Listar Los Clientes: " + ex.Message);
                throw;
            }
        }
        public static bool Eliminar(gestionalumnos.Entities.Controls pControls)
        {
            Database oDb = DatabaseFactory.CreateDatabase("gestionAlumnos");
            int result;
            try
            {
                result = oDb.ExecuteNonQuery("Controls_Eliminar", pControls.Page, pControls.ControlID);
                if (result > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                Logger.WriteXMLError("Controls.cs", "Controls.cs", "Eliminar", ex.Message);
                //Console.WriteLine("Problema Al Eliminar El Tipo De Documento: " + ex.Message);
                throw;
            }
        }
        public static int Insertar(gestionalumnos.Entities.Controls pControls)
        {
            Database oDb = DatabaseFactory.CreateDatabase("gestionAlumnos");
            int clienteID = -1;
            try
            {
                clienteID = int.Parse(oDb.ExecuteScalar("Controls_Insertar", pControls.Page,pControls.ControlID).ToString());
            }
            catch (Exception ex)
            {
                Logger.WriteXMLError("Controls.cs", "Controls.cs", "Insertar", ex.Message);
                //Console.WriteLine("Problemas Al Guardar El Tipo De Documento: " + ex.Message);
                throw;
            }
            return clienteID;
        }
        public static gestionalumnos.Entities.Controls Buscar(gestionalumnos.Entities.Controls pControls)
        {
            Database oDb = DatabaseFactory.CreateDatabase("gestionAlumnos");
            try
            {
                List<gestionalumnos.Entities.Controls> lst = oDb.ExecuteSprocAccessor("Controls_Buscar", MapBuilder<gestionalumnos.Entities.Controls>.MapAllProperties().Build(), pControls.Page,pControls.ControlID).ToList();
                if (lst != null && lst.Count > 0)
                {
                    return lst[0];
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                Logger.WriteXMLError("Controls.cs", "Controls.cs", "Buscar", ex.Message);
                //Console.WriteLine("Problemas Al Listar Los ALumnos: " + ex.Message);
                throw;
            }
        }
        public static bool Existe(gestionalumnos.Entities.Controls pControls)
        {
            Database oDb = DatabaseFactory.CreateDatabase("gestionAlumnos");
            try
            {
                List<gestionalumnos.Entities.Controls> lst = oDb.ExecuteSprocAccessor("Controls_Buscar", MapBuilder<gestionalumnos.Entities.Controls>.MapAllProperties().Build(), pControls.Page, pControls.ControlID).ToList();
                if (lst != null && lst.Count > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                Logger.WriteXMLError("Controls.cs", "Controls.cs", "Existe", ex.Message);
                //Console.WriteLine("Problemas Al Listar Los ALumnos: " + ex.Message);
                throw;
            }
        }
        
    }
}
