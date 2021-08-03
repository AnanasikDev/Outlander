using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Collider2D))]
public class PlayerController : PlayerHealth
{
    public static PlayerController instance { get; private set; }
    private void Awake() => instance = this;
    private void Start()
    {
        InitHealth();
    }
    private void Update()
    {
        if (Settings.IsPlaying)
            FollowCursor();
    }
    private void FollowCursor()
    {
        transform.position = Input.mousePosition;
    }
}
