using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class Default2 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Usuario"] == null)
        {
            Response.Redirect("Default.aspx");
        }
        else
        {

        }
    }
    protected void btnIngresar_Click(object sender, EventArgs e)
    {

    }
    protected void ddlNrosHabitaciones_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void ddlTipoHabitacion_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void ddlHotel_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void btnBuscar_Click(object sender, EventArgs e)
    {
        Response.Redirect("FrmListadoHabitacionesHotel");
    }
}
