using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyHolder : MonoBehaviour
{
    private Transform[] children;
    private Transform newParent;
    
    public void Die()
    {
        children = GetComponentsInChildren<Transform>();
        newParent = GameObject.Find("Debries").transform;        
        foreach(var c in children)
        {
            c.transform.SetParent(newParent);
        }
        Destroy(gameObject);
    }
}
