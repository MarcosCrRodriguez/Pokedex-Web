<%@ Page Title="" Language="C#" MasterPageFile="~/MasterSite.Master" AutoEventWireup="true" CodeBehind="MiPerfil.aspx.cs" Inherits="Pokedex_ASP.MiPerfil" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
        .lbl-text-error {
            font-size: 16px;
            font-weight: bold;
            padding: 2px 4px; /* Espacio alrededor del texto en relación con el ancho de la ventana */
            border: 0.1vw solid black; /* Ancho del borde en relación con el ancho de la ventana */
            background-color: #E0FFFF;
            border-radius: 3px; /* Borde redondeado en relación con el ancho de la ventana */
            display: inline-block;
            margin: 5px;
        }
    </style>

    <hr />
    <h2>Mi Perfil</h2>
    <hr />

    <div class="row">
        <div class="col-md-4">
            <div class="mb-3">
                <asp:Label runat="server" Text="Usuario" CssClass="form-label"></asp:Label>
                <asp:TextBox runat="server" CssClass="form-control" ID="txtUsuario" style="margin-top: 5px;"></asp:TextBox>
            </div>
            <div class="mb-3">
                <asp:Label runat="server" Text="Nombre" CssClass="form-label"></asp:Label>
                <asp:TextBox runat="server" CssClass="form-control" ID="txtNombre" style="margin-top: 5px;"></asp:TextBox>
                <asp:RequiredFieldValidator ErrorMessage="El nombre es requrido" ControlToValidate="txtNombre" runat="server" CssClass="lbl-text-error"/>            
            </div>
            <div class="mb-3">
                <asp:Label runat="server" Text="Apellido" CssClass="form-label"></asp:Label>
                <asp:TextBox runat="server" CssClass="form-control" ID="txtApellido" style="margin-top: 5px;"></asp:TextBox>
                <asp:RequiredFieldValidator ErrorMessage="El apellido es requrido" ControlToValidate="txtApellido" runat="server" CssClass="lbl-text-error"/>
            </div>
            <div class="mb-3">
                <asp:Label runat="server" Text="Tipo Usuario" CssClass="form-label"></asp:Label>
                <asp:TextBox runat="server" CssClass="form-control" ID="txtTipoUser" style="margin-top: 5px;"></asp:TextBox>
            </div>
            <div class="mb-3">
                <asp:Label runat="server" Text="Fecha Nacimiento" CssClass="form-label"></asp:Label>
                <asp:TextBox runat="server" CssClass="form-control" ID="txtFechaNacimiento" TextMode="Date" style="margin-top: 5px;"></asp:TextBox>
                <asp:RequiredFieldValidator ErrorMessage="La Fecha es requrida" ControlToValidate="txtFechaNacimiento" runat="server" CssClass="lbl-text-error"/>            
            </div>
        </div>
        <div class="col-md-4">
            <div class="mb-3">
                <label runat="server" class="form-label">Imagen Perfil</label>
                <input type="file" id="txtImage" runat="server" class="form-control" style="margin-top: 5px;"/>
            </div>
            <div class="mb-3">
                <asp:Image runat="server" ImageUrl="https://grupoact.com.ar/wp-content/uploads/2020/04/placeholder-1024x683.png"
                    ID="imgPerfil" CssClass="img-fluid mb-3" style="margin-top: 5px; border: 0.2vw solid black;"></asp:Image>
            </div>
            <div class="mb-3">
                <asp:Label ID="lblMensaje" runat="server" Text="" CssClass="lbl-text-error"></asp:Label>
            </div>
        </div>
    </div>
    <div class="row">
        <div lass="col-md-4">
            <div class="mb-3">
                <asp:Button runat="server" Text="Guardar" CssClass="btn btn-primary" ID="btnGuardar" OnClick="btnGuardar_Click" />
            </div>
        </div>
    </div>
</asp:Content>
