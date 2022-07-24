using UnityEngine;

public abstract class BaseEnemy : MonoBehaviour
{
    [SerializeField] protected Rigidbody2D rb;
    [SerializeField] protected float speed;

    [SerializeField] protected Vector2 velocity;

    [SerializeField] protected SpriteRenderer spriteRenderer;
    
    protected virtual void FixedUpdate()
    {
        Move();
    }
    protected abstract void Move();
    protected virtual void OnCollisionEnter2D(Collision2D collision2D)
    {
        if (collision2D.rigidbody.GetComponent<PlayerController>() != null)
        {
            EventManager.OnEnemyHitPlayer();
        }
    }
}
