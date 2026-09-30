using UnityEngine;
using UnityEngine.InputSystem;

public class Shoot : MonoBehaviour
{
    [SerializeField] private GameObject bulletprefab;

    private Collider2D shooterCollider;

    void Start()
    {
        shooterCollider = GetComponent<Collider2D>();
    }

    public void ShootDirection(
        Transform firepoint,
        Vector2 direction,
        GameObject shooter)
    {
        GameObject bulletprefarb = Instantiate(
            bulletprefab,
            firepoint.position,
            Quaternion.identity
        );

        BulletMovement bulletMovement =
            bulletprefarb.GetComponent<BulletMovement>();

        bulletMovement.Initialize(direction, shooter);
    }

    public void ShootPlayer(Transform transform, GameObject player)
    {
        Vector2 direction = MousePosition(transform);

        ShootDirection(transform,direction,gameObject);
    }

    Vector2 MousePosition(Transform firepoint)
    {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(
            Mouse.current.position.ReadValue()
        );

        Vector2 direction =
            mousePosition - (Vector2)firepoint.position;

        return direction.normalized;
    }
}