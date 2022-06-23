using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddTime : MonoBehaviour
{
    [SerializeField] private float timeToAdd;    
    private GameManager gameManager;
    AudioManager audioManager;

    private void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
        audioManager = GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            audioManager.PlaySound(AudioManager.Sounds.Bonus);
            gameManager.time += timeToAdd;
            Destroy(gameObject);
        }
    }


}
