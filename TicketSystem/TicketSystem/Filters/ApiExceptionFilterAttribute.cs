﻿using TicketSystem.Application.Common.Exceptions;
using TicketSystem.Application.Common.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Serilog;

namespace TicketSystem.API.Filters
{
    public class ApiExceptionFilterAttribute : ExceptionFilterAttribute
    {

        private readonly IDictionary<Type, Action<ExceptionContext>> _exceptionHandlers;

        public ApiExceptionFilterAttribute()
        {
            // Register known exception types and handlers.
            _exceptionHandlers = new Dictionary<Type, Action<ExceptionContext>>
            {
                { typeof(ValidationException), HandleValidationException },
                { typeof(NotFoundException), HandleNotFoundException },
                { typeof(UnauthorizedAccessException), HandleUnauthorizedAccessException },
                { typeof(ForbiddenAccessException), HandleForbiddenAccessException }
            };
        }

        public override void OnException(ExceptionContext context)
        {
            HandleException(context);

            base.OnException(context);
        }

        private void HandleException(ExceptionContext context)
        {
            Type type = context.Exception.GetType();
            if (_exceptionHandlers.ContainsKey(type))
            {
                _exceptionHandlers[type].Invoke(context);
                return;
            }

            if (!context.ModelState.IsValid)
            {
                HandleInvalidModelStateException(context);
                return;
            }

            HandleUnknownException(context);
        }

        private void HandleValidationException(ExceptionContext context)
        {
            var errorDetails = new List<CustomError>();
            if (context.Exception is ValidationException validationException)
            {
                foreach (var (key, value) in validationException.Errors)
                {
                    errorDetails.Add(new CustomError()
                    {
                        ErrorCode = StatusCodes.Status400BadRequest,
                        Title = key,
                        Message = string.Join(" | ", value)
                    });
                }
            }
            else
            {
                errorDetails.Add(new CustomError()
                {
                    ErrorCode = StatusCodes.Status400BadRequest,
                    Title = "One or more validation errors occurred",
                    Message = context.Exception.ToString()
                });
            }

            context.Result = new BadRequestObjectResult(errorDetails);

            context.ExceptionHandled = true;
        }

        private void HandleInvalidModelStateException(ExceptionContext context)
        {
            var errorDetails = new List<CustomError>()
            {
                new()
                {
                    ErrorCode = StatusCodes.Status400BadRequest,
                    Title = "One or more validation errors occurred",
                    Message = string.Join(" | ", context.ModelState.Values
                        .SelectMany(v => v.Errors)
                        .Select(e => e.ErrorMessage))
                }
            };

            context.Result = new BadRequestObjectResult(errorDetails);

            context.ExceptionHandled = true;
        }

        private void HandleNotFoundException(ExceptionContext context)
        {
            var exception = context.Exception as NotFoundException;

            var errorDetails = new List<CustomError>()
            {
                new()
                {
                    ErrorCode = StatusCodes.Status404NotFound,
                    Title = "The specified resource was not found.",
                    Message = exception.Message
                }
            };

            context.Result = new NotFoundObjectResult(errorDetails);

            context.ExceptionHandled = true;
        }

        private void HandleUnauthorizedAccessException(ExceptionContext context)
        {
            var errorDetails = new List<CustomError>()
            {
                new CustomError()
                {
                    ErrorCode = StatusCodes.Status401Unauthorized,
                    Title = "Unauthorized",
                    Message = "You are not Authorized to access"
                }
            };

            context.Result = new ObjectResult(errorDetails)
            {
                StatusCode = StatusCodes.Status401Unauthorized
            };

            context.ExceptionHandled = true;
        }

        private void HandleForbiddenAccessException(ExceptionContext context)
        {

            var errorDetails = new List<CustomError>()
            {
                new()
                {
                    ErrorCode = StatusCodes.Status403Forbidden,
                    Title = "Forbidden",
                    Message = "You are not Authorized to access"
                }
            };

            context.Result = new ObjectResult(errorDetails)
            {
                StatusCode = StatusCodes.Status403Forbidden
            };

            context.ExceptionHandled = true;
        }

        private void HandleUnknownException(ExceptionContext context)
        {
            Log.Error(context.Exception, "Exception Message: {0}", context.Exception.Message);

            var errorDetails = new List<CustomError>()
            {
                new()
                {
                    ErrorCode = StatusCodes.Status500InternalServerError,
                    Title = "An error occurred while processing your request.",
                    Message = context.Exception.Message
                }
            };

            context.Result = new ObjectResult(errorDetails)
            {
                StatusCode = StatusCodes.Status500InternalServerError
            };

            context.ExceptionHandled = true;
        }

    }
}
