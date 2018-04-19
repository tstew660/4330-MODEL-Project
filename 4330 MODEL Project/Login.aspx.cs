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
        XmlDocument techs = new XmlDocument();
            
        protected void Page_Load(object sender, EventArgs e)
        {
            techs.Load(HttpContext.Current.Server.MapPath("~/Technician.xml"));
            XmlNodeList nodes = techs.SelectSingleNode("//Technicians").ChildNodes;

            for (int i = 0; i < nodes.Count; i++)
            {
                string id = i.ToString();
                string query = string.Format("//*[@id='{0}']", id);
                XmlElement el = (XmlElement)nodes[i];
                el.SetAttribute("loggedIn", "false");
            }
            techs.Save(HttpContext.Current.Server.MapPath("~/Technician.xml"));
        }

        protected void onButtonSubmit(object sender, EventArgs e)
        {
            String currentUser = userField.Text;
            
            techs.Load(HttpContext.Current.Server.MapPath("~/Technician.xml"));
            string query = string.Format("//*[@name='{0}']", currentUser);
            
            XmlElement node = (XmlElement)techs.SelectSingleNode(query);
            node.SetAttribute("loggedIn", "true");
            String password = node.GetAttribute("pass");
            if (password == pass.Text)
            {
                techs.Save(HttpContext.Current.Server.MapPath("~/Technician.xml"));
                Response.Redirect("Default.aspx");
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "popDeny()", true);
            }
        }


    }
}