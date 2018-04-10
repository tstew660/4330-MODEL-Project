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
    public partial class CustomerCreation : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void custSubmit(object sender, EventArgs e)
        {
            if (CompanyName.Text == String.Empty ||
                CompanyAddress.Text == String.Empty)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "popDeny()", true);
            }
            else
            {
                var library = XElement.Load(HttpContext.Current.Server.MapPath("~/Customer.xml"));
                library.Add(new XElement("Customer",
                new XAttribute("CompanyName", CompanyName.Text),
                new XAttribute("CompanyAddress", CompanyAddress.Text),
                new XAttribute(name: "priority", value: 0),
                new XAttribute(name: "jobCount", value: 0)));
                try
                {
                    library.Save(HttpContext.Current.Server.MapPath("~/Customer.xml"));
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
            CompanyName.Text = String.Empty;
            CompanyAddress.Text = String.Empty;
        }


    }
    /* public class Ticket
     {
         public String description;
         public Customer owner;
         public int difficulty;
         public String status;
         public String submittedBy;
         public double hours;

         public Ticket(String description1, Customer owner1, int difficulty1, String status1, String submittedBy1, double hours1)
         {
             description = description1;
             owner = owner1;
             difficulty = difficulty1;
             status = status1;
             submittedBy = submittedBy1;
             hours = hours1;
         }

         public void creationTimeStamp()
         {

         }

         public void beginingTimeStamp()
         {

         }

         public void submit()
         {

         }

         public void begin()
         {

         }

         public void close()
         {

         }
     }*/
}