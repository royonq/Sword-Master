using System.Collections;
using TMPro;
using UnityEngine;

public class AutoMessageHandler : MonoBehaviour
{
    private readonly float _massageFadeTime = 2;
    
    [SerializeField] private float _messageDurationTime; 
    private TMP_Text _text;
    
    private bool _isFadeing;

    private void Start()
    {
        _text = GetComponent<TMP_Text>();
        _text.CrossFadeAlpha(0, 0, false);
    }

    private void OnEnable()
    {
        ProjectileAbility.OnTryUseAutoAbility += ShowMessage;
    }


    private void OnDisable()
    {
        ProjectileAbility.OnTryUseAutoAbility -= ShowMessage;
    }


    private void ShowMessage()
    {
        if (_isFadeing)
        {
            return;
        }

        StartCoroutine(FadeInFadeOutMessage());
    }


    private IEnumerator FadeInFadeOutMessage()
    {
        _isFadeing = true;
        
        _text.CrossFadeAlpha(1, _massageFadeTime, false);

        yield return new WaitForSeconds(_massageFadeTime);

        _text.CrossFadeAlpha(0, _massageFadeTime, false);
        
        yield return new WaitForSeconds(_massageFadeTime);
        
        _isFadeing = false;
    }
}
