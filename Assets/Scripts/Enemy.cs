using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] protected Vector3 Direction;
    [SerializeField] protected float Speed;
    [SerializeField] public float Damage = 0.2f;

    [SerializeField] protected ParticleSystem DestroyEffect;
    
    [SerializeField] protected float Torque;

    private void Start()
    {
        SetDirection();
        SetTorque();

        Destroy(gameObject, 25);
    }
    private void SetTorque()
    {
        Torque = Random.Range(Torque * -0.8f, Torque * 1.2f);
    }
    private void FixedUpdate()
    {
        transform.localEulerAngles += Vector3.forward * Torque;
        Move();
    }
    protected virtual void SetDirection()
    {
        Direction = -Vector3.RotateTowards(transform.position, (transform.position - PlayerController.instance.transform.position), 10, 0).normalized;
        Direction.z = 0;
    }
    protected virtual void Move()
    {
        transform.Translate(Direction * Speed, Space.World);
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
