using System.Threading;
using System.Threading.Tasks;
using CqrsMediatrExample.Commands;
using CqrsMediatrExample.DataStore;
using MediatR;

namespace CqrsMediatrExample.Handlers;

public class AddUserHandler : IRequestHandler<AddUserCommand, User>
{
    private readonly FakeDataStore _fakeDataStore;

    public AddUserHandler(FakeDataStore fakeDataStore) => _fakeDataStore = fakeDataStore;

    public async Task<User> Handle(AddUserCommand request, CancellationToken cancellationToken)
    {
        await _fakeDataStore.AddUser(request.User);
        return request.User;
    }
}