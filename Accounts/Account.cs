using System;

namespace App2
{
    internal class Account
    {
        public string Login { get; private set; }
        public string Password { get; private set; }

        public string Name { get; set; }

        public int YearOfBirthday { get; set; }

        public bool HasAdminsRights { get; protected set; }

        public Account(string name = "", string login = "", string password = "", int year = 1900)
        {
            Name = name;
            Login = login;
            Password = password;
            YearOfBirthday = year;
            HasAdminsRights = false;
        }

        public bool SetLogin(Account account, string newLogin)
        {
            if (account.HasAdminsRights)
            {
                Login = newLogin;
                return true;
            }

            return false;
        }

        public bool SetPassword(Account account, string newPassword)
        {
            if (account.HasAdminsRights)
            {
                Password = newPassword;
                return true;
            }

            return false;
        }

        public int GetAge()
        {
            return DateTime.Now.Year - YearOfBirthday;
        }

        public override string ToString()
        {
            return string.Format("Name: {0}\tLogin: {1}\tPassword: {2}\tYear of birthday: {3}", Name, Login, Password, YearOfBirthday);
        }
    }
}
