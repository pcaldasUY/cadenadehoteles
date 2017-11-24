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

public partial class FrmAltaPromocion : System.Web.UI.Page
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
        txtComentario.Text = "";
        txtDias.Text = "";
        txtFechaFin.Text = "";
        txtFechaInicio.Text = "";
        txtPasajeros.Text = "";
        txtPrecio.Text = "";
        txtTitulo.Text = "";
    }
    protected void btnAgregar_Click(object sender, EventArgs e)
    {
        string mensaje = "";
        long rut = Convert.ToInt64(ddlHotel.SelectedValue);
        int codigo = Convert.ToInt32(ddlTipo.SelectedValue);
        DateTime fechaIni = DateTime.Now;
        DateTime fechaFin = DateTime.Now;
        int dias = 0;
        int pasajeros = 0;        
        string titulo = "";
        string comentario = "";
        double precio = 0;

        try
        {
            fechaIni = Convert.ToDateTime(txtFechaInicio.Text);
        }
        catch
        {
            mensaje = "Fecha de inicio inválida. ";
        }

        try
        {
            fechaFin = Convert.ToDateTime(txtFechaFin.Text);
        }
        catch
        {
            mensaje = mensaje+"Fecha de finalización inválida. ";
        }
        try
        {
            dias = Convert.ToInt32(txtDias.Text);
        }
        catch
        {
            mensaje = mensaje + "La cantidad de días debe ser un número entero. ";
        }

        try
        {
            pasajeros = Convert.ToInt32(txtPasajeros.Text);
        }
        catch
        {
            mensaje = mensaje + "La cantidad de pasajeros debe ser un número entero. ";
        }

        if (txtTitulo.Text == "")
        {
            mensaje=mensaje+"El título no puede estar en blanco. ";
        }
        else
        {
            titulo = txtTitulo.Text;
        }

        if (txtComentario.Text == "")
        {
            mensaje = mensaje + "El comentario no puede estar en blanco. ";
        }
        else
        {
            comentario = txtComentario.Text;
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
                    Promociones p = new Promociones(fechaIni, fechaFin, dias, pasajeros, titulo, comentario, precio, h, t);                    try
                    {
                        if (LogicaPromocion.Alta(p))                            
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
