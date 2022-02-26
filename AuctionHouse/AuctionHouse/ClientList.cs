using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuctionHouse
{
    class ClientList
    {
        private List<Client> clients = new List<Client>();

        /// <summary>
        /// used to add a user to list
        /// </summary>
        /// <param name="newClient"></param> contains all information for a new client
        public void RegisterUser(Client newClient)
        {
            clients.Add(newClient);
        }

        /// <summary>
        /// lists all clients
        /// </summary>
        /// <returns></returns>
        public List<Client> GetClients()
        {
            List<Client> results = new List<Client>();

            foreach ( Client user in clients)
            {
                results.Add(user);
            }
            return results;
        }

        /// <summary>
        /// comapares paramaters given to log a user in,
        /// sets field to true of successfully logged in
        /// </summary>
        /// <param name="email"></param> email given to log in
        /// <param name="password"></param> password given to log in
        /// <param name="loggedin"></param> checks whether anyone is logged in
        /// <returns></returns>
        public bool UserLogin(string email, string password, bool loggedin)
        {
            foreach (Client cli in clients)
            {
                if (cli.Email == email && cli.Password == password && loggedin == false)
                {
                    cli.LoggedIn = true;
                    CAB201.UserInterface.Message("Logged in!");
                }
                else
                {
                    CAB201.UserInterface.Error("Unsuccessful");
                }
                if (cli.LoggedIn)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// authenticates user then displays their information
        /// </summary>
        /// <param name="clientEmail"></param> email given to authenticate
        /// <param name="clientPassword"></param> password given to authenticate
        /// <param name="loggedin"></param> checks to see if anyone is logged in
        /// <returns></returns>
        public List<Client> AuthenticateUser(string clientEmail, string clientPassword, bool loggedin)
        {
            List<Client> results = new List<Client>();

            foreach(Client cli in clients)
            {
                if (cli.Email == clientEmail && cli.Password == clientPassword && cli.LoggedIn && loggedin)
                {
                    results.Add(cli);
                }
            }
            return results;
        }

        /// <summary>
        /// returns current user logged in
        /// </summary>
        /// <returns></returns>
        public string UserLoggedIn()
        {
            foreach (Client cli in clients)
            {
                if (cli.LoggedIn)
                {
                    return cli.AccountNumber;
                }
            }
            return "User not found";
        }

        /// <summary>
        /// sets 
        /// </summary>
        /// <param name="loggedin"></param> checks to see if anyone if logged in
        /// <param name="email"></param> used to check who is logged in
        /// <param name="password"></param> used to check who is logged in
        /// <returns></returns>
        public bool Logout(bool loggedin, string email, string password)
        {
            foreach (Client cli in clients)
            {
                if (cli.Email == email && cli.Password == password && loggedin)
                {
                    cli.LoggedIn = false;
                }
                else
                {
                    continue;
                }
            }
            return true;
        }


    }
}
