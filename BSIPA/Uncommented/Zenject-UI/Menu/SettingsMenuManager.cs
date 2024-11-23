using System;
using BeatSaberMarkupLanguage.Settings;
using Zenject;

namespace UnnamedPlugin.Menu
{
    internal class SettingsMenuManager : IInitializable, IDisposable
    {
        private readonly ExampleSettingsMenu exampleSettingsMenu;
        private readonly BSMLSettings bsmlSettings;
        
        private const string MenuName = nameof(UnnamedPlugin);
        private const string ResourcePath = nameof(UnnamedPlugin) + ".Menu.BSML.example.bsml";
        
        public SettingsMenuManager(ExampleSettingsMenu exampleSettingsMenu, BSMLSettings bsmlSettings)
        {
            this.exampleSettingsMenu = exampleSettingsMenu;
            this.bsmlSettings = bsmlSettings;
        }

        public void Initialize()
        {
            bsmlSettings.AddSettingsMenu(MenuName, ResourcePath, exampleSettingsMenu);
        }
        
        public void Dispose()
        {
            bsmlSettings.RemoveSettingsMenu(exampleSettingsMenu);
        }
    }
}