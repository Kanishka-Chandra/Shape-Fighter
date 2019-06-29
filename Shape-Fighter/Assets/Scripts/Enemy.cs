using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Enemy : MonoBehaviour
{
    private float speed;
    private GameManager gameManager;
    private ScoreBoard scoreBoard;
    private Rigidbody2D rb;

    private void Start() {
        gameManager = GameManager.Instance;
        scoreBoard = ScoreBoard.Instance;
        rb = gameObject.GetComponent<Rigidbody2D>();
        rb.gravityScale = 0;
        speed = EnemySpawner.Instance.enemySpeed;
    }

    private void FixedUpdate() {
        //rb.MovePosition(Vector2.left * Time.fixedDeltaTime);

        //speed = EnemySpawner.Instance.enemySpeed;
        transform.position = Vector2.Lerp(transform.position, (Vector2.left * 50), speed * Time.fixedDeltaTime);
    }
    private void OnCollisionEnter2D(Collision2D other) {
        if (gameObject.tag == other.gameObject.tag)
        {
            scoreBoard.SetScore(1);
            gameObject.SetActive(false);
        }
        else 
        {
            gameManager.GameOver();
        }
    }
}
