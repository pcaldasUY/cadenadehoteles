<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FrmListadoDeHoteles.aspx.cs" Inherits="FrmListadoDeHoteles" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Página sin título</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table style="width: 861px; color: black; font-family: Algerian; height: 248px">
            <tr>
                <td style="height: 20px">
                </td>
                <td style="width: 3px; height: 20px">
                </td>
                <td style="font-family: Calibri; height: 20px">
                    LISTADO DE HOTELES</td>
            </tr>
            <tr>
                <td style="height: 147px">
                </td>
                <td style="width: 3px; height: 147px">
                </td>
                <td style="height: 147px">
                    <asp:GridView ID="grdListaDeHoteles" runat="server" AutoGenerateColumns="False" CellPadding="4"
                        ForeColor="#333333" GridLines="None" Height="1px" OnSelectedIndexChanged="GridView1_SelectedIndexChanged"
                        Style="font-family: Arial" Width="1px">
                        <Columns>
                            <asp:BoundField DataField="rut" HeaderText="Rut" />
                            <asp:BoundField DataField="nombre" HeaderText="Nombre" />
                            <asp:BoundField DataField="direccion" HeaderText="Direccion" />
                            <asp:BoundField DataField="ciudad" HeaderText="Ciudad" />
                            <asp:BoundField DataField="desayuno" HeaderText="Desayuno" />
                            <asp:CheckBoxField DataField="piscinaClimatizada" HeaderText="Piscina Climatizada" />
                            <asp:CheckBoxField DataField="piscinaExterna" HeaderText="Piscina Externa" />
                            <asp:CheckBoxField DataField="solarium" HeaderText="Solarium" />
                            <asp:CommandField SelectText="Telefonos e Imagenes" ShowHeader="True" ShowSelectButton="True" />
                        </Columns>
                        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                        <EditRowStyle BackColor="#999999" />
                        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                    </asp:GridView>
                </td>
            </tr>
            <tr>
                <td>
                </td>
                <td style="width: 3px">
                </td>
                <td>
                    <asp:Label ID="lblError" runat="server" ForeColor="Red" Width="822px"></asp:Label></td>
            </tr>
            <tr>
                <td>
                </td>
                <td style="width: 3px">
                </td>
                <td align="right">
                    <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click">Volver al menu anterior</asp:LinkButton></td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
