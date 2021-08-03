using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] protected Vector3 Direction;
    [SerializeField] protected float Speed;
    private void Start()
    {
        SetDirection();

        Destroy(gameObject, 25);
    }
    private void FixedUpdate()
    {
        Move();
    }
    protected virtual void SetDirection()
    {
        Direction = Vector3.RotateTowards(transform.position, (transform.position - PlayerController.instance.transform.position), 10, 0).normalized;
        Direction.z = 0;
    }
    protected virtual void Move()
    {
        transform.Translate(Direction * Speed);
    }
    public void SetSpeed(float speed)
    {
        Speed = speed;
    }
}
