using System;
using System.Collections.Generic;

namespace App2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Shop shop = new("My shop");
            shop.AddAdmin(new Admin("John", "john", "qwerty", 1950, 1000.0));
            shop.AddAdmin(new Admin("NotJohn", "notjohn"));

            Random random = new();

            Admin john = shop.GetAdmin("john");

            if (john != null)
            {
                int size = random.Next(10);

                for (int i = 0; i < size; i++)
                {
                    Manager manager = new("name" + (char)('A' + i), "login" + (char)('A' + i), "password" + (char)('A' + i));
                    manager.YearOfBirthday = random.Next(1900, 2022);
                    manager.Salary = random.Next() / 100.0;

                    john.AddManager(manager);
                }
            }

            Admin notjohn = shop.GetAdmin("notjohn");

            if (john != null)
            {

                int size = random.Next(10);

                for (int i = 0; i < size; i++)
                {
                    Manager manager = new("name" + (char)('Z' - i), "login" + (char)('Z' - i), "password" + (char)('Z' - i))
                    {
                        YearOfBirthday = random.Next(1900, 2022),
                        Salary = random.Next() / 100.0
                    };

                    notjohn.AddManager(manager);
                }
            }

            int countOfClients = 10;

            for (int i = 0; i < countOfClients; i++)
            {
                Backet backet = new Backet(shop);

                int articles = random.Next(10);

                for (int j = 0; j < articles; j++)
                {
                    backet.AddArticle(ArticleFactory.Create((ArticleType)random.Next(6)));
                }

                Client client = new Client("Client" + i, "client" + i);
                client.Buy(ref backet);
            }

            string del = new string('=', 15);

            Console.WriteLine("Admins:");

            var admins = shop.GetAllAdmins();

            foreach (Admin admin in admins)
            {
                Console.WriteLine(admin);
            }

            Console.WriteLine(del);

            Console.WriteLine("Managers:");

            var managers = shop.GetAllManagers();

            foreach(Manager manager in managers)
            {
                Console.WriteLine(manager);
            }

            Console.WriteLine(del);

            Console.WriteLine("Clients:");

            var clients = shop.GetAllClients();

            foreach (Client client in clients)
            {
                Console.WriteLine(client);
            }

            Console.WriteLine(del);

            Console.WriteLine("Sales:");

            var sales = shop.GetAllSales();

            foreach(var sale in sales)
            {
                Console.WriteLine(sale);
            }
        }
    }
}
