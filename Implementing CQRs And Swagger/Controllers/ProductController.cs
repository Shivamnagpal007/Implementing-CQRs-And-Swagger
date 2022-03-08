using Implementing_CQRs_And_Swagger.Models;
using Implementing_CQRs_And_Swagger.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Implementing_CQRs_And_Swagger.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _mediator.Send(new GetAllProductsQuery()));
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await _mediator.Send(new GetProductById{ Id = id }));
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateProduct product)
        {
            return Ok(await _mediator.Send(product));
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateProduct product)
        {
            if (id != product.Id)
            {
                return BadRequest();
            }
            return Ok(await _mediator.Send(product));
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await _mediator.Send(new DeleteProduct{ Id = id }));
        }
    }
}
