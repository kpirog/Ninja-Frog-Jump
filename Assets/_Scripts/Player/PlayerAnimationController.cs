using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
    private Animator anim;
    private SpriteRenderer spriteRenderer;
    private PlayerController playerController;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        playerController = GetComponent<PlayerController>();
    }
    private void Update()
    {
        anim.SetBool("InAir", playerController.IsGrounded);

        SetSpriteFlip();
    }
    private void SetSpriteFlip()
    {
        if (playerController.Direction == Vector2.zero)
        {
            return;
        }

        spriteRenderer.flipX = playerController.Direction == Vector2.left;
    }
}
