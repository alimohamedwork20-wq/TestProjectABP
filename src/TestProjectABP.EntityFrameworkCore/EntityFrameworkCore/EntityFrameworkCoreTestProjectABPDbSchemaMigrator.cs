using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using TestProjectABP.Data;
using Volo.Abp.DependencyInjection;

namespace TestProjectABP.EntityFrameworkCore;

public class EntityFrameworkCoreTestProjectABPDbSchemaMigrator
    : ITestProjectABPDbSchemaMigrator, ITransientDependency
{
    private readonly IServiceProvider _serviceProvider;

    public EntityFrameworkCoreTestProjectABPDbSchemaMigrator(
        IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task MigrateAsync()
    {
        /* We intentionally resolve the TestProjectABPDbContext
         * from IServiceProvider (instead of directly injecting it)
         * to properly get the connection string of the current tenant in the
         * current scope.
         */

        await _serviceProvider
            .GetRequiredService<TestProjectABPDbContext>()
            .Database
            .MigrateAsync();
    }
}
