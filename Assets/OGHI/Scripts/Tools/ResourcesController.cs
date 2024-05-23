using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OGHI.Tools
{
    public class ResourcesController : MonoBehaviour
    {
        [SerializeField] private GameObject grabbablePrefab;
        [SerializeField] private GameObject snapzonePrefab;
        [SerializeField] private GameObject leverPrefab;

        private static ResourcesController instance;
        private static readonly object _lock = new object();

        public static ResourcesController Instance
        {
            get
            {
                lock (_lock)
                {
                    if (instance == null)
                    {
                        instance = FindObjectOfType<ResourcesController>();

                        if (instance == null)
                        {
                            GameObject singletonObject = new GameObject(typeof(ResourcesController).Name);
                            instance = singletonObject.AddComponent<ResourcesController>();
                            DontDestroyOnLoad(singletonObject);
                        }
                    }
                    return instance;
                }
            }
        }

        private void Awake()
        {
            if (instance == null)
            {
                lock (_lock)
                {
                    if (instance == null)
                    {
                        instance = this;
                        DontDestroyOnLoad(gameObject);
                    }
                    else if (instance != this)
                    {
                        Destroy(gameObject);
                    }
                }
            }
            else if (instance != this)
            {
                Destroy(gameObject);
            }
        }

        public void CreateSnapzone(GameObject objectToRotate, Transform position)
        {

        }
    }
}
