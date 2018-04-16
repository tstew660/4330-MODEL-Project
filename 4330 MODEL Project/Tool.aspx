<%@ Page Title="About" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Tool.aspx.cs" Inherits="_4330_MODEL_Project.About" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    
   <div id="form1" runat="server">
        <div>
            <h2>MODEL Computing Services</h2>
            <h2>Daily Summary</h2>
            <asp:Label ID="CustomerName" runat="server"></asp:Label>
            &nbsp;
            <h2>Average Waiting Time Before Job is Started For The Day</h2>
            <asp:Label ID="waitTime" runat="server"></asp:Label>
            &nbsp;
            <h2>Number of Jobs Not Addressed Sameday </h2>
            <asp:Label ID="jobsLeft" runat="server"></asp:Label>
            &nbsp;
            <h2>Average Queue Length</h2>
            <asp:Label ID="queueLength" runat="server"></asp:Label>
            &nbsp;
            <h2>Empty Queue Percentage</h2>
            <asp:Label ID="queuePercent" runat="server"></asp:Label>
            &nbsp;
            <h2>Idle Hours Per Technician</h2>
            <asp:Label ID="tech" runat="server"></asp:Label>
            <asp:DropDownList runat="server" ID="queueOver" ></asp:DropDownList>
            <asp:Button runat="server" Text="Override" OnClick="ManagerOverride"></asp:Button>

            
            <h2>Monthly Summary</h2>
            <asp:Label ID="CustomerNameMonth" runat="server"></asp:Label>
            &nbsp;
            <h2>Average Waiting Time Before Job is Started For The Month</h2>
            <asp:Label ID="waitTimeMonth" runat="server"></asp:Label>
            &nbsp;
            <h2>Number of Jobs Not Addressed Sameday </h2>
            <asp:Label ID="jobsLeftMonth" runat="server"></asp:Label>
            &nbsp;
            <h2>Average Queue Length</h2>
            <asp:Label ID="queueLengthMonth" runat="server"></asp:Label>
            &nbsp;
            <h2>Empty Queue Percentage</h2>
            <asp:Label ID="queuePercentMonth" runat="server"></asp:Label>
            &nbsp;
            <h2>Idle Hours Per Technician</h2>
            <asp:Label ID="techMonth" runat="server"></asp:Label>

        </div>
    </div>

</asp:Content>
