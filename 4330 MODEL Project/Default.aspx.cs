using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using System.Xml.Linq;

namespace _4330_MODEL_Project
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            XmlDocument ticket = new XmlDocument();
            ticket.Load(HttpContext.Current.Server.MapPath("~/Tickets.xml"));
            
            string id = "0";
            string query = string.Format("//*[@id='{0}']", id);
            XmlElement el = (XmlElement)ticket.SelectSingleNode(query);
            
            
             

            TableRow row = new TableRow();
            TableCell priorityCell = new TableCell();
            priorityCell.Text = getCustJobCount(el);
            row.Cells.Add(priorityCell);
            Queue.Rows.Add(row);
        }

        protected String getCustJobCount(XmlElement ticketOwner)
        {
            XmlDocument customer = new XmlDocument();
            customer.Load(HttpContext.Current.Server.MapPath("~/Customer.xml"));
            String ownerName = ticketOwner.GetAttribute("owner");
            string query1 = string.Format("//*[@name='{0}']", ownerName);
            XmlElement test = (XmlElement)customer.SelectSingleNode(query1);
            String jobCount = test.GetAttribute("jobCount");

            return jobCount;
        }

        
    }

    public class Queue
    {
        public int length;

        public void sortBy()
        {

        }

        public void displayTickets()
        {

        }

    }


}