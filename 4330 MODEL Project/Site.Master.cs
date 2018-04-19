using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

namespace _4330_MODEL_Project
{
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            XmlDocument techs = new XmlDocument();
            techs.Load(HttpContext.Current.Server.MapPath("~/Technician.xml"));
            string query = string.Format("//*[@loggedIn='{0}']", "true");
            try
            {
                XmlElement el = (XmlElement)techs.SelectSingleNode(query);
                userName.InnerText = "Hi, " + el.GetAttribute("name");
            }
            catch
            {
                userName.InnerText = "Not Logged In";
            }


        }
    }
}
            
        }
    }
}