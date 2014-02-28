using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using gestionalumnos.Entities;
using gestionalumnos.DL;
namespace gestionalumnos.BL
{
    public class GestorTiposDocumentos
    {
        public int Insertar(TipoDocumento pTipoDocumento)
        {
            return TiposDocumentos.Insertar(pTipoDocumento);
        }
        public IEnumerable<TipoDocumento> Listar()
        {
            return TiposDocumentos.ListarTiposDocumentos();
        }
        public bool Modificar(TipoDocumento pTipoDocumento)
        {
            return TiposDocumentos.Actualizar(pTipoDocumento);
        }
        public bool Eliminar(int id)
        {
            return TiposDocumentos.Eliminar(id);
        }
        public int ObtenerID()
        {
            return TiposDocumentos.ObtenerUltimoID();
        }
    }
}
