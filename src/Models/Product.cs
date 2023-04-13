namespace Demo.Api.Models;

public class Product
{
    public uint Id { get; set; }
    public required string Name { get; set; } = default!;
    public required double Price { get; set; }

    private Product() { }

    public static Product Create(string name, double price)
        => new()
        {
            Name = name,
            Price = price
        };
}
