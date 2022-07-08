using MediatR;

namespace CqrsMediatrExample.Notifications;

public record UserAddedNotification(User User) : INotification;
