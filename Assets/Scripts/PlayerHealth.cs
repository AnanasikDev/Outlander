using UnityEngine;
using UnityEngine.UI;
public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private float _healthPoints = 1;
    protected float HealthPoints
    {
        get
        {
            return _healthPoints;
        }
        set
        {
            _healthPoints = Mathf.Clamp((float)System.Math.Round(value, 2), 0, 1);
            SetHealthBar();

            if (Mathf.Approximately(_healthPoints, 0))
            {
                Debug.LogWarning("end");
            }
        }
    }
    
    [SerializeField] private Image HealthImage;
    private float HealthImageLength;

    [SerializeField] float HealFreq = 0.25f;
    [SerializeField] float HealValue = 0.1f;

    
    protected void InitHealth()
    {
        HealthImageLength = HealthImage.GetComponent<RectTransform>().rect.width;
        HealFreq = 1 / HealFreq;
        InvokeRepeating("Heal", HealFreq, HealFreq);
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
    private void Heal()
    {
        HealthPoints += HealValue;
    }
    private void Die()
    {

    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.TryGetComponent<Enemy>(out Enemy enemy))
        {
            TakeDamage(enemy.Damage);

            enemy.Destroy();
        }
    }
}
