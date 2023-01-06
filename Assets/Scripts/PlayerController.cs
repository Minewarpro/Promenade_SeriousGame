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
    [SerializeField] ParticleSystem pasParticls;
    public bool canMove;
    private Animator mAnimator;
    private bool isWalking;

    static public bool canRotate = true;

    //Cache
    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        canMove = true;

        if (Application.platform == RuntimePlatform.Android)
        {
            QualitySettings.shadowDistance = 100;
        }

        mAnimator = transform.GetChild(0).GetComponent<Animator>();
        isWalking = false;


        if (ChangeScene.staticChangePos)
        {
            transform.position = ChangeScene.spawnPos;
            ChangeScene.staticChangePos = false;
        }
    }


    void Update()
    {
        if (joystick.Direction.magnitude > 0 && canMove)
        {
            // Vecteur de direction de déplacement
            moveDirection = new Vector3(joystick.Direction.x, 0, joystick.Direction.y).normalized;
            moveSpeed = Mathf.Lerp(moveSpeed, speedMax, acceleration) * joystick.Direction.magnitude;

            float AnimSpeed = Mathf.Lerp(0, 1, joystick.Direction.magnitude);
            mAnimator.SetFloat("AnimSpeed", AnimSpeed);

            if (!isWalking)
            {
                mAnimator.SetTrigger("Run");
                Debug.Log("run");
                isWalking = true;
                pasParticls.Play();
            }

        }
        else
        {
            moveSpeed = Mathf.Lerp(moveSpeed, 0, decceleration);

            if (isWalking) 
            {
                mAnimator.SetTrigger("Idle");
                pasParticls.Stop();


                isWalking = false;
            }

        }


        // Vitesse de déplacement
        moveSpeed += joystick.Direction.magnitude * acceleration * Time.deltaTime;
        moveSpeed = Mathf.Clamp(moveSpeed, 0, speedMax);

        if (canRotate)
        {
            // Orientation Joueur
            aimDirection = moveDirection;
            transform.forward = Vector3.Lerp(transform.forward, aimDirection, smoothRotation);
        }
        

        // Vélocité = direction * vitesse * inclinaison du joystick
        Vector3 truc = new Vector3(moveDirection.x * moveSpeed, rb.velocity.y, moveDirection.z * moveSpeed);
        rb.velocity = truc;
    }

    private void FixedUpdate()
    {
        
    }
}
