<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="ListaArticulos.aspx.cs" Inherits="TPFinalNivel3_Colapaolo.ListaArticulos" %>

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

        .seleccionado > td {
            background-color: lightblue;
            color: black;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <div class="container-fluid border-bottom border-success-subtle mb-3">
        <h1 class="display-6">Lista de Artículos</h1>
    </div>

    <div class="container-fluid bg-success-subtle rounded p-4 vh-80">



        <%--GRID CON PAGINATION--%>
        <asp:GridView ID="dgvArticulos" CssClass="table table-dark table-bordered table-striped-columns table-hover" 
            AutoGenerateColumns="false" runat="server"
            DataKeyNames="Id" OnPageIndexChanging="dgvArticulos_PageIndexChanging"
            AllowPaging="True" PageSize="5" SelectedRowStyle-CssClass="seleccionado">
            <Columns>
                <asp:BoundField HeaderText="Nombre" DataField="Nombre" />
                <asp:BoundField HeaderText="Codigo" DataField="Codigo" />
                <asp:BoundField HeaderText="Marca" DataField="Marca.Descripcion" />
                <asp:BoundField HeaderText="Categoria" DataField="Categoria.Descripcion" />
                <asp:BoundField HeaderText="Precio" DataField="Precio" />

                <asp:CommandField ShowSelectButton="true" SelectText="✍🏻" HeaderText="Accion" />

            </Columns>
        </asp:GridView>

        <asp:Button Text="Agregar" CssClass="btn btn-primary" ID="btnAgregar" runat="server" />

    </div>


</asp:Content>
