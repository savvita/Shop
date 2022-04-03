namespace App2
{
    internal class Client: Account
    {
        #region ctors
        public Client(string name, string login, string password, int year): base(name, login, password, year)
        {
        }

        public Client(string name, string login, string password) : base(name, login, password)
        {
        }

        public Client(string name, string login) : base(name, login)
        {
        }

        public Client(string name) : base(name)
        {
        }

        public Client() : base()
        {
        }

        #endregion

        public void Buy(ref Backet backet)
        {
            backet.Shop.SellBacket(this, backet);
            backet = null;
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
