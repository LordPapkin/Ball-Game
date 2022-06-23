using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SphereControler : MonoBehaviour
{
    [Header("Control Settings")]
    [SerializeField] private float speed = 1f;    
    [SerializeField] private float maxAngularVelocity;
    private new Rigidbody rigidbody;
    private bool isRigidbody;
    public bool isSpeedUp;



    float hDirection;
    float vDirection;

    private GameManager gameManager;
    
    void Start()
    {
        if (isRigidbody = TryGetComponent<Rigidbody>(out rigidbody))
        {
            rigidbody.maxAngularVelocity = maxAngularVelocity;                     
        }
        gameManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();

    }
    private void Update()
    {
        if(transform.position.y <= -50f)
        {
            gameManager.Reset();
        }
    }
    void FixedUpdate()
    {
        if (isSpeedUp)
        {
            DoubleSpeed();
        }
        else
        {
            NormalSpeed();
        }

    }
    public void ToggleMaxAngularVelocity()
    {
        if (isSpeedUp)
        {
            rigidbody.maxAngularVelocity = maxAngularVelocity * 2;
        }
        else
        {
            rigidbody.maxAngularVelocity = maxAngularVelocity;
        }
    }

    private void NormalSpeed()
    {
        if (isRigidbody && (hDirection = Input.GetAxis("Horizontal")) != 0)
        {
            rigidbody.AddTorque(0, 0, -hDirection * speed * Time.fixedDeltaTime);
        }
        if (isRigidbody && (vDirection = Input.GetAxis("Vertical")) != 0)
        {
            rigidbody.AddTorque(vDirection * speed * Time.fixedDeltaTime, 0, 0);
        }
    }

    private void DoubleSpeed()
    {
        if (isRigidbody && (hDirection = Input.GetAxis("Horizontal")) != 0)
        {
            rigidbody.AddTorque(0, 0, -hDirection * speed * 2f * Time.fixedDeltaTime);
        }
        if (isRigidbody && (vDirection = Input.GetAxis("Vertical")) != 0)
        {
            rigidbody.AddTorque(vDirection * speed * 2f * Time.fixedDeltaTime, 0, 0);
        }
    }
    public void Jump(float jumpForce)
    {
        rigidbody.AddForce(Vector3.up * jumpForce);
    }
}
