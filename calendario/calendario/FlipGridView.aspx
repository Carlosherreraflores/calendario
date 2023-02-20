<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FlipGridView.aspx.cs" Inherits="calendario.FlipGridView" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
        <script type="text/javascript">
        function Callreg() {
            var boton = document.getElementById("btn_buscar");
            boton.click();
        }
        </script>
  <title>Untitled Page</title>
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/css/bootstrap.min.css"/>
</head>
<body>
  <form id="form1" runat="server">
      <div style="width:406px; text-align:left; height: 84px;">
      <div style="margin-top: 20px;width: 60px;">
            <asp:DropDownList ID="ddl_ano" runat="server"  onchange="Callreg();">
                <asp:ListItem>2022</asp:ListItem>
                <asp:ListItem>2023</asp:ListItem>
                <asp:ListItem>2024</asp:ListItem>
            </asp:DropDownList>

      </div>
      <div style="margin-top: 20px; width: 60px;">
            <asp:DropDownList ID="ddl_mes" runat="server" onchange="Callreg();">
                <asp:ListItem Value="1">Enero</asp:ListItem>
                <asp:ListItem Value="2">Febrero</asp:ListItem>
                <asp:ListItem Value="3">Marzo</asp:ListItem>
                <asp:ListItem Value="4">Abril</asp:ListItem>
                <asp:ListItem Value="5">Mayo</asp:ListItem>
                <asp:ListItem Value="6">Junio</asp:ListItem>
                <asp:ListItem Value="7">Julio</asp:ListItem>
                <asp:ListItem Value="8">Agosto</asp:ListItem>
                <asp:ListItem Value="9">Septiembre</asp:ListItem>
                <asp:ListItem Value="10">Octubre</asp:ListItem>
                <asp:ListItem Value="11">Noviembre</asp:ListItem>
                <asp:ListItem Value="12">Diciembre</asp:ListItem>
            </asp:DropDownList>
      </div>
     
          </div>
      <div style="margin-top: 20px;">
      <asp:Button ID="btn_buscar" style="visibility:hidden" runat="server" Text="Buscar" OnClick="btn_buscar_find" />
          </div>
      <div style="margin-top: 50px;">
         <asp:GridView ID="GridView1" ShowHeader="false" class="table table-bordered table-condensed table-responsive table-hover" runat="server" AllowSorting="true" OnRowDataBound="GridView1_RowDataBound">
          </asp:GridView>
      </div>
      <div style="margin-top: 20px;">
      <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
          </div>
  </form>
</body>
</html>
