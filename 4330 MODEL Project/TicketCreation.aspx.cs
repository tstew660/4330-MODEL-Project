using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using System.Xml.Linq;

namespace _4330_MODEL_Project
{
    public partial class TicketCreation : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Difficulty.Items.Insert(0, new ListItem("Select Job Difficulty", ""));
                Difficulty.Items.Insert(1, new ListItem("1", "1"));
                Difficulty.Items.Insert(2, new ListItem("2", "2"));
                Difficulty.Items.Insert(3, new ListItem("3", "3"));

                // Status.Items.Insert(0, new ListItem("Select a Ticket Status", ""));
                // Status.Items.Insert(1, new ListItem("Open", "Open"));
                // Status.Items.Insert(2, new ListItem("Closed", "Closed"));

            }


        }

        protected void insertInitialCust(object sender, EventArgs e)
        {
            Owner.Items.Insert(0, new ListItem("Select a Customer", ""));


        }



        protected void custSubmit(object sender, EventArgs e)
        {
            if (Description.Text == String.Empty ||
            Owner.SelectedIndex == 0 ||
            Difficulty.SelectedIndex == 0 ||


            Hours.Text == String.Empty)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "popDeny()", true);
            }
            else
            {
                XmlDocument tickets = new XmlDocument();
                tickets.Load(HttpContext.Current.Server.MapPath("~/Tickets.xml"));
                XmlDocument techs = new XmlDocument();
                techs.Load(HttpContext.Current.Server.MapPath("~/Technician.xml"));
                string queryCust = string.Format("//*[@loggedIn='{0}']", "true");
                XmlElement currUser = (XmlElement)techs.SelectSingleNode(queryCust);
                String currUserStr = currUser.GetAttribute("name");
                XmlNodeList nodes = tickets.SelectSingleNode("//Queue").ChildNodes;
                int id = nodes.Count;
                var library = XElement.Load(HttpContext.Current.Server.MapPath("~/Tickets.xml"));
                library.Add(new XElement("Ticket",
                new XAttribute("description", Description.Text),
                new XAttribute("owner", Owner.Text),
                new XAttribute("difficulty", Difficulty.Text),
                new XAttribute("status", "Open"),
                new XAttribute("submittedBy", currUserStr),
                new XAttribute("hours", Hours.Text),
                new XAttribute("id", id.ToString()),
                new XAttribute("old", "false"),
                new XAttribute("dateCreated", DateTime.Now.ToString("yyyy-MM-dd")),
                new XAttribute("dateOpened", "waiting"),
                new XAttribute("timeCreated", DateTime.Now.ToString("HH:mm")),
                new XAttribute("timeOpened", "waiting"),
                new XAttribute("emergency", "false")));

                try
                {
                    library.Save(HttpContext.Current.Server.MapPath("~/Tickets.xml"));
                }
                catch
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "popDeny()", true);
                }
                resetFields();
                Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "popConfirm()", true);
            }
        }

        private void resetFields()
        {
            Description.Text = String.Empty;
            Owner.SelectedIndex = 0;
            Difficulty.SelectedIndex = 0;


            Hours.Text = String.Empty;
        }


    }
    
}