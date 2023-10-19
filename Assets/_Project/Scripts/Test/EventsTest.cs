using gishadev.tools.Events;
using UnityEngine;

namespace gishadev.tools.Test
{
    public class EventsTest : MonoBehaviour
    {
        [SerializeField] private EventsContainerSO eventsContainer;
        [SerializeField] private MeshRenderer planeMeshRenderer;
        
        private void OnEnable()
        {
            eventsContainer.ColorEventChannel.ChangedValue += OnColorChanged;
            eventsContainer.FloatEventChannel.ChangedValue += OnFloatChanged;
        }

        private void OnDisable()
        {
            eventsContainer.ColorEventChannel.ChangedValue -= OnColorChanged;
            eventsContainer.FloatEventChannel.ChangedValue -= OnFloatChanged;
        }

        private void OnFloatChanged(float value)
        {
            planeMeshRenderer.transform.localScale = Vector3.one * value;
        }

        // TODO: Add enum based broadcasters & channels.
        private void OnColorChanged(StringWrapper stringText)
        {
            switch (stringText.value)
            {
                case "Blue":
                    planeMeshRenderer.material.color = Color.blue;
                    break;
                case "Red":
                    planeMeshRenderer.material.color = Color.red;
                    break;
            }   
        }
    }
}