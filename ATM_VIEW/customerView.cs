using ATM_BLL;
using ATM_BO;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace ATM_VIEW
{
    public class customerView
    {
        //CHECKING LOGIN AND PASSWORD
        public void login()
        {
            customerBO activecustomer = new customerBO();
            customerBLL bll = new customerBLL();
            Console.WriteLine("Enter login: ");
            string lo = Console.ReadLine();
            activecustomer.login = lo;
            Console.WriteLine("Enter pin ");
            activecustomer.pin = Console.ReadLine();
            if (bll.checkdisable(activecustomer))
            {
                if (bll.validate(ref activecustomer))
                {
                    Console.WriteLine("Login successful");
                    customerMenu(lo, activecustomer);
                }
                else
                {
                    Console.WriteLine("Wrong login and password combination. Try again");
                    customerBO.count++;
                    login();
                }
            }
            else
            {
                Console.WriteLine("Account is disabled by administrator.");
            }

        }
        //CUSTOMER MENU
        public void customerMenu(string lo, customerBO activecustomer)
        {
            try {

                Console.WriteLine(" ");
                Console.WriteLine("=================================");
                Console.WriteLine("1----Withdraw Cash");
                Console.WriteLine("2----Cash Transfer");
                Console.WriteLine("3----Deposit Cash");
                Console.WriteLine("4----Display Balance");
                Console.WriteLine("5----Exit");
                Console.WriteLine(" ");
                Console.WriteLine("=================================");
                Console.WriteLine("Please select one of the above options:");
                int selection = System.Convert.ToInt32(Console.ReadLine());
                switch (selection)
                {
                    case 1:
                        withdraw(lo, activecustomer);
                        break;
                    case 2:
                        transfer(lo, activecustomer);
                        break;
                    case 3:
                        deposit(lo, activecustomer);
                        break;
                    case 4:
                        displaybalance(lo,activecustomer);
                        break;
                    case 5:
                        exit();
                        break;
                    default:
                        Console.WriteLine("Select a number from 1 to 5");
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.Write($"Exception type: {ex.GetType()} Message: {ex.Message} ");
            }


        }
        //WITHDRAW MENU
        public void withdraw(string lo,customerBO activecustomer)
        {
            try
            {
                Console.WriteLine("");
                Console.WriteLine("a)----Fast cash");
                Console.WriteLine("b)----Normal cash");
                Console.WriteLine(" ");
                Console.WriteLine("Please select a mode of withdrawal:");
                char selection = System.Convert.ToChar(Console.ReadLine());
                switch (selection)
                {
                    case 'a':
                        fastcash(lo, activecustomer);
                        break;
                    case 'b':
                        normalcash(lo, activecustomer);
                        break;
                    default:
                        Console.WriteLine("Select option a or b");
                        normalcash(lo, activecustomer);
                        break;
                }
            }
            catch(Exception ex)
            {
                Console.Write($"Exception type: {ex.GetType()} Message: {ex.Message} ");

            }
        }
        //FAST CASH MENU
        public void fastcash(string lo,customerBO activecustomer)
        {
            try
            {
                customerBO recipt = new customerBO();
                customerdataBO newbo = new customerdataBO();
                List<string> fastlist = new List<string>();
                string trans = "Cash withdrawl";
                customerBLL bll = new customerBLL();
                Console.WriteLine("");
                Console.WriteLine("1----500");
                Console.WriteLine("2----1000");
                Console.WriteLine("3----2000");
                Console.WriteLine("4----5000");
                Console.WriteLine("5----10000");
                Console.WriteLine("6----15000");
                Console.WriteLine("7----20000");
                Console.WriteLine(" ");
                Console.WriteLine("Select one of the denominations of money:");
                int selection = System.Convert.ToInt32(Console.ReadLine());
                switch (selection)
                {
                    case 1:
                        Console.WriteLine("Are you sure you want to withdraw Rs.500 (Y/N)?");
                        char c1 = System.Convert.ToChar(Console.ReadLine());
                        if (c1 == 'y' || c1 == 'Y')
                        {

                            if (System.Convert.ToInt32(activecustomer.balance) >= System.Convert.ToInt32("500"))
                            {
                                string bal = "500";
                                fastlist = bll.updateBalanceAndDate(bal, lo, newbo, ref recipt, trans);
                                bll.writelist(fastlist);
                                Console.WriteLine("Cash Successfully Withdrawn!");
                                Console.WriteLine("Do you wish to print a receipt (Y/N)?");
                                char cc = System.Convert.ToChar(Console.ReadLine());
                                if (cc == 'y' || cc == 'Y')
                                {
                                    printrecipt(recipt, trans);
                                    customerMenu(lo, activecustomer);

                                }
                                else
                                {
                                    customerMenu(lo, activecustomer);
                                }
                            }
                            else
                            {
                                Console.WriteLine("Account doesnot have sufficient balance");
                                customerMenu(lo, activecustomer);

                            }

                        }
                        else
                        {
                            customerMenu(lo, activecustomer);
                        }
                        break;
                    case 2:
                        Console.WriteLine("Are you sure you want to withdraw Rs.1000 (Y/N)?");
                        char c2 = System.Convert.ToChar(Console.ReadLine());
                        if (c2 == 'y' || c2 == 'Y')
                        {
                            if (System.Convert.ToInt32(activecustomer.balance) >= System.Convert.ToInt32("1000"))
                            {
                                string bal = "1000";
                                fastlist = bll.updateBalanceAndDate(bal, lo, newbo, ref recipt, trans);
                                bll.writelist(fastlist);
                                Console.WriteLine("Cash Successfully Withdrawn!");
                                Console.WriteLine("Do you wish to print a receipt (Y/N)?");
                                char cc = System.Convert.ToChar(Console.ReadLine());
                                if (cc == 'y' || cc == 'Y')
                                {
                                    printrecipt(recipt, trans);
                                    customerMenu(lo, activecustomer);

                                }
                                else
                                {
                                    customerMenu(lo, activecustomer);
                                }
                            }
                            else
                            {
                                Console.WriteLine("Account doesnot have sufficient balance");
                                customerMenu(lo, activecustomer);


                            }

                        }
                        else
                        {
                            customerMenu(lo, activecustomer);

                        }
                        break;
                    case 3:
                        Console.WriteLine("Are you sure you want to withdraw Rs.2000 (Y/N)?");
                        char c3 = System.Convert.ToChar(Console.ReadLine());
                        if (c3 == 'y' || c3 == 'Y')
                        {
                            if (System.Convert.ToInt32(activecustomer.balance) >= System.Convert.ToInt32("2000"))
                            {
                                string bal = "2000";
                                fastlist = bll.updateBalanceAndDate(bal, lo, newbo, ref recipt, trans);
                                bll.writelist(fastlist);
                                Console.WriteLine("Cash Successfully Withdrawn!");
                                Console.WriteLine("Do you wish to print a receipt (Y/N)?");
                                char cc = System.Convert.ToChar(Console.ReadLine());
                                if (cc == 'y' || cc == 'Y')
                                {
                                    printrecipt(recipt, trans);
                                    customerMenu(lo, activecustomer);

                                }
                                else
                                {
                                    customerMenu(lo, activecustomer);
                                }
                            }
                            else
                            {
                                Console.WriteLine("Account does not have sufficient balance");
                                customerMenu(lo, activecustomer);


                            }

                        }
                        else
                        {
                            customerMenu(lo, activecustomer);
                        }
                        break;
                    case 4:
                        Console.WriteLine("Are you sure you want to withdraw Rs.5000 (Y/N)?");
                        char c4 = System.Convert.ToChar(Console.ReadLine());
                        if (c4 == 'y' || c4 == 'Y')
                        {
                            if (System.Convert.ToInt32(activecustomer.balance) >= System.Convert.ToInt32("5000"))
                            {

                                string bal = "5000";
                                fastlist = bll.updateBalanceAndDate(bal, lo, newbo, ref recipt, trans);
                                bll.writelist(fastlist);
                                Console.WriteLine("Cash Successfully Withdrawn!");
                                Console.WriteLine("Do you wish to print a receipt (Y/N)?");
                                char cc = System.Convert.ToChar(Console.ReadLine());
                                if (cc == 'y' || cc == 'Y')
                                {
                                    printrecipt(recipt, trans);
                                    customerMenu(lo, activecustomer);

                                }
                                else
                                {
                                    customerMenu(lo, activecustomer);
                                }
                            }
                            else
                            {
                                Console.WriteLine("Account does not have sufficient balance");
                                customerMenu(lo, activecustomer);

                            }

                        }
                        else
                        {
                            customerMenu(lo, activecustomer);
                        }
                        break;
                    case 5:
                        Console.WriteLine("Are you sure you want to withdraw Rs.10000 (Y/N)?");
                        char c5 = System.Convert.ToChar(Console.ReadLine());
                        if (c5 == 'y' || c5 == 'Y')
                        {
                            if (System.Convert.ToInt32(activecustomer.balance) >= System.Convert.ToInt32("10000"))
                            {
                                string bal = "10000";
                                fastlist = bll.updateBalanceAndDate(bal, lo, newbo, ref recipt, trans);
                                bll.writelist(fastlist);
                                Console.WriteLine("Cash Successfully Withdrawn!");
                                Console.WriteLine("Do you wish to print a receipt (Y/N)?");
                                char cc = System.Convert.ToChar(Console.ReadLine());
                                if (cc == 'y' || cc == 'Y')
                                {
                                    printrecipt(recipt, trans);
                                    customerMenu(lo, activecustomer);

                                }
                                else
                                {
                                    customerMenu(lo, activecustomer);
                                }
                            }
                            else
                            {
                                Console.WriteLine("Account does not have sufficient balance");
                                customerMenu(lo, activecustomer);

                            }
                        }
                        else
                        {
                            customerMenu(lo, activecustomer);
                        }
                        break;
                    case 6:
                        Console.WriteLine("Are you sure you want to withdraw Rs.15000 (Y/N)?");
                        char c6 = System.Convert.ToChar(Console.ReadLine());
                        if (c6 == 'y' || c6 == 'Y')
                        {
                            if (System.Convert.ToInt32(activecustomer.balance) >= System.Convert.ToInt32("15000"))
                            {
                                string bal = "15000";
                                fastlist = bll.updateBalanceAndDate(bal, lo, newbo, ref recipt, trans);
                                bll.writelist(fastlist);
                                Console.WriteLine("Cash Successfully Withdrawn!");
                                Console.WriteLine("Do you wish to print a receipt (Y/N)?");
                                char cc = System.Convert.ToChar(Console.ReadLine());
                                if (cc == 'y' || cc == 'Y')
                                {

                                    printrecipt(recipt, trans);
                                    customerMenu(lo, activecustomer);

                                }
                                else
                                {
                                    customerMenu(lo, activecustomer);
                                }
                            }
                            else
                            {
                                Console.WriteLine("Account does not have sufficient balance");
                                customerMenu(lo, activecustomer);

                            }

                        }
                        else
                        {
                            customerMenu(lo, activecustomer);
                        }
                        break;
                    case 7:
                        Console.WriteLine("Are you sure you want to withdraw Rs.20000 (Y/N)?");
                        char c7 = System.Convert.ToChar(Console.ReadLine());
                        if (c7 == 'y' || c7 == 'Y')
                        {
                            if (System.Convert.ToInt32(activecustomer.balance) >= System.Convert.ToInt32("20000"))
                            {
                                string bal = "20000";
                                fastlist = bll.updateBalanceAndDate(bal, lo, newbo, ref recipt, trans);
                                bll.writelist(fastlist);
                                Console.WriteLine("Cash Successfully Withdrawn!");
                                Console.WriteLine("Do you wish to print a receipt (Y/N)?");
                                char cc = System.Convert.ToChar(Console.ReadLine());
                                if (cc == 'y' || cc == 'Y')
                                {
                                    string lasttransaction = bll.getlasttransaction();
                                    printrecipt(recipt, trans);
                                    customerMenu(lo, activecustomer);

                                }
                                else
                                {
                                    customerMenu(lo, activecustomer);
                                }
                            }
                            else
                            {
                                Console.WriteLine("Account does not have sufficient balance");
                                customerMenu(lo, activecustomer);

                            }

                        }
                        else
                        {
                            customerMenu(lo, activecustomer);
                        }
                        break;
                    default:
                        Console.WriteLine("Select a number from 1 to 7");
                        break;

                }
            }
            catch(Exception ex)
            {
                Console.WriteLine($"Exception type: {ex.GetType()} Message: {ex.Message}");
            }

        }
        //FUNCTION FOR PRINTING RECIPTS 
        public void printrecipt(customerBO bo,string trans)
        {
            Console.WriteLine("");
            Console.WriteLine("=================================");
            Console.WriteLine($"Account no:{bo.accountno}");
            Console.WriteLine($"Date:{bo.login}");
            Console.WriteLine($"{trans}:{bo.pin}");
            Console.WriteLine($"Balance:{bo.balance}");
            Console.WriteLine("=================================");
            Console.WriteLine("");

        }
        //NORMAL CASH MENU
        public void normalcash(string lo,customerBO activecustomer)
        {
            customerdataBO newbo = new customerdataBO();
            string trans = "Cash withdrawl";
            customerBLL bll = new customerBLL();
            List<string> normallist = new List<string>();
            customerBO recipt = new customerBO();
            Console.WriteLine("Enter the withdrawal amount:");
            int amount = System.Convert.ToInt32(Console.ReadLine());
            string bal = System.Convert.ToString(amount);
            if (System.Convert.ToInt32(activecustomer.balance) >= System.Convert.ToInt32(amount))
            {
                normallist = bll.updateBalanceAndDate(bal, lo, newbo, ref recipt, trans);
                bll.writelist(normallist);
                Console.WriteLine("Amount successfully Withdrawn!");
                Console.WriteLine("Do you wish to print a receipt (Y/N)?");
                char cc = System.Convert.ToChar(Console.ReadLine());
                if (cc == 'y' || cc == 'Y')
                {
                    printrecipt(recipt,trans);
                    customerMenu(lo, activecustomer);
                }
            }
            else
            {
                Console.WriteLine("Account does not have sufficient balance");
                customerMenu(lo, activecustomer);
            }

        }
        //FUNCTION FOR PERFORMING CASH TRANSFER
        public void transfer(string lo,customerBO activecustomer)
        {
            string trans = "Transfer cash";
            List<string> list = new List<string>();
            customerBO bo = new customerBO();
            customerdataBO newbo = new customerdataBO();
            customerBO recipt = new customerBO();
            Console.WriteLine("Enter the amount in multiples of 500");
            string amount = Console.ReadLine();
            string bal = amount;
            if (System.Convert.ToInt32(activecustomer.balance) >= System.Convert.ToInt32(amount)){
                if (System.Convert.ToInt32(amount) % 500 == 0)
                {
                    Console.WriteLine("Enter the account no to which you want to transfer: ");
                    int num = int.Parse(Console.ReadLine());
                    customerBLL bll = new customerBLL();
                    if (bll.check(num, ref bo))
                    {
                        Console.WriteLine($"You wish to transfer Rs {amount} in an account held by Mr {bo.name}; \n If this information is correct please re-enter the account number:");
                        int num2 = int.Parse(Console.ReadLine());
                        if (num2 == num)
                        {
                            list = bll.transferamount(num, lo, newbo, ref recipt, trans, bal);
                            bll.writelist(list);
                            Console.WriteLine("Transaction Confirmed");
                            Console.WriteLine("Do you wish to print a recipt (Y/N)");
                            char cc = System.Convert.ToChar(Console.ReadLine());
                            if (cc == 'y' || cc == 'Y')
                            {
                                printrecipt(recipt, trans);
                                customerMenu(lo, activecustomer);
                            }
                            else
                            {
                                customerMenu(lo, activecustomer);
                            }
                        }
                        else
                        {
                            Console.WriteLine("AccountNo do not match the above entered accountNo. Transfer failed");
                            customerMenu(lo, activecustomer);
                        }

                    }
                }
                else
                {
                    Console.WriteLine("Enter multiples of 500 only");
                    customerMenu(lo, activecustomer);
                }
            }
            else
            {
                Console.WriteLine("Account doesnot have sufficient balance");
                customerMenu(lo, activecustomer);
            }
        }
        //FUNCITON FOR DEPOSITING CASH 
        public void deposit(string lo,customerBO activecustomer)
        {
            List<string> depositelist = new List<string>();
            customerBLL bll = new customerBLL();
            string trans = "Cash Deposit";
            customerBO recipt = new customerBO();
            customerdataBO newbo = new customerdataBO();
            Console.WriteLine("Enter the cash amount to deposite: ");
            string amount = Console.ReadLine();
            depositelist = bll.depositamount(lo, newbo, ref recipt, trans, amount);
            bll.writelist(depositelist);
            Console.WriteLine("Amount deposited successfully");
            Console.WriteLine("Do you wish to print a receipt (Y/N)?");
            char cc = System.Convert.ToChar(Console.ReadLine());
            if (cc == 'y' || cc == 'Y')
            {
                printrecipt(recipt,trans);
                customerMenu(lo, activecustomer);
            }
            else
            {
                customerMenu(lo, activecustomer);
            }



        }
        //FUNCTION FOR DISPLAYING BALANCE
        public void displaybalance (string lo,customerBO activecustomer)
        {
            customerBLL bll = new customerBLL();
            string bal = bll.getbalance(lo);
            Console.WriteLine("==========================");
            Console.WriteLine("");
            Console.WriteLine($"Account: {activecustomer.accountno}");
            DateTime d = DateTime.Today;
            Console.WriteLine($"Date: {d} ");
            Console.WriteLine($"Balance: {bal}");
                Console.WriteLine("");
            Console.WriteLine("==========================");
            customerMenu(lo, activecustomer);
        }
        //FUNCTION FOR EXITING
        public void exit()
        {
            System.Environment.Exit(0);
        }

    } 
    
}
