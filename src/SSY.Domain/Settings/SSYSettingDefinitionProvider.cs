using Volo.Abp.Settings;

namespace SSY.Settings;

public class SSYSettingDefinitionProvider : SettingDefinitionProvider
{
    public override void Define(ISettingDefinitionContext context)
    {
        //Define your own settings here. Example:
        //context.Add(new SettingDefinition(SSYSettings.MySetting1));
    }
}
