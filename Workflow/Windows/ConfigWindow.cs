using Ocelot.Windows;

namespace Workflow.Windows;

[OcelotConfigWindow]
public class ConfigWindow(Plugin plugin, Config config) : OcelotConfigWindow(plugin, config);
