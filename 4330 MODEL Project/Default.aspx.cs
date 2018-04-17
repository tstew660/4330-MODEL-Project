using System;
using System.Collections.Generic;
using System.Linq;
using System.Timers;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using System.Threading;
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
            //this is calling dailyReset everytime the page is reloaded until the timer function is fixed
            dailyReset();
            //Thread timer = new Thread(new ThreadStart(resetTechs));
            


        }
       /* void resetTechs()
        {
            while (true)
            {
                dailyReset();
                Thread.Sleep(1000 * 60 ); // 5 Minutes
            }
        }*/

        

        void dailyReset()
        {
            XmlDocument techs = new XmlDocument();
            techs.Load(HttpContext.Current.Server.MapPath("~/Technician.xml"));
            XmlNodeList nodes = techs.SelectSingleNode("/Technicians").ChildNodes;
            string id = "00";
            int idEnd = 0;
            for (int i = 0; i < nodes.Count; i++)
            {

                string query = string.Format("//*[@id='{0}']", id);

                string query1 = string.Format("//*[@ID='{0}']", id + idEnd.ToString());
                XmlElement el = (XmlElement)techs.SelectSingleNode(query1);
                int hoursRemaining = Int32.Parse(el.GetAttribute("hoursRemaining"));
                int dailyHoursInactive = Int32.Parse(el.GetAttribute("dailyHours"));
                if (hoursRemaining > 0)
                {
                    if ((hoursRemaining - 8) >= 8)
                    {

                        hoursRemaining -= 8;
                        el.SetAttribute("dailyHours", 0.ToString());
                        el.SetAttribute("hoursRemaining", hoursRemaining.ToString());
                    }
                    else
                    {
                       // dailyHoursInactive = 8 - hoursRemaining;
                        el.SetAttribute("dailyHours", (8 - hoursRemaining).ToString());
                        el.SetAttribute("hoursRemaining", 0.ToString());
                    }

                }
                else
                {
                    dailyHoursInactive = 0;
                    el.SetAttribute("dailyHours", 8.ToString());
                }
                idEnd++;
            }
            techs.Save(HttpContext.Current.Server.MapPath("~/Technician.xml"));
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

        protected void setCustJobCount(XmlElement ticketOwner)
        {
            XmlDocument customer = new XmlDocument();
            customer.Load(HttpContext.Current.Server.MapPath("~/Customer.xml"));
            String ownerName = ticketOwner.GetAttribute("owner");
            string query1 = string.Format("//*[@name='{0}']", ownerName);
            XmlElement test = (XmlElement)customer.SelectSingleNode(query1);
            String jobCount = test.GetAttribute("jobCount");
            int x = Int32.Parse(jobCount) + 1;
            test.SetAttribute("jobCount", x.ToString());
            customer.Save(HttpContext.Current.Server.MapPath("~/Customer.xml"));
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
            
           foreach (XmlElement tic in queueList)
            {
                if (tic.GetAttribute("emergency") == "true")
                {
                    XmlElement currEl = tic;
                    queueList.Remove(tic);
                    queueList.Insert(0, currEl);
                    break;
                }

            } 
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
            setCustJobCount(nodeDesc);
            nodeDesc.SetAttribute("old", "true");
            nodeDesc.SetAttribute("dateOpened", DateTime.Now.ToString("yyyy-MM-dd"));
            nodeDesc.SetAttribute("timeOpened", DateTime.Now.ToString("HH:mm"));
            String currUser = nodeName.GetAttribute("name");
            String custNum = nodeDesc.GetAttribute("id");
            DateTime dt1 = DateTime.Parse("07/12/2011");
            DateTime dt2 = DateTime.Now;

            if (dt1.Date > dt2.Date)
            {
                //It's a later date
            }
            else
            {
                //It's an earlier or equal date
            }

            int dailyHours;
            int jobInProgress;
            int jobHours = Int32.Parse(nodeDesc.GetAttribute("hours"));

            try
            {
                XmlElement el = (XmlElement)techs.SelectSingleNode(queryName);
                jobInProgress = Int32.Parse(el.GetAttribute("hoursRemaining"));
                dailyHours = Int32.Parse(el.GetAttribute("dailyHours"));
                if (jobInProgress == 0) {
                    if (jobHours > 8)
                    {
                        el.SetAttribute("dailyHours", 0.ToString());
                        jobHours = (jobHours - 8);
                        el.SetAttribute("hoursRemaining", jobHours.ToString());
                    }
                    else
                    {
                        el.SetAttribute("dailyHours", (dailyHours - jobHours).ToString());
                    }
                }
                else
                {
                   // put error alert here saying a job is already in progress
                }
               
             }
            catch
             {
                dailyHours = 8;
                            }

            tickets.Save(HttpContext.Current.Server.MapPath("~/Tickets.xml"));
            techs.Save(HttpContext.Current.Server.MapPath("~/Technician.xml"));
            Response.Redirect("Receipt.aspx?name="+currUser+"&custID="+custNum);
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