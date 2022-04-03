using System;
using System.IO;

namespace App2
{
    internal class Admin: Employee
    {
        public string PathManagers { get; set; }

        #region ctors

        public Admin(string name, string login, string password, int year, double salary, string path) : base(name, login, password, year, salary)
        {
            PathManagers = path;
            HasAdminsRights = true;
        }
        public Admin(string name, string login, string password, int year, double salary) : this(name, login, password, year, salary, $"{login}.txt")
        {
        }
        public Admin(string name, string login, string password, int year): this(name, login, password, year, 0)
        {
        }

        public Admin(string name, string login, string password) : this(name, login, password, 1900)
        {
        }

        public Admin(string name, string login) : this(name, login, "")
        {
        }

        public Admin(string name) : this(name, "")
        {
        }

        public Admin() : this("")
        {
        }

        #endregion

        public void AddManager(Manager manager)
        {
            AddAccount(manager, PathManagers);
        }

        public Manager[] GetManagers()
        {
            if (!File.Exists(PathManagers))
                return null;

            try
            {
                string[] lines = File.ReadAllLines(PathManagers);

                Manager[] managers = new Manager[lines.Length];

                for (int i = 0; i < lines.Length; i++)
                {
                    managers[i] = (Manager)GetAccount(lines[i], AccountType.Manager);
                    managers[i].Salary = GetSalary(lines[i]);
                }
                return managers;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public bool ChangeLogin(ref Manager manager, string newLogin)
        {
            return manager.SetLogin(this, newLogin);
        }

        public bool ChangePassword(ref Manager manager, string newPassword)
        {
            return manager.SetPassword(this, newPassword);
        }
    }
}
