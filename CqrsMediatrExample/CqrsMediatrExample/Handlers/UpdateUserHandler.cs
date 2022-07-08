using System.Threading;
using System.Threading.Tasks;
using CqrsMediatrExample.Commands;
using CqrsMediatrExample.DataStore;
using MediatR;

namespace CqrsMediatrExample.Handlers;

public class UpdateUserHandler : IRequestHandler<UpdateUserCommand, User>
{
    private readonly FakeDataStore _fakeDataStore;

    public UpdateUserHandler(FakeDataStore fakeDataStore)
    {
        _fakeDataStore = fakeDataStore;
    }

    public async Task<User> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
    {
        await _fakeDataStore.DeleteUser(request.User.Id);
        await _fakeDataStore.AddUser(request.User);
        return request.User;
    }
}