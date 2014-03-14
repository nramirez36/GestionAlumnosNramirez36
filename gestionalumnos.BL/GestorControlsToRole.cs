using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using gestionalumnos.DL;
using gestionalumnos.Entities;
namespace gestionalumnos.BL
{
    public class GestorControlsToRole
    {
        public int Insertar(gestionalumnos.Entities.ControlsToRoles pControls)
        {
            return gestionalumnos.DL.ControlsToRoles.Insertar(pControls);
        }
        public IEnumerable<gestionalumnos.Entities.ControlsToRoles> ListarPorRoles()
        {
            return gestionalumnos.DL.ControlsToRoles.ListarPorRol();
        }
        public IEnumerable<gestionalumnos.Entities.ControlsToRoles> ListarPorControl()
        {
            return gestionalumnos.DL.ControlsToRoles.ListarPorControl();
        }
        public IEnumerable<gestionalumnos.Entities.ControlsToRoles> ListarPorPagina(string pPagina)
        {
            return gestionalumnos.DL.ControlsToRoles.ListarPorPagina(pPagina);
        }
        public IEnumerable<gestionalumnos.Entities.ControlsToRoles> Listar()
        {
            return gestionalumnos.DL.ControlsToRoles.Listar();
        }
        public IEnumerable<gestionalumnos.Entities.ControlsToRoles> Habilitar(gestionalumnos.Entities.ControlsToRoles pControls)
        {
            return gestionalumnos.DL.ControlsToRoles.Habilitar(pControls);
        }
    }
}
