using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Bullet : MonoBehaviour
{
    private float speed;
    private Rigidbody2D rb;

    private void Start() {
        rb = gameObject.GetComponent<Rigidbody2D>();
        rb.gravityScale = 0;
        speed = BulletSpawner.Instance.bulletSpeed;
    }

    private void FixedUpdate() {
        //rb.MovePosition(Vector2.left * Time.fixedDeltaTime);

        //speed = BulletSpawner.Instance.bulletSpeed;
        transform.position = Vector2.Lerp(transform.position, (Vector2.right * 50), speed * Time.fixedDeltaTime);
    }
    private void OnCollisionEnter2D(Collision2D other) {
        if (gameObject.tag == other.gameObject.tag)
        {
            gameObject.SetActive(false);
        }
    }
}
