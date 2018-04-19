<%@ Page Language="C#"  MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Receipt.aspx.cs" Inherits="_4330_MODEL_Project.Receipt1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

   <section class="invoice">
      <!-- title row -->
      <div class="row">
        <div class="col-xs-12">
          <h2 class="page-header">
            <i class="fa fa-globe"></i> Customer Invoice
            <asp:Label runat="server" class="pull-right" ID="receiptDate" Text="today"></asp:Label>
          </h2>
        </div>
        <!-- /.col -->
      </div>
      <!-- info row -->
      <div class="row invoice-info">
        <div class="col-sm-4 invoice-col">
          From
          <address>
            <strong> MODEL Computing Services, Inc.</strong><br>
            100 North St., Suite C<br>
            Baton Rouge, LA 70802<br>
            Phone: (804) 123-5432<br>
            Email: support@modelCS.com
          </address>
        </div>
        <!-- /.col -->
        <div class="col-sm-4 invoice-col">
          To
          <address>
           <strong><asp:Label runat="server" ID="receiptCustomer"></asp:Label></strong> <br>
            795 Folsom Ave, Suite 600<br>
            San Francisco, CA 94107<br>
            Phone: (555) 539-1037<br>
            Email: john.doe@example.com
          </address>
        </div>
        <!-- /.col -->
        <div class="col-sm-4 invoice-col">
          <b>Invoice #007612</b><br>
          <br>
          <b>Order ID:</b> 4F3S8J<br>
          <b>Account:</b> 968-34567
        </div>
        <!-- /.col -->
      </div>
      <!-- /.row -->

      <!-- Table row -->
      <div class="row">
        <div class="col-xs-12 table-responsive">
          <table class="table table-striped">
            <thead>
            <tr>
              <th>Qty</th>
              <th>Technician</th>
              <th>Clocked Hours</th>
              <th>Description</th>
              <th>Subtotal</th>
            </tr>
            </thead>
            <tbody>
            <tr>
              <td runat="server" id="jobNum">1</td>
              <td runat="server" id="receiptTech"></td>
              <td runat="server" id="receiptHours"></td>
              <td runat="server" id="receiptDesc"></td>
              <td runat="server" id="total1"></td>
            </tr>
            </tbody>
          </table>
        </div>
        <!-- /.col -->
      </div>
      <!-- /.row -->

      <div class="row">
        <!-- accepted payments column -->
        <div class="col-xs-6">
          <p class="lead">Payment Methods:</p>
          <img src="admin-lte/img/credit/visa.png" alt="Visa">
          <img src="admin-lte/img/credit/mastercard.png" alt="Mastercard">
          <img src="admin-lte/img/credit/american-express.png" alt="American Express">
          <img src="admin-lte/img/credit/paypal2.png" alt="Paypal">

          <p class="text-muted well well-sm no-shadow" style="margin-top: 10px;">
            Invoice totals are calculated by factoring in the amount of hours required to complete the requested job and the hourly wage of the technician responsible for your submitted job request. For more information, please contact MODEL customer support at <a href="#">support@modelCS.com</a>
          </p>
        </div>
        <!-- /.col -->
        <div class="col-xs-6">
          <p class="lead">Amount Due</p>

          <div class="table-responsive">
            <table class="table">
              <tr>
                <th style="width:50%">Subtotal:</th>
                <td runat="server" id="total2"> $250.30</td>
              </tr>
              <tr>
                <th>Tax (0%):</th>
                <td>$0.00</td>
              </tr>
              <tr>
                <th>Additional Fees:</th>
                <td>$0.00</td>
              </tr>
              <tr>
                <th>Total:</th>
                <td runat="server" id="total3">$265.24</td>
              </tr>
            </table>
          </div>
        </div>
        <!-- /.col -->
      </div>
      <!-- /.row -->

      <!-- this row will not appear when printing -->
      <div class="row no-print">
        <div class="col-xs-12">
          <button type="button" class="btn btn-success pull-right" a href="invoice-print.html" target="_blank"><i class="fa fa-print"></i> Print Receipt
          </button>
          <button type="button" class="btn btn-primary pull-right" style="margin-right: 5px;">
            <i class="fa fa-download"></i> Generate PDF
          </button>
        </div>
      </div>
    </section>
    <!-- /.content -->
    <div class="clearfix"></div>

   
    
    <asp:XmlDataSource ID="Customers" runat="server" DataFile="~/Customer.xml"></asp:XmlDataSource>

</asp:Content>

