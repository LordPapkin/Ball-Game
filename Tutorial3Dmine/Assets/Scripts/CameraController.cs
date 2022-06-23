using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [Header("Camera Settings")]

    [SerializeField] private Vector3 distance;
    [SerializeField] private float lookUp;
    [SerializeField] private float lerpAmount;

    private GameObject ballObject;
    private void Start()
    {
        ballObject = GameObject.FindGameObjectWithTag("Player");
        QualitySettings.vSyncCount = 1;
        Application.targetFrameRate = 144;
    }
    void LateUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, ballObject.transform.position + distance, lerpAmount * Time.deltaTime);
        transform.LookAt(ballObject.transform.position);
        transform.Rotate(-lookUp, 0, 0);
    }
}
