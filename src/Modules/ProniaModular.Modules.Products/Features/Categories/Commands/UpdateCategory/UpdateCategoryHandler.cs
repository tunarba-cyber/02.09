using MediatR;
using ProniaModular.Modules.Products.Data;

namespace ProniaModular.Modules.Products.Features.Categories.Commands.UpdateCategory
{
    public class UpdateCategoryHandler : IRequestHandler<UpdateCategoryCommand, UpdateCategoryResponse>
    {
        private readonly ProductsDbContext _context;

        public UpdateCategoryHandler(ProductsDbContext context)
        {
            _context = context;
        }

        public async Task<UpdateCategoryResponse> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = _context.Categories.FirstOrDefault(c => c.Id == request.Id);
            if (category == null)
            {
                throw new InvalidOperationException($"Category with ID {request.Id} does not exist.");
            }

            // Validate Name uniqueness (excluding current category)
            var existingCategory = _context.Categories.FirstOrDefault(c => c.Name == request.Name && c.Id != request.Id);
            if (existingCategory != null)
            {
                throw new InvalidOperationException($"A category with name '{request.Name}' already exists.");
            }

            category.Name = request.Name;
            category.UpdatedAt = DateTime.UtcNow;

            _context.Categories.Update(category);
            await _context.SaveChangesAsync(cancellationToken);

            return new UpdateCategoryResponse(category.Id, category.Name);
        }
    }
}
