using MediatR;

namespace CqrsMediatrExample.Commands
{
    public record DeleteUserCommand(int UserId) : IRequest<int>;
}