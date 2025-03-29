using UnityEngine;

public abstract class MobAnimations : MonoBehaviour
{
    
    protected Animator _animator;
    protected SpriteRenderer _spriteRenderer;
    private readonly string _transitionTomovement = "MoveSpeed";

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public virtual void MoveIdleAnimation(Vector2 direction)
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