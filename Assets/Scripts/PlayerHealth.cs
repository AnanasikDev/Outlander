using UnityEngine;
using UnityEngine.UI;
public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private float healthPoints = 1;
    protected float HealthPoints
    {
        get
        {
            return healthPoints;
        }
        set
        {
            healthPoints = Mathf.Clamp((float)System.Math.Round(value, 2), 0, 1);
            SetHealthBar();

            if (Mathf.Approximately(healthPoints, 0))
            {
                Debug.LogWarning("end");
            }
        }
    }
    
    [SerializeField] private Image HealthImage;

    public float HealthImageLength;
    protected void InitHealth()
    {
        HealthImageLength = HealthImage.GetComponent<RectTransform>().rect.width;
    }

    private void SetHealthBar()
    {
        HealthImage.transform.localPosition = new Vector3
            (
                -HealthImageLength * (1 - HealthPoints),
                0,
                0
            );
    }
    protected void TakeDamage(float damage)
    {
        HealthPoints -= damage;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.TryGetComponent<Enemy>(out Enemy enemy))
        {
            TakeDamage(enemy.Damage);
        }
    }
}
