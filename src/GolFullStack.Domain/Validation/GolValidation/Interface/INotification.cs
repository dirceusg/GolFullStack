using System;
using System.Collections.Generic;

namespace GolFullStack.Domain.Validation.GolValidation.Interface
{
    public interface INotification
    {
        bool HaveNotification();        List<Notification> GetNotification();        void Handle(Notification notification);
    }
}
