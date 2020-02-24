<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebAutomovil.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body bgcolor="#FBF2EF">
    <form id="form1" runat="server">
        <div class="auto-style1">
        <asp:Image ID="Image1" runat="server" Height="119px" ImageUrl="~/imagenes/Inacap.png" Width="1025px" />
            <h1>Login
            </h1>
        
    <div>

        <table style="width:100%;">
            <tr>
                <td class="auto-style3">Usuario</td>
                <td>
                    <asp:TextBox ID="txtUsu" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style3">Contraseña</td>
                <td>
                    <asp:TextBox ID="txtContra" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style3">&nbsp;</td>
                <td class="auto-style2">
                    <asp:Button ID="btnLogin" runat="server" OnClick="btnLogin_Click" Text="Login" Width="127px" />
                </td>

            </tr>
        </table>

    </div>
    </form>
    </body>
</html>
