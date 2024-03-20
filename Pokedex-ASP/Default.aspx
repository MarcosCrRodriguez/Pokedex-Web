<%@ Page Title="" Language="C#" MasterPageFile="~/MasterSite.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Pokedex_ASP.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <hr />
    <h1>Pokedex</h1>
    <h5>Bienvenído a la biblioteca Pokémon - para mas <a href="https://www.pokemon.com/el/pokedex" target="_blank" rel="noopener noreferrer">Información</a></h5>
    <br />
    <p>
        Aquí encontraras todos los Pokémons que se encuentren actualmente en nuestra Pokedex. Adentrate en este extraordinario mundo para poder recopilar información acerca de ellos,
        y asi poder tener registro en nuestra Pokedex. Disfruta de la experiencia.
    </p>
    <br />
    <hr />
    <%-- Primero ordenar los pokemons x NumeroPokedex despues la linea 11 --%>
    <%-- Tener un DropDownList para poder tener los pokemon ordenados o en otro orden--%>
    <%-- Tambien poder tener un apartado de "Inicio" inicio en donde explique un poco de que va la página mas otros apartados extras para pensar a futuro --%>
    <%-- Esos apartados podrian ser Inicio - Pokedex - Listado Pokemons - Contacto --%>
    <div class="row row-cols-1 row-cols-md-3 g-4">
        <asp:Repeater ID="repRepetidor" runat="server">
            <ItemTemplate>
                <div class="col">
                    <div class="card" style="width: 18rem;">
                        <img src="<%#Eval("UrlImagen") %>" class="card-img-top" alt="<%#Eval("Nombre") %>">
                        <div class="card-body">
                            <p class="card-text">N.° <%#Eval("NumeroPokedex") %></p>
                            <h5 class="card-title"><%#Eval("Nombre") %></h5>
                        </div>
                        <ul class="list-group list-group-flush">
                            <li class="list-group-item">[<%#Eval("Tipo") %>]</li>
                        </ul>
                        <div class="card-body">
                            <%-- Cuando interactuo con el boton/link (tengo que ver cual dejo), me voy a una pantalla
                                en donde muestro todos los datos del pókemon --%>
                            <%--<a href="DetallePokemon.aspx?id=<%#Eval("NumeroPokedex") %>">Ver Detalle</a>--%>
                            <asp:Button ID="btnAcceder" CssClass="btn btn-primary" runat="server" Text="Acceder" CommandArgument='<%#Eval("ID") %>' CommandName="PokemonID" OnClick="btnAcceder_Click" />
                        </div>
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>

        <%--  
        <%
            foreach (Dominio.Pokemon pokemon in ListaPokemon)
            {
        %>
        <div class="col">
            <div class="card">
                <img src="<%: pokemon.UrlImagen %>" class="card-img-top" alt="<%: pokemon.Nombre %>">
                <div class="card-body">
                    <h5 class="card-title"><%: pokemon.Nombre %></h5>
                    <p class="card-text"><%: pokemon.Descripcion %></p>
                    <a href="DetallePokemon.aspx?id=<%: pokemon.NumeroPokedex %>">Ver Detalle</a>
                </div>
            </div>
        </div>
        <% } %>
        --%>
    </div>
</asp:Content>
