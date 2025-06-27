public interface IProjectileState
{
    float Damage { get; }
    float Speed { get; }
    float LifeTime { get; }
    bool IsUpgraded { get; }
}
