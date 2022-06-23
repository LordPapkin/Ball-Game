using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [Header("Ball Render")]
    [SerializeField] private GameObject ballPrefab;
    [SerializeField] private Transform start;
    [Header("Time Settings")]
    [SerializeField] public float time;
    [SerializeField] private float endTime;
    [SerializeField ]private bool audioBool;
    public TextMeshProUGUI timeText;


    private bool end;

    private AudioSource audioSource;
    private AudioManager audioManager;
   


    private void Awake()
    {
        Instantiate(ballPrefab, start.position, Quaternion.identity);       
    }
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioManager = GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>();
    }
    private void Update()
    {
        if (!end)
        {
            time -= Time.deltaTime;
            timeText.text = "Time: " + Mathf.CeilToInt(time).ToString();
            if (time <= endTime && !audioBool)
            {
                audioBool = true;
                timeText.enableVertexGradient = false;
                timeText.color = Color.red;

                audioSource.Play();



            }
            else if (time > endTime && audioBool)
            {
                audioBool = false;
                timeText.enableVertexGradient = true;
                timeText.color = Color.white;

                audioSource.Stop();



            }
            if (time <= 0)
            {
                Reset();
            }
        }
    }
    public void Reset()
    {
        audioManager.PlaySound(AudioManager.Sounds.Lose);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void Win()
    {
        end = true;
        audioManager.PlaySound(AudioManager.Sounds.Win);
        Invoke("NextLevel", 2.5f);
    }
    private void NextLevel()
    {        
        if (SceneManager.sceneCountInBuildSettings > SceneManager.GetActiveScene().buildIndex + 1)
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        else
            SceneManager.LoadScene(0);
    }
}



