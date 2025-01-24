using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody RB;

    public float Speed;
    public float SprintSpeed;
    public float JumpForce;
    public bool InSprint;

    public bool MovementAllowed;

    float Horizontal;
    float Vertical;

    public bool IsGrounded;
    public LayerMask GroundMask;

    void Start()
    {
        RB = GetComponent<Rigidbody>();
    }

    void Update()
    {

        IsGrounded = Physics.CheckSphere(new Vector3(transform.position.x, transform.position.y - 1.7f, transform.position.z), 0.5f, GroundMask);
        if(MovementAllowed)
        {
            if (InSprint == true)
            {
                Horizontal = Input.GetAxis("Horizontal") * SprintSpeed;
                Vertical = Input.GetAxis("Vertical") * Speed;
            }
            else
            {
                Horizontal = Input.GetAxis("Horizontal") * Speed;
                Vertical = Input.GetAxis("Vertical") * Speed;
            }
        }
        


        Vector3 MovePosition = transform.right * Horizontal * Speed + transform.forward * Vertical * Speed;
        Vector3 NewMovePosition = new Vector3(MovePosition.x, RB.linearVelocity.y, MovePosition.z);

        RB.linearVelocity = NewMovePosition;

    }
}