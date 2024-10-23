using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class CoolDown : MonoBehaviour
{

    [SerializeField] private float _timeCooldown;
    [SerializeField] private Image _abilityImage;
    private bool _iscooldown;
    public bool IsCooldown { get { return _iscooldown; } }
    private void Start()
    {
        _abilityImage.fillAmount = 0;
    }
    public IEnumerator Cooldown()
    {
        _iscooldown = true;
        _abilityImage.fillAmount = 1; 

        while (_abilityImage.fillAmount > 0)
        {
            _abilityImage.fillAmount -= 1 / _timeCooldown * Time.deltaTime; 
            yield return null; 
        }

        _abilityImage.fillAmount = 0; 
        _iscooldown = false; 
    }
}
