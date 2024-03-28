<%@ Page Title="" Language="C#" MasterPageFile="~/MasterSite.Master" AutoEventWireup="true" CodeBehind="Registro.aspx.cs" Inherits="Pokedex_ASP.Registro" %>

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
            margin: 5px;
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
    <h1>Regístro de Usuario</h1>
    <div class="row">
        <div class="col-4">
            <div class="mb-3">
                <p style="font-size: 17px;">Por favor, introduce información fidedigna. Recuerda los datos que ingresaras para el regístro de la cuenta, no compartas tu contraseña con nadie así evitaras tener problemas a futuro.</p>
            </div>
        </div>
    </div>
    <div class="row">
        <div class="col-6">
            <div class="mb-3">
                <p style="font-size: 18px; font-weight: bold;">¡Te deseo una agradable estadía en la página, disfrutala!</p>
            </div>
        </div>
    </div>
    <hr />
    <div class="row">
        <div class="col-5">
            <div class="mb-3">
                <asp:Label ID="lblUser" runat="server" Text="User" CssClass="form-label"></asp:Label>
                <asp:TextBox ID="txtUser" runat="server" CssClass="form-control" type="email"></asp:TextBox>
                <asp:RegularExpressionValidator ErrorMessage="Tiene que ingresar un mail, con su debido formato conteniendo '@' y '.com'..." ControlToValidate="txtUser" runat="server" ValidationExpression="^[\w-]+(\.[\w-]+)*@([\w-]+\.)+[a-zA-Z]{2,40}$" CssClass="lbl-text-error" />
            </div>
            <div class="mb-3">
                <asp:Label ID="lblPassword" runat="server" Text="Password" CssClass="form-label"></asp:Label>
                <asp:TextBox ID="txtPassword" runat="server" CssClass="form-control" type="password"></asp:TextBox>
                <asp:RegularExpressionValidator ErrorMessage="La contraseña tiene que tener entre 6 y 20 caracteres, y con un formato alfanumérico" ControlToValidate="txtPassword" runat="server" ValidationExpression="^[a-zA-Z0-9]{6,20}$" CssClass="lbl-text-error" Type="Integer" />
            </div>
            <div class="mb-3">
                <asp:Label ID="lblMensaje" runat="server" Text="" CssClass="lbl-text-error"></asp:Label>
            </div>
        </div>
        <div class="col-2"></div>
        <div class="col-3">
            <div class="mb-3" style="justify-content: center; align-content: center; text-align: center;">
                <asp:Image runat="server" ImageUrl="https://grupoact.com.ar/wp-content/uploads/2020/04/placeholder-1024x683.png"
                    ID="imgRegistro" CssClass="img-fluid mb-3 imagen-con-borde"></asp:Image>
            </div>
        </div>
    </div>
    <div class="row">
        <div class="col">
            <div class="mb-3">
                <asp:Button ID="btnRegistrar" runat="server" Text="Registrar" CssClass="btn btn-secondary" OnClick="btnRegistrar_Click" />
            </div>
        </div>
    </div>
    <hr />
    <div class="row">
        <div class="col-2"></div>
        <div class="col">
            <div class="mb-3">
                <p style="font-size: 17px; justify-content: center; align-content: center; text-align: center;">
                    ¿Listo para embarcarte en una aventura Pokémon como ninguna otra? 
                    Regístrate ahora en nuestra plataforma de Pokédex y desbloquea un mundo de conocimiento y diversión. 
                    Con acceso a información detallada sobre cada Pokémon, consejos de entrenamiento, y mucho más, ¡te estamos esperando para que comiences tu viaje hacia la maestría Pokémon!
                </p>
            </div>
        </div>
        <div class="col-2"></div>
    </div>
</asp:Content>
