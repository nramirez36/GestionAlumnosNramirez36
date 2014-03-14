using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using gestionalumnos.Entities;
using gestionalumnos.DL;
namespace gestionalumnos.BL
{
    public class GestorUsersToRoles
    {
        //public IEnumerable<gestionalumnos.Entities.UsersToRoles> Buscar(gestionalumnos.Entities.UsersToRoles pUser)
        public IEnumerable<gestionalumnos.Entities.Roles> Buscar(gestionalumnos.Entities.UsersToRoles pUser)
        {
            return gestionalumnos.DL.UserToRoles.Buscar(pUser);
        }
    }
}
