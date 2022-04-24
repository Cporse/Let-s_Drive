using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMovement : MonoBehaviour
{
    //Variables,
    public static CarMovement Instance;
    public int speed;

    [SerializeField] private Camera orthoGraphic;
    [SerializeField] private float sensivity;

    private Rigidbody rigidbody;

    private Vector3 firstPosition;
    private Vector3 mousePosition;
    private Vector3 difference;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }

        rigidbody = gameObject.GetComponent<Rigidbody>();
    }
    private void FixedUpdate()
    {
        rigidbody.velocity = Vector3.Lerp(rigidbody.velocity, new Vector3(difference.x, rigidbody.velocity.y, speed), 10f);
    }
    private void Update()
    {
        firstPosition = Vector3.Lerp(firstPosition, mousePosition, .1f);
        if (Input.GetMouseButtonDown(0))
        {
            MouseButtonDown(Input.mousePosition);
        }
        else if (Input.GetMouseButton(0))
        {
            MouseButtonDownHold(Input.mousePosition);
        }
        if (Input.GetMouseButtonUp(0))
        {
            MouseButtonUp();
        }

        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -4, 4), transform.position.y, transform.position.z);
    }

    //Functions,
    public void StopCar()
    {
        rigidbody.isKinematic = false;
    }
    private void MouseButtonDown(Vector3 position)
    {
        firstPosition = orthoGraphic.ScreenToWorldPoint(position);
    }
    private void MouseButtonDownHold(Vector3 position)
    {
        mousePosition = orthoGraphic.ScreenToWorldPoint(position);
        difference = mousePosition - firstPosition;
        difference *= sensivity;
    }
    private void MouseButtonUp()
    {
        difference = Vector3.zero;
    }
    //END LINE.
}