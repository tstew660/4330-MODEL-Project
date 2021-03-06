﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="TicketCreation.aspx.cs" Inherits="_4330_MODEL_Project.TicketCreation" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <script>
        function popConfirm()
        {
            alert("Ticket has been successfully created");
        }
        function popDeny()
        {
            alert("Ticket could not be created");
        }
    </script>
    &nbsp;
    <p>Select Customer</p>
    <div>
        
    <asp:DropDownList runat="server" ID="Owner" DataSourceID="Customers" DataTextField="name" DataValueField="name" OnDataBound="insertInitialCust"></asp:DropDownList>
        </div>
    &nbsp;
    <p>Select Difficulty</p>
    <div>
        
     <asp:DropDownList runat="server" ID="Difficulty"></asp:DropDownList>
        </div>
    &nbsp;
    <p>Select Status</p>
    <div>
        
     <asp:DropDownList runat="server" ID="Status"></asp:DropDownList>
        </div>
    &nbsp;
    <p>Select Technician</p>
    <div>
        
     <asp:DropDownList runat="server" ID="Technician" DataSourceID="Techs" DataTextField="name" DataValueField="name"  OnDataBound="insertInitialTech"></asp:DropDownList>
        <asp:XmlDataSource ID="Techs" runat="server" DataFile="~/Technician.xml"></asp:XmlDataSource>
        </div>
    &nbsp;
    <p>Enter Estimated Hours for Completion</p>
    <div>
        
    <asp:TextBox runat="server" ID="Hours"></asp:TextBox>
        </div>
    &nbsp;
    <p>Enter a Brief Description</p>
    <div>
       
    <asp:TextBox runat="server" ID="Description"></asp:TextBox>
        </div>
    &nbsp;

    <asp:Button runat="server" Text="Submit" OnCommand="custSubmit"></asp:Button>
    
    <asp:XmlDataSource ID="Customers" runat="server" DataFile="~/Customer.xml"></asp:XmlDataSource>

</asp:Content>
