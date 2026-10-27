
using UnityEngine;

public class InteractionDetector : MonoBehaviour
{
    private Interactor interactor;

    private void Awake()
    {
        interactor = GetComponentInParent<Interactor>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        IInteracatable interactable =
            collision.GetComponent<IInteracatable>();

        if (interactable == null)
            interactable = collision.GetComponentInParent<IInteracatable>();

        if (interactable != null)
        {
            interactor.SetInteractable(interactable);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        IInteracatable interactable =
            collision.GetComponent<IInteracatable>();

        if (interactable == null)
            interactable = collision.GetComponentInParent<IInteracatable>();

        if (interactable != null)
        {
            interactor.ClearInteractable(interactable);
        }
    }
}
