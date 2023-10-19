using gishadev.tools.Events;
using UnityEngine;

namespace gishadev.tools.Test
{
    [CreateAssetMenu(fileName = "EventsContainer", menuName = "ScriptableObjects/EventsContainer")]
    public class EventsContainerSO : ScriptableObject
    {
        [field: SerializeField] public DefaultEventChannelSO ColorEventChannel { get; private set; }
        [field: SerializeField] public FloatEventChannelSO FloatEventChannel { get; private set; }
    }
}