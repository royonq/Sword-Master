using UnityEngine;

public class InteractableHandler : MonoBehaviour
{
    private Trader _interactable;

    private void Awake()
    {
        PlayerInput.OnPlayerInteract += Interact;
    }

    private void OnDestroy()
    {
        PlayerInput.OnPlayerInteract -= Interact;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Interactable"))
        {
            Debug.Log("InZone");
            _interactable = other.GetComponent<Trader>();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Interactable"))
        {
            _interactable = null;
        }
    }

    private void Interact()
    {
        if (!_interactable)
        {
            return;
        }

        _interactable.OpenTradePannel();
    }
}