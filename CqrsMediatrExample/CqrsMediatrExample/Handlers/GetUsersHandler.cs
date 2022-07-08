using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using CqrsMediatrExample.DataStore;
using CqrsMediatrExample.Queries;
using MediatR;

namespace CqrsMediatrExample.Handlers
{
    public class GetUsersHandler : IRequestHandler<GetUsersQuery, IEnumerable<User>>
    {
        private readonly FakeDataStore _fakeDataStore;

        public GetUsersHandler(FakeDataStore fakeDataStore) => _fakeDataStore = fakeDataStore;

        public async Task<IEnumerable<User>> Handle(GetUsersQuery request,
            CancellationToken cancellationToken) => await _fakeDataStore.GetAllUsers();
    }
}