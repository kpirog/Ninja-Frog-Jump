using UnityEngine;

namespace FrogNinja.Platforms
{
    public class BreakingPlatform : BasePlatform
    {
        [SerializeField] private SpriteRenderer spriteRenderer;

        protected override void HandleCollision(Collision2D collision)
        {
            collision.otherCollider.enabled = false;
            spriteRenderer.enabled = false;
        }
    }
}
