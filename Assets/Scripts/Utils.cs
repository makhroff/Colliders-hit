using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Utils
{
    public static class MyUtils
    {
        public static GameObject FindParent(this GameObject go)
        {
            if (go.transform.parent == null)
                return go;

            return FindParent(go.transform.parent.gameObject);
        }
    }
}