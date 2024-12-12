namespace Domain;

public class Indice
{
    public int Id { get; set; }
    public string Name { get; set; }
    public ICollection<Stock> Stocks { get; set; }

    public override string ToString()
    {
        return $"{Name} ({Stocks.Count})";
    }
}