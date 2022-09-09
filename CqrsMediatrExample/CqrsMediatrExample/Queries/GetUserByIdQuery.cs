using CqrsMediatrExample.DataStore;
using MediatR;

namespace CqrsMediatrExample.Queries;

public record GetUserByIdQuery(int Id) : IRequest<User>;