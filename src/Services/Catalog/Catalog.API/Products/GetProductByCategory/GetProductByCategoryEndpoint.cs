using MediatR;

namespace Catalog.API.Products.GetProductByCategory
{

    public record CreateProductCommand(
        string Name,
        List<string> Category,
        string Description,
        string ImageFile,
        decimal Price) : IRequest<CreateProductResult>;

    public record CreateProductResult(Guid Id);

    internal class GetProductByCategoryEndpoint : IRequestHandler<CreateProductCommand, CreateProductResult>
    {
        public Task<CreateProductResult> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
