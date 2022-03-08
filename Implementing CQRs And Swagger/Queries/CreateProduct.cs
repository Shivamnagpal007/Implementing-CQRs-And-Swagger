using Implementing_CQRs_And_Swagger.Data;
using Implementing_CQRs_And_Swagger.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Implementing_CQRs_And_Swagger.Queries
{
    public class CreateProduct : IRequest<bool>
    {
        public string Name { get; set; }
        public string Description { get; set; }    
        public class CreateProductCommandHandler : IRequestHandler<CreateProduct, bool>
        {
            private readonly ApplicationDbContext _context;
            public CreateProductCommandHandler(ApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<bool> Handle(CreateProduct command, CancellationToken cancellationToken)
            {
                var product = new Product();             
                product.Name = command.Name;            
                product.Description = command.Description;
                _context.Products.Add(product);
               await _context.SaveChangesAsync();
                if (product == null)
                    return false;
                return true;
            }
        }
    }
}
