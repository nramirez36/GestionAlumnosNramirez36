using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using gestionalumnos.DL;
using gestionalumnos.Entities;
namespace gestionalumnos.BL
{
    public class GestorDomicilios
    {
        public int Insertar(Domicilio pDomicilio)
        {
            return Domicilios.Insertar(pDomicilio);
        }
        public IEnumerable<Domicilio> Listar()
        {
            return Domicilios.Listar();
        }
        public bool Modificar(Domicilio pDomicilio)
        {
            return Domicilios.Actualizar(pDomicilio);
        }
        public bool Eliminar(int id)
        {
            return Domicilios.Eliminar(id);
        }
        public int ObtenerID()
        {
            return Domicilios.ObtenerUltimoID();
        }
        public Domicilio Buscar(int id)
        {
            return Domicilios.Buscar(id);
        }
    }
}
