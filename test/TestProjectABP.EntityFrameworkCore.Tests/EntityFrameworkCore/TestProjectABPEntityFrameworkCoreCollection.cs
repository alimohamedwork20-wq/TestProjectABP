using Xunit;

namespace TestProjectABP.EntityFrameworkCore;

[CollectionDefinition(TestProjectABPTestConsts.CollectionDefinitionName)]
public class TestProjectABPEntityFrameworkCoreCollection : ICollectionFixture<TestProjectABPEntityFrameworkCoreFixture>
{

}
