<%@ Page Title="" Language="C#" MasterPageFile="~/MasterSite.Master" AutoEventWireup="true" CodeBehind="Error.aspx.cs" Inherits="Pokedex_ASP.Error" %>

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
    <h1>Hubo un problema</h1>
    <div class="row">
        <div class="col-5">
            <div class="mb-3">
                <asp:Label ID="lblError" runat="server" Text="Label" CssClass="lbl-text-error"></asp:Label>
            </div>
        </div>
    </div>
</asp:Content>
