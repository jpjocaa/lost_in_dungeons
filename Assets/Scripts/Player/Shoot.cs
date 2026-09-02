using UnityEngine;
using UnityEngine.InputSystem;

public class Shoot : MonoBehaviour
{
    [SerializeField] private GameObject bulletprefab;

    public void ShootPlayer(Transform firepoint)
    {
        Vector2 direction = MousePosition(firepoint);

        GameObject bulletprefarb = Instantiate(
            bulletprefab,
            firepoint.position,
            Quaternion.identity
        );

        BulletMovement bulletMovement = bulletprefarb.GetComponent<BulletMovement>();

        if (bulletMovement != null)
        {
            bulletMovement.SetDirection(direction);
        }
        else
        {
            Debug.LogError("Player_Bullet não possui o componente BulletMovement!");
        }
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
