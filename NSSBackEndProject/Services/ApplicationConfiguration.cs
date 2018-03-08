using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NSSBackEndProject.Services
{
    public class ApplicationConfiguration: IApplicationConfiguration
    {
        public string BookAPIKey { get; set; }
    }
}
