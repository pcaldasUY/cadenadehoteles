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
/// Descripción breve de DatosHotel
/// </summary>
public class DatosHotel
{
    public static int Alta(Hotel h)
    {
        SqlConnection cnn = new SqlConnection(Conexion.STR);
        SqlCommand cmd = new SqlCommand();
        cmd.CommandText = "AltaDeHotel";
        cmd.Connection = cnn;
        cmd.CommandType = CommandType.StoredProcedure;
        
        SqlParameter rut = new SqlParameter("@rut", h.Rut);
        SqlParameter nombre = new SqlParameter("@nombre", h.Nombre);
        SqlParameter direccion = new SqlParameter("@direccion", h.Direccion);
        SqlParameter ciudad = new SqlParameter("@ciudad", h.Ciudad);
        SqlParameter desayuno = new SqlParameter("@desayuno", h.Desayuno);
        SqlParameter piscinaClimatizada = new SqlParameter("@piscinaClimatizada", h.PiscinaClimatizada);
        SqlParameter piscinaExterna = new SqlParameter("@piscinaExterna", h.PiscinaExterna);
        SqlParameter solarium = new SqlParameter("@solarium", h.Solarium);

        SqlParameter retorno = new SqlParameter("retorno",SqlDbType.Int);
        retorno.Direction = ParameterDirection.ReturnValue;
        
        cmd.Parameters.Add(rut);
        cmd.Parameters.Add(nombre);
        cmd.Parameters.Add(direccion);
        cmd.Parameters.Add(ciudad);
        cmd.Parameters.Add(desayuno);
        cmd.Parameters.Add(piscinaClimatizada);
        cmd.Parameters.Add(piscinaExterna);
        cmd.Parameters.Add(solarium);
        cmd.Parameters.Add(retorno);

        int afectados = -1;
        try
        {
            cnn.Open();
            cmd.ExecuteNonQuery();
            afectados = (int)cmd.Parameters["retorno"].Value;
            if (afectados > 0)
            {
                SqlParameter telefonos = null;

                long tel = 0;
                for (int i = 0; i < h.Telefonos.Count; i++)
                {
                    cmd = new SqlCommand();
                    cmd.CommandText = "CargarTelefonosHotel";
                    cmd.Connection = cnn;
                    cmd.CommandType = CommandType.StoredProcedure;

                    rut = new SqlParameter("@rut", h.Rut);
                    tel = Convert.ToInt64(h.Telefonos[i].ToString());
                    telefonos = new SqlParameter("@tel", tel);

                    retorno = new SqlParameter("retorno", SqlDbType.Int);
                    retorno.Direction = ParameterDirection.ReturnValue;

                    cmd.Parameters.Add(rut);
                    cmd.Parameters.Add(telefonos);
                    cmd.Parameters.Add(retorno);
                    cmd.ExecuteNonQuery();
                    afectados = (int)cmd.Parameters["retorno"].Value;
                }

                SqlParameter imagenes = null;

                string img = "";
                for (int i = 0; i < h.Fotos.Count; i++)
                {
                    cmd = new SqlCommand();
                    cmd.CommandText = "CargarFotosHotel";
                    cmd.Connection = cnn;
                    cmd.CommandType = CommandType.StoredProcedure;

                    rut = new SqlParameter("@rut", h.Rut);
                    img = h.Fotos[i].ToString();
                    imagenes = new SqlParameter("@imagenes", img);

                    retorno = new SqlParameter("retorno", SqlDbType.Int);
                    retorno.Direction = ParameterDirection.ReturnValue;

                    cmd.Parameters.Add(rut);
                    cmd.Parameters.Add(imagenes);
                    cmd.Parameters.Add(retorno);
                    cmd.ExecuteNonQuery();
                    afectados = (int)cmd.Parameters["retorno"].Value;
                }
            }
            else
            {
                throw new Exception("Problemas!!!... El hotel ya existe. ");
            }
        }
        catch (Exception es)
        {
            throw new Exception("Problemas con la BD " + es.Message);
        }
        finally
        {
            cnn.Close();
        }
        return afectados;
    }

    public static List<Hotel> Listado()
    {
        Hotel h=null;
        SqlConnection cnn = new SqlConnection(Conexion.STR);
        SqlCommand cmd = new SqlCommand("ListadoDeHoteles", cnn);
        cmd.CommandType = CommandType.StoredProcedure;
        SqlDataReader lector;
        try
        {
            cnn.Open();
            lector = cmd.ExecuteReader();
            List<Hotel> lista = new List<Hotel>();
            while (lector.Read())
            {
                long rut = (long)lector["rut"];
                string nombre = (string)lector["nombre"];
                string direccion = (string)lector["direccion"];
                string ciudad = (string)lector["ciudad"];
                string desayuno = (string)lector["desayuno"];
                bool piscinaCli = (bool)lector["piscinaClimatizada"];
                bool piscinaExt=(bool)lector["piscinaExterna"]; 
                bool solarium = (bool)lector["solarium"];
                h=new Hotel(rut,nombre,direccion,ciudad,desayuno,piscinaCli,piscinaExt,solarium);
                lista.Add(h);               
            }
            return lista;
        }
        catch (Exception err)
        {
            throw new Exception("Problemas con la BD " + err.Message);
        }
        finally
        {
            cnn.Close();
        }
    }

    public static Hotel Buscar(long rut)
    {       
        string nombre = "";
        string direccion = "";
        string ciudad = "";
        string desayuno = "";
        bool piscinaClim = true;
        bool piscinaExt = true;
        bool solarium = true;
        Hotel h = null;
        SqlConnection cnn = new SqlConnection(Conexion.STR);
        string consulta = "BuscarHotel "+rut;
        SqlCommand comando = new SqlCommand(consulta, cnn);
        SqlDataReader lector;
        try
        {
            cnn.Open();
            lector = comando.ExecuteReader();
            if (lector.Read())
            {
                rut = (long)lector["rut"];
                nombre = (string)lector["nombre"];
                direccion = (string)lector["direccion"];
                ciudad = (string)lector["ciudad"];
                desayuno = (string)lector["desayuno"];
                piscinaClim = (bool)lector["piscinaClimatizada"];
                piscinaExt = (bool)lector["piscinaExterna"];
                solarium = (bool)lector["solarium"];
                h = new Hotel(rut, nombre, direccion, ciudad, desayuno, piscinaClim, piscinaExt, solarium);
            }
            return h;
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

    public static List<string> ListadoDeImganes(long pRut)
    {
        SqlConnection cnn = new SqlConnection(Conexion.STR);
        SqlCommand cmd = new SqlCommand("ListadoDeImagenes", cnn);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@rut", pRut);
        SqlDataReader lector;
        try
        {
            cnn.Open();
            lector = cmd.ExecuteReader();
            List<string> ImagenesDelHotel = new List<string>();
            while (lector.Read())
            {
                string imagen = (string)lector["imagen"];
                ImagenesDelHotel.Add(imagen);
            }
            return ImagenesDelHotel;
        }
        catch (Exception err)
        {
            throw new Exception("Problemas con la BD " + err.Message);
        }
        finally
        {
            cnn.Close();
        }
    }

    public static List<long> ListadoDeTelefonos(long pRut)
    {
        SqlConnection cnn = new SqlConnection(Conexion.STR);
        SqlCommand cmd = new SqlCommand("ListadoDeTelefonos", cnn);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@rut", pRut);
        SqlDataReader lector;
        try
        {
            cnn.Open();
            lector = cmd.ExecuteReader();
            List<long> telefonosDelHotel = new List<long>();
            while (lector.Read())
            {
                long nro = (long)lector["nroTelefono"];
                telefonosDelHotel.Add(nro);
            }
            return telefonosDelHotel;
        }
        catch (Exception err)
        {
            throw new Exception("Problemas con la BD " + err.Message);
        }
        finally
        {
            cnn.Close();
        }
    }
}
