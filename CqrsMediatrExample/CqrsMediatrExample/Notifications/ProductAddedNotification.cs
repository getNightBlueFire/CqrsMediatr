﻿using CqrsMediatrExample.DataStore;
using MediatR;

namespace CqrsMediatrExample.Notifications
{
	public record ProductAddedNotification(Product Product) : INotification;
}
