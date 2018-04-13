using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using System.Xml.Linq;
using System.Xml.XPath;

namespace _4330_MODEL_Project
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            

            List<XmlElement> testList = new List<XmlElement>();
            
            fillQueue(testList);

            
        }

        protected int getCustJobCount(XmlElement ticketOwner)
        {
            XmlDocument customer = new XmlDocument();
            customer.Load(HttpContext.Current.Server.MapPath("~/Customer.xml"));
            String ownerName = ticketOwner.GetAttribute("owner");
            string query1 = string.Format("//*[@name='{0}']", ownerName);
            XmlElement test = (XmlElement)customer.SelectSingleNode(query1);
            String jobCount = test.GetAttribute("jobCount");
            int x = Int32.Parse(jobCount);
            return x;
           
        }

        protected void fillQueue(List<XmlElement> queueList)
        {
            XmlDocument tickets = new XmlDocument();
            tickets.Load(HttpContext.Current.Server.MapPath("~/Tickets.xml"));
            XmlNodeList nodes = tickets.SelectSingleNode("//Queue").ChildNodes;
            
            for (int i = 0; i < nodes.Count; i++)
            {
                string id = i.ToString();
                string query = string.Format("//*[@id='{0}']", id);
                XmlElement el = (XmlElement)tickets.SelectSingleNode(query);
                if (el.GetAttribute("old") == "false")
                    queueList.Add(el);
            }

            int n = queueList.Count;
            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - i - 1; j++)
                {
                    if (getCustJobCount(queueList[j]) > getCustJobCount(queueList[j + 1]))
                    {
                        XmlElement temp = queueList[j];
                        queueList[j] = queueList[j + 1];
                        queueList[j + 1] = temp;
                    }
                    
                }
            }

            queueList.Reverse();
            int buttonID = 0;
            foreach(XmlElement sortedTicket in queueList)
            {
                int count = getCustJobCount(sortedTicket);
                String priorityValue = "";
                if (count >= 5)
                    priorityValue = "1";
                else if (count >= 2 && count <= 4)
                    priorityValue = "2";
                else if (count == 1)
                    priorityValue = "3";
                else
                    priorityValue = "4";
                TableRow row = new TableRow();
                LinkButton receipt = new LinkButton();
                receipt.Text = "Accept";
                receipt.ID = buttonID.ToString();
                receipt.Click += new EventHandler(makeCLickable);
                TableCell priority = new TableCell();
                TableCell owner = new TableCell();
                TableCell difficulty = new TableCell();
                TableCell status = new TableCell();
                TableCell submittedBy = new TableCell();
                TableCell hours = new TableCell();
                TableCell description = new TableCell();
                TableCell accept = new TableCell();
                priority.Text = priorityValue;
                owner.Text = sortedTicket.GetAttribute("owner");
                difficulty.Text = sortedTicket.GetAttribute("difficulty");
                status.Text = sortedTicket.GetAttribute("status");
                submittedBy.Text = sortedTicket.GetAttribute("submittedBy");
                hours.Text = sortedTicket.GetAttribute("hours");
                description.Text = sortedTicket.GetAttribute("description");
                accept.Controls.Add(receipt);
                row.Cells.Add(priority);
                row.Cells.Add(owner);
                row.Cells.Add(difficulty);
                row.Cells.Add(status);
                row.Cells.Add(submittedBy);
                row.Cells.Add(hours);
                row.Cells.Add(description);
                row.Cells.Add(accept);
                Queue.Rows.Add(row);
                buttonID++;
            }

            

            

        }

        protected void makeCLickable(object sender, EventArgs e)
        {
            
            LinkButton src = (LinkButton)sender;
            int ID = Int32.Parse(src.ID);
            String description = Queue.Rows[ID + 1].Cells[6].Text;
            XmlDocument tickets = new XmlDocument();
            tickets.Load(HttpContext.Current.Server.MapPath("~/Tickets.xml"));
            XmlDocument techs = new XmlDocument();
            techs.Load(HttpContext.Current.Server.MapPath("~/Technician.xml"));
            string queryDesc = string.Format("//*[@description='{0}']", description);
            XmlElement nodeDesc = (XmlElement)tickets.SelectSingleNode(queryDesc);
            string queryName = string.Format("//*[@loggedIn='{0}']", "true");
            XmlElement nodeName = (XmlElement)techs.SelectSingleNode(queryName);
            nodeDesc.SetAttribute("old", "true");
            tickets.Save(HttpContext.Current.Server.MapPath("~/Tickets.xml"));
            String currUser = nodeName.GetAttribute("name");
            String cust = nodeDesc.GetAttribute("owner");
            Response.Redirect("Receipt.aspx?name="+currUser+"&custName="+cust);
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