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
    public class Users
    {
        public static gestionalumnos.Entities.Users IniciarSesion(gestionalumnos.Entities.Users pUsers)
        {
            Database odb = DatabaseFactory.CreateDatabase("gestionAlumnos");
            try
            {
                List<gestionalumnos.Entities.Users> lstUsuarios= odb.ExecuteSprocAccessor("Users_IniciarSesion", MapBuilder<gestionalumnos.Entities.Users>.MapAllProperties().Build(), pUsers.Name, pUsers.Password).ToList();
                if (lstUsuarios != null && lstUsuarios.Count == 1)
                {
                    return lstUsuarios[0];
                }
                else
                    return null;
            }
            catch (Exception ex)
            {
                Logger.WriteXMLError("Users.cs", "Users.cs", "IniciarSesion", ex.Message);
                //Logger.WriteXMLError("Users.cs", "Users.cs", "IniciarSesion", ex.Message);
                throw;
            }
        }
        public static gestionalumnos.Entities.Users Buscar(int id)
        {
            Database odb = DatabaseFactory.CreateDatabase("gestionAlumnos");
            try
            {
                List<gestionalumnos.Entities.Users> lst= odb.ExecuteSprocAccessor("Users_Buscar", MapBuilder<gestionalumnos.Entities.Users>.MapAllProperties().Build(), id).ToList();
                if (lst!=null && lst.Count>0)
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
                //Logger.WriteXMLError("Users.cs", "Users.cs", "IniciarSesion", ex.Message);
                Logger.WriteXMLError("Users.cs", "Users.cs", "IniciarSesion", ex.Message);
                throw;
            }
        }
        public static bool Baja(gestionalumnos.Entities.Users pUsers)
        {
            Database oDb = DatabaseFactory.CreateDatabase("gestionAlumnos");
            int result;
            try
            {
                result = oDb.ExecuteNonQuery("Users_Baja", pUsers.Name, pUsers.Password,pUsers.UserID, pUsers.FechaBaja);
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
                Logger.WriteXMLError("Users.cs", "Users.cs", "Baja", ex.Message);
                //Console.WriteLine("Problema Al Eliminar El Tipo De Documento: " + ex.Message);
                throw;
            }
        }
        public static bool ReestablecerPassword(gestionalumnos.Entities.Users pUsers)
        {
            Database oDb = DatabaseFactory.CreateDatabase("gestionAlumnos");
            int result;
            try
            {
                result = oDb.ExecuteNonQuery("Users_ReestablecerContraseña", pUsers.Name, pUsers.Password, pUsers.FechaBaja);
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
                Logger.WriteXMLError("Users.cs", "Users.cs", "ReestablecerPassword", ex.Message);
                //Console.WriteLine("Problemas Al Modificar El Tipo De Documento: " + ex.Message);
                throw;
            }
        }
        public static bool Modificar(gestionalumnos.Entities.Users pUsers)
        {
            Database oDb = DatabaseFactory.CreateDatabase("gestionAlumnos");
            int result;
            try
            {
                result = oDb.ExecuteNonQuery("Users_Modificar", pUsers.Name, pUsers.Email, pUsers.UserID);
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
                Logger.WriteXMLError("Users.cs", "Users.cs", "Modificar", ex.Message);
                //Console.WriteLine("Problemas Al Modificar El Tipo De Documento: " + ex.Message);
                throw;
            }
        }
        public static int Insertar(gestionalumnos.Entities.Users pUsers)
        {
            Database oDb = DatabaseFactory.CreateDatabase("gestionAlumnos");
            int clienteID = -1;
            try
            {
                clienteID = int.Parse(oDb.ExecuteScalar("Users_Insertar", pUsers.Name, pUsers.Password, pUsers.Email).ToString());
            }
            catch (Exception ex)
            {
                Logger.WriteXMLError("Users.cs", "Users.cs", "Insertar", ex.Message);
                //Console.WriteLine("Problemas Al Guardar El Tipo De Documento: " + ex.Message);
                throw;
            }
            return clienteID;
        }
        public static int ObtenerUltimoID()
        {
            Database oDb = DatabaseFactory.CreateDatabase("gestionAlumnos");
            int cli = -1;
            try
            {
                cli = int.Parse(oDb.ExecuteScalar("Users_ObtenerUltimoID").ToString());
            }
            catch (Exception ex)
            {
                Logger.WriteXMLError("Users.cs", "Users.cs", "ObtenerUltimoID", ex.Message);
                //Console.WriteLine("Problemas Al Obtener El Ultimo Número De Tipo De Documento: " + ex.Message);
                throw;
            }
            return cli;
        }
        public static IEnumerable<gestionalumnos.Entities.Users> ListarUsuariosActivos()
        {
            Database odb = DatabaseFactory.CreateDatabase("gestionAlumnos");
            try
            {
                //return odb.ExecuteSprocAccessor("Users_ListarUsuarios", MapBuilder<gestionalumnos.Entities.Users>.MapAllProperties().Build());              
                return odb.ExecuteSprocAccessor("Users_ListarUsuarios", MapBuilder<gestionalumnos.Entities.Users>.MapAllProperties().MapByName(p=>p.UserID).MapByName(p=>p.Name).MapByName(p=>p.Email).DoNotMap(p=>p.FechaBaja).DoNotMap(p=>p.Password).Build());
            }
            catch (Exception ex)
            {
                Logger.WriteXMLError("Users.cs", "Users.cs", "ListarUsuariosActivos", ex.Message);
                //Console.WriteLine("Problemas Al Listar Los Clientes: " + ex.Message);
                throw;
            }
        }
        public static bool VerificarExistencia(string pName)
        { 
            Database oDb = DatabaseFactory.CreateDatabase("gestionAlumnos");
            String result=null;
            try
            {
                List<gestionalumnos.Entities.Users> lst = oDb.ExecuteSprocAccessor("Users_VerificarExistencia", MapBuilder<gestionalumnos.Entities.Users>.MapAllProperties().Build(), pName).ToList();
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
                Logger.WriteXMLError("Users.cs", "Users.cs", "VerificarExistencia", ex.Message);
                //Console.WriteLine("Problema Al Eliminar El Tipo De Documento: " + ex.Message);
                throw;
            }
        }
        
    }
}
