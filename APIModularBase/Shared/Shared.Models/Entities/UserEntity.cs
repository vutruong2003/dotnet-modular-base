namespace Shared.Models.Entities;

public class UserEntity : BaseEntity
{
    public string UserName { get; set; }
    public string Email { get; set; }

    public string Phone { get; set; }
    public string Address { get; set; }
}
