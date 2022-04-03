namespace App2
{
    internal class Pencil: Article
    {
        private new static readonly int id = ++Article.id;
        public Pencil(double price) : base("Pencil", price)
        {
            Id = id;
        }

        public Pencil() : this(0)
        {
        }
    }
}
