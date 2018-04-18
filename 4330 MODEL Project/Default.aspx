<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="_4330_MODEL_Project._Default" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
      
      <div class="col-xs-12">
    <div class="box">
        <div class="box-header">
              <h3 class="box-title">Responsive Hover Table</h3>

              <div class="box-tools">
                <div class="input-group input-group-sm" style="width: 150px;">
                  <input type="text" name="table_search" class="form-control pull-right" placeholder="Search">

                  <div class="input-group-btn">
                    <button type="submit" class="btn btn-default"><i class="fa fa-search"></i></button>
                  </div>
                </div>
              </div>
            </div>
        <div class="box-body table-responsive no-padding">
   
  
        <asp:Table runat="server" ID="Queue" class="table table-hover" HorizontalAlign="Center">
        <asp:TableRow ID="HeaderRow" runat="server" Font-Bold="true" HorizontalAlign="Center" VerticalAlign="Bottom">
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
        </div>
       
        </div>
          </div>

    
</asp:Content>

