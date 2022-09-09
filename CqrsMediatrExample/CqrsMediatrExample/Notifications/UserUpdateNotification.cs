using CqrsMediatrExample.DataStore;
using MediatR;

namespace CqrsMediatrExample.Notifications;

public record UserUpdateNotification(User User) : INotification;