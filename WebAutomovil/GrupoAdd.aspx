<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/MasterDocente.Master" AutoEventWireup="true" CodeBehind="GrupoAdd.aspx.cs" Inherits="WebAutomovil.GrupoAdd" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:FileUpload ID="flExcel" runat="server" />
    <asp:Button ID="btnImportar" runat="server" OnClick="btnImportar_Click" Text="Importar" Width="105px" />
    <asp:GridView ID="gdGrupos" runat="server">
    </asp:GridView>
</asp:Content>
