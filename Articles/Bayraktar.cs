namespace App2
{
    internal class Bayraktar : Article
    {
        private new static readonly int id = ++Article.id;
        public Bayraktar(double price) : base("Bayraktar", price)
        {
            Id = id;
        }

        public Bayraktar() : this(0)
        {
        }
    }
}
