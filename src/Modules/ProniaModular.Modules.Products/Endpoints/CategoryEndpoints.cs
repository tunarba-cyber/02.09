using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using ProniaModular.Modules.Products.Features.Categories.Commands.CreateCategory;
using ProniaModular.Modules.Products.Features.Categories.Commands.UpdateCategory;
using ProniaModular.Modules.Products.Features.Categories.Commands.DeleteCategory;
using ProniaModular.Modules.Products.Features.Categories.Queries.GetCategoryById;
using ProniaModular.Modules.Products.Features.Categories.Queries.GetAllCategories;

namespace ProniaModular.Modules.Products.Endpoints
{
    public static class CategoryEndpoints
    {
        public static void MapCategoryEndpoints(this WebApplication app)
        {
            var group = app.MapGroup("/api/categories")
                .WithTags("Categories");

            group.MapPost("/", CreateCategory)
                .WithName("CreateCategory")
                .WithOpenApi();

            group.MapPut("/{id}", UpdateCategory)
                .WithName("UpdateCategory")
                .WithOpenApi();

            group.MapDelete("/{id}", DeleteCategory)
                .WithName("DeleteCategory")
                .WithOpenApi();

            group.MapGet("/{id}", GetCategoryById)
                .WithName("GetCategoryById")
                .WithOpenApi();

            group.MapGet("/", GetAllCategories)
                .WithName("GetAllCategories")
                .WithOpenApi();
        }

        private static async Task<IResult> CreateCategory(CreateCategoryCommand command, IMediator mediator)
        {
            var result = await mediator.Send(command);
            return Results.Created($"/api/categories/{result.Id}", result);
        }

        private static async Task<IResult> UpdateCategory(long id, UpdateCategoryCommand command, IMediator mediator)
        {
            var updateCommand = command with { Id = id };
            var result = await mediator.Send(updateCommand);
            return Results.Ok(result);
        }

        private static async Task<IResult> DeleteCategory(long id, IMediator mediator)
        {
            var command = new DeleteCategoryCommand(id);
            var result = await mediator.Send(command);
            return result.Success ? Results.Ok(result) : Results.NotFound(result);
        }

        private static async Task<IResult> GetCategoryById(long id, IMediator mediator)
        {
            var query = new GetCategoryByIdQuery(id);
            var result = await mediator.Send(query);
            return Results.Ok(result);
        }

        private static async Task<IResult> GetAllCategories(IMediator mediator)
        {
            var query = new GetAllCategoriesQuery();
            var result = await mediator.Send(query);
            return Results.Ok(result);
        }
    }
}
