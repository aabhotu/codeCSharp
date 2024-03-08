using CqrsMediatr.DataStore;
using CqrsMediatr.Notifications;
using MediatR;

namespace CqrsMediatr.Handlers
{
    public class EmailHandler : INotificationHandler<ProductAddedNotification>
    {
        private readonly FakeDataStore _fakeDataStore;
        public EmailHandler(FakeDataStore fakeDataStore) 
            => _fakeDataStore = fakeDataStore;
        public async Task Handle(ProductAddedNotification notification, CancellationToken cancellationToken)
        {
            await _fakeDataStore.EventOccured(notification.product, "Send mail");
            await Task.CompletedTask;
        }
    }
}
