using TestProjectABP.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace TestProjectABP.Controllers;

/* Inherit your controllers from this class.
 */
public abstract class TestProjectABPController : AbpControllerBase
{
    protected TestProjectABPController()
    {
        LocalizationResource = typeof(TestProjectABPResource);
    }
}
