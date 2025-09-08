using Dalamud.Plugin;
using ECommons;
using Ocelot;
using Ocelot.Chain;

namespace Workflow;

public sealed class Plugin : OcelotPlugin
{
    public override string Name {
        get => "Workflow";
    }

    public Config Config { get; }

    public override OcelotConfig OcelotConfig {
        get => Config;
    }

    public static ChainQueue Chain {
        get => ChainManager.Get("Workflow.Chain");
    }

    public Plugin(IDalamudPluginInterface plugin)
        : base(plugin, Module.DalamudReflector)
    {
        Config = plugin.GetPluginConfig() as Config ?? new Config();

        SetupLanguage(plugin);

        OcelotInitialize();
    }

    private void SetupLanguage(IDalamudPluginInterface plugin)
    {
        I18N.SetDirectory(plugin.AssemblyLocation.Directory?.FullName!);
        I18N.LoadAllFromDirectory("en", "Translations/en");

        I18N.SetLanguage("en");
    }

    protected override void OnCoreLoaded()
    {
        Commands.InitializeMainCommand("/workflow");
        Commands.InitializeConfigCommand("/workflowcfg", aliases: ["/workflowc"]);
    }
}
