using MediatR;
using Shared.Core.Contracts;
using Shared.Core.Contracts.Fakers;
using Shared.Models.Entities;

namespace Module.User.Core.Commands;
public class GenerateUserCommand : IRequest
{
    public int Amount { get; set; }
}

internal class GenerateUserCommandHandler : IRequestHandler<GenerateUserCommand>
{
    private readonly IBaseFaker<UserEntity> _userFaker;
    private readonly IModuleDbContext _dbContext;

    public GenerateUserCommandHandler(IBaseFaker<UserEntity> userFaker, IModuleDbContext dbContext)
    {
        _userFaker = userFaker;
        _dbContext = dbContext;
    }

    public async Task Handle(GenerateUserCommand request, CancellationToken cancellationToken)
    {
        var users = _userFaker.Generate(request.Amount);

        await _dbContext.Users.AddRangeAsync(users, cancellationToken);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }
}
