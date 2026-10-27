using UnityEngine;

public class Chest : MonoBehaviour, IInteracatable
{
    public void Interact()
    {
        Debug.Log("Baú irá abrir!");
    }

    public void OnNotTouchingPlayer()
    {
        Debug.Log("N é possivel abrir o baú mais");
    }

    public void OnTouchingPlayer()
    {
        Debug.Log("É possivel abrir o baú!");
    }
}
