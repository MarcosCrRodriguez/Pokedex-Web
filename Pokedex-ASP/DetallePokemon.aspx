<%@ Page Title="" Language="C#" MasterPageFile="~/MasterSite.Master" AutoEventWireup="true" CodeBehind="DetallePokemon.aspx.cs" Inherits="Pokedex_ASP.DetallePokemon" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
        .titulo {
            font-size: 24px; /* Tamaño de la fuente en relación con el ancho de la ventana */
            font-weight: bold;
            text-transform: uppercase;
            padding: 1vw 3vw; /* Espacio alrededor del texto en relación con el ancho de la ventana */
            border: 0.2vw solid black; /* Ancho del borde en relación con el ancho de la ventana */
            border-radius: 1vw; /* Borde redondeado en relación con el ancho de la ventana */
            display: inline-block;
        }

        .lbl-text {
            font-size: 18px;
            font-weight: bold;
        }

        .lbl-text-border {
            font-size: 18px;
            font-weight: bold;
            text-transform: uppercase;
            padding: 3px 6px; /* Espacio alrededor del texto en relación con el ancho de la ventana */
            border: 0.1vw solid black; /* Ancho del borde en relación con el ancho de la ventana */
            border-radius: 4px; /* Borde redondeado en relación con el ancho de la ventana */
            display: inline-block;
        }

        .txt-p {
            font-size: 16px;
        }
    </style>

    <hr />
    <h1>Acerca de un Pokemon</h1>
    <hr />
    <br />
    <div class="row">
        <div class="col-4"></div>
        <div class="col-4">
            <asp:Label ID="lblDatosPokemon" runat="server" Text="" CssClass="titulo"></asp:Label>
        </div>
        <div class="col-4"></div>
    </div>
    <br />
    <br />
    <div class="row">
        <div class="col-2"></div>
        <div class="col-4">
            <asp:Image ID="srcUrl" CssClass="img-fluid" runat="server" />
        </div>
        <div class="col-1"></div>
        <div class="col-3">
            <br />
            <br />
            <asp:Label ID="lblTipo" runat="server" Text="" CssClass="lbl-text"></asp:Label>
            <br />
            <asp:Label ID="lblTipoBorder" runat="server" Text="" CssClass="lbl-text-border"></asp:Label><br />
            <br />
            <asp:Label ID="lblResistencia" runat="server" Text="" CssClass="lbl-text"></asp:Label>
            <br />
            <asp:Label ID="lblResistenciaBorder" runat="server" Text="" CssClass="lbl-text-border"></asp:Label><br />
            <br />
            <asp:Label ID="lblDebilidad" runat="server" Text="" CssClass="lbl-text"></asp:Label>
            <br />
            <asp:Label ID="lblDebilidadBorder" runat="server" Text="" CssClass="lbl-text-border"></asp:Label>
        </div>
        <div class="col-2"></div>
    </div>
    <hr />
    <div class="row">
        <div class="col-2"></div>
        <div class="col">
            <h3>Descripción</h3>
            <asp:Label ID="prfPokemon" runat="server" Text="" CssClass="txt-p"></asp:Label>
        </div>
        <div class="col-2"></div>
    </div>
    <br />
    <br />
    <div class="row">
        <div class="col-10"></div>
        <div class="col-2">
            <asp:Button ID="btnVolverPokedex" runat="server" Text="Volver a la Pokedex" type="button" OnClick="btnVolverPokedex_Click" CssClass="btn btn-primary" />
        </div>
    </div>

</asp:Content>
