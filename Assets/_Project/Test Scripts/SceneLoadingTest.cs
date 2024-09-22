using gishadev.tools.SceneLoading;
using UnityEngine;

namespace gishadev.tools.Test
{
    public class SceneLoadingTest : MonoBehaviour
    {
        [SerializeField] private string nextSceneToLoad;

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.J))
                SceneLoader.I.AsyncSceneLoad(nextSceneToLoad);
        }
    }
}