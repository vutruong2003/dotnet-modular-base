using MediatR;
using Microsoft.AspNetCore.Mvc;
using Module.User.Core.Commands;
using Module.User.Core.Queries;
using Module.User.Models;

namespace Module.User.Controllers;
[ApiController]
[Route("[Controller]")]
public class UserController : ControllerBase
{
    private readonly IMediator _mediator;

    public UserController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> Get(CancellationToken cancellationToken = default)
    {
        var user = await _mediator.Send(new GetAllUserQuery(), cancellationToken);

        return Ok(user);
    }

    [HttpPost]
    public async Task<IActionResult> Generate(GenerateUserModel model, CancellationToken cancellationToken = default)
    {
        await _mediator.Send(new GenerateUserCommand
        {
            Amount = model.Amount
        });

        return Ok();
    }
}
