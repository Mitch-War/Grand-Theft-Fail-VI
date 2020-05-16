using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class WeaponSelector : MonoBehaviour
{
    [SerializeField] private KeyCode wheelKey = KeyCode.Tab;
    [SerializeField] private GameObject wheelParent;
    public GameObject darkScreen;

    void Start()
    {
        DisableWheel();
    }

    private void EnableWheel()
    {
        if (wheelParent != null)
            wheelParent.SetActive(true);

        if (darkScreen != null)
            darkScreen.SetActive(true);

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

    }

    private void DisableWheel()
    {
        if (wheelParent != null)
            wheelParent.SetActive(false);
        
        if(darkScreen != null)
            darkScreen.SetActive(false);

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;


    }

    void Update()
    {
        if (Input.GetKey(wheelKey))
        {
            //Enable Wheel Mode
            EnableWheel();
        }
        else if (Input.GetKeyUp(wheelKey))
        {
            //Disable Wheel Mode
            DisableWheel();
        }
    }
}

