using System;
using System.Collections;
using UnityEngine;

public class Familiar : MonoBehaviour
{
    [SerializeField] private FamiliarStats _familiarStats;
    private Transform _target;
    private Rigidbody2D _rb;
    private Vector2 _direction;
    private IFamiliarAbility _familiarAbility;

    private float _speed;
    private float _stopDistance;
    private float _stopSpeed;
    private float _useAbilityRate;

    private void OnEnable()
    {
        
        SpawnEnemies.OnFamiliarUseAbility += StartUseAbility;
    }

    private void OnDisable()
    {
        SpawnEnemies.OnFamiliarUseAbility -= StartUseAbility;
    }

    private void Start()
    {
        Init();
    }

    private void Init()
    {
        _rb = GetComponent<Rigidbody2D>();
        _familiarAbility = GetComponent<IFamiliarAbility>();
        
        _speed = _familiarStats.FamiliarSpeed;
        _stopDistance = _familiarStats.StopDistance;
        _stopSpeed = _familiarStats.StopSpeed;
        _useAbilityRate = _familiarStats.UseAbilityRate;
    }
    
    private void FixedUpdate()
    {
        if (Vector2.Distance(transform.position, _target.position) > _stopDistance)
        {
            FollowPlayer();
        }
        else
        {
            _rb.velocity = Vector2.Lerp(_rb.velocity, Vector2.zero, _stopSpeed * Time.fixedDeltaTime);
        }
    }

    public void SetTarget(Transform target)
    {
        _target = target;
    }

    private void FollowPlayer()
    {
        _direction = _target.position - transform.position;
        _rb.velocity = _speed * _direction;
    }

    private void StartUseAbility()
    {
        StartCoroutine(UseAbility());
    }

    private IEnumerator UseAbility()
    {
        while (true)
        {
            _familiarAbility.Use();
            yield return new WaitForSeconds(_useAbilityRate);
        }
    }
   
}