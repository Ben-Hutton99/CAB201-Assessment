using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuctionHouse
{
    class ProductList
    {
        public List<Product> products = new List<Product>();

        /// <summary>
        /// adds a new item to products list
        /// </summary>
        /// <param name="newProduct"></param> contains information on current item
        public void Advertise(Product newProduct)
        {
            products.Add(newProduct);
        }

        /// <summary>
        /// lists all products
        /// </summary>
        /// <returns></returns>
        public List<Product> ListAllProducts()
        {
            List<Product> results = new List<Product>();

            foreach (Product product in products)
            {
                results.Add(product);
            }
           
            return results;
        }

        /// <summary>
        /// lists all products for current user
        /// </summary>
        /// <param name="userLoggedIn"></param> current user logged in
        public void ListAllClientProducts(string userLoggedIn)
        {
            List<Product> results = new List<Product>();

            foreach(Product product in products)
            {
                if (userLoggedIn == product.AccountNumber)
                {
                    results.Add(product);
                }
                else
                {
                    CAB201.UserInterface.Error("No products found");
                }
            }
            int x = 1;
            foreach (Product product in results)
            {
                CAB201.UserInterface.Message($"Product {x++}:");
                CAB201.UserInterface.Message(product);
            }
        }

        /// <summary>
        /// searches through product list based on what the user has input
        /// </summary>
        /// <param name="name"></param> name of item given as input from user
        /// <param name="type"></param> type of product given as input from user
        public void Search(string name, string type)
        {
            List<Product> result = new List<Product>();
            foreach (Product product in products)
            {
                if (product.Name == name && product.Type == type)
                {
                    result.Add(product);
                }
                else
                {
                    CAB201.UserInterface.Error($"No products found for {name} and type {type}");
                }
            }
            foreach(Product products in result)
            {
                CAB201.UserInterface.Message(products);
            }
        }

        /// <summary>
        /// adds name and account number of items with the same name as paramater
        /// </summary>
        /// <param name="name"></param> user input used to search through list
        /// <returns>List of products matching given string</returns>
        public string[] ProductNames(string name)
        {
            List<string> list = new List<string>();

            foreach (Product product in products)
            {
                if (product.Name == name)
                {
                    list.Add(product.Name);
                    list.Add(product.AccountNumber);
                }
            }
            string[] results = list.ToArray();

            return results;
        }


    }
}
