using Model;

public static class SeafoodStockDTOAdapter
{    

    public static SeafoodStock SeafoodStockDTOToSeafoodStock(SeafoodStockDTO seafoodStockDTO)
    {
        return new SeafoodStock(new Seafood(seafoodStockDTO.SeafoodName),seafoodStockDTO.Stock);
    }

}
