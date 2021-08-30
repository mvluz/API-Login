using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Login.Models
{
    public class ValidateFieldsModel
    {
        public IEnumerable<string> Errors { get; private set; }

        public ValidateFieldsModel (IEnumerable<string> errors)
        {
            Errors = errors;
        }
    }
}
