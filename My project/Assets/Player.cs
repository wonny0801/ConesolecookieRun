using UnityEngine;
using UnityEngine.SceneManagement;

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
        FixedPositionX();
        Jump();
        DoubleJump();
       if(!isGround &&  !isJump)
        {
            transform.Rotate(Vector3.back * 450f * Time.deltaTime);
        }
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

    private void FixedPositionX()
    {
        rid.transform.position = new Vector3(-7f,
                                rid.transform.position.y,
                                rid.transform.position.z);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
        {
            Debug.Log("Ground");
            isGround = true;
            isJump = false;
            transform.rotation = Quaternion.identity;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("Enemy");
            GameMng.CurHp -= GameMng.MaxHp / 5;
        }
    }
}
