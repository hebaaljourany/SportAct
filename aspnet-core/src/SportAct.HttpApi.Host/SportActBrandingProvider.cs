using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace SportAct;

[Dependency(ReplaceServices = true)]
public class SportActBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "SportAct";
}
