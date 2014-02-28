using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nramirez.gestionAlumnos
{
    public class Init:System.Windows.Forms.ApplicationContext
    {
        public Init()
        {
            frmSplash frm = new frmSplash();
            frm.Show();
        }
    }
}
