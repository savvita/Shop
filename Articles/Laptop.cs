namespace App2
{
    internal class Laptop : Article
    {
        private new static readonly int id = ++Article.id;
        public Laptop(double price) : base("Laptop", price)
        {
            Id = id;
        }

        public Laptop() : this(0)
        {
        }
    }
}
