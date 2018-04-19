<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="TicketCreation.aspx.cs" Inherits="_4330_MODEL_Project.TicketCreation" %>
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
     <div class="box box-primary" style:"border-top: none;">

      <div class="box-header with-border" style="border-bottom: 3px solid rgb(209, 209, 209);">

        <h3 class="box-title" style="font-weight:800;">Submit New Ticket</h3>

      </div>

      <div class="form">

        <div class="box-body">

          

          <div class="form-group">

            <label for="companyName">Select Customer</label>
              <br />

            <asp:DropDownList runat="server" ID="Owner" DataSourceID="Customers" DataTextField="name" DataValueField="name" OnDataBound="insertInitialCust"></asp:DropDownList>

          </div>

          <div class="form-group">

            <label for="CompanyAddress">Specify Job Difficulty</label>
              <br />

            <asp:DropDownList runat="server" ID="Difficulty"></asp:DropDownList>

          </div>

          <div class="form-group">

            <label for="companyName">Estimated Hours for Job Completion</label>
              <br />

            <asp:TextBox runat="server" ID="Hours"></asp:TextBox>

          </div>

          <div class="form-group">

            <label for="companyName">Job Description</label>
              <br />

             <asp:TextBox runat="server" ID="Description" placeholder="Enter a brief job description"></asp:TextBox>

          </div>

          <div class="form-group">

           

            <asp:Button runat="server" Text="Submit" OnCommand="custSubmit" type="submit" class="btn btn-primary" style="width:15%; margin-top:2%; margin-left:15.5%; padding-top: 1%; padding-bottom:1%"></asp:Button>

          </div>

        </div>

      </div>
         
  </div>
    
    <asp:XmlDataSource ID="Customers" runat="server" DataFile="~/Customer.xml"></asp:XmlDataSource>

</asp:Content>