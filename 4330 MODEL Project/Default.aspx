<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="_4330_MODEL_Project._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <style>
        .queue {
    border-collapse: collapse;
    width: 100%;
}

.queuerow {
    border: 1px solid #ddd;
    text-align: left;
    
}
    </style>
   
    

    <asp:Table runat="server" ID="Queue" CssClass="queue">
        <asp:TableRow CssClass="queuerow" ID="HeaderRow" runat="server" Font-Bold="True" HorizontalAlign="Center" VerticalAlign="Bottom">
            <asp:TableCell runat="server" ID="Priority" Text="Priority" />
            <asp:TableCell runat="server" ID="Owmer" Text="Owner" />
            <asp:TableCell runat="server" ID="Difficulty" Text="Difficulty" />
            <asp:TableCell runat="server" ID="Status" Text="Status" />
            <asp:TableCell runat="server" ID="SubmittedBy" Text="Submitted By" />
            <asp:TableCell runat="server" ID="Hours" Text="Hours" />
            <asp:TableCell runat="server" ID="Description" Text="Description" />
            <asp:TableCell runat="server" ID="Accept" Text="Accept Job" />
        </asp:TableRow>

    </asp:Table> 

</asp:Content>
