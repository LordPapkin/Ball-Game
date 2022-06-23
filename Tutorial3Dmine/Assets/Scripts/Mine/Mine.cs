using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mine : MonoBehaviour
{
    [Header("Box Settings")]
    
    [Header("Destroy Settings")]
    [SerializeField] float explosionForce = 1000f;

    MeshRenderer meshRenderer;    
    BoxCollider boxCollider;

    MeshRenderer[] childMaterial;
    Rigidbody[] rigidbodies;

    GameObject holder;
    DestroyMineHolder destroyHolder;

    void Start()
    {        
        boxCollider = GetComponent<BoxCollider>();
        meshRenderer = GetComponent<MeshRenderer>();   
        
        holder = transform.GetChild(0).gameObject;
        destroyHolder = holder.GetComponent<DestroyMineHolder>();       

        rigidbodies = GetComponentsInChildren<Rigidbody>(true);
        childMaterial = GetComponentsInChildren<MeshRenderer>(true);  
    }
    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Player") || collision.collider.CompareTag("Box"))
        {
            Die();
        }       
    }    
    private void OnBecameInvisible()
    {
        if (transform.position.y <= -10f)
        {
            Destroy(gameObject);
        }
    }
    
    void Die()
    {        
        boxCollider.enabled = false;        
        foreach (var c in childMaterial)
        {
            c.material.color = meshRenderer.material.color;
        }
        meshRenderer.enabled = false;
        holder.SetActive(true);
        foreach (var r in rigidbodies)
        {
            r.AddExplosionForce(explosionForce, transform.position, 10f);
        }
        transform.DetachChildren();
        destroyHolder.Die();
        Destroy(gameObject);
    }
}
