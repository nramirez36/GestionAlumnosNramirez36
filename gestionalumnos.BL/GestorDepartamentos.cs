using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using gestionalumnos.DL;
using gestionalumnos.Entities;
namespace gestionalumnos.BL
{
    public class GestorDepartamentos
    {
        public int Insertar(Departamento pDepartamento)
        {
            return Departamentos.Insertar(pDepartamento);
        }
        public IEnumerable<Departamento> Listar(int pCodProvincia)
        {
            return Departamentos.Listar(pCodProvincia);
        }
        public bool Modificar(Departamento pDepartamento)
        {
            return Departamentos.Actualizar(pDepartamento);
        }
        public bool Eliminar(int id)
        {
            return Departamentos.Eliminar(id);
        }
        public int ObtenerID()
        {
            return Departamentos.ObtenerUltimoID();
        }
    }
}
