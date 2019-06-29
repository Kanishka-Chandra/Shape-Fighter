using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    public static BulletSpawner Instance;
    [Range(0.0f, 1.0f)]
    public float bulletSpeed;
    private ObjectPooler objectPooler;
    private Vector3 spawnPosition;
    private AudioManager audioManager;

    private void Awake() {
        Instance = this;
    }
    void Start()
    {
        audioManager = AudioManager.instance;
        objectPooler = ObjectPooler.Instance;
        spawnPosition = transform.position;
    }

    private void Update() {
        
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            CircleBullet();
        }
        if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            SquareBullet();
        }
        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            TriangleBullet();
        }
    }

    public void TriangleBullet()
    {
        audioManager.Play("BulletFire");
        objectPooler.SpawnFromPool("Triangle Bullet", spawnPosition, Quaternion.identity);
    }
    public void CircleBullet()
    {
        audioManager.Play("BulletFire");
        objectPooler.SpawnFromPool("Circle Bullet", spawnPosition, Quaternion.identity);
    }
    public void SquareBullet()
    {
        audioManager.Play("BulletFire");
        objectPooler.SpawnFromPool("Square Bullet", spawnPosition, Quaternion.identity);
    }
}
