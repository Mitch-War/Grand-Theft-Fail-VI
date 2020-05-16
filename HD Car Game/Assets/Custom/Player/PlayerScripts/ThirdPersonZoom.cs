using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonZoom : MonoBehaviour
{
    public Transform[] views;
    public float transitionSpeed;
    Transform currentView;

    void Start()
    {
        
    }


    void Update()
    {
        if (Input.GetMouseButton(1))
        {
            currentView = views[1];
        }

        else if (Input.GetMouseButtonUp(1)) 
        {
            currentView = views[0];
        }

    }

    void LateUpdate()
    {
        //Lerp Position
        transform.position = Vector3.Lerp(transform.position, currentView.position, Time.deltaTime * transitionSpeed);
    }
}
