using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponWheelSounds : MonoBehaviour
{
    public AudioSource slowDown;
    public AudioSource returnToNormal;

    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            slowDown.Play();
        }
        else if (Input.GetKeyUp(KeyCode.Tab))
        {
            returnToNormal.Play();
            slowDown.Stop();
        }
    }
}
