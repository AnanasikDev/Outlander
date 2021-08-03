using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance { get; private set; }
    private void Awake() => instance = this;
    private void Start()
    {
        Cursor.visible = false;
    }
    private void Update()
    {
        FollowCursor();
    }
    private void FollowCursor()
    {
        transform.position = Input.mousePosition;
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.TryGetComponent<Enemy>(out Enemy enemy))
        {
            Debug.Log("The End");
        }
    }
}
