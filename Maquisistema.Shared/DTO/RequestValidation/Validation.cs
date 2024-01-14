using System;
using System.Collections.Generic;
using System.Text;

namespace Maquisistema.Shared.DTO
{
    public class Validation
    {
        public bool IsValid { get; set; }
        public List<ErrorValidation> Errors { get; set; }
        public Validation()
        {
            Errors = new List<ErrorValidation>();
        }
    }
}
