using UnityEngine;

public abstract class MobAnimations : MonoBehaviour
{
    protected Animator _animator;
    private const string _transitionTomovement = "MoveSpeed";

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    public void MoveIdleAnimation(Vector2 direction)
    {
        _animator.SetFloat(_transitionTomovement, direction.magnitude);

        transform.localScale = direction.x switch
        {
            < 0 => new Vector3(-Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z),
            > 0 => new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z),
            _ => transform.localScale
        };
    }
}