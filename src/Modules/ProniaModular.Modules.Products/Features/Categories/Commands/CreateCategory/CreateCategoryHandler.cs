using MediatR;
using ProniaModular.Modules.Products.Data;
using ProniaModular.Modules.Products.Entities;

namespace ProniaModular.Modules.Products.Features.Categories.Commands.CreateCategory
{
    public class CreateCategoryHandler : IRequestHandler<CreateCategoryCommand, CreateCategoryResponse>
    {
        private readonly ProductsDbContext _context;

        public CreateCategoryHandler(ProductsDbContext context)
        {
            _context = context;
        }

        public async Task<CreateCategoryResponse> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            // Validate Name uniqueness
            var existingCategory = _context.Categories.FirstOrDefault(c => c.Name == request.Name);
            if (existingCategory != null)
            {
                throw new InvalidOperationException($"A category with name '{request.Name}' already exists.");
            }

            var category = new Category { Name = request.Name };

            _context.Categories.Add(category);
            await _context.SaveChangesAsync(cancellationToken);

            return new CreateCategoryResponse(category.Id, category.Name);
        }
    }
}
