using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] FixedJoystick joystick;
    //[SerializeField] DynamicJoystick joystick;

    Vector3 moveDirection;
    Vector3 aimDirection;
    float moveSpeed = 0f;
    [SerializeField] float speedMax = 10f;
    [SerializeField] float acceleration = 0.1f;
    [SerializeField] float decceleration = 0.1f;
    [SerializeField] float smoothRotation = 0.1f;
    public bool canMove;
    private Animator mAnimator;



    //Cache
    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        canMove = true;

        if (Application.platform == RuntimePlatform.Android)
        {
            QualitySettings.shadowDistance = 50;
        }

        mAnimator = transform.GetChild(0).GetComponent<Animator>();
        mAnimator.SetTrigger("Idle");
    }


    void Update()
    {
        if (joystick.Direction.magnitude > 0 && canMove)
        {
            // Vecteur de direction de déplacement
            moveDirection = new Vector3(joystick.Direction.x, 0, joystick.Direction.y).normalized;
            moveSpeed = Mathf.Lerp(moveSpeed, speedMax, acceleration) * joystick.Direction.magnitude;
        }
        else
        {
            moveSpeed = Mathf.Lerp(moveSpeed, 0, decceleration);
        }



        // Vitesse de déplacement
        moveSpeed += joystick.Direction.magnitude * acceleration * Time.deltaTime;
        moveSpeed = Mathf.Clamp(moveSpeed, 0, speedMax);

        // Orientation Joueur
        aimDirection = moveDirection;
        transform.forward = Vector3.Lerp(transform.forward, aimDirection, smoothRotation);

        // Vélocité = direction * vitesse * inclinaison du joystick
        rb.velocity = moveDirection * moveSpeed;
    }

    private void FixedUpdate()
    {
        
    }
}
