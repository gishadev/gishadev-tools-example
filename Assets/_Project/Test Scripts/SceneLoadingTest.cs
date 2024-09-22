using gishadev.tools.SceneLoading;
using UnityEngine;
using Zenject;

namespace gishadev.tools.Test
{
    public class SceneLoadingTest : MonoBehaviour
    {
        [SerializeField] private string nextSceneToLoad;
        [Inject] private ISceneLoader _sceneLoader;
        
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.J))
                _sceneLoader.AsyncSceneLoad(nextSceneToLoad);
        }
    }
}