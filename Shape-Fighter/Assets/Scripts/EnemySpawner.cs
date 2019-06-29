using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public static EnemySpawner Instance;
    [Range(0.0f, 1.0f)]
    public float enemySpeed;
    public float timeToSpawn;
    private float currentTime;
    private string[] enemies = {"Triangle", "Square", "Circle"};
    private ObjectPooler objectPooler;
    private AudioManager audioManager;

    private void Awake() {
        Instance = this;
    }
    void Start()
    {
        audioManager = AudioManager.instance;
        objectPooler = ObjectPooler.Instance;
        currentTime = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime;
        if (currentTime > timeToSpawn)
        {
            currentTime = 0f;
            int spawnIndex = (int)Random.Range(0,enemies.Length);
            audioManager.Play("EnemyStart");
            objectPooler.SpawnFromPool(enemies[spawnIndex], transform.position, Quaternion.identity);
        }
    }
}
