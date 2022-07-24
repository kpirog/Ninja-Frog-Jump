using UnityEngine;

public class FullScreenEnemy : BaseEnemy
{
    private Camera mainCamera;

    protected override void Awake()
    {
        base.Awake();
        mainCamera = Camera.main;
    }
    protected override void Move()
    {
        rb.velocity = velocity;
        Vector2 viewPort = mainCamera.WorldToViewportPoint(transform.position);

        if (viewPort.x >= 1)
        {
            velocity.x = -speed;
            spriteRenderer.flipX = false;
        }
        else if (viewPort.x <= 0)
        {
            velocity.x = speed;
            spriteRenderer.flipX = true;
        }
    }
    protected override void OnCollisionEnter2D(Collision2D collision2D)
    {
        base.OnCollisionEnter2D(collision2D);
    }
}
