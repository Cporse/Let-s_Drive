using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    //Variables,
    public static CameraController Instance;

    [SerializeField] private Transform carPosition;
    [SerializeField] AudioSource inGameAudio;

    private float yAxis = 5;
    private float zAxis = 10;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }
    private void Start()
    {
        inGameAudio.Play();
    }
    private void Update()
    {
        transform.position = new Vector3(carPosition.position.x, carPosition.position.y + yAxis, carPosition.position.z - zAxis);
    }

    //Functions,
    public void DoZoom()
    {
        yAxis += .3f;
        zAxis += .6f;
    }
    public void DontZoom()
    {
        yAxis -= .3f;
        zAxis -= .6f;
    }

    //END LINE.
}