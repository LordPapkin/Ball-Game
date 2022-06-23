using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBoxChildern : MonoBehaviour
{
    private float startingY;

    private void Start()
    {
        startingY = transform.position.y;
    }
    private void OnBecameInvisible()
    { 
        if(transform.position.y < 0f && transform.position.y < startingY)
        {
            Destroy(gameObject);
        }        
    }
}
