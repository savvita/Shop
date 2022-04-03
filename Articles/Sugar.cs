namespace App2
{
    internal class Sugar : Article
    {
        private new static readonly int id = ++Article.id;
        public Sugar(double price) : base("Sugar", price)
        {
            Id = id;
        }

        public Sugar() : this(0)
        {
        }
    }
}
