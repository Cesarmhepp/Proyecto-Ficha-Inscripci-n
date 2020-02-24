<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Site1.Master" AutoEventWireup="true" CodeBehind="MisProyectos.aspx.cs" Inherits="WebAutomovil.MisFichas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table style="width:100%;">
        <tr>
            <td>&nbsp;</td>
            <td>
    <asp:TextBox ID="txtFolioEdit" runat="server"></asp:TextBox>
    <asp:Button ID="btnModificar" runat="server" OnClick="btnModificar_Click1" Text="Editar" />
<asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="Data Source=LAPTOP-R6R278BM;Initial Catalog=DB_M1;Integrated Security=True" SelectCommand="ListarMisProyectos" SelectCommandType="StoredProcedure" ProviderName="System.Data.SqlClient">
    <SelectParameters>
        <asp:SessionParameter DefaultValue="rut" Name="rut" SessionField="rut" Type="String" />
    </SelectParameters>
    </asp:SqlDataSource>
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="folio" DataSourceID="SqlDataSource1" CellPadding="4" ForeColor="#333333" GridLines="None" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" HorizontalAlign="Center" Width="861px">
        <AlternatingRowStyle BackColor="White" />
    <Columns>
        <asp:BoundField DataField="folio" HeaderText="Folio" SortExpression="folio" InsertVisible="False" ReadOnly="True" >
        <ItemStyle HorizontalAlign="Center" />
        </asp:BoundField>
        <asp:BoundField DataField="nombre" HeaderText="Nombre Proyecto" SortExpression="nombre" >
        <ItemStyle HorizontalAlign="Center" />
        </asp:BoundField>
        <asp:BoundField DataField="Expr1" HeaderText="Grupo" SortExpression="Expr1" >
        <ItemStyle HorizontalAlign="Center" />
        </asp:BoundField>
        <asp:BoundField DataField="tipo" HeaderText="Tipo Semestre" SortExpression="tipo" >
        <ItemStyle HorizontalAlign="Center" />
        </asp:BoundField>
        <asp:BoundField DataField="numero" HeaderText="Numero Semestre" SortExpression="numero" >
        <ItemStyle HorizontalAlign="Center" />
        </asp:BoundField>
        <asp:BoundField DataField="Año" HeaderText="Año" SortExpression="Año" >
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
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td aria-orientation="horizontal">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
    </table>
    </asp:Content>
