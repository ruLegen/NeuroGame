using System;
using UnityEngine;

public class PlayerControls : MonoBehaviour, KillableInterface
{
    public float speed = 6.0f;
    public float maxAnimationSpeed = 6f;
    public float jumpSpeed = 8.0f;
    public float rotateSpeed = 0.8f;
    public float gravity = 20.0f;
    public bool isManual = true;
    public bool isDead = false;
    public Animator animator;
   
    public Vector3 turnDirection = Vector3.forward;
    private Vector3 moveDirection = Vector3.zero;
    
    private CharacterController controller;
    private Transform playerCamera;
    private bool isWalk = false;
    private bool isIdle = false;

    private void Awake()
    {
        MindWaveAdapter.OnAttenction += OnAttention;
        MindWaveAdapter.OnMediationEvent += OnMeditation;
        MindWaveAdapter.OnBlink += OnBlink; ;
    }

  

    private void Start()
    {
        controller = GetComponent<CharacterController>();
        playerCamera = GetComponentInChildren<Camera>().transform;
       
    }
    private void OnDestroy()
    {
        MindWaveAdapter.OnBlink -= OnBlink;
        MindWaveAdapter.OnMediationEvent -= OnMeditation;
    }
    private void OnBlink(int value)
    {
        if (!isManual)
        {
            // Save Jump vector
            Vector3 direction = turnDirection * speed;
            direction.y = moveDirection.y;
            moveDirection = direction;
        }
        moveDirection = transform.TransformDirection(moveDirection);

        if (controller.isGrounded)
        {
            if (!isWalk && !isIdle && !isDead)      // Restrict Jump while Walk or Idle 
            {
                moveDirection.y = jumpSpeed;
                animator.SetBool("isOnGround", false);
            }
            else
            {
                animator.SetBool("isOnGround", true);
                moveDirection.y = 0;
            }
        }
        controller.Move(moveDirection * Time.deltaTime);

    }

    private void OnAttention(int value)
    {
        if (!isDead && GlobalParams.RUN_TYPE == Constants.RUN_ON_ATTENTION)
            speed = map(value, 0, 101, 5, 26);
    }
    private void OnMeditation(int value)
    {
        if (!isDead && GlobalParams.RUN_TYPE == Constants.RUN_ON_MEDITATION)
            speed = map(value, 0, 101, 5, 26);
    }

    public float map(float value, float min, float max, float out_min, float out_max)
    {
        return (value - min) * (out_max - out_min) / (max - min) + out_min;
    }
    void Update()
    {
        isWalk = animator.GetCurrentAnimatorStateInfo(0).IsName("Walk");
        isIdle = animator.GetCurrentAnimatorStateInfo(0).IsName("Idle");
        
        if (!isManual)
        {
            // Save Jump vector
            Vector3 direction = turnDirection * speed;
            direction.y = moveDirection.y;
            moveDirection = direction;
        }
        else
        {
            moveDirection = new Vector3(Input.GetAxis("Horizontal") * speed, moveDirection.y, Input.GetAxis("Vertical") * speed);
        }
        moveDirection = transform.TransformDirection(moveDirection);
        
        animator.SetFloat("speed", Mathf.Clamp(speed / maxAnimationSpeed, 0,1.3f));
        if (controller.isGrounded)
        {
            if (Input.GetButton("Jump") && !isWalk && !isIdle && !isDead)      // Restrict Jump while Walk or Idle 
            {
                moveDirection.y = jumpSpeed;
                animator.SetBool("isOnGround", false);
            }
            else
            {
                animator.SetBool("isOnGround", true);
                moveDirection.y = 0;
            }
        }

        if(isDead)
        {
            animator.SetFloat("speed", 1);
            speed -= speed*1.5f * Time.deltaTime+1;
            if (speed < 0)
                speed = 0;
        }
        moveDirection.y -= gravity * Time.deltaTime;
        controller.Move(moveDirection * Time.deltaTime);
    }

    public void Rotate(Vector3 rotation)
    {
        gameObject.transform.Rotate(rotation);
    }

    public void onDie()
    {
        speed = 0;
    }
}