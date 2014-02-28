using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gestionalumnos.Entities
{
    public class Alumno
    {
        public int alumnoID { get; set; }
        public string nombres { get; set; }
        public string apellidos { get; set; }
        public int direccionID { get; set; }
        public int tipodocumentoID { get; set; }
        public int nrodocumento { get; set; }
        public string telefonofijo { get; set; }
        public string telefonocelular { get; set; }
        public string nacionalidad { get; set; }
        public DateTime fechanacimiento { get; set; }
        public int edad { get; set; }
    }
}
