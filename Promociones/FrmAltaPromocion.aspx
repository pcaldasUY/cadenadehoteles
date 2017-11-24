<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FrmAltaPromocion.aspx.cs" Inherits="FrmAltaPromocion" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Página sin título</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table style="width: 732px">
            <tr>
                <td align="center" colspan="2" style="height: 65px">
                    &nbsp;<asp:Label ID="Label2" runat="server" Font-Bold="True" Font-Overline="False"
                        Font-Size="XX-Large" Font-Underline="True" ForeColor="#C000C0" Text="Ingresar nuevas promociones"
                        Width="408px"></asp:Label></td>
            </tr>
            <tr>
                <td style="width: 232px; height: 43px">
                    <table style="width: 744px; height: 515px">
                        <tr>
                            <td align="center" colspan="2">
                                <asp:Label ID="Label1" runat="server" Text="Hotel: " Width="249px"></asp:Label></td>
                            <td colspan="2">
                                <asp:DropDownList ID="ddlHotel" runat="server" Width="387px">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td align="center" colspan="2" style="height: 39px">
                                <asp:Label ID="Label3" runat="server" Text="Tipo de habitación: " Width="249px"></asp:Label></td>
                            <td colspan="2" style="height: 39px">
                                <asp:DropDownList ID="ddlTipo" runat="server" Width="387px">
                                </asp:DropDownList></td>
                        </tr>
                        <tr>
                            <td align="center" colspan="2" style="height: 28px">
                                <asp:Label ID="Label4" runat="server" Text="Fecha de inicio:" Width="249px"></asp:Label></td>
                            <td colspan="2" style="height: 28px">
                                <asp:TextBox ID="txtFechaInicio" runat="server"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td align="center" colspan="2">
                                <asp:Label ID="Label5" runat="server" Text="Fecha de finalización:" Width="249px"></asp:Label></td>
                            <td colspan="2">
                                <asp:TextBox ID="txtFechaFin" runat="server"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td align="center" colspan="2">
                                <asp:Label ID="Label6" runat="server" Text="Cantidad de días:" Width="249px"></asp:Label></td>
                            <td colspan="2">
                                <asp:TextBox ID="txtDias" runat="server"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td align="center" colspan="2">
                                <asp:Label ID="Label8" runat="server" Text="Cantidad de pasajeros: " Width="249px"></asp:Label></td>
                            <td colspan="2">
                                <asp:TextBox ID="txtPasajeros" runat="server"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td align="center" colspan="2">
                                <asp:Label ID="Label9" runat="server" Text="Título: " Width="249px"></asp:Label></td>
                            <td colspan="2">
                                <asp:TextBox ID="txtTitulo" runat="server"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td align="center" colspan="2">
                                <asp:Label ID="Label10" runat="server" Text="Comentario:" Width="249px"></asp:Label></td>
                            <td colspan="2">
                                <asp:TextBox ID="txtComentario" runat="server"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td align="center" colspan="2">
                                <asp:Label ID="Label7" runat="server" Text="Precio:" Width="249px"></asp:Label></td>
                            <td colspan="2">
                                <asp:TextBox ID="txtPrecio" runat="server"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td align="center" colspan="2">
                            </td>
                            <td colspan="2">
                            </td>
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
                </td>
                <td style="width: 205px; height: 43px">
                </td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
