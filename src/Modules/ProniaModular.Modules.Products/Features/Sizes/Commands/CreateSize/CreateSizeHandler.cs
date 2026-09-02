using MediatR;
using ProniaModular.Modules.Products.Data;
using ProniaModular.Modules.Products.Entities;

namespace ProniaModular.Modules.Products.Features.Sizes.Commands.CreateSize
{
    public class CreateSizeHandler : IRequestHandler<CreateSizeCommand, CreateSizeResponse>
    {
        private readonly ProductsDbContext _context;

        public CreateSizeHandler(ProductsDbContext context)
        {
            _context = context;
        }

        public async Task<CreateSizeResponse> Handle(CreateSizeCommand request, CancellationToken cancellationToken)
        {
            // Validate Name uniqueness
            var existingSize = _context.Sizes.FirstOrDefault(s => s.Name == request.Name);
            if (existingSize != null)
            {
                throw new InvalidOperationException($"A size with name '{request.Name}' already exists.");
            }

            var size = new Size { Name = request.Name };

            _context.Sizes.Add(size);
            await _context.SaveChangesAsync(cancellationToken);

            return new CreateSizeResponse(size.Id, size.Name);
        }
    }
}
