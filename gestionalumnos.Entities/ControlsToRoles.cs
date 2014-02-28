using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gestionalumnos.Entities
{
    public class ControlsToRoles
    {
        public int FKRole { get; set; }
        public string FKPage { get; set; }
        public string FKControlID { get; set; }
        public int Invisible { get; set; }
        public int Disabled { get; set; }
    }
}
