using UnityEngine;

public abstract class MobAnimations : MonoBehaviour
{
    protected Animator _animator;
    private readonly string _transitionTomovement = "MoveSpeed";

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    public void MoveIdleAnimation(Vector2 direction)
    {
        _animator.SetFloat(_transitionTomovement, direction.magnitude);

        if ((direction.x < 0 && transform.localScale.x > 0) || (direction.x > 0 && transform.localScale.x < 0))
        {
            transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
        }
    }
}