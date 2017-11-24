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
/// Descripción breve de Promociones
/// </summary>
public class Promociones
{
    int nro;
    DateTime fechaInicio;
    DateTime fechaFin;
    int dias;
    int pasajeros;
    string titulo;
    string comentario;
    double precio;
    Hotel tienePromociones;
    Tipos forma;

    public int Nro
    {
        get { return nro; }
        set { nro = value; }
    }

    public DateTime FechaInicio
    {
        get { return fechaInicio; }
        set { fechaInicio = value; }
    }

    public DateTime FechaFin
    {
        get { return fechaFin; }
        set { fechaFin = value; }
    }

    public int Dias
    {
        get { return dias; }
        set { dias = value; }
    }

    public int Pasajeros
    {
        get { return pasajeros; }
        set { pasajeros = value; }
    }

    public string Titulo
    {
        get { return titulo; }
        set { titulo = value; }
    }

    public string Comentario
    {
        get { return comentario; }
        set { comentario = value; }
    }

    public double Precio
    {
        get { return precio; }
        set { precio = value; }
    }

    public Hotel TienePromociones
    {
        get { return tienePromociones; }
        set { tienePromociones = value; }
    }

    public Tipos Forma
    {
        get { return forma; }
        set { forma = value; }
    }
 
    public Promociones()
    {
        nro=0;
        fechaInicio=DateTime.Now;
        fechaFin=DateTime.Now;
        dias=0;
        pasajeros=0;
        titulo="sin titulo";
        comentario="sin comentario";
        precio=0;
        tienePromociones=null;
        forma=null;
    }

    public Promociones(int pNro,DateTime pFechaIni, DateTime pFechaFin, int pDias, int pPasajeros, string pTitulo, string pComentario, double pPrecio, Hotel pTienePromociones, Tipos pForma)
    {
        nro = pNro;
        fechaInicio = pFechaIni;
        fechaFin = pFechaFin;
        dias = pDias;
        pasajeros = pPasajeros;
        titulo = pTitulo;
        comentario = pComentario;
        precio = pPrecio;
        tienePromociones = pTienePromociones;
        forma = pForma;
    }

    public Promociones(DateTime pFechaIni, DateTime pFechaFin, int pDias, int pPasajeros, string pTitulo, string pComentario, double pPrecio, Hotel pTienePromociones, Tipos pForma)
    {
        fechaInicio = pFechaIni;
        fechaFin = pFechaFin;
        dias = pDias;
        pasajeros = pPasajeros;
        titulo = pTitulo;
        comentario = pComentario;
        precio = pPrecio;
        tienePromociones = pTienePromociones;
        forma = pForma;
    }

    public override string ToString()
    {
        return "Promoción Número: " + nro + " Fecha de Inicio: " + fechaInicio + " Fecha de Finalización: " + fechaFin + " Dias: " + dias + " Pasajeros: " + pasajeros + " Título: " + titulo + " Comentario: " + comentario + " Precio: " + precio + " Hotel: " + tienePromociones.Nombre + " Habitación tipo: " + forma.Tipo;
    }  
}
