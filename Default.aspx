﻿<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="_4330_MODEL_Project._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <script>
       /**  function insertTicket()
        {
           
            Want to grab last row of ticket xml file,
            match owner to customer name, check priority of owner
            insert into queue depending on priority (3 if statements + 1 else)
            grabbing information from xml into queue
             
            var table = document.getElementById("Queue");
            var result = $(xml).find("album").text();
            var row = table.insertRow(0);
            alert("Ticket has been successfully created");
        }*/

    </script>
    <script type="text/javascript">
         $('#Accept').click(function(){ alert("This is how we do it!"); });
    </script>
    

    <asp:Table runat="server" ID="Queue">
        <asp:TableRow ID="HeaderRow" runat="server" Font-Bold="True" HorizontalAlign="Center" VerticalAlign="Bottom">
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
