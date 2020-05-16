using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour
{
    public float mouseSensitivity = 10;
    public Transform target;
    public float targetDistance = 2;
    public Vector2 pitchMinMax = new Vector2 (-40, 85);

    public float rotationSmoothTime = 0.12f;
    Vector3 rotationSmoothVelocity;
    Vector3 currentRotation;


    float yaw; // Y axis rotation
    float pitch; // X axis rotation


    //Wibbly wobbly timey wimey stuff
    public float slowMoTime = 0.05f;
    public float realTime = 1f;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Tab))
        {
            SlowMotionTime();
        }
        else if (Input.GetKeyUp(KeyCode.Tab))
        {
            RealTime();
        }
    }

    void LateUpdate()
    {
        yaw += Input.GetAxis("Mouse X") * mouseSensitivity;
        //For Controller Support on the X axis on right stick.
        yaw += Input.GetAxis("Controller Right Stick X") * mouseSensitivity;

        pitch -= Input.GetAxis("Mouse Y") * mouseSensitivity;
        //For controller support on the Y axis on right stick.
        pitch -= Input.GetAxis("Controller Right Stick Y") * mouseSensitivity;

        pitch = Mathf.Clamp(pitch, pitchMinMax.x, pitchMinMax.y);

        currentRotation = Vector3.SmoothDamp(currentRotation, new Vector3(pitch, yaw), ref rotationSmoothVelocity, rotationSmoothTime);

        transform.eulerAngles = currentRotation;

        transform.position = target.position - transform.forward * targetDistance;
    }

    void SlowMotionTime() 
    {
        Time.timeScale = slowMoTime;
        Time.fixedDeltaTime = Time.timeScale * 0.02f;
    }

    void RealTime()
    {
        Time.timeScale = realTime;
        Time.fixedDeltaTime = Time.timeScale * 1f;
    }
}
