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
/// Descripción breve de Tipos
/// </summary>
public class Tipos
{
    int codigo = 0;
    string tipo = "";
    int minima = 0;
    int maxima = 0;

    public int Codigo
    {
        get { return codigo; }
    }

    public string Tipo
    {
        get { return tipo; }
        set { tipo = value; }
    }

    public int Minima
    {
        get { return minima; }
        set
        {
            if (value < 0)
            {
                throw new Exception("Nro de cantidad minima de pasajeros invalido. ");
            }
            else
            {
                minima = value;
            }
        }
    }

    public int Maxima
    {
        get { return maxima; }
        set
        {
            if (value < 0)
            {
                throw new Exception("Nro de cantidad minima de pasajeros invalido. ");
            }
            else
            {
                maxima = value;
            }
        }
    }

    public Tipos()
    {
        tipo = "Sin tipo";
        minima = 0;
        maxima = 0;
        codigo = 0;
    }

    public Tipos(string aTipo, int aMin, int aMax)
    {
        string error = "";
        if (aTipo == "")
        {
            error = "El tipo no puede estar en blanco. ";
        }
        if (aMin < 0)
        {
            error = error + "La cantidad mínima no puede ser menor a 0. ";
        }
        if (aMax < 0)
        {
            error = error + "La cantidad máxima no puede ser menor a 0. ";
        }
        if (aMin > aMax)
        {
            error = error + "La cantidad minima no puede ser superior a la cantidad máxima. ";
        }
        if (error == "")
        {
            tipo = aTipo;
            maxima = aMax;
            minima = aMin;
        }
        else
        {
            throw new Exception(error);
        }
    }

    public Tipos(int aCodigo, string aTipo, int aMin, int aMax)
    {
        string error = "";
        if (aCodigo < 0)
        {
            error = error + "El código no puede ser menor a 0. ";
        }
        if (aTipo == "")
        {
            error = "El tipo no puede estar en blanco. ";
        }
        if (aMin < 0)
        {
            error = error + "La cantidad mínima no puede ser menor a 0. ";
        }
        if (aMax < 0)
        {
            error = error + "La cantidad máxima no puede ser menor a 0. ";
        }
        if (aMin > aMax)
        {
            error = error + "La cantidad minima no puede ser superior a la cantidad máxima. ";
        }
        if (error == "")
        {
            codigo = aCodigo;
            tipo = aTipo;
            maxima = aMax;
            minima = aMin;
        }
        else
        {
            throw new Exception(error);
        }
    }

    public override string ToString()
    {
        return "Codigo: " + codigo + " Tipo: " + tipo + " Mínima: " + minima + " Máxima: " + maxima;
    }
}
