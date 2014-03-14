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
    public class UserToRoles
    {
        //public static IEnumerable<gestionalumnos.Entities.UsersToRoles> Buscar(gestionalumnos.Entities.UsersToRoles pUser)
        public static IEnumerable<gestionalumnos.Entities.Roles> Buscar(gestionalumnos.Entities.UsersToRoles pUser)
        {
            Database odb = DatabaseFactory.CreateDatabase("gestionAlumnos");
            try
            {
                //return odb.ExecuteSprocAccessor("UsersToRoles_BuscarRoles", MapBuilder<gestionalumnos.Entities.UsersToRoles>.MapAllProperties().Build(),pUser.FKUserID);
                return odb.ExecuteSprocAccessor("UsersToRoles_BuscarRoles", MapBuilder<gestionalumnos.Entities.Roles>.MapAllProperties().DoNotMap(p => p.FechaBaja).DoNotMap(p => p.RoleName).Build(), pUser.FKUserID);
            }
            catch (Exception ex)
            {
                Logger.WriteXMLError("UserToRoles.cs", "UserToRoles.cs", "Buscar", ex.Message);
                //Console.WriteLine("Problemas Al Listar Los Clientes: " + ex.Message);
                throw;
            }
        }
    }
}
