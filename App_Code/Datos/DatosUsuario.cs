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

/// <summary>
/// Descripción breve de DatosUsuario
/// </summary>
public class DatosUsuario
{
    public static int CambioClave(long pCi, string pClave, string pNuevaClave)
    {
        int afectados = -1;
        SqlConnection cnn = new SqlConnection(Conexion.STR);
        SqlCommand comando = new SqlCommand();
        comando.Connection = cnn;
        comando.CommandType = CommandType.StoredProcedure;
        comando.CommandText = "CambioPassword";
        SqlParameter ci = new SqlParameter("@ci", pCi);
        SqlParameter clave = new SqlParameter("@clave", pClave);
        SqlParameter nuevaClave = new SqlParameter("@nuevaClave", pNuevaClave);
        SqlParameter retorno = new SqlParameter("retorno", SqlDbType.Int);
        retorno.Direction = ParameterDirection.ReturnValue;
        comando.Parameters.Add(ci);
        comando.Parameters.Add(clave);
        comando.Parameters.Add(nuevaClave);
        comando.Parameters.Add(retorno);
        try
        {
            cnn.Open();
            comando.ExecuteNonQuery();
            afectados = (int)comando.Parameters["retorno"].Value;
            return afectados;
        }
        catch (Exception es)
        {
            throw new Exception ("Problemas !!!!! " + es.Message);
        }
        finally
        {
            cnn.Close();
        }
    }
}
