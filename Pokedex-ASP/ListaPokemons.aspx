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
            background-color: #E0FFFF;
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
    <div class="row bg-dark" style="padding-top: 10px; padding-left: 20px; margin-left: -30px; margin-right: -30px;">
        <div class="col-5">
            <div class="mb-3">
                <asp:Label ID="lblFiltrar" runat="server" Text="Filtrar" Style="color: white;"></asp:Label>
                <asp:TextBox runat="server" ID="txtFiltro" CssClass="form-control" AutoPostBack="true" OnTextChanged="txtFiltro_TextChanged" />
            </div>
        </div>
        <div class="col-2"></div>
        <div class="col-5" style="display: flex; flex-direction: column; justify-content: flex-end;">
            <div class="mb-3">
                <asp:CheckBox Text="Filtro Avanzado" runat="server"
                    ID="chkAvanzado" AutoPostBack="true" OnCheckedChanged="chkAvanzado_CheckedChanged" Style="color: white;" />
            </div>
        </div>
    </div>
    <% if (FiltroAvanzado)
        { %>
    <div class="row bg-secondary" style="padding-top: 25px; padding-left: 20px; margin-left: -25px; margin-right: -30px;">
        <div class="col-3">
            <div class="mb-3">
                <asp:Label runat="server" Text="Tipo" Style="color: white;"></asp:Label>
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
                <asp:Label runat="server" Text="Debilidad" Style="color: white;"></asp:Label>
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
        <div class="col-6"></div>
    </div>
    <div class="row bg-secondary" style="padding-top: 10px; padding-left: 20px; margin-left: -25px; margin-right: -30px;">
        <div class="col-3">
            <div class="mb-3">
                <asp:Label runat="server" Text="" ID="txtMensaje" CssClass="lbl-text-error"></asp:Label>
            </div>
        </div>
    </div>
    <div class="row bg-secondary" style="padding-top: 10px; padding-left: 20px; margin-left: -25px; margin-right: -30px;">
        <div class="col-3">
            <div class="mb-3">
                <asp:Button ID="btnBuscar" runat="server" Text="Buscar" OnClick="btnBuscar_Click" CssClass="btn btn-primary" />
            </div>
        </div>
    </div>
    <% }%>
    <br />
    <asp:GridView ID="dgvPokemons" runat="server" DataKeyNames="ID" OnSelectedIndexChanged="dgvPokemons_SelectedIndexChanged"
        OnPageIndexChanging="dgvPokemons_PageIndexChanging" AllowPaging="true" PageSize="15" CssClass="table table-dark table-bordered"
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
    <div class="row">
        <div class="col-3">
            <div class="mb-3">
                <asp:Label runat="server" Text="" ID="lblSeAgregoCorrect" CssClass="lbl-text-border"></asp:Label>
                <asp:Label runat="server" Text="" ID="lblSeModificoCorrect" CssClass="lbl-text-border"></asp:Label>
                <asp:Label runat="server" Text="" ID="lblSeEliminoCorrect" CssClass="lbl-text-border"></asp:Label>
            </div>
        </div>
    </div>
    <div class="row">
        <div class="col-3">
            <div class="mb-3">
                <a href="FormPokemon.aspx" class="btn btn-primary">Agregar</a>
            </div>
        </div>
    </div>

</asp:Content>
