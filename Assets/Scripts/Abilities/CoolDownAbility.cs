using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class CoolDownAbility : MonoBehaviour
{
    [SerializeField] private AbilitySateliteSword _abilitySateliteSword;
    private float _timeAbilityCooldown;
    private Image _abilityColdownImage;
    private Image _abilityImage;
    private bool _isAbilityCooldown;
    public bool IsAbilityCooldown { get { return _isAbilityCooldown; } }
    private void Start()
    {
        _timeAbilityCooldown = _abilitySateliteSword.TimeCooldown;

        _abilityImage = GetComponent<Image>();
        _abilityColdownImage = GetComponentsInChildren<Image>()[1];

        _abilityImage.sprite = _abilitySateliteSword.AbilityIcon;

        _abilityColdownImage.fillAmount = 0;
    }
    public void StartCooldown()
    {
        StartCoroutine(Cooldown());
    }
    private IEnumerator Cooldown()
    {
        _isAbilityCooldown = true;
        _abilityColdownImage.fillAmount = 1; 

        while (_abilityColdownImage.fillAmount > 0)
        {
            _abilityColdownImage.fillAmount -= 1 / _timeAbilityCooldown * Time.deltaTime; 
            yield return null; 
        }

        _abilityColdownImage.fillAmount = 0; 
        _isAbilityCooldown = false; 
    }
}
