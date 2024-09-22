using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private int _cost;
    public int Cost { get { return _cost; } }
}
