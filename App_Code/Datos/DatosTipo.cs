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
/// Descripción breve de DatosTipo
/// </summary>
public class DatosTipo
{
    public static int Alta(Tipos t)
    {
        SqlConnection cnn = new SqlConnection(Conexion.STR);
        string consulta = "AgregarTipo";
        SqlCommand cmd = new SqlCommand(consulta, cnn);
        cmd.CommandType = CommandType.StoredProcedure;
        int afectados = -1;
        SqlParameter retorno = new SqlParameter("retorno", SqlDbType.Int);
        retorno.Direction = ParameterDirection.ReturnValue;
        cmd.Parameters.Add(retorno);
        cmd.Parameters.AddWithValue("@tipo",t.Tipo);
        cmd.Parameters.AddWithValue("@minima",t.Minima);
        cmd.Parameters.AddWithValue("@maxima",t.Maxima);
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

    public static List<Tipos> Lista()
    {
        SqlConnection cnn = new SqlConnection(Conexion.STR);
        SqlCommand cmd = new SqlCommand("ListarTipo", cnn);
        cmd.CommandType = CommandType.StoredProcedure;
        try
        {
            cnn.Open();
            SqlDataReader lector = cmd.ExecuteReader();
            List<Tipos> tipos = new List<Tipos>();
            while (lector.Read())
            {
                int codigo = (int)lector["codigo"];
                string tipo = (string)lector["tipo"];
                int minima = (int)lector["minima"];
                int maxima = (int)lector["maxima"];
                Tipos t = new Tipos(codigo, tipo, minima, maxima);
                tipos.Add(t);
            }
            return tipos;
        }
        catch (Exception es)
        {
            throw new Exception("Problemas con la base de datos!!!!!! "+es.Message);
        }
        finally
        {
            cnn.Close();
        }
    }

    public static Tipos Buscar(int codigo)
    {
        string tipo = "";
        int minima = 0;
        int maxima = 0;
        Tipos t = null;
        SqlConnection cnn = new SqlConnection(Conexion.STR);
        string consulta = "BuscarTipo " + codigo;
        SqlCommand comando = new SqlCommand(consulta, cnn);
        SqlDataReader lector;
        try
        {
            cnn.Open();
            lector = comando.ExecuteReader();
            if (lector.Read())
            {
                codigo = (int)lector["codigo"];
                tipo = (string)lector["tipo"];
                minima = (int)lector["minima"];
                maxima = (int)lector["maxima"];
                t = new Tipos(codigo, tipo, minima, maxima);               
            }
            return t;
        }
        catch (Exception es)
        {
            throw new Exception("Problemas!!!!! " + es.Message);
        }
        finally
        {
            cnn.Close();
        }
    }

    public static int Baja(string tipo)
    {
        SqlConnection cnn = new SqlConnection(Conexion.STR);
        string consulta = "EliminarTipo";
        SqlCommand cmd = new SqlCommand(consulta, cnn);
        cmd.CommandType = CommandType.StoredProcedure;
        int afectados = -1;

        SqlParameter t = new SqlParameter("@tipo", tipo);       
        cmd.Parameters.Add(t);
        
        SqlParameter retorno = new SqlParameter("retorno", SqlDbType.Int);
        retorno.Direction = ParameterDirection.ReturnValue;
        cmd.Parameters.Add(retorno);
       
        try
        {
            cnn.Open();
            cmd.ExecuteNonQuery();
            afectados = (int)cmd.Parameters["retorno"].Value;
            return afectados;
        }
        catch (Exception err)
        {
            throw new Exception("Problemas!!!! " + err.Message);
        }
        finally
        {
            cnn.Close();
        }
    }

    public static int Modificacion(Tipos t)
    {
        SqlConnection cnn = new SqlConnection(Conexion.STR);
        string consulta = "ModificarTipo";
        SqlCommand cmd = new SqlCommand(consulta, cnn);
        cmd.CommandType = CommandType.StoredProcedure;
        int afectados = -1;
        SqlParameter retorno = new SqlParameter("retorno", SqlDbType.Int);
        retorno.Direction = ParameterDirection.ReturnValue;
        cmd.Parameters.Add(retorno);
        cmd.Parameters.AddWithValue("@tipo", t.Tipo);
        cmd.Parameters.AddWithValue("@min", t.Minima);
        cmd.Parameters.AddWithValue("@max", t.Maxima);
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

    public static Tipos BuscarTiposPorNombre(string tipo)
    {        
        int minima = 0;
        int maxima = 0;
        Tipos t = null;
        SqlConnection cnn = new SqlConnection(Conexion.STR);
        string consulta = "buscarTipoPorNombre";
        SqlCommand comando = new SqlCommand(consulta, cnn);
        comando.CommandType = CommandType.StoredProcedure;
        comando.Parameters.AddWithValue("@tipo", tipo);
        SqlDataReader lector;
        try
        {
            cnn.Open();
            lector = comando.ExecuteReader();
            if (lector.Read())
            {                
                tipo = (string)lector["tipo"];
                minima = (int)lector["minima"];
                maxima = (int)lector["maxima"];
                t = new Tipos( tipo, minima, maxima);
            }
            return t;
        }
        catch (Exception es)
        {
            throw new Exception("Problemas!!!!! " + es.Message);
        }
        finally
        {
            cnn.Close();
        }
    }
}
