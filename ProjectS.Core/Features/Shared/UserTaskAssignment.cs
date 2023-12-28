using Standard.Core.Features.Users;

namespace Standard.Core.Features.Shared;

public class UserTaskAssignment(int userId, User user, int taskId, Task task)
{
	public int UserId { get; set; } = userId;
	public User User { get; set; } = user;

	public int TaskId { get; set; } = taskId;
	public Task Task { get; set; } = task;
}
