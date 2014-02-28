using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gestionalumnos.Entities
{
    public class Users
    {
        public int UserID { get; set; }
        public string Name { get; set; }
        //public string WorkPhone { get; set; }
        public DateTime? FechaBaja { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
    }
}
