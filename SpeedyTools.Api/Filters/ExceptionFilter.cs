﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using SpeedyTools.Api.Contracts;
using SpeedyTools.Api.Contracts.Responses;

namespace SpeedyTools.Api.Filters
{
    public class ExceptionFilter : IExceptionFilter
    {
        private readonly ILogger<ExceptionFilter> _logger;

        public ExceptionFilter(ILogger<ExceptionFilter> logger)
        {
            _logger = logger;
        }

        public void OnException(ExceptionContext context)
        {
            _logger.LogError(context.Exception.StackTrace);
            var error = new Error
            {
                StatusCode = "500",
                Message = context.Exception.Message,
            };

            context.Result = new JsonResult(error) { StatusCode = 500 };
        }
    }
}