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
using System.Xml;


public partial class FrmIngresarReclamos : System.Web.UI.Page
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

    protected void btnAgregar_Click(object sender, EventArgs e)
    {
        long cedula = 0;
        cedula = (long)Session["Usuario"];
        string nombreUsuario = LogicaUsuario.NombreUsuario(cedula);
        string nombreHotel = ddlHotel.SelectedItem.Text;
        string comentario = txtComentario.Text;
        if (comentario == "")
        {
            lblError.Text = "Error: Ud debe ingresar un comentario.";
        }
        string archivo = ConfigurationManager.AppSettings["LibroXml"];
        string camino = Server.MapPath(archivo);
        XmlDocument doc = new XmlDocument();
        doc.Load(camino);
        XmlNode raiz = doc.DocumentElement;
        XmlElement xReclamo = doc.CreateElement("Reclamos");
        XmlAttribute xUsuario = doc.CreateAttribute("usuario");
        xUsuario.Value = nombreUsuario;
        xReclamo.Attributes.Append(xUsuario);
        XmlElement xHotel = doc.CreateElement("hotel");
        xHotel.InnerText = nombreHotel;
        XmlElement xComentario = doc.CreateElement("comentario");
        xComentario.InnerText = comentario;
        xReclamo.AppendChild(xHotel);
        xReclamo.AppendChild(xComentario);
        raiz.AppendChild(xReclamo);
        doc.Save(camino);
        Response.Redirect("FrmPrincipalRegistrado.aspx");
    }
}
