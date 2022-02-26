using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuctionHouse
{
    class Product
    {
        private string name;
        private string type;
        private float initialCost;
        private string accountNumber;

        public Product(string name, string type, float initialCost, string accountNumber)
        {
            this.name = name;
            this.type = type;
            this.initialCost = initialCost;
            this.accountNumber = accountNumber;
        }

        public string Name
        {
            get { return name; }
        }

        public string Type
        {
            get { return type; }
        }

        public float InitialCost
        {
            get { return initialCost; }
        }

        public string AccountNumber
        {
            get { return accountNumber; }
            set { accountNumber = value; }
        }

        public override string ToString()
        {
            return $"{name}{Environment.NewLine}{type}{Environment.NewLine}{initialCost:C}{Environment.NewLine}";
        }

    }
}
