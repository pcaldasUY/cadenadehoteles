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
using System.Collections.Generic;

public partial class frmListadoDisponibilidadPorHotel : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            List<Hotel> h = LogicaHotel.Listado();
            ddlHoteles.DataSource = h;
            ddlHoteles.DataTextField = "Nombre";
            ddlHoteles.DataValueField = "rut";
            ddlHoteles.DataBind();
            ddlHoteles.Items.Insert(0, "...Elegir Hotel...");
        }
    }

    protected void ddlHoteles_SelectedIndexChanged(object sender, EventArgs e)
    {
        lblerror.Text = "";
        long rut = 0;
        try
        {
            rut = Convert.ToInt64(ddlHoteles.SelectedValue);
        }
        catch
        {
            lblerror.Text = "Este hotel no existe. ";
        }
        DataTable disponibles = LogicaHabitacion.listarDisponibles(rut);
        if (disponibles != null)
        {
            grdListado.DataSource = disponibles;
            grdListado.DataBind();
        }
        else
        {
            lblerror.Text = "No hay Habitaciones disponibles para el Hotel seleccionado. ";
        }
    }
    protected void grdListado_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}
