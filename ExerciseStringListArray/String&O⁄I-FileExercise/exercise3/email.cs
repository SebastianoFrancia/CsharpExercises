using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise3
{
    internal class email
    {
        private string _accountname;
        private string _domain;

        public string AccountName
        {
            get { return _accountname; }
            private set
            {
                if(value==null || value.Contains("@")) throw new ArgumentException("the account name is invalid");
                _accountname = value;
            }
        }

        public string Domain
        {
            get { return _domain; }
            private set
            {
                if(value.Contains("@")) throw new ArgumentException("invalid top level doamin");
                _domain = value;
            }
        }
        public EmailAddress(string email)
        {
            //if(!IsEmailAddress(email)) throw new ArgumentException("isn't an valid email address");
            if(email.Contains("@"))
            {
                string[] emailSpilt = email.Split("@");
                AccountName = emailSpilt[0];
                Domain = emailSpilt[1];
            }
        }

        public string EmailToAccountname(string email)
        {
            List<char> accountname = new List<char>();
            foreach (char ch in email)
            {
                if (ch == '@') break;
                accountname.Add(ch);
            }
            return accountname.ToString();
        }
       

        public bool TheresTopLevelDoamin(string domain)
        {
            if(domain.Contains("."))
            {
                string[] domainSplit = domain.Split(".");
                if (domainSplit[0].Contains(".") || domainSplit[1].Contains(".") || domainSplit[1].Length<2) return false;
                return true;
            }
            
            return false;
        }

        public string ToString()
        {
            return $"{AccountName}@{Domain}";
        }
    }
}
