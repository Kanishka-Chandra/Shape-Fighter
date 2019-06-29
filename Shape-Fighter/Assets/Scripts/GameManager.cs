using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Animator animator;
    public GameObject gameOverUI;
    public static GameManager Instance;

    private void Awake() {
        Instance = this;
        gameOverUI.SetActive(false);
    }
    private void Update() {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(1);
        }
    }

    public void GameOver()
    {
        gameOverUI.SetActive(true);
        animator.SetTrigger("SceneChange");
    }
}