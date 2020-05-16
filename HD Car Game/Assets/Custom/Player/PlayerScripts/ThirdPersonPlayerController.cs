using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonPlayerController : MonoBehaviour
{

    public float walkSpeed = 2;
    public float runSpeed = 6;

    public float turnSmoothTime = 0.2f;
    float turnSmoothVelocity;

    public float speedSmoothTime = 0.1f;
    float speedSmoothVelocity;
    float currentSpeed;

    public Animator animator;
    Transform cameraT;

    [SerializeField] private bool isAiming;

    void Start()
    {
        cameraT = Camera.main.transform;
    }


    void Update()
    {
        //Movement
        Vector2 input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        Vector2 inputDir = input.normalized;

        if (inputDir != Vector2.zero)
        {
            float targetRotation = Mathf.Atan2(inputDir.x, inputDir.y) * Mathf.Rad2Deg + cameraT.eulerAngles.y;
            transform.eulerAngles = Vector3.up * Mathf.SmoothDampAngle(transform.eulerAngles.y, targetRotation, ref turnSmoothVelocity, turnSmoothTime);
        }

        bool running = Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.JoystickButton8);

        float targetSpeed = ((running) ? runSpeed : walkSpeed) * inputDir.magnitude;
        currentSpeed = Mathf.SmoothDamp(currentSpeed, targetSpeed, ref speedSmoothVelocity, speedSmoothTime);

        transform.Translate(transform.forward * currentSpeed * Time.deltaTime, Space.World);

        float animationSpeedPercent = ((running) ? 1 : .5f) * inputDir.magnitude;
        animator.SetFloat("speedPercent", animationSpeedPercent, speedSmoothTime, Time.deltaTime);

        //Aiming
        if (Input.GetMouseButton(1))
        {
            isAiming = true;
            Aim();
        }

        else if (Input.GetMouseButtonUp(1))
        {
            isAiming = false;
            DontAim();
        }
    }

    public void Aim()
    {
        if (isAiming)
        {
            animator.SetBool("isHoldingRifle", true);
            animator.SetFloat("riflePercent", 1f);
        }
    }

    public void DontAim() 
    {
        if (!isAiming) 
        {
            animator.SetBool("isHoldingRifle", false);
            animator.SetFloat("riflePercent", 0f);
        }
    }
}
