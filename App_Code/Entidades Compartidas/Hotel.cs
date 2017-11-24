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
/// Descripción breve de Hotel
/// </summary>
public class Hotel
{
    long rut;
    string nombre;
    string direccion;
    string ciudad;
    string desayuno;
    bool piscinaClimatizada;
    bool piscinaExterna;
    bool solarium;
    List<string> fotos;
    List<long> telefonos;

    public long Rut
    {
        get { return rut; }
        set
        {
            if (value < 0)
            {
                throw new Exception("Nro de RUT inválido. ");
            }
            else
            {
                rut = value;
            }
        }
    }

    public string Nombre
    {
        get { return nombre; }
        set { nombre = value; }
    }

    public string Direccion
    {
        get { return direccion; }
        set { direccion = value; }
    }

    public string Ciudad
    {
        get { return ciudad; }
        set { ciudad = value; }
    }

    public string Desayuno
    {
        get { return desayuno; }
        set { desayuno = value; }
    }

    public bool PiscinaClimatizada
    {
        get { return piscinaClimatizada; }
        set { piscinaClimatizada = value; }
    }

    public bool PiscinaExterna
    {
        get { return piscinaExterna; }
        set { piscinaExterna = value; }
    }

    public bool Solarium
    {
        get { return solarium; }
        set { solarium = value; }
    }

    public List<string> Fotos
    {
        get { return fotos; }
        set { fotos = value; }
    }

    public List<long> Telefonos
    {
        get { return telefonos; }
        set
        {
            if (value.Count < 0)
            {
                throw new Exception("Nro de teléfono inválido. ");
            }
            else
            {
                telefonos = value;
            }
        }
    }

    public Hotel()
    {
        rut = 0;
        nombre = "no definido";
        direccion = "no definido";
        ciudad = "no definido";
        desayuno = "no definido";
        piscinaClimatizada = false;
        piscinaExterna = false;
        solarium = false;
        fotos = new List<string>();
        telefonos = new List<long>();
    }

    public Hotel(long pRut, string pNombre, string pDireccion, string pCiudad, string pDesayuno,
        bool pPiscinaClimatizada, bool pPiscinaExterna, bool pSolarium, List<string> pFotos,
        List<long> pTelefonos)
    {
        string error = "";

        if (pRut < 0)
        {
            error = "Nro de RUT inválido. ";
        }
        if (pNombre == "")
        {
            error = error + "Falta ingresar Nombre del Hotel. ";
        }
        if (pDireccion == "")
        {
            error = error + "Falta ingresar Direccion del Hotel. ";
        }
        if (pCiudad == "")
        {
            error = error + "Falta ingresar ciudad del hotel. ";
        }
        if (pDesayuno == "")
        {
            error = error + "Falta aclarar que desayuno ofrece el Hotel. ";
        }
        if (error == "")
        {
            rut = pRut;
            nombre = pNombre;
            direccion = pDireccion;
            ciudad = pCiudad;
            desayuno = pDesayuno;
            piscinaClimatizada = pPiscinaClimatizada;
            piscinaExterna = pPiscinaExterna;
            solarium = pSolarium;
            fotos = pFotos;
            telefonos = pTelefonos;
        }
        else
        {
            throw new Exception(error);
        }
    }

    public Hotel(long pRut, string pNombre, string pDireccion, string pCiudad, string pDesayuno,
        bool pPiscinaClimatizada, bool pPiscinaExterna, bool pSolarium)
    {
        string error = "";

        if (pRut < 0)
        {
            error = "Nro de RUT inválido. ";
        }
        if (pNombre == "")
        {
            error = error + "Falta ingresar Nombre del Hotel. ";
        }
        if (pDireccion == "")
        {
            error = error + "Falta ingresar Direccion del Hotel. ";
        }
        if (pCiudad == "")
        {
            error = error + "Falta ingresar ciudad del hotel. ";
        }
        if (pDesayuno == "")
        {
            error = error + "Falta aclarar que desayuno ofrece el Hotel. ";
        }
        if (error == "")
        {
            rut = pRut;
            nombre = pNombre;
            direccion = pDireccion;
            ciudad = pCiudad;
            desayuno = pDesayuno;
            piscinaClimatizada = pPiscinaClimatizada;
            piscinaExterna = pPiscinaExterna;
            solarium = pSolarium;
        }
        else
        {
            throw new Exception(error);
        }
    }

    public override string ToString()
    {
        return "Rut: " + rut + " Nombre: " + direccion + " Dirección: " +
            direccion + " Ciudad: " + ciudad + " Desayuno: " + desayuno + " Piscina Climatizada: " +
            piscinaClimatizada + " Piscina Externa: " + piscinaExterna + " Solarium: " + solarium +
            " Fotos: " + fotos + " Telefonos: " + telefonos;
    }
}
