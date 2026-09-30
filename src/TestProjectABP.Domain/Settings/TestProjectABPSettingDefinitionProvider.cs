using Volo.Abp.Settings;

namespace TestProjectABP.Settings;

public class TestProjectABPSettingDefinitionProvider : SettingDefinitionProvider
{
    public override void Define(ISettingDefinitionContext context)
    {
        //Define your own settings here. Example:
        //context.Add(new SettingDefinition(TestProjectABPSettings.MySetting1));
    }
}
