using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] protected Vector3 Direction;
    [SerializeField] protected float Speed;
    [SerializeField] public float Damage = 0.2f;

    [SerializeField] protected ParticleSystem DestroyEffect;
    private void Start()
    {
        SetDirection();
        SetTorque();

        Destroy(gameObject, 25);
    }
    private void SetTorque()
    {
        GetComponent<Rigidbody2D>().AddTorque(Random.value);
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
    public virtual void Destroy()
    {
        DestroyEffect.Play();
        DestroyEffect.transform.SetParent(null);

        Destroy(gameObject);
        Destroy(DestroyEffect.gameObject, 3);
    }
}
