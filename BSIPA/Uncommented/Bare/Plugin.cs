using IPA;
using IPA.Loader;
using UnityEngine;
using IPALogger = IPA.Logging.Logger;

namespace UnnamedPlugin
{
    [Plugin(RuntimeOptions.SingleStartInit)]
    internal class Plugin
    {
        internal static IPALogger Log { get; private set; }

        [Init]
        public Plugin(IPALogger ipaLogger, PluginMetadata pluginMetadata)
        {
            Log = ipaLogger;
            
            Log.Info($"{pluginMetadata.Name} {pluginMetadata.HVersion} initialized.");
        }
        
        [OnStart]
        public void OnApplicationStart()
        {
            Log.Debug("OnApplicationStart");
        }

        [OnExit]
        public void OnApplicationQuit()
        {
            Log.Debug("OnApplicationQuit");
        }
    }
}