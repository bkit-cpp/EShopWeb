using BuildingBlocks.CQRS;
using Catalog.API.Models;

namespace Catalog.API.Products.GetProducts
{
    public record GetProductQuery() : IQuery<GetProductsResult>;
    public record GetProductsResult(IEnumerable<Product> Products);
    public class GetProductQueryHandler(IDocumentSession session, ILogger<GetProductQueryHandler> logger)
    : IQueryHandler<GetProductQuery, GetProductsResult>
    {
        public async Task<GetProductsResult> Handle(GetProductQuery query, CancellationToken cancellationToken)
        {
            logger.LogInformation("GetProductQueryHandle Handle called with {@Query}",query);
            var product = await session.Query<Product>().ToListAsync(cancellationToken);
            return new GetProductsResult(product);
        }
    }
}
