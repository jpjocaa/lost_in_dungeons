using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    [SerializeField] private float velocity = 10f;

    private Vector2 direction;

    public void SetDirection(Vector2 direction)
    {
        this.direction = direction;
    }

    private void Update()
    {
        transform.Translate(direction * velocity * Time.deltaTime);
    }
}
