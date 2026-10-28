using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player_Cotroller : MonoBehaviour //Decide quando as coisas devem acontecer
{

    public Rigidbody2D Rb2D; 
    public BoxCollider2D collider;
    public Transform transform;
    public GameObject gameObject;


    public Shoot shooting; 
    // IMPORTANTE: NÃO SE USA NEW PARA INSTANCIAR MONOBEHAVIOR! por isso precisa ter a linha 18.
    //A linha 18 só funciona pq está no mesmo gameobject tbm.
    private float shootTimer = 0f;

    private PlayerBaseStats stats;
    [SerializeField] private float ShootCooldown = 1f;


    void Start()
    {
        stats = GetComponent<PlayerBaseStats>();
        this.Rb2D = GetComponent<Rigidbody2D>();
        this.collider = GetComponent<BoxCollider2D>();
        this.transform = GetComponent<Transform>();
        this.gameObject = GetComponent<GameObject>();
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
            shooting.ShootPlayer(transform, gameObject, stats.BaseDamage);
            shootTimer = ShootCooldown;

            //Debug.Log(Input.mousePosition);
        }
    }
    
    
}
