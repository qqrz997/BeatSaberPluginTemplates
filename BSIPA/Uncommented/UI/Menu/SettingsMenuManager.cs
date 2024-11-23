using BeatSaberMarkupLanguage.Settings;
using UnityEngine;

namespace UnnamedPlugin.Menu
{
    internal static class SettingsMenuManager
    {
        private static ExampleSettingsMenu SettingsMenuInstance { get; set; }
        
        private const string MenuName = nameof(UnnamedPlugin);
        private const string ResourcePath = nameof(UnnamedPlugin) + ".Menu.BSML.example.bsml";
        
        public static void AddSettingsMenu()
        {
            if (SettingsMenuInstance == null)
            {
                SettingsMenuInstance = new GameObject(nameof(ExampleSettingsMenu)).AddComponent<ExampleSettingsMenu>();
                Object.DontDestroyOnLoad(SettingsMenuInstance.gameObject);
            }
            
            RemoveSettingsMenu();
            
            BSMLSettings.Instance.AddSettingsMenu(
                MenuName, ResourcePath, SettingsMenuInstance);
        }

        public static void RemoveSettingsMenu()
        {
            BSMLSettings.Instance.RemoveSettingsMenu(SettingsMenuInstance);
        }
    }
}