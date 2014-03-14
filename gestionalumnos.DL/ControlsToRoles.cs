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
using System.Data;
namespace gestionalumnos.DL
{
    public class ControlsToRoles
    {
        public static IEnumerable<gestionalumnos.Entities.ControlsToRoles> Listar()
        {
            Database odb = DatabaseFactory.CreateDatabase("gestionAlumnos");
            try
            {
                return odb.ExecuteSprocAccessor("ControlsToRole_Listar", MapBuilder<gestionalumnos.Entities.ControlsToRoles>.MapAllProperties().Build());
            }
            catch (Exception ex)
            {
                Logger.WriteXMLError("ControlsToRoles.cs", "ControlsToRoles.cs", "Listar", ex.Message);
                //Console.WriteLine("Problemas Al Listar Los Clientes: " + ex.Message);
                throw;
            }
        }
        public static IEnumerable<gestionalumnos.Entities.ControlsToRoles> ListarPorPagina(string pPage)
        {
            Database odb = DatabaseFactory.CreateDatabase("gestionAlumnos");
            try
            {
                //return odb.ExecuteSprocAccessor("ControlsToRole_ListarPorPagina", MapBuilder<gestionalumnos.Entities.ControlsToRoles>.MapAllProperties().DoNotMap(p => p.FKPage).DoNotMap(p => p.FKRole).Build(), pPage);
                //return odb.ExecuteSprocAccessor("ControlsToRole_ListarPorPagina", MapBuilder<gestionalumnos.Entities.ControlsToRoles>.MapAllProperties().DoNotMap(p => p.FKPage).Build(), pPage);
                return odb.ExecuteSprocAccessor("ControlsToRole_ListarPorPagina", MapBuilder<gestionalumnos.Entities.ControlsToRoles>.MapAllProperties().Build(), pPage);
            }
            catch (Exception ex)
            {
                Logger.WriteXMLError("ControlsToRoles.cs", "ControlsToRoles.cs", "ListarPorPagina", ex.Message);
                //Console.WriteLine("Problemas Al Listar Los Clientes: " + ex.Message);
                throw;
            }
        }
        public static IEnumerable<gestionalumnos.Entities.ControlsToRoles> ListarPorControl()
        {
            Database odb = DatabaseFactory.CreateDatabase("gestionAlumnos");
            try
            {
                //return odb.ExecuteSprocAccessor("ControlsToRole_ListarOrderControl", MapBuilder<gestionalumnos.Entities.ControlsToRoles>.MapAllProperties().DoNotMap(p => p.FKPage).DoNotMap(p => p.FKRole).Build());
                //return odb.ExecuteSprocAccessor("ControlsToRole_ListarOrderControl", MapBuilder<gestionalumnos.Entities.ControlsToRoles>.MapAllProperties().DoNotMap(p => p.FKPage).Build());
                return odb.ExecuteSprocAccessor("ControlsToRole_ListarOrderControl", MapBuilder<gestionalumnos.Entities.ControlsToRoles>.MapAllProperties().Build());
            }
            catch (Exception ex)
            {
                Logger.WriteXMLError("ControlsToRoles.cs", "ControlsToRoles.cs", "ListarPorControl", ex.Message);
                //Console.WriteLine("Problemas Al Listar Los Clientes: " + ex.Message);
                throw;
            }
        }
        public static IEnumerable<gestionalumnos.Entities.ControlsToRoles> ListarPorRol()//(gestionalumnos.Entities.Controls pControls)
        {
            Database odb = DatabaseFactory.CreateDatabase("gestionAlumnos");
            try
            {
                //return odb.ExecuteSprocAccessor("ControlsToRole_ListarOrderRole", MapBuilder<gestionalumnos.Entities.ControlsToRoles>.MapAllProperties().DoNotMap(p => p.FKPage).DoNotMap(p => p.FKRole).Build());
                //return odb.ExecuteSprocAccessor("ControlsToRole_ListarOrderRole", MapBuilder<gestionalumnos.Entities.ControlsToRoles>.MapAllProperties().DoNotMap(p => p.FKPage).Build());
                return odb.ExecuteSprocAccessor("ControlsToRole_ListarOrderRole", MapBuilder<gestionalumnos.Entities.ControlsToRoles>.MapAllProperties().Build());
            }
            catch (Exception ex)
            {
                Logger.WriteXMLError("Controls.cs", "Controls.cs", "ListarPorRol", ex.Message);
                //Console.WriteLine("Problemas Al Listar Los Clientes: " + ex.Message);
                throw;
            }
        }
        public static int Insertar(gestionalumnos.Entities.ControlsToRoles pControls)
        {
            Database oDb = DatabaseFactory.CreateDatabase("gestionAlumnos");
            int clienteID = -1;
            try
            {
                clienteID=oDb.ExecuteNonQuery("spInsertNewControlToRole", pControls.FKRole, pControls.FKPage,pControls.FKControlID,pControls.Invisible,pControls.Disabled);
                //clienteID = int.Parse(oDb.ExecuteScalar("spInsertNewControlToRole", pControls.FKRole, pControls.FKPage,pControls.FKControlID,pControls.Invisible,pControls.Disabled).ToString());
            }
            catch (Exception ex)
            {
                Logger.WriteXMLError("ControlsToRoles.cs", "ControlsToRoles.cs", "Insertar", ex.Message);
                //Console.WriteLine("Problemas Al Guardar El Tipo De Documento: " + ex.Message);
                //throw;
            }
            return clienteID;
        }
        public static IEnumerable<gestionalumnos.Entities.ControlsToRoles> Habilitar(gestionalumnos.Entities.ControlsToRoles pControls)
        {
            Database odb = DatabaseFactory.CreateDatabase("gestionAlumnos");
            try
            {
                //return odb.ExecuteSprocAccessor("ControlsToRole_ListarPorPagina", MapBuilder<gestionalumnos.Entities.ControlsToRoles>.MapAllProperties().DoNotMap(p => p.FKPage).DoNotMap(p => p.FKRole).Build(), pPage);
                //return odb.ExecuteSprocAccessor("ControlsToRole_ListarPorPagina", MapBuilder<gestionalumnos.Entities.ControlsToRoles>.MapAllProperties().DoNotMap(p => p.FKPage).Build(), pPage);
                return odb.ExecuteSprocAccessor("ControlsToRoles_Habilitar", MapBuilder<gestionalumnos.Entities.ControlsToRoles>.MapAllProperties().Build(), pControls.FKPage, pControls.FKRole);
            }
            catch (Exception ex)
            {
                Logger.WriteXMLError("ControlsToRoles.cs", "ControlsToRoles.cs", "Habilitar", ex.Message);
                //Console.WriteLine("Problemas Al Listar Los Clientes: " + ex.Message);
                throw;
            }
        }
    }
}
