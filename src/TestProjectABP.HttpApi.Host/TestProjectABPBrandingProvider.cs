using Microsoft.Extensions.Localization;
using TestProjectABP.Localization;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace TestProjectABP;

[Dependency(ReplaceServices = true)]
public class TestProjectABPBrandingProvider : DefaultBrandingProvider
{
    private IStringLocalizer<TestProjectABPResource> _localizer;

    public TestProjectABPBrandingProvider(IStringLocalizer<TestProjectABPResource> localizer)
    {
        _localizer = localizer;
    }

    public override string AppName => _localizer["AppName"];
}
