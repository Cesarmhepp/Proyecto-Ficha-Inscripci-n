<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Site2.Master" AutoEventWireup="true" CodeBehind="WebPDF.aspx.cs" Inherits="WebAutomovil.WebPDF" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .encabezado{
            background: #ff0000;
            color: #fff;
            font-family: Arial, Helvetica, sans-serif;
            height: 45px;
            border: 1px solid #000000;
            width: 90%;
            margin:auto;
        }

                .botones{
            background-color:#900;
            color: #fff;
            font-family: Arial, Helvetica, sans-serif;
            margin:auto;
        }
        .botones a:hover{
            background: #b94f4f;
        }

                .encabezado2{
                    background:#8f8f8f;
            color:#000000;
            font-family: Arial, Helvetica, sans-serif;
            height: 45px;
            font-size: 11px;
            border: 1px solid #000000;
            width: 90%;
            margin:auto;
        }

        .cuatro{
            font-family:Arial, Helvetica, sans-serif;
            font-size: 12px;
            border:1px solid #000000;
            height:45px;
            text-align:center;
            width:25%;
        }

                .dos{
            font-family:Arial, Helvetica, sans-serif;
            font-size: 12px;
            border:1px solid #000000;
            height:200px;
            text-align:center;
            width:50%;
            
        }
                .uno{
            font-family:Arial, Helvetica, sans-serif;
            font-size: 12px;
            border:1px solid #000000;
            height:45px;
            text-align:center ;
            width:25%;
        }
                                .textarea{
            font-family:Arial, Helvetica, sans-serif;
            font-size: 12px;
            border:1px solid #000000;
            height:200px;
            text-align:center ;
            width:90%;
            margin:auto;
        }

                                .uno2{
            font-family:Arial, Helvetica, sans-serif;
            font-size: 12px;
            border:1px solid #000000;
            height:45px;
            text-align: ;
            width:75%;
        }
        .auto-style1 {
            font-family: Arial, Helvetica, sans-serif;
            font-size: 12px;
            border: 1px solid #000000;
            height: 45px;
            text-align: center;
            width: 75%;
        }
        </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   
    <body>
        <table class="encabezado">
                    <tr>
                <td><strong>1.- ANTECEDENTES DEL PROYECTO</strong></td>
            </tr>
            </table>
        <table style="width: 90%; margin:auto;">
            <tr>
                <td class="cuatro">CARRERA</td>
                <td class="cuatro">
                    <asp:TextBox ID="txtCarrera" runat="server" CausesValidation="True" ReadOnly="True"></asp:TextBox>

                </td>
                <td class="cuatro">AÑO</td>
                <td class="cuatro">
                    <asp:TextBox ID="txtAñoSemestre" runat="server" CausesValidation="True" ReadOnly="True"></asp:TextBox>
                </td>
            </tr>
        </table>

        <table style="width: 90%; margin:auto;">
            <tr>
                <td class="cuatro">N° SEMESTRE</td>
                <td class="cuatro">
                    <asp:TextBox ID="txtNroSemestre" runat="server" CausesValidation="True" ReadOnly="True"></asp:TextBox>
                </td>
                <td class="cuatro">TIPO SEMESTRE&nbsp;</td>
                <td class="cuatro">
                    <asp:TextBox ID="txtTipoSemestre" runat="server" CausesValidation="True" ReadOnly="True"></asp:TextBox>
                </td>
            </tr>
        </table>

        <table style="width: 90%; margin:auto;">
            <tr>
                <td class="uno">NOMBRE DEL PROYECTO</td>
                <td class="auto-style1">
                    <asp:TextBox ID="txtNombre_Proyecto" runat="server" Width="512px" ReadOnly="True"></asp:TextBox>
                </td>
        </table>

        <table style="width: 90%; margin:auto;">
            <tr>
                <td class="uno">DOCENTE RESPONSABLE GPI</td>
                <td class="auto-style1">
                    <asp:TextBox ID="txtDocenteGPI" runat="server" Width="512px" ReadOnly="True"></asp:TextBox>
                </td>
        </table>

                <table style="width: 90%; margin:auto;">
            <tr>
                <td class="uno">DOCENTE RESPONSABLE PEP</td>
                <td class="auto-style1">
                    <asp:TextBox ID="txtDocentePEP" runat="server" Width="512px" ReadOnly="True"></asp:TextBox>
                </td>
        </table>

                <table style="width: 90%; margin:auto;">
            <tr>
                <td class="uno">LINK PITCH ELEVATOR (2 Min. Como máximo)</td>
                <td class="auto-style1">
                    <asp:TextBox ID="txtLinkPitch" runat="server" Width="512px" ReadOnly="True"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="uno">Sucursal</td>
                <td class="auto-style1">
                    <asp:TextBox ID="txtSucursal" runat="server" Width="512px" ReadOnly="True"></asp:TextBox>
                </td>
            </tr>
        </table>
        &nbsp;&nbsp;
                <table class="encabezado">
                    <tr>
                <td><strong>2.- ANTECEDENTES DEL GRUPO DE TRABAJO</strong></td>
            </tr>
            </table>

                        <table style="width: 90%; margin:auto;">
            <tr>
                <td class="uno">NOMBRE DEL GRUPO</td>
                <td class="auto-style1">
                    <asp:TextBox ID="txtNombreGrupo" runat="server" Width="512px" ReadOnly="True"></asp:TextBox>
                </td>
        </table>

        <table style="width: 90%; margin:auto;">
            <tr>
                <td class="cuatro"><strong>ADMINISTRADOR BASE DE DATOS</strong></td>
                <td class="cuatro"><strong>DESARROLLADOR</strong></td>
                <td class="cuatro"><strong>JEFE DE PROYECTO</strong></td>
            </tr>
        </table>

                <table style="width: 90%; margin:auto;">
            <tr>
                <td class="cuatro">
                    <asp:TextBox ID="txtRutDBA" runat="server" ReadOnly="True" TextMode="Password">Rut</asp:TextBox>
                </td>
                <td class="cuatro">
                    <asp:TextBox ID="txtRutProgra" runat="server" ReadOnly="True" TextMode="Password">Rut</asp:TextBox>
                </td>
                <td class="cuatro">
                    <asp:TextBox ID="txtRutJefe" runat="server" ReadOnly="True" TextMode="Password">Rut</asp:TextBox>
                </td>
            </tr>
        </table>

                        <table style="width: 90%; margin:auto;">
            <tr>
                <td class="cuatro">
                    <asp:TextBox ID="txtNombreDBA" runat="server" ReadOnly="True">Nombre Completo</asp:TextBox>
                </td>
                <td class="cuatro">
                    <asp:TextBox ID="txtNomProgra" runat="server" ReadOnly="True">Nombre Completo</asp:TextBox>
                </td>
                <td class="cuatro">
                    <asp:TextBox ID="txtNombreJEfe" runat="server" ReadOnly="True">Nombre Completo</asp:TextBox>
                </td>
            </tr>
        </table>

                <table style="width: 90%; margin:auto;">
            <tr>
                <td class="cuatro">
                    <asp:RadioButton ID="dueñoDba" runat="server" Text="Dueño Idea" GroupName="rdDueñoIdea" Enabled="False" />
                </td>
                <td class="cuatro">
                    <asp:RadioButton ID="dueñoProgra" runat="server" Text="Dueño Idea" GroupName="rdDueñoIdea" Enabled="False" />
                </td>
                <td class="cuatro">
                    <asp:RadioButton ID="dueñoJefe" runat="server" Text="Dueño Idea" GroupName="rdDueñoIdea" Enabled="False" />
                </td>
            </tr>
        </table>
                &nbsp;&nbsp;
                <table class="encabezado">
                    <tr>
                <td><strong>3.- DESCRIPCIÓN DEL PROYECTO</strong></td>
            </tr>
            </table>
                        <table class="encabezado2">
                    <tr>
                <td class="encabezado2"><strong>IDENTIFIACIÓN DEL PROBLEMA</strong>(Contar en sus palabras, cuál es la problemática.)</td>
            </tr>
            </table>
                        <table class="textarea">
                    <tr>
                <td>
                    <asp:TextBox ID="txtIdentificacion" runat="server" Height="177px" Width="1098px" ReadOnly="True"></asp:TextBox>
                        </td>
            </tr>
            </table>
                                <table class="encabezado2">
                    <tr>
                <td class="encabezado2"><strong>ORIGEN DEL PROBLEMA</strong>(Porque surge lo indicado en la identificación del problema, cuál es la causa raíz.)</td>
            </tr>
            </table>
                        <table class="textarea">
                    <tr>
                <td>
                    <asp:TextBox ID="txtOrigen" runat="server" Height="177px" Width="1098px" ReadOnly="True"></asp:TextBox>
                        </td>
            </tr>
            </table>
                                <table class="encabezado2">
                    <tr>
                <td class="encabezado2"><strong>AFECTADOS DEL PROBLEMA</strong>(Indicar quiénes son los afectados e indicar por qué y en qué son afectados.)</td>
            </tr>
            </table>
                        <table class="textarea">
                    <tr>
                <td>
                    <asp:TextBox ID="txtAfectados" runat="server" Height="177px" Width="1098px" ReadOnly="True"></asp:TextBox>
                        </td>
            </tr>
            </table>
                                <table class="encabezado2">
                    <tr>
                <td class="encabezado2"><strong>JUSTIFICACIÓN DEL PROBLEMA</strong>(Porque lo planteado, efectivamente lo ven como un problema.)</td>
            </tr>
            </table>
                        <table class="textarea">
                    <tr>
                <td>
                    <asp:TextBox ID="txtJustificacion" runat="server" Height="177px" Width="1098px" ReadOnly="True"></asp:TextBox>
                        </td>
            </tr>
            </table>
                                <table class="encabezado2">
                    <tr>
                <td class="encabezado2"><strong>PROPUESTA SOLUCIÓN</strong>(Un resumen de la propuesta de solución al problema planteado.)</td>
            </tr>
            </table>
                        <table class="textarea">
                    <tr>
                <td>
                    <asp:TextBox ID="txtPropuesta" runat="server" Height="177px" Width="1098px" ReadOnly="True"></asp:TextBox>
                        </td>
            </tr>
            </table>
                                        <table class="encabezado2">
                    <tr>
                <td class="encabezado2"><strong>DIAGRAMA DE FUNCIONAMIENTO</strong>(Arquitectura o infraestructura Básica de la propuesta de solución.)</td>
            </tr>
            </table>
                <table style="width: 90%; margin:auto;">
            <tr>
                <td class="uno">DIAGRAMA</td>
                <td class="auto-style1">
                    <br />
                    <asp:Image ID="imgDiagrama" runat="server" Height="285px" Width="474px" />
                </td>
        </table>
                        &nbsp;&nbsp;
                <table class="encabezado">
                    <tr>
                <td><strong>4.- DEFINICIONES DEL PROYECTO DE CARACTER OBLIGATORIO</strong></td>
            </tr>
            </table>

            <table class="textarea">
                 <tr>
                    <td>
                    <asp:TextBox ID="txtDefiniciones" runat="server" Height="177px" Width="1098px" ReadOnly="True"></asp:TextBox>
                     </td>
                </tr>
            </table>

                                &nbsp;&nbsp;
                <table class="encabezado">
                    <tr>
                <td><strong>5.- TIPO DE DESARROLLO</strong></td>
            </tr>
            </table>
                <table style="width: 90%; margin:auto;">
            <tr>
                <td class="cuatro">
                    <asp:RadioButton ID="rdWeb" runat="server" Text="Plataforma Web" GroupName="rdTp" Enabled="False" />
                </td>
                <td class="cuatro">
                    <asp:RadioButton ID="rdMovil" runat="server" Text="Aplicación Móvil" GroupName="rdTp" Enabled="False" />
                </td>
                <td class="cuatro">
                    <asp:RadioButton ID="rdArduino" runat="server" Text="Aplicación con Arduino" GroupName="rdTp" Enabled="False" />
                </td>
                <td class="cuatro">
                    <asp:RadioButton ID="rdclienteServidor" runat="server" Text="Aplicación Cliente-Servidor" GroupName="rdTp" Enabled="False" />
                </td>
            </tr>
        </table>

                                        &nbsp;&nbsp;
                <table class="encabezado">
                    <tr>
                <td><strong>6.- TIPO DE NEGOCIO</strong></td>
            </tr>
            </table>
                        <table style="width: 90%; margin:auto;">
            <tr>
                <td class="cuatro">
                    <asp:RadioButton ID="rdEmpren" runat="server" Text="Emprendimiento" GroupName="rdTn" Enabled="False" />
                </td>
                <td class="cuatro">
                    <asp:RadioButton ID="rdVincula" runat="server" Text="Vinculación con el Medio" GroupName="rdTn" Enabled="False" />
                </td>
            </tr>
        </table>

                                                &nbsp;&nbsp;
                <table class="encabezado">
                    <tr>
                <td><strong>7.- TIPOS DE INNOVACIÓN</strong></td>
            </tr>
            </table>
                <table style="width: 90%; margin:auto;">
            <tr>
                <td class="cuatro"><strong>Nuevas Tecnologias</strong></td>
                <td class="cuatro"><strong>Nuevas Tecnologias (Negocio)</strong></td>
            </tr>
        </table>

                <table style="width: 90%; margin:auto;">
            <tr>
                <td class="dos" aria-multiline="True">
                  
                    <asp:RadioButton ID="rdBeacon" runat="server" Text="Beacons" GroupName="rdTinoo" Enabled="False" />
                    <br />
                    <asp:RadioButton ID="rdDron" runat="server" Text="Dron" GroupName="rdTinoo" Enabled="False" />
                    <br />
                    <asp:RadioButton ID="rdDomotica" runat="server" Text="Domótica" GroupName="rdTinoo" Enabled="False" />
                    <br />
                    <asp:RadioButton ID="rdRobotica" runat="server" Text="Robótica" GroupName="rdTinoo" Enabled="False" />
                    <br />
                    <asp:RadioButton ID="rdInternetDeLasCosas" runat="server" Text="Internet de las cosas" GroupName="rdTinoo" Enabled="False" />
                    <br />
                    <asp:RadioButton ID="rdLentesVr" runat="server" Text="Lentes VR" GroupName="rdTinoo" Enabled="False" />
                  
                    <br />
                  
                    <asp:RadioButton ID="rdOtro" runat="server" Text="Otros" GroupName="rdTinoo" Enabled="False" />
                    <br />
                    <asp:TextBox ID="txtOtro" runat="server" Enabled="False"></asp:TextBox>
                  
                </td>
                <td class="dos" aria-multiline="True" class="auto-style2">
                    <asp:RadioButton ID="cbWebPay" runat="server" Text="WebPay-Paypal" GroupName="rdTin" Enabled="False" />
                    <br />
                    <asp:RadioButton ID="cbMigracion" runat="server" Text="Migración de Datos" GroupName="rdTin" Enabled="False" />
                    <br />
                    <asp:RadioButton ID="cbIntegraOtroSis" runat="server" Text="Integración con Otros Sistemas" GroupName="rdTin" Enabled="False" />
                    <br />
                </td>
            </tr>
        </table>
                        <table style="width: 90%; margin:auto;">
            <tr>
                <td class="cuatro">
                    <asp:Button ID="btnPDF" runat="server" OnClick="btnPDF_Click" Text="Descargar PDF" />
                </td>
            </tr>
        </table>
    </body>
</asp:Content>
