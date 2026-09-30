using System.Threading.Tasks;

namespace TestProjectABP.Data;

public interface ITestProjectABPDbSchemaMigrator
{
    Task MigrateAsync();
}
