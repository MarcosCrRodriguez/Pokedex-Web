<%@ Page Title="" Language="C#" MasterPageFile="~/MasterSite.Master" AutoEventWireup="true" CodeBehind="FormPokemon.aspx.cs" Inherits="Pokedex_ASP.FormPokemon" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
        .lbl-error {
            font-weight: bold;
            background-color: #FFCCCC; /* Fondo rojo suave */
            border: 2px solid #8B0000; /* Borde rojo oscuro de 2px */
            padding: 5px; /* Añadir un espacio alrededor del contenido del label */
            display: inline-block; /* Para que el tamaño del label se ajuste automáticamente al contenido */
            border-radius: 5px; /* Para suavizar los bordes del borde */
        }
    </style>

    <hr />
    <h2>Interactuar con la Base de Datos</h2>
    <br />
    <asp:ScriptManager ID="ScriptManagerForm" runat="server"></asp:ScriptManager>
    <div class="row">
        <div class="col-6">
            <div class="mb-3">
                <label for="txtID" class="form-label">Numero Pokedex</label>
                <asp:TextBox runat="server" ID="txtNumeroPokedex" CssClass="form-control" />
            </div>
            <div class="mb-3">
                <label for="txtModelo" class="form-label">Nombre</label>
                <asp:TextBox runat="server" ID="txtNombre" CssClass="form-control" />
            </div>
            <div class="mb-3">
                <label for="ddlColor" class="form-labelt">Tipo</label>
                <asp:DropDownList ID="ddlTipo" CssClass="form-select" runat="server"></asp:DropDownList>
            </div>
            <div class="mb-3">
                <label for="ddlColor" class="form-labelt">Sub Tipo</label>
                <asp:DropDownList ID="ddlSubTipo" CssClass="form-select" runat="server"></asp:DropDownList>
            </div>
            <div class="mb-3">
                <label for="ddlColor" class="form-labelt">Resistencia</label>
                <asp:DropDownList ID="ddlResistencia" CssClass="form-select" runat="server"></asp:DropDownList>
            </div>
            <div class="mb-3">
                <label for="ddlColor" class="form-labelt">Debilidad</label>
                <asp:DropDownList ID="ddlDebilidad" CssClass="form-select" runat="server"></asp:DropDownList>
            </div>
            <hr />
            <div class="mb-3">
                <asp:Label ID="lblMensaje" CssClass="lbl-error" runat="server" Text="" role="alert"></asp:Label>
            </div>
            <div class="mb-3">
                <asp:Button ID="btnAceptar" runat="server" CssClass="btn btn-primary" Text="Aceptar" OnClick="btnAceptar_Click" />
                <asp:Button ID="btnModificar" runat="server" CssClass="btn btn-secondary" Text="Modificar" OnClick="btnModificar_Click" />
                <asp:Button ID="btnEliminar" runat="server" CssClass="btn btn-danger" Text="Eliminar" OnClick="btnEliminar_Click" />
                <asp:Button ID="btnConirmarBaja" runat="server" CssClass="btn btn-danger" Text="Confirmar Baja" OnClick="btnConirmarBaja_Click" />
                <hr />
                <a href="ListaPokemons.aspx">Cancelar</a>
            </div>
        </div>
        <div class="col-6">
            <div class="mb-3">
                <label for="txtDescripcion" class="form-label">Descripcion</label>
                <asp:TextBox runat="server" TextMode="MultiLine" ID="txtDescripcion" CssClass="form-control" />
            </div>
            <asp:UpdatePanel ID="UpdatePanelPokemon" runat="server">
                <ContentTemplate>
                    <div class="mb-3">
                        <label for="txtUrlImagen" class="form-label">Url Imagen</label>
                        <asp:TextBox runat="server" TextMode="MultiLine" ID="txtUrlImagen" CssClass="form-control"
                            AutoPostBack="true" OnTextChanged="txtUrlImagen_TextChanged" />
                    </div>
                    <asp:Image ImageUrl="https://grupoact.com.ar/wp-content/uploads/2020/04/placeholder-1024x683.png"
                        runat="server" ID="imgPokemon" Width="60%" />
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>
</asp:Content>
