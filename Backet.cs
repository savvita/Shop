using System.Collections.Generic;

namespace App2
{
    internal class Backet
    {
        public List<Article> Articles { get; private set; }

        public Shop Shop { get; private set; }

        public Backet(Shop shop)
        {
            Articles = new List<Article>();
            Shop = shop;
        }

        public void AddArticle(Article article)
        {
            Articles.Add(article);
        }
    }
}
