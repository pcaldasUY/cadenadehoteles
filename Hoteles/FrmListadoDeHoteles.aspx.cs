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

public partial class FrmListadoDeHoteles : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            List<Hotel> lista = LogicaHotel.Listado();
            if (lista != null)
            {
                grdListaDeHoteles.DataSource = lista;
                grdListaDeHoteles.DataBind();
            }
            else
            {
                lblError.Text = "No hay hoteles cargados. ";
            }
        }
    }

    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {
        long rutElegido = Convert.ToInt64(grdListaDeHoteles.SelectedRow.Cells[0].Text);
        Session["listatelefonos"] = LogicaHotel.ListadoDeTelefonos(rutElegido);
        Session["listaimagenes"] = LogicaHotel.ListadoDeImganes(rutElegido);
        Response.Redirect("frmTelefonosEImagenes.aspx");
    }

    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        long cedula = (long)Session["Usuario"];
        if (LogicaUsuario.EsAdministrador(cedula))
        {
            Response.Redirect("FrmPrincipalAdministrador.aspx");
        }
        else
        {
            if (LogicaUsuario.EsRegistrado(cedula))
            {
                Response.Redirect("FrmPrincipalRegistrado.aspx");
            }
            else
            {
                Response.Redirect("Default.aspx");
            }
        }
    }
}
