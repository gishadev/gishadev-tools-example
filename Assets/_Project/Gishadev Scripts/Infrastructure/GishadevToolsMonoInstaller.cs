using gishadev.tools.Audio;
using gishadev.tools.Effects;
using Zenject;

public class GishadevToolsMonoInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        SignalBusInstaller.Install(Container);

        Container.BindInterfacesTo<AudioManager>().AsSingle().NonLazy();
        Container.BindInterfacesTo<SFXEmitter>().AsSingle().NonLazy();
        Container.BindInterfacesTo<VFXEmitter>().AsSingle().NonLazy();
        Container.BindInterfacesTo<OtherEmitter>().AsSingle().NonLazy();
    }
}