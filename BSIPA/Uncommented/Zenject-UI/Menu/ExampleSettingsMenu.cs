using BeatSaberMarkupLanguage.Attributes;
using HMUI;
using TMPro;
using UnityEngine;

namespace UnnamedPlugin.Menu
{
    internal class ExampleSettingsMenu
    {
        [UIComponent("example-image")]
        private readonly ImageView exampleImage = null!;

        [UIComponent("example-text")] 
        private readonly TextMeshProUGUI exampleText = null!;

        [UIAction("#post-parse")]
        private void PostParse()
        {
            Plugin.Log.Debug($"{nameof(ExampleSettingsMenu)} parsed");
        }
        
        [UIAction("example-action")]
        private void ExampleAction()
        {
            exampleImage.color = Color.white;
            exampleText.text = "Hello World!";
        }
    }
}