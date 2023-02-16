using Bogus;
using Shared.Core.Contracts.Fakers;

namespace Shared.Infrastructures.Fakers;
public abstract class BaseFaker<T> : IBaseFaker<T> where T : class
{
    protected static Faker<T> FakerInstance { get; set; } = null!;

    public BaseFaker()
    {
        InitFaker();
    }

    public virtual T Generate(params object?[]? args) => FakerInstance.Generate();

    public virtual List<T> Generate(int count, params object?[]? args) => FakerInstance.Generate(count);

    protected virtual void InitFaker(params object?[]? args)
    {
        FakerInstance = new Faker<T>();
    }
}