using UnityEditorInternal;
using UnityEngine;
using UnityEngine.InputSystem;

public class Interactor : MonoBehaviour
{
    
    private IInteracatable currentInteractable;

    public void Interact(InputAction.CallbackContext context)
    {
        if(context.performed|| currentInteractable != null)
        {
            currentInteractable.Interact();
        }
        else if (currentInteractable == null)
        {
            Debug.Log("Sem interação!");
        }
    }

    public void SetInteractable(IInteracatable interactable)
    {
        currentInteractable = interactable;
        currentInteractable.OnTouchingPlayer();
    }

    public void ClearInteractable(IInteracatable interactable)
    {
        if (currentInteractable != interactable)
            return;

        currentInteractable.OnNotTouchingPlayer();
        currentInteractable = null;
    }

}