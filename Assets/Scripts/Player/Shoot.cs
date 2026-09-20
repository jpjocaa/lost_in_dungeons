using UnityEngine;
using UnityEngine.InputSystem;

public class Shoot : MonoBehaviour //Define direção
{
    [SerializeField] private GameObject bulletprefab;
    private Collider2D shooterCollider;

    void Start()
    {
        shooterCollider = GetComponent<Collider2D>();   
    }

    //METODO PRINCIPAL DE DIREÇÃO DE TIRO
    public void ShootDirection(Transform firepoint, Vector2 direction)
    {
        GameObject bulletprefarb = Instantiate(
            bulletprefab,
            firepoint.position,
            Quaternion.identity
        );
        BulletMovement bulletMovement = bulletprefarb.GetComponent<BulletMovement>();  
        Collider2D shooterCollider = GetComponent<Collider2D>();  
        bulletMovement.SetDirection(direction, shooterCollider);

       
    }


    public void ShootPlayer(Transform transform)
    {
        Vector2 direction = MousePosition(transform);
        ShootDirection(transform, direction);
    }


    Vector2 MousePosition(Transform firepoint)
    {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(
            Mouse.current.position.ReadValue()
        );

        Vector2 direction = mousePosition - (Vector2)firepoint.position;

        return direction.normalized;
    }
}
