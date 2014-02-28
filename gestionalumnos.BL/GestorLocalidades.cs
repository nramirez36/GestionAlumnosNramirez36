using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using gestionalumnos.DL;
using gestionalumnos.Entities;
namespace gestionalumnos.BL
{
    public class GestorLocalidades
    {
        public int Insertar(Localidad pLocalidad)
        {
            return Localidades.Insertar(pLocalidad);
        }
        public IEnumerable<Localidad> Listar(int pDepartamento)
        {
            return Localidades.Listar(pDepartamento);
        }
        public bool Modificar(Localidad pLocalidad)
        {
            return Localidades.Actualizar(pLocalidad);
        }
        public bool Eliminar(int id)
        {
            return Localidades.Eliminar(id);
        }
        public int ObtenerID()
        {
            return Localidades.ObtenerUltimoID();
        }
    }
}
