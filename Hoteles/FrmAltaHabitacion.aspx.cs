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

public partial class FrmAltaHabitacion : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            List<Hotel> listaHotel = LogicaHotel.Listado();
            if (listaHotel.Count > 0)
            {
                ddlHotel.DataSource = listaHotel;
                ddlHotel.DataTextField = "nombre";
                ddlHotel.DataValueField = "rut";
                ddlHotel.DataBind();
            }
            else
            {
                lblError.Text = "No hay hoteles. ";
            }

            List<Tipos> listaTipos = LogicaTipo.Lista();
            if (listaTipos.Count > 0)
            {
                ddlTipo.DataSource = listaTipos;
                ddlTipo.DataTextField = "tipo";
                ddlTipo.DataValueField = "codigo";
                ddlTipo.DataBind();
            }
            else
            {
                lblError.Text = "No hay tipos de habitaciones. ";
            }
        }
    }

    protected void btnLimpiar_Click(object sender, EventArgs e)
    {
        txtPrecio.Text = "";
        txtNumero.Text = "";
        txtPiso.Text = "";
    }
    protected void btnAgregar_Click(object sender, EventArgs e)
    {
        string mensaje = "";
        long rut = Convert.ToInt64(ddlHotel.SelectedValue);
        int codigo = Convert.ToInt32(ddlTipo.SelectedValue);
        int numero = 0;
        int piso = 0;
        bool balcon = ccbBalcon.Checked;
        double precio = 0;

        try
        {
            numero = Convert.ToInt32(txtNumero.Text);
        }
        catch
        {
            mensaje = "Los números deben ser enteros. ";
        }

        try
        {
            piso = Convert.ToInt32(txtPiso.Text);
        }
        catch
        {
            mensaje = mensaje + "El piso debe ser enteros. ";
        }

        try
        {
            precio = Convert.ToDouble(txtPrecio.Text);
        }
        catch
        {
            mensaje = mensaje + "Los precios debe ser un número. ";
        }

        if (mensaje == "")
        {
            Hotel h = LogicaHotel.buscar(rut);
            if (h != null)
            {
                Tipos t = LogicaTipo.Buscar(codigo);
                if (t != null)
                {
                    Habitacion hab = new Habitacion(numero, piso, balcon, precio, h, t, true);
                    try
                    {
                        if (LogicaHabitacion.Alta(hab))
                        {
                            Response.Redirect("FrmPrincipalAdministrador.aspx");
                        }
                        else
                        {
                            lblError.Text = "Problemas !!!!!";
                        }
                    }
                    catch (Exception es)
                    {
                        lblError.Text = es.Message;
                    }
                }
            }
        }
        else
        {
            lblError.Text = mensaje; 
        }
    }
}
