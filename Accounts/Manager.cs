using System;
using System.IO;

namespace App2
{
    internal class Manager: Employee
    {
        private readonly string pathClients;
        private readonly string pathSales;

        #region ctors

        public Manager(string name, string login, string password, int year, double salary): base(name, login, password, year, salary)
        {
            pathClients = $"{Login}_clients.txt";
            pathSales = $"{Login}_sales.txt";
        }

        public Manager(string name, string login, string password, int year) : this(name, login, password, year, 0)
        {
        }

        public Manager(string name, string login, string password) : this(name, login, password, 1900, 0)
        {
        }

        public Manager(string name, string login) : this(name, login, "", 1900, 0)
        {
        }

        public Manager(string name) : this(name, "", "", 1900, 0)
        {
        }

        public Manager() : this("", "", "", 1900, 0)
        {
        }

        #endregion

        public void AddClient(Client client)
        {
            if (client != null)
                AddAccount(client, pathClients);
        }

        public Client[] GetClients()
        {
            if (!File.Exists(pathClients))
                return null;

            try
            {
                string[] lines = File.ReadAllLines(pathClients);

                Client[] clients = new Client[lines.Length];

                for (int i = 0; i < lines.Length; i++)
                {
                    clients[i] = (Client)GetAccount(lines[i], AccountType.Client);
                }
                return clients;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public void Sell(Client client, Backet backet)
        {
            if (client == null || backet == null)
                return;

            try
            {
                AddClient(client);

                for (int i = 0; i < backet.Articles.Count; i++)
                {
                    string str = String.Format("{0}\tManager: {1}\tClient: {2}\tArticle: {3}\n", DateTime.Now.ToShortDateString(), Login, client.Login,
                        backet.Articles[i].ToString());
                    File.AppendAllText(pathSales, str);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public string[] GetSalesHistory()
        {
            if (!File.Exists(pathSales))
                return null;

            try
            {
                return File.ReadAllLines(pathSales);
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
