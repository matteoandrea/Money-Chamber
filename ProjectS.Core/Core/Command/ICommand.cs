namespace ProjectS.Core.Core.Command;

public interface ICommand : IHttpsRequest
{
	void Validate();
}
