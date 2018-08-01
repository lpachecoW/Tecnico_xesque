<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Teste_tecnico.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
<title>Teste técnico - Cadastro de documentos</title>
<script src="https://code.jquery.com/jquery-3.3.1.slim.min.js" integrity="sha384-q8i/X+965DzO0rT7abK41JStQIAqVgRVzpbzo5smXKp4YfRvH+8abtTE1Pi6jizo" crossorigin="anonymous"></script>
<script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.14.3/umd/popper.min.js" integrity="sha384-ZMP7rVo3mIykV+2+9J3UJ46jBk0WLaUAdn689aCwoqbBJiSnjAK/l8WvCWPIPm49" crossorigin="anonymous"></script>
<script src="https://stackpath.bootstrapcdn.com/bootstrap/4.1.3/js/bootstrap.min.js" integrity="sha384-ChfqqxuZUCnJSK3+MXmPNIyE6ZbWh2IMqE241rYiqJxyMiZ6OW/JmZQ5stwEULTy" crossorigin="anonymous"></script>
<link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.1.3/css/bootstrap.min.css" integrity="sha384-MCw98/SFnGE8fJT3GXwEOngsV7Zt27NXFoaoApmYm81iuXoPkFOJwJ8ERdknLPMO" crossorigin="anonymous">
   
</head>
<body>
    <form id="form1" runat="server">
        <div>
              <br />  
        <table class="table">  
            <tr>  
                <td>Codigo</td>  
                <td>  
                    <asp:TextBox ID="txtCodigo" runat="server" Width="210px"></asp:TextBox>  
                    <asp:RequiredFieldValidator
                        ID="rfv1"
                        runat="server"
                        ErrorMessage="*Campo obrigatorio"
                        ForeColor="Red"
                        ValidationGroup="vg1"
                        ControlToValidate="txtCodigo">
                    </asp:RequiredFieldValidator>  
                </td>  
                <td> </td>  
            </tr>  
            <tr>  
                <td>Titulo</td>  
                <td>  
                    <asp:TextBox ID="txtTitulo" runat="server"></asp:TextBox>  
                    <asp:RequiredFieldValidator 
                        ID="rfv2" 
                        runat="server" 
                        ErrorMessage="Campo obrigatorio" 
                        ForeColor="Red" 
                        ValidationGroup="vg1" 
                        ControlToValidate="txtTitulo">
                    </asp:RequiredFieldValidator>  
                </td>  
                <td> </td>  
            </tr>  
            <tr>  
                <td>Processo</td>  
                <td>  
                    <asp:TextBox ID="txtProcesso" runat="server" Width="216px"></asp:TextBox>  
                    <asp:RequiredFieldValidator 
                        ID="rfv3" 
                        runat="server" 
                        ErrorMessage="Campo obrigatorio" 
                        ForeColor="Red" 
                        ValidationGroup="vg1" 
                        ControlToValidate="txtProcesso">
                    </asp:RequiredFieldValidator>  
                </td>  
                <td> </td>  
            </tr>  
             <tr>  
                <td>Categoria</td>  
                <td>  
                    <asp:TextBox ID="txtCategoria" runat="server" Width="216px"></asp:TextBox>  
                    <asp:RequiredFieldValidator 
                        ID="rfv4" 
                        runat="server" ErrorMessage="*Campo obrigatorio" 
                        ForeColor="Red" 
                        ValidationGroup="vg1" 
                        ControlToValidate="txtCategoria">
                    </asp:RequiredFieldValidator>  
                </td>  
                <td> </td>  
            </tr>  
            <tr>
                <td>Arquivo</td>
                <td>
                   <asp:FileUpload id="Arquivo"                 
                    runat="server">
                    </asp:FileUpload>
                    
                    <asp:Label id="WarningStatusLabel" ForeColor="Red" runat="server"> </asp:Label>   
                 </td>
             </tr>
            <tr>  
                <td colspan="3">  
                    <asp:Button type="button" CssClass="btn btn-success" ID="btnSalvar" runat="server" Text="Salvar" ValidationGroup="vg1" OnClick="BtnSalvar_Click" />  
                    <asp:Button type="button" CssClass="btn btn-danger" ID="btnCancelar" runat="server" Text="Cancelar" ValidationGroup="vg2" OnClick="BtnCancelar_Click" />  
                </td>  
            </tr>  
        </table>  
       <div class="card">
            <div class="card-header" data-background-color="purple">
                <p class="category">Documentos para procedimentos operacionais da empresa</p>
            </div>
            <asp:GridView ID="grdDocumentos" runat="server" AutoGenerateColumns="False" class="col-md-12">  
            <Columns>  
                <asp:TemplateField HeaderText="Codigo" ControlStyle-CssClass="text-primary">  
                    <ItemTemplate>  
                        <asp:HiddenField ID="hfFunciId" Value='<% #Eval("codigo") %>' runat="server" />  
                        <asp:Label ID="lblNome" runat="server" Text='<% #Bind("codigo") %>'></asp:Label>  
                    </ItemTemplate>  
                </asp:TemplateField>  
                <asp:TemplateField HeaderText="Titulo"  ControlStyle-CssClass="text-primary">  
                    <ItemTemplate>  
                        <asp:Label ID="lblTitulo" runat="server" Text='<% #Bind("titulo") %>'></asp:Label>  
                    </ItemTemplate>  
                </asp:TemplateField>  
                 <asp:TemplateField HeaderText="Processo"  ControlStyle-CssClass="text-primary">  
                    <ItemTemplate>  
                        <asp:Label ID="lblProcesso" runat="server" Text='<% #Bind("processo") %>'></asp:Label>  
                    </ItemTemplate>  
                </asp:TemplateField>  
                 <asp:TemplateField HeaderText="Categoria"  ControlStyle-CssClass="text-primary">  
                    <ItemTemplate>  
                        <asp:Label ID="lblCategoria" runat="server" Text='<% #Bind("categoria") %>'></asp:Label>  
                    </ItemTemplate>  
                </asp:TemplateField>  
                <asp:TemplateField HeaderText="Arquivo"  ControlStyle-CssClass="text-primary">  
                    <ItemTemplate>  
                        <asp:HyperLink ID="hlDownload" runat="server" BorderStyle="None" Style="text-decoration: none;" Target="_self" Text="Download" NavigateUrl='<%#Eval("Arquivo1") %>'>
                        </asp:HyperLink>
                    </ItemTemplate>  
                </asp:TemplateField>  
            </Columns>  
        </asp:GridView>  
           </div>
    </div>
         <asp:Label ID="lblError" runat="server" Font-Bold="True" Font-Size="Medium" ForeColor="Red"></asp:Label>
        <asp:Label ID="lblSucesso" runat="server" Font-Bold="true" Font-Size="Medium" ForeColor="Blue"></asp:Label>
    </form>
   
  </body>

</html>
