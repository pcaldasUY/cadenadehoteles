<%@ Page Title="" Language="C#" MasterPageFile="~/Hoteles/MPHoteles.master" AutoEventWireup="true" CodeFile="ListadoHoteles.aspx.cs" Inherits="Hoteles_ListadoHoteles" %>

<asp:Content ID="Content1" ContentPlaceHolderID="contenidoPrincipal" Runat="Server">
    <h2>Listado de Hoteles</h2>
    <asp:GridView ID="gdvListadoHoteles" runat="server" CellPadding="4" EnableModelValidation="True" Font-Size="10pt" ForeColor="#333333" GridLines="None">
        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
        <EditRowStyle BackColor="#999999" />
        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
    </asp:GridView>
</asp:Content>

