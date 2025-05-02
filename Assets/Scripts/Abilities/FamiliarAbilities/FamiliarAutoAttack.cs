using System;
using UnityEngine;

public class FamiliarAutoAttack : MonoBehaviour, IFamiliarAbility
{
   public static Action<float> OnUse;
   [SerializeField] private float _damage;
   private bool _isUsable;
   public void Use()
   {
      if (_isUsable)
      {
         OnUse?.Invoke(_damage);
      }
   }

   private void OnTriggerEnter2D(Collider2D other)
   {
      if (other.CompareTag("Enemy"))
      {
         _isUsable = true;
      }
   }

   private void OnTriggerExit2D(Collider2D other)
   {
      if (other.CompareTag("Enemy"))
      {
         _isUsable = false;
      }
   }
}
