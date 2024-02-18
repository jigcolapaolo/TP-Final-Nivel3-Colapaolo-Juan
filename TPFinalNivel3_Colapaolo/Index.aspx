<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="TPFinalNivel3_Colapaolo.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .card-img-top {
            max-width: 100%;
            max-height: 100%;
            object-fit: contain; /* Esto mantendrá la relación de aspecto */
        }

        .card {
            transition: transform 0.3s;
        }

            .card:hover {
                transform: scale(1.05);
            }

                .card:hover .card-title {
                    color: orange;
                }

        #star {
            border-radius: 5px 0 20px 0;
        }

            #star:hover {
                background-color: yellow;
                cursor: pointer;
            }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="row my-4">
        <h1 class="text-secondary display-6">Catálogo</h1>
    </div>


    <div class="row row-cols-1 row-cols-md-3 g-5 mb-4 ms-md-2">

        <%--Repeater--%>
        <asp:Repeater runat="server" ID="repRepeater" OnItemDataBound="repRepeater_ItemDataBound">
            <ItemTemplate>

                <div class="col ms-5 ms-md-0">
                    <%--Card--%>

                    <div class="card shadow" style="width: 16rem;">

                        <%if (Session["user"] != null)
                            {%>
                        <i class="bi bi-star text-warning h4 p-2 bg-success bg-gradient position-absolute" onclick="clickFavorito(this)" id="star"></i>


                        <%} %>

                        <a href="DetalleArticulo.aspx">
                            <img src='<%# string.IsNullOrEmpty(Eval("ImagenUrl").ToString()) ? "./Images/SinImagen.png" : Eval("ImagenUrl") %>'
                                height="300" class="card-img-top" onerror="this.onerror=null;this.src='./Images/SinImagen.png';" alt="Imagen de Artículo" />
                            <div class="card-body">
                                <a href="#" class="link-danger">
                                    <h5 class="card-title"><%#Eval("Nombre") %></h5>
                                </a>
                                <small class="card-text mb-3"><%#Eval("Categoria") %> / <%#Eval("Marca") %></small>
                                <h1 class="card-text">$<%#Eval("Precio") %></h1>
                            </div>
                        </a>
                    </div>
                </div>



            </ItemTemplate>
        </asp:Repeater>


    </div>

</asp:Content>
