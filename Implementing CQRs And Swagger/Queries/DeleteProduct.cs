using Implementing_CQRs_And_Swagger.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Implementing_CQRs_And_Swagger.Queries
{
    public class DeleteProduct : IRequest<bool>
    {
        public int Id { get; set; }
        public class DeleteProductByIdCommandHandler : IRequestHandler<DeleteProduct, bool>
        {
            private readonly ApplicationDbContext _context;
            public DeleteProductByIdCommandHandler(ApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<bool> Handle(DeleteProduct command, CancellationToken cancellationToken)
            {
                var product = await _context.Products.Where(a => a.Id == command.Id).FirstOrDefaultAsync();
                if (product == null) 
                    return default;
                _context.Products.Remove(product);
                await _context.SaveChangesAsync();
                return true;
            }
        }
    }
}
