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
                TableCell priority = new TableCell();
                TableCell owner = new TableCell();
                TableCell difficulty = new TableCell();
                TableCell status = new TableCell();
                TableCell submittedBy = new TableCell();
                TableCell hours = new TableCell();
                TableCell description = new TableCell();
                priority.Text = priorityValue;
                owner.Text = sortedTicket.GetAttribute("owner");
                difficulty.Text = sortedTicket.GetAttribute("difficulty");
                status.Text = sortedTicket.GetAttribute("status");
                submittedBy.Text = sortedTicket.GetAttribute("submittedBy");
                hours.Text = sortedTicket.GetAttribute("hours");
                description.Text = sortedTicket.GetAttribute("description");
                row.Cells.Add(priority);
                row.Cells.Add(owner);
                row.Cells.Add(difficulty);
                row.Cells.Add(status);
                row.Cells.Add(submittedBy);
                row.Cells.Add(hours);
                row.Cells.Add(description);
                Queue.Rows.Add(row);
            }

            

            

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