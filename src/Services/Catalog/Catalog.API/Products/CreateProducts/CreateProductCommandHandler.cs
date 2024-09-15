
using BuildingBlocks.CQRS;
using Catalog.API.Models;
using Marten;
using MediatR;
using System.Windows.Input;

namespace Catalog.API.Products.CreateProducts
{
    public record CreateProductCommand(string Name, List<string>Category,string Description,string ImageFile, decimal Price)
        :ICommand<CreateProductResult>;
    public record CreateProductResult(Guid Id);
    public class CreateProductCommandHandler(IDocumentSession session) : ICommandHandler<CreateProductCommand, CreateProductResult>
    {
        
        public async  Task<CreateProductResult> Handle(CreateProductCommand command, CancellationToken cancellationToken)
        {
            var product = new Product()
            {
           Category=command.Category,
           Description=command.Description,
           ImageFile=command.ImageFile,
           Price=command.Price,
           Name=command.Name
            };
            session.Store(product);
            await session.SaveChangesAsync(cancellationToken);
            return new CreateProductResult(product.Id);
        }
    }
}
