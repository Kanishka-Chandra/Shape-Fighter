using UnityEngine;
using TMPro;

public class ScoreBoard : MonoBehaviour{
    public static ScoreBoard Instance;
    public TextMeshProUGUI scoreUI;
    public TextMeshProUGUI highScoreUI;
    private int score;
    private int highScore;// holds the highscore
    private void Awake() {
        Instance = this;
        highScore = PlayerPrefs.GetInt("HighScore", 0); // inilitises the highscore
    }
    
    private void Start() {
        score = 0;
        highScoreUI.SetText("HighScore : " + highScore.ToString());
        scoreUI.SetText("Score : 0");
    }

    public void SetScore(int scoreToAdd){
        score += scoreToAdd;
        scoreUI.SetText("Score : "+score);
        SetHighScore();
    }
    private void SetHighScore()
    {
        if (score > highScore)
        {
            PlayerPrefs.SetInt("HighScore", score);
            highScoreUI.SetText("HighScore : " + score.ToString());
            //Highscores.AddNewHighscore("Kanishka", score);
        }
    }

}