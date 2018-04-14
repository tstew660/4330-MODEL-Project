using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

namespace _4330_MODEL_Project
{
    public partial class About : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }

    public class AssessmentTool
    {
        public double jobWaitTime;
        public double queueLength;
        public int jobsNotAddressed;
        public double percentQueueEmpty;
        public double techHoursIdle;

        protected void  dailyReport()
        {
            //looping through techs, printing name and hours idle
            XmlDocument techs = new XmlDocument();
            techs.Load(HttpContext.Current.Server.MapPath("~/Technician.xml"));
            

        }

        protected void monthlyReport()
        {

        }
    }

    


}