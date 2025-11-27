using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Rigidbody2D rid;

    private void Awake()
    {
        rid = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("eee");
            Destroy(gameObject);
            GameMng.CurHp -= GameMng.MaxHp / 10f;
        }
    }


}
