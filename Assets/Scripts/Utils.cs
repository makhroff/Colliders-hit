using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Utils : MonoBehaviour
{
    public static GameObject FindParent(GameObject go)
    {
        if (go.transform.parent == null)
            return go;

        return FindParent(go.transform.parent.gameObject);
    }
}
