using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyMinesChildren : MonoBehaviour
{
    private float startingY;    
    private void Start()
    {
        startingY = transform.position.y;
        Destroy(gameObject, 120);
        
    }   
    private void OnBecameInvisible()
    {
        if (transform.position.y < startingY - 2f)
        {
            Destroy(gameObject);
        }
    }
}
