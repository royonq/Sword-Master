using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class CoolDownAbility : MonoBehaviour
{
    [SerializeField] private Image _abilityColdownImage;
    private Image _abilityImage;
    private bool _isAbilityCooldown;
    public bool IsAbilityCooldown { get { return _isAbilityCooldown; } }
    private void Start()
    {
        _abilityColdownImage.fillAmount = 0;
    }
    public void SetAbilityImage(Sprite abilityIcon)
    {
        _abilityImage = GetComponent<Image>();
        _abilityImage.sprite = abilityIcon;
    }

    public void StartCooldown(float cooldown)
    {
        StartCoroutine(Cooldown(cooldown));
    }

    private IEnumerator Cooldown(float cooldown)
    {
        _isAbilityCooldown = true;
        _abilityColdownImage.fillAmount = 1; 

        while (_abilityColdownImage.fillAmount > 0)
        {
            _abilityColdownImage.fillAmount -= 1 / cooldown * Time.deltaTime; 
            yield return null; 
        }

        _abilityColdownImage.fillAmount = 0; 
        _isAbilityCooldown = false; 
    }
}
