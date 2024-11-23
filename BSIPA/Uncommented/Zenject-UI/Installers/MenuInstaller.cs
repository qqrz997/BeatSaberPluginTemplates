using UnnamedPlugin.Menu;
using Zenject;

namespace UnnamedPlugin.Installers
{
    internal class MenuInstaller : Installer
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesTo<SettingsMenuManager>().AsSingle();
            
            Container.Bind<ExampleSettingsMenu>().AsSingle();
        }
    }
}