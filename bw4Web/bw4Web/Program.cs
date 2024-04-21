using System;
using System.Diagnostics;

namespace SydneyCoffee
{
    public class Customer
    {   
        public string name { get; set; }
        public int quantity { get; set; }
        public  string reseller { get; set; }
         private  double  price;
        public double charge;
        public void  determinePrice()
        {
            if (quantity <= 5)
            {
                price = 36 * quantity;
            }
            else if (quantity <= 15)
            {
                price = 34.5 * quantity;
            }
            else
            {
                price = 32.7 * quantity;
            }
        }

        public void chargeCustomer()
        {
            
            if (reseller == "yes")
            {
                // 20% discount
                charge = price * 0.8;
            }
            else
            {
                charge = price;
            }
            
        }
        
    }
    class Program
    {
        static void Main(string[] args)
        {
            // Declaring N and allocating a value
            int n = 2;

            // declaring transcationDetials
            List<Customer> transactionDetail = new List<Customer>();
            double min = 9999999;
            String minName = "";
            double max = -1;
            String maxName = "";
            // Welcome message
            Console.WriteLine("\t\t\t\tWelcome to use Sydney Coffee Program\n");

            // Loop to get the inputs
            for (int i = 0; i < n; i++)
            {
            Customer customer = new Customer();
                Console.Write("Enter customer name: ");
                customer.name = Console.ReadLine();

               
                // The loop will continue whenever the entered value is out of range
                do
                {
                    Console.Write("Enter the number of coffee beans bags (bag/1kg): ");
                    customer.quantity = Convert.ToInt32(Console.ReadLine());
                    

                    if (customer.quantity < 1 || customer.quantity > 200)
                    {
                        Console.WriteLine("Invalid Input!\nCoffee bags between 1 and 200 can be ordered.");
                    }
                } while (customer.quantity < 1 || customer.quantity > 200);

                // determining the price

                customer.determinePrice();
                Console.Write("Enter yes/no to indicate whesther you are a reseller: ");
                customer.reseller = Console.ReadLine();
                //charge customer
                customer.chargeCustomer();
                //add this customers transaction detail.
                transactionDetail.Add(customer);
                Console.WriteLine(String.Format("The total sales value from {0} is ${1}", transactionDetail[i].name, transactionDetail[i].charge));
                Console.WriteLine("-----------------------------------------------------------------------------");

                // finding max min value
                if (min > transactionDetail[i].charge)
                {
                    min = transactionDetail[i].charge;
                    minName = transactionDetail[i].name;
                }

                if (max < transactionDetail[i].charge)
                {
                    max = transactionDetail[i].charge;
                    maxName = transactionDetail[i].name;
                }
            }

            // summary heading
            Console.WriteLine("\t\t\t\t\tSummary of sales\n");
            Console.WriteLine("-----------------------------------------------------------------------------");
            Console.WriteLine("-----------------------------------------------------------------------------");

            // displaying table header
            Console.WriteLine(String.Format("{0,15}{1,10}{2,10}{3,10}",
                        "Name", "Quantity", "Reseller", "Charge"));

            // displaying table data
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine(String.Format("{0,15}{1,10}{2,10}{3,10}",
                       transactionDetail[i].name, transactionDetail[i].quantity, transactionDetail[i].reseller,  transactionDetail[i].charge));
            }

            Console.WriteLine("-----------------------------------------------------------------------------");
            Console.WriteLine("-----------------------------------------------------------------------------");
            Console.WriteLine(String.Format("The customer spending most is {0} ${1}", maxName, max));
            Console.WriteLine(String.Format("The customer spending least is {0} ${1}", minName, min));

        }
    }
}