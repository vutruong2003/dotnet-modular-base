using Shared.Common.DependencyInjection.Attributes;
using Shared.Core.Contracts.Fakers;
using Shared.Infrastructures.Fakers;
using Shared.Models.Entities;

namespace Module.User.Infrastructure.Fakers;

[SingletonDependency<IBaseFaker<UserEntity>>]
internal class UserFaker : EntityFaker<UserEntity>
{
    protected override void InitFaker(params object?[]? args)
    {
        base.InitFaker(args);

        FakerInstance.RuleFor(field => field.Email, m => m.Person.Email)
            .RuleFor(field => field.Phone, m => m.Person.Phone)
            .RuleFor(field => field.Address, m => m.Address.FullAddress())
            .RuleFor(field => field.UserName, m => m.Person.UserName)
            ;
    }
}
