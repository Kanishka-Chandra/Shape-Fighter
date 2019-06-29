using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Animation : MonoBehaviour
{
    
    public Animator animator = null;
    public float timeToWait = 0f;
    private int currentLevel;
    private void Start() {
        currentLevel = SceneManager.GetActiveScene().buildIndex;
    }
    public void TimeScaleOnStart()
    {
        Time.timeScale = 0;
    }

    public void TimeScaleOnEnd()
    {
        Time.timeScale = 1;
    }

    public void Introduction()
    {
        if(currentLevel == 0)
        {
            StartCoroutine(LoadMainMenu());
        }
    }

    public void LoadLevel()
    {
        int levelToLoad = currentLevel;
        if(currentLevel != 2 )
        {
            levelToLoad +=1;
        }

        TimeScaleOnEnd();
        SceneManager.LoadScene(levelToLoad);
    }

    IEnumerator LoadMainMenu()
    {
        yield return new WaitForSeconds(timeToWait);
        animator.SetTrigger("SceneChange"); 
    }
}
