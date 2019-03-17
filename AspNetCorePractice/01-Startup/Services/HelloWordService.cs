using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Startup.Services
{
    public class HelloWordService
    {
        public string HelloWord()
        {
            return "Hello Word From " + nameof(HelloWordService);
        }
    }
}
