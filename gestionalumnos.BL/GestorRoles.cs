using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using gestionalumnos.Entities;
using gestionalumnos.DL;
namespace gestionalumnos.BL
{
    public class GestorRoles
    {
        public int Insertar(gestionalumnos.Entities.Roles pRoles)
        {
            return gestionalumnos.DL.Roles.Insertar(pRoles);
        }
        public IEnumerable<gestionalumnos.Entities.Roles> Listar()
        {
            return gestionalumnos.DL.Roles.ListarRoles();
        }
        public bool Modificar(gestionalumnos.Entities.Roles pRoles)
        {
            return gestionalumnos.DL.Roles.Actualizar(pRoles);            
        }
        public bool Eliminar(gestionalumnos.Entities.Roles pRoles)
        {
            return gestionalumnos.DL.Roles.Eliminar(pRoles);
        }
        public gestionalumnos.Entities.Roles Buscar(int pRol)
        {
            return gestionalumnos.DL.Roles.Buscar(pRol);
        }
        public bool VerificarExistencia(string pName)
        {
            return gestionalumnos.DL.Roles.VerificarExistencia(pName);
        }
        //public int ObtenerID()
        //{
        //    return TiposDocumentos.ObtenerUltimoID();
        //}

    }
}
