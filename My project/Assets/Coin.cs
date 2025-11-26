using UnityEngine;

public class Coin : MonoBehaviour
{
    private Rigidbody2D rid;

    private void Awake()
    {
        rid = GetComponent<Rigidbody2D>();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
            GameMng.GameScore += GameMng.PlusScoreValue;
        }
    }
}
