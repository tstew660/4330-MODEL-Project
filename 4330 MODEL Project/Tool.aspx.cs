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
using System.Diagnostics;
using System.IO;

namespace _4330_MODEL_Project
{
    public partial class About : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           
            if (!IsPostBack)
            {
                populateDropDown();
                avgTime.Text = AssessmentTool.avgWaitTime;
                queueLeng.Text = AssessmentTool.queueLengthDay;
                emptyQ.Text = AssessmentTool.queuePerDay;
                waitTimeMonth.Text = AssessmentTool.queueWaitMon;
                queueLengthMonth.Text = AssessmentTool.queueLenMon;
                queuePercentMonth.Text = AssessmentTool.queuePerMon;
            }

            XmlDocument techs = new XmlDocument();
            techs.Load(HttpContext.Current.Server.MapPath("~/Technician.xml"));
            
            string queryCurr = string.Format("//*[@loggedIn='{0}']", "true");
            
            XmlElement curr = (XmlElement)techs.SelectSingleNode(queryCurr);
            if (curr.GetAttribute("ID") != "000")
            {
                Response.Redirect("Default.aspx");
            }
            else
            {
                if (!IsPostBack)
                {
                    //Do manager things
                    XmlNodeList nodes = techs.SelectSingleNode("/Technicians").ChildNodes;
                    string id = "00";
                    int idEnd = 0;
                    for (int i = 0; i < nodes.Count; i++)
                    {
                        string query1 = string.Format("//*[@ID='{0}']", id + idEnd.ToString());
                        XmlElement el = (XmlElement)techs.SelectSingleNode(query1);
                        String name = el.GetAttribute("name");
                        int dailyHoursInactive = Int32.Parse(el.GetAttribute("dailyHours"));
                        String id3 = el.GetAttribute("ID");
                        TableRow row = new TableRow();
                        TableCell techIdNum = new TableCell();
                        TableCell techNameFull = new TableCell();
                        TableCell techHoursIdleDay = new TableCell();
                        techNameFull.Text = name;
                        techIdNum.Text = id3;
                        techHoursIdleDay.Text = dailyHoursInactive.ToString();
                        row.Cells.Add(techIdNum);
                        row.Cells.Add(techNameFull);
                        row.Cells.Add(techHoursIdleDay);
                        row.HorizontalAlign = HorizontalAlign.Center;
                        techTable.Rows.Add(row);
                        //Added month part
                        techMonth.Text += name + "   " + dailyHoursInactive + System.Environment.NewLine;
                        idEnd++;
                    }
                    techs.Save(HttpContext.Current.Server.MapPath("~/Technician.xml"));
                    int jobsLeftOver = 0;
                    //var totalTime = TimeSpan.Zero;
                    //int ticketCounter = 0;
                    String today = DateTime.Now.ToString("yyyy-MM-dd");

                    XmlDocument tickets = new XmlDocument();
                    tickets.Load(HttpContext.Current.Server.MapPath("~/Tickets.xml"));
                    XmlNodeList nodesTickets = tickets.SelectSingleNode("//Queue").ChildNodes;
                    for (int i = 0; i < nodesTickets.Count; i++)
                    {
                        string idTicket = i.ToString();
                        string query = string.Format("//*[@id='{0}']", idTicket);
                        XmlElement elTicket = (XmlElement)tickets.SelectSingleNode(query);
                        if (elTicket.GetAttribute("dateOpened") != "waiting")
                        {
                            String created = elTicket.GetAttribute("dateCreated");
                            String opened = elTicket.GetAttribute("dateOpened");
                            if (created != opened)
                            {
                                jobsLeftOver++;
                                jobsLeftOverDay.Text = jobsLeftOver.ToString();
                                //Added month part
                                jobsLeftMonth.Text = jobsLeftOver + " job(s) were not addressed the day they were submitted.";
                            }
                        }
                    }
                    //Commeted out just for right now
                    /*for (int i = 0; i < nodesTickets.Count; i++)
                    {
                        string idTic = i.ToString();
                        string query = string.Format("//*[@id='{0}']", idTic);
                        XmlElement elTic = (XmlElement)tickets.SelectSingleNode(query);
                        if ((elTic.GetAttribute("old") == "true") && (elTic.GetAttribute("dateOpened") == today))
                        {
                            ticketCounter++;
                            String timeCreated = elTic.GetAttribute("timeCreated");
                            String timeOpened = elTic.GetAttribute("timeOpened");
                            TimeSpan time = DateTime.Parse(timeOpened).Subtract(DateTime.Parse(timeCreated));
                            totalTime = totalTime.Add(time);

                        }
                    }
                    TimeSpan avgTime;
                    try
                    {
                        avgTime = new TimeSpan(totalTime.Ticks / ticketCounter);
                        waitTime.Text = avgTime.ToString();
                    }
                    catch
                    {
                        waitTime.Text = "No tickets have been closed today";
                    }
                    
                    
                    tickets.Save(HttpContext.Current.Server.MapPath("~/Tickets.xml"));
                    */
                }
            }
        }

        

        protected void ManagerOverride(object sender, EventArgs e)
        {
            String ticID = queueOver.SelectedValue;
            XmlDocument tickets = new XmlDocument();
            tickets.Load(HttpContext.Current.Server.MapPath("~/Tickets.xml"));
            XmlNodeList nodes = tickets.SelectSingleNode("//Queue").ChildNodes;

            for (int i = 0; i < nodes.Count; i++)
            {
                string id = i.ToString();
                string query = string.Format("//*[@id='{0}']", id);
                XmlElement el = (XmlElement)tickets.SelectSingleNode(query);
                el.SetAttribute("emergency", "false");
            }
            string queryID = string.Format("//*[@description='{0}']", ticID);
            XmlElement overTic = (XmlElement)tickets.SelectSingleNode(queryID);
            overTic.SetAttribute("emergency", "true");
            tickets.Save(HttpContext.Current.Server.MapPath("~/Tickets.xml"));
        }

        protected void populateDropDown()
        {
            XmlDocument xDocument = new XmlDocument();
            xDocument.Load(HttpContext.Current.Server.MapPath("~/Tickets.xml"));
            string query = string.Format("//*[@old='{0}']", "false");
            foreach (XmlNode node in xDocument.SelectNodes(query))
            {
                queueOver.Items.Add(new ListItem(
                    node.Attributes["description"].Value));
            }
            queueOver.DataValueField = "id";
            queueOver.DataTextField = "description";
            queueOver.DataBind();
        }
    }


    

    public class AssessmentTool
    {
        /*added timer for each average we need
         * such as queuelength, time queue is empty
         */
        public static int dayCounter = 0;
        public static String avgWaitTime = "";
        public static String queueLengthDay = "";
        public static String queuePerDay = "";
        public static String queuePerMon = "";
        public static String queueLenMon = "";
        public static String queueWaitMon = "";
        public static void randomMethod(object sender, EventArgs e)
        {
            //wait time before starting
            var totalTime = TimeSpan.Zero;
            int ticketCounter = 0;
            int queueCounter = 0;
            int currentHour =0;
            int queueLengthHour = 0;
            int emptyQueueHours = 0;
            int queueEmpty = 0;
            
            String today = DateTime.Now.ToString("yyyy-MM-dd");

            //opening tickets xml document
            XmlDocument tickets = new XmlDocument();
            String path = AppDomain.CurrentDomain.BaseDirectory + "//Tickets.xml";
            tickets.Load(path);
            //getting list of child nodes in tickets xml doc
            XmlNodeList nodesTickets = tickets.SelectSingleNode("//Queue").ChildNodes;
            //iterating through each child node(ticket) in tickets.xml
            for (int i = 0; i < nodesTickets.Count;i++)
            {
                //specifying which ticket we are looking at by use of ticket ID
                string idTic = i.ToString();
                string query = string.Format("//*[@id='{0}']", idTic);
                XmlElement elTic = (XmlElement)tickets.SelectSingleNode(query);
                //finding all tickets that are in the queue to record the queue length at this hour in the workday
                if (elTic.GetAttribute("old") == "false")
                {
                    //if a ticket's "old" attribute is false it has not yet been closed and is still in the queue, incremement counter that is counting number of tickets in queue
                    queueCounter++;
                }
                //finding all tickets that were closed by technicians on this workday to calculate the average time between ticket submission and a technician opening the ticket
                if ((elTic.GetAttribute("old") == "true") && (elTic.GetAttribute("dateOpened") == today))
                {
                    // incrementing ticket counter so that we can use it to divide by the total time before tickets were addressed later in method (to find average)
                    ticketCounter++;
                    //getting the time the ticket was created
                    String timeCreated = elTic.GetAttribute("timeCreated");
                    //getting the time the ticket was closed
                    String timeOpened = elTic.GetAttribute("timeOpened");
                    //getting the total time this ticket waited before it was opened/closed
                    TimeSpan time = DateTime.Parse(timeOpened).Subtract(DateTime.Parse(timeCreated));
                    //adding the time between creation and opening/closing for this specific ticket to the total amount of time tickets that were closed today had to wait before they were addressed to use later for average
                    totalTime = totalTime.Add(time);
                }
            }
            // declaring avgTime variable here because it gave an error when declared in the try catch. avgTime is the variable for the daily average time tickets had to wait before being addressed.
            TimeSpan avgTime = new TimeSpan();
            try
            {
                //calculating average ***up until this point in time!*** meaning if 3/8 hours in the workday have passed, this is the average at the 3 hour mark.
                avgTime = new TimeSpan(totalTime.Ticks / ticketCounter);
                //replacing the text in the waitTime label on the tool page with the updated average
                //waitTime.Text = avgTime.ToString();
                avgWaitTime = avgTime.ToString();
            }
            catch
            {
                //if no tickets have been closed yet (such as if the workday hours have not yet passed 0 or 1 and a ticket hasn't been opened by a technician yet)
                //waitTime.Text = "No tickets have been closed today";
                avgWaitTime = "No tickets have been closed today";
            }
            //iterating through all tickets to find the average percent of time the queue is empty
            for (int i = 0; i < nodesTickets.Count; i++)
            {
                string ids = i.ToString();
                string query = string.Format("//*[@id='{0}']", ids);
                XmlElement elTic = (XmlElement)tickets.SelectSingleNode(query);
                //If the ticket in the tickets.xml doc's "old" attribute is true, it has been opened and cleared from the queue. 
                //If this is the case, the counter variable "emptyQueueHours" is incremented to use later in this method to see if the number of closed tickets is equal to the total number of tickets in the tickets.xml doc. 
                //If all tickets are closed, then no tickets are in the queue, and therefore the queue is empty. 
                if (elTic.GetAttribute("old") == "true")
                {
                    emptyQueueHours++;
                }
            }
            //now checking is the number of closed tickets is equal to the total number of tickets in the tickets.xml doc.
            if (emptyQueueHours == nodesTickets.Count)
            {
                //If all tickets are closed, then no tickets are in the queue, and therefore the queue is empty. 
                //Therefore this hour is added to the "queueEmpty" counter to later be used to calculate the percent of time that the queue was empty during the workday.
                queueEmpty++;
            }
            //the counter variable "currentHour" is incremented here to calculate correct daily averages by the hour. 
            //For example, in the second hour, averages will be calculated by dividing sums by 2 (hours), in the 7th hour averages will be calculated by dividing sums by 7 (hours)
            currentHour++;
            // queueLengthHour is updated to the current average including the new data for this hour
            queueLengthHour += queueCounter / currentHour;
            //queueLength label is replaced to display the new daily average queue length, including this hour
            //queueLength.Text = queueLength;
            queueLengthDay = queueLengthHour.ToString();
           //queuePercent label is updated to display the new daily average percent of time queue is empty, including data from this hour
           // queuePercent.Text += queueEmpty / currentHour;\
           queuePerDay += queueEmpty / currentHour;
            //saving tickets doc
            tickets.Save(path);
            //incrementing counter variable dayCounter because all of the data for the hour has been calculated. This variable should really be called "hourCounter".
            //once dayCounter reaches 8, the workday is considered over because there are only 8 hours in a workday (dayCounter starts at 0 and goes to 7, totalling 8 hours)
            dayCounter++;
           //if the dayCounter is 8, the day is over and data needs to be averaged in to the monthly totals
            if (dayCounter == 8)
            {
                //reset dayCounter so the next workday will correctly record its data
                dayCounter = 0;
                //queuePercentMonth is the label for the MONTHLY average percent of time the queue is empty. It is totalling the total hours the queue was empty today out of 8 hours to get today's total average and add that to the monthly average. These need to later be divided by the number of days in the month to get the correct average value, but this should not cause actual errors right now, the value will just be incorrect until they're divided by the correct number of total days.
                //queuePercentMonth.Text += queueEmpty / currentHour;
                queuePerMon += queueEmpty / currentHour;
                //queueLengthMonth is the label for the MONTHLY average queue length; this simply adds the day's queueLength value. This will also need to be later divided by the correct number of days.
                //queueLengthMonth.Text += queueLength;
                queueLenMon += queueLengthHour.ToString();
                //waitTimeMonth is the label for the MONTHLY average amount of time a ticket waits before it is opened by a tech.
                //waitTimeMonth.Text += avgTime.ToString();
                queueWaitMon += avgTime.ToString();

            }
        }
    }
            
  

}
