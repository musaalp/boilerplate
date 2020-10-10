using System;
using System.Collections.Generic;
using System.Text;

namespace App.Infrustructure.RabbitMQ
{
    public class RabbitMQConstants
    {
        public const string NotificationExchangeName = "Notification_Exchange";
        public const string NotificationQueueName = "Notification_Queue";
        public const string NotificationRouteKey = "Notification_RouteKey";
    }
}
