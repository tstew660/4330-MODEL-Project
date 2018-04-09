<%@ Page Title="Contact" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="_4330_MODEL_Project.Contact" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.</h2>
    <h3>Please Enter Credentials Below</h3>
    
     <div class="container">
    <label for="uname"><b>Username</b></label>
    <input type="text" placeholder="Enter Username" name="uname" required>

    <label for="psw"><b>Password</b></label>
    <input type="password" placeholder="Enter Password" name="psw" required>


    <button type="button" onclick="location.href='Default.aspx'">Login</button>
         
         
    <label>
      <input type="checkbox" checked="checked" name="remember"> Remember me
    </label>
  </div>

  


</asp:Content>
