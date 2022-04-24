using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    //Variables,
    public static ObjectSpawner Instance;

    private CanvasManagement canvasManagement;

    [SerializeField] private Transform carPosition;
    [SerializeField] private GameObject[] timeOrNosOrTrap;
    [SerializeField] private float objectCreatingTime;

    public bool objectSpawnerRunning = true;

    private float totalTime = 0;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }
    private void Start()
    {
        canvasManagement = CanvasManagement.Instance;
        StartCoroutine(FunctionSpawnerTime());
    }
    private void FixedUpdate()
    {
        canvasManagement.ScoreCounter(totalTime += Time.deltaTime);
    }
    IEnumerator FunctionSpawnerTime()
    {
        yield return new WaitForSeconds(objectCreatingTime);
        if (objectSpawnerRunning)
        {
            Instantiate(timeOrNosOrTrap[Random.Range(0, 3)], new Vector3(Random.Range(-4, 4), carPosition.position.y, carPosition.position.z + 20), Quaternion.identity);
            StartCoroutine(FunctionSpawnerTime());
        }
    }
}