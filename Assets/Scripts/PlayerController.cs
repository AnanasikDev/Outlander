using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Collider2D))]
public class PlayerController : PlayerHealth
{
    public static PlayerController instance { get; private set; }
    private void Awake() => instance = this;
    private void Start()
    {
        Cursor.visible = false;
        InitHealth();
    }
    private void Update()
    {
        FollowCursor();
    }
    private void FollowCursor()
    {
        transform.position = Input.mousePosition;
    }
}
