using UnityEngine;

public class EnemyControl : MonoBehaviour
{
    public float speed = 6.0f;
    public float maxAnimationSpeed = 6f;
    public float jumpSpeed = 8.0f;
    public float rotateSpeed = 0.8f;
    public float gravity = 20.0f;
    public Vector3 turnDirection = Vector3.forward;
    private Vector3 moveDirection = Vector3.zero;
    
    public CharacterController controller;


    private void Awake()
    {
        controller = GetComponent<CharacterController>();
    }
    private void Start()
    {
        
    }

    void Update()
    {

        Vector3 direction = turnDirection * speed;
        direction.y = moveDirection.y;
        moveDirection = direction;
        moveDirection = transform.TransformDirection(moveDirection);
        
        if (controller.isGrounded)
        {
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