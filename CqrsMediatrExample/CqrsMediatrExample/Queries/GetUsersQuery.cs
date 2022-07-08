using System.Collections.Generic;
using MediatR;

namespace CqrsMediatrExample.Queries
{
    public record GetUsersQuery() : IRequest<IEnumerable<User>>;
}