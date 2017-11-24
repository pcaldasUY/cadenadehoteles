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

public partial class FrmListadoHabitacionesHotel : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            List<Hotel> lista = LogicaHotel.Listado();
            if (lista.Count > 0)
            {
                ddlHotel.DataSource = lista;
                ddlHotel.DataTextField = "Nombre";
                ddlHotel.DataValueField = "Rut";
                ddlHotel.DataBind();
            }
            else
            {
                lblError.Text = "No hay hoteles. ";
            }
        }
    }

    protected void btnBuscar_Click(object sender, EventArgs e)
    {
        long rut = Convert.ToInt64(ddlHotel.SelectedValue);
        List<Habitacion> lista = LogicaHabitacion.lista(rut);
        if (lista != null)
        {
            lstHabitaciones.Items.Clear();
            for (int i = 0; i < lista.Count; i++)
            {
                lstHabitaciones.Items.Add(lista[i].ToString());
            }
        }
        else
        {
            lblError.Text = "No hay habitaciones cargados para ese hotel. ";
        }
    }
    protected void ddlHotel_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}
