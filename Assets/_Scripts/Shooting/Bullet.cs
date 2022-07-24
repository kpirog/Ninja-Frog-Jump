using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float speed;
    [SerializeField] private float lifeTime = 3f;
    private void OnEnable()
    {
        Destroy(gameObject, lifeTime);
    }
    private void FixedUpdate()
    {
        rb.AddForce(Vector2.up * speed, ForceMode2D.Impulse);
    }
}
