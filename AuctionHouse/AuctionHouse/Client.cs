using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuctionHouse
{
    class Client
    {
        private static int accountNumberSeed = 1;
        private string name;
        private string email;
        private string password;
        private bool loggedIn;
        private string accountNumber;

        public Client (string name, string email, string password, bool loggedIn)
        {
            this.name = name;
            this.password = password;
            this.email = email;
            this.loggedIn = loggedIn;
            this.accountNumber = accountNumberSeed.ToString();
            accountNumberSeed++;
        }

        public string Name
        {
            get { return name; }
        }

        public string Email
        {
            get { return email; }
        }

        public string Password
        {
            get { return password; }
        }

        public bool LoggedIn
        {
            get { return loggedIn; }
            set { loggedIn = value; }
        }

        public string AccountNumber
        {
            get { return accountNumber; }
        }


        public override string ToString()
        {
            return $"Name: {name}{Environment.NewLine}Email: {email}{Environment.NewLine}Password: {password}{Environment.NewLine}Account number: {accountNumber}";
        }

    }
}
