using ATM_BLL;
using ATM_BO;
using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;

namespace ATM_VIEW
{
    public class adminView
    {
        // ADMIN MENU
        public void adminmenu()
        {
            try
            {
                Console.WriteLine(" ");
                Console.WriteLine("==========================");
                Console.WriteLine("1----Create new account");
                Console.WriteLine("2----Delete existing acount");
                Console.WriteLine("3----update account information");
                Console.WriteLine("4----Search for account");
                Console.WriteLine("5----View reports");
                Console.WriteLine("6----Exit");
                Console.WriteLine(" ");
                Console.WriteLine("==========================");
                Console.WriteLine("Please select one of the above options:");
                int selection = System.Convert.ToInt32(Console.ReadLine());
                switch (selection)
                {
                    case 1:
                        createaccount();
                        adminmenu();
                        break;
                    case 2:
                        deleteaccount();
                        adminmenu();
                        break;
                    case 3:
                        updateaccount();
                        adminmenu();

                        break;
                    case 4:
                        searchaccount();
                        adminmenu();
                        break;
                    case 5:
                        viewreports();
                        adminmenu();
                        break;
                    case 6:
                        exit();
                        break;
                    default:
                        Console.WriteLine("Select a number from 1 to 6");
                        break;
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine($"Exception type: {ex.GetType()} Message: {ex.Message}");
            }

        }
        //CREATING USER ACOUNT
        public void createaccount()
        {
            customerBO bo = new customerBO();
            Console.WriteLine("Login: ");
            bo.login = Console.ReadLine();
            Console.WriteLine("Pin code: ");
            bo.pin = Console.ReadLine();
            Console.WriteLine("Holder name: ");
            bo.name = Console.ReadLine();
            Console.WriteLine("Type(Current,Savings): ");
            bo.type = Console.ReadLine();
            Console.WriteLine("Starting Balance: ");
            bo.balance = Console.ReadLine();
            Console.WriteLine("Status(Active,Disable) ");
            bo.status = Console.ReadLine();
            adminBLL bll = new adminBLL();
            if (bll.savecustomer(ref bo))
            {
                Console.Write($"customer succesfully added. The account number assigned is {bo.accountno+1}");
            }
            else
            {
                Console.WriteLine($"Login already exist. Enter some other login");
            }

        }
        //DISPLAY METHOD
        public void Display()
        {
            adminBLL bll = new adminBLL();
            List<customerBO> list = bll.ReadEmployee();
            foreach (customerBO e in list)
            {
                Console.WriteLine($"login : {e.login} pin: {e.pin} name: {e.name} type: {e.type}  balance: {e.balance} status: {e.status} accountno {e.accountno} ");
            }


        }
        //DELETING SPECIFIC ACCOUNT
        public void deleteaccount()
        {
            customerBO bo = new customerBO();
            Console.WriteLine("Enter the account no you want to delete: ");
            int num = int.Parse(Console.ReadLine());
            adminBLL bll = new adminBLL();
            if(bll.check(num,ref bo))
            {
                Console.WriteLine($"You wish to delete the account held by Mr {bo.name}; \n If this information is correct please re-enter the account number:");
                int num2 = int.Parse(Console.ReadLine());
                if (num2 == num)
                {
                    bll.delete(num);
                    Console.WriteLine("Account deleted sucessfully");
                }
                else
                {
                    Console.WriteLine("AccountNo do not match the above entered accountNo. Account deletion failed");
                }
            }
            else
            {
                Console.WriteLine("Account does not exist in the system");
            }
        }
        //FUNCTION FOR UPDATTING ACCOUNT INFOMATION
        public void updateaccount()
        {
            customerBO bo = new customerBO();
            Console.WriteLine("Enter account number you want to update");
            int num = int.Parse(Console.ReadLine());
            adminBLL bll = new adminBLL();
            if(bll.retrieveaccount(ref bo, num))
            {
                Console.WriteLine($"Account # {bo.accountno}");
                Console.WriteLine($"Type: {bo.type}");
                Console.WriteLine($"Holder: {bo.name}");
                Console.WriteLine($"Balance: {bo.balance}");
                Console.WriteLine($"Status: {bo.status}");
                Console.WriteLine("Please enter in the fields you wish to update (leave blank otherwise): ");
                Console.WriteLine("Login: ");
                bo.login=Console.ReadLine();
                Console.WriteLine("Pincode: ");
                bo.pin = Console.ReadLine();
                Console.WriteLine("Holders name ");
                bo.name = Console.ReadLine();
                Console.WriteLine("status: ");
                bo.status = Console.ReadLine();
                if (bll.updateinfo(bo, num))
                {
                    Console.WriteLine("Your account has been successfully updated");
                }
                else
                {
                    Console.WriteLine("Login already exists. Enter some other login");
                }
            }
            else
            {
                Console.WriteLine("Account does not exist. Please enter an existing account No.");    
            }
        }
        //FUNCTION FOR SEARCHING ACCOUNTS
        public void searchaccount()
        {
            customerBO bo = new customerBO();
            adminBLL bll = new adminBLL();
            Console.WriteLine("Search menu:");
            Console.WriteLine("Account ID: ");
           string n = Console.ReadLine();
            if (string.IsNullOrEmpty(n))
            {
                bo.accountno = -1111;
            }
            else
            {
                bo.accountno = int.Parse(n);
            }

            Console.WriteLine("Login: ");
            bo.login = Console.ReadLine();
            Console.WriteLine("Type: ");
            bo.type = Console.ReadLine();
            Console.WriteLine("Holder's name: ");
            bo.name = Console.ReadLine();
            Console.WriteLine("Balance: ");
            bo.balance = Console.ReadLine();
            Console.WriteLine("Status: ");
            bo.status = Console.ReadLine();
            List<customerBO> list = bll.searchforaccounts(bo);
            Console.WriteLine("\t\t\t\t\t==========SEARCH RESULTS==========");
            Console.WriteLine();
            Console.WriteLine();
            if (list.Any())
            {
                Console.WriteLine(String.Format("{0,-10}  {1,-10}  {2,-11}   {3,-10}  {4,-10}  {5,-10}", "AccountID", "UserID", "Holders Name", "Type", "Balance", "Status"));
                foreach (customerBO s in list)
                {
                    Console.WriteLine(" ");
                    Console.WriteLine(String.Format("{0,-10}  {1,-10}  {2,-11}   {3,-10}  {4,-10}  {5,-11}", s.accountno, s.login, s.name, s.type, s.balance, s.status));
                }
            }
            else
            {
                Console.WriteLine("No results found");
            }
        }
        //FUNCTION FOR VIEWING REPORTS
        public void viewreports()
        {
            Console.WriteLine("1---Accounts By Amount");
            Console.WriteLine("2---Accounts By Dates");
            int choice = int.Parse(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    byamounts();
                    break;
                case 2:
                    bydate();
                    break;
                default:
                    Console.WriteLine("Enter 1 or 2");
                    break;
            }


        }
        //FUNCTION FOR VIEWING REPORTS BY AMOUNT
        public void byamounts()
        {
            List<customerBO> list = new List<customerBO>();
            Console.WriteLine("Enter the minimum amount");
            string min = Console.ReadLine();
            Console.WriteLine("Enter the maximum amount");
            string max = Console.ReadLine();
            adminBLL bll = new adminBLL();
            list=bll.searchbyamounts(min, max);
            Console.WriteLine("\t\t\t\t\t==========SEARCH RESULTS==========");
            Console.WriteLine();
            Console.WriteLine();
            if (list.Any())
            {
                Console.WriteLine(String.Format("{0,-10}  {1,-10}  {2,-11}   {3,-10}  {4,-10}  {5,-10}", "AccountID", "UserID", "Holders Name","Type","Balance","Status"));

                foreach (customerBO s in list)
                {
                    Console.WriteLine(" ");
                    Console.WriteLine(String.Format("{0,-10}  {1,-10}  {2,-11}   {3,-10}  {4,-10}  {5,-11}", s.accountno, s.login, s.name, s.type, s.balance, s.status));
                }
            }
            else
            {
                Console.WriteLine("No results found");
            }

        }
        //FUNCTION FOR VIEWING REPORTS BY DATES
        public void bydate()
        {
            List<customerdataBO> list = new List<customerdataBO>();
            Console.WriteLine("Enter the starting date:");
            DateTime start = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("Enter the ending date:");
            DateTime end = DateTime.Parse(Console.ReadLine());
            adminBLL bll = new adminBLL();
            list = bll.searchbydates(start, end);
            Console.WriteLine("\t\t\t\t\t==========SEARCH RESULTS==========");
            Console.WriteLine();
            Console.WriteLine();
            if (list.Any())
            {
                Console.WriteLine(String.Format("{0,-15}  {1,-10}  {2,-11}   {3,-10}  {4,-10} ", "TransactionType", "UserID", "Holders Name", "Amount", "Date"));

                foreach (customerdataBO d in list)
                {
                    Console.WriteLine(" ");
                    Console.WriteLine(String.Format("{0,-15}  {1,-10}  {2,-11}   {3,-10}  {4,-10} ", d.transaction, d.login, d.name, d.amount, d.date));
                }
            }
            else
            {
                Console.WriteLine("No results found");
            }
        }
        //FUNCTION FOR EXITING 
        public void exit()
        {
            System.Environment.Exit(0);
        }

    }
}
    