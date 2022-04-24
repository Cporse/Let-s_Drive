using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CanvasManagement : MonoBehaviour
{
    //Variables,
    public static CanvasManagement Instance;

    private CarMovement carMovement;
    private ObjectSpawner objectSpawner;

    [SerializeField] private Text textScore;
    [SerializeField] private Text textSpeed;
    [SerializeField] private Slider sliderTime;
    [SerializeField] private AudioSource forGameOverAudio;

    public bool sliderFlowRunning;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }
    private void Start()
    {
        StartCoroutine(FunctionSliderTime());
        sliderFlowRunning = true;
        carMovement = CarMovement.Instance;
        objectSpawner = ObjectSpawner.Instance;
    }
    public void ScoreCounter(float totalTime)
    {
        textScore.text = Convert.ToDecimal(totalTime).ToString("#,##0.0");
    }
    public void SpeedCounter(float actualSpeed)
    {
        textSpeed.text = Convert.ToDecimal(actualSpeed).ToString("#,##0.0" + " km/h");
    }
    public void TimeCounter()
    {
        sliderTime.value += 3;
    }
    IEnumerator FunctionSliderTime()
    {
        yield return new WaitForSeconds(1);
        if (sliderFlowRunning)
        {
            if (sliderTime.value <= 0)
            {
                sliderFlowRunning = false;
                objectSpawner.objectSpawnerRunning = false;
                carMovement.StopCar();
                forGameOverAudio.Play();
                Invoke("FunctionRestart", 3f);
            }
            sliderTime.value -= 1;
            StartCoroutine(FunctionSliderTime());
        }
    }
    private void FunctionRestart()
    {
        SceneManager.LoadScene(0);
    }
}