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
/// Descripción breve de LogicaTipo
/// </summary>
public class LogicaTipo
{
    public static bool Alta(Tipos t)
    {
        return DatosTipo.Alta(t) == 1;
    }


    public static List<Tipos> Lista()
    {
        return DatosTipo.Lista();
    }

    public static Tipos Buscar(int codigo)
    {
        return DatosTipo.Buscar(codigo);
    }

    public static int Baja(string tipo)
    {
        return DatosTipo.Baja(tipo);
    }

    public static int Modificacion(Tipos t)
    {
        return DatosTipo.Modificacion(t);
    }

    public static Tipos BuscarTiposPorNombre(string tipo)
    {
        return DatosTipo.BuscarTiposPorNombre(tipo);
    }
}
