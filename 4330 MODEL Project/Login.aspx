<%@ Page Title="Contact" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="_4330_MODEL_Project.Contact" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.</h2>
    <h3>Please Enter Credentials Below</h3>
    
     <div class="container">
    <label for="uname"><b>Username</b></label>
    <asp:DropDownList runat="server" ID="userField" DataSourceID="username" DataTextField="name" DataValueField="name"></asp:DropDownList>

         <asp:XmlDataSource ID="username" runat="server" DataFile="~/Technician.xml"></asp:XmlDataSource>

    <label for="psw"><b>Password</b></label>
    <asp:textbox ID="pass" placeholder="Enter Password" name="psw" runat="server"/>


    <asp:button type="button" runat="server" OnClick="onButtonSubmit" Text="Login"></asp:button>
         
         
    <label>
      <input type="checkbox" checked="checked" name="remember"> Remember me
    </label>
  </div>

  


</asp:Content>
