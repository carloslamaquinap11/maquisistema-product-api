using System;
using System.Collections.Generic;
using System.Text;

namespace Maquisistema.Shared.DTO
{
    public interface IRequestValidation
    {
        bool IsValid();
        IEnumerable<ErrorValidation> GetErrors();
    }
}
