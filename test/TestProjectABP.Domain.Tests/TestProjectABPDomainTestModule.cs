using Volo.Abp.Modularity;

namespace TestProjectABP;

[DependsOn(
    typeof(TestProjectABPDomainModule),
    typeof(TestProjectABPTestBaseModule)
)]
public class TestProjectABPDomainTestModule : AbpModule
{

}
