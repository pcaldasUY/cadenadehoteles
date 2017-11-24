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
/// Descripción breve de Registrado
/// </summary>
public class Registrado:Usuario
{
    private bool sexo;
    private long tarjeta;

    public bool Sexo
    {
        get { return sexo;}
        set { sexo = value; } 
    }

    public long Tarjeta
    {
        get { return tarjeta; }
        set
        {
            if (value <= 0)
            {
                throw new Exception("Nro de tarjeta inválido. ");
            }
            else
            {
                tarjeta = value;
            }
        }
    }

    public Registrado()
    {
        sexo = false;
        tarjeta = -1;
    }

    public Registrado(long aCi, string aNombre, string aPassword, bool aSexo, long aTarjeta)
        : base(aCi, aNombre, aPassword)
    {
        string mensaje = "";

        if (aTarjeta <= 0)
        {
            mensaje = "Nro de tarjeta inválido. ";
        }
        if (mensaje == "")
        {
            tarjeta = aTarjeta;
            sexo = aSexo;
        }
        else
        {
            throw new Exception(mensaje);
        }
    }

    public Registrado(long aCi, string aNombre, bool aSexo, long aTarjeta)
        : base(aCi, aNombre)
    {
        string mensaje = "";

        if (aTarjeta <= 0)
        {
            mensaje = "Nro de tarjeta inválido. ";
        }
        if (mensaje == "")
        {
            tarjeta = aTarjeta;
            sexo = aSexo;
        }
        else
        {
            throw new Exception(mensaje);
        }
    }


    public override string ToString()
    {
        return base.ToString() + "Sexo: " + sexo + "Tarjeta: " + tarjeta;
    }
}
