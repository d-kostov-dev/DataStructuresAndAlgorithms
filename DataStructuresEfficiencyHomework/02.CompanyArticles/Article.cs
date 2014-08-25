namespace CompanyArticles
{
    using System;

    public class Article : IComparable<Article>
    {
        public string Title { get; set; }

        public string Vendor { get; set; }

        public double Price { get; set; }

        public int Barcode { get; set; }

        public int CompareTo(Article other)
        {
            if (other == null)
            {
                return 1;
            }

            if (this.Price > other.Price)
            {
                return 1;
            }

            if (this.Price < other.Price)
            {
                return -1;
            }

            return 0;
        }
    }
}
