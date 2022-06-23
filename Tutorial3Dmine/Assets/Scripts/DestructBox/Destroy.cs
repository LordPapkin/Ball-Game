using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{
    [Header("Box Settings")]

    [SerializeField] private Color startColor;
    [SerializeField] private Color endColor;
    [SerializeField] private float health;

    private Material material;
    private float maxHealth = 3f;
    private float startingY;

    [Header("Destroy Settings")]
    [SerializeField] float explosionForce = 500f;
    //pobiera swoje elementy
    MeshRenderer meshRenderer;
    BoxCollider boxCollider;
    //pobiera elemnty dzieci
    MeshRenderer[] childMaterial;
    Rigidbody[] rigidbodies;
    //pobiera holder odłamków
    GameObject holder;
    DestroyHolder destroyHolder;

    void Start()
    {
        //ustawiamy hp i kolorek
        health = Mathf.Clamp(health, 1, maxHealth);
        material = GetComponent<MeshRenderer>().material;
        SetColor();

        boxCollider = GetComponent<BoxCollider>();
        meshRenderer = GetComponent<MeshRenderer>();

        holder = transform.GetChild(0).gameObject;
        destroyHolder = holder.GetComponent<DestroyHolder>();


        rigidbodies = GetComponentsInChildren<Rigidbody>(true);
        childMaterial = GetComponentsInChildren<MeshRenderer>(true);

        startingY = transform.position.y;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            health--;
            if (health <= 0)
            {
                Die();
            }
            else
            {
                SetColor();
            }
        }
    }
    private void OnBecameInvisible()
    {
        if (transform.position.y <= startingY)
        {
            Destroy(gameObject);
        }
    }
    void SetColor()
    {
        material.color = Color.Lerp(endColor, startColor, health / maxHealth);
    }
    void Die()
    {
        boxCollider.enabled = false;
        foreach (var c in childMaterial)
        {
            c.material.color = Color.Lerp(endColor, startColor, health / maxHealth);
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
