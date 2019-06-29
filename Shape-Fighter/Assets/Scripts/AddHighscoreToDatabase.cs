using UnityEngine;
using UnityEngine.SceneManagement;

public class AddHighscoreToDatabase : MonoBehaviour
{
    void Start()
    {  
        int score = PlayerPrefs.GetInt("HighScore", 0);
        string name = PlayerPrefs.GetString("PlayerName", "");
        Highscores.AddNewHighscore(name, score); 
    }

    private void Update() {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(1);
        }
    }

}
