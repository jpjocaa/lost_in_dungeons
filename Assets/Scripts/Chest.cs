using Unity.VisualScripting;
using UnityEngine;

public class Chest : MonoBehaviour, IInteracatable
{
    [SerializeField] private RewardMenu menu;

    private void Awake()
    {
        menu = FindFirstObjectByType<RewardMenu>();
        Debug.Log(menu);
    }
    public void Interact()
    {
        menu.OpenMenu();
        Debug.Log("ABRIU!");
        Destroy(gameObject);
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
