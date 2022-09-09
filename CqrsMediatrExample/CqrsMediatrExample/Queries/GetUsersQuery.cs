using System.Collections.Generic;
using CqrsMediatrExample.DataStore;
using MediatR;

namespace CqrsMediatrExample.Queries
{
    public record GetUsersQuery() : IRequest<IEnumerable<User>>;
}