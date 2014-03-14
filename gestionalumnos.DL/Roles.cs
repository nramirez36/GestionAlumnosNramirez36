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
    public class Roles
    {
        public static IEnumerable<gestionalumnos.Entities.Roles> ListarRoles()
        {
            Database odb = DatabaseFactory.CreateDatabase("gestionAlumnos");
            try
            {
                //return odb.ExecuteSprocAccessor("Users_ListarUsuarios", MapBuilder<gestionalumnos.Entities.Users>.MapAllProperties().MapByName(p => p.UserID).MapByName(p => p.Name).MapByName(p => p.Email).DoNotMap(p => p.FechaBaja).DoNotMap(p => p.Password).Build());
                return odb.ExecuteSprocAccessor("Roles_Listar", MapBuilder<gestionalumnos.Entities.Roles>.MapAllProperties().DoNotMap(p=>p.FechaBaja).Build());
            }
            catch (Exception ex)
            {
                Logger.WriteXMLError("Roles.cs", "Roles.cs", "ListarRoles", ex.Message);
                //Console.WriteLine("Problemas Al Listar Los Clientes: " + ex.Message);
                throw;
            }
        }
        public static bool Eliminar(gestionalumnos.Entities.Roles pRoles)
        {
            Database oDb = DatabaseFactory.CreateDatabase("gestionAlumnos");
            int result;
            try
            {
                result = oDb.ExecuteNonQuery("Roles_Eliminar", pRoles.FechaBaja, pRoles.RoleID);
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
                Logger.WriteXMLError("Roles.cs", "Roles.cs", "Eliminar", ex.Message);
                //Console.WriteLine("Problema Al Eliminar El Tipo De Documento: " + ex.Message);
                throw;
            }
        }
        public static bool Actualizar(gestionalumnos.Entities.Roles pRoles)
        {
            Database oDb = DatabaseFactory.CreateDatabase("gestionAlumnos");
            int result;
            try
            {
                result = oDb.ExecuteNonQuery("Roles_Modificar", pRoles.RoleName,pRoles.RoleID);
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
                Logger.WriteXMLError("Roles.cs", "Roles.cs", "Actualizar", ex.Message);
                //Console.WriteLine("Problemas Al Modificar El Tipo De Documento: " + ex.Message);
                throw;
            }
        }
        public static int Insertar(gestionalumnos.Entities.Roles pRoles)
        {
            Database oDb = DatabaseFactory.CreateDatabase("gestionAlumnos");
            int clienteID = -1;
            try
            {
                clienteID = int.Parse(oDb.ExecuteScalar("Roles_Insertar", pRoles.RoleName).ToString());
            }
            catch (Exception ex)
            {
                Logger.WriteXMLError("Roles.cs", "Roles.cs", "Insertar", ex.Message);
                //Console.WriteLine("Problemas Al Guardar El Tipo De Documento: " + ex.Message);
                throw;
            }
            return clienteID;
        }
        public static gestionalumnos.Entities.Roles Buscar(int id)
        {
            Database oDb = DatabaseFactory.CreateDatabase("gestionAlumnos");
            try
            {
                List<gestionalumnos.Entities.Roles> lst = oDb.ExecuteSprocAccessor("Roles_Buscar", MapBuilder<gestionalumnos.Entities.Roles>.MapAllProperties().DoNotMap(p=>p.FechaBaja).Build(), id).ToList();
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
                Logger.WriteXMLError("Roles.cs", "Roles.cs", "Buscar", ex.Message);
                //Console.WriteLine("Problemas Al Listar Los ALumnos: " + ex.Message);
                throw;
            }
        }
        public static bool VerificarExistencia(string pName)
        {
            Database oDb = DatabaseFactory.CreateDatabase("gestionAlumnos");
            String result = null;
            try
            {
                List<gestionalumnos.Entities.Roles> lst = oDb.ExecuteSprocAccessor("Roles_VerificarExistencia", MapBuilder<gestionalumnos.Entities.Roles>.MapAllProperties().Build(), pName).ToList();
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
                Logger.WriteXMLError("Roles.cs", "Roles.cs", "VerificarExistencia", ex.Message);
                //Console.WriteLine("Problema Al Eliminar El Tipo De Documento: " + ex.Message);
                throw;
            }
        }
    }
}
