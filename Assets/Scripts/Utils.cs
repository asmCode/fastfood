using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Utils
{
    public static void SetParentAndResetTransform(Transform child, Transform parent)
    {
        child.SetParent(parent);
        ResetTransform(child);
    }

    public static void ResetTransform(Transform transform)
    {
        transform.localPosition = Vector3.zero;
        transform.localRotation = Quaternion.identity;
        transform.localScale = Vector3.one;
    }

    private static void GetBoundsRecursively(GameObject go, ref Bounds bounds)
    {
        var renderer = go.GetComponent<Renderer>();
        if (renderer != null)
            bounds.Encapsulate(renderer.bounds);

        for (int i = 0; i < go.transform.childCount; i++)
            GetBoundsRecursively(go.transform.GetChild(i).gameObject, ref bounds);
    }

    public static Bounds GetBounds(GameObject go)
    {
        Bounds bounds = new Bounds(go.transform.position, Vector3.zero);
        GetBoundsRecursively(go, ref bounds);
        return bounds;
    }
}
