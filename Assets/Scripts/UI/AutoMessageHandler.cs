using System.Collections;
using UnityEngine;

public class AutoMessageHandler : MonoBehaviour
{
    [SerializeField] private float _messageDurationTime;
    [SerializeField] private CanvasGroup _canvasGroup;

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


        float t = 0;
        while (t < 1)
        {
            t += Time.deltaTime * _messageDurationTime;
            _canvasGroup.alpha = Mathf.Lerp(0, 1, t);
            yield return null;
        }


        yield return new WaitForSeconds(2);


        t = 0;
        while (t < 1)
        {
            t += Time.deltaTime * _messageDurationTime;
            _canvasGroup.alpha = Mathf.Lerp(1, 0, t);
            yield return null;
        }

        _canvasGroup.gameObject.SetActive(false);
        _currentCoroutine = null;
    }
}
