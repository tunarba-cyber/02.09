using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using ProniaModular.Modules.Products.Features.Products.Commands.CreateProduct;
using ProniaModular.Modules.Products.Features.Products.Commands.UpdateProduct;
using ProniaModular.Modules.Products.Features.Products.Commands.DeleteProduct;
using ProniaModular.Modules.Products.Features.Products.Queries.GetProductById;
using ProniaModular.Modules.Products.Features.Products.Queries.GetAllProducts;

namespace ProniaModular.Modules.Products.Endpoints
{
    public static class ProductEndpoints
    {
        public static void MapProductEndpoints(this WebApplication app)
        {
            var group = app.MapGroup("/api/products")
                .WithTags("Products");

            group.MapPost("/", CreateProduct)
                .WithName("CreateProduct")
                .WithOpenApi();

            group.MapPut("/{id}", UpdateProduct)
                .WithName("UpdateProduct")
                .WithOpenApi();

            group.MapDelete("/{id}", DeleteProduct)
                .WithName("DeleteProduct")
                .WithOpenApi();

            group.MapGet("/{id}", GetProductById)
                .WithName("GetProductById")
                .WithOpenApi();

            group.MapGet("/", GetAllProducts)
                .WithName("GetAllProducts")
                .WithOpenApi();
        }

        private static async Task<IResult> CreateProduct(CreateProductCommand command, IMediator mediator)
        {
            var result = await mediator.Send(command);
            return Results.Created($"/api/products/{result.Id}", result);
        }

        private static async Task<IResult> UpdateProduct(long id, UpdateProductCommand command, IMediator mediator)
        {
            var updateCommand = command with { Id = id };
            var result = await mediator.Send(updateCommand);
            return Results.Ok(result);
        }

        private static async Task<IResult> DeleteProduct(long id, IMediator mediator)
        {
            var command = new DeleteProductCommand(id);
            var result = await mediator.Send(command);
            return result.Success ? Results.Ok(result) : Results.NotFound(result);
        }

        private static async Task<IResult> GetProductById(long id, IMediator mediator)
        {
            var query = new GetProductByIdQuery(id);
            var result = await mediator.Send(query);
            return Results.Ok(result);
        }

        private static async Task<IResult> GetAllProducts(IMediator mediator)
        {
            var query = new GetAllProductsQuery();
            var result = await mediator.Send(query);
            return Results.Ok(result);
        }
    }
}
