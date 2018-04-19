<%@ Page Title="About" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Tool.aspx.cs" Inherits="_4330_MODEL_Project.About" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Daily Report</h2>
    <div class="row">
        <div class="col-lg-3 col-xs-6" style="height:150px">
          <!-- small box -->
          <div class="small-box bg-aqua" style="height:85%">
            <div class="inner">
                 <asp:Label runat="server" ID="avgTime" Text="hold" style="font-size: 38px;
    font-weight: bold;
    margin: 0 0 10px 0;
    padding: 0;"></asp:Label>
                 <p>Average Waiting Time Before Job is Started</p>
             
            </div>
          </div>
        </div>
        <!-- ./col -->
        <div class="col-lg-3 col-xs-6" style="height:150px">
          <!-- small box -->
          <div class="small-box bg-green" style="height:85%; background-color:#0932bd !important;">
            <div class="inner">
              <asp:Label runat="server" ID="jobsLeftOverDay" Text="hold" style="font-size: 38px;
    font-weight: bold;
    margin: 0 0 10px 0;
    padding: 0;"></asp:Label>
                  <p>Job(s) Not Addressed Same Day</p>
                </div>
          </div>
        </div>
        <!-- ./col -->
        <div class="col-lg-3 col-xs-6" style="height:150px">
          <!-- small box -->
          <div class="small-box bg-yellow" style="height:85%; background-color:#5809bd !important;">
            <div class="inner">
              <asp:Label runat="server" ID="queueLeng" Text="hold" style="font-size: 38px;
    font-weight: bold;
    margin: 0 0 10px 0;
    padding: 0;"></asp:Label>
                
              <p>Daily Average Queue Length</p>
          </div>
        </div>
            </div>
        <!-- ./col -->

            <div class="col-lg-3 col-xs-6" style="height:150px">
          <!-- small box -->
          <div class="small-box bg-red" style="height:85%; background-color:#8c07b3 !important;">
            <div class="inner">
                 <asp:Label runat="server" ID="emptyQ" Text="hold" style="font-size: 38px;
    font-weight: bold;
    margin: 0 0 10px 0;
    padding: 0;"></asp:Label>
                <p>Daily Empty Queue Percentage</p>
            </div>
            
          </div>
        </div>


       
        <!-- ./col -->
   
        </div>
   
        <div class="col-xs-12">
    <div class="box">
        <div class="box-header">
              <h3 class="box-title" style="font-weight:bold">Today's Idle Technician Hours</h3>

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
   
  
        <asp:Table runat="server" ID="techTable" class="table table-hover" HorizontalAlign="Center">
        <asp:TableRow ID="HeaderRow" runat="server" Font-Bold="true" HorizontalAlign="Center" VerticalAlign="Bottom">
            <asp:TableCell runat="server" ID="techID" Text="Technician ID" />
            <asp:TableCell runat="server" ID="techWName" Text="Technician Name" />
            <asp:TableCell runat="server" ID="idleTbleHours" Text="Current Daily Idle Hours" />
       </asp:TableRow>
            </asp:Table>
        </div>
       
        </div>
          </div>
   
  
            <asp:Label ID="tech" runat="server"></asp:Label>
            <asp:DropDownList runat="server" ID="queueOver" ></asp:DropDownList>
            <asp:Button runat="server" Text="Override" OnClick="ManagerOverride"></asp:Button>

            
            <h2>Monthly Summary</h2>


             <div class="row">
        <div class="col-lg-3 col-xs-6" style="height:150px">
          <!-- small box -->
          <div class="small-box bg-aqua" style="height:85%">
            <div class="inner">
                 <asp:Label runat="server" ID="waitTimeMonth" Text="hold" style="font-size: 38px;
    font-weight: bold;
    margin: 0 0 10px 0;
    padding: 0;"></asp:Label>
                 <p>Average Waiting Time Before Job is Started</p>
             
            </div>
          </div>
        </div>
        <!-- ./col -->
        <div class="col-lg-3 col-xs-6" style="height:150px">
          <!-- small box -->
          <div class="small-box bg-green" style="height:85%; background-color:#0932bd !important;">
            <div class="inner">
              <asp:Label runat="server" ID="jobsLeftMonth" Text="hold" style="font-size: 38px;
    font-weight: bold;
    margin: 0 0 10px 0;
    padding: 0;"></asp:Label>
                  <p>Job(s) Not Addressed Same Day</p>
                </div>
          </div>
        </div>
        <!-- ./col -->
        <div class="col-lg-3 col-xs-6" style="height:150px">
          <!-- small box -->
          <div class="small-box bg-yellow" style="height:85%; background-color:#5809bd !important;">
            <div class="inner">
              <asp:Label runat="server" ID="queueLengthMonth" Text="hold" style="font-size: 38px;
    font-weight: bold;
    margin: 0 0 10px 0;
    padding: 0;"></asp:Label>
                
              <p>Daily Average Queue Length</p>
          </div>
        </div>
            </div>
        <!-- ./col -->

            <div class="col-lg-3 col-xs-6" style="height:150px">
          <!-- small box -->
          <div class="small-box bg-red" style="height:85%; background-color:#8c07b3 !important;">
            <div class="inner">
                 <asp:Label runat="server" ID="queuePercentMonth" Text="hold" style="font-size: 38px;
    font-weight: bold;
    margin: 0 0 10px 0;
    padding: 0;"></asp:Label>
                <p>Daily Empty Queue Percentage</p>
            </div>
            
          </div>
        </div>


       
        <!-- ./col -->
   
        </div>
   
        <div class="col-xs-12">
    <div class="box">
        <div class="box-header">
              <h3 class="box-title" style="font-weight:bold">Today's Idle Technician Hours</h3>

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
   
  
        <asp:Table runat="server" ID="monthHours" class="table table-hover" HorizontalAlign="Center">
        <asp:TableRow ID="monthHoursHead" runat="server" Font-Bold="true" HorizontalAlign="Center" VerticalAlign="Bottom">
            <asp:TableCell runat="server" ID="monthTechID" Text="Technician ID" />
            <asp:TableCell runat="server" ID="monthTechName" Text="Technician Name" />
            <asp:TableCell runat="server" ID="monthTechHours" Text="Current Daily Idle Hours" />
       </asp:TableRow>
            </asp:Table>
        </div>
       
        </div>
          </div>

</asp:Content>
