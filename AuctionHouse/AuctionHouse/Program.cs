using System;
using System.Collections.Generic;

namespace AuctionHouse
{
    class Program
    {
        static ClientList clientlist = new ClientList();
        static ProductList products = new ProductList();
        static Bid bids = new Bid();

        static bool LoggedIn = false;
        static int option;

        static string User_email, User_password;

        const int MENU_REGISTER = 0, LOGIN = 1, MENU_EXIT = 2, USER_AUTHENTICATION = 0, USER_LOGOUT = 1, ADVERTISE_PRODUCT = 2, LIST_PRODUCTS = 3, SEARCH_ITEMS = 4, BID = 5, CURRENT_BIDS = 6;
        
        static void Main(string[] args)
        {

            while (true)
            {
                if (!LoggedIn)
                {
                    option = CAB201.UserInterface.GetOption(
                        "Auction House Main Menu",
                        "Register User",
                        "Log in",
                        "EXIT"
                        );
                }
                else
                {
                    option = CAB201.UserInterface.GetOption(
                        "Auction House Main Menu",
                        "Authenticate User",
                        "Logout",
                        "Advertise your product",
                        "List your advertised products",
                        "Search for an item",
                        "Bid on an item",
                        "List all current bids and sell items"
                        );
                }

                if (option == MENU_EXIT && !LoggedIn)
                {
                    break;
                }
                else if (!LoggedIn)
                {
                    NotLoggedInProcessMainMenu(option);
                }
                else
                {
                    ProcessMainMenu(option);
                }
            }
            
            static void NotLoggedInProcessMainMenu(int opt)
            {
                switch (opt)
                {
                    case MENU_REGISTER:
                        RegisterUser();
                        break;
                    case LOGIN:
                        Login();
                        break;
                }
            }

            static void ProcessMainMenu(int opt)
            {
                switch (opt)
                {
                    case USER_AUTHENTICATION:
                        UserAuthentication();
                        break;
                    case USER_LOGOUT:
                        UserLogout();
                        break;
                    case ADVERTISE_PRODUCT:
                        AdvertiseProduct();
                        break;
                    case LIST_PRODUCTS:
                        ListAdvertisedProducts();
                        break;
                    case SEARCH_ITEMS:
                        SearchItems();
                        break;
                    case BID:
                        BidOnItem();
                        break;
                    case CURRENT_BIDS:
                        ListCurrentBids();
                        break;

                }
            }

            
            static void RegisterUser()
            {
                if (!LoggedIn)
                {
                    string name = CAB201.UserInterface.GetInput("Please enter your name").Trim();
                    string email = CAB201.UserInterface.GetInput("Please enter your email").Trim();
                    string password = CAB201.UserInterface.GetInput("Please enter a password").Trim();
                    LoggedIn = true;
                    Client newClient = new Client(name, email, password, LoggedIn);
                    clientlist.RegisterUser(newClient);
                    User_email = email;
                    User_password = password;
                }
                else
                {
                    CAB201.UserInterface.Error("log out first");
                }

            }

            static void Login()
            {
                if (!LoggedIn)
                {
                    string email = CAB201.UserInterface.GetInput("Please enter your email");
                    string password = CAB201.UserInterface.GetPassword("Please enter your password");
                    LoggedIn = clientlist.UserLogin(email, password, LoggedIn);
                    User_email = email;
                    User_password = password;
                }
                else
                {
                    CAB201.UserInterface.Error("Log out first");
                }
            }

            static void UserAuthentication(){
                if (!LoggedIn)
                {
                    CAB201.UserInterface.Error("log in");
                    return;
                }
                else
                {
                    string auth_email = CAB201.UserInterface.GetInput("Please enter your email");
                    string auth_password = CAB201.UserInterface.GetInput("Please enter your password");

                    List<Client> clients = clientlist.AuthenticateUser(auth_email, auth_password, LoggedIn);
                    foreach (Client cli in clients)
                    {
                        CAB201.UserInterface.Message(cli);
                    }
                }
            }


            static void UserLogout()
            {
                if (clientlist.Logout(LoggedIn, User_email, User_password))
                {
                    LoggedIn = false;
                    User_email = null;
                    User_password = null;
                    CAB201.UserInterface.Message("Successfully logged out!");
                }
                else
                {
                    CAB201.UserInterface.Error("Error");
                }
            }

            static void AdvertiseProduct()
            {
                if (LoggedIn)
                {
                    string name = CAB201.UserInterface.GetInput("Please enter your products name");
                    string type = CAB201.UserInterface.GetInput("Please enter your product type");
                    float cost = float.Parse(CAB201.UserInterface.GetInput("Please enter the starting cost"));

                    string accountnumber = clientlist.UserLoggedIn();

                    Product newProduct = new Product(name, type, cost, accountnumber);
                    products.Advertise(newProduct);
                }
                else
                {
                    CAB201.UserInterface.Error("Log in first");
                }

            }

            static void ListAdvertisedProducts()
            {
                products.ListAllClientProducts(clientlist.UserLoggedIn());
            }

            static void SearchItems()
            {
                string name = CAB201.UserInterface.GetInput("Please enter a product name");
                string type = CAB201.UserInterface.GetInput("Please enter a product type");
                products.Search(name, type);
            }

            
            static void BidOnItem()
            {
                string product_name_input = CAB201.UserInterface.GetInput("Please enter a product name");
                List<string> product_name = new List<string>();
                List<string> acc_num = new List<string>();


                string[] items = products.ProductNames(product_name_input);
                for (int i = 0; i < items.Length; i++)
                {
                    if (i % 2 == 0)
                    {
                        product_name.Add(items[i]);
                    }
                    else
                    {
                        acc_num.Add(items[i]);
                    }
                }
                string[] product_name_string = product_name.ToArray();
                string[] acc_num_string = acc_num.ToArray();

                int menuoption = CAB201.UserInterface.GetOption(
                    "Please chose an item",
                    product_name_string
                    );

                bids.CreateBid(acc_num_string, product_name_string, menuoption, clientlist.GetClients(), products.ListAllProducts());

            }

            static void ListCurrentBids()
            {
                bids.ListAllCurrentBids(clientlist.GetClients(), products.ListAllProducts());
            }
        }
    }
}
