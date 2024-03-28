<%@ Page Title="" Language="C#" MasterPageFile="~/MasterSite.Master" AutoEventWireup="true" CodeBehind="Contacto.aspx.cs" Inherits="Pokedex_ASP.Contacto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
        .lbl-text-border {
            font-size: 18px;
            font-weight: bold;
            padding: 3px 6px; /* Espacio alrededor del texto en relación con el ancho de la ventana */
            border: 0.1vw solid black; /* Ancho del borde en relación con el ancho de la ventana */
            background-color: #ADD8E6;
            border-radius: 3px; /* Borde redondeado en relación con el ancho de la ventana */
            display: inline-block;
        }

        .lbl-text-error {
            font-size: 16px;
            font-weight: bold;
            padding: 2px 4px; /* Espacio alrededor del texto en relación con el ancho de la ventana */
            background-color: #FFCCCC; /* Fondo rojo suave */
            border: 2px solid #8B0000; /* Borde rojo oscuro de 2px */
            border-radius: 3px; /* Borde redondeado en relación con el ancho de la ventana */
            display: inline-block;
        }

        .imagen-con-borde {
            max-width: 100%; /* La imagen se ajustará al ancho máximo del contenedor */
            height: auto; /* La altura se ajustará automáticamente para mantener la proporción */
            border: 2px solid #ccc; /* Añade un borde de 2px sólido de color gris claro */
            border-radius: 10px; /* Añade un borde redondeado */
            display: block; /* Asegura que la imagen sea un elemento de bloque */
            margin: 0 auto; /* Centra horizontalmente la imagen */
        }
    </style>

    <hr />
    <h1>Contacto</h1>
    <hr />
    <div class="row">
        <div class="col-8">
            <div class="mb-3">
                <asp:Label ID="lblInfo" runat="server" Text="" CssClass="form-label lbl-text-border"></asp:Label>
            </div>
        </div>
    </div>
    <div class="row">
        <div class="col-5">
            <div class="mb-3">
                <asp:Label ID="lblEmail" runat="server" Text="Usuario" CssClass="form-label"></asp:Label>
                <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" type="email"></asp:TextBox>
                <asp:RegularExpressionValidator ErrorMessage="Tiene que ingresar un mail, con su debido formato conteniendo '@' y '.com'..." ControlToValidate="txtEmail" runat="server" ValidationExpression="^[\w-]+(\.[\w-]+)*@([\w-]+\.)+[a-zA-Z]{2,40}$" CssClass="lbl-text-error" />
            </div>
            <div class="mb-3">
                <asp:Label ID="lblAsunto" runat="server" Text="Asunto" CssClass="form-label"></asp:Label>
                <asp:TextBox ID="txtAsunto" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="mb-3">
                <asp:Label ID="lblMensaje" runat="server" Text="Mensaje" CssClass="form-label"></asp:Label>
                <asp:TextBox ID="txtMensaje" runat="server" TextMode="MultiLine" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="mb-3">
                <asp:Label ID="lblComentario" runat="server" Text="" CssClass="form-label lbl-text-border"></asp:Label>
                <asp:Label ID="lblError" runat="server" Text="" CssClass="form-label lbl-text-error"></asp:Label>
            </div>
            <div class="mb-3">
                <asp:Button ID="btnEnviar" runat="server" Text="Enviar" CssClass="btn btn-primary" OnClick="btnEnviar_Click" />
            </div>
        </div>
        <div class="col-1"></div>
        <div class="col-5">
            <br />
            <div class="mb-3" style="justify-content: center; align-content: center; text-align: center;">
                <asp:Image runat="server" ImageUrl="https://grupoact.com.ar/wp-content/uploads/2020/04/placeholder-1024x683.png"
                    ID="imgContacto" CssClass="imagen-con-borde"></asp:Image>
            </div>
        </div>
    </div>
</asp:Content>
