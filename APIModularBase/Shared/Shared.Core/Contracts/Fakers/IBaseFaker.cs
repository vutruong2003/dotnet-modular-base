namespace Shared.Core.Contracts.Fakers;

public interface IBaseFaker<T> where T : class
{
    T Generate(params object?[]? args);

    List<T> Generate(int count, params object?[]? args);
}
