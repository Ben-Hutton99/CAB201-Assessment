using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuctionHouse
{
    class Bidding : Product
    {
        private float bid_amount;
        private bool homedelivered;
        private string bidder_accountnumber;
        private bool sold;


        public Bidding(string name, string type, float initialCost, string accountNumber, float bid_amount, bool homedelivered, string bidder_accountnumber, bool sold) : base(name, type, initialCost, accountNumber)
        {
            this.bid_amount = bid_amount;
            this.homedelivered = homedelivered;
            this.bidder_accountnumber = bidder_accountnumber;
            this.sold = sold;
        }

        public float Bid_amount
        {
            get { return bid_amount; }
        }

        public bool Homedelivered
        {
            get { return homedelivered; }
        }

        public string Bidder_accountnumber
        {
            get { return bidder_accountnumber; }
        }

        public bool Sold
        {
            get { return sold; }
            set { sold = value; }
        }

        public override string ToString()
        {
            return $"Bid amount {bid_amount}{Environment.NewLine}";
        }
    }
}
