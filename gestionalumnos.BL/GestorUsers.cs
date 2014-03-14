using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using gestionalumnos.Entities;
using gestionalumnos.DL;
namespace gestionalumnos.BL
{
    public class GestorUsers
    {
        public int Insertar(gestionalumnos.Entities.Users pUsers)
        {
            return gestionalumnos.DL.Users.Insertar(pUsers);
        }
        public IEnumerable<gestionalumnos.Entities.Users> Listar()
        {
            return gestionalumnos.DL.Users.ListarUsuariosActivos();
        }
        public bool ReestablecerPassword(gestionalumnos.Entities.Users pUsers)
        {
            return gestionalumnos.DL.Users.ReestablecerPassword(pUsers);
        }
        public bool Baja(gestionalumnos.Entities.Users pUsers)
        {
            return gestionalumnos.DL.Users.Baja(pUsers);
        }
        public int ObtenerID()
        {
            return gestionalumnos.DL.Users.ObtenerUltimoID();
        }
        public gestionalumnos.Entities.Users IniciarSesion(gestionalumnos.Entities.Users pUsers)
        {
            return gestionalumnos.DL.Users.IniciarSesion(pUsers);
        }
        public gestionalumnos.Entities.Users Buscar(int id)
        {
            return gestionalumnos.DL.Users.Buscar(id);
        }
        public bool Modificar(gestionalumnos.Entities.Users pUsers)
        {
            return gestionalumnos.DL.Users.Modificar(pUsers);
        }
        public bool VerficarExistencia(string pName)
        {
            return gestionalumnos.DL.Users.VerificarExistencia(pName);
        }
    }
}
