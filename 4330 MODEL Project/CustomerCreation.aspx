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
    <div class="box box-primary">

      <div class="box-header with-border">

        <h3 class="box-title" style="font-weight:800;">Add New Customer</h3>

      </div>

      <div class="form">

        <div class="box-body">

          <div class="form-group">

            <label for="companyName">Company Name</label>
              <br/>

            <asp:TextBox runat="server" ID="CompanyName" placeholder="Enter Company Name"></asp:TextBox>

          </div>

          <div class="form-group">

            <label for="CompanyAddress">Company Address</label>
              <br/>
            <asp:TextBox runat="server" ID="CompanyAddress" placeholder="Enter Company Address"></asp:TextBox>

          </div>

          <div class="form-group">

            <asp:Button runat="server" Text="Submit" OnCommand="custSubmit" type="submit" class="btn btn-primary" style="width:15%; margin-top:2%; margin-left:15.5%; padding-top: 1%; padding-bottom:1%"></asp:Button>

          </div>

        </div>

      </div>

  </div>
    
    <asp:XmlDataSource ID="Customers" runat="server" DataFile="~/Customer.xml"></asp:XmlDataSource>

</asp:Content>
