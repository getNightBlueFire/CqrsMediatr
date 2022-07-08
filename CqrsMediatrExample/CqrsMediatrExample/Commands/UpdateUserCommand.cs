using MediatR;

namespace CqrsMediatrExample.Commands;

public record UpdateUserCommand(User User) : IRequest<User>;
