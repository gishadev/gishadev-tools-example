using gishadev.tools.Audio;
using gishadev.tools.Pooling;
using UnityEngine;
using Zenject;

[CreateAssetMenu(fileName = "GishadevToolsSOInstaller", menuName = "Installers/GishadevToolsSOInstaller")]
public class GishadevToolsSOInstaller : ScriptableObjectInstaller<GishadevToolsSOInstaller>
{
    [SerializeField] private AudioMasterSO audioMasterSO;
    [SerializeField] private PoolDataSO poolDataSO;
    
    public override void InstallBindings()
    {
        Container.BindInstances(audioMasterSO, poolDataSO);
    }
}