using System;
namespace GolFullStack.Domain.Validation.GolValidation
{
    public class Notification
    {
        public Notification(string message)        {            Message = message;        }        public string Message { get; set; }
    }
}
