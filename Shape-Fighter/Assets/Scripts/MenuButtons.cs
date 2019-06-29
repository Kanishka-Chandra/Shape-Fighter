using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtons : MonoBehaviour
{
    public Animator animator;

    private AudioManager audioManager;
    

    private void Start() {
        audioManager = AudioManager.instance;
        
    }
    public void Play()
    {
        audioManager.Play("Click");
        animator.SetTrigger("SceneChange");
    }

    public void ResetScore()
    {
        audioManager.Play("Click");
        PlayerPrefs.DeleteAll();
    }

    public void LeaderBoard()
    {
        audioManager.Play("Click");
        SceneManager.LoadScene(3);
    }

    public void Quit()
    {
        audioManager.Play("Click");
        Application.Quit();
    }
}
