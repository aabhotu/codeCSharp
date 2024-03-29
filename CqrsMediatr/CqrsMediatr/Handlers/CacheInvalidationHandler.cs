﻿using CqrsMediatr.DataStore;
using CqrsMediatr.Notifications;
using MediatR;

namespace CqrsMediatr.Handlers
{
    public class CacheInvalidationHandler : INotificationHandler<ProductAddedNotification>
    {
        private readonly FakeDataStore _fakeDataStore;
        public CacheInvalidationHandler(FakeDataStore fakeDataStore)
        {
            _fakeDataStore = fakeDataStore;
        }
        public async Task Handle(ProductAddedNotification notification, CancellationToken cancellationToken)
        {
            await _fakeDataStore.EventOccured(notification.product, "Cache Invalidate");
            await Task.CompletedTask;
        }
    }
}
