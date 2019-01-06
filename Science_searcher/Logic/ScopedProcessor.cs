using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Science_searcher.Logic
{
    public abstract class ScopedProcessor: BackgroundService
    {
        private readonly IServiceScopeFactory _serviceScopeFactory;

        public ScopedProcessor(IServiceScopeFactory serviceScopeFactory) : base()
        {
            _serviceScopeFactory = serviceScopeFactory;
        }

        //public override async Task Process()
        //{
        //    using (var scope = _serviceScopeFactory.CreateScope())
        //    {
        //        await ProcessInScope(scope.ServiceProvider);
        //    }
        //}

        public abstract Task ProcessInScope(IServiceProvider serviceProvider);
    }
}
