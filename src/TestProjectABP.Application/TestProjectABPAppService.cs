using System;
using System.Collections.Generic;
using System.Text;
using TestProjectABP.Localization;
using Volo.Abp.Application.Services;

namespace TestProjectABP;

/* Inherit your application services from this class.
 */
public abstract class TestProjectABPAppService : ApplicationService
{
    protected TestProjectABPAppService()
    {
        LocalizationResource = typeof(TestProjectABPResource);
    }
}
