using BNG;
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

        public Grabbable CreateGrabbable(GameObject objectToGrab, out GrabbableUnityEvents grabbableUnityEvents)
        {
            ResourcesDictionaries.RegisterObjectInitialParent(objectToGrab, objectToGrab.transform.parent);

            Grabbable grabbableObject = Instantiate(grabbablePrefab).GetComponent<Grabbable>();
            grabbableUnityEvents = grabbableObject.GetComponent<GrabbableUnityEvents>();

            grabbableObject.name = ResourcesDictionaries.GetUniqueName();

            grabbableObject.transform.position = objectToGrab.transform.position;
            grabbableObject.transform.rotation = objectToGrab.transform.rotation;

            objectToGrab.transform.SetParent(grabbableObject.transform);
            grabbableObject.gameObject.SetActive(true);

            return grabbableObject;
        }

        public SnapZone CreateSnapzone(Grabbable objectToPlace, Transform position)
        {
            SnapZone snapZoneObject = Instantiate(snapzonePrefab).GetComponent<SnapZone>();
            snapZoneObject.transform.position = position.position;
            snapZoneObject.transform.rotation = position.rotation;

            snapZoneObject.OnlyAllowNames.Add(objectToPlace.gameObject.name);
            snapZoneObject.gameObject.SetActive(true);

            return snapZoneObject;
        }

        public void MakeUngrabbable(GameObject initialObject)
        {
            Transform currentParent = initialObject.transform.parent;
            initialObject.transform.parent = ResourcesDictionaries.GetObjectInitialParent(initialObject);
            Destroy(currentParent.gameObject); 
        }

        public void MakeUngrabbable(GameObject initialObject, SnapZone snapZone)
        {
            MakeUngrabbable(initialObject);
            Destroy(snapZone.gameObject);
        }
    }
}
