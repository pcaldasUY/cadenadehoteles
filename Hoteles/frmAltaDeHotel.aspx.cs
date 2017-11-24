using System;
using System.Data;
using System.Collections.Generic;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        long usuario;

        if (!IsPostBack)
        {
            SetFocus(txtRut);
            if (Session["Usuario"] != null)
            {
                usuario = (long)Session["Usuario"];
            }
            else
            {
                Response.Redirect("Default.aspx");
            }
        }
    }

    protected void btnAgregar_Click(object sender, EventArgs e)
    {
        SetFocus(txtRut);
        lblErrores.Text = "";
        string err = "";
        long rut = 0;
        string nom = txtNombre.Text;
        string dir = txtDireccion.Text;
        string ciu = txtCiudad.Text;
        string des = txtDesayuno.Text;
        bool pCli = chkPiscinaClimatizada.Checked;
        bool pExt = chkPiscinaExterna.Checked;
        bool sol = chkSolarium.Checked;
        List<string> img = new List<string>();
        List<long> tel = new List<long>();

        try
        {
            rut = Convert.ToInt64(txtRut.Text);
        }
        catch
        {
            err = "Nro de Rut inválido. ";
        }
        if (nom == "")
        {
            err = err + "Debe ingresar el nombre. ";
        }
        if (dir == "")
        {
            err = err + "Debe ingresar la dirección. "; 
        }
        if (ciu == "")
        {
            err = err + "Debe ingresar la ciudad. ";
        }
        if (des == "")
        {
            err = err + "Debe ingresar desayuno ofrecido. ";
        }

        for (int i = 0; i < lstListaDeTelefonos.Items.Count; i++)
        {
            tel.Add(Convert.ToInt64(lstListaDeTelefonos.Items[i].ToString()));
        }
        
        for (int i = 0; i < lstImagenesCargadas.Items.Count; i++)
        {
            img.Add(lstImagenesCargadas.Items[i].ToString());
        }

        if (err == "")
        {
            try
            {
                Hotel agr = new Hotel(rut, nom, dir, ciu, des, pCli, pExt, sol, img, tel);
                if (LogicaHotel.Alta(agr))
                {
                    Response.Redirect("FrmPrincipalAdministrador.aspx");
                }
                else
                {
                    lblErrores.Text = "Error!! Este hotel ya existe. ";
                }
            }
            catch (Exception ex)
            {
                lblErrores.Text = ex.Message;
            }
        }
        else
        {
            lblErrores.Text = err;
        }
    }
    protected void btnAgregarTelefono_Click(object sender, EventArgs e)
    {
        string err = "";
        lblErrores.Text = "";
        long tel = 0;

        try
        {
            tel = Convert.ToInt64(txtTelefono.Text);
        }
        catch
        {
            err = "Nro de teléfono inválido. ";
            txtTelefono.Text = "";
            SetFocus(txtTelefono);
        }
        if (err == "")
        {
            lstListaDeTelefonos.Items.Add(Convert.ToString(tel));
            txtTelefono.Text = "";
        }
        else
        {
            lblErrores.Text = err;
        }
        
    }
    protected void btnAceptar_Click(object sender, EventArgs e)
    {
        lblErrores.Text = "";
        string img = "";

        if (fulArchivo.PostedFile == null)
        {
            lblStatus.Text = "El archivo no ha sido especificado. ";
        }
        else
        {
            img = fulArchivo.PostedFile.FileName;
            string ext = img.Substring(img.LastIndexOf("."));
            ext = ext.ToLower();

            if (ext == ".jpg" || ext == ".gif" || ext == ".bmp")
            {
                try
                {
                    img = fulArchivo.PostedFile.FileName;
                    lstImagenesCargadas.Items.Add(img);
                }
                catch
                {
                    lblErrores.Text = "Error en la carga del archivo. ";
                }
            }
            else
            {
                lblStatus.Text = "Solo son soportados los formatos jpg, bmp o gif. ";
                SetFocus(fulArchivo);
            }
        }
    }
}
