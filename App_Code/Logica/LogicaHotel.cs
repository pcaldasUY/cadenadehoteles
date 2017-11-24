using System;
using System.Data;
using System.Collections.Generic;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

/// <summary>
/// Descripción breve de LogicaHotel
/// </summary>
public class LogicaHotel
{
    public static bool Alta(Hotel h)
    {
        return DatosHotel.Alta(h) > 0;
    }

    public static List<Hotel> Listado()
    {
        List<Hotel> listado = new List<Hotel>();
        List<Hotel> hoteles = DatosHotel.Listado();
        listado.AddRange(hoteles);
        return listado;
    }

    public static Hotel buscar(long rut)
    {
        return DatosHotel.Buscar(rut);
    }

    public static List<string> ListadoDeImganes(long pRut)
    {
        List<string> imagenes = DatosHotel.ListadoDeImganes(pRut);
        return imagenes;
    }

    public static List<long> ListadoDeTelefonos(long pRut)
    {
        List<long> telefonos = DatosHotel.ListadoDeTelefonos(pRut);
        return telefonos;
    }

}