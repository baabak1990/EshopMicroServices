﻿using BuildingBlock.CQRS;

namespace Catalog.API.Products.CreateProduct
{
    public record CreateProductCommand(
        string Name,
        List<string> Category,
        string Description,
        string ImageFile,
        decimal Price) : ICommand<CreateProductResult>;
    public record CreateProductResult(Guid Id);


     
    public class CreateProductEndPoint
    {
    }
}
