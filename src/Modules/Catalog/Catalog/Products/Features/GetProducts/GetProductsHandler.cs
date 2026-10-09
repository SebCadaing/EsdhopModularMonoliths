namespace Catalog.Products.Features.GetProducts;


public record GetProductsQuery() : IQuery<GetProductResult>;
public record GetProductResult(IEnumerable<ProductDto> Products);

internal class GetProductsHandler(CatalogDbContext dbContext) : IQueryHandler<GetProductsQuery, GetProductResult>
{
    public async Task<GetProductResult> Handle(GetProductsQuery query, CancellationToken cancellationToken)
    {
        //get products using dbcontext
        //return result

        var products = await dbContext.Products
            .AsNoTracking()
            .OrderBy(p => p.Name)
            .ToListAsync(cancellationToken);

        //mapping produtc entity to product dto using Mapster
        var productDtos = products.Adapt<List<ProductDto>>();

        return new GetProductResult(productDtos);
    }

    
}
