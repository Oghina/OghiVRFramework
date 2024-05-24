using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OGHI.Tools
{
    public static class ResourcesDictionaries
    {
        private static Dictionary<GameObject, Transform> initialParentsDictionary = new Dictionary<GameObject, Transform>();

        public static string GetUniqueName()
        {
            string guid = Guid.NewGuid().ToString();
            return guid;
        }

        public static void RegisterObjectInitialParent(GameObject obj, Transform parent)
        {
            initialParentsDictionary.Add(obj, parent);
        }

        public static Transform GetObjectInitialParent(GameObject gameObject)
        {
            Transform parent = null;
            initialParentsDictionary.TryGetValue(gameObject, out parent);
            return parent;
        }
    }
}
