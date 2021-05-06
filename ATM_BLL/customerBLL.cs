using ATM_BO;
using ATM_DAL;
using Microsoft.VisualBasic;
using System;
using System.Buffers.Binary;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace ATM_BLL
{
   public class customerBLL
    {
        //VALIDATING LOGIN AND PASSWORD
        public bool validate (ref customerBO bo)
        {
            customerDAL dal = new customerDAL();
            List<string> list = new List<string>();
            list = dal.getdata("customers.txt");
            foreach (string s in list)
            {
                string[] data = s.Split(",");
                if (data[0] == bo.login && data[1] == bo.pin)
                {
                    bo.balance = data[4];
                    bo.accountno = int.Parse(data[6]);
                    return true;

                }

               
            }
            return false;
        }
        //CHECK DISABLE ACOUNT
        public bool checkdisable(customerBO activecustomer)
        {
            List<string> list = new List<string>();
            customerDAL dal = new customerDAL();
            list = dal.getdata("customers.txt");
            foreach(string s in list)
            {
                string[] data = s.Split(",");
                if (data[0] == activecustomer.login && data[5] == "active")
                {
                    return true;
                }
            }
            return false;
        }
        // FUNCTION FOR UPDATING BALANCE AND DATE
        public List<string> updateBalanceAndDate(string bal, string lo, customerdataBO newbo, ref customerBO bo,string trans)
        {
            customerDAL dal = new customerDAL();
            List<string> list = new List<string>();
            List<string> list2 = new List<string>();
            list = dal.getdata("customers.txt");
            foreach(string s in list)
            {
                string[] data = s.Split(",");
                if (data[0] == lo)
                {
                    string newbalance = System.Convert.ToString(System.Convert.ToInt32(data[4]) - System.Convert.ToInt32(bal));
                    data[4] = newbalance;
                    newbo.transaction = trans;
                    newbo.login = data[0];
                    newbo.name = data[2];
                    newbo.amount = bal;
                    newbo.date = System.Convert.ToDateTime(DateTime.Today.ToString("dd-MM-yyyy"));
                    bo.accountno = int.Parse(data[6]);
                    bo.balance = data[4];
                    bo.login = System.Convert.ToString(DateTime.Today);
                    bo.pin = bal;
                    dal.writenewobject(newbo);
                    string text = $"{data[0]},{data[1]},{data[2]},{data[3]},{data[4]},{data[5]},{data[6]}";
                    list2.Add(text);
                }
                else
                {
                    list2.Add(s);

                }
            }
            return list2;
        }
        //FUNCTION FOR WRITING UPDATED DATA INTO FILE
        public void writelist(List<string> fastlist)
        {
            customerDAL dal = new customerDAL();
            dal.writelist(fastlist);
        }
        //FUNCTION FOR RETURNING THE LAST TRANSACTION
        public string getlasttransaction()
        {
            customerDAL dal = new customerDAL();
            string s = dal.getlasttransaction();
            return s;
        }
        //FUNCTION TO CHECK IF ACCOUNT IS AVAILABLE
        public bool check(int num, ref customerBO bo)
        {
            customerDAL dal = new customerDAL();
            if (dal.check(num, ref bo))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        //FUNCTION TO PERFORM CASH TRANFER
        public List<string> transferamount(int num,string lo,customerdataBO newbo,ref customerBO recipt,string trans,string bal)
        {
            List<string> rlist = new List<string>();
            List<string> list = new List<string>();
            customerDAL dal = new customerDAL();
            list = dal.getdata("customers.txt");
            foreach(string s in list)
            {
                string[] data = s.Split(",");
                if (data[0] == lo)
                {
                    string newbal = System.Convert.ToString(System.Convert.ToInt32(data[4]) - System.Convert.ToInt32(bal));
                    data[4] = newbal;
                    newbo.transaction = trans;
                    newbo.login = data[0];
                    newbo.name = data[2];
                    newbo.amount = bal;
                    newbo.date = System.Convert.ToDateTime(DateTime.Today.ToString("dd-MM-yyyy"));
                    recipt.accountno = int.Parse(data[6]);
                    recipt.balance = data[4];
                    recipt.login = System.Convert.ToString(DateTime.Today);
                    recipt.pin = bal;
                    dal.writenewobject(newbo);
                    string text = $"{data[0]},{data[1]},{data[2]},{data[3]},{data[4]},{data[5]},{data[6]}";
                    rlist.Add(text);
                }
                
                else if (System.Convert.ToInt32(data[6]) == num)
                {
                    string newbal = System.Convert.ToString((System.Convert.ToInt32(data[4]) + System.Convert.ToInt32(bal)));
                    data[4] = newbal;
                    string text = $"{data[0]},{data[1]},{data[2]},{data[3]},{data[4]},{data[5]},{data[6]}";
                    rlist.Add(text);

                }
                else
                {
                    rlist.Add(s);

                }
            }
            return rlist;
        }
        //FUNCTIONN TO PERFORM CASH DEPOSITE
        public List<string> depositamount(string lo, customerdataBO newbo, ref customerBO recipt,string trans,string amount)
        {
            List<string> rlist = new List<string>();
            List<string> list = new List<string>();
            customerDAL dal = new customerDAL();
            list = dal.getdata("customers.txt");
            foreach(string s in list)
            {
                string[] data = s.Split(",");
                if (data[0] == lo)
                {
                    data[4] = System.Convert.ToString(System.Convert.ToInt32(data[4]) + System.Convert.ToInt32(amount));
                    newbo.transaction = trans;
                    newbo.login = data[0];
                    newbo.name = data[2];
                    newbo.amount = amount;
                    newbo.date = System.Convert.ToDateTime(DateTime.Today.ToString("dd-MM-yyyy"));
                    recipt.accountno = int.Parse(data[6]);
                    recipt.balance = data[4];
                    recipt.login = System.Convert.ToString(DateTime.Today);
                    recipt.pin = amount;
                    dal.writenewobject(newbo);
                    string text = $"{data[0]},{data[1]},{data[2]},{data[3]},{data[4]},{data[5]},{data[6]}";
                    rlist.Add(text);
                }
                else
                {
                    rlist.Add(s);
                }
            }
            return rlist;
        }
        //FUNCTION FOR GETTING THE BALANCE
        public string getbalance(string lo)
        {
            string bal = string.Empty;
            List<string> list = new List<string>();
            customerDAL dal = new customerDAL();
            list = dal.getdata("customers.txt");
            foreach(string s in list)
            {
                string[] data = s.Split(",");
                if(data[0]== lo)
                {
                    bal=data[4];
                }
                else
                {
                    continue;
                }
            }
            return bal;
        }
    }
}
