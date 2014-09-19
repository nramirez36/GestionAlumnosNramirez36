using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gestionalumnos.Entities
{
    public class Localidad
    {
        public int localidad_id { get; set; }
        public int provincia_id { get; set; }
        public string nombre { get; set; }
    }
}
