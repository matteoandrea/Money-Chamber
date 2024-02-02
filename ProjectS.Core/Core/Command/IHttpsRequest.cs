using MediatR;

namespace ProjectS.Core.Core.Command;

public interface IHttpsRequest : IRequest<GenericCommandResult>
{
}
