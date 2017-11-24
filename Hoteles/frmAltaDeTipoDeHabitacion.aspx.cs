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
        lblError.Text = "";

    }
    protected void btnAgregar_Click(object sender, EventArgs e)
    {
        string mensaje = "";
        string tipo="";
        int minima = 0;
        int maxima = 0;
        if (txtTipo.Text == "")
        {
            mensaje="El tipo de habitación no puede estar en blanco. ";
        }
        else
        {
            tipo=txtTipo.Text;
        }
        try
        {
            minima=Convert.ToInt32(txtMinima.Text);
        }
        catch
        {
            mensaje=mensaje +"La cantidad mínima debe ser un número entero. ";
        }
         try
        {
            maxima=Convert.ToInt32(txtMaxima.Text);
        }
        catch
        {
            mensaje=mensaje +"La cantidad máxima debe ser un número entero. ";
        }
        if (mensaje == "")
        {
            Tipos t = new Tipos(tipo, minima, maxima);
            try
            {
                if (LogicaTipo.Alta(t))
                {
                    txtTipo.Text = "";
                    txtMaxima.Text = "";
                    txtMinima.Text = "";
                }
                else
                {
                    lblError.Text = "Error!!!!: ya existe el tipo de habitación. ";
                }
            }
            catch (Exception es)
            {
                lblError.Text = es.Message;
            }
        }
        else
        {
            lblError.Text = mensaje;
        }        
    }
    protected void btnEliminar_Click(object sender, EventArgs e)
    {
        string mensaje = "";
        string tipo = "";
        lblError.Text="";
        if (txtTipo.Text == "")
        {
            mensaje = "El tipo de habitación no puede estar en blanco. ";
        }
        else
        {
            tipo = txtTipo.Text;
        }
     
        if (mensaje == "")
        {           
            try
            {
                if (LogicaTipo.Baja(tipo)==0)
                {
                    lblError.Text = "Error!!!!: no se puede eliminar ya que no existe ese tipo";
                }
                else
                {
                    if (LogicaTipo.Baja(tipo) == -1)
                    {
                        lblError.Text = "Error!!!!: Hay habitaciones de hotel con ese mismo tipo. ";
                    }
                    else
                    {
                        if (LogicaTipo.Baja(tipo) == -2)
                        {
                            lblError.Text = "No se pudo realizar la baja correctamente. ";
                        }
                        else                        
                        {
                            txtTipo.Text = "";
                            txtMaxima.Text = "";
                            txtMinima.Text = "";
                        }
                    }
                }
            }
            catch (Exception es)
            {
                lblError.Text = es.Message;
            }
        }
        else
        {
            lblError.Text = mensaje;
        }  
    }
    protected void btnModificar_Click(object sender, EventArgs e)
    {
        string mensaje = "";
        string tipo = "";
        int minima = 0;
        int maxima = 0;
        if (txtTipo.Text == "")
        {
            mensaje="El tipo de habitación no puede estar en blanco. ";
        }
        else
        {
            tipo = txtTipo.Text;
        }
        try
        {
            minima = Convert.ToInt32(txtMinima.Text);
        }
        catch
        {
            mensaje = mensaje+"La cantidad mínima debe ser un número entero. ";
        }
        try
        {
            maxima = Convert.ToInt32(txtMaxima.Text);
        }
        catch
        {
            mensaje = mensaje+"La cantidad máxima debe ser un número entero. ";
        }
        if (mensaje == "")
        {
            Tipos t = new Tipos(tipo, minima, maxima);
            try
            {
                if (LogicaTipo.Modificacion(t)==1)
                {
                    txtTipo.Text = "";
                    txtMaxima.Text = "";
                    txtMinima.Text = "";
                }
                else
                {
                    lblError.Text = "Error!!!!: no existe el tipo de habitación. ";
                }
            }
            catch (Exception es)
            {
                lblError.Text = es.Message;
            }
        }
        else
        {
            lblError.Text = mensaje;
        }   
    }
    protected void btnBuscar_Click(object sender, EventArgs e)
    {
        string mensaje = "";
        string tipo = "";
        lblError.Text = "";
        Tipos t=null;

        if (txtTipo.Text == "")
        {
            mensaje = "El tipo de habitación no puede estar en blanco. ";
        }
        else
        {
            tipo = txtTipo.Text;
        }

        if (mensaje == "")
        {
            try
            {
                t=LogicaTipo.BuscarTiposPorNombre(tipo);               
            }
            catch (Exception es)
            {
                lblError.Text = es.Message;
            }
            if (t != null)
            {
                txtMaxima.Text = t.Maxima.ToString();
                txtMinima.Text = t.Minima.ToString();
            }
            else
            {
                lblError.Text = "No existe ningun tipo de habitación con ese nombre.";
            }
        }
        else
        {
            lblError.Text = mensaje;
        }  
    }
}
