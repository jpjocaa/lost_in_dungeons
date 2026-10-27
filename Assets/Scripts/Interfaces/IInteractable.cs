using UnityEngine;

public interface IInteracatable
{
    void Interact();

    void OnTouchingPlayer();

    void OnNotTouchingPlayer();
}
