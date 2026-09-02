using UnityEngine;
using UnityEngine.InputSystem;

public class Player_Cotroller : MonoBehaviour
{

    public Rigidbody2D Rb2D; 
    public BoxCollider2D collider;
    public Transform transform;


    public Shoot shooting; 
    // IMPORTANTE: NÃO SE USA NEW PARA INSTANCIAR MONOBEHAVIOR! por isso precisa ter a linha 18.
    //A linha 18 só funciona pq está no mesmo gameobject tbm.
    void Start()
    {
        this.Rb2D = GetComponent<Rigidbody2D>();
        this.collider = GetComponent<BoxCollider2D>();
        this.transform = GetComponent<Transform>();
        shooting = GetComponent<Shoot>();
    }


    public void Shoot(InputAction.CallbackContext context)
    {
        if(context.performed)
        {
            shooting.ShootPlayer(transform);
            Debug.Log(Input.mousePosition);
        }
    }
    
}
