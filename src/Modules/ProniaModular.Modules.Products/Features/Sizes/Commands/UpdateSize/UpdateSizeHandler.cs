using MediatR;
using ProniaModular.Modules.Products.Data;

namespace ProniaModular.Modules.Products.Features.Sizes.Commands.UpdateSize
{
    public class UpdateSizeHandler : IRequestHandler<UpdateSizeCommand, UpdateSizeResponse>
    {
        private readonly ProductsDbContext _context;

        public UpdateSizeHandler(ProductsDbContext context)
        {
            _context = context;
        }

        public async Task<UpdateSizeResponse> Handle(UpdateSizeCommand request, CancellationToken cancellationToken)
        {
            var size = _context.Sizes.FirstOrDefault(s => s.Id == request.Id);
            if (size == null)
            {
                throw new InvalidOperationException($"Size with ID {request.Id} does not exist.");
            }

            // Validate Name uniqueness (excluding current size)
            var existingSize = _context.Sizes.FirstOrDefault(s => s.Name == request.Name && s.Id != request.Id);
            if (existingSize != null)
            {
                throw new InvalidOperationException($"A size with name '{request.Name}' already exists.");
            }

            size.Name = request.Name;
            size.UpdatedAt = DateTime.UtcNow;

            _context.Sizes.Update(size);
            await _context.SaveChangesAsync(cancellationToken);

            return new UpdateSizeResponse(size.Id, size.Name);
        }
    }
}
