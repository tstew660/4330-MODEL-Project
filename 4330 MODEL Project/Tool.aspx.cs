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

namespace _4330_MODEL_Project
{
    public partial class About : Page
    {
       
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                populateDropDown();

                //Assign values to ASP controls here
                //Daily first
                //if (monthlyResult != null)
                //Assign monthly
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
                        tech.Text += name + "   " + dailyHoursInactive + System.Environment.NewLine;
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
                                jobsLeft.Text = jobsLeftOver + " job(s) were not addressed the day they were submitted.";
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

        //Daily and monthly string initilaized, day counter outside of function. 
        public static String[] dailyresult = new String[5];
        public static String[] monthlyresult = new String[5];
        public static int dayCounter = 0;
        public static void RandomMethod(object sender, EventArgs e)
        {
            //wait time before starting
            var totalTime = TimeSpan.Zero;
            int ticketCounter = 0;
            int queueCounter = 0;
            int currentHour =0;
            int queueLength = 0;
            int emptyQueueHours = 0;
            int queueEmpty = 0;
            
            String today = DateTime.Now.ToString("yyyy-MM-dd");
            

            XmlDocument tickets = new XmlDocument();
            tickets.Load(HttpContext.Current.Server.MapPath("~/Tickets.xml"));
            XmlNodeList nodesTickets = tickets.SelectSingleNode("//Queue").ChildNodes;
            for (int i = 0; i < nodesTickets.Count;i++)
            {
                string idTic = i.ToString();
                string query = string.Format("//*[@id='{0}']", idTic);
                XmlElement elTic = (XmlElement)tickets.SelectSingleNode(query);
                if (elTic.GetAttribute("old") == "false")
                {
                    queueCounter++;
                }
                if ((elTic.GetAttribute("old") == "true") && (elTic.GetAttribute("dateOpened") == today))
                {
                    ticketCounter++;
                    String timeCreated = elTic.GetAttribute("timeCreated");
                    String timeOpened = elTic.GetAttribute("timeOpened");
                    TimeSpan time = DateTime.Parse(timeOpened).Subtract(DateTime.Parse(timeCreated));
                    totalTime = totalTime.Add(time);
                }
            }
            TimeSpan avgTime = new TimeSpan();
            
            try
            {
                avgTime = new TimeSpan(totalTime.Ticks / ticketCounter);
                
                waitTime.Text = avgTime.ToString();
            }
            catch
            {
                
                waitTime.Text = "No tickets have been closed today";
            }
            //checking if queue is empty during this hour
            for (int i = 0; i < nodesTickets.Count; i++)
            {
                string ids = i.ToString();
                string query = string.Format("//*[@id='{0}']", ids);
                XmlElement elTic = (XmlElement)tickets.SelectSingleNode(query);
                if (elTic.GetAttribute("old") == "true")
                {
                    emptyQueueHours++;
                }
            }
            if (emptyQueueHours == nodesTickets.Count)
            {
                queueEmpty++;
            }
            currentHour++;
            queueLength += queueCounter / currentHour;
           
            queueLength.Text += queueLength;
           
            queuePercent.Text += queueEmpty / currentHour;
            tickets.Save(HttpContext.Current.Server.MapPath("~/Tickets.xml"));
            dayCounter++;
            if (dayCounter == 8)
            {
                dayCounter = 0;
                
                queuePercentMonth.Text += queueEmpty / currentHour;
                
                queueLengthMonth.Text += queueLength;
                
                waitTimeMonth.Text += avgTime.ToString();

                //Assign monthly values to monthly array here
                //monthlyResult[0] = Whatever first monthly data piece is
                //monthlyResult[1] = etc....
            }
            //Assign daily values to daily array here
            //dailyResult[0] = Whatever first daily data piece is
            //dailyResult[1] = etc....

        }
    }
            
  

}