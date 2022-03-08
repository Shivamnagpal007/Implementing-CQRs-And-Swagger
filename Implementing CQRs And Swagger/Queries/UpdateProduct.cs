using Implementing_CQRs_And_Swagger.Data;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Implementing_CQRs_And_Swagger.Queries
{
    public class UpdateProduct : IRequest<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }     
      public string Description { get; set; }
       
        public class UpdateProductCommandHandler : IRequestHandler<UpdateProduct, int>
        {
            private readonly ApplicationDbContext _context;
            public UpdateProductCommandHandler(ApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<int> Handle(UpdateProduct command, CancellationToken cancellationToken)
            {
                var product = _context.Products.Where(a => a.Id == command.Id).FirstOrDefault();

                if (product == null)
                {
                    return default;
                }
                else
                {
                 
                    product.Name = command.Name;                 
                    product.Description = command.Description;
                    await _context.SaveChangesAsync();
                    return product.Id;
                }
            }
        }
    }
}
