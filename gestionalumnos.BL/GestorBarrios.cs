using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using gestionalumnos.Entities;
using gestionalumnos.DL;
namespace gestionalumnos.BL
{
    public class GestorBarrios
    {
        public int Insertar(Barrio pBarrio)
        {
            return Barrios.Insertar(pBarrio);
        }
        public IEnumerable<Barrio> Listar(int pCodLocalidad)
        {
            return Barrios.Listar(pCodLocalidad);
        }
        public bool Modificar(Barrio pBarrio)
        {
            return Barrios.Actualizar(pBarrio);
        }
        public bool Eliminar(int id)
        {
            return Barrios.Eliminar(id);
        }
        public int ObtenerID()
        {
            return Barrios.ObtenerUltimoID();
        }
    }
}
