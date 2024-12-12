namespace Domain;

public class Stock
{
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public int Quantity { get; set; }
    public decimal TotalWorth => Price * Quantity;


    public override string ToString()
    {
        return $"{Name}: {TotalWorth}, Metadata: id: {Id}, Price: {Price}, Quantity: {Quantity}";
    }
}