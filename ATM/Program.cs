using ATM_VIEW;
using System;
using System.Numerics;

namespace ATM
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("====== WELCOME TO ATM ======");
                Console.WriteLine(" ");
                Console.WriteLine("NOTE: First add some accounts from admin mode and then perform transaction in customer mode");
                Console.WriteLine("How do you wish to log in?");
                Console.WriteLine("1----Admin");
                Console.WriteLine("2----Customer");
                int choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:

                        adminView ad = new adminView();
                        ad.adminmenu();
                        break;
                    case 2:
                        customerView cu = new customerView();
                        cu.login();
                        break;
                    default:
                        Console.WriteLine("Please select one of the above mentioned options");
                        break;
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine($"Exception type: {ex.GetType()} Message: {ex.Message}");
            }



           
        }
    }
}
