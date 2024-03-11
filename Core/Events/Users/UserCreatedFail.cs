namespace Core.Events.Users;

public class UserCreatedFail(Guid userId)
{
    public Guid UserId { get; init; } = userId;
}
