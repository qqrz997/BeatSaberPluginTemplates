using UnityEngine;

namespace UnnamedPlugin
{
    internal class UnnamedPluginController : MonoBehaviour
    {
        public static UnnamedPluginController Instance { get; private set; }
        
        private void Awake()
        {
            if (Instance != null)
            {
                DestroyImmediate(this);
                return;
            }

            DontDestroyOnLoad(this);
            Instance = this;
        }

        private void Start()
        {
            Plugin.Log.Debug($"{name} started");
        }

        private void OnDestroy()
        {
            Plugin.Log.Debug($"{name} destroyed");
            if (Instance == this)
            {
                Instance = null;
            }
        }
    }
}