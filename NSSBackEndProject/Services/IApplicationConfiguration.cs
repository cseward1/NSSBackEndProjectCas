using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NSSBackEndProject.Services
{
    public interface IApplicationConfiguration
    {
        string BookAPIKey { get; set; }
    }
}
