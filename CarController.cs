using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    //Variables,
    public static CarController Instance;

    private CameraController cameraController;
    private CanvasManagement canvasManagement;
    private CarMovement carMovement;
    private ObjectSpawner objectSpawner;

    [SerializeField] private AudioSource forSpeedAudio;
    [SerializeField] private AudioSource forTimeAudio;
    [SerializeField] private AudioSource forWrongAudio;
    [SerializeField] private AudioSource forGameOverAudio;
    [SerializeField] private int speedDifference;

    private Transform ground;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }
    private void Start()
    {
        cameraController = CameraController.Instance;
        canvasManagement = CanvasManagement.Instance;
        carMovement = CarMovement.Instance;
        objectSpawner = ObjectSpawner.Instance;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("CubeNos"))
        {
            NosTrigger();
        }
        else if (other.gameObject.CompareTag("CubeTime"))
        {
            TimeTrigger();
        }
        else if (other.gameObject.CompareTag("CubeTrap"))
        {
            TrapTrigger();
        }

        Destroy(other.gameObject);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("WayWall"))
        {
            //Debug.Log("Gizli duvara temas edildi.");
            ground = collision.gameObject.transform.parent;
            ground.position = new Vector3(ground.position.x, ground.position.y, ground.position.z + 30);
        }
    }

    //Functions,
    private void NosTrigger()
    {
        canvasManagement.SpeedCounter(carMovement.speed += speedDifference);
        cameraController.DoZoom();
        forSpeedAudio.Play();
    }
    private void TimeTrigger()
    {
        canvasManagement.TimeCounter();
        forTimeAudio.Play();
    }
    private void TrapTrigger()
    {
        canvasManagement.SpeedCounter(carMovement.speed -= speedDifference);
        cameraController.DontZoom();

        if (carMovement.speed < 5)
        {
            forGameOverAudio.Play();
            carMovement.StopCar();
            objectSpawner.objectSpawnerRunning = false;
            canvasManagement.sliderFlowRunning = false;
        }
        else
        {
            forWrongAudio.Play();
        }
    }
}