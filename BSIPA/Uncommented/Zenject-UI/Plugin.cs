using IPA;
using IPA.Config.Stores;
using IPA.Loader;
using SiraUtil.Zenject;
using UnnamedPlugin.Installers;
using IPALogger = IPA.Logging.Logger;
using IPAConfig = IPA.Config.Config;

namespace UnnamedPlugin
{
    [Plugin(RuntimeOptions.SingleStartInit), NoEnableDisable]
    internal class Plugin
    {
        internal static IPALogger Log { get; private set; }

        [Init]
        public Plugin(IPALogger ipaLogger, IPAConfig ipaConfig, Zenjector zenjector, PluginMetadata pluginMetadata)
        {
            Log = ipaLogger;
            zenjector.UseLogger(Log);
            
            var pluginConfig = ipaConfig.Generated<PluginConfig>();
            
            zenjector.Install<AppInstaller>(Location.App, pluginConfig);
            zenjector.Install<MenuInstaller>(Location.Menu);
            
            Log.Info($"{pluginMetadata.Name} {pluginMetadata.HVersion} initialized.");
        }
    }
}