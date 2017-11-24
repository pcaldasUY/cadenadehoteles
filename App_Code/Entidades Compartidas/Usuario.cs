using System;
using System.Data;
using System.Configuration;
using System.Collections.Generic;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

/// <summary>
/// Descripción breve de Usuario
/// </summary>
public class Usuario
{
    long cedula;
    string nombre;
    string password;

    public long Cedula
    {
        get { return cedula; }
        set { cedula = value; }
    }

    public string Nombre
    {
        get { return nombre; }
        set { nombre = value; }
    }

    public string Password
    {
        get { return password; }
        set { password = value; }
    }

    public Usuario()
    {
        cedula = 0;
        nombre = "no definido";
        password = "no definido"; ;
    }

    public Usuario(long pCedula, string pNombre, string pPassword)
    {
        cedula = pCedula;
        nombre = pNombre;
        password = pPassword;
    }

    public Usuario(long pCedula, string pNombre)
    {
        cedula = pCedula;
        nombre = pNombre;
    }

    public override string ToString()
    {
        return "Ci: " + cedula + " Nombre: " + nombre + " Password: " + password;
    }
}
