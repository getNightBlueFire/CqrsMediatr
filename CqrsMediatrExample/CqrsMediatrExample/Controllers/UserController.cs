using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CqrsMediatrExample.Commands;
using CqrsMediatrExample.DataStore;
using CqrsMediatrExample.Notifications;
using CqrsMediatrExample.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CqrsMediatrExample.Controllers;

[Route("api/users")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly IMediator _mediator;

    public UserController(IMediator mediator) => _mediator = mediator;

    [HttpGet]
    public async Task<ActionResult> GetUsers()
    {
        var users = await _mediator.Send(new GetUsersQuery());

        return Ok(users);
    }

    [HttpGet("{id:int}", Name = "GetUserById")]
    public async Task<ActionResult> GetUserById(int id)
    {
        var user = await _mediator.Send(new GetUserByIdQuery(id));

        return Ok(user);
    }

    [HttpGet("{id:int}/products", Name = "GetProductsByUser")]
    public async Task<ActionResult> GetProductsByUser(int id)
    {
        var user = await _mediator.Send(new GetUserByIdQuery(id));
        var products = new List<Product>();
        foreach (var i in user.List)
        {
            var product = await _mediator.Send(new GetProductByIdQuery(i));
            products.Add(product);
        }

        return Ok(products);
    }

    [HttpGet("{id:int}/products/{userId:int}", Name = "GetProductByUser")]
    public async Task<ActionResult> GetProductByUser(int id, int userId)
    {
        var user = await _mediator.Send(new GetUserByIdQuery(id));
        var products = new List<Product>();
        foreach (var i in user.List)
        {
            var product = await _mediator.Send(new GetProductByIdQuery(i));
            products.Add(product);
        }

        var single = products.Single(p => p.Id == userId);

        return Ok(single);
    }

    [HttpPost]
    public async Task<ActionResult> AddUser([FromBody] User user)
    {
        var userToReturn = await _mediator.Send(new AddUserCommand(user));

        await _mediator.Publish(new UserAddedNotification(userToReturn));

        return CreatedAtRoute("GetUserById", new {id = userToReturn.Id}, userToReturn);
    }

    [HttpDelete]
    public async Task<ActionResult> DeleteUser([FromBody] int userId)
    {
        var userToReturn = await _mediator.Send(new DeleteUserCommand(userId));

        await _mediator.Publish(new UserDeleteNotification(userToReturn));

        return Ok(userToReturn);
    }

    [Authorize(Roles = "A,B")]
    [HttpPut]
    public async Task<ActionResult> UpdateUser([FromBody] User user)
    {
        var send = await _mediator.Send(new UpdateUserCommand(user));
        await _mediator.Publish(new UserUpdateNotification(send));
        return Ok(send);
    }
}