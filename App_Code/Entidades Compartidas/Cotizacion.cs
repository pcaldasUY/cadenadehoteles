using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

/// <summary>
/// Descripción breve de Cotizacion
/// </summary>
public class Cotizacion
{
    DateTime fecha = DateTime.Now;
    double dolar = 0;
    double euro = 0;

    public DateTime Fecha
    {
        get { return fecha; }
        set { fecha = value; }
    }

    public double Dolar
    {
        get { return dolar; }
        set { dolar = value; }
    }

    public double Euro
    {
        get { return euro; }
        set { euro = value; }
    }

    public Cotizacion()
    {
        fecha = DateTime.Now;
        dolar = 0;
        euro = 0;
    }

    public Cotizacion(DateTime pFecha, double pDolar, double pEuro)
    {
        string error = "";
        if (pDolar <= 0)
        {
            error = "El valor del dolar debe ser mayor a 0. ";
        }
        if (pEuro <= 0)
        {
            error = error + "El valor del euro debe ser mayor a 0. ";
        }
        if (error == "")
        {
            fecha = pFecha;
            dolar = pDolar;
            euro = pEuro;
        }
        else
        {
            throw new Exception(error);
        }
    }

    public override string ToString()
    {
        return "Fecha: "+fecha+" Dolar: "+dolar+" Euro: "+euro;
    }
}
