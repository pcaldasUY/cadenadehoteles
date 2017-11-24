using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using System.Collections.Generic;

/// <summary>
/// Descripción breve de DatosAdministrador
/// </summary>
public class DatosAdministrador
{
    public static int ClaveCorrecta(long pCi, string pClave)
    {
        SqlConnection cnn = new SqlConnection(Conexion.STR);
        SqlCommand comando = new SqlCommand();
        comando.Connection = cnn;
        comando.CommandType = CommandType.StoredProcedure;
        comando.CommandText = "claveCorrectaAdministrador";
        SqlParameter ci = new SqlParameter("@ci", pCi);
        SqlParameter clave = new SqlParameter("@clave", pClave);
        SqlParameter retorno = new SqlParameter("retorno", SqlDbType.Int);
        retorno.Direction = ParameterDirection.ReturnValue;
        comando.Parameters.Add(ci);
        comando.Parameters.Add(clave);
        comando.Parameters.Add(retorno);
        try
        {
            cnn.Open();
            SqlDataReader lector = comando.ExecuteReader();
            lector.Read();
            return (int)retorno.Value;
        }
        catch (Exception es)
        {
            throw new Exception("Problemas !!!!!!! " + es.Message);
        }
        finally
        {
            cnn.Close();
        }
    }

    public static int EsAdministrador(long pCi)
    {
        SqlConnection cnn = new SqlConnection(Conexion.STR);
        SqlCommand comando = new SqlCommand();
        comando.Connection = cnn;
        comando.CommandType = CommandType.StoredProcedure;
        comando.CommandText = "EsAdministrador";
        SqlParameter ci = new SqlParameter("@ci", pCi);
        SqlParameter retorno = new SqlParameter("retorno", SqlDbType.Int);
        retorno.Direction = ParameterDirection.ReturnValue;
        comando.Parameters.Add(ci);
        comando.Parameters.Add(retorno);
        try
        {
            cnn.Open();
            SqlDataReader lector = comando.ExecuteReader();
            lector.Read();
            return (int)retorno.Value;
        }
        catch (Exception es)
        {
            throw new Exception("Problemas !!!!!!! " + es.Message);
        }
        finally
        {
            cnn.Close();
        }
    }

    public static string NombreAdministrador(long pci)
    {
        string nombre = "";
        SqlConnection cnn = new SqlConnection(Conexion.STR);
        string consulta = "NombreAdministrador " + pci;
        SqlCommand comando = new SqlCommand(consulta, cnn);
        SqlDataReader lector;
        try
        {
            cnn.Open();
            lector = comando.ExecuteReader();
            if (lector.Read())
            {
                nombre = (string)lector["nombre"];
            }
            return nombre;
        }
        catch (Exception es)
        {
            throw new Exception("Problemas !!!!!!! " + es.Message);
        }
        finally
        {
            cnn.Close();
        }
    }

    public static int AgregarAdministrador(Administrador a)
    {
        SqlConnection cnn = new SqlConnection(Conexion.STR);
        string consulta = "AltaAdministrador";
        SqlCommand comando = new SqlCommand(consulta, cnn);
        comando.CommandType = CommandType.StoredProcedure;
        SqlParameter ci = new SqlParameter("@ci", a.Cedula);
        SqlParameter nombre = new SqlParameter("@nombre", a.Nombre);
        SqlParameter cargo = new SqlParameter("@cargo", a.Cargo);
        SqlParameter retorno = new SqlParameter("retorno", SqlDbType.Int);
        retorno.Direction = ParameterDirection.ReturnValue;
        comando.Parameters.Add(ci);
        comando.Parameters.Add(nombre);
        comando.Parameters.Add(cargo);
        comando.Parameters.Add(retorno);
        int afectados = -1;
        try
        {
            cnn.Open();
            comando.ExecuteNonQuery();
            afectados = (int)comando.Parameters["retorno"].Value;
        }
        catch (Exception es)
        {
            throw new Exception("Problemas con la base de datos!!!!! " + es.Message);
        }
        finally
        {
            cnn.Close();
        }
        return afectados;
    }

    public static int EliminoAdministrador(long pCi)
    {
        SqlConnection cnn = new SqlConnection(Conexion.STR);
        string consulta = "BajaAdministrador";
        SqlCommand comando = new SqlCommand(consulta, cnn);
        comando.CommandType = CommandType.StoredProcedure;
        SqlParameter ci = new SqlParameter("@ci", pCi);
        SqlParameter retorno = new SqlParameter("retorno", SqlDbType.Int);
        retorno.Direction = ParameterDirection.ReturnValue;
        comando.Parameters.Add(ci);
        comando.Parameters.Add(retorno);
        int afectados = -1;
        try
        {
            cnn.Open();
            comando.ExecuteNonQuery();
            afectados = (int)comando.Parameters["retorno"].Value;
        }
        catch (Exception es)
        {
            throw new Exception("Problemas con la base de datos!!!!! " + es.Message);
        }
        finally
        {
            cnn.Close();
        }
        return afectados;
    }

    public static int ModificoAdministrador(Administrador a)
    {
        SqlConnection cnn = new SqlConnection(Conexion.STR);
        string consulta = "ModificacionAdministrador";
        SqlCommand comando = new SqlCommand(consulta, cnn);
        comando.CommandType = CommandType.StoredProcedure;
        comando.Parameters.AddWithValue("@ci", a.Cedula);
        comando.Parameters.AddWithValue("@nombre", a.Nombre);
        comando.Parameters.AddWithValue("@cargo", a.Cargo);
        SqlParameter retorno = new SqlParameter("retorno", SqlDbType.Int);
        retorno.Direction = ParameterDirection.ReturnValue;
        comando.Parameters.Add(retorno);
        int afectados = -1;
        try
        {
            cnn.Open();
            comando.ExecuteNonQuery();
            afectados = (int)comando.Parameters["retorno"].Value;
        }
        catch (Exception es)
        {
            throw new Exception("Problemas con la base de datos!!!!! " + es.Message);
        }
        finally
        {
            cnn.Close();
        }
        return afectados;
    }

    public static List<Administrador> ListarAdministrador()
    {
        SqlConnection cnn = new SqlConnection(Conexion.STR);
        SqlCommand comando = new SqlCommand("ListarAdministrador", cnn);
        comando.CommandType = CommandType.StoredProcedure;
        try
        {
            cnn.Open();
            SqlDataReader lector = comando.ExecuteReader();
            List<Administrador> lista = new List<Administrador>();
            while (lector.Read())
            {
                long ci = (long)lector["cedula"];
                string nombre = (string)lector["nombre"];
                string cargo = (string)lector["cargo"];
                string password = (string)lector["password"];
                Administrador a = new Administrador(ci, nombre, password, cargo);
                lista.Add(a);
            }
            return lista;
        }
        catch (Exception es)
        {
            throw new Exception("Problemas con la base de datos. " + es.Message);
        }
        finally
        {
            cnn.Close();
        }
    }

    public static Administrador BuscarAdministradorPorCedula(long pCi)
    {
        string nombre = "";
        string cargo = "";
        Administrador a = null;
        SqlConnection cnn = new SqlConnection(Conexion.STR);
        string consulta = "BuscarAdministrador";
        SqlCommand comando = new SqlCommand(consulta, cnn);
        comando.CommandType = CommandType.StoredProcedure;
        comando.Parameters.AddWithValue("@ci", pCi);
        SqlDataReader lector;
        try
        {
            cnn.Open();
            lector = comando.ExecuteReader();
            if (lector.Read())
            {
                nombre = (string)lector["nombre"];
                cargo = (string)lector["cargo"];
                a = new Administrador(pCi, nombre, cargo);
            }
            return a;
        }
        catch (Exception es)
        {
            throw new Exception("Problemas !!!! " + es.Message);
        }
        finally
        {
            cnn.Close();
        }
    }
}