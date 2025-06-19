using System.Collections;
using UnityEngine;

public class AutoMessageHandler : MonoBehaviour
{
    [SerializeField] private float _messageDurationTime;
    [SerializeField] private CanvasGroup _canvasGroup;
    private readonly float _massageFadeTime = 2;

    private Coroutine _currentCoroutine;

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
        if (_currentCoroutine != null)
        {
            StopCoroutine(_currentCoroutine);
        }

        _currentCoroutine = StartCoroutine(FadeInFadeOutMessage());
    }


    private IEnumerator FadeInFadeOutMessage()
    {
        _canvasGroup.gameObject.SetActive(true);
        _canvasGroup.alpha = 0;


        float time = 0;
        while (time < 1)
        {
            time += Time.deltaTime * _messageDurationTime;
            _canvasGroup.alpha = Mathf.Lerp(0, 1, time);
            yield return null;
        }


        yield return new WaitForSeconds(_massageFadeTime);


        time = 0;
        while (time < 1)
        {
            time += Time.deltaTime * _messageDurationTime;
            _canvasGroup.alpha = Mathf.Lerp(1, 0, time);
            yield return null;
        }

        _canvasGroup.gameObject.SetActive(false);
        _currentCoroutine = null;
    }
}
