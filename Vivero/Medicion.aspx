<%@ Page Title=""  Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Medicion.aspx.cs" Inherits="Vivero.Medicion" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <section>
        <asp:Panel runat="server" ID="panelMensajes">
            <asp:Label ID="lblMensaje" runat="server" Text=""></asp:Label>
        </asp:Panel>
        <div class="row">
            <div class="col-md-6">
                <div class="form-group">
                    <asp:Label runat="server" ID="lblHorario" Text="Horario"></asp:Label>
                    <asp:TextBox runat="server" Enabled="false" ID="txtHorario" AutoPostBack="true" Placeholder="hora" CssClass="form-control"></asp:TextBox>

                </div>
                <div class="form-group">
                    <asp:Label runat="server" ID="lblTemporada" Text="Temporada"></asp:Label>
                    <asp:TextBox runat="server" Enabled="false" ID="txtTemporada" AutoPostBack="true" Placeholder="temporada" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="form-group">
                    <asp:Label runat="server" ID="lblTemperatura" Text="Temperatura"></asp:Label>
                    <asp:TextBox runat="server" Enabled="false" ID="txtTemperatura" AutoPostBack="true" Placeholder="temperatura" CssClass="form-control"></asp:TextBox>
                </div>
                    
            </div>
            <div class="col-md-6">
                <div class="form-group">
                    <asp:Label runat="server" ID="lblRegado" Text="Regado?"></asp:Label>
                    <asp:TextBox runat="server" Enabled="false" ID="txtRegado" AutoPostBack="true" Placeholder="regado?" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="form-group">
                    <asp:Label runat="server" ID="lblHumedad" Text="Humedad Inicial"></asp:Label>
                    <asp:TextBox runat="server" Enabled="false" ID="txtHumedad_Inicial" AutoPostBack="true" Placeholder="humedad inicial" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="form-group">
                    <asp:Label runat="server" ID="lblFinal" Text="Humedad Final"></asp:Label>
                    <asp:TextBox runat="server" Enabled="false" ID="txtHumedad_Final" AutoPostBack="true" Placeholder="humedad final" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="form-group">
                    <asp:Label runat="server" ID="lblPronostico" Text="Pronostico"></asp:Label>
                    <asp:TextBox runat="server" Enabled="false" ID="txtPronostico" AutoPostBack="true" Placeholder="Pronostico" CssClass="form-control"></asp:TextBox>
                </div>
                    
             </div>
            </div>

    </section>
    
</asp:Content>
