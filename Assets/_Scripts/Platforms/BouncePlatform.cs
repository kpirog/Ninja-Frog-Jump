using UnityEngine;

namespace FrogNinja.Platforms
{
    public class BouncePlatform : BasePlatform
    {
        [SerializeField] private float bounceStrenght;
        
        protected override void HandleCollision(Collision2D collision)
        {
            collision.rigidbody.AddForce(Vector2.up * bounceStrenght, ForceMode2D.Impulse);
        }
    }
}
