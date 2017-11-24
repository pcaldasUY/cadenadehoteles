<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FrmListadoHabitacionesHotel.aspx.cs" Inherits="FrmListadoHabitacionesHotel" %>

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
                        Font-Underline="True" ForeColor="#C000C0" Text="Habitaciones de un hotel" Width="614px"></asp:Label></td>
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
                    <asp:DropDownList ID="ddlHotel" runat="server" Width="410px" OnSelectedIndexChanged="ddlHotel_SelectedIndexChanged">
                    </asp:DropDownList>
                    <asp:Button ID="btnBuscar" runat="server" BackColor="Gainsboro" BorderColor="White"
                         Text="Buscar !!!" OnClick="btnBuscar_Click" /></td>
            </tr>
            <tr>
                <td align="center" colspan="2" rowspan="1" style="height: 177px">
                    <asp:ListBox ID="lstHabitaciones" runat="server" Height="163px" Width="682px"></asp:ListBox></td>
            </tr>
            <tr>
                <td align="center" colspan="2" rowspan="3">
                    &nbsp;</td>
            </tr>
            <tr>
            </tr>
            <tr>
            </tr>
            <tr>
                <td align="center" colspan="2">
                    <asp:Label ID="lblError" runat="server" ForeColor="Red" Width="647px"></asp:Label></td>
            </tr>
            <tr>
                <td align="center">
                </td>
                <td align="right">
                    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/FrmPrincipalAdministrador.aspx"
                        Width="234px">Regresar al menu anterior</asp:HyperLink></td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
