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

/// <summary>
/// Descripción breve de LogicaCotizacion
/// </summary>
public class LogicaCotizacion
{
    public static bool AltaCotizacion(Cotizacion c)
    {
        return DatosCotizacion.AltaCotizacion(c) == 1;
    }

    public static Cotizacion Buscar(DateTime fecha)
    {
        return DatosCotizacion.Buscar(fecha);
    }

    public static List<Cotizacion> Listar()
    {
        return DatosCotizacion.listar();
    }

    public static List<Cotizacion> ListarEntreFechas(DateTime fecha1, DateTime fecha2)
    {
        return DatosCotizacion.listarEntreFechas(fecha1, fecha2);
    }

    public static Cotizacion BuscarCotizacionActual()
    {
        return DatosCotizacion.BuscarCotizacionActual();
    }
}
