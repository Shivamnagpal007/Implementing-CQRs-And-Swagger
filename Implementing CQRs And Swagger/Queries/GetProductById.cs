using Implementing_CQRs_And_Swagger.Data;
using Implementing_CQRs_And_Swagger.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Implementing_CQRs_And_Swagger.Queries
{
        public class GetProductById : IRequest<Product>
        {
            public int Id { get; set; }
            public class GetProductByIdQueryHandler : IRequestHandler<GetProductById, Product>
            {
                private readonly ApplicationDbContext _context;
                public GetProductByIdQueryHandler(ApplicationDbContext context)
                {
                    _context = context;
                }
                public async Task<Product> Handle(GetProductById query, CancellationToken cancellationToken)
                {
                    var product =await _context.Products.Where(a => a.Id == query.Id).FirstOrDefaultAsync();
                    if (product == null) return null;
                    return product;
                }
            }
        }
  }

