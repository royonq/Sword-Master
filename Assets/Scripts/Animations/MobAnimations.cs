using UnityEngine;

public abstract class MobAnimations : MonoBehaviour
{
    protected Animator _animator;
    private readonly string _transitionTomovement = "MoveSpeed";

    private void Start()
    {
        _animator = GetComponentInChildren<Animator>();
    }

    public void MoveIdleAnimation(Vector2 direction)
    {
        _animator.SetFloat(_transitionTomovement, direction.magnitude);
        if (direction.x == 0)
        {
            return;
        }

        float directionX = direction.x > 0 ? 1 : -1;
        transform.localScale = new Vector3(directionX, transform.localScale.y, transform.localScale.z);
    }
}