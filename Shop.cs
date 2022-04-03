using System;
using System.IO;
using System.Collections.Generic;

namespace App2
{
    internal class Shop
    {
        public string Name { get; set; }

        private readonly string pathAdmins;

        public Shop(string name = "Shop")
        {
            Name = name;
            pathAdmins = "admins.txt";
        }

        public void AddAdmin(Admin admin)
        {
            admin.PathManagers = "\\Managers\\"+ admin.PathManagers;
            Employee.AddAccount(admin, pathAdmins);
        }

        public Admin GetAdmin(string login)
        {
            if (!File.Exists(pathAdmins))
                return null;

            try
            {
                string[] lines = File.ReadAllLines(pathAdmins);

                for (int i = 0; i < lines.Length; i++)
                {
                    if (lines[i].Contains(login))
                    {
                        Admin admin = (Admin)Employee.GetAccount(lines[i], AccountType.Admin);
                        admin.Salary = Employee.GetSalary(lines[i]);

                        return admin;
                    }
                }
                return null;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public Admin[] GetAllAdmins()
        {
            if (!File.Exists(pathAdmins))
                return null;

            try
            {
                string[] lines = File.ReadAllLines(pathAdmins);

                Admin[] admins = new Admin[lines.Length];

                for (int i = 0; i < lines.Length; i++)
                {
                    admins[i] = (Admin)Employee.GetAccount(lines[i], AccountType.Admin);
                    admins[i].Salary = Employee.GetSalary(lines[i]);
                }
                return admins;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<Manager> GetAllManagers()
        {
            Admin[] admins = GetAllAdmins();

            if (admins == null)
                return null;

            List<Manager> managers = new List<Manager>();

            for (int i = 0; i < admins.Length; i++)
            {
                var man = admins[i].GetManagers();

                if (man != null)
                    managers.AddRange(man);
            }

            return managers;
        }

        public List<Client> GetAllClients()
        {
            List<Manager> managers = GetAllManagers();

            if (managers == null)
                return null;

            List<Client> clients = new List<Client>();

            foreach(Manager m in managers)
            {
                var m_clients = m.GetClients();

                if(m_clients != null)
                    clients.AddRange(m_clients);
            }

            return clients;
        }

        public List<string> GetAllSales()
        {
            List<Manager> managers = GetAllManagers();

            if (managers == null)
                return null;

            List<string> sales = new List<string>();

            foreach (Manager m in managers)
            {
                var m_sales = m.GetSalesHistory();

                if(m_sales != null)
                    sales.AddRange(m_sales);
            }

            return sales;

        }

        private Manager FindFreeManager()
        {
            var managers = GetAllManagers();

            if (managers == null)
                return null;

            Random rnd = new Random();

            return managers[rnd.Next(managers.Count - 1)];
        }

        public void SellBacket(Client client, Backet backet)
        {
            Manager manager = FindFreeManager();

            if (manager != null)
                manager.Sell(client, backet);
        }
    }
}
