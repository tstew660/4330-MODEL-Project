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
            Difficulty.Items.Insert(0, new ListItem("Select Job Difficulty", ""));
            Difficulty.Items.Insert(1, new ListItem("0", "0"));
            Difficulty.Items.Insert(2, new ListItem("1", "1"));
            Difficulty.Items.Insert(3, new ListItem("2", "2"));
            Difficulty.Items.Insert(4, new ListItem("3", "3"));
            Difficulty.Items.Insert(5, new ListItem("4", "4"));
            Difficulty.Items.Insert(6, new ListItem("5", "5"));

            Status.Items.Insert(0, new ListItem("Select a Ticket Status", ""));
            Status.Items.Insert(1, new ListItem("Open", "Open"));
            Status.Items.Insert(2, new ListItem("Closed", "Closed"));

            


        }

        protected void insertInitialCust(object sender, EventArgs e)
        {
            Owner.Items.Insert(0, new ListItem("Select a Customer", ""));

           
        }

        protected void insertInitialTech(object sender, EventArgs e)
        {
            

            Technician.Items.Insert(0, new ListItem("Select a Technician", ""));
        }

        protected void custSubmit(object sender, EventArgs e)
        {
            
            var library = XElement.Load("C:\\Users\\Tyler Stewart\\source\\repos\\4330 MODEL Project\\4330 MODEL Project\\Tickets.xml");
            library.Add(new XElement("Ticket",
            new XAttribute("description", Description.Text),
            new XAttribute("owner", Owner.Text),
            new XAttribute("difficulty", Difficulty.Text),
            new XAttribute("status", Status.Text),
            new XAttribute("submittedBy", Technician.Text),
            new XAttribute("hours", Hours.Text)));
            library.Save("C:\\Users\\Tyler Stewart\\source\\repos\\4330 MODEL Project\\4330 MODEL Project\\Tickets.xml");
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