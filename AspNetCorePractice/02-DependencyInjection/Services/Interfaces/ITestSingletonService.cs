﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DependencyInjection.Services.Interfaces
{
    public interface ITestSingletonService
    {
        Guid GetGuid();
    }
}
