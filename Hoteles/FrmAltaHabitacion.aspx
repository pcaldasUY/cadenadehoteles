<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FrmAltaHabitacion.aspx.cs" Inherits="FrmAltaHabitacion" %>

<!DOCTYPE html>

<head runat="server">
    <title>Página sin título</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table style="width: 744px; height: 515px">
            <tr>
                <td align="center" colspan="4">
                    <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Overline="False" Font-Size="XX-Large"
                        Font-Underline="True" ForeColor="#C000C0" Text="Habitaciones" Width="614px"></asp:Label></td>
            </tr>
            <tr>
                <td align="center" colspan="2">
                    <asp:Label ID="Label2" runat="server" Text="Hotel: " Width="249px"></asp:Label></td>
                <td colspan="2">
                    <asp:DropDownList ID="ddlHotel" runat="server" Width="387px">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td align="center" colspan="2">
                    <asp:Label ID="Label3" runat="server" Text="Tipo de habitación: " Width="249px"></asp:Label></td>
                <td colspan="2">
                    <asp:DropDownList ID="ddlTipo" runat="server" Width="387px">
                    </asp:DropDownList></td>
            </tr>
            <tr>
                <td align="center" colspan="2">
                    <asp:Label ID="Label4" runat="server" Text="Número: " Width="249px"></asp:Label></td>
                <td colspan="2">
                    <asp:TextBox ID="txtNumero" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td align="center" colspan="2">
                    <asp:Label ID="Label5" runat="server" Text="Piso: " Width="249px"></asp:Label></td>
                <td colspan="2">
                    <asp:TextBox ID="txtPiso" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td align="center" colspan="2">
                    <asp:Label ID="Label6" runat="server" Text="Balcón:" Width="249px"></asp:Label></td>
                <td colspan="2">
                    <asp:CheckBox ID="ccbBalcon" runat="server" /></td>
            </tr>
            <tr>
                <td align="center" colspan="2">
                    <asp:Label ID="Label7" runat="server" Text="Precio:" Width="249px"></asp:Label></td>
                <td colspan="2">
                    <asp:TextBox ID="txtPrecio" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td align="center" colspan="4">
                    <asp:Label ID="lblError" runat="server" ForeColor="Red" Width="647px"></asp:Label></td>
            </tr>
            <tr>
                <td align="center">
                    <asp:Button ID="btnLimpiar" runat="server" OnClick="btnLimpiar_Click" Text="Limpiar" /></td>
                <td align="center">
                    <asp:Button ID="btnAgregar" runat="server" OnClick="btnAgregar_Click" Text="Agregar!!!!!" /></td>
                <td align="center" colspan="2">
                    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/FrmPrincipalAdministrador.aspx">Volver al menu principal</asp:HyperLink></td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
