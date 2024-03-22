<%@ Page Title="" Language="C#" MasterPageFile="~/MasterSite.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Pokedex_ASP.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
        .lbl-text-error {
            font-size: 16px;
            font-weight: bold;
            padding: 2px 4px; /* Espacio alrededor del texto en relación con el ancho de la ventana */
            background-color: #FFCCCC; /* Fondo rojo suave */
            border: 2px solid #8B0000; /* Borde rojo oscuro de 2px */
            border-radius: 3px; /* Borde redondeado en relación con el ancho de la ventana */
            display: inline-block;
        }
    </style>

    <hr />
    <h1>Login</h1>
    <hr />
    <div class="row">
        <div class="col-5">
            <div class="mb-3">
                <asp:Label ID="lblUser" runat="server" Text="User"></asp:Label>
                <asp:TextBox ID="txtUser" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
        </div>
    </div>
    <div class="row">
        <div class="col-5">
            <div class="mb-3">
                <asp:Label ID="lblPassword" runat="server" Text="Password"></asp:Label>
                <asp:TextBox ID="txtPassword" runat="server" CssClass="form-control" type="password"></asp:TextBox>
            </div>
        </div>
    </div>
    <div class="row">
        <div class="col-5">
            <div class="mb-3">
                <asp:Label ID="lblMensaje" runat="server" Text="" CssClass="lbl-text-error"></asp:Label>
            </div>
        </div>
    </div>
    <div class="row">
        <div class="col-1">
            <div class="mb-3">
                <asp:Button ID="btnIngresar" runat="server" Text="Ingresar" CssClass="btn btn-primary" OnClick="btnIngresar_Click" />
            </div>
        </div>
        <div class="col">
            <div class="mb-3">
                <a href="Registro.aspx">Registrar</a>
            </div>
        </div>
    </div>
</asp:Content>
