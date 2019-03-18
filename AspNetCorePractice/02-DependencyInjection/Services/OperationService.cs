using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DependencyInjection.Services.Interfaces;

namespace DependencyInjection.Services
{
    public class OperationService
    {
        private readonly ITestScopedService _scopedService;
        private readonly ITestTransientService _transientService;
        private readonly ITestSingletonService _singletonService;

        public OperationService(ITestScopedService scopedService, ITestTransientService transientService, ITestSingletonService singletonService)
        {
            _scopedService = scopedService;
            _transientService = transientService;
            _singletonService = singletonService;
        }

        public (Guid scoped, Guid transient, Guid singleton) GetGuid()
        {
            return (this._scopedService.GetGuid(), this._transientService.GetGuid(), this._singletonService.GetGuid());
        }
    }
}
