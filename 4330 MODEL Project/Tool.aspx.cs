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