using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using gestionalumnos.Entities;
using gestionalumnos.DL;
namespace gestionalumnos.BL
{
    public class GestorProvincias
    {
        public int Insertar(Provincia pProvincia)
        {
            return Provincias.Insertar(pProvincia);
        }
        public IEnumerable<Provincia> Listar()
        {
            return Provincias.Listar();
        }
        public bool Modificar(Provincia pProvincia)
        {
            return Provincias.Actualizar(pProvincia);
        }
        public bool Eliminar(int id)
        {
            return Provincias.Eliminar(id);
        }
        public int ObtenerID()
        {
            return Provincias.ObtenerUltimoID();
        }
    }
}
