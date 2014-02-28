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
    public class Provincias
    {
        public static IEnumerable<Provincia> Listar()
        {
            Database odb = DatabaseFactory.CreateDatabase("gestionAlumnos");
            try
            {
                return odb.ExecuteSprocAccessor("Provincia_Listar", MapBuilder<Provincia>.MapAllProperties().Build());
            }
            catch (Exception ex)
            {
                Logger.WriteXMLError("Provincias.cs", "Provincias.cs", "Listar", ex.Message);
                //Console.WriteLine("Problemas Al Listar Las Provincias: " + ex.Message);
                throw;
            }
        }
        public static bool Eliminar(int id)
        {
            Database oDb = DatabaseFactory.CreateDatabase("gestionAlumnos");
            int result;
            try
            {
                result = oDb.ExecuteNonQuery("Provincia_Eliminar", id);
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
                Logger.WriteXMLError("Provincias.cs", "Provincias.cs", "Eliminar", ex.Message);
                //Console.WriteLine("Problema Al Eliminar La Provincia: " + ex.Message);
                throw;
            }
        }
        public static bool Actualizar(Provincia pProvincia)
        {
            Database oDb = DatabaseFactory.CreateDatabase("gestionAlumnos");
            int result;
            try
            {
                result = oDb.ExecuteNonQuery("Provincia_Modificar", pProvincia.nombre, pProvincia.id);
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
                Logger.WriteXMLError("Provincias.cs", "Provincias.cs", "Actualizar", ex.Message);
                //Console.WriteLine("Problemas Al Modificar La Provincia: " + ex.Message);
                throw;
            }
        }
        public static int Insertar(Provincia pProvincia)
        {
            Database oDb = DatabaseFactory.CreateDatabase("gestionAlumnos");
            int clienteID = -1;
            try
            {
                clienteID = int.Parse(oDb.ExecuteScalar("Provincia_Insertar", pProvincia.nombre).ToString());
            }
            catch (Exception ex)
            {
                Logger.WriteXMLError("Provincias.cs", "Provincias.cs", "Insertar", ex.Message);
                //Console.WriteLine("Problemas Al Guardar La Provincia: " + ex.Message);
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
                cli = int.Parse(oDb.ExecuteScalar("Provincia_ObtenerUltimoID").ToString());
            }
            catch (Exception ex)
            {
                Logger.WriteXMLError("Provincias.cs", "Provincias.cs", "ObtenerUltimoID", ex.Message);
                //Console.WriteLine("Problemas Al Obtener El Ultimo Número De Provincia: " + ex.Message);
                throw;
            }
            return cli;
        }
    }
}
