using gishadev.tools.Effects;
using UnityEngine;

namespace gishadev.tools.Test
{
    public class EffectsTest : MonoBehaviour
    {
        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out var hitInfo))
                {
                    VFXEmitter.I.EmitAt(VisualEffectsEnum.BOOM, hitInfo.point, Quaternion.identity);
                    SFXEmitter.I.EmitAt(SoundEffectsEnum.BOOM, hitInfo.point, Quaternion.identity);
                }
            }
        }
    }
}