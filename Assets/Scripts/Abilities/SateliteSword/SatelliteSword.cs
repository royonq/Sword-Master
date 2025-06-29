using UnityEngine;

public class SatelliteSword : Projectile
{
    [SerializeField] private GameObject _satellitePrefab;
    
    
    private void FixedUpdate()
    {
        RotateAroundPlayer();
    }
    
    private void RotateAroundPlayer()
    {
        transform.Rotate(_speed * Time.fixedDeltaTime * Vector3.forward);
    }
    
    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {
            
            if (!_isUpgraded)
            {
                base.OnTriggerEnter2D(collision);
                return;
            }
            base.OnTriggerEnter2D(collision);
            SplitProjectile(collision);
        }
    }

    private void SplitProjectile(Collider2D mobCollider)
    {
        float baseAngle = mobCollider.transform.localScale.x < 0 ? 0f : 180f;

        for (int angle = -45; angle <= 45; angle += 45)
        {
            float finalAngle = baseAngle + angle;
            var rotation = Quaternion.Euler(0, 0, finalAngle);
            var instancedProjectile = Instantiate(
                _satellitePrefab,
                mobCollider.transform.position,
                rotation
            );
            var afterHit = instancedProjectile.GetComponent<SplitProjectile>();
            afterHit.Init(_states);
            afterHit.SetIgnoreCollider(mobCollider);
        }
    }
}
