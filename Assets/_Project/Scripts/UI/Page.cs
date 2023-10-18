using System;
using UnityEngine;

namespace gishadev.tools.UI
{
    public class Page : MonoBehaviour
    {
        [field: SerializeField] public bool ExitOnNewPagePush { get; private set; }
        public event Action Changed;

        public void Enter()
        {
            gameObject.SetActive(true);
            Changed?.Invoke();
        }

        public void Exit()
        {
            gameObject.SetActive(false);
            Changed?.Invoke();
        }
    }
}