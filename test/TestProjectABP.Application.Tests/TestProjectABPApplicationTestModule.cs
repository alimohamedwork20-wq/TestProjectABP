using Volo.Abp.Modularity;

namespace TestProjectABP;

[DependsOn(
    typeof(TestProjectABPApplicationModule),
    typeof(TestProjectABPDomainTestModule)
)]
public class TestProjectABPApplicationTestModule : AbpModule
{

}
