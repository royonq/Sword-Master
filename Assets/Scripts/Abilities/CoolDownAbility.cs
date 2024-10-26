using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class CoolDownAbility : MonoBehaviour
{

    [SerializeField] private float _timeAbilityCooldown;
    [SerializeField] private Image _abilityImage;
    private bool _isAbilityCooldown;
    public bool IsAbilityCooldown { get { return _isAbilityCooldown; } }
    private void Start()
    {
        _abilityImage.fillAmount = 0;
    }
    public void StartCooldown()
    {
        StartCoroutine(Cooldown());
    }
    private IEnumerator Cooldown()
    {
        _isAbilityCooldown = true;
        _abilityImage.fillAmount = 1; 

        while (_abilityImage.fillAmount > 0)
        {
            _abilityImage.fillAmount -= 1 / _timeAbilityCooldown * Time.deltaTime; 
            yield return null; 
        }

        _abilityImage.fillAmount = 0; 
        _isAbilityCooldown = false; 
    }
}
