using TestProjectABP.Samples;
using Xunit;

namespace TestProjectABP.EntityFrameworkCore.Domains;

[Collection(TestProjectABPTestConsts.CollectionDefinitionName)]
public class EfCoreSampleDomainTests : SampleDomainTests<TestProjectABPEntityFrameworkCoreTestModule>
{

}
