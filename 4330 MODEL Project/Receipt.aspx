<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Receipt.aspx.cs" Inherits="_4330_MODEL_Project.Receipt1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2>MODEL Computing Services</h2>
            <h2>Customer Name</h2>
            <asp:Label ID="CustomerName" runat="server"></asp:Label>
            &nbsp;
            <h2>Job Description</h2>
            <asp:Label ID="Description" runat="server"></asp:Label>
            &nbsp;
            <h2>Hours to Complete</h2>
            <asp:Label ID="Hours" runat="server"></asp:Label>
            &nbsp;
            <h2>Technician Name</h2>
            <asp:Label ID="Tech" runat="server"></asp:Label>
            &nbsp;
            <h2>Cost</h2>
            <asp:Label ID="Cost" runat="server"></asp:Label>
        </div>
    </form>
</body>
</html>
