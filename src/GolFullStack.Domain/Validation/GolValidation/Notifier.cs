using System;
using System.Collections.Generic;
using System.Linq;
using GolFullStack.Domain.Validation.GolValidation.Interface;

namespace GolFullStack.Domain.Validation.GolValidation
{
    public class Notifier : INotification
    {
        private List<Notification> _notifications;        public Notifier()        {            _notifications = new List<Notification>();        }        public List<Notification> GetNotification()        {            return _notifications;        }        public void Handle(Notification notification)        {            _notifications.Add(notification);        }        public bool HaveNotification()        {            return _notifications.Any();        }
    }
}
