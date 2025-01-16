using System.Collections;
using UnityEngine;
using UnityEngine.UI;
public abstract class Ability : MonoBehaviour
{
    [SerializeField] private GameObject _ability;
    [SerializeField] private Transform _spawnpoint;
    [SerializeField] private AbilityStats _stats;

    [SerializeField] private Image _abilityColdownImage;
    [SerializeField] private Image _abilityImage;
    private bool _isAbilityCooldown;

    protected abstract void InitAbility(GameObject instancedAbility, AbilityStats stats);
    private void Start()
    {
        _abilityColdownImage.fillAmount = 0;
    }

    protected void SetAbilityImage(Sprite abilityIcon)
    {
        _abilityImage.sprite = abilityIcon;
    }

    private void StartCooldown(float cooldown)
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

    public void Use()
    {
        if (!_isAbilityCooldown)
        {
            StartCooldown(_stats.Cooldown);
            GameObject instancedAbility = Instantiate(_ability, _spawnpoint.position, Quaternion.identity);
            InitAbility(instancedAbility, _stats);
        }
    }
}
