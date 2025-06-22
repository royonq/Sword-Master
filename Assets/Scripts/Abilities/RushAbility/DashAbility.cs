using UnityEngine;
using System.Collections;
using UnityEngine.InputSystem;

public class DashAbility : Ability
{
    [SerializeField] private Camera _camera;
    [SerializeField] private LayerMask _enemyLayer;
    private DashAbilityStats _dashAbilityStats;
    private Rigidbody2D _rb;
    private Player _player;
    
    private float _slowDuration;
    private float _slowCoefficient;
    private float _slowRadius;
    private float _dashForce;
    private readonly float _dashDuration = 1;

    private TrailRenderer _trail;
    
    private void Awake()
    {
        _rb = GetComponentInParent<Rigidbody2D>();
        _player = GetComponentInParent<Player>();
        _trail = GetComponentInParent<TrailRenderer>();
        
        _dashAbilityStats = _stats as DashAbilityStats;
        _slowDuration = _dashAbilityStats.SlowDuration;
        _slowCoefficient = _dashAbilityStats.SlowCoefficient;
        _slowRadius = _dashAbilityStats.SlowRadius;
        _dashForce = _dashAbilityStats.Force; 
    }

    protected override void InitAbility()
    {
        StartCoroutine(Dash());
    }

    public override void UpgradeAbility(ItemsData itemData)
    {
        base.UpgradeAbility(itemData);
        var upgradeStats = itemData as UpgradeDashAbility;
        _dashForce += upgradeStats.IncreaseDistance;
        _slowDuration += upgradeStats.IncreaseSlowDuration;
        _slowCoefficient += upgradeStats.IncreaseSlowCoefficient;
        _slowRadius += upgradeStats.IncreaseSlowRadius;
    }

    private IEnumerator Dash()
{
    _player.SetCanMove(false);
    _player.SetInvulnerable(true);
    _trail.enabled = true;

    var cursorWorldPos = _camera.ScreenToWorldPoint(Mouse.current.position.ReadValue());
    var direction = ((Vector2)cursorWorldPos - (Vector2)transform.position).normalized;

    _rb.AddForce(direction * _dashForce, ForceMode2D.Impulse);

    yield return new WaitForSeconds(_dashDuration);

    _rb.velocity = Vector2.zero;
    
    var start = _rb.position;
    var end = _rb.position - direction * _dashForce;
    
    if (_isAbilityUpgraded)
    {
        HitEnemiesOnLine(start, end);
    }
    
    _player.SetCanMove(true);
    _player.SetInvulnerable(false);
    yield return new WaitForSeconds(_trail.time);
    _trail.enabled = false;
}
    
    private void HitEnemiesOnLine(Vector2 start, Vector2 end)
    {
        var direction = (end - start).normalized;
        float length = Vector2.Distance(start, end);

        var hits = Physics2D.BoxCastAll(start, Vector2.one * _slowRadius,
            0, direction, length, _enemyLayer);

        foreach (var hit in hits)
        {
            var enemy = hit.collider.GetComponent<Enemy>();
            enemy.ApplySlow(_slowCoefficient, _slowDuration);
        }
    }
    
    private void OnDrawGizmos()
    {

        if (!Application.isPlaying)
        {
            return;
        }
        
        var cursorWorldPos = _camera.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        var direction = ((Vector2)cursorWorldPos - _rb.position).normalized;
        var boxSize = Vector2.one * _slowRadius;
        float length = _dashAbilityStats.Force;

        Gizmos.color = Color.cyan;
        var oldMatrix = Gizmos.matrix;
        Gizmos.matrix = Matrix4x4.TRS(_rb.position + direction * length / 2, Quaternion.FromToRotation(Vector3.right, direction), Vector3.one);
        Gizmos.DrawWireCube(Vector3.zero, new Vector3(length, boxSize.y, 0.1f));
        Gizmos.matrix = oldMatrix;
    }
}
