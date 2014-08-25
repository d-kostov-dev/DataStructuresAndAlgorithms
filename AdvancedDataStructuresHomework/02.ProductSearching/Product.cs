namespace ProductSearching
{
    using System;

    public class Product : IComparable<Product>
    {
        public Product(string name, double price)
        {
            this.Name = name;
            this.Price = price;
        }

        public string Name { get; set; }

        public double Price { get; set; }

        public int CompareTo(Product other)
        {
            if (other == null)
            {
                return 1;
            }

            if (this.Price > other.Price)
            {
                return 1;
            }
            else if (this.Price < other.Price)
            {
                return -1;
            }
            else
            {
                return 0;
            }
        }

        public override string ToString()
        {
            return string.Format("Product: {0} | Price: {1}", this.Name, this.Price);
        }
    }
}
