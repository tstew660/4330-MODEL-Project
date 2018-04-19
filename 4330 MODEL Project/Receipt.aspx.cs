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
            String custID = Request.QueryString["custID"];
            XmlDocument tickets = new XmlDocument();
            tickets.Load(HttpContext.Current.Server.MapPath("~/Tickets.xml"));
            XmlDocument techs = new XmlDocument();
            techs.Load(HttpContext.Current.Server.MapPath("~/Technician.xml"));
            string queryCust = string.Format("//*[@id='{0}']", custID);
            string queryTech = string.Format("//*[@name='{0}']", techName);
            XmlElement nodeTech = (XmlElement)techs.SelectSingleNode(queryTech);
            XmlElement nodeCust = (XmlElement)tickets.SelectSingleNode(queryCust);
            String jobHours = nodeCust.GetAttribute("hours");
            String description = nodeCust.GetAttribute("description");
            String wage = nodeTech.GetAttribute("wage");
            String name = nodeCust.GetAttribute("owner");
            int jobHoursAsInt = Int32.Parse(jobHours);
            int wageAsInt = Int32.Parse(wage);
            String cost = (jobHoursAsInt * wageAsInt).ToString();
            receiptCustomer.Text = name;
            receiptDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
            receiptDesc.InnerText = description;
            receiptHours.InnerText = jobHours;
            receiptTech.InnerText = techName;
            total1.InnerText = "$" + cost +".00";
            total2.InnerText = "$" + cost + ".00";
            total3.InnerText = "$" + cost + ".00";
        }
    }
}