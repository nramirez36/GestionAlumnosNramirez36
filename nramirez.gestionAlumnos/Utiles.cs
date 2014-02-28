using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Globalization;
namespace nramirez.gestionAlumnos
{
    public static class Utiles
    {
        public enum OpcionesABM
        {
            ALTA = 1,
            MODIFICACION = 2,
            CONSULTA = 3,
            BAJA = 4,
        }
        public static bool ComprobarFormatoEmail(string sEmailAComprobar)
        {
            String sFormato;
            sFormato = "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*";
            if (Regex.IsMatch(sEmailAComprobar, sFormato))
            {
                if (Regex.Replace(sEmailAComprobar, sFormato, String.Empty).Length == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        public static bool validarEmail(string email)
        {
            Regex reg = new Regex(@"^[A-Z0-9._%+-]+@[A-Z0-9.-]+\.[A-Z]{2,6}$");
            if (reg.IsMatch(email))
            {
                return true;
            }
            else
                return false;
        }
    }
}

