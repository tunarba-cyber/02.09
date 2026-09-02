using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using ProniaModular.Modules.Products.Features.Sizes.Commands.CreateSize;
using ProniaModular.Modules.Products.Features.Sizes.Commands.UpdateSize;
using ProniaModular.Modules.Products.Features.Sizes.Commands.DeleteSize;
using ProniaModular.Modules.Products.Features.Sizes.Queries.GetSizeById;
using ProniaModular.Modules.Products.Features.Sizes.Queries.GetAllSizes;

namespace ProniaModular.Modules.Products.Endpoints
{
    public static class SizeEndpoints
    {
        public static void MapSizeEndpoints(this WebApplication app)
        {
            var group = app.MapGroup("/api/sizes")
                .WithTags("Sizes");

            group.MapPost("/", CreateSize)
                .WithName("CreateSize")
                .WithOpenApi();

            group.MapPut("/{id}", UpdateSize)
                .WithName("UpdateSize")
                .WithOpenApi();

            group.MapDelete("/{id}", DeleteSize)
                .WithName("DeleteSize")
                .WithOpenApi();

            group.MapGet("/{id}", GetSizeById)
                .WithName("GetSizeById")
                .WithOpenApi();

            group.MapGet("/", GetAllSizes)
                .WithName("GetAllSizes")
                .WithOpenApi();
        }

        private static async Task<IResult> CreateSize(CreateSizeCommand command, IMediator mediator)
        {
            var result = await mediator.Send(command);
            return Results.Created($"/api/sizes/{result.Id}", result);
        }

        private static async Task<IResult> UpdateSize(long id, UpdateSizeCommand command, IMediator mediator)
        {
            var updateCommand = command with { Id = id };
            var result = await mediator.Send(updateCommand);
            return Results.Ok(result);
        }

        private static async Task<IResult> DeleteSize(long id, IMediator mediator)
        {
            var command = new DeleteSizeCommand(id);
            var result = await mediator.Send(command);
            return result.Success ? Results.Ok(result) : Results.NotFound(result);
        }

        private static async Task<IResult> GetSizeById(long id, IMediator mediator)
        {
            var query = new GetSizeByIdQuery(id);
            var result = await mediator.Send(query);
            return Results.Ok(result);
        }

        private static async Task<IResult> GetAllSizes(IMediator mediator)
        {
            var query = new GetAllSizesQuery();
            var result = await mediator.Send(query);
            return Results.Ok(result);
        }
    }
}
