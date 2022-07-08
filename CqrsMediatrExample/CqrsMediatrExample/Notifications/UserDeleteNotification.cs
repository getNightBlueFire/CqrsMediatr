using MediatR;

namespace CqrsMediatrExample.Notifications;

public record UserDeleteNotification(int UserId) : INotification;
