<%@ Page Language="C#" MasterPageFile="~/MPAdministrador.master" AutoEventWireup="true" CodeFile="frmAltaDeTipoDeHabitacion.aspx.cs" Inherits="Default2" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <span style="color: #ff99cc; font-family: Arial Black; text-decoration: underline">
        <br />
        <table style="width: 740px">
            <tr>
                <td align="center" colspan="2">
                    <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Overline="False" Font-Size="XX-Large"
                        Font-Underline="True" ForeColor="#C000C0" Text="ALTA DE TIPOS DE HABITACION"
                        Width="614px"></asp:Label></td>
            </tr>
            <tr>
                <td style="height: 21px; width: 268px;">
                </td>
                <td style="height: 21px">
                </td>
            </tr>
            <tr>
                <td align="center" style="width: 268px">
                    <asp:Label ID="Label2" runat="server" Text="Tipo de habitación" Width="208px"></asp:Label></td>
                <td>
                    <asp:TextBox ID="txtTipo" runat="server" Width="352px"></asp:TextBox></td>
            </tr>
            <tr>
                <td align="center" style="width: 268px">
                    <asp:Label ID="Label3" runat="server" Text="Cantidad Mínima" Width="208px"></asp:Label></td>
                <td>
                    <asp:TextBox ID="txtMinima" runat="server" Width="352px"></asp:TextBox></td>
            </tr>
            <tr>
                <td align="center" style="width: 268px">
                    <asp:Label ID="Label4" runat="server" Text="Cantidad Máxima" Width="208px"></asp:Label></td>
                <td>
                    <asp:TextBox ID="txtMaxima" runat="server" Width="352px"></asp:TextBox></td>
            </tr>
            <tr>
                <td align="right" style="width: 268px; height: 25px">
                </td>
                <td style="height: 25px">
                </td>
            </tr>
            <tr>
                <td align="center" style="width: 268px">
                    <asp:Button ID="btnBuscar" runat="server" OnClick="btnBuscar_Click" Text="Buscar !!!" /></td>
                <td align="center">
                    <asp:Button ID="btnModificar" runat="server" OnClick="btnModificar_Click" Text="Modificar !!!" /></td>
            </tr>
            <tr>
                <td align="right" style="width: 268px">
                </td>
                <td>
                </td>
            </tr>
            <tr>
                <td style="width: 268px" align="center">
                    <asp:Button ID="btnEliminar" runat="server" OnClick="btnEliminar_Click" Text="Eliminar !!!!" /></td>
                <td align="center">
                    <asp:Button ID="btnAgregar" runat="server" BackColor="Gainsboro" BorderColor="White"
                        OnClick="btnAgregar_Click" Text="Agregar !!!" /></td>
            </tr>
            <tr>
                <td align="center" colspan="2">
                    <asp:Label ID="lblError" runat="server" ForeColor="Red" Width="647px"></asp:Label></td>
            </tr>
            <tr>
                <td align="center" style="width: 268px">
                </td>
                <td>
                    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/FrmPrincipalAdministrador.aspx"
                        Width="234px">Regresar al menu anterior</asp:HyperLink></td>
            </tr>
        </table>
    </span>
</asp:Content>

