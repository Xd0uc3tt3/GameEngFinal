using UnityEngine;
using UnityEngine.InputSystem;

public class InteractionController : MonoBehaviour
{
    private IInteractable currentInteractable;

    public void OnInteract(InputAction.CallbackContext context)
    {
        if (!context.performed) return;

        if (currentInteractable != null)
        {
            currentInteractable.Interact();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent<IInteractable>(out IInteractable interactable))
        {
            currentInteractable = interactable;
            currentInteractable.OnFocus();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.TryGetComponent<IInteractable>(out IInteractable interactable))
        {
            if (interactable == currentInteractable)
            {
                currentInteractable.OnUnfocus();
                currentInteractable = null;
            }
        }
    }
}

