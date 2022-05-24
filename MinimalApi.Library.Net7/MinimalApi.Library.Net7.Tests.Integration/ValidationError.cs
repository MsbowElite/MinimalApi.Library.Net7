using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinimalApi.Library.Net7.Tests.Integration
{
    internal class ValidationError
    {
        public string PropertyName { get; set; } = default!;

        public string ErrorMessage { get; set; } = default!;
    }
}
