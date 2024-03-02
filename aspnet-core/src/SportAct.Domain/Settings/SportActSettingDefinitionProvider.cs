using Volo.Abp.Settings;

namespace SportAct.Settings;

public class SportActSettingDefinitionProvider : SettingDefinitionProvider
{
    public override void Define(ISettingDefinitionContext context)
    {
        //Define your own settings here. Example:
        //context.Add(new SettingDefinition(SportActSettings.MySetting1));
    }
}
