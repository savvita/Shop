namespace App2
{
    internal class Bed: Article
    {
        private new static readonly int id = ++Article.id;
        public Bed(double price): base("Bed", price)
        {
            Id = id;
        }

        public Bed() : this(0)
        {
        }
    }
}
