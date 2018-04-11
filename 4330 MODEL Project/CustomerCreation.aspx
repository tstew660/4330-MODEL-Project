<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CustomerCreation.aspx.cs" Inherits="_4330_MODEL_Project.CustomerCreation" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <script>
        function popConfirm() {
            alert("Customer has been successfully added");
        }
        function popDeny() {
            alert("Customer could not be added");
        }
    </script>
    &nbsp;
    <p>Company Name</p>
    <div>
        
    <asp:TextBox runat="server" ID="CompanyName"></asp:TextBox>
        </div>
    &nbsp;
    <p>Company Address</p>
    <div>
       
    <asp:TextBox runat="server" ID="CompanyAddress"></asp:TextBox>
        </div>
    &nbsp;

    <asp:Button runat="server" Text="Submit" OnCommand="custSubmit"></asp:Button>
    
    <asp:XmlDataSource ID="Customers" runat="server" DataFile="~/Customer.xml"></asp:XmlDataSource>

</asp:Content>
