using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DependencyInjection.Services;
using DependencyInjection.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DependencyInjection.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly ITestScopedService _scopedService;
        private readonly ITestTransientService _transientService;
        private readonly ITestSingletonService _singletonService;
        private readonly OperationService _operationService;


        public TestController(ITestScopedService scopedService, ITestTransientService transientService, ITestSingletonService singletonService, OperationService operationService)
        {
            _scopedService = scopedService;
            _transientService = transientService;
            _singletonService = singletonService;
            _operationService = operationService;
        }


        [HttpGet]
        public object Get()
        {
            var scoped = this._scopedService.GetGuid();
            var transient = this._transientService.GetGuid();
            var singleton = this._singletonService.GetGuid();
            var guid = this._operationService.GetGuid();
            var result = new
            {
                controller = new
                {
                    scoped = scoped,
                    transient = transient,
                    singleton = singleton
                },
                services = new
                {
                    scoped = guid.scoped,
                    transient = guid.transient,
                    singleton = guid.singleton
                }
            };
            return result;
        }
    }
}