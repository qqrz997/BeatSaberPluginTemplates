using IPA;
using IPA.Config.Stores;
using IPA.Loader;
using UnityEngine;
using IpaLogger = IPA.Logging.Logger;
using IpaConfig = IPA.Config.Config;

namespace MenuPlugin;

[Plugin(RuntimeOptions.SingleStartInit)]
internal class Plugin
{
    internal static IpaLogger Log { get; private set; }

    // Methods with [Init] are called when the plugin is first loaded by IPA.
    // All the parameters are provided by IPA and are optional.
    // The constructor is called before any method with [Init]. Only use [Init] with one constructor.
        
    [Init]
    public Plugin(IpaLogger ipaLogger, IpaConfig ipaConfig, PluginMetadata pluginMetadata)
    {
        Log = ipaLogger;
            
        // Creates an instance of PluginConfig used by IPA to load and store config values
        PluginConfig.Instance = ipaConfig.Generated<PluginConfig>();
            
        Log.Info($"{pluginMetadata.Name} {pluginMetadata.HVersion} initialized.");
    }
        
    [OnStart]
    public void OnApplicationStart()
    {
        Log.Debug("OnApplicationStart");
        new GameObject("MenuPluginController").AddComponent<MenuPluginController>();
    }

    [OnExit]
    public void OnApplicationQuit()
    {
        Log.Debug("OnApplicationQuit");
    }
}