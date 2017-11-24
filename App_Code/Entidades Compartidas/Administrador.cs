using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

/// <summary>
/// Descripción breve de Administrador
/// </summary>
public class Administrador : Usuario
{
    private string cargo;

    public string Cargo
    {
        get { return cargo; }
        set { cargo = value; }
    }

    public Administrador()
    {
        cargo = "sin cargo";
    }

    public Administrador(long pCedula, string pNombre, string pPassword, string pCargo)
        : base(pCedula, pNombre, pPassword)
    {
        cargo = pCargo;
    }

    public Administrador(long pCedula, string pNombre, string pCargo)
        : base(pCedula, pNombre)
    {
        cargo = pCargo;
    }
    public override string ToString()
    {
        return base.ToString() + "Cargo: " + cargo;
    }
}
