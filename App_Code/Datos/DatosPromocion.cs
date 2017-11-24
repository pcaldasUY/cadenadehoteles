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
/// Descripción breve de DatosPromocion
/// </summary>
public class DatosPromocion
{
    public static int Alta(Promociones p)
    {
        SqlConnection cnn = new SqlConnection(Conexion.STR);
        string consulta = "AgregarPromociones";
        SqlCommand comando = new SqlCommand(consulta, cnn);
        comando.CommandType = CommandType.StoredProcedure;
        int afectados = -1;
        SqlParameter retorno = new SqlParameter("retorno", SqlDbType.Int);
        retorno.Direction = ParameterDirection.ReturnValue;
        comando.Parameters.Add(retorno);
        comando.Parameters.AddWithValue("@fechaInicio", p.FechaInicio);
        comando.Parameters.AddWithValue("@fechaFin", p.FechaFin);
        comando.Parameters.AddWithValue("@dias",p.Dias);
        comando.Parameters.AddWithValue("@pasajeros", p.Pasajeros);
        comando.Parameters.AddWithValue("@titulo", p.Titulo);
        comando.Parameters.AddWithValue("@comentario", p.Comentario);
        comando.Parameters.AddWithValue("@precio", p.Precio);
        comando.Parameters.AddWithValue("@rut", p.TienePromociones.Rut);
        comando.Parameters.AddWithValue("@codigo", p.Forma.Codigo);
        try
        {
            cnn.Open();
            comando.ExecuteNonQuery();
            afectados = (int)comando.Parameters["retorno"].Value;
            return afectados;
        }
        catch (Exception es)
        {
            throw new Exception("Problemas !!!!!!!! " + es.Message); 
        }
        finally
        {
            cnn.Close();
        }
    }

    public static List<Promociones> listarVigentes()
    {
        SqlConnection cnn = new SqlConnection(Conexion.STR);
        string consulta = "promocionesVigentes";
        SqlCommand comando = new SqlCommand(consulta, cnn);
        comando.CommandType = CommandType.StoredProcedure;        
        try
        {
            cnn.Open();
            SqlDataReader lector = comando.ExecuteReader();
            List<Promociones> lista = new List<Promociones>();
            while (lector.Read())
            {
                int nro=(int)lector["nro"];
                DateTime fechaInicio = (DateTime)lector["fechaInicio"];
                DateTime fechaFin = (DateTime)lector["fechaFin"];
                int dias = (int)lector["dias"];
                int pasajeros = (int)lector["pasajeros"];
                string titulo = (string)lector["titulo"];
                string comentario = (string)lector["comentario"];
                double precio = (double)lector["precio"];
                long rut = (long)lector["rut"];
                Hotel h = DatosHotel.Buscar(rut);
                int codigo = (int)lector["codigo"];
                Tipos t = DatosTipo.Buscar(codigo);
                Promociones p = new Promociones(nro, fechaInicio, fechaFin, dias, pasajeros, titulo, comentario, precio, h, t);               
                lista.Add(p);
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
}
