namespace Shared.Models.Contracts;

public interface IEntity<T>
{
    T Id { get; }
}

public interface IEntity : IEntity<Guid>
{
}

public interface IAuditable
{
    DateTime? UpdatedOnUtc { get; set; }

    Guid? UpdatedBy { get; set; }

    DateTime CreatedOnUtc { get; set; }

    Guid? CreatedBy { get; set; }
}

public interface IDeletable
{
    DateTime? DeletedTime { get; set; }
}
