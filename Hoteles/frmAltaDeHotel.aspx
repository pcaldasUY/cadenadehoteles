<%@ Page Language="C#" MasterPageFile="~/MPAdministrador.master" AutoEventWireup="true" CodeFile="frmAltaDeHotel.aspx.cs" Inherits="Default" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table style="width: 121px; height: 1px">
        <tr>
            <td colspan="2" style="height: 21px">
                <asp:Label ID="lblAltaDeHotel" runat="server" Text="ALTA DE HOTEL" Font-Bold="True"></asp:Label></td>
        </tr>
        <tr>
            <td>
            </td>
            <td style="width: 1px">
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblRut" runat="server" Text="Rut"></asp:Label></td>
            <td style="width: 1px">
                <asp:TextBox ID="txtRut" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td style="height: 1px">
                <asp:Label ID="lblNombre" runat="server" Text="Nombre"></asp:Label></td>
            <td style="height: 1px; width: 1px;">
                <asp:TextBox ID="txtNombre" runat="server" Width="317px" TabIndex="1"></asp:TextBox></td>
        </tr>
        <tr>
            <td style="height: 1px">
                <asp:Label ID="lblDireccion" runat="server" Text="Dirección"></asp:Label></td>
            <td style="height: 1px; width: 1px;">
                <asp:TextBox ID="txtDireccion" runat="server" Width="317px" TabIndex="2"></asp:TextBox></td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblCiudad" runat="server" Text="Ciudad"></asp:Label></td>
            <td style="width: 1px">
                <asp:TextBox ID="txtCiudad" runat="server" Width="318px" TabIndex="3"></asp:TextBox></td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblDesayuno" runat="server" Text="Desayuno"></asp:Label></td>
            <td style="width: 1px">
                <asp:TextBox ID="txtDesayuno" runat="server" Width="318px" TabIndex="4"></asp:TextBox></td>
        </tr>
        <tr>
            <td>
            </td>
            <td style="width: 1px">
                <asp:CheckBox ID="chkPiscinaClimatizada" runat="server" Text="Piscina Climatizada" Width="202px" TabIndex="5" /></td>
        </tr>
        <tr>
            <td style="height: 22px">
            </td>
            <td style="width: 1px; height: 22px;">
                <asp:CheckBox ID="chkPiscinaExterna" runat="server" Text="Piscina Externa" Width="132px" TabIndex="6" /></td>
        </tr>
        <tr>
            <td style="height: 22px">
            </td>
            <td style="width: 1px; height: 22px;">
                <asp:CheckBox ID="chkSolarium" runat="server" Text="Solarium" Width="124px" TabIndex="6" /></td>
        </tr>
        <tr>
            <td style="vertical-align: top; position: static; text-align: left">
                <br />
                <asp:Label ID="lblTelefonos" runat="server" Text="Teléfonos" Width="82px" style="vertical-align: top; text-align: left" Height="23px"></asp:Label></td>
            <td style="position: relative; vertical-align: middle; text-align: left;">
                &nbsp;<table style="left: 0px; position: static; top: -17px">
                    <tr>
                        <td style="width: 108px; height: 26px">
                <asp:TextBox ID="txtTelefono" runat="server" Width="142px" style="position: static" TabIndex="7"></asp:TextBox></td>
                        <td style="width: 78px; height: 26px">
                <asp:Button ID="btnAgregarTelefono" runat="server" Text="Agregar Teléfono" Width="113px" OnClick="btnAgregarTelefono_Click" /></td>
                    </tr>
                </table>
                <asp:ListBox ID="lstListaDeTelefonos" runat="server" AutoPostBack="True" Width="152px">
                </asp:ListBox><br />
            </td>
        </tr>
        <tr>
            <td style="height: 111px; vertical-align: top; position: static;">
                <br />
                <asp:Label ID="Label1" runat="server" Text="Imágenes" Width="93px" style="vertical-align: top; position: static" Height="25px"></asp:Label></td>
            <td style="width: 1px; position: static; height: 111px;">
                &nbsp;&nbsp;
                <table style="width: 426px">
                    <tr>
                        <td>
                <asp:FileUpload ID="fulArchivo" runat="server" Height="24px" Width="270px" style="position: static" TabIndex="8" /></td>
                        <td style="width: 3px">
                <asp:Button ID="btnAceptar" runat="server" Text="Aceptar" Width="110px" OnClick="btnAceptar_Click" style="position: static" Height="24px" /></td>
                    </tr>
                </table>
                <asp:ListBox ID="lstImagenesCargadas" runat="server" Width="425px" style="position: static" AutoPostBack="True"></asp:ListBox><br />
                <asp:Label ID="lblStatus" runat="server" Font-Names="Georgia" Font-Size="X-Small"
                    ForeColor="Blue" Width="421px"></asp:Label></td>
        </tr>
        <tr>
            <td style="vertical-align: top; position: static">
            </td>
            <td style="position: static">
                <asp:Button ID="btnAgregar" runat="server" Text="Agregar" Width="126px" OnClick="btnAgregar_Click" Height="29px" />
                &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
                <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" Width="126px" Height="29px" /></td>
        </tr>
        <tr>
            <td colspan="2" style="height: 45px">
                <asp:Label ID="lblErrores" runat="server" ForeColor="Red" Width="806px"></asp:Label></td>
        </tr>
    </table>
</asp:Content>

