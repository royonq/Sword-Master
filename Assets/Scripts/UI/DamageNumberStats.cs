using UnityEngine;
[CreateAssetMenu(fileName = "NewDamageNumbers", menuName = "Data/BattleUi/DamageNumbers")]
public class DamageNumberStats : ScriptableObject
{
    [SerializeField] private float _lifeTime;
    public float LifeTime => _lifeTime;
    
    [SerializeField] private float _moveUpSpeed;
    public float MoveUpSpeed => _moveUpSpeed;
}
