using System;
using FluentValidation;
using FluentValidation.Results;
using GolFullStack.Domain.Validation.GolValidation;
using GolFullStack.Domain.Validation.GolValidation.Interface;

namespace GolFullStack.Domain.Service.Service
{
    public class BaseService
    {
        private INotification _notifier;

        public BaseService(INotification notifier)
        {
            _notifier = notifier;
        }


        protected void Notify(ValidationResult validationResult)        {            foreach (var error in validationResult.Errors)            {                Notify(error.ErrorMessage);            }        }        protected void Notify(string mensagem)        {            _notifier.Handle(new Notification(mensagem));        }        protected bool ExecuteValidation<TV, TE>(TV validation, TE entity) where TV : AbstractValidator<TE> where TE : Entity.Entities.Entity        {            var validator = validation.Validate(entity);            if (validator.IsValid) return true;            Notify(validator);            return false;        }
    }
}
