namespace App2
{
    internal class Paste: Article
    {
        private new static readonly int id = ++Article.id;
        public Paste(double price) : base("Paste", price)
        {
            Id = id;
        }

        public Paste() : this(0)
        {
        }
    }
}
