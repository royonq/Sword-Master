using System;
using UnityEngine;

public class Player : Mob
{
    public static event Action OnPlayerDeath;

    [SerializeField] private PlayerBar _playerBars;
    [SerializeField] private Ability _deafultAttack;
    [SerializeField] private Ability _ultimate;
    [SerializeField] private PlayerAnimations _playerAnimations;
    private Animator _animator;
    private SpriteRenderer _spriteRenderer;


    protected override void SetStats()
    {
        base.SetStats();

        var playerStats = _damagableStats as PlayerStats;

        _playerBars.SetMaxHealth(playerStats.MaxHealth);
        GetAnimationComponents();
    }

    private void GetAnimationComponents()
    {
        _playerAnimations = GetComponent<PlayerAnimations>();
        _animator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        
        _deafultAttack.SetAnimation(_animator,"IsAttack");
        _ultimate.SetAnimation(_animator,"IsUltimate");
    }

    

    public void Attack()
    {
        _deafultAttack.Use();
    }

    public void UseUltimate()
    {
        _ultimate.Use();
    }

    protected override void Die()
    {
        OnPlayerDeath?.Invoke();
    }

    public override void TakeDamage(float recivedDamage)
    {
        base.TakeDamage(recivedDamage);

        _playerBars.ChangeValue(_currentHealth);
    }

    public override void Move(Vector2 direction)
    {
        base.Move(direction);
        _playerAnimations.MoveIdleAnimation(direction,_animator,_spriteRenderer);
    }

    private void LevelUp()
    {
    }

    private void Interact()
    {
    }

    private void UpgradeAbility()
    {
    }

    private void UseWorkBench()
    {
    }

    private void EarnXp()
    {
    }

    private void BuyItem()
    {
    }

    private void OpenInventory()
    {
    }
    
}