using MediatR;
using ProniaModular.Modules.Products.Data;

namespace ProniaModular.Modules.Products.Features.Categories.Queries.GetCategoryById
{
    public class GetCategoryByIdHandler : IRequestHandler<GetCategoryByIdQuery, GetCategoryByIdResponse>
    {
        private readonly IAppDbContext _context;

        public GetCategoryByIdHandler(IAppDbContext context)
        {
            _context = context;
        }

        public async Task<GetCategoryByIdResponse> Handle(GetCategoryByIdQuery request, CancellationToken cancellationToken)
        {
            var category = _context.Categories.FirstOrDefault(c => c.Id == request.Id && !c.IsDeleted);
            if (category == null)
            {
                throw new InvalidOperationException($"Category with ID {request.Id} not found.");
            }

            return await Task.FromResult(new GetCategoryByIdResponse(category.Id, category.Name));
        }
    }
}