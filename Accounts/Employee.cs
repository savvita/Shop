using System;
using System.IO;

namespace App2
{
    enum AccountType
    {
        Client,
        Manager,
        Admin
    }
    internal class Employee: Account
    {
        public double Salary { get; set; }

        #region ctors
        public Employee(string name, string login, string password, int year, double salary) : base(name, login, password, year)
        {
            Salary = salary;
        }

        public Employee(string name, string login, string password, int year) : this(name, login, password, year, 0)
        {
        }

        public Employee(string name, string login, string password) : this(name, login, password, 1900, 0)
        {
        }

        public Employee(string name, string login) : this(name, login, "", 1900, 0)
        {
        }

        public Employee(string name) : this(name, "", "", 1900, 0)
        {
        }

        public Employee() : this("", "", "", 1900, 0)
        {
        }
        #endregion

        public override string ToString()
        {
            return $"{base.ToString()}\tSalary: {Salary}";
        }

        public static void AddAccount(Account account, string path)
        {
            try
            {
                File.AppendAllText(path, $"{account}\n");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static string GetProperty(string line, ref int idx)
        {
            int start = line.IndexOf(':', idx);
            int end = line.IndexOfAny(new char[] { '\t', '\n' }, start + 1);
            idx = end + 1;

            if (end == -1)
                return line.Substring(start + 2);

            return line.Substring(start + 2, end - start - 2);
        }

        public static Account GetAccount(string line, AccountType type)
        {
            Account account = null;

            int idx = 0;

            string name = GetProperty(line, ref idx);
            string login = GetProperty(line, ref idx);
            string password = GetProperty(line, ref idx);

            switch(type)
            {
                case AccountType.Admin:
                    account = new Admin(name, login, password);
                    break;

                case AccountType.Manager:
                    account = new Manager(name, login, password);
                    break;

                case AccountType.Client:
                    account = new Client(name, login, password);
                    break;
            }

            if (int.TryParse(GetProperty(line, ref idx), out int year))
            {
                account.YearOfBirthday = year;
            }
            else
            {
                account.YearOfBirthday = 1900;
            }

            return account;
        }

        public static double GetSalary(string line)
        {
            int idx = line.LastIndexOf(':');

            if (double.TryParse(line.Substring(idx + 1), out double salary))
            {
                return salary;
            }
            else
            {
               return 0;
            }
        }
    }
}
