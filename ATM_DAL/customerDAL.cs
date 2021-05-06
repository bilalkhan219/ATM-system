using ATM_BO;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace ATM_DAL
{
    public class customerDAL : adminbaseDAL
    {
        //FUNCTION FOR RETURNING ALL THE DATA FROM FILE
        public List<string> getdata(string filename)
        {
            List<string> list = new List<string>();
            list = Read(filename);
            return list;
        }
        //FUNCTION FOR WRITING NEW TRANSACTION DATA INTO THE FILE
        public void writenewobject(customerdataBO newbo)
        {
            string text= $"{newbo.transaction},{newbo.login},{newbo.name},{newbo.amount},{newbo.date}";
            writenew(newbo,"transactions.txt",text);
        }
        //FUNCTION FOR WRITING UPDATED DATA INTO LIST
        public void writelist(List<string> fastlist)
        {
            writeUpdatedData(fastlist);
        }
        //FUNCTION FOR RETURNING THE LAST TRANSACTION
        public string getlasttransaction()
        {
            string n = string.Empty;
            List<string> list = new List<string>();
            list = Read("transactions.txt");
            foreach(string s in list)
            {
                n = s;
            }
            return n;
        }
        //FUNCTION FOR CHECKING OF ACCOUNT IS AVAILABLE
        public bool check(int num, ref customerBO bo)
        {
            if (checkAccountNo(num, ref bo))
            {
                return true;
            }

            else
            {
                return false;
            }
        }
    }
}
