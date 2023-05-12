﻿using System.Text.Json;

namespace SpeedyTools.Api.Contracts.Responses
{
    public class Error
    {
        public string? StatusCode { get; set; }
        public string? Message { get; set; }


        public override string ToString()
        {
            return JsonSerializer.Serialize(this);
        }
    }
}
