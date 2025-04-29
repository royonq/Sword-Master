using UnityEngine;

public class FamiliarAutoAttack : MonoBehaviour, IFamiliarAbility
{
   public void Use()
   {
      Debug.Log("Auto attack");
   }
}
