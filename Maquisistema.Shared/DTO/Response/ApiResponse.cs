using System;
using System.Collections.Generic;
using System.Text;

namespace Maquisistema.Shared.DTO
{
    public class ApiResponse
    {
        public string Message { get; set; }
        public object Data { get; set; }
        public ApiResponse()
        {
            Data = new Object();
        }
    }
}
