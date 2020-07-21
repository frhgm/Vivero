<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Medicion.aspx.cs" Inherits="Vivero.Medicion" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <section>
        <asp:Panel runat="server" ID="panelMensajes">
            <asp:Label ID="lblMensaje" runat="server" Text=""></asp:Label>
        </asp:Panel>
        <div class="row">
            <div class="col-md-6">
                <div class="form-group">
                    <asp:Label runat="server" ID="lblHorario" Text="Horario"></asp:Label>
                    <asp:TextBox runat="server" Enabled="false" ID="txtHorario" Placeholder="hora" CssClass="form-control"></asp:TextBox>

                </div>
                <div class="form-group">
                    <asp:Label runat="server" ID="lblTemporada" Text="Temporada"></asp:Label>
                    <asp:TextBox runat="server" Enabled="false" ID="txtTemporada" Placeholder="temporada" CssClass="form-control"></asp:TextBox>
                </div>
                    
            </div>
            <div class="col-md-6">
                <div class="form-group">
                    <asp:Label runat="server" ID="lblTemperatura" Text="Temperatura"></asp:Label>
                    <asp:TextBox runat="server" Enabled="false" ID="txtTemperatura" Placeholder="temperatura" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="form-group">
                    <asp:Label runat="server" ID="lblHumedad" Text="Humedad"></asp:Label>
                    <asp:TextBox runat="server" Enabled="false" ID="txtHumedad" Placeholder="humedad" CssClass="form-control"></asp:TextBox>
                </div>
                    
             </div>
        </div>
        <div class="row">
            <div class="col-md-12">
                <asp:Button runat="server" ID="btnMedir" OnClick="btnMedir_Click" Text="Medir" CssClass="btn btn-primary" />
            </div>
        </div>

    </section>
    
</asp:Content>
