using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{
    public void MoveIdleAnimation(Vector2 direction, Animator animator, SpriteRenderer spriteRenderer)
    {
        animator.SetFloat("MoveSpeed", direction.magnitude);
        if (direction.x < 0)
        {
            spriteRenderer.flipX = true;
        }
        else
            if (direction.x > 0)
            {
                spriteRenderer.flipX = false;
            }
    }
}
