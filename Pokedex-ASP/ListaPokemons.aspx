<%@ Page Title="" Language="C#" MasterPageFile="~/MasterSite.Master" AutoEventWireup="true" CodeBehind="ListaPokemons.aspx.cs" Inherits="Pokedex_ASP.ListaPokemons" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
        .lbl-text-border {
            font-size: 16px;
            font-weight: bold;
            padding: 2px 4px; /* Espacio alrededor del texto en relación con el ancho de la ventana */
            border: 0.1vw solid black; /* Ancho del borde en relación con el ancho de la ventana */
            border-radius: 3px; /* Borde redondeado en relación con el ancho de la ventana */
            display: inline-block;
            background-color: #E0FFFF;
        }
    </style>

    <hr />
    <h1>Lista de Pokémons</h1>
    <br />
    <div class="row">
        <div class="col-4">
            <asp:Label runat="server" CssClass="lbl-text-border" Text="
                Busca un Pokémon por su nombre, si ingresas 
                una sola letra se filtrara por los Pokémons
                que contengan misma esa letra en su nombre."></asp:Label>
        </div>
        <div class="col"></div>
    </div>
    <br />
    <div class="row">
        <div class="col-6">
            <div class="mb-3">
                <asp:Label ID="lblFiltrar" runat="server" Text="Filtrar"></asp:Label>
                <asp:TextBox runat="server" ID="txtFiltro" CssClass="form-control" AutoPostBack="true" OnTextChanged="txtFiltro_TextChanged" />
            </div>
        </div>
        <div class="col-6" style="display: flex; flex-direction: column; justify-content: flex-end;">
            <div class="mb-3">
                <asp:CheckBox Text="Filtro Avanzado" runat="server" CssClass=""
                    ID="chkAvanzado" AutoPostBack="true" OnCheckedChanged="chkAvanzado_CheckedChanged" />
            </div>
        </div>
    </div>
    <% if (FiltroAvanzado)
        { %>
    <hr />
    <div class="row">
        <div class="col-3">
            <div class="mb-3">
                <asp:Label runat="server" Text="Tipo"></asp:Label>
                <asp:DropDownList runat="server" ID="ddlTipo" CssClass="form-control"
                    OnSelectedIndexChanged="ddlTipo_SelectedIndexChanged" AutoPostBack="true">
                    <asp:ListItem Text="Fuego" />
                    <asp:ListItem Text="Planta" />
                    <asp:ListItem Text="Agua" />
                    <asp:ListItem Text="Eléctrico" />
                    <asp:ListItem Text="Roca" />
                    <asp:ListItem Text="Lucha" />
                    <asp:ListItem Text="Tierra" />
                    <asp:ListItem Text="Acero" />
                    <asp:ListItem Text="Hielo" />
                    <asp:ListItem Text="Psiquico" />
                    <asp:ListItem Text="Siniestro" />
                    <asp:ListItem Text="Fantasma" />
                    <asp:ListItem Text="Bicho" />
                    <asp:ListItem Text="Veneno" />
                    <asp:ListItem Text="Hada" />
                    <asp:ListItem Text="Dragón" />
                    <asp:ListItem Text="Volador" />
                    <asp:ListItem Text="Normal" />
                </asp:DropDownList>
            </div>
        </div>
        <div class="col-3">
            <div class="mb-3">
                <asp:Label runat="server" Text="Debilidad"></asp:Label>
                <asp:DropDownList runat="server" ID="ddlDebilidad" CssClass="form-control"
                    OnSelectedIndexChanged="ddlDebilidad_SelectedIndexChanged" AutoPostBack="true">
                    <asp:ListItem Text="Fuego" />
                    <asp:ListItem Text="Planta" />
                    <asp:ListItem Text="Agua" />
                    <asp:ListItem Text="Eléctrico" />
                    <asp:ListItem Text="Roca" />
                    <asp:ListItem Text="Lucha" />
                    <asp:ListItem Text="Tierra" />
                    <asp:ListItem Text="Acero" />
                    <asp:ListItem Text="Hielo" />
                    <asp:ListItem Text="Psiquico" />
                    <asp:ListItem Text="Siniestro" />
                    <asp:ListItem Text="Fantasma" />
                    <asp:ListItem Text="Bicho" />
                    <asp:ListItem Text="Veneno" />
                    <asp:ListItem Text="Hada" />
                    <asp:ListItem Text="Dragón" />
                    <asp:ListItem Text="Volador" />
                    <asp:ListItem Text="Normal" />
                </asp:DropDownList>
            </div>
        </div>
        <%--<div class="col-3">
            <div class="mb-3">
                <asp:Label runat="server" Text="Filtro"></asp:Label>
                <asp:TextBox runat="server" ID="txtFiltradoAvanzado" CssClass="form-control" />
            </div>
        </div>--%>
        <div class="col-6"></div>
    </div>
    <div class="row">
        <div class="col-3">
            <div class="mb-3">
                <asp:Button ID="btnBuscar" runat="server" Text="Buscar" OnClick="btnBuscar_Click" CssClass="btn btn-primary" />
            </div>
        </div>
    </div>
    <% }%>
    <br />
    <asp:GridView ID="dgvPokemons" runat="server" DataKeyNames="ID" OnSelectedIndexChanged="dgvPokemons_SelectedIndexChanged"
        OnPageIndexChanging="dgvPokemons_PageIndexChanging" AllowPaging="true" PageSize="12" CssClass="table table-dark table-bordered"
        AutoGenerateColumns="false">
        <Columns>
            <%--<asp:BoundField HeaderText="ID" DataField="ID" HeaderStyle-CssClass="oculto" ItemStyle-CssClass="oculto" />--%>
            <asp:BoundField HeaderText="Número Pokedex" DataField="NumeroPokedex" />
            <asp:BoundField HeaderText="Nombre" DataField="Nombre" />
            <asp:BoundField HeaderText="Tipo" DataField="Tipo" />
            <asp:BoundField HeaderText="Resistencia" DataField="Resistencia" />
            <asp:BoundField HeaderText="Debilidad" DataField="Debilidad" />
            <asp:CommandField ShowSelectButton="true" HeaderText="Edición" SelectText="🖊️" />
        </Columns>
    </asp:GridView>
    <%-- Aca solo debería de poder agregar pokemons --%>
    <a href="FormPokemon.aspx" class="btn btn-primary">Agregar</a>

</asp:Content>
