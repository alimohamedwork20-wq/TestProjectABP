using Volo.Abp.Modularity;

namespace TestProjectABP;

public abstract class TestProjectABPApplicationTestBase<TStartupModule> : TestProjectABPTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
