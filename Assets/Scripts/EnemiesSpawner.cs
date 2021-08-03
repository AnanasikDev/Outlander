using UnityEngine;

public class EnemiesSpawner : MonoBehaviour
{
    [SerializeField] private Enemy[] SpawnableEnemies;
    [SerializeField] private Vector2 SpawnRadiusLimits;
    [SerializeField] private Transform EnemiesHandler;

    [SerializeField] private float StartSpawnDelay = 3;
    private float SpawnFreqStatic;
    [SerializeField] private float SpawnFreq = 3;

    [SerializeField] private AnimationCurve HardnessCurve;
    [SerializeField] private int HardnessUpdateTimeDelay = 15;

    [SerializeField] private AnimationCurve EnemiesSpeedCurve;
    [SerializeField] private float EnemySpeed = 1;
    private float EnemySpeedStatic = 1;

    [SerializeField] private float CurrentCurvePosition = 0;
    [SerializeField] private float HardnessCurveLength = 1;
    [SerializeField] private float EnemySpeedCurveLength = 1;
    [SerializeField] private float CurveStep = 0.1f;

    private float _hardness;
    private float Hardness
    {
        set
        {
            _hardness = value;
            SpawnFreq = SpawnFreqStatic + _hardness;
        }
    }
    private void Start()
    {
        SpawnFreq = 1 / SpawnFreq;

        SpawnFreqStatic = SpawnFreq;
        EnemySpeedStatic = EnemySpeed;

        BeginSpawning();
    }
    private void BeginSpawning()
    {
        InvokeRepeating("SpawnEnemy", StartSpawnDelay, SpawnFreq);
        InvokeRepeating("UpdateHardness", 0, HardnessUpdateTimeDelay);
    }
    protected virtual Enemy GetEnemy()
    {
        return SpawnableEnemies[Random.Range(0, SpawnableEnemies.Length)];
    }
    protected virtual Vector2 GetPosition()
    {
        float angle = Random.value * 360;
        float radius = Random.Range(SpawnRadiusLimits.x, SpawnRadiusLimits.y);

        Vector3 position = new Vector3
            (
                Mathf.Sin(angle) * radius, 
                Mathf.Cos(angle) * radius
            );

        return position + PlayerController.instance.transform.position;
    }
    protected virtual Quaternion GetEnemyRotation()
    {
        return new Quaternion(0, 0, Random.value, 0);
    }
    protected virtual void SpawnEnemy()
    {
        Enemy enemyPrefab = GetEnemy();
        Vector2 enemyPosition = GetPosition();

        Enemy enemySpawned = Instantiate(enemyPrefab, enemyPosition, GetEnemyRotation(), EnemiesHandler);
        enemySpawned.SetSpeed(EnemySpeed);
    }
    protected virtual void UpdateHardness()
    {
        Hardness = HardnessCurve.Evaluate(Mathf.Repeat(CurrentCurvePosition, HardnessCurveLength));
        CurrentCurvePosition += CurveStep;

        EnemySpeed = EnemySpeedStatic * EnemiesSpeedCurve.Evaluate(Mathf.Repeat(CurrentCurvePosition, EnemySpeedCurveLength));
    }
}
