using System;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using VContainer;
using VContainer.Unity;

namespace gishadev.tools.Infrastructure
{
    public abstract class AutoInjectLifetimeScope : LifetimeScope
    {
        [SerializeField] private bool autoInjectScene = true;
        [SerializeField] private FindObjectsInactive includeInactive = FindObjectsInactive.Include;

        protected override void Awake()
        {
            base.Awake();
            InjectAllSceneObjects();
            
            SceneManager.sceneLoaded += OnSceneLoaded;
            SceneManager.sceneUnloaded += OnSceneUnloaded;
        }

        protected override void OnDestroy()
        {
            base.OnDestroy();
            SceneManager.sceneLoaded -= OnSceneLoaded;
            SceneManager.sceneUnloaded -= OnSceneUnloaded;
        }

        private void InjectAllSceneObjects()
        {
            // Find all scene objects with [Inject] attributes and inject them
            var injectables = FindObjectsByType(typeof(MonoBehaviour), includeInactive, FindObjectsSortMode.None)
                .Select(x => (MonoBehaviour)x)
                .Where(HasInjectAttribute);

            int count = 0;
            foreach (var injectable in injectables)
            {
                try
                {
                    Container.Inject(injectable);
                    count++;
                }
                catch (Exception ex)
                {
                    Debug.LogError(
                        $"Failed to inject {injectable.GetType()} on {injectable.gameObject.name}: {ex.Message}");
                }
            }

            Debug.Log($"Auto-injected {count} scene components");
        }


        // Helper method to check if a MonoBehaviour has any [Inject] fields/properties/methods
        private bool HasInjectAttribute(MonoBehaviour mb)
        {
            var type = mb.GetType();

            // Check if any fields have [Inject]
            var hasInjectFields = type.GetFields(System.Reflection.BindingFlags.Instance |
                                                 System.Reflection.BindingFlags.Public |
                                                 System.Reflection.BindingFlags.NonPublic)
                .Any(field => field.GetCustomAttributes(typeof(InjectAttribute), true).Length > 0);

            if (hasInjectFields) return true;

            // Check if any properties have [Inject]
            var hasInjectProperties = type.GetProperties(System.Reflection.BindingFlags.Instance |
                                                         System.Reflection.BindingFlags.Public |
                                                         System.Reflection.BindingFlags.NonPublic)
                .Any(prop => prop.GetCustomAttributes(typeof(InjectAttribute), true).Length > 0);

            if (hasInjectProperties) return true;

            // Check if any methods have [Inject]
            var hasInjectMethods = type.GetMethods(System.Reflection.BindingFlags.Instance |
                                                   System.Reflection.BindingFlags.Public |
                                                   System.Reflection.BindingFlags.NonPublic)
                .Any(method => method.GetCustomAttributes(typeof(InjectAttribute), true).Length > 0);

            return hasInjectMethods;
        }

        private void OnSceneLoaded(Scene arg0, LoadSceneMode arg1)
        {
            if (autoInjectScene)
                InjectAllSceneObjects();
        }

        private void OnSceneUnloaded(Scene arg0)
        {
        }
    }
}