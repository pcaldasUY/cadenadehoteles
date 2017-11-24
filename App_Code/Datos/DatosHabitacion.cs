using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections.Generic;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

/// <summary>
/// Descripción breve de DatosHabitacion
/// </summary>
public class DatosHabitacion
{
    public static int Alta(Habitacion h)
    {
        SqlConnection cnn = new SqlConnection(Conexion.STR);
        string consulta = "AgregarHabitacion";
        SqlCommand cmd = new SqlCommand(consulta, cnn);
        cmd.CommandType = CommandType.StoredProcedure;
        int afectados = -1;
        SqlParameter retorno = new SqlParameter("retorno", SqlDbType.Int);
        retorno.Direction = ParameterDirection.ReturnValue;
        cmd.Parameters.Add(retorno);      
        cmd.Parameters.AddWithValue("@numero", h.Numero);
        cmd.Parameters.AddWithValue("@piso", h.Piso);
        cmd.Parameters.AddWithValue("@balcon", h.Balcon);
        cmd.Parameters.AddWithValue("@precio", h.Precio);
        cmd.Parameters.AddWithValue("@rut", h.TieneHabitaciones.Rut);
        cmd.Parameters.AddWithValue("@codigo", h.EsDeTipo.Codigo);
        cmd.Parameters.AddWithValue("@disponible", h.Disponible);

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

    public static List<Habitacion> Lista(long rut)
    {        
        SqlConnection cnn = new SqlConnection(Conexion.STR);
        string consulta = "ListarHabitacionesDeHotel";
        SqlCommand comando = new SqlCommand(consulta, cnn);
        comando.CommandType = CommandType.StoredProcedure;
        comando.Parameters.AddWithValue("@rut", rut);               
        try
        {
            Hotel h = DatosHotel.Buscar(rut);
            cnn.Open();
            SqlDataReader lector = comando.ExecuteReader();
            List<Habitacion> lista = new List<Habitacion>();
            while (lector.Read())
            {
                int numero = (int)lector["numero"];
                int piso = (int)lector["piso"];
                bool balcon = (bool)lector["balcon"];
                int codigo = (int)lector["codigo"];
                double precio = (double)lector["precio"];
                bool disponible = (bool)lector["disponible"];
                Tipos t = DatosTipo.Buscar(codigo);
                Habitacion hab = new Habitacion(numero, piso, balcon, precio, h, t,disponible);
                lista.Add(hab);
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

    public static DataTable ListarHabDisponibles(long pRut)
    {
        SqlConnection cnn = new SqlConnection(Conexion.STR);
        //SqlCommand cmd = new SqlCommand("ListarDiponibilidadesPorHotel", cnn);
        
        
        try
        {
            cnn.Open();
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = new SqlCommand("ListarDiponibilidadesPorHotel " + pRut, cnn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            //while (dr.Read())
            //{
            //    int numero = (int)dr["numero"];
            //    int piso = (int)dr["piso"];
            //    bool balcon = (bool)dr["balcon"];
            //    double precio = (double)dr["precio"];
            //    //int codigo = (int)dr["codigo"];
            //    string tipo = (string)dr["tipo"];
            //    string nombre = (string)dr["nombre"];
            //    bool disponible = (bool)dr["disponible"];
            //    Habitacion h = new Habitacion(numero, piso, balcon, precio, tipo, nombre, disponible);
            //    //Hotel h = DatosHotel.Buscar(pRut);
            //    //Tipos t = DatosTipo.Buscar(codigo);
            //    //Habitacion habDisponibles = new Habitacion(numero, piso, balcon, precio, h, t, disponible);
            //    lista.Add(h);
            //}
            return dt;
        }
        catch (Exception err)
        {
            throw new Exception("Problemas con la base de datos !!! " + err.Message);
        }
    }

    public static double ObtengoPrecio(long rut, int nro)
    {
        double precio = -1;
        SqlConnection cnn = new SqlConnection(Conexion.STR);
        string consulta = "ObtengoPrecio";
        SqlCommand comando = new SqlCommand(consulta, cnn);
        comando.CommandType = CommandType.StoredProcedure;
        comando.Parameters.AddWithValue("@rut", rut);
        comando.Parameters.AddWithValue("@numero", nro);
        SqlDataReader lector;
        try
        {
            cnn.Open();
            lector = comando.ExecuteReader();
            if (lector.Read())
            {
                precio=(double) lector["precio"];               
            }
            return precio;
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