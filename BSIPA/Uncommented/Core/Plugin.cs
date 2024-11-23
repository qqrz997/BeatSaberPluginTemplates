using IPA;
using IPA.Config.Stores;
using IPA.Loader;
using UnityEngine;
using IPALogger = IPA.Logging.Logger;
using IPAConfig = IPA.Config.Config;

namespace UnnamedPlugin
{
    [Plugin(RuntimeOptions.SingleStartInit)]
    internal class Plugin
    {
        internal static IPALogger Log { get; private set; }

        [Init]
        public Plugin(IPALogger ipaLogger, IPAConfig ipaConfig, PluginMetadata pluginMetadata)
        {
            Log = ipaLogger;
            
            PluginConfig.Instance = ipaConfig.Generated<PluginConfig>();
            
            Log.Info($"{pluginMetadata.Name} {pluginMetadata.HVersion} initialized.");
        }
        
        [OnStart]
        public void OnApplicationStart()
        {
            Log.Debug("OnApplicationStart");
            new GameObject("UnnamedPluginController").AddComponent<UnnamedPluginController>();
        }

        [OnExit]
        public void OnApplicationQuit()
        {
            Log.Debug("OnApplicationQuit");
        }
    }
}