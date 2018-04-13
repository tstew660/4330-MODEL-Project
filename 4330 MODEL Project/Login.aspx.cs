using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

namespace _4330_MODEL_Project
{
     
    public partial class Contact : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void onButtonSubmit(object sender, EventArgs e)
        {
            String currentUser = userField.Text;
            XmlDocument techs = new XmlDocument();
            techs.Load(HttpContext.Current.Server.MapPath("~/Technician.xml"));
            string query = string.Format("//*[@name='{0}']", currentUser);
            XmlElement node = (XmlElement)techs.SelectSingleNode(query);
            node.SetAttribute("loggedIn", "true");
            techs.Save(HttpContext.Current.Server.MapPath("~/Technician.xml"));
            Response.Redirect("Default.aspx");
        }


    }
}