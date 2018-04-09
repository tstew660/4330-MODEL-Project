using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _4330_MODEL_Project
{

   

    public class Technician
    {
        public String name;
        public int id;
        public double hourlyWage;
        public Boolean available;

        public Technician(String name1, int id1, double hourlyWage1, Boolean available1)
        {
            name = name1;
            id = id1;
            this.hourlyWage = hourlyWage1;
            this.available = available1;
        }

        public void generateReceipt(int id, double hoursToCompleteJob)
        {

        }

        public void customerCreate(List<Customer> list)
        {
            Customer x = new Customer("Bob", "Address", 0);
            list.Add(x);
        }

    }
    /*public class Manager : Technician
    {
        private String name;
        private int id;
        private double hourlyWage;
        private Boolean available;

        public Manager(String name1, int id1, double hourlyWage1, Boolean available1)
        {
            name = name1;
            id = id1;
            hourlyWage = hourlyWage1;
            available = available1;
        }

        public void technicianCreate()
        {

        }

        public void editTechnician()
        {

        }

        public void alterQueue()
        {

        }
    } */

    public class Customer
    {
        public String name;
        public String address;
        public int priority;

        public Customer(String name1, String address1, int priority1)
        {
            name = name1;
            address = address1;
            priority = priority1;

        }
        
        public void request()
        {

        }
        
    }

    public class Receipt
    {
        public String employeeName;
        public int employeeID;
        public String customerName;
        public String jobDescription;
        public double total;

        public Receipt(String employeeName1, int employeeID1, String customerName1, String jobDescription1, double total1)
        {
            employeeName = employeeName1;
            employeeID = employeeID1;
            customerName = customerName1;
            jobDescription = jobDescription1;
            total = total1;
        }

        public void calculateTotal(double wage, double estHours)
        {

        }

        public void formatReceipt()
        {

        }

        public void printReceipt()
        {

        }



    }

    

    public class Queue
    {
        public int length;

        public void sortBy()
        {

        }

        public void displayTickets()
        {

        }

    }

    public class GenerateReport
    {
        public void report()
        {

        }
    }

    

    public class Ticket
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
    }

    
}