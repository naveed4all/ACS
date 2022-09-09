using Radzen;
using System;

namespace ACS.Helpers
{
    public class NotificationHelper
    {
        private readonly NotificationService _NotificationService;

        public NotificationHelper(NotificationService NotificationService)
        {
            _NotificationService = NotificationService;
        }
        public void Message(NotificationSeverity type, string Title, string Message)
        {
            var msg = new NotificationMessage
            {
                Severity = type,
                Summary = Title,
                Detail = Message,
                Duration = 4000
            };

            _NotificationService.Notify(msg);

        }
    }
}
