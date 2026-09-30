using Volo.Abp.Modularity;

namespace TestProjectABP;

/* Inherit from this class for your domain layer tests. */
public abstract class TestProjectABPDomainTestBase<TStartupModule> : TestProjectABPTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
