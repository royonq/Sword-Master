using UnityEngine;
using UnityEngine.UI;

public class PlayerBars : MonoBehaviour
{
    [SerializeField] private Image _healthbar;
    private float _maxHealth;

    private void Start()
    {
        _healthbar.fillAmount = 1;
    }

    public void SetMaxHealth(float playerMaxHealth)
    {
        _maxHealth = playerMaxHealth;
    }

    public void ChangeValue(float currentHealth)
    {
        _healthbar.fillAmount = Mathf.Clamp01(currentHealth / _maxHealth);
    }
}
