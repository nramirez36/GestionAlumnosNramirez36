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
    public class Domicilios
    {
        public static IEnumerable<Domicilio> Listar()
        {
            Database odb = DatabaseFactory.CreateDatabase("gestionAlumnos");
            try
            {
                return odb.ExecuteSprocAccessor("Domicilio_Listar", MapBuilder<Domicilio>.MapAllProperties().Build());
            }
            catch (Exception ex)
            {
                Logger.WriteXMLError("Domicilios.cs", "Domicilios.cs", "Listar", ex.Message);
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
                result = oDb.ExecuteNonQuery("Domicilio_Eliminar", id);
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
                Logger.WriteXMLError("Domicilios.cs", "Domicilios.cs", "Eliminar", ex.Message);
                //Console.WriteLine("Problema Al Eliminar La Localidad: " + ex.Message);
                throw;
            }
        }
        public static bool Actualizar(Domicilio pDomicilio)
        {
            Database oDb = DatabaseFactory.CreateDatabase("gestionAlumnos");
            int result;
            try
            {
                result = oDb.ExecuteNonQuery("Domicilio_Modificar", pDomicilio.calle, pDomicilio.altura, pDomicilio.depto,pDomicilio.piso,pDomicilio.provincia_id,pDomicilio.barrio_id, pDomicilio.direccionID);
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
                Logger.WriteXMLError("Domicilios.cs", "Domicilios.cs", "Actualizar", ex.Message);
                //Console.WriteLine("Problemas Al Modificar La Localidad: " + ex.Message);
                throw;
            }
        }
        public static int Insertar(Domicilio pDomicilio)
        {
            Database oDb = DatabaseFactory.CreateDatabase("gestionAlumnos");
            int clienteID = -1;
            try
            {
                clienteID = int.Parse(oDb.ExecuteScalar("Domicilio_Insertar", pDomicilio.calle,pDomicilio.altura,pDomicilio.depto,pDomicilio.piso,pDomicilio.provincia_id,pDomicilio.ciudad_id,pDomicilio.barrio_id).ToString());
            }
            catch (Exception ex)
            {
                Logger.WriteXMLError("Domicilios.cs", "Domicilios.cs", "Insertar", ex.Message);
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
                cli = int.Parse(oDb.ExecuteScalar("Domicilio_ObtenerUltimoID").ToString());
            }
            catch (Exception ex)
            {
                Logger.WriteXMLError("Domicilios.cs", "Domicilios.cs", "ObtenerUltimoID", ex.Message);
                //Console.WriteLine("Problemas Al Obtener El Ultimo Número De Localidad: " + ex.Message);
                throw;
            }
            return cli;
        }
    }
}
