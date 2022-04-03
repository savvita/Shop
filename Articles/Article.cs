namespace App2
{
    internal class Article
    {
        protected static int id = 0;
        public int Id { get; protected set; }

        public string Name { get; set; }

        public double Price { get; set; }

        public Article(string name = "Article", double price = 0)
        {
            Name = name;
            Price = price;
            Id = id;
        }

        public override string ToString()
        {
            return string.Format("ID: {0}\tName: {1}\tPrice: {2}", Id, Name, Price);
        }
    }
}
