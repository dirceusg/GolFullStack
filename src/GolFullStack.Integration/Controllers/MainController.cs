using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GolFullStack.Domain.Validation.GolValidation;
using GolFullStack.Domain.Validation.GolValidation.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace GolFullStack.Integration.Controllers
{

    [ApiController]
    public abstract class MainController : ControllerBase
    {
        private readonly INotification _notify;

        public MainController(INotification notify)
        {
            _notify = notify;
        }

        protected bool OperationIsValid()
        {
            return !_notify.HaveNotification();
        }

        protected ActionResult CustomResponse(object result = null)
        {
            if (OperationIsValid())
            {
                return Ok(new
                {
                    success = true,
                    errors = "",
                    data = result
                });
            }

            return BadRequest(new
            {
                success = false,
                errors = _notify.GetNotification().Select(x => x.Message),
                data = ""
            });
        }

        protected ActionResult CustomReponse(ModelStateDictionary modelState)
        {
            if (!modelState.IsValid) NotifyInvalidModelError(modelState);
            return CustomResponse();
        }

        protected void NotifyInvalidModelError(ModelStateDictionary modelState)
        {
            var errors = modelState.Values.SelectMany(e => e.Errors);
            foreach (var error in errors)
            {
                var errorMessage = error.Exception == null ? error.ErrorMessage : error.Exception.Message;
                NotifyError(errorMessage);
            }
        }

        protected void NotifyError(string message)
        {
            _notify.Handle(new Notification(message));
        }

    }
}
