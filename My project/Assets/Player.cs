using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("setting")]
    [SerializeField] private float JumpVelocity;
    [SerializeField] private float JumpPower;

    private Rigidbody2D rid;
    private bool isGround = true;
    private bool isJump = false;

    private void Awake()
    {
        rid = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        Jump();
        DoubleJump();
       
    }

    private void Jump()
    {
        if(Input.GetKeyDown(KeyCode.Z) && isGround && !isJump)
        {
            Debug.Log("Jump");
            isGround = false;
            isJump = true;
            rid.linearVelocityY = JumpVelocity;
            rid.AddForce(Vector2.up * JumpPower, ForceMode2D.Impulse);
        }
       
    }
    private void DoubleJump()
    {
        if(Input.GetKeyDown(KeyCode.X) && !isGround && isJump)
        {
            Debug.Log("Double Jump");
            isJump = false;
            rid.linearVelocityY = JumpVelocity;
            rid.AddForce(Vector2.up * JumpPower, ForceMode2D.Impulse);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
        {
            isGround = true;
            isJump = false;
        }
    }
}
