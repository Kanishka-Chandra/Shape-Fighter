using UnityEngine;
using System.Collections;
using TMPro;

public class DisplayHighscores : MonoBehaviour {

	public TextMeshProUGUI[] highscoreFields;
	Highscores highscoresManager;

	void Start() {
		for (int i = 0; i < highscoreFields.Length; i ++) {
			highscoreFields[i].text = i+1 + ". Fetching...";
		}

				
		highscoresManager = GetComponent<Highscores>();
		StartCoroutine(RefreshHighscores());
	}
	
	public void OnHighscoresDownloaded(Score[] highscoreList) {
		for (int i =0; i < highscoreFields.Length; i ++) {
			
			if (i < highscoreList.Length) {
				highscoreFields[i].SetText((i+1) + ". " + highscoreList[i].username + " - " + highscoreList[i].score);
			}
		}
	}
	
	IEnumerator RefreshHighscores() {
		while (true) {
			highscoresManager.DownloadHighscores();
			yield return new WaitForSeconds(30);
		}
	}
}