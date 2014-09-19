using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
namespace gestionalumnos.Comun
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
        public enum Roles
        {
            admin = 1,
            admiin = 2,
            asdasa = 3,
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
        public static int CalcularEdad(DateTime pFecha)
        {
            int edad = DateTime.Now.Year - pFecha.Year;
            DateTime nacimientoAhora = pFecha.AddYears(edad);
            if (DateTime.Now.CompareTo(nacimientoAhora) < 0)
                edad--;
            return edad;
        }
        public static void GetLargestTextExtent(System.Windows.Forms.ComboBox cbo, ref int largestWidth)
        {
            int maxLen = -1;
            if (cbo.Items.Count >= 1)
            {
                using (Graphics g = cbo.CreateGraphics())
                {
                    int vertScrollBarWidth = 0;
                    if (cbo.Items.Count > cbo.MaxDropDownItems)
                    {
                        vertScrollBarWidth = SystemInformation.VerticalScrollBarWidth;
                    }
                    for (int nLoopCnt = 0; nLoopCnt < cbo.Items.Count; nLoopCnt++)
                    {
                        int newWidth = (int)g.MeasureString(cbo.Items[nLoopCnt].ToString(), cbo.Font).Width + vertScrollBarWidth;
                        if (newWidth > maxLen)
                        {
                            maxLen = newWidth;
                        }
                    }
                }
            }
            largestWidth = maxLen;
        }
    }
}
