using Application.Response;
using MediatR;

namespace Application.Features.Queries
{
    public class GetProductQuery : IRequest<ApiResponse<Product>>
    {
        internal class GetProductQueryHandler : IRequestHandler<GetProductQuery, ApiResponse<Product>>
        {
            public async Task<ApiResponse<Product>> Handle(GetProductQuery request, CancellationToken cancellationToken)
            {
                var product = new Product
                {
                    Id = 1,
                    Name = "Product 1",
                    Description = "This is product 1",
                    Price = 100
                };
                return new ApiResponse<Product>(product, "Data is fethced");
            }
        }
    }

    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
    }
}
