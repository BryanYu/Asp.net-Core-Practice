using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DependencyInjection.Services.Interfaces;

namespace DependencyInjection.Services
{
    public class TestScopedService : ITestScopedService
    {
        private readonly Guid _guid;
        public TestScopedService()
        {
            this._guid = Guid.NewGuid();
        }
        public Guid GetGuid()
        {
            return this._guid;
        }
    }
}
