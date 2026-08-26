using UnityEngine;
using UnityEngine.InputSystem;

public class Player_Cotroller : MonoBehaviour
{
    public Rigidbody2D Rb2D; 
    public BoxCollider2D collider;
    public Transform transform;


    public Shoot shooting = new();
    void Start()
    {
        this.Rb2D = GetComponent<Rigidbody2D>();
        this.collider = GetComponent<BoxCollider2D>();
        this.transform = GetComponent<Transform>();
    }


    void Update()
    {
        
    }

    public void Shoot(InputAction.CallbackContext context)
    {
        if(context.performed)
        {
            shooting.Gunning();
            Debug.Log(Input.mousePosition);
        }
    }
    
}
