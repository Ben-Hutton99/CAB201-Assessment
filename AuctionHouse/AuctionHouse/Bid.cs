using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuctionHouse
{
    class Bid
    {
        private List<Bidding> bids = new List<Bidding>();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="acc_num"></param> List of account numbers
        /// <param name="product_list"></param> List of products matching search
        /// <param name="menuoption"></param> Option from previous menu
        /// <param name="client"></param> List of all clients
        /// <param name="products"></param> List of all products
        public void CreateBid(string[] acc_num, string[] product_list, int menuoption, List<Client> client, List<Product> products)
        {
            foreach (Product product in products)
            {
                if (product.Name == product_list[menuoption] && product.AccountNumber == acc_num[menuoption])
                {
                    PlaceBid(product_list[menuoption], acc_num[menuoption], product.InitialCost.ToString(), client, products);

                }
            }
            
            
        }

        /// <summary>
        /// Takes in bid amount and whether the user wants to have the item home delivered
        /// </summary>
        /// <param name="name"></param> Name of product
        /// <param name="accountnumber"></param> account number of product owner
        /// <param name="cost"></param> cost of product
        /// <param name="client"></param> list of all clients
        /// <param name="products"></param> list of all products
        public void PlaceBid(string name, string accountnumber, string cost, List<Client> client, List<Product> products)
        {
            foreach (Client clients in client)
            {
                if (accountnumber == clients.AccountNumber)
                {
                    CAB201.UserInterface.Message($"Information on {name}:{Environment.NewLine}" +
                        $"Price: {cost:C}{Environment.NewLine}" +
                        $"Seller: {clients.Name}{Environment.NewLine}" +
                        $"Contact information: {clients.Email}");
                }
                break;
            }

            int place_bid = CAB201.UserInterface.GetOption(
                $"Would you like to bid on the {name}?",
                "Yes",
                "No"
            );

            switch (place_bid)
            {
                case 0:
                    foreach (Product product in products)
                    {
                        float bid_amount = float.Parse(CAB201.UserInterface.GetInput("How much would you like to bid"));
                        if (product.InitialCost > bid_amount)
                        {
                            while (product.InitialCost > bid_amount)
                            {
                                CAB201.UserInterface.Error($"Enter a number above {product.InitialCost:C}");
                                bid_amount = float.Parse(CAB201.UserInterface.GetInput("How much would you like to bid"));
                            }
                        }
                        else
                        {
                            foreach (Client clients in client)
                            {
                                bool homedelivered = CAB201.UserInterface.GetBool("Would you like this item to be home delivered");
                                Bidding newBid = new Bidding(product.Name, product.Type, product.InitialCost, product.AccountNumber, bid_amount, homedelivered, clients.AccountNumber, false);
                                bids.Add(newBid);
                                CAB201.UserInterface.Message($"Bid of {bid_amount:C} successfully placed on item {product.Name}!");
                            }
                            break;
                        }
                    }
                    break;
                default:
                    CAB201.UserInterface.Message("Returning to main menu");
                    break;
            }

            //bool homedelivered = CAB201.UserInterface.GetBool("Would you like this item to be home delivered");
            //Bidding newBid = new Bidding(product.Name, product.Type, product.InitialCost, product.AccountNumber, bid_amount, homedelivered, clients.AccountNumber, false);
        }

        /// <summary>
        /// Creates 3 lists that contain the name of each bidder,
        /// amount they are bidding and what they are bidding on,
        /// then calls method PrintBidders()
        /// </summary>
        /// <param name="client"></param> used to get information on each client
        /// <param name="products"></param> used to get information on each product
        public void ListAllCurrentBids(List<Client> client, List<Product> products)
        {
            List<string> name = new List<string>();
            List<string> amount = new List<string>();
            List<string> product_name = new List<string>();
            foreach (Product product in products)
            {
                foreach(Client clients in client)
                {
                    foreach (Bidding bid in bids)
                    {
                        if (bid.Bidder_accountnumber == clients.AccountNumber && !bid.Sold)
                        {
                            name.Add(clients.Name);
                            amount.Add(bid.Bid_amount.ToString());
                            product_name.Add(product.Name);

                        }
                    }
                    
                }
            }
            PrintBidders(name.ToArray(), amount.ToArray(), product_name.ToArray());
        }

        /// <summary>
        /// adds each parameter into a list to be displayed on a menu
        /// </summary>
        /// <param name="name"></param> contains the name of everyone who has bid on the product
        /// <param name="amount"></param> contains the amount that has been bid
        /// <param name="product"></param> contains the product that has been bid on
        private void PrintBidders(string[] name, string[] amount, string[] product)
        {
            List<string> menuoptions = new List<string>();

            for (int i = 0; i < name.Length; i++)
            {
                menuoptions.Add($"{name[i]} has placed a bid of {amount[i]} on your {product[i]}");
            }

            string[] menuoptions_array = menuoptions.ToArray();

            int selloption = CAB201.UserInterface.GetOption(
                "Who would you like to sell to",
                menuoptions_array
                );

            SellItems(selloption, name, amount, product);
        }

        /// <summary>
        /// asks user if they want to sell their product then sets the item to sold
        /// </summary>
        /// <param name="selloption"></param> contains the number of which item is to be sold
        /// <param name="name"></param> contains the name of everyone who has bid on the product
        /// <param name="amount"></param> contains the amount that has been bid
        /// <param name="product"></param> contains the product that has been bid on
        private void SellItems(int selloption, string[] name, string[] amount, string[] product)
        {
            int menuoption = CAB201.UserInterface.GetOption(
                $"Would you like to sell to {name[selloption]}",
                "Yes",
                "No"
                );

            if (menuoption == 1)
            {
                CAB201.UserInterface.Message($"{product[selloption]} has been successfully sold to {name[selloption]} for {amount[selloption]}");
                foreach (Bidding bid in bids)
                {
                    bid.Sold = true;
                }
            }
        }

    }
}
