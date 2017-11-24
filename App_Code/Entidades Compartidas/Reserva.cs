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
/// Descripción breve de Reserva
/// </summary>
public class Reserva
{
    int id;
    DateTime fechaInicio;
    DateTime fechaFin;
    double precio;
    string moneda;
    bool cancelada;
    Registrado cedula;
    Habitacion numero;
    Habitacion rut;

    public int Id
    {
        get { return id; }
        set
        {
            if (value < 0)
            {
                throw new Exception("Nro de reserva inválido. ");
            }
            else
            {
                id = value;
            }
        }
    }

    public DateTime FechaInicio
    {
        get { return fechaInicio; }
        set
        {
            if (value < DateTime.Today)
            {
                throw new Exception("La fecha de inicio inválida. ");
            }
            else
            {
                fechaInicio = value;
            }
        }
    }

    public DateTime FechaFin
    {
        get { return fechaFin; }
        set
        {
            if (value < DateTime.Today)
            {
                throw new Exception("La fecha de finalizaión inválida. ");
            }
            else
            {
                fechaFin = value;
            }
        }
    }

    public double Precio
    {
        get { return precio; }
        set
        {
            if (value < 0)
            {
                throw new Exception("Precio inválido. ");
            }
            else
            {
                precio = value;
            }
        }
    }

    public string Moneda
    {
        get { return moneda; }
        set { moneda = value; }
    }

    public bool Cancelada
    {
        get { return cancelada; }
        set { cancelada = value; }
    }

    public Registrado Cedula
    {
        get { return cedula; }
        set { cedula = value; }
    }

    public Habitacion Numero
    {
        get { return numero; }
        set { numero = value; }
    }

    public Habitacion Rut
    {
        get { return rut; }
        set { rut = value; }
    }

    public Reserva()
	{
        id = 0;
        fechaInicio = DateTime.Today;
        fechaFin = DateTime.Today;
        precio = 0;
        moneda = "Pesos";
        cancelada = false;
        cedula = null;
        numero = null;
        rut = null;
	}

    public Reserva(int pId, DateTime pFinicio, DateTime pFfin, double pPrecio, string pMoneda, bool pCancelada,
        Registrado pCedula, Habitacion pNumero, Habitacion pRut)
    {
        string mensaje = "";

        if (cedula == null)
        {
            mensaje = "Usuario no seleccionado";
        }
        if (numero == null)
        {
            mensaje = mensaje + "Habitación no seleccionada. ";
        }
        if (rut == null)
        {
            mensaje = mensaje + "Hotel no seleccionado. ";
        }
        if (fechaInicio < DateTime.Today)
        {
            mensaje = mensaje + "Fecha de inicio incorrecta. ";
        }
        if (fechaFin < DateTime.Today)
        {
            mensaje = mensaje + "Fecha final incorrecta. ";
        }
        if (precio <= 0)
        {
            mensaje = mensaje + "Precio inválido. ";
        }
        if (mensaje == "")
        {
            id = pId;
            fechaInicio = pFinicio;
            fechaFin = pFfin;
            precio = pPrecio;
            moneda = pMoneda;
            cancelada = pCancelada;
            cedula = pCedula;
            rut = pRut;
            numero = pNumero;
        }
        else
        {
            throw new Exception(mensaje);
        }
    }

    public override string ToString()
    {
        return id + " " + fechaInicio + " " + fechaFin + " " + precio + " " + moneda + " " + cancelada 
            + " " + cedula + " " + rut + " " + numero;
    }
    
}
