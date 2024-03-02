using System;
using System.Collections.Generic;
using System.Text;
using SportAct.Localization;
using Volo.Abp.Application.Services;

namespace SportAct;

/* Inherit your application services from this class.
 */
public abstract class SportActAppService : ApplicationService
{
    protected SportActAppService()
    {
        LocalizationResource = typeof(SportActResource);
    }
}
