using TestProjectABP.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;

namespace TestProjectABP.DbMigrator;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(TestProjectABPEntityFrameworkCoreModule),
    typeof(TestProjectABPApplicationContractsModule)
    )]
public class TestProjectABPDbMigratorModule : AbpModule
{
}
