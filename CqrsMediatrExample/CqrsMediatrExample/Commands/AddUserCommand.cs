using MediatR;

namespace CqrsMediatrExample.Commands
{
    public record AddUserCommand(User User) : IRequest<User>;
}