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
    public partial class About : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

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
                tickets.Save(HttpContext.Current.Server.MapPath("~/Tickets.xml"));

            }
        }
    }
    

    public class AssessmentTool
    {
        public double jobWaitTime;
        public double queueLength;
        public int jobsNotAddressed;
        public double percentQueueEmpty;
        public double techHoursIdle;

       

        

    }

}