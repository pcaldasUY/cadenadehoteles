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
/// Descripción breve de LogicaPromocion
/// </summary>
public class LogicaPromocion
{
    public static bool Alta(Promociones p) {
        return DatosPromocion.Alta(p) == 1;
    }

    public static List<Promociones> listadoVigentes() {
        return DatosPromocion.listarVigentes();
    }
}
