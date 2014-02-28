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
    public class Alumnos
    {
        public static IEnumerable<Alumno> Listar()
        {
            Database odb = DatabaseFactory.CreateDatabase("gestionAlumnos");
            try
            {
                return odb.ExecuteSprocAccessor("Alumnos_Listar", MapBuilder<Alumno>.MapAllProperties().Build());
            }
            catch (Exception ex)
            {
                Logger.WriteXMLError("Alumnos.cs", "Alumnos.cs", "Listar", ex.Message);
                //Console.WriteLine("Problemas Al Listar Los Localidad: " + ex.Message);
                throw;
            }
        }
        public static IEnumerable<Alumno> BuscarAlumnosPorDocumento(int pDocumento)
        {
            Database oDb = DatabaseFactory.CreateDatabase("gestionAlumnos");
            try
            {
                return oDb.ExecuteSprocAccessor("Alumno_Buscar", MapBuilder<Alumno>.MapAllProperties().Build(), pDocumento);
            }
            catch (Exception ex)
            {
                Logger.WriteXMLError("Alumnos.cs", "Alumnos.cs", "BuscarAlumnosPorDocumento", ex.Message);
                //Console.WriteLine("Problemas Al Listar Los ALumnos: " + ex.Message);
                throw;
            }
        }
        public static bool Eliminar(int id)
        {
            Database oDb = DatabaseFactory.CreateDatabase("gestionAlumnos");
            int result;
            try
            {
                result = oDb.ExecuteNonQuery("Alumno_Eliminar", id);
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
                Logger.WriteXMLError("Alumnos.cs", "Alumnos.cs", "Eliminar", ex.Message);
                //Console.WriteLine("Problema Al Eliminar La Localidad: " + ex.Message);
                throw;
            }
        }
        public static bool Actualizar(Alumno pAlumno)
        {
            Database oDb = DatabaseFactory.CreateDatabase("gestionAlumnos");
            int result;
            try
            {
                result = oDb.ExecuteNonQuery("Alumno_Modificar", pAlumno.nombres, pAlumno.apellidos, pAlumno.direccionID, pAlumno.tipodocumentoID, pAlumno.nrodocumento, pAlumno.telefonofijo, pAlumno.telefonocelular, pAlumno.nacionalidad, pAlumno.fechanacimiento, pAlumno.edad, pAlumno.alumnoID);
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
                Logger.WriteXMLError("Alumnos.cs", "Alumnos.cs", "Actualizar", ex.Message);
                //Console.WriteLine("Problemas Al Modificar La Localidad: " + ex.Message);
                throw;
            }
        }
        public static int Insertar(Alumno pAlumno)
        {
            Database oDb = DatabaseFactory.CreateDatabase("gestionAlumnos");
            int clienteID = -1;
            try
            {
                clienteID = int.Parse(oDb.ExecuteScalar("Alumno_Insertar", pAlumno.apellidos, pAlumno.direccionID, pAlumno.tipodocumentoID, pAlumno.nrodocumento, pAlumno.telefonofijo, pAlumno.telefonocelular, pAlumno.nacionalidad, pAlumno.fechanacimiento, pAlumno.edad).ToString());
            }
            catch (Exception ex)
            {
                Logger.WriteXMLError("Alumnos.cs", "Alumnos.cs", "Insertar", ex.Message);
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
                cli = int.Parse(oDb.ExecuteScalar("Alumno_ObtenerUltimoID").ToString());
            }
            catch (Exception ex)
            {
                Logger.WriteXMLError("Alumnos.cs", "Alumnos.cs", "ObtenerUltimoID", ex.Message);
                //Console.WriteLine("Problemas Al Obtener El Ultimo Número De Localidad: " + ex.Message);
                throw;
            }
            return cli;
        }
    }
}
