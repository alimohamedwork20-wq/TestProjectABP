using TestProjectABP.Samples;
using Xunit;

namespace TestProjectABP.EntityFrameworkCore.Applications;

[Collection(TestProjectABPTestConsts.CollectionDefinitionName)]
public class EfCoreSampleAppServiceTests : SampleAppServiceTests<TestProjectABPEntityFrameworkCoreTestModule>
{

}
