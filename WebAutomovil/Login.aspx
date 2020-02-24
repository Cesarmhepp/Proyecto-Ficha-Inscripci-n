<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="WebAutomovil.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
    <style type="text/css">
        #form1 {

        }
        *{margin:0; padding:0;}
        body{
            background:#f6f6f6;
            margin:0;
            padding:0;
        }
        header{
            width:100%;
            overflow:hidden;
            background:#900;
            height: 110px;
        }
        .wrapper {
            width:90%;
            max-width:1000px;
            margin:auto;
            overflow:hidden;
        }
        header .logo{
            color:#f2f2f2;
            font-size:50px;
            line-height:75px;
            float:left;
        }
        .derecha{
            float:right;
            color:#fff;
            display:inline-block;
            line-height:140px;
            font-size:15px;
            font-family: Arial, Helvetica, sans-serif;

        }

        .izquerda{
                        float:left;
                        color:#fff;
            display:inline-block;
            padding:10px 20px;
            line-height:75px;
            font-size:15px;
            font-family: Arial, Helvetica, sans-serif;
        }
       nav{
            text-align:center;
            line-height:100px;
            font-family:Arial, Helvetica, sans-serif;
        }
       nav a{
            display:inline-block;
            color:#900;
            text-decoration:none;
            padding:10px 20px;
            line-height:normal;
            font-size:20px;
            font-weight:bold;
            -o-transition:all 300ms ease;
            transition:all 300ms ease;
        }
       nav a:hover{
            background:#900;
            color:#ffffff;
            border-radius:50px;
        }
       .login{
           margin: auto;
           box-shadow: -20px 0 15px rgba(0,0,0,.2);
           	border: 2px solid rgba(0,0,0,0.2);
               top:40%;
               left:40%;
               position:absolute;
               box-sizing:border-box;

       }
       .login td {
           font-family: Arial, Helvetica, sans-serif;
       }
       .TextBox {
         border: 3px groove #FFA5A5; 
         outline:0; 
         height:22px; 
         width: 220px; 
         color: rgba(128, 128, 128, 0.90);
  } 
       }
        .botones{
            background-color:#900;
            color: #fff;
            font-family: Arial, Helvetica, sans-serif;
        }
        .botones a:hover{
            background: #b94f4f;
        }
        .auto-style1 {
            width: 114%;
        }
        .letras{
            font-size: 12px;
        }
        </style>
    </style>
</head>

<body bgcolor="#FBF2EF">
    <form id="form1" runat="server">
                <header>
               <div class="wrapper">
                    <div class="logo">
                        <a href="WebPortada.aspx">
                        <asp:Image ID="Image2" runat="server" ImageUrl="~/imagenes/logo.png" />
                            </a>
                            </div>
                                      <div class="izquerda">
                                          <h1>Sede Santiago Sur</h1>
                       </div>
               </div>
         </header>    
        <div class="login">
        <table class="auto-style1" align="center">
            <tr>
                <td class="auto-style3">&nbsp;</td>
                <td>
                    <asp:Label class="letras" ID="Label1" runat="server" Text="Label">Ingrese su cuenta INACAPMail o su RUT:</asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style3">&nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style3">&nbsp;</td>
                <td class="auto-style2">
                    <asp:TextBox CssClass="TextBox" ID="txtUsu" runat="server">usuario@inacapmail.cl o RUT</asp:TextBox>
                </td>

            </tr>
            <tr>
                <td class="auto-style3">&nbsp;</td>
                <td class="auto-style2">
                    <asp:TextBox CssClass="TextBox"  ID="txtContra" runat="server" TextMode="Password"></asp:TextBox>
                </td>

            </tr>
            <tr>
                <td class="auto-style3">&nbsp;</td>
                <td class="auto-style2">
                    &nbsp;</td>

            </tr>
            <tr>
                <td class="auto-style3">&nbsp;</td>
                <td class="auto-style2">
                    <asp:Button class="botones" ID="btnLogin" runat="server" OnClick="btnLogin_Click" Text="Login" Width="127px" />
                </td>

            </tr>
        </table>
        </div>  
    </form>
    </body></html>
