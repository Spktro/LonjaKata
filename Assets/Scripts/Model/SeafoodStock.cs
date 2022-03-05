namespace Model
{
    public class SeafoodStock
    {
        public Seafood Seafood { get; set; }
        public float KilosSupplies { get; set; }

        public SeafoodStock(Seafood seafood, float kilosSupplies) {
            this.Seafood = seafood;
            this.KilosSupplies = kilosSupplies;
        }
    }
}