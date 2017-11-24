using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Collections.Generic;

/// <summary>
/// Descripción breve de LogicaUsuario
/// </summary>
public class LogicaUsuario
{
    public static int ClaveCorrecta(long pCi, string pClave)
    {
        if (EsAdministrador(pCi))
        {
            return DatosAdministrador.ClaveCorrecta(pCi, pClave);
        }
        else
        {
            return DatosRegistrado.ClaveCorrecta(pCi, pClave);            
        }
    }

    public static bool EsAdministrador(long pCi)
    {
        return DatosAdministrador.EsAdministrador(pCi)==1;
    }

    public static bool EsRegistrado(long pCi)
    {
        return DatosRegistrado.EsRegistrado(pCi) == 1;
    }

    public static string NombreUsuario(long pCi)
    {
        if (EsAdministrador(pCi))
        {
            return DatosAdministrador.NombreAdministrador(pCi);
        }
        else
        {
            return DatosRegistrado.NombreRegistrado(pCi);
        }
    }

    public static bool AgregarUsuario(Usuario u)
    {
        if (u is Registrado)
        {
            return DatosRegistrado.Alta((Registrado)u)==1;
        }
        else
        {           
            return DatosAdministrador.AgregarAdministrador((Administrador)u)==1;
        }
    }

    public static bool BajaUsuario(long ci)
    {
        if (EsRegistrado(ci))
        {
            return true;
        }
        else
        {
            return DatosAdministrador.EliminoAdministrador(ci) == 1;
        }
    }

    public static bool ModificoUsuario(Usuario u)
    {
        if (u is Registrado)
        {
            return DatosRegistrado.Modificion((Registrado)u) == 1;
        }
        else
        {
            return DatosAdministrador.ModificoAdministrador((Administrador)u) == 1;
        }
    }

    public static List<Administrador> ListarAdministrador()
    {       
        return DatosAdministrador.ListarAdministrador();        
    }

    public static List<Registrado> ListarRegistrados()
    {
        return DatosRegistrado.ListarRegistrados();
    }

    public static int CambioClave(long pCi, string pClave, string pNuevaClave)
    {
        return DatosUsuario.CambioClave(pCi, pClave, pNuevaClave);
    }

    public static Administrador buscarAdministrador(long pci)
    {
        return DatosAdministrador.BuscarAdministradorPorCedula(pci); 
    }

    public static Registrado buscarRegistrado(long pCi)
    {
        return DatosRegistrado.BuscarRegistrado(pCi);
    }
}
