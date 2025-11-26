using UnityEngine;

public class GroundMove : MonoBehaviour
{
    [SerializeField] private float MoveSpeed;

    private float DestroyX = -20f;

    private void Update()
    {
        if (transform.position.x < DestroyX)
            Destroy(gameObject);

        transform.Translate(Vector3.left *  MoveSpeed * Time.deltaTime);
    }

}
