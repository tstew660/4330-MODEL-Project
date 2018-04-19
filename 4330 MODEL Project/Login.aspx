<%@ Page Title="Login" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="_4330_MODEL_Project.Contact" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
     <script>
        
        function popDeny()
        {
            alert("Password is incorrect");
        }
    </script>
    <h3>Employee Login</h3>
    
     <div class="container" style="text-align:center;">
    <label for="uname"><b>Username</b></label>
    <asp:DropDownList runat="server" ID="userField" DataSourceID="username" DataTextField="name" DataValueField="name" style="width:20%"></asp:DropDownList>

         <asp:XmlDataSource ID="username" runat="server" DataFile="~/Technician.xml"></asp:XmlDataSource>
         <br/>
    <label for="psw" ><b>Password</b></label>
    <asp:textbox runat="server" ID="pass" placeholder="Enter Password" TextMode="Password" name="psw"  style="width:20%; font-family: inherit;
    font-size: inherit;
    line-height: inherit;
    margin-left: 2%;
    margin-top: 2%;
    padding: 0.5%;
    border-radius: 5px;
    border-width: 2px;
    border-style: solid;
    border-color: rgb(209, 209, 209);
    border-image: initial;"/>

         <br />
         <label>
      <input type="checkbox" checked="checked" name="remember"> Remember me
    </label>
         <br />

    <asp:button type="button" runat="server" OnClick="onButtonSubmit" Text="Login" style="margin-top:3%;"></asp:button>
         
         
    
  </div>

  


</asp:Content>
