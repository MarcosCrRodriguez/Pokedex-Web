<%@ Page Title="" Language="C#" MasterPageFile="~/MasterSite.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Pokedex_ASP.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
        .lbl-text-border {
            font-size: 20px;
            font-weight: bold;
            padding: 3px 6px; /* Espacio alrededor del texto en relación con el ancho de la ventana */
            border: 0.1vw solid black; /* Ancho del borde en relación con el ancho de la ventana */
            background-color: #9ED9A9;
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

        .boton-enlace {
            display: inline-block;
            padding: 10px 20px; /* Ajusta el padding según sea necesario */
            background-color: #007bff; /* Color de fondo del botón */
            color: #fff; /* Color del texto del botón */
            text-decoration: none; /* Quita el subrayado del enlace */
            border-radius: 5px; /* Bordes redondeados */
            border: none; /* Quita el borde del botón */
            cursor: pointer; /* Cambia el cursor al pasar sobre el botón */
            font-size: 16px; /* Tamaño de la fuente del texto del botón */
        }
    </style>

    <hr />
    <h1>Pokedex</h1>
    <h4>Bienvenído a la biblioteca Pokémon - para mas <a href="https://www.pokemon.com/el/pokedex" target="_blank" rel="noopener noreferrer">Información</a></h4>
    <br />
    <p style="font-size: 18px;">
        La Pokédex es tu guía esencial en el mundo Pokémon. 
        Encuentra información detallada sobre cada criatura, desde sus habilidades hasta sus hábitats, ¡todo en un solo lugar! 
        ¡Explora y conoce a tus Pokémon como nunca antes!
    </p>
    <br />
    <hr />
    <div class="row bg-dark" style="padding-top: 15px; padding-left: 20px; margin-left: -30px; margin-right: -30px;">
        <div class="col-5">
            <div class="mb-3">
                <asp:Label ID="lblSerch" runat="server" Text="Numero Pokedex" Style="color: white;"></asp:Label>
            </div>
        </div>
    </div>
    <div class="row bg-dark" style="padding-left: 20px; margin-left: -30px; margin-right: -30px;">
        <div class="col-4">
            <div class="mb-3">
                <asp:TextBox runat="server" ID="txtNumeroSerch" CssClass="form-control" />
                <asp:RegularExpressionValidator ErrorMessage="Ingrese unicamente numeros" ControlToValidate="txtNumeroSerch" runat="server" ValidationExpression="^[0-9]+$" CssClass="lbl-text-error" Type="Integer" Style="margin: 5px;" />
            </div>
        </div>
        <div class="col-3">
            <div class="mb-3">
                <asp:Button ID="btnSerch" runat="server" Text="Buscar" CssClass="btn btn-success" OnClick="btnSerch_Click" />
            </div>
        </div>
        <div class="col-5">
            <div class="mb-3">
                <asp:Label ID="lblInfo" runat="server" Text="Buscar un Pokémon por su numero en la Pokedex" CssClass="lbl-text-border" Style="padding-bottom: 5px;"></asp:Label>
                <asp:Label ID="lblMensaje" runat="server" Text="Ingresa un Numero de la Pokedex existente" CssClass="lbl-text-error" Style="padding-bottom: 5px;"></asp:Label>
            </div>
        </div>
    </div>
    <br />
    <div class="row row-cols-1 row-cols-md-3 g-4">
        <%--<asp:Repeater ID="repRepetidor" runat="server">
            <ItemTemplate>
                <div class="col">
                    <div class="card" style="width: 18rem;">
                        <img src="<%#Eval("UrlImagen") %>" class="card-img-top" alt="<%#Eval("Nombre") %>">
                        <div class="card-body">
                            <p class="card-text">N.° <%#Eval("NumeroPokedex") %></p>
                            <h4 class="card-title"><%#Eval("Nombre") %></h4>
                        </div>
                        <ul class="list-group list-group-flush">
                            <li class="list-group-item">[<%#Eval("Tipo") %>]</li>
                        </ul>
                        <ul class="list-group list-group-flush">
                            <li class="list-group-item" id="subtipoCard">[<%#Eval("SubTipo") %>]</li>
                        </ul>
                        <div class="card-body">
                            <asp:Button ID="btnAcceder" CssClass="btn btn-primary" runat="server" Text="Acceder" CommandArgument='<%#Eval("ID") %>' CommandName="PokemonID" OnClick="btnAcceder_Click" />
                        </div>
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>--%>

          
        <%
            foreach (Dominio.Pokemon pokemon in pokemons)
            {
        %>
        <div class="col">
            <div class="card style="width: 18rem;"">
                <img src="<%: pokemon.UrlImagen %>" class="card-img-top" alt="<%: pokemon.Nombre %>">
                <div class="card-body">
                    <p class="card-text">N.° <%: VerificarNumero(pokemon.NumeroPokedex) %></p>
                    <h4 class="card-title"><%: pokemon.Nombre %></h4>    
                </div>
                <ul class="list-group list-group-flush">
                    <li class="list-group-item">[<%: pokemon.Tipo %>]  <%: ValidarCadenaNinguno(pokemon.SubTipo) %></li>
                </ul>
                <div class="card-body">
                    <a href="DetallePokemon.aspx?id=<%: pokemon.ID %>" class="boton-enlace">Acceder Detalle</a>
                </div>
            </div>
        </div>
        <% } %>
        
    </div>
</asp:Content>
