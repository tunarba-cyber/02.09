using MediatR;
using ProniaModular.Modules.Products.Data;

namespace ProniaModular.Modules.Products.Features.Sizes.Queries.GetSizeById
{
    public class GetSizeByIdHandler : IRequestHandler<GetSizeByIdQuery, GetSizeByIdResponse>
    {
        private readonly IAppDbContext _context;

        public GetSizeByIdHandler(IAppDbContext context)
        {
            _context = context;
        }

        public async Task<GetSizeByIdResponse> Handle(GetSizeByIdQuery request, CancellationToken cancellationToken)
        {
            var size = _context.Sizes.FirstOrDefault(s => s.Id == request.Id && !s.IsDeleted);
            if (size == null)
            {
                throw new InvalidOperationException($"Size with ID {request.Id} not found.");
            }

            return await Task.FromResult(new GetSizeByIdResponse(size.Id, size.Name));
        }
    }
}