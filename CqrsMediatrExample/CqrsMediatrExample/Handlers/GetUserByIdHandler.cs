using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using CqrsMediatrExample.DataStore;
using CqrsMediatrExample.Queries;
using MediatR;

namespace CqrsMediatrExample.Handlers
{
    public class GetUserByIdHandler : IRequestHandler<GetUserByIdQuery, User>
    {
        private readonly FakeDataStore _fakeDataStore;

        public GetUserByIdHandler(FakeDataStore fakeDataStore) => _fakeDataStore = fakeDataStore;

        public async Task<User> Handle(GetUserByIdQuery request, CancellationToken cancellationToken) =>
            await _fakeDataStore.GetUserById(request.Id);
    }
}