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
    public class Localidades
    {
        public static IEnumerable<Localidad> Listar(int pDepartamento)
        {
            Database odb = DatabaseFactory.CreateDatabase("gestionAlumnos");
            try
            {
                return odb.ExecuteSprocAccessor("Localidad_Listar", MapBuilder<Localidad>.MapAllProperties().Build(), pDepartamento);
            }
            catch (Exception ex)
            {
                Logger.WriteXMLError("Localidades.cs", "Localidades.cs", "Listar", ex.Message);
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
                result = oDb.ExecuteNonQuery("Localidad_Eliminar", id);
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
                Logger.WriteXMLError("Localidades.cs", "Localidades.cs", "Eliminar", ex.Message);
                //Console.WriteLine("Problema Al Eliminar La Localidad: " + ex.Message);
                throw;
            }
        }
        public static bool Actualizar(Localidad pLocalidad)
        {
            Database oDb = DatabaseFactory.CreateDatabase("gestionAlumnos");
            int result;
            try
            {
                result = oDb.ExecuteNonQuery("Localidad_Modificar", pLocalidad.nombre, pLocalidad.departamento_id,pLocalidad.id);
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
                Logger.WriteXMLError("Localidades.cs", "Localidades.cs", "Actualizar", ex.Message);
                //Console.WriteLine("Problemas Al Modificar La Localidad: " + ex.Message);
                throw;
            }
        }
        public static int Insertar(Localidad pLocalidad)
        {
            Database oDb = DatabaseFactory.CreateDatabase("gestionAlumnos");
            int clienteID = -1;
            try
            {
                clienteID = int.Parse(oDb.ExecuteScalar("Localidad_Insertar", pLocalidad.nombre, pLocalidad.departamento_id).ToString());
            }
            catch (Exception ex)
            {
                Logger.WriteXMLError("Localidades.cs", "Localidades.cs", "Insertar", ex.Message);
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
                cli = int.Parse(oDb.ExecuteScalar("Localidad_ObtenerUltimoID").ToString());
            }
            catch (Exception ex)
            {
                Logger.WriteXMLError("Localidades.cs", "Localidades.cs", "ObtenerUltimoID", ex.Message);
                //Console.WriteLine("Problemas Al Obtener El Ultimo Número De Localidad: " + ex.Message);
                throw;
            }
            return cli;
        }
    }
}
