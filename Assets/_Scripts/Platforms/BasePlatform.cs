using UnityEngine;

namespace FrogNinja.Platforms
{
    public abstract class BasePlatform : MonoBehaviour
    {
        protected abstract void HandleCollision(Collision2D collision);
        private void OnCollisionEnter2D(Collision2D collision)
        {
            HandleCollision(collision);
        }
    }
}