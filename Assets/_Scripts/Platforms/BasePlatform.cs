using UnityEngine;

namespace FrogNinja.Platforms
{
    public abstract class BasePlatform : MonoBehaviour
    {
        protected abstract void HandleCollision(Collision2D collision);
        private void OnCollisionEnter2D(Collision2D collision)
        {
            Rigidbody2D playerRB = collision.rigidbody;

            if (playerRB.velocity.y > 0f)
                return;

            if (playerRB.transform.position.y < transform.position.y)
                return;

            HandleCollision(collision);
        }
    }
}