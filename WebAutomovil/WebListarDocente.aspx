<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/MasterDocente.Master" AutoEventWireup="true" CodeBehind="WebListarDocente.aspx.cs" Inherits="WebAutomovil.WebListarDocente" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            margin-left: 0;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:TextBox ID="txtFolio" runat="server"></asp:TextBox>
    <asp:Button ID="btnPDF" runat="server" OnClick="btnPDF_Click" Text="Generar PDF" />
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="Data Source=LAPTOP-R6R278BM;Initial Catalog=DB_M1;Integrated Security=True" SelectCommand="SELECT Proyecto.folio, Proyecto.nombre, Carrera.nombre AS Expr1, Grupo.nombre AS Expr2, Semestre.numero, Semestre.Año, TipoSemestre.tipo, Sucursal.sucursal FROM Grupo INNER JOIN Proyecto ON Grupo.idGru = Proyecto.fk_idGru INNER JOIN Semestre ON Proyecto.fk_idSem = Semestre.idSem INNER JOIN TipoSemestre ON Semestre.fk_idTSem = TipoSemestre.idTSem INNER JOIN Sucursal ON Proyecto.fk_idSuc = Sucursal.idSuc CROSS JOIN Carrera" ProviderName="System.Data.SqlClient"></asp:SqlDataSource>
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="folio" DataSourceID="SqlDataSource1" CellPadding="4" ForeColor="#333333" GridLines="None" HorizontalAlign="Center" CssClass="auto-style1" Width="863px">
        <AlternatingRowStyle BackColor="White" />
        <Columns>
            <asp:BoundField DataField="folio" HeaderText="Folio" InsertVisible="False" ReadOnly="True" SortExpression="folio" >
            <ItemStyle HorizontalAlign="Center" />
            </asp:BoundField>
            <asp:BoundField DataField="nombre" HeaderText="Nombre" SortExpression="nombre" >
            <ItemStyle HorizontalAlign="Center" />
            </asp:BoundField>
            <asp:BoundField DataField="Expr1" HeaderText="Carrera" SortExpression="Expr1" >
            <ItemStyle HorizontalAlign="Center" />
            </asp:BoundField>
            <asp:BoundField DataField="Expr2" HeaderText="Grupo" SortExpression="Expr2" >
            <ItemStyle HorizontalAlign="Center" />
            </asp:BoundField>
            <asp:BoundField DataField="numero" HeaderText="Numero Semestre" SortExpression="numero" >
            <ItemStyle HorizontalAlign="Center" />
            </asp:BoundField>
            <asp:BoundField DataField="Año" HeaderText="Año" SortExpression="Año" >
            <ItemStyle HorizontalAlign="Center" />
            </asp:BoundField>
            <asp:BoundField DataField="tipo" HeaderText="Tipo Semestre" SortExpression="tipo" >
            <ItemStyle HorizontalAlign="Center" />
            </asp:BoundField>
            <asp:BoundField DataField="sucursal" HeaderText="Sucursal" SortExpression="sucursal" >
            <ItemStyle HorizontalAlign="Center" />
            </asp:BoundField>
        </Columns>
        <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
        <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
        <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
        <SortedAscendingCellStyle BackColor="#FDF5AC" />
        <SortedAscendingHeaderStyle BackColor="#4D0000" />
        <SortedDescendingCellStyle BackColor="#FCF6C0" />
        <SortedDescendingHeaderStyle BackColor="#820000" />
    </asp:GridView>
    </asp:Content>
