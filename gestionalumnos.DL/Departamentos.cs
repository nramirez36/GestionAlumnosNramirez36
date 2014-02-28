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
    public class Departamentos
    {
        public static IEnumerable<Departamento> Listar(int pCodProvincia)
        {
            Database odb = DatabaseFactory.CreateDatabase("gestionAlumnos");
            try
            {
                return odb.ExecuteSprocAccessor("Departamento_Listar", MapBuilder<Departamento>.MapAllProperties().Build(), pCodProvincia);
            }
            catch (Exception ex)
            {
                Logger.WriteXMLError("Departamentos.cs", "Departamentos.cs", "Listar", ex.Message);
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
                result = oDb.ExecuteNonQuery("Deparamento_Eliminar", id);
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
                Logger.WriteXMLError("Departamentos.cs", "Departamentos.cs", "Eliminar", ex.Message);
                //Console.WriteLine("Problema Al Eliminar La Localidad: " + ex.Message);
                throw;
            }
        }
        public static bool Actualizar(Departamento pDepartamento)
        {
            Database oDb = DatabaseFactory.CreateDatabase("gestionAlumnos");
            int result;
            try
            {
                result = oDb.ExecuteNonQuery("Departamento_Modificar", pDepartamento.nombre, pDepartamento.provincia_id,pDepartamento.id);
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
                Logger.WriteXMLError("Departamentos.cs", "Departamentos.cs", "Actualizar", ex.Message);
                //Console.WriteLine("Problemas Al Modificar La Localidad: " + ex.Message);
                throw;
            }
        }
        public static int Insertar(Departamento pDepartamento)
        {
            Database oDb = DatabaseFactory.CreateDatabase("gestionAlumnos");
            int clienteID = -1;
            try
            {
                clienteID = int.Parse(oDb.ExecuteScalar("Departamento_Insertar", pDepartamento.nombre, pDepartamento.provincia_id).ToString());
            }
            catch (Exception ex)
            {
                Logger.WriteXMLError("Departamentos.cs", "Departamentos.cs", "Insertar", ex.Message);
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
                cli = int.Parse(oDb.ExecuteScalar("Departamento_ObtenerUltimoID").ToString());
            }
            catch (Exception ex)
            {
                Logger.WriteXMLError("Departamentos.cs", "Departamentos.cs", "ObtenerUltimoID", ex.Message);
                //Console.WriteLine("Problemas Al Obtener El Ultimo Número De Localidad: " + ex.Message);
                throw;
            }
            return cli;
        }
    }
}
