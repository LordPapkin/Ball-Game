using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyMineHolder : MonoBehaviour
{
    private Transform newParent;
    private Transform[] children;

    public void Die()
    {
        children = GetComponentsInChildren<Transform>();
        newParent = GameObject.Find("Debries").transform;
        foreach(Transform c in children)
        {
            c.transform.SetParent(newParent);
        }
        Destroy(gameObject);
    }
}
