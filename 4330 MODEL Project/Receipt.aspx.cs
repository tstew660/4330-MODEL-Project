using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

namespace _4330_MODEL_Project
{
    public partial class Receipt1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            String techName = Request.QueryString["name"];
            String custName = Request.QueryString["custName"];
            XmlDocument tickets = new XmlDocument();
            tickets.Load(HttpContext.Current.Server.MapPath("~/Tickets.xml"));
            XmlDocument techs = new XmlDocument();
            techs.Load(HttpContext.Current.Server.MapPath("~/Technician.xml"));
            string queryCust = string.Format("//*[@owner='{0}']", custName);
            string queryTech = string.Format("//*[@name='{0}']", techName);
            XmlElement nodeTech = (XmlElement)techs.SelectSingleNode(queryTech);
            XmlElement nodeCust = (XmlElement)tickets.SelectSingleNode(queryCust);
            String jobHours = nodeCust.GetAttribute("hours");
            String description = nodeCust.GetAttribute("description");
            String wage = nodeTech.GetAttribute("wage");
            int jobHoursAsInt = Int32.Parse(jobHours);
            int wageAsInt = Int32.Parse(wage);
            String cost = (jobHoursAsInt * wageAsInt).ToString();
            CustomerName.Text = custName;
            Description.Text = description;
            Hours.Text = jobHours;
            Tech.Text = techName;
            Cost.Text = "$" + cost;
        }
    }
}