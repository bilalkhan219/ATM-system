using System;
using System.Collections.Generic;
using System.Net;
using System.Runtime.CompilerServices;
using System.Text;

namespace ATM_BO
{
    public class customerBO
    {
        public string login { get; set; }
        public string pin { get; set; }
        public string name { get; set; }
        public string type { get; set; }
        public string balance { get; set; }
        public string status { get; set; }
        public int accountno { get; set; }
        public static int count = 0;
        public customerBO (customerBO bo)
        {
            this.login = bo.login;
            this.pin = bo.pin;
            this.name = bo.name;
            this.type = bo.type;
            this.balance = bo.balance;
            this.status = bo.status;
            this.accountno = bo.accountno;
        }
        public customerBO()
        {
            count = 0;
        }

    }
}
