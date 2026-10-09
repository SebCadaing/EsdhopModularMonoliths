using MediatR;

namespace Shared.Core.CQRS;

public interface ICommand : ICommand<Unit>
{

}


public interface ICommand<out TResponse> : IRequest<TResponse>
{

}


