using System;
using ECommons.DalamudServices;
using Ocelot;

namespace Workflow;

[Serializable]
public class Config : OcelotConfig
{
    public override int Version { get; set; } = 1;

    public override void Save()
    {
        Svc.PluginInterface.SavePluginConfig(this);
    }
}
