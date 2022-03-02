
namespace Model
{
    public class SeafoodDetail
    {
        public SeafoodDetail(Seafood seafood, decimal price)
        {
            Seafood = seafood;
            Price = price;
        }

        public Seafood Seafood { get; set; }
        public decimal Price { get; set; }
    }
}