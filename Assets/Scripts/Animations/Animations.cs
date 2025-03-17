using UnityEngine;

public class Animations : MonoBehaviour
{
    [SerializeField] protected Animator _animator;
    [SerializeField] protected SpriteRenderer _spriteRenderer;
     private readonly string _transitionTomovement = "MoveSpeed";

    public void MoveIdleAnimation(Vector2 direction)
    {
        _animator.SetFloat(_transitionTomovement, direction.magnitude);

        _spriteRenderer.flipX = direction.x switch
        {
            < 0 => true,
            > 0 => false,
            _ => _spriteRenderer.flipX
        };
    }
   
}
