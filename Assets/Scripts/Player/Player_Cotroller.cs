using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player_Cotroller : MonoBehaviour //Decide quando as coisas devem acontecer
{

    public Rigidbody2D Rb2D; 
    public BoxCollider2D collider;
    public Transform transform;


    public Shoot shooting; 
    // IMPORTANTE: NÃO SE USA NEW PARA INSTANCIAR MONOBEHAVIOR! por isso precisa ter a linha 18.
    //A linha 18 só funciona pq está no mesmo gameobject tbm.
    private float shootTimer = 0f;
    [SerializeField] private float ShootCooldown = 1f;


    void Start()
    {
        this.Rb2D = GetComponent<Rigidbody2D>();
        this.collider = GetComponent<BoxCollider2D>();
        this.transform = GetComponent<Transform>();
        shooting = GetComponent<Shoot>();
        
    }

    void Update()
    {
        if (shootTimer > 0)
        {
            shootTimer -= Time.deltaTime;
        }   
    }


    public void Shoot(InputAction.CallbackContext context) //PRECISA DE COOLDOWN E SUMIR A BALA!
    {
        if(context.performed && shootTimer <= 0f )
        {
            shooting.ShootPlayer(transform);
            shootTimer = ShootCooldown;

            //Debug.Log(Input.mousePosition);
        }
    }
    
    
}
