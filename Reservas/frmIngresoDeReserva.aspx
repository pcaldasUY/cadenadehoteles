<%@ Page Language="C#" MasterPageFile="~/MPRegistrado.master" AutoEventWireup="true" CodeFile="frmIngresoDeReserva.aspx.cs" Inherits="Default2" Title="Untitled Page" %>

<%@ Register Src="ActualizacionDePreciosTC.ascx" TagName="ActualizacionDePreciosTC"
    TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table style="width: 411px; height: 362px">
        <tr>
            <td style="height: 8px" colspan="3">
                <asp:Label ID="lblReservas" runat="server" Height="5px" Text="Nueva Reserva" Width="324px"></asp:Label></td>
            <td colspan="1" style="height: 8px">
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label1" runat="server" Text="Hotel:"></asp:Label></td>
            <td>
                <asp:DropDownList ID="ddlHotel" runat="server" OnSelectedIndexChanged="ddlHotel_SelectedIndexChanged" Width="148px">
                </asp:DropDownList></td>
            <td style="width: 12px">
            </td>
            <td>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label2" runat="server" Text="Tipo de habitación:"></asp:Label></td>
            <td>
                <asp:DropDownList ID="ddlTipoHabitacion" runat="server" OnSelectedIndexChanged="ddlTipoHabitacion_SelectedIndexChanged" Width="152px">
                </asp:DropDownList></td>
            <td style="width: 12px">
            </td>
            <td>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label6" runat="server" Text="Fecha de ingreso:" Width="151px"></asp:Label></td>
            <td>
                <asp:TextBox ID="txtFechaIngreso" runat="server"></asp:TextBox></td>
            <td style="width: 12px">
            </td>
            <td>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label7" runat="server" Text="Fecha de egreso:"></asp:Label></td>
            <td>
                <asp:TextBox ID="txtFechaEgreso" runat="server"></asp:TextBox></td>
            <td style="width: 12px">
            </td>
            <td>
                <asp:Button ID="btnBuscar" runat="server" Text="Buscar habitaciones disponibles !!"
                    Width="275px" OnClick="btnBuscar_Click" /></td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label3" runat="server" Text="habitaciones"></asp:Label></td>
            <td>
                <asp:DropDownList ID="ddlNrosHabitaciones" runat="server" Width="152px" OnSelectedIndexChanged="ddlNrosHabitaciones_SelectedIndexChanged">
                </asp:DropDownList></td>
            <td style="width: 12px">
            </td>
            <td>
            </td>
        </tr>
        <tr>
            <td colspan="4">
                <uc1:ActualizacionDePreciosTC ID="ActualizacionDePreciosTC1" runat="server" />
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label4" runat="server" Text="Label"></asp:Label></td>
            <td>
                <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox></td>
            <td style="width: 12px">
                <asp:Label ID="Label5" runat="server" Text="Label"></asp:Label></td>
            <td>
                <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td>
            </td>
            <td>
            </td>
            <td style="width: 12px">
                &nbsp;</td>
            <td>
                <asp:Button ID="btnIngresar" runat="server" OnClick="btnIngresar_Click" Text="Ingresar"
                    Width="131px" />
                <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" Width="131px" /></td>
        </tr>
    </table>
</asp:Content>

