using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DynamicBox : MonoBehaviour
{
    private float startingY;
    private void Start()
    {
        startingY = gameObject.transform.position.y;
    }
    private void OnBecameInvisible()
    {        
        if(gameObject.transform.position.y < startingY)
        {            
            Destroy(gameObject);
        }
        
    }
}
