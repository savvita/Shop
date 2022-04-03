namespace App2
{
    enum ArticleType
    {
        Bayraktar,
        Bed,
        Carrot,
        Laptop,
        Paste,
        Pencil,
        Sugar
    }
    internal static class ArticleFactory
    {
        public static Article Create(ArticleType type)
        {
            Article article = null;

            switch(type)
            {
                case ArticleType.Bayraktar:
                    article = new Bayraktar();
                    break;

                case ArticleType.Bed:
                    article = new Bed(0.5);
                    break;

                case ArticleType.Carrot:
                    article = new Carrot(3);
                    break;

                case ArticleType.Laptop:
                    article = new Laptop(2000);
                    break;

                case ArticleType.Paste:
                    article = new Paste(50);
                    break;

                case ArticleType.Pencil:
                    article = new Pencil(10);
                    break;

                case ArticleType.Sugar:
                    article = new Sugar(2);
                    break;
            }

            return article;
        }
    }
}
