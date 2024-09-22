using gishadev.tools.Audio;
using Zenject;

public class GishadevToolsMonoInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        SignalBusInstaller.Install(Container);

        Container.BindInterfacesTo<AudioManager>().AsSingle().NonLazy();
    }
}