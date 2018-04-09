<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="TicketCreation.aspx.cs" Inherits="_4330_MODEL_Project.TicketCreation" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    
    <asp:Label runat="server" ID="O"></asp:Label>
    <asp:DropDownList runat="server" ID="Owner" DataSourceID="Customers" DataTextField="name" DataValueField="name"></asp:DropDownList>

    <asp:XmlDataSource ID="Customers" runat="server" DataFile="~/XMLFile1.xml"></asp:XmlDataSource>

</asp:Content>
