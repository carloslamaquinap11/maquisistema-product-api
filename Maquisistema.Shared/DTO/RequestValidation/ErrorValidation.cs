using System;
using System.Collections.Generic;
using System.Text;

namespace Maquisistema.Shared.DTO
{
    public class ErrorValidation
    {
        public string Message { get; set; }
        public ErrorValidation(string message)
        {
            Message = message;
        }
    }
}
