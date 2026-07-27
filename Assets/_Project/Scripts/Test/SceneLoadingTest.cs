using Cysharp.Threading.Tasks;
using gishadev.tools.SceneLoading;
using UnityEngine;
using VContainer;

namespace gishadev.tools.Test
{
    public class SceneLoadingTest : MonoBehaviour
    {
        [SerializeField] private string nextSceneToLoad;
        [Inject] private ISceneLoader _sceneLoader;
        
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.J))
                _sceneLoader.LoadScene(nextSceneToLoad).Forget();
        }
    }
}