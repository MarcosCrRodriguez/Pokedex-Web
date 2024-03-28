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
    <h1>Iniciar Sesion</h1>
    <div class="row">
        <div class="col">
            <div class="mb-3">
                <p style="font-size: 20px; font-weight: bold; justify-content: center; align-content: center; text-align: center;">¡TE DAMOS LA BIENVENIDA ENTRENADOR POKÉMON!</p>
            </div>
            <div class="mb-3">
                <p style="font-size: 18px; justify-content: center; align-content: center; text-align: center;">
                    Estamos felices de verte. ¡Adelante y disfruta tu estancia!
                </p>
            </div>
        </div>
    </div>
    <hr />
    <div class="row">
        <div class="col-5">
            <div class="mb-3">
                <asp:Label ID="lblUser" runat="server" Text="User" CssClass="form-label"></asp:Label>
                <asp:TextBox ID="txtUser" runat="server" CssClass="form-control" type="email"></asp:TextBox>
            </div>
            <div class="mb-3">
                <asp:Label ID="lblPassword" runat="server" Text="Password" CssClass="form-label"></asp:Label>
                <asp:TextBox ID="txtPassword" runat="server" CssClass="form-control" type="password"></asp:TextBox>
            </div>
            <div class="mb-3">
                <asp:Label ID="lblMensaje" runat="server" Text="" CssClass="lbl-text-error"></asp:Label>
            </div>
        </div>
        <div class="col-2"></div>
        <div class="col-3">
            <div class="mb-3" style="justify-content: center; align-content: center; text-align: center;">
                <asp:Image runat="server" ImageUrl="https://grupoact.com.ar/wp-content/uploads/2020/04/placeholder-1024x683.png"
                    ID="imgLogin" CssClass="img-fluid mb-3 imagen-con-borde"></asp:Image>
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
    <hr />
    <div class="row">
        <div class="col-1"></div>
        <div class="col">
            <div class="mb-3">
                <p style="font-size: 17px; justify-content: center; align-content: center; text-align: center;">
                    ¡Bienvenido! La Pokédex es una herramienta invaluable para todo entrenador Pokémon. 
                    Diseñada con la finalidad de ser una enciclopedia digital, la Pokédex contiene información detallada sobre las diversas especies de Pokémon que habitan nuestro mundo. 
                    Desde sus características físicas y biológicas hasta sus hábitats naturales y habilidades únicas, la Pokédex te brinda un conocimiento profundo sobre cada criatura que encuentres en tu viaje. 
                    Ya sea que estés buscando completar tu colección, entender mejor a tus compañeros de equipo o simplemente explorar el vasto mundo Pokémon, la Pokédex está aquí para ser tu compañera confiable en esta emocionante aventura. 
                    ¡Explora, descubre y sé el mejor entrenador que puedas ser!
                </p>
            </div>
        </div>
        <div class="col-1"></div>
    </div>
</asp:Content>
