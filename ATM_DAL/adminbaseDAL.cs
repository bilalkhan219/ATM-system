using ATM_BO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;

namespace ATM_DAL
{
    public class adminbaseDAL
    {
        //FUNCTION TO SAVE CUSTOMER DATA IN FILE
        internal bool save(customerBO bo, string text, string filename)
        {
            if (isexist(bo, filename))
            {
                string filepath = Path.Combine(Environment.CurrentDirectory, filename);
                StreamWriter sw = new StreamWriter(filepath, append: true);
                sw.WriteLine(text);
                sw.Close();
                return true;
            }
            else
            {
                return false;
            }

        }
        //FUNCTION FOR READING ALL DATA FROM FILE
        internal List<string> Read(string fileName)
        {

            List<string> list = new List<string>();
            string filePath = Path.Combine(Environment.CurrentDirectory,
                fileName);
            StreamReader sr = new StreamReader(filePath);
            string line = String.Empty;
            while ((line = sr.ReadLine()) != null)
            {

                list.Add(line);

            }
            sr.Close();
            return list;
        }
        //FINCTION FOR CHECKING REPITITION OF LOGINS
        public bool isexist(customerBO bo, string filename)

        {
            bool istrue = true;
            List<string> list = new List<string>();
            list = Read(filename);
            foreach (string s in list)
            {
                string[] attributes = s.Split(",");
                if (attributes[0] == bo.login)
                    istrue = false;
            }
            return istrue;

        }
        //FUNCTION FOR ASSIGNING ACCOUNT NUMBERS
        public int getAccountNo(string filename, int no = 0)
        {
            List<string> list = new List<string>();
            list = Read(filename);
            if (list == null)
            {
                return 0;
            }
            else
            {
                foreach (string s in list)
                {
                    string[] attributes = s.Split(",");
                    no = int.Parse(attributes[6]);
                }
            }
            return no;
        }
        //FUNCTION FOR DELETING ACCOUNT 
        internal void deletecustomer(int num)
        {
            List<string> list = new List<string>();
            List<string> list2 = new List<string>();
            list = Read("customers.txt");
            foreach (string s in list)
            {
                string[] data = s.Split(",");
                if (num != int.Parse(data[6]))
                {
                    list2.Add(s);
                }
            }
            writeUpdatedData(list2);
        }
        //FUNCTION FOR GETTING DATA OF SPECIFIC ACCOUNT NUMBER
        internal bool checkAccountNo(int num, ref customerBO bo)
        {
            List<string> list = new List<string>();
            list = Read("customers.txt");
            foreach (string s in list)
            {
                string[] data = s.Split(",");
                if (System.Convert.ToInt32(data[6]) == num)
                {
                    bo.name = data[2];
                    return true;
                }
            }
            return false;
        }
        //FUNCTION FOR DELETING OLD FILE AND WRITING DATA IN NEW FILE
        public void writeUpdatedData(List<string> list)
        {
            string filepath = Path.Combine(Environment.CurrentDirectory, "customers.txt");
            File.Delete(filepath);
            StreamWriter sw = new StreamWriter(filepath);
            foreach (string s in list)
            {
                sw.WriteLine(s);
            }
            sw.Close();
        }
        //FUNCTION TO RETRIEVE SPECIFIC ACCOUNT INFO
        internal bool retrieveacc(ref customerBO bo, int num)
        {
            List<string> list = new List<string>();
            list = Read("customers.txt");
            foreach (string s in list)
            {
                string[] data = s.Split(",");
                if (System.Convert.ToInt32(data[6]) == num)
                {
                    bo.name = data[2];
                    bo.accountno = int.Parse(data[6]);
                    bo.type = data[3];
                    bo.balance = data[4];
                    bo.status = data[5];
                    return true;
                }
            }
            return false;
        }
        //FUNCTION FOR UPDATING ACCOUNT INFO
        public bool update(customerBO bo, int num)
        {
            List<string> list = new List<string>();
            List<string> list2 = new List<string>();
            list = Read("customers.txt");
            foreach (string s in list)
            {
                string[] data = s.Split(",");
                if (num == int.Parse(data[6]))
                {
                    if (string.IsNullOrWhiteSpace(bo.login))
                    {
                        data[0] = data[0];
                    }
                    else
                    {
                        if (isexist(bo, "customers.txt"))
                        {
                            data[0] = bo.login;
                        }
                        else
                        {
                            return false;
                        }
                    }
                    if (string.IsNullOrWhiteSpace(bo.pin))
                    {
                        data[1] = data[1];
                    }
                    else
                    {
                        data[1] = bo.pin;
                    }
                    if (string.IsNullOrWhiteSpace(bo.name))
                    {
                        data[2] = data[2];
                    }
                    else
                    {
                        data[2] = bo.name;
                    }
                    if (string.IsNullOrWhiteSpace(bo.status))
                    {
                        data[5] = data[5];
                    }
                    else
                    {
                        data[5] = bo.status;
                    }

                    string text = $"{data[0]},{data[1]},{data[2]},{data[3]},{data[4]},{data[5]},{data[6]}";
                    list2.Add(text);
                }
                else
                {
                    list2.Add(s);
                }
            }
            writeUpdatedData(list2);
            return true;

        }
        //FUNCTION FOR SEARCHING ACCOUNTS ON BASED ON SPECIFIC CRITERIAS
        internal List<customerBO> search(customerBO bo)
        {
            List<string> list = new List<string>();
            List<string> list2 = new List<string>();

            list2 = Read("customers.txt");
            customerBO temp = new customerBO(bo);
            foreach (string s in list2)
            {
                string[] data = s.Split(",");

                if (bo.accountno == -1111)
                {
                    bo.accountno = int.Parse(data[6]);

                }

                if (string.IsNullOrWhiteSpace(bo.login))
                {
                    bo.login = data[0];
                }
                if (string.IsNullOrWhiteSpace(bo.name))
                {
                    bo.name = data[2];
                }
                if (string.IsNullOrWhiteSpace(bo.type))
                {
                    bo.type = data[3];
                }
                if (string.IsNullOrWhiteSpace(bo.balance))
                {
                    bo.balance = data[4];
                }
                if (string.IsNullOrWhiteSpace(bo.status))
                {
                    bo.status = data[5];
                }
                if (bo.accountno == int.Parse(data[6]) && bo.login == data[0] && bo.name == data[2] && bo.type == data[3] && bo.balance == data[4] && bo.status == data[5])
                {
                    list.Add(s);

                }
                bo = temp;

            }
            List<customerBO> listbo = new List<customerBO>();
            listbo = converttoobjects(list);
            return listbo;

        }
        //FUNCTION FOR RETURNING SPECIFIC SEARCHED CUSTOMER OBJECTS
        public List<customerBO> converttoobjects(List<string> list)
        {
            List<customerBO> empList = new List<customerBO>();
            foreach (string s in list)
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
        //FUNCTION FOR WRITING NEW OBJECT DATA
        internal void writenew(customerdataBO newbo,string filename,string text)
        {
            string filepath = Path.Combine(Environment.CurrentDirectory, filename);
            StreamWriter sw = new StreamWriter(filepath, append: true);
            sw.WriteLine(text);
            sw.Close();
        }
       
    }


}

