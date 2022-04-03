namespace App2
{
    internal class Carrot: Article
    {
        private new static readonly int id = ++Article.id;
        public Carrot(double price): base("Carrot", price)
        {
            Id = id;
        }

        public Carrot() : this(0)
        {
        }
    }
}
