using gishadev.tools.Audio;
using UnityEngine;
using Zenject;

[CreateAssetMenu(fileName = "GishadevToolsSOInstaller", menuName = "Installers/GishadevToolsSOInstaller")]
public class GishadevToolsSOInstaller : ScriptableObjectInstaller<GishadevToolsSOInstaller>
{
    [SerializeField] private AudioMasterSO audioMasterSO;
    
    public override void InstallBindings()
    {
        Container.BindInstances(audioMasterSO);
    }
}