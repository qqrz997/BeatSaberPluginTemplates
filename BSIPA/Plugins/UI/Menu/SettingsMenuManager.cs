using BeatSaberMarkupLanguage.Settings;
using UnityEngine;

namespace MenuPlugin.Menu;

internal static class SettingsMenuManager
{
    private static ExampleSettingsMenu SettingsMenuInstance { get; set; }
        
    private const string MenuName = nameof(MenuPlugin);
    private const string ResourcePath = nameof(MenuPlugin) + ".Menu.example.bsml";
        
    /// <summary>
    /// Adds a custom menu in the Mod Settings section of the main menu.
    /// This should only be called when the main menu is active.
    /// </summary>
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