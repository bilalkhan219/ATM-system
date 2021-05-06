
using ATM_BO;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Xml.Serialization;

namespace ATM_DAL
{
    public class adminDAL : adminbaseDAL
    {
        //FUNCTION TO SAVE CUSTOMER INFO IN FILE
        public bool savecustomer(customerBO bo)
        {
            bo.accountno = getAccountNo("customers.txt");
            string text = $"{bo.login},{bo.pin},{bo.name},{bo.type},{bo.balance},{bo.status},{bo.accountno + 1}";

            if (save(bo, text, "customers.txt"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        //FUNCTION TO READ DATA FROM THE FILE AMD RETURNING IN THE FORM OF CUSTOMER OBJECTS
        public List<customerBO> ReadEmployee()
        {
            List<String> stringList = Read("customers.txt");
            List<customerBO> empList = new List<customerBO>();
            foreach (string s in stringList)
            {

                string[] data = s.Split(",");
                customerBO e = new customerBO();
                e.login = data[0];
                e.pin = data[1];
                e.name = data[2];
                e.type = data[3];
                e.balance = data[4];
                e.status = data[5];
                e.accountno = System.Convert.ToInt32(data[6]);
                empList.Add(e);
            }

            return empList;

        }
        //FUNCTION TO DELETE SPECIFIC ACCOUNT
        public void delete(int num)
        {
            deletecustomer(num);
        }
        //FUNCTION TO CHECK IF ACCOUNT EXISTS
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
        //Function to retrieve account data 
        public bool retrieveaccount(ref customerBO bo, int num)
        {
            if (retrieveacc(ref bo, num))
            {
                return true;

            }
            else
            {
                return false;
            }
        }
        //FUNCTION FOR UPDATING ACCOUNT INFO
        public bool updateinfo(customerBO bo, int num)
        {
            if (update(bo, num))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        //FUNCTION FOR SEARCHING ACCOUNTS ON BASED ON SPECIFIC CRITERIAS AND RETURNING LIST OF OBJECTS
        public List<customerBO> searchforaccounts(customerBO bo)
        {
            List<customerBO> list = new List<customerBO>();
            list = search(bo);
            return list;
        }
        //FUNCTION FOR RETURNING LIST OF ALL DATA FROM FILE
        public List<String> getlist(string filename)
        {
            List<String> list = new List<String>();
            list = Read(filename);
            return list;
        }
        //FUNCTION FOR CONVERTING STRING IN A FILE INTO OBJECTS
        public List<customerBO> getobjects(List<string> list)
        {
            List<customerBO> cuList = new List<customerBO>();
            foreach (string s in list)
            {

                string[] data = s.Split(",");
                customerBO c = new customerBO();
                c.login = data[0];
                c.pin = data[1];
                c.name = data[2];
                c.type = data[3];
                c.balance = data[4];
                c.status = data[5];
                c.accountno = System.Convert.ToInt32(data[6]);
                cuList.Add(c);
            }

            return cuList;

        }
        //FUNCTION FOR CINVERTING STRING TO TRANSACTION TYPE OBJECTS
        public List<customerdataBO> getBOobjects(List<string> list)
        {
            List<customerdataBO> cuList = new List<customerdataBO>();
            foreach (string s in list)
            {

                string[] data = s.Split(",");
                customerdataBO c = new customerdataBO();
                c.transaction = data[0];
                c.login = data[1];
                c.name = data[2];
                c.amount = data[3];
                c.date = System.Convert.ToDateTime(data[4]);
                cuList.Add(c);
            }

            return cuList;

        }

    }
}
