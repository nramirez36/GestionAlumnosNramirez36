using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gestionalumnos.Entities
{
    public class Domicilio
    {
        public int direccionID { get; set; }
        public string calle { get; set; }
        public string altura { get; set; }
        public string depto { get; set; }
        public string piso { get; set; }
        public int provincia_id { get; set; }
        public int ciudad_id { get; set; }
        public int barrio_id { get; set; }
    }
}
