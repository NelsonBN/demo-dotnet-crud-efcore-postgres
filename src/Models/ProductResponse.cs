namespace Demo.Api.Models;

public record ProductResponse(uint Id, string Name, double Price)
{
    public static implicit operator ProductResponse(Product product)
        => new(product.Id,
            product.Name,
            product.Price);
}
