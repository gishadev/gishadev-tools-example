using gishadev.tools.Effects;
using UnityEngine;
using VContainer;

namespace gishadev.tools.Test
{
    public class EffectsTest : MonoBehaviour
    {
        [Inject] private IVFXEmitter _vfxEmitter;
        [Inject] private ISFXEmitter _sfxEmitter;
        
        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out var hitInfo))
                {
                    _vfxEmitter.EmitAt((int)VisualEffectsEnum.EXPLOSION, hitInfo.point, Quaternion.identity);
                    _sfxEmitter.EmitAt((int)SoundEffectsEnum.EXPLOSION, hitInfo.point, Quaternion.identity);
                }
            }
        }
    }
}