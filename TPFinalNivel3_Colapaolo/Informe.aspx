<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Informe.aspx.cs" Inherits="TPFinalNivel3_Colapaolo.Informe" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no" />
    <title>Informe</title>
    <%--iconos bootstrap--%>
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap-icons@1.11.3/font/bootstrap-icons.min.css" />
    <%--Link Bootstrap--%>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.2/dist/css/bootstrap.min.css"
        rel="stylesheet" integrity="sha384-T3c6CoIi6uLrA9TneNEoa7RxnatzjcDSCmG1MXxSR1GAsXEV/Dwwykc2MPK8M2HN" crossorigin="anonymous" />

    <style>
        body {
            font-family: 'Poppins', sans-serif;
        }

        #homeBtn {
            border: 1px solid #198754;
            color: #198754
        }

            #homeBtn:hover {
                background-image: linear-gradient(to bottom, #198754, #44c767);
                border-color: lightgreen;
                color: white;
            }

        .bg-error {
            background: #8B0000;
            background: radial-gradient(circle, rgba(139,0,0,1) 0%, rgba(0,0,0,1) 100%);
        }

        .bg-success {
            background: #008000;
            background: radial-gradient(circle, rgba(0,128,0,1) 0%, rgba(0,0,0,1) 100%);
        }

        .cursorDefault {
            cursor: default;
        }
    </style>

</head>

<body class="bg-error d-flex justify-content-center align-items-center vh-100" id="bodyBg" runat="server">

    <form id="form2" runat="server">

        <div class="bg-white p-4 rounded-5 text-secondary shadow" style="width: 30rem">
            <%--Imagen logo y Error--%>
            <div class="d-flex justify-content-center">
                <img src="./Images/Logo.png" alt="login-icon" style="height: 4rem" />
                <asp:Label Text="#Error#" CssClass="text-center text-danger fs-1 ms-5 fw-bold cursorDefault" ID="lblError" runat="server" />
            </div>
            <%--Linea--%>
            <div class="border-bottom text-center" style="height: 0.9rem"></div>

            <%--Mensaje de error--%>
            <div class="d-flex justify-content-center mt-4">
                <div class="h1 me-2">
                    <i class="bi bi-emoji-frown h1 text-danger" id="iEmoji" runat="server"></i>
                </div>
                <asp:Label Text="Hubo un problema" CssClass="h1 cursorDefault" ID="lblEmoji" runat="server">
                </asp:Label>
            </div>
            <asp:Label ID="lblInforme" Text="" CssClass="d-flex justify-content-center fw-bold text-danger h5 mt-4 text-center mb-4 cursorDefault" runat="server" />

            <%--Linea--%>
            <div class="border-bottom text-center" style="height: 0.9rem"></div>

            <%--Boton Home--%>
            <div class="d-flex justify-content-center mt-4">
                <a class="btn rounded-pill shadow" id="homeBtn" aria-current="page" href="Index.aspx"><i class="bi bi-house me-1"></i>Volver a Home
                </a>
            </div>
        </div>


    </form>

    <%--Link Bootstrap--%>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.2/dist/js/bootstrap.bundle.min.js"
        integrity="sha384-C6RzsynM9kWDrMNeT87bh95OGNyZPhcTNXj1NW7RuBCsyN/o0jlpcV8Qyq46cDfL" crossorigin="anonymous"></script>
</body>
</html>
