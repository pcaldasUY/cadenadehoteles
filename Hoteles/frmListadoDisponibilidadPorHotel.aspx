<%@ Page Language="C#" AutoEventWireup="true" CodeFile="frmListadoDisponibilidadPorHotel.aspx.cs" Inherits="frmListadoDisponibilidadPorHotel" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Página sin título</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        &nbsp;</div>
        <table style="width: 602px; height: 483px">
            <tr>
                <td>
                </td>
                <td>
                    <asp:Label ID="lblListadoDeDisponibilidades" runat="server" Font-Bold="True" Font-Names="Calibri"
                        Font-Size="Large" ForeColor="#004000" Text="DISPONIBILIDADES DE HABITACION POR HOTEL"
                        Width="453px"></asp:Label>
                    &nbsp;
                </td>
                <td>
                </td>
            </tr>
            <tr>
                <td style="height: 6px">
                </td>
                <td style="height: 6px; text-align: left">
                    <asp:Label ID="lblSeleccionar" runat="server" Height="21px" Text="Seleccionar Hotel:"
                        Width="124px"></asp:Label>
                    &nbsp;
                    <asp:DropDownList ID="ddlHoteles" runat="server" OnSelectedIndexChanged="ddlHoteles_SelectedIndexChanged"
                        Width="172px" AutoPostBack="True">
                    </asp:DropDownList>
                    <table style="width: 617px; height: 337px; text-align: left">
                        <tr>
                            <td style="vertical-align: top; height: 97px; text-align: left">
                    <asp:GridView ID="grdListado" runat="server" Height="1px" Width="614px" CellPadding="4" ForeColor="#333333" GridLines="None" OnSelectedIndexChanged="grdListado_SelectedIndexChanged">
                        <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                        <RowStyle BackColor="#E3EAEB" />
                        <EditRowStyle BackColor="#7C6F57" />
                        <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
                        <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
                        <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                        <AlternatingRowStyle BackColor="White" />
                        <Columns>
                            <asp:CommandField ShowSelectButton="True" />
                        </Columns>
                    </asp:GridView>
                            </td>
                            <td style="height: 97px">
                            </td>
                            <td style="height: 97px">
                            </td>
                        </tr>
                        <tr>
                            <td>
                            </td>
                            <td>
                            </td>
                            <td>
                            </td>
                        </tr>
                    </table>
                    &nbsp;&nbsp;</td>
                <td style="height: 6px">
                </td>
            </tr>
            <tr>
                <td>
                </td>
                <td>
                    &nbsp;</td>
                <td>
                </td>
            </tr>
            <tr>
                <td>
                </td>
                <td>
                    <asp:Label ID="lblerror" runat="server" BorderColor="Red" Width="614px" ForeColor="Red"></asp:Label></td>
                <td>
                </td>
            </tr>
        </table>
    </form>
</body>
</html>
