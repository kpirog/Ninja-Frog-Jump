using UnityEngine;

namespace FrogNinja.Platforms
{
    public class BouncePlatform : BasePlatform
    {
        [SerializeField] private float bounceStrenght;
        
        protected override void HandleCollision(Collision2D collision)
        {
            Rigidbody2D playerRB = collision.rigidbody;

            if (playerRB.velocity.y > 0f)
                return;

            if (playerRB.transform.position.y < transform.position.y)
                return;

            playerRB.AddForce(Vector2.up * bounceStrenght, ForceMode2D.Impulse);
        }
    }
}
