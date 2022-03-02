namespace Model
{
    public class SeafoodStock
    {
        public Seafood Seafood { get; set; }
        public int Amount { get; set; }

        public SeafoodStock(Seafood seafood, int amount) {
            this.Seafood = seafood;
            this.Amount = amount;
        }
    }
}