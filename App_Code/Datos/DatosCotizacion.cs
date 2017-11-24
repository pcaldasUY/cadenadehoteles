using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Collections.Generic;
using System.Data.SqlClient;

/// <summary>
/// Descripción breve de DatosCotizacion
/// </summary>
public class DatosCotizacion
{
    public static int AltaCotizacion(Cotizacion c)
    {
        SqlConnection cnn = new SqlConnection(Conexion.STR);
        string consulta = "AltaCotizacion";
        SqlCommand cmd = new SqlCommand(consulta, cnn);
        cmd.CommandType = CommandType.StoredProcedure;
        int afectados = -1;
        SqlParameter retorno = new SqlParameter("retorno", SqlDbType.Int);
        retorno.Direction = ParameterDirection.ReturnValue;
        cmd.Parameters.Add(retorno);
        cmd.Parameters.AddWithValue("@fecha", c.Fecha);
        cmd.Parameters.AddWithValue("@dolar", c.Dolar);
        cmd.Parameters.AddWithValue("@euro", c.Euro);
        try
        {
            cnn.Open();
            cmd.ExecuteNonQuery();
            afectados = (int)cmd.Parameters["retorno"].Value;
            return afectados;
        }
        catch (Exception err)
        {
            throw new Exception("!!Problemas " + err.Message);
        }
        finally
        {
            cnn.Close();
        }
    }

    public static Cotizacion Buscar(DateTime fecha)
    {
        Cotizacion c = null;
        double dolar = 0;
        double euro = 0;

        SqlConnection cnn = new SqlConnection(Conexion.STR);
        string consulta = "BuscarCotizacion";
        SqlCommand comando = new SqlCommand(consulta, cnn);
        comando.CommandType = CommandType.StoredProcedure;
        comando.Parameters.AddWithValue("@fecha", fecha);
        SqlDataReader lector;
        try
        {
            cnn.Open();
            lector = comando.ExecuteReader();
            if (lector.Read())
            {
                dolar = (double)lector["dolar"];
                euro = (double)lector["euro"];
                c = new Cotizacion(fecha, dolar, euro);
            }
            return c;
        }
        catch (Exception es)
        {
            throw new Exception("Problemas !!!!! " + es.Message);
        }
        finally
        {
            cnn.Close();
        }
    }

    public static List<Cotizacion> listar()
    {
        SqlConnection cnn = new SqlConnection(Conexion.STR);
        SqlCommand comando = new SqlCommand("ListarCotizacion", cnn);
        comando.CommandType = CommandType.StoredProcedure;
        try
        {
            cnn.Open();
            SqlDataReader lector = comando.ExecuteReader();
            List<Cotizacion> lista = new List<Cotizacion>();
            while (lector.Read())
            {
                DateTime fecha = (DateTime)lector["fecha"];
                double dolar = (double)lector["dolar"];
                double euro = (double)lector["euro"];
                Cotizacion c = new Cotizacion(fecha, dolar, euro);
                lista.Add(c);
            }
            return lista;
        }
        catch (Exception es)
        {
            throw new Exception("Problemas con la base de datos !!!!! " + es.Message);
        }
        finally
        {
            cnn.Close();
        }
    }

    public static List<Cotizacion> listarEntreFechas(DateTime fecha1, DateTime fecha2)
    {
        SqlConnection cnn = new SqlConnection(Conexion.STR);
        string consulta = "listarCotizacionEntreFechas";
        SqlCommand comando = new SqlCommand(consulta, cnn);
        comando.CommandType = CommandType.StoredProcedure;
        comando.Parameters.AddWithValue("@fechaIni", fecha1);
        comando.Parameters.AddWithValue("@fechaFin", fecha2);
        try
        {
            cnn.Open();
            SqlDataReader lector = comando.ExecuteReader();
            List<Cotizacion> lista = new List<Cotizacion>();
            while (lector.Read())
            {
                DateTime fecha = (DateTime)lector["fecha"];
                double dolar = (double)lector["dolar"];
                double euro = (double)lector["euro"];
                Cotizacion c = new Cotizacion(fecha, dolar, euro);
                lista.Add(c);
            }
            return lista;
        }
        catch (Exception es)
        {
            throw new Exception("Problemas con la base de datos !!!!! " + es.Message);
        }
        finally
        {
            cnn.Close();
        }
    }

    public static Cotizacion BuscarCotizacionActual()
    {
        Cotizacion c = null;
        double dolar = 0;
        double euro = 0;
        DateTime fecha = DateTime.Now;

        SqlConnection cnn = new SqlConnection(Conexion.STR);
        string consulta = "BuscarCotizacionActual";
        SqlCommand comando = new SqlCommand(consulta, cnn);
        comando.CommandType = CommandType.StoredProcedure;
        SqlDataReader lector;
        try
        {
            cnn.Open();
            lector = comando.ExecuteReader();
            if (lector.Read())
            {
                fecha = (DateTime)lector["fecha"];
                dolar = (double)lector["dolar"];
                euro = (double)lector["euro"];
                c = new Cotizacion(fecha, dolar, euro);
            }
            return c;
        }
        catch (Exception es)
        {
            throw new Exception("Problemas !!!!! " + es.Message);
        }
        finally
        {
            cnn.Close();
        }
    }
}
