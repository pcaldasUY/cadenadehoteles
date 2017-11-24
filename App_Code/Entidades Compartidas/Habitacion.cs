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
/// Descripción breve de Habitacion
/// </summary>
public class Habitacion
{
    int numero;
    int piso;
    bool balcon;
    double precio;
    Hotel tieneHabitaciones;
    Tipos esDeTipo;
    bool disponible;

    public int Numero
    {
        get { return numero; }
        set { numero = value; }
    }

    public int Piso
    {
        get { return piso; }
        set { piso = value; }
    }

    public bool Balcon
    {
        get { return balcon; }
        set { balcon = value; }
    }

    public double Precio
    {
        get { return precio; }
        set { precio = value; }
    }

    public Hotel TieneHabitaciones
    {
        get { return tieneHabitaciones; }
        set { tieneHabitaciones = value; }
    }

    public Tipos EsDeTipo
    {
        get { return esDeTipo; }
        set { esDeTipo = value; }
    }

    public bool Disponible
    {
        get { return disponible; }
        set { disponible = value; }
    }

    public Habitacion()
    {
        numero = 0;
        piso = 0;
        balcon = true;
        precio = 0;
        tieneHabitaciones = null;
        esDeTipo = null;
        disponible = true;
    }

    public Habitacion(int pNumero, int pPiso, bool pBalcon, double pPrecio, 
        Hotel pTieneHabitaciones, Tipos pEsDeTipo, bool pDisponible)
    {
        numero = pNumero;
        piso = pPiso;
        balcon = pBalcon;
        precio = pPrecio;
        tieneHabitaciones = pTieneHabitaciones;
        esDeTipo = pEsDeTipo;
        disponible = pDisponible;
    }

    public Habitacion(int pNumero, int pPiso, bool pBalcon, double pPrecio, Tipos pEsDeTipo)
    {
        numero = pNumero;
        piso = pPiso;
        balcon = pBalcon;
        precio = pPrecio;
        esDeTipo = pEsDeTipo;
    }

    public override string ToString()
    {
        return "Hotel: " + tieneHabitaciones.Nombre + " Nro Habit.: " + numero + " Piso: " + piso + " Balcon: " + balcon +
            " Precio: " + precio + " Es del tipo: " + esDeTipo.Tipo + " Disponible: " + disponible;
    }
}
