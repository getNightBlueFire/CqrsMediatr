using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CqrsMediatrExample.DataStore;

namespace CqrsMediatrExample.Queries
{
	public record GetProductByIdQuery(int Id) : IRequest<Product>;
}
