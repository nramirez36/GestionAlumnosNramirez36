using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using gestionalumnos.Entities;
using gestionalumnos.DL;
namespace gestionalumnos.BL
{
    public class GestorControles
    {
        public int Insertar(gestionalumnos.Entities.Controls pControls)
        {
            return gestionalumnos.DL.Controls.Insertar(pControls);
        }
        public IEnumerable<gestionalumnos.Entities.Controls> Listar()
        {
            return gestionalumnos.DL.Controls.Listar();
        }
        public IEnumerable<gestionalumnos.Entities.Controls> ListarPaginas()
        {
            return gestionalumnos.DL.Controls.ListarPaginas();
        }
        public IEnumerable<gestionalumnos.Entities.Controls> ListarPorPagina(gestionalumnos.Entities.Controls pControls)
        {
            return gestionalumnos.DL.Controls.ListarPorPagina(pControls);
        }
        public bool Eliminar(gestionalumnos.Entities.Controls pControls)
        {
            return gestionalumnos.DL.Controls.Eliminar(pControls);
        }
        public gestionalumnos.Entities.Controls Buscar(gestionalumnos.Entities.Controls pControls)
        {
            return gestionalumnos.DL.Controls.Buscar(pControls);
        }
        public bool Existe(gestionalumnos.Entities.Controls pControls)
        {
            return gestionalumnos.DL.Controls.Existe(pControls);
        }
    }
}
