<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FrmIngresarReclamos.aspx.cs" Inherits="FrmIngresarReclamos" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Página sin título</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table style="width: 740px">
            <tr>
                <td align="center" colspan="2">
                    <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Overline="False" Font-Size="XX-Large"
                        Font-Underline="True" ForeColor="#C000C0" Text="Ingresar reclamos" Width="614px"></asp:Label></td>
            </tr>
            <tr>
                <td style="height: 21px">
                </td>
                <td style="height: 21px">
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label2" runat="server" Text="Hotel: " Width="211px"></asp:Label></td>
                <td>
                    <asp:DropDownList ID="ddlHotel" runat="server" Width="498px">
                    </asp:DropDownList></td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label3" runat="server" Text="Comentario: " Width="208px"></asp:Label></td>
                <td>
                    <asp:TextBox ID="txtComentario" runat="server" TextMode="MultiLine" Width="491px"></asp:TextBox></td>
            </tr>
            <tr>
                <td align="right">
                </td>
                <td>
                </td>
            </tr>
            <tr>
                <td>
                </td>
                <td align="right">
                    <asp:Button ID="btnAgregar" runat="server" BackColor="Gainsboro" BorderColor="White"
                        OnClick="btnAgregar_Click" Text="Agregar !!!" /></td>
            </tr>
            <tr>
                <td align="center" colspan="2">
                    <asp:Label ID="lblError" runat="server" ForeColor="Red" Width="647px"></asp:Label></td>
            </tr>
            <tr>
                <td align="center">
                </td>
                <td>
                    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/FrmPrincipalRegistrado.aspx"
                        Width="234px">Regresar al menu anterior</asp:HyperLink></td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
