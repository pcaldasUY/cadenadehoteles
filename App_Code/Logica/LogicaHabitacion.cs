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
/// Descripción breve de LogicaHabitacion
/// </summary>
public class LogicaHabitacion
{
    public static bool Alta(Habitacion h)
    {
        return DatosHabitacion.Alta(h) == 1;
    }

    public static List<Habitacion> lista(long rut)
    {
        return DatosHabitacion.Lista(rut);
    }

    public static DataTable listarDisponibles(long pRut)
    {
        return DatosHabitacion.ListarHabDisponibles(pRut);
    }

    public static double ObtengoPrecio(long rut, int nro)
    {
        return DatosHabitacion.ObtengoPrecio(rut, nro);
    }
}
