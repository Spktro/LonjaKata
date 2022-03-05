public class SeafoodStockDTO
{
    public string SeafoodName { get; }
    public float Stock { get; }

    public SeafoodStockDTO(string seafoodName, float stock)
    {
        SeafoodName = seafoodName;
        Stock = stock;
    }
}