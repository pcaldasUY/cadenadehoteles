<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FrmListadoPromocionesVigentes.aspx.cs" Inherits="FrmListadoPromocionesVigentes" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Página sin título</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <span style="font-size: 24pt; color: #996633; text-decoration: underline">Listado de
            promociones vigentes</span><br />
        <br />
        <br />
        <asp:GridView ID="GridView1" runat="server">
        </asp:GridView>
        <br />
        <br />
        <asp:LinkButton ID="LinkButton1" runat="server" PostBackUrl="~/FrmPrincipalAdministrador.aspx">Volver al menu principal</asp:LinkButton></div>
    </form>
</body>
</html>
