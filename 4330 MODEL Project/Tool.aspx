<%@ Page Title="About" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Tool.aspx.cs" Inherits="_4330_MODEL_Project.About" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <style>
        .container div:not(.navbar-collapse collapse)  {
            display: flex;
            align-content:space-around;
        }

        .item {
            padding: 15px;
        }
    </style>
    
   <div id="form1" runat="server" class="container">
       
       
            
           
        
                
       <div class="item">
           <h2>Daily Summary</h2>
            <asp:Label ID="CustomerName" runat="server"></asp:Label>
            &nbsp;
            <h3>Average Waiting Time Before Job is Started For The Day</h3>
            <asp:Label ID="waitTime" runat="server"></asp:Label>
            &nbsp;
            <h3>Number of Jobs Not Addressed Sameday </h3>
            <asp:Label ID="jobsLeft" runat="server"></asp:Label>
            &nbsp;
            <h3>Average Queue Length</h3>
            <asp:Label ID="queueLength" runat="server"></asp:Label>
            &nbsp;
            <h3>Empty Queue Percentage</h3>
            <asp:Label ID="queuePercent" runat="server"></asp:Label>
            &nbsp;
            <h3>Idle Hours Per Technician</h3>
            <asp:Label ID="tech" runat="server"></asp:Label>
            <asp:Table runat="server" ID="techTable">
                <asp:TableHeaderRow ID="row" runat="server">
                    <asp:TableHeaderCell ID="Name" runat="server" Text="Technician"></asp:TableHeaderCell>
                    <asp:TableHeaderCell ID="Hours" runat="server" Text="Hours Idle"></asp:TableHeaderCell>
                </asp:TableHeaderRow>
            </asp:Table>
            
            </div>
       <div class="item">
            <h2>Monthly Summary</h2>
            <asp:Label ID="CustomerNameMonth" runat="server"></asp:Label>
            &nbsp;
            <h3>Average Waiting Time Before Job is Started For The Month</h3>
            <asp:Label ID="waitTimeMonth" runat="server"></asp:Label>
            &nbsp;
            <h3>Number of Jobs Not Addressed Sameday </h3>
            <asp:Label ID="jobsLeftMonth" runat="server"></asp:Label>
            &nbsp;
            <h3>Average Queue Length</h3>
            <asp:Label ID="queueLengthMonth" runat="server"></asp:Label>
            &nbsp;
            <h3>Empty Queue Percentage</h3>
            <asp:Label ID="queuePercentMonth" runat="server"></asp:Label>
            &nbsp;
            <h3>Idle Hours Per Technician</h3>
            <asp:Table runat="server" ID="techTableMon">
                <asp:TableHeaderRow ID="TableHeaderRow1" runat="server">
                    <asp:TableHeaderCell ID="TableHeaderCell1" runat="server" Text="Technician"></asp:TableHeaderCell>
                    <asp:TableHeaderCell ID="TableHeaderCell2" runat="server" Text="Hours Idle"></asp:TableHeaderCell>
                </asp:TableHeaderRow>
            </asp:Table>
            <asp:Label ID="techMonth" runat="server"></asp:Label>
           </div>
       <div class="item">
            
            
            
                <h3>Override Queue
                </h3>
            <asp:DropDownList runat="server" ID="queueOver" ></asp:DropDownList>
                <div style="margin-top: 7px;">
            <asp:Button runat="server" Text="Override" OnClick="ManagerOverride"></asp:Button>
                    </div>
            </div>
        
    </div>

</asp:Content>
