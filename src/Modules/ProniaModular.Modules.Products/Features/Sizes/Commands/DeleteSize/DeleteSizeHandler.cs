using MediatR;
using ProniaModular.Modules.Products.Data;

namespace ProniaModular.Modules.Products.Features.Sizes.Commands.DeleteSize
{
    public class DeleteSizeHandler : IRequestHandler<DeleteSizeCommand, DeleteSizeResponse>
    {
        private readonly IAppDbContext _context;

        public DeleteSizeHandler(IAppDbContext context)
        {
            _context = context;
        }

        public async Task<DeleteSizeResponse> Handle(DeleteSizeCommand request, CancellationToken cancellationToken)
        {
            var size = _context.Sizes.FirstOrDefault(s => s.Id == request.Id);
            if (size == null)
            {
                return new DeleteSizeResponse(false, $"Size with ID {request.Id} does not exist.");
            }

            _context.Sizes.Remove(size);
            await _context.SaveChangesAsync(cancellationToken);

            return new DeleteSizeResponse(true, "Size deleted successfully.");
        }
    }
}