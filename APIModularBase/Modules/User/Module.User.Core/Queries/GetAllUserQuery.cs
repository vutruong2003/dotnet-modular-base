using MediatR;
using Microsoft.EntityFrameworkCore;
using Shared.Core.Contracts;
using Shared.Models.Entities;

namespace Module.User.Core.Queries;

public class GetAllUserQuery : IRequest<List<UserEntity>>
{
}

internal class GetAllUserQueryHandler : IRequestHandler<GetAllUserQuery, List<UserEntity>>
{
    private readonly IModuleDbContext _moduleDbContext;

    public GetAllUserQueryHandler(IModuleDbContext moduleDbContext)
    {
        _moduleDbContext = moduleDbContext;
    }

    public async Task<List<UserEntity>> Handle(GetAllUserQuery request, CancellationToken cancellationToken)
    {
        return await _moduleDbContext.Users.ToListAsync();
    }
}
