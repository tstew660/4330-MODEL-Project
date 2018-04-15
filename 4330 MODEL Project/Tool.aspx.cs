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
                        idEnd++;
                    }
                    techs.Save(HttpContext.Current.Server.MapPath("~/Technician.xml"));
                    int jobsLeftOver = 0;
                    var totalTime = TimeSpan.Zero;
                    int ticketCounter = 0;
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
                            }
                        }
                    }
                    
                    for (int i = 0; i < nodesTickets.Count; i++)
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
        public static void randomMethod(object sender, EventArgs e)
        {
            
        }





    }

}