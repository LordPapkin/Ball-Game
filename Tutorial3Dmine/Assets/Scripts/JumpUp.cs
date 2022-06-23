using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpUp : MonoBehaviour
{
    [SerializeField] private float jumpForce;
    private SphereControler sphereControler;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            sphereControler = other.GetComponent<SphereControler>();
            Invoke("Jump", 0.5f);
        }        
    }
    private void Jump()
    {
        sphereControler.Jump(jumpForce);
    }
}
