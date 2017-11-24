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
/// Descripción breve de DatosRegistrado
/// </summary>
public class DatosRegistrado
{
    public static int ClaveCorrecta(long pCi, string pClave)
    {
        SqlConnection cnn = new SqlConnection(Conexion.STR);
        SqlCommand comando = new SqlCommand();
        comando.Connection = cnn;
        comando.CommandType = CommandType.StoredProcedure;
        comando.CommandText = "claveCorrectaRegistrado";
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

    public static int EsRegistrado(long pCi)
    {
        SqlConnection cnn = new SqlConnection(Conexion.STR);
        SqlCommand comando = new SqlCommand();
        comando.Connection = cnn;
        comando.CommandType = CommandType.StoredProcedure;
        comando.CommandText = "EsRegistrado";
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

    public static string NombreRegistrado(long pci)
    {
        string nombre = "";
        SqlConnection cnn = new SqlConnection(Conexion.STR);
        string consulta = "NombreRegistrado " + pci;
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

    public static int Alta(Registrado r)
    {
        SqlConnection cnn = new SqlConnection(Conexion.STR);
        string consulta = "AltaRegistrado";
        SqlCommand comando = new SqlCommand(consulta, cnn);
        comando.CommandType = CommandType.StoredProcedure;
        SqlParameter ci = new SqlParameter("@ci", r.Cedula);
        SqlParameter nombre = new SqlParameter("@nombre", r.Nombre);
        SqlParameter password = new SqlParameter("@password", r.Password);
        SqlParameter sexo = new SqlParameter("@sexo", r.Sexo);
        SqlParameter tarjeta = new SqlParameter("@tarjeta", r.Tarjeta);
        SqlParameter retorno = new SqlParameter("retorno", SqlDbType.Int);
        retorno.Direction = ParameterDirection.ReturnValue;
        comando.Parameters.Add(ci);
        comando.Parameters.Add(nombre);
        comando.Parameters.Add(password);
        comando.Parameters.Add(sexo);
        comando.Parameters.Add(tarjeta);
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
            throw new Exception("Problemas con la base de datos. " + es.Message);
        }
        finally
        {
            cnn.Close();
        }
        return afectados;
    }

    public static List<Registrado> ListarRegistrados()
    {
        SqlConnection cnn = new SqlConnection(Conexion.STR);
        SqlCommand comando = new SqlCommand("ListarRegistrados", cnn);
        comando.CommandType = CommandType.StoredProcedure;
        try
        {
            cnn.Open();
            SqlDataReader lector = comando.ExecuteReader();
            List<Registrado> lista = new List<Registrado>();
            while (lector.Read())
            {
                long ci = (long)lector["cedula"];
                string nombre = (string)lector["nombre"];
                bool sexo = (bool)lector["sexo"];
                long tarjeta = (long)lector["tarjeta"];
                string password = (string)lector["password"];
                Registrado r = new Registrado(ci, nombre, password, sexo, tarjeta);
                lista.Add(r);
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

    public static int Modificion(Registrado r)
    {
        SqlConnection cnn = new SqlConnection(Conexion.STR);
        string consulta = "ModificacionRegistrado";
        SqlCommand comando = new SqlCommand(consulta, cnn);
        comando.CommandType = CommandType.StoredProcedure;
        comando.Parameters.AddWithValue("@ci", r.Cedula);
        comando.Parameters.AddWithValue("@nombre", r.Nombre);
        comando.Parameters.AddWithValue("@sexo", r.Sexo);
        comando.Parameters.AddWithValue("@tarjeta", r.Tarjeta);
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


    public static Registrado BuscarRegistrado(long pCi)
    {
        string nombre = "";
        bool sexo = true;
        long tarjeta = 0;
        string password = "";
        Registrado r = null;
        SqlConnection cnn = new SqlConnection(Conexion.STR);
        string consulta = "BuscarRegistrado";
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
                sexo = (bool)lector["sexo"];
                tarjeta = (long)lector["tarjeta"];
                password = (string)lector["password"];
                r = new Registrado(pCi, nombre, password, sexo, tarjeta);
            }
            return r;
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