using System;
using System.Threading;
using System.Threading.Tasks;
using CqrsMediatrExample.Commands;
using CqrsMediatrExample.DataStore;
using MediatR;

namespace CqrsMediatrExample.Handlers
{
    public class DeleteUserHandler : IRequestHandler<DeleteUserCommand, int>
    {
        private readonly FakeDataStore _fakeDataStore;

        public DeleteUserHandler(FakeDataStore fakeDataStore) => _fakeDataStore = fakeDataStore;

        public async Task<int> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            await _fakeDataStore.DeleteUser(request.UserId);
            return request.UserId;
        }
    }    
}

