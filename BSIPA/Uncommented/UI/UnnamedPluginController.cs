using BeatSaberMarkupLanguage.Util;
using UnityEngine;
using UnnamedPlugin.Menu;

namespace UnnamedPlugin
{
    internal class UnnamedPluginController : MonoBehaviour
    {
        public static UnnamedPluginController Instance { get; private set; }
        
        private void Awake()
        {
            if (Instance != null)
            {
                DestroyImmediate(this);
                return;
            }

            DontDestroyOnLoad(this);
            Instance = this;
            
            MainMenuAwaiter.MainMenuInitializing += SettingsMenuManager.AddSettingsMenu;
        }

        private void Start()
        {
            Plugin.Log.Debug($"{name} started");
        }

        private void OnDestroy()
        {
            Plugin.Log.Debug($"{name} destroyed");
            MainMenuAwaiter.MainMenuInitializing -= SettingsMenuManager.AddSettingsMenu;
            
            if (Instance == this)
            {
                Instance = null;
            }
        }
    }
}