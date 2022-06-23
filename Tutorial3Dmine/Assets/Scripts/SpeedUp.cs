using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedUp : MonoBehaviour
{
    private SphereControler sphereControler;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            sphereControler = other.GetComponent<SphereControler>();
            sphereControler.isSpeedUp = true;
            sphereControler.ToggleMaxAngularVelocity();
        }
       
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            sphereControler = other.GetComponent<SphereControler>();
            sphereControler.isSpeedUp = false;
            sphereControler.ToggleMaxAngularVelocity();
        }        
    }
}
