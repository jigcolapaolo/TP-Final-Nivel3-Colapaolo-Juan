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




    <div class="row my-4 justify-content-between">
        <h1 id="topCat" class="text-secondary display-6">Catálogo</h1>

        <%--Filtro por nombre--%>
        <div class="col-10 col-lg-3">
            <div class="input-group mt-2 mb-2">
                <div class="input-group-text">
                    <i class="bi bi-search"></i>
                </div>
                <asp:TextBox Text="" CssClass="form-control" AutoPostBack="true" OnTextChanged="txtFiltroNombre_TextChanged" placeholder="Buscar por Nombre" ID="txtFiltroNombre" runat="server" />
            </div>
        </div>

    </div>


    <asp:UpdatePanel runat="server">
        <ContentTemplate>


            <div class="row row-cols-1 row-cols-md-3 g-5 mb-4 ms-md-2">

                <%--Repeater--%>
                <asp:Repeater runat="server" ID="repRepeater" OnItemDataBound="repRepeater_ItemDataBound">
                    <ItemTemplate>

                        <div class="col ms-5 ms-md-0">
                            <%--Card--%>
                            <div class="card shadow" style="width: 16rem;">

                                <%if (Session["user"] != null)
                                    {
                                %>
                                <div class="text-warning h4 p-2 bg-success bg-gradient position-absolute" id="star">
                                    <asp:CheckBox ID="chkFavoritoIndex" runat="server" CssClass="btn-check" AutoPostBack="true" OnCheckedChanged="chkFavoritoIndex_CheckedChanged"/>
                                    <asp:Label Text="" CssClass="form-check-label bi bi-star" AssociatedControlID="chkFavoritoIndex" ID="lblStarIndex" runat="server" />
                                </div>

                                <%} %>

                                <a href='DetalleArticulo.aspx?id=<%#Eval("Id") %>&returnUrl=Index.aspx'>
                                    <img src='<%# string.IsNullOrEmpty(Eval("ImagenUrl") as string) ? "./Images/SinImagen.png" : (Eval("ImagenUrl") as string).StartsWith("art") ? "./ImagenArt/" + Eval("ImagenUrl") as string : Eval("ImagenUrl") as string %>'
                                        height="300" class="card-img-top" onerror="this.onerror=null;this.src='./Images/SinImagen.png';" alt="Imagen de Artículo" />
                                    <div class="card-body">
                                        <a href="#" class="link-danger">
                                            <h5 class="card-title"><%#Eval("Nombre") %></h5>
                                        </a>
                                        <small class="card-text mb-3"><%#Eval("Categoria") %> / <%#Eval("Marca") %></small>
                                        <h1 class="card-text">$<%#string.Format("{0:0.00}", Convert.ToDecimal(Eval("Precio"))) %></h1>
                                        <asp:Label Text='<%#Eval("Id") %>' CssClass="d-none" ID="lblIdIndex" runat="server" />
                                    </div>
                                </a>
                            </div>
                        </div>



                    </ItemTemplate>
                </asp:Repeater>


            </div>

        </ContentTemplate>
    </asp:UpdatePanel>

    <%--Flecha Volver a Top--%>
    <a href="#" class="arrow-up">
        <div href="#topCat" class="btn btn-outline-success rounded"><i class="bi bi-arrow-up"></i></div>
    </a>

</asp:Content>
