<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="DetalleArticulo.aspx.cs" Inherits="TPFinalNivel3_Colapaolo.DetalleArticulo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        #sidebar {
            display: none;
            visibility: hidden;
            position: absolute;
            left: -99999px;
        }

        .main {
            margin-left: 0 !important;
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <%--FILA 1--%>
    <div class="row">
        <%--COLUMNA 1--%>
        <div class="col-12 col-lg-6">
            <%--ImagenArticulo--%>
            <div class="d-flex justify-content-center align-items-center">
                <asp:Image ImageUrl="imageurl" runat="server" />
            </div>
            <div class="d-flex justify-content-center align-items-center">

            </div>
        </div>

        <div class="col-12 col-lg-6">

        </div>
    </div>


</asp:Content>
