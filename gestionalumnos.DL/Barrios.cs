using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Common;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using gestionalumnos.Entities;
using nramirez36.Logger;
namespace gestionalumnos.DL
{
    public class Barrios
    {
        public static IEnumerable<Barrio> Listar(int pCodLocalidad)
        {
            Database odb = DatabaseFactory.CreateDatabase("gestionAlumnos");
            try
            {
                return odb.ExecuteSprocAccessor("Barrio_Listar", MapBuilder<Barrio>.MapAllProperties().Build(), pCodLocalidad);
            }
            catch (Exception ex)
            {
                Logger.WriteXMLError("Barrios.cs", "Barrios.cs", "Listar", ex.Message);
                //Console.WriteLine("Problemas Al Listar Los Localidad: " + ex.Message);
                throw;
            }
        }
        public static bool Eliminar(int id)
        {
            Database oDb = DatabaseFactory.CreateDatabase("gestionAlumnos");
            int result;
            try
            {
                result = oDb.ExecuteNonQuery("Barrio_Eliminar", id);
                if (result > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                Logger.WriteXMLError("Barrios.cs", "Barrios.cs", "Eliminar", ex.Message);
                //Console.WriteLine("Problema Al Eliminar La Localidad: " + ex.Message);
                throw;
            }
        }
        public static bool Actualizar(Barrio pBarrio)
        {
            Database oDb = DatabaseFactory.CreateDatabase("gestionAlumnos");
            int result;
            try
            {
                result = oDb.ExecuteNonQuery("Barrio_Modificar", pBarrio.localidad_id, pBarrio.nombre, pBarrio.id);
                if (result > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                Logger.WriteXMLError("Barrios.cs", "Barrios.cs", "Actualizar", ex.Message);
                //Console.WriteLine("Problemas Al Modificar La Localidad: " + ex.Message);
                throw;
            }
        }
        public static int Insertar(Barrio pBarrio)
        {
            Database oDb = DatabaseFactory.CreateDatabase("gestionAlumnos");
            int clienteID = -1;
            try
            {
                clienteID = int.Parse(oDb.ExecuteScalar("Barrio_Insertar", pBarrio.nombre,pBarrio.localidad_id).ToString());
            }
            catch (Exception ex)
            {
                Logger.WriteXMLError("Barrios.cs", "Barrios.cs", "Insertar", ex.Message);
                //Console.WriteLine("Problemas Al Guardar La Localidad: " + ex.Message);
                throw;
            }
            return clienteID;
        }
        public static int ObtenerUltimoID()
        {
            Database oDb = DatabaseFactory.CreateDatabase("gestionAlumnos");
            int cli = -1;
            try
            {
                cli = int.Parse(oDb.ExecuteScalar("Barrio_ObtenerUltimoID").ToString());
            }
            catch (Exception ex)
            {
                Logger.WriteXMLError("Barrios.cs", "Barrios.cs", "ObtenerUltimoID", ex.Message);
                //Console.WriteLine("Problemas Al Obtener El Ultimo Número De Localidad: " + ex.Message);
                throw;
            }
            return cli;
        }
    }
}
