<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TPFinalNivel3_Colapaolo.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h1>Catalogo</h1>


    <div class="row row-cols-1 row-cols-md-3 g-4 mb-3">


        <asp:Repeater runat="server" ID="repRepeater">
            <ItemTemplate>

                <div class="col">
                    <div class="card" style="width: 18rem;">
                        <img src='<%# string.IsNullOrEmpty(Eval("ImagenUrl").ToString()) ? "./Images/SinImagen.png" : Eval("ImagenUrl") %>' 
                            Height="300" class="card-img-top" onerror="this.onerror=null;this.src='./Images/SinImagen.png';" alt="Imagen de Artículo" />

                        <div class="card-body">
                            <h5 class="card-title"><%#Eval("Nombre") %></h5>
                            <h1 class="card-text"><%#Eval("Precio") %></h1>
                            <a href="#" class="btn btn-primary">Go somewhere</a>
                        </div>
                    </div>
                </div>



            </ItemTemplate>
        </asp:Repeater>


    </div>

</asp:Content>
