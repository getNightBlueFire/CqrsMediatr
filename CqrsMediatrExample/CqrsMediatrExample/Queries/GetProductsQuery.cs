using MediatR;
using System.Collections.Generic;
using CqrsMediatrExample.DataStore;

namespace CqrsMediatrExample.Queries
{
	public record GetProductsQuery() : IRequest<IEnumerable<Product>>;
}
