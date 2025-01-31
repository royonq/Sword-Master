using UnityEngine;
using UnityEngine.UI;

public class PlayerBars : MonoBehaviour
{
    [SerializeField] private Image _healthbar;

    private void Start()
    {
        _healthbar.fillAmount = 1;
    }

    public void ChangeValue(float currentHealth, float maxHealth)
    {
        _healthbar.fillAmount = Mathf.Clamp01(currentHealth / maxHealth);
    }
}
