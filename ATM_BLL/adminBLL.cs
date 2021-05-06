using ATM_BO;
using ATM_DAL;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Reflection;
using System.Text;
using System.Xml;

namespace ATM_BLL
{
   public class adminBLL
    {
        //FUNCTION TO SAVE CUSTOMER DATA IN FILE
        public bool savecustomer(ref customerBO bo)
        {
            adminDAL dal = new adminDAL();
            if (dal.savecustomer( bo))
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        public List<customerBO> ReadEmployee()
        {
            adminDAL dal = new adminDAL();
            return dal.ReadEmployee();

        }
        //FUNCTION TO DELETE SPECIFIC ACCOUNT
        public void delete(int num)
        {
            adminDAL dal = new adminDAL();
            dal.delete(num);

        }
        //FUNCTION TO CHECK IF ACCOUNT IS AVAILABLE
        public bool check(int num,ref customerBO bo)
        {
            adminDAL dal = new adminDAL();
            if(dal.check(num, ref bo))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        //FUNCTION TO RETRIEVE ACCOUNT INFO
        public bool retrieveaccount(ref customerBO bo, int num)
        {
            adminDAL dal = new adminDAL();
            if(dal.retrieveaccount(ref bo, num))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        //FUNCTION FOR UPDATING ACCOUNT INFO
        public bool updateinfo(customerBO bo,int num)
        {
            adminDAL dal = new adminDAL();
            if(dal.updateinfo(bo, num))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        //FUNCTION FOR SEARCHING ACCOUNTS ON BASED ON SPECIFIC CRITERIAS
        public List<customerBO> searchforaccounts(customerBO bo)
        {
            adminDAL dal = new adminDAL();
            return dal.searchforaccounts(bo);
        }
        //FUNCTION FOR GETTING ACCOUNTS WITH SPECIFIC AMOUNT RANGE
        public List<customerBO> searchbyamounts(string min,string max)
        {
            adminDAL dal = new adminDAL();
            //dal.searchbyamounts(min, max);
            List<string> list = new List<string>();
            List<string> newlist = new List<string>();
            list = dal.getlist("customers.txt");
            foreach (string s in list)
            {
                string[] data = s.Split(",");
                if (System.Convert.ToInt32(data[4])>=System.Convert.ToInt32(min) && System.Convert.ToInt32(data[4]) <= System.Convert.ToInt32(max))
                {
                    newlist.Add(s);
                }
                else
                {
                    continue;
                }
            }
            List<customerBO> bolist = new List<customerBO>();
            bolist = dal.getobjects(newlist);
            return bolist;

        }
        //FUNCTION FOR GETTING ACCOUNT WITH DATE RANGE
        public List<customerdataBO> searchbydates(DateTime start, DateTime end)
        {
            List<string> rlist = new List<string>();
            List<string> list = new List<string>();
            adminDAL dal = new adminDAL();
            list = dal.getlist("transactions.txt");
            foreach (string s in list)
            {
                string[] data = s.Split(",");
                if (System.Convert.ToDateTime(data[4]) >= start && System.Convert.ToDateTime(data[4]) <= end)
                {
                    rlist.Add(s);
                }
                else
                {
                    continue;
                }
            }
            List<customerdataBO> bolist = new List<customerdataBO>();
            bolist = dal.getBOobjects(rlist);
            return bolist;
        }
    }
}
