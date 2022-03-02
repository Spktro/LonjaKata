
namespace Model {
    public class Seafood {
        public Seafood(string name, float price)
        {
            Name = name;
            Price = price;
        }

        public string Name { get; set; }
        public float Price { get; set; }
    }
}