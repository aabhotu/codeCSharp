﻿using CqrsMediatr.Commands;
using CqrsMediatr.Notifications;
using CqrsMediatr.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CqrsMediatr.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ProductsController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<ActionResult> GetProducts()
        {
            var products = await _mediator.Send(new GetProductsQuery());
            return Ok(products);
        }
        [HttpPost]
        public async Task<ActionResult> AddProduct([FromBody] Product product)
        {
            var productToReturn = await _mediator.Send(new AddProductCommand(product));
            await _mediator.Publish(new ProductAddedNotification(productToReturn));
            return CreatedAtRoute("GetProductById", new {id =  productToReturn.Id}, productToReturn);
        }
        [HttpGet("{id:int}", Name = "GetProductById")]
        public async Task<ActionResult> GetProductById(int id)
        {
            var product = await _mediator.Send(new GetProductByIdQuery(id));
            return Ok(product);
        }
        [HttpPut("{id:int}")]
        public async Task<ActionResult> UpdateProduct([FromBody] Product product)
        {
            var productUp = await _mediator.Send(new UpdateProductCommand(product));
            return Ok(productUp);
        } 
    }
}
