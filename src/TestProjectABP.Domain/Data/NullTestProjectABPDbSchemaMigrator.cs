using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace TestProjectABP.Data;

/* This is used if database provider does't define
 * ITestProjectABPDbSchemaMigrator implementation.
 */
public class NullTestProjectABPDbSchemaMigrator : ITestProjectABPDbSchemaMigrator, ITransientDependency
{
    public Task MigrateAsync()
    {
        return Task.CompletedTask;
    }
}
